using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Cafe
{
    public class Account
    {
        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        private string passWord;

        public string PassWord
        {
            get { return passWord; }
            set { passWord = value; }
        }

        private long type;

        public long Type
        {
            get { return type; }
            set { type = value; }
        }

        public Account(string userName, string passWord, long type)
        {
            this.UserName = userName;
            this.PassWord = passWord;
            this.Type = type;
        }

        public Account(DataRow row)
        {
            this.UserName = row["Username"].ToString();
            this.PassWord = row["Password"].ToString();
            this.Type = (long)row["Type"];
        }
    }
}
