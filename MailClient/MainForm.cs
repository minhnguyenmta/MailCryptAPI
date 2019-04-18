using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MailClient.UC;

namespace MailClient
{
    public partial class MainForm : Form
    {
        string apppassword;

        public MainForm()
        {
            InitializeComponent();
        }

        private void ChangeUI(string passwd)
        {
            apppassword = passwd;

            pnlMain.Controls.Clear();
            MainUI ucMain = new MainUI();
            ucMain.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(ucMain);
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
    }
}
