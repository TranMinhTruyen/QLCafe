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

        #region Login Button
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string passWord = txtPassWord.Text.Trim();

            if(userName == "" && passWord == "")
            {
                MessageBox.Show("Bạn chưa nhập username và password", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtUserName.Clear();
                txtPassWord.Clear();

                txtUserName.Focus();
            }
            else if(userName == "" && passWord != "")
            {
                MessageBox.Show("Bạn chưa nhập username", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtUserName.Clear();

                txtUserName.Focus();
            }
            else if(userName != "" && passWord == "")
            {
                MessageBox.Show("Bạn chưa nhập password", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtPassWord.Clear();

                txtPassWord.Focus();
            }
            else
            {
                if (Login(userName, passWord))
                {
                    Account loginAccount = GetAccountByUser(userName);
                    if (true)
                    {
                        if (loginAccount.Type == 1)
                        {
                            Form1 f = new Form1("Admin");

                            this.Hide();
                            f.ShowDialog();
                        }
                        else
                        {
                            Form1 f = new Form1("Staff");

                            this.Hide();
                            f.ShowDialog();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Bạn nhập sai username hoặc password", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    txtUserName.Focus();
                }
            }
        }

        private bool Login(string userName, string passWord)
        {
            string query = "SELECT * FROM Account WHERE Username='" + userName + "' AND Password = '" + passWord + "'";

            DataTable result = DataProvider.Instance.ExecuteQuery(query);

            if (result.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        private Account GetAccountByUser(string userName)
        {
            string query  = "SELECT * FROM Account WHERE Username ='" + userName + "'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }
            return null;
        }
        #endregion

        #region Exit Button
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
