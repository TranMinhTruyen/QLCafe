using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        #region Login
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string passWord = txtPassWord.Text.Trim();

            long check = AccoutProvider.Instance.CheckAcount(userName, passWord);

            AccoutProvider.Instance.ShowAccountIfRight(check, this, txtUserName, txtPassWord);
        }
        #endregion

        #region Exit
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn thoát chương trình", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
        #endregion

    }
}
