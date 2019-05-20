using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace MailClient.UC
{
    public partial class MainUI : UserControl
    {
        internal static RSAParameters privateKey;           //private key đc truyền từ MainForm
        internal static string username;
        string plaintextWithSignature;
        byte[] encrypteddata;
        byte[] encSK;
        byte[] encIV;

        public MainUI()
        {
            InitializeComponent();
        }

        public MainUI(RSAParameters _privateKey, string _username)
        {
            InitializeComponent();
            privateKey = _privateKey;
            username = _username;
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            try
            {
                //concatenate recipient id, title and message content 
                string presignData = txtRecipient.Text + txtTitle.Text + txtContent.Text;
                //Sign
                byte[] signatureData = CryptoFunctions.RSASign(Encoding.Unicode.GetBytes(presignData), privateKey, new SHA256CryptoServiceProvider());
                //Concatenate content with signature
                plaintextWithSignature = "<Datamail><Content>" + txtContent.Text + "</Content><Signature>" + Convert.ToBase64String(signatureData) + "</Signature></Datamail>";
            }
            catch (CryptographicException ex)
            {
                MessageBox.Show("Cannot sign this mail!!");
            }
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                var client = ; /* create proxy here */
                byte[] compressedData = Zip(Encoding.ASCII.GetBytes(plaintextWithSignature));
                byte[] sessionkey = new byte[16];
                byte[] iv = new byte[16];
                encrypteddata = CryptoFunctions.AESEncrypt(compressedData, sessionkey, iv);
                string xmlstr = client.getPublicKey(txtRecipient.Text);
                encSK = null;
                encIV = null;
                using (RSACryptoServiceProvider rsak = new RSACryptoServiceProvider())
                {
                    rsak.FromXmlString(xmlstr);
                    RSAParameters key = rsak.ExportParameters(false);
                    encSK = CryptoFunctions.RSAEncrypt(sessionkey, key, false);
                    encIV = CryptoFunctions.RSAEncrypt(iv, key, false);
                }

                
            }
            catch (CryptographicException ex)
            {
                MessageBox.Show("Cannot encrypt this mail!!");
            }
        }

        public static byte[] Zip(byte[] bytes)
        {
            //var bytes = Encoding.UTF8.GetBytes(str);

            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(mso, CompressionMode.Compress))
                {
                    msi.CopyTo(gs);
                    //CopyTo(msi, gs);
                }

                return mso.ToArray();
            }
        }
        
        public static byte[] Unzip(byte[] bytes)
        {
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(msi, CompressionMode.Decompress))
                {
                    gs.CopyTo(mso);
                    //CopyTo(gs, mso);
                }

                //return Encoding.UTF8.GetString(mso.ToArray());
                return mso.ToArray();
            }
        }

        private void MainUI_Load(object sender, EventArgs e)
        {
            //Lấy ds mail về rồi load vào listview
            var client = ; /* create proxy here */
            List<ReceivedMailInfo> list = client.getReceivedMailList(username);
            ListViewItem[] listitem = new ListViewItem[list.Count];
            foreach (ListViewItem item in listitem)
            {
                int index = item.Index;
                item.Text = list[index].senderName + "    " + list[index].mailID;
                item.SubItems.Add(list[index].senderName);
                item.SubItems.Add(list[index].title);
                item.SubItems.Add(list[index].mailID);

                lsvMail.Items.Add(item);
            }

            
        }

        private void lsvMail_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            Font tempfont = e.Item.Font;
            e.Item.Font = new Font(tempfont, tempfont.Style ^ FontStyle.Bold);

            txtSender.Text = e.Item.SubItems[1].Text;
            txtSubject.Text = e.Item.SubItems[2].Text;
            //Lấy thư về
            var client = ; /* create proxy here */
            string path;
            string content = null;
            Stream fs = client.getMail(e.Item.SubItems[3].Text, out path);
            using (StreamReader sr = new StreamReader(fs))
            {
                content = sr.ReadToEnd();
            }
            fs.Close();
            Mail mail = (Mail)ObjectToXML(content, typeof(Mail));
            try
            {
                //Decrypt
                byte[] sessionKey = CryptoFunctions.RSADecrypt(Convert.FromBase64String(mail.SessionKey), privateKey, false);
                byte[] iv = CryptoFunctions.RSADecrypt(Convert.FromBase64String(mail.IV), privateKey, false);
                byte[] decrypteddata = CryptoFunctions.AESDecrypt(Convert.FromBase64String(mail.encryptedContent), sessionKey, iv);
                byte[] decompressdata = Unzip(decrypteddata);
                string retrievedcontent = Encoding.ASCII.GetString(decompressdata);

                //Verify and show
                Datamail datam = (Datamail)ObjectToXML(retrievedcontent, typeof(Datamail));
                txtContent1.Text = datam.Content;
                string pubk = client.getPublicKey(txtSender.Text);
                using (RSACryptoServiceProvider rsak = new RSACryptoServiceProvider()) {
                    rsak.FromXmlString(pubk);

                    if(CryptoFunctions.RSAVerify(Encoding.Unicode.GetBytes(datam.Content), Convert.FromBase64String(datam.Signature), rsak.ExportParameters(false), new SHA256CryptoServiceProvider())) {
                        lblNotifyImage.Image = Properties.Resources.icons8_checked_32;
                        lblNotify.Text = "SUCCESSFULLY VERIFY!!";
                    }
                    else
                    {
                        lblNotifyImage.Image = Properties.Resources.icons8_error_30;
                        lblNotify.Text = "FAILED VERIFY!!";
                    }
                    
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("Somethings is wrong!! " + exp.Message);
                lblNotifyImage.Image = Properties.Resources.icons8_error_30;
                lblNotify.Text = "FAILED VERIFY!!";
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Random rd = new Random();
            string tempid = rd.Next(1, 999).ToString().PadLeft(3, '0');
            string mpath = @"Mail\M" + tempid + ".mail";
            using (StreamWriter fsw = new StreamWriter(mpath))
            {
                fsw.Write(@"<?xml version='1.0' encoding='UTF - 8'?><Mail>");
                fsw.Write("<SessionKey>" + Convert.ToBase64String(encSK) + "</SessionKey>");
                fsw.Write("<IV>" + Convert.ToBase64String(encIV) + "</IV>");
                fsw.Write("<encryptedContent>" + Convert.ToBase64String(encrypteddata) + "</encryptedContent>");
                fsw.Write("</Mail>");

            }
            string mailid = "M" + tempid;
            //Form pfr = Parent as Form;
            var client = ; /* create proxy here */
            client.sendEncryptedMail(txtRecipient.Text, new FileStream(mpath, FileMode.Open, FileAccess.Read), Path.GetFileName(mpath), new ReceivedMailInfo { mailid, username, txtTitle.Text });
        }

        public static object ObjectToXML(string xml, Type objectType)
        {
            StringReader strReader = null;
            XmlSerializer serializer = null;
            XmlTextReader xmlReader = null;
            object obj = null;
            try
            {
                strReader = new StringReader(xml);
                serializer = new XmlSerializer(objectType);
                xmlReader = new XmlTextReader(strReader);
                obj = serializer.Deserialize(xmlReader);
            }
            catch (Exception exp)
            {
                MessageBox.Show("Convert error!!");
            }
            finally
            {
                if (xmlReader != null)
                {
                    xmlReader.Close();
                }
                if (strReader != null)
                {
                    strReader.Close();
                }
            }
            return obj;
        }
    }

    public class Mail
    {
        public string SessionKey;
        public string IV;
        public string encryptedContent;

        public Mail(string sessionKey, string iV, string encryptedContent)
        {
            SessionKey = sessionKey;
            IV = iV;
            this.encryptedContent = encryptedContent;
        }
    }

    public class Datamail
    {
        public string Content;
        public string Signature;

        public Datamail(string content, string signature)
        {
            Content = content;
            Signature = signature;
        }
    }
}
