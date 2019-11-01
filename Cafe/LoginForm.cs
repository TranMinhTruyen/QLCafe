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

            if (check == 1)
            {
                Form1 f = new Form1("Admin");

                this.Hide();
                f.ShowDialog();
            }
            else if (check == 0)
            {
                Form1 f = new Form1("Staff");

                this.Hide();
                f.ShowDialog();
            }
            else if (check == -1)
            {
                MessageBox.Show("Bạn chưa nhập username và password", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtUserName.Clear();
                txtPassWord.Clear();

                txtUserName.Focus();
            }
            else if (check == -2)
            {
                MessageBox.Show("Bạn chưa nhập username", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtUserName.Clear();

                txtUserName.Focus();
            }
            else if (check == -3)
            {
                MessageBox.Show("Bạn chưa nhập password", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtPassWord.Clear();

                txtPassWord.Focus();
            }
            else if (check == -4)
            {
                MessageBox.Show("Bạn nhập sai username hoặc password", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtUserName.Focus();
            }
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

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtPassWord_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
