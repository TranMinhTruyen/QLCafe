using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    public class Table
    {
        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private long status;

        public long Status
        {
            get { return status; }
            set { status = value; }
        }

        public Table(long id, string name, long status)
        {
            this.Id = id;
            this.Name = name;
            this.Status = status;
        }

        public Table(DataRow row)
        {
            this.Id = (long)row["Id"];
            this.Name = row["Name"].ToString();
            this.Status = (long)row["Status"];
        }
    }
}
