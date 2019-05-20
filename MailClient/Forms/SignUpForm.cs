using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
//chừa chỗ cho service reference

namespace MailClient.Forms
{
    public delegate void SignUpHandler(string username, string passwd, RSAParameters privkey);

    public partial class SignUpForm : Form
    {
        public event SignUpHandler Signup;

        public SignUpForm()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                MessageBox.Show("You must be enter your user name!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(txtConfirm.Text))
            {
                MessageBox.Show("You must be enter your password twice!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.Equals(txtPassword.Text, txtConfirm.Text))
            {
                MessageBox.Show("Password wrong!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(1024))
                    {
                        string pubkey = rsa.ToXmlString(false);
                        string privkey = rsa.ToXmlString(true);

                        string fname = PrivPubKey.GenerateEncryptedPrivFile(privkey, txtUsername.Text, txtPassword.Text, "AES-256-CBC");
                        //Send sign up info
                        var client = ; /* create proxy here */
                        client.sendSignUpInfo(txtUsername.Text, txtPassword.Text, txtName.Text, pubkey, new FileStream(fname, FileMode.Open, FileAccess.Read), Path.GetFileName(fname));

                        RSAParameters privatekey = convertXML2key(privkey);
                        Signup.Invoke(txtUsername.Text, txtPassword.Text, privatekey);

                        Close();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("User name must be unique!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void chbAcceptTerm_CheckedChanged(object sender, EventArgs e)
        {
            if (chbAcceptTerm.Checked == true)
                if (btnSignUp.Enabled == false) btnSignUp.Enabled = true;
        }

        private static RSAParameters convertXML2key(string xmlstr)
        {
            StringReader str = new StringReader(xmlstr);
            XmlTextReader xr = new XmlTextReader(str);
            XmlDocument xml = new XmlDocument();
            xml.Load(xr);
            RSAParameters rsakey;
            rsakey.Modulus = Convert.FromBase64String(xml.GetElementsByTagName("Modulus")[0].InnerText);
            rsakey.Exponent = Convert.FromBase64String(xml.GetElementsByTagName("Exponent")[0].InnerText);
            rsakey.P = Convert.FromBase64String(xml.GetElementsByTagName("P")[0].InnerText);
            rsakey.Q = Convert.FromBase64String(xml.GetElementsByTagName("Q")[0].InnerText);
            rsakey.D = Convert.FromBase64String(xml.GetElementsByTagName("D")[0].InnerText);
            rsakey.DP = Convert.FromBase64String(xml.GetElementsByTagName("DP")[0].InnerText);
            rsakey.DQ = Convert.FromBase64String(xml.GetElementsByTagName("DQ")[0].InnerText);
            rsakey.InverseQ = Convert.FromBase64String(xml.GetElementsByTagName("InverseQ")[0].InnerText);

            return rsakey;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
