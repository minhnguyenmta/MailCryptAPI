using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailClient.UC
{
    public delegate void SignInHandler(string passwd);

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
                Signin.Invoke(passwd);
            }
        }

        private bool Login(string username, string password)
        {
            return true; //Demo! Test event xong tính sau :3
        }
    }
}
