using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    public class Bill
    {
        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private string dateCheckIn;

        public string DateCheckIn
        {
            get { return dateCheckIn; }
            set { dateCheckIn = value; }
        }

        private string dateCheckOut;

        public string DateCheckOut
        {
            get { return dateCheckOut; }
            set { dateCheckOut = value; }
        }

        private long idTable;

        public long IdTable
        {
            get { return idTable; }
            set { idTable = value; }
        }

        private long status;

        public long Status
        {
            get { return status; }
            set { status = value; }
        }

        public Bill(long id, string dateCheckIn, string dateCheckOut, long idTable, long status)
        {
            this.Id = id;
            this.DateCheckIn = dateCheckIn;
            this.DateCheckOut = dateCheckOut;
            this.IdTable = idTable;
            this.Status = status;
        }

        public Bill(DataRow row)
        {
            this.Id = (long)row["Id"];
            this.DateCheckIn = row["DateCheckIn"].ToString();
            this.DateCheckOut = row["DateCheckOut"].ToString();
            this.IdTable = (long)row["IdTable"];
            this.Status = (long)row["Status"];
        }
    }
}
