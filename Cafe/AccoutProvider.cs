using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe
{
    public class AccoutProvider
    {
        #region Singleton Account
        private static AccoutProvider instance;

        public static AccoutProvider Instance
        {
            get 
            {
                if (instance == null)
                    instance = new AccoutProvider();
                return AccoutProvider.instance; 
            }
            private set { AccoutProvider.instance = value; }
        }

        private AccoutProvider() { }
        #endregion

        #region Methods
        public bool CheckAccoutExit(string userName, string passWord) // Unit Test
        {
            string query = "SELECT * FROM Account WHERE Username='" + userName + "' AND Password = '" + passWord + "'";

            DataTable result = DataProvider.Instance.ExecuteQuery(query);

            if (result.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public long GetAccountType(string userName) // Unit Test
        {
            try
            {
                string query = "SELECT * FROM Account WHERE Username ='" + userName + "'";

                DataTable data = DataProvider.Instance.ExecuteQuery(query);

                Account account = new Account(data.Rows[0]);

                return account.Type;
            }
            catch
            {
                return -1;
            }
        }

        public long CheckAcount(string userName, string passWord) // Unit Test
        {
            long check;

            /*
             * check = 1: Đăng nhập bằng tài khoảng Admin
             * check = 0:  Đăng nhập bằng tài khoảng Staff
             * check = -1: Chưa nhập username và password
             * check = -2: Chưa nhập username
             * check = -3: Chưa nhập password
             * check = -4: Nhập sai username hoặc password
             * check = -5: Username chưa có
            */

            if (userName == "" && passWord == "")
            {
                check = -1;

                return check;
            }
            else if (userName == "" && passWord != "")
            {
                check = -2;

                return check;
            }
            else if (userName != "" && passWord == "")
            {
                check = -3;

                return check;
            }
            else
            {
                if (CheckAccoutExit(userName, passWord))
                {
                    long loginAccount = GetAccountType(userName); // Check Account Type

                    if (loginAccount == 1)
                    {
                        check = 1;

                        return check;
                    }
                    else if (loginAccount == 0)
                    {
                        check = 0;

                        return check;
                    }
                    else
                    {
                        check = -5;

                        return check;
                    }
                }
                else
                {
                    check = -4;

                    return check;
                }
            }
        }
        #endregion
    }
}
