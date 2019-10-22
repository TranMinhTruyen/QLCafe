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

        private string day;

        public string Day
        {
            get { return day; }
            set { day = value; }
        }

        private string month;

        public string Month
        {
            get { return month; }
            set { month = value; }
        }

        private string year;

        public string Year
        {
            get { return year; }
            set { year = value; }
        }

        private string timeCheckIn;

        public string TimeCheckIn
        {
            get { return timeCheckIn; }
            set { timeCheckIn = value; }
        }

        private string timeCheckOut;

        public string TimeCheckOut
        {
            get { return timeCheckOut; }
            set { timeCheckOut = value; }
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

        private long totalPrice;

        public long TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }

        public Bill(long id, string day, string month, string year, string timeCheckIn, string timeCheckOut, long idTable, long status, long totalPrice)
        {
            this.Id = id;
            this.Day = day;
            this.Month = month;
            this.Year = year;
            this.TimeCheckIn = timeCheckIn;
            this.TimeCheckOut = timeCheckOut;
            this.IdTable = idTable;
            this.Status = status;
            this.TotalPrice = totalPrice;
        }

        public Bill(DataRow row)
        {
            this.Id = (long)row["Id"];
            this.Day = row["Day"].ToString();
            this.Month = row["Month"].ToString();
            this.Year = row["Year"].ToString();
            this.TimeCheckIn = row["TimeCheckIn"].ToString();
            this.TimeCheckOut = row["TimeCheckOut"].ToString();
            this.IdTable = (long)row["IdTable"];
            this.Status = (long)row["Status"];
            this.TotalPrice = (long)row["TotalPrice"];
        }
    }
}
