using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Windows.Forms;
using MailClient.UC;
using MailClient.Forms;

namespace MailClient
{
    public partial class MainForm : Form
    {
        string apppassword;
        string appusername;

        public MainForm()
        {
            InitializeComponent();
        }

        private void ChangeUI(string username, string passwd, RSAParameters privkey)
        {
            appusername = username;
            apppassword = passwd;

            pnlMain.Controls.Clear();
            MainUI ucMain = new MainUI(privkey, appusername);       //truyền khóa vào
            ucMain.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(ucMain);

            tsbtnSignUp.Enabled = false;
            tslblAccount.Text = appusername;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //pnlMain.Controls.Clear();
            SignIn ucSignIn = new SignIn();
            ucSignIn.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(ucSignIn);
            //SignIn.Instance.BringToFront();
            ucSignIn.Signin += ChangeUI;
        }

        private void tsbtnSignUp_Click(object sender, EventArgs e)
        {
            SignUpForm frmSignUp = new SignUpForm();
            frmSignUp.ShowDialog();

            frmSignUp.Signup += ChangeUI;
        }

        //public static RSAParameters XMLToRSAkey(string xml)
        //{
        //    StringReader strReader = null;
        //    XmlSerializer serializer = null;
        //    XmlTextReader xmlReader = null;
        //    object obj = null;
        //    try
        //    {
        //        strReader = new StringReader(xml);
        //        serializer = new XmlSerializer(typeof(RSAParameters));
        //        xmlReader = new XmlTextReader(strReader);
        //        obj = serializer.Deserialize(xmlReader);
        //    }
        //    catch (Exception exp)
        //    {
        //        //Handle Exception Code
        //    }
        //    finally
        //    {
        //        if (xmlReader != null) xmlReader.Close();
        //        if (strReader != null)
        //        {
        //            strReader.Close();
        //        }
        //    }
        //    return (RSAParameters)obj;
        //}
    }
}
