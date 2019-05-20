using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace MailClient.UC
{
    public delegate void SignInHandler(string username, string passwd, RSAParameters privkey);

    public partial class SignIn: UserControl
    {
        //private static SignIn instance;
        public event SignInHandler Signin;
        
        //internal string screenname;

        public SignIn()
        {
            InitializeComponent();
            //screenname = "Sign In";
        }

        //public static SignIn Instance
        //{
        //    get
        //    {
        //        if (instance == null) instance = new SignIn();
        //        return instance;
        //    }
        //}

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            string uname = txtUsername.Text;
            string passwd = txtPassword.Text;
            if (!Login(uname, passwd))   //Đăng nhập không thành công
            {
                lblError.Visible = true;
            }
            else
            {
                //screenname = "Main";
                //Signin?.Invoke();
                string temp;
                using (StreamReader fsr = new StreamReader(getPrivatekey(uname, passwd)))
                    temp = fsr.ReadToEnd();
                string xmlstring = PrivPubKey.DecodeRSAPrivateKey(temp, passwd);
                RSAParameters privkey = XMLToRSAkey(xmlstring);
                Signin.Invoke(uname, passwd, privkey);
            }
        }

        private bool Login(string username, string password)
        {
            var client = ; /* create proxy here */
            return client.signIn(username, password);

            //return true; //Demo! Test event xong tính sau :3
        }

        private Stream getPrivatekey(string username, string password)
        {
            //Phải dùng hàm sendSignInInfo của service
            string fname;
            var client = ; /* create proxy here */
            Stream fs = client.sendSignInInfo(username, password, out fname);
            using (StreamReader sr = new StreamReader(fs))
            {
                string temp = sr.ReadToEnd();
                using (StreamWriter sw = new StreamWriter(@"PrivK\" + fname))
                {
                    sw.Write(temp);
                }
            }

            return new FileStream(@"PrivK\" + fname, FileMode.Open, FileAccess.Read);
        }

        public static RSAParameters XMLToRSAkey(string xml)
        {
            StringReader strReader = null;
            XmlSerializer serializer = null;
            XmlTextReader xmlReader = null;
            object obj = null;
            try
            {
                strReader = new StringReader(xml);
                serializer = new XmlSerializer(typeof(RSAParameters));
                xmlReader = new XmlTextReader(strReader);
                obj = serializer.Deserialize(xmlReader);
            }
            catch (Exception exp)
            {
                MessageBox.Show("Convert error!!");
            }
            finally
            {
                if (xmlReader != null) xmlReader.Close();
                if (strReader != null)
                {
                    strReader.Close();
                }
            }
            return (RSAParameters)obj;
        }
    }
}
