using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    public class Report
    {
        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private string nameTable;

        public string NameTable
        {
            get { return nameTable; }
            set { nameTable = value; }
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

        private long totalPrice;

        public long TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }

        public Report(long id, string nameTable, string day, string month, string year, string timeCheckIn, string timeCheckOut, long totalPrice)
        {
            this.Id = id;
            this.NameTable = nameTable;
            this.Day = day;
            this.Month = month;
            this.Year = year;
            this.TimeCheckIn = timeCheckIn;
            this.TimeCheckOut = timeCheckOut;
            this.TotalPrice = totalPrice;
        }

        public Report(DataRow row)
        {
            this.Id = (long)row["Id"];
            this.NameTable = row["NameTable"].ToString();
            this.Day = row["Day"].ToString();
            this.Month = row["Month"].ToString();
            this.Year = row["Year"].ToString();
            this.TimeCheckIn = row["TimeCheckIn"].ToString();
            this.TimeCheckOut = row["TimeCheckOut"].ToString();
            this.TotalPrice = (long)row["TotalPrice"];
        }
    }
}
