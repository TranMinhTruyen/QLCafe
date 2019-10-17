using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe
{
    public class ReportProvider
    {
        #region Singleton Bill
        private static ReportProvider instance;

        public static ReportProvider Instance
        {
            get 
            {
                if (instance == null)
                    instance = new ReportProvider();
                return ReportProvider.instance; 
            }
            private set { ReportProvider.instance = value; }
        }

        private ReportProvider() { }
        #endregion

        #region Methods
        public long GetMaxReportId()
        {
            string query = "SELECT max(id) FROM Report";

            try
            {
                long maxId = (long)DataProvider.Instance.ExecuteScalar(query);

                return maxId;
            }
            catch
            {
                return 0;
            }
        }

        public bool InsertReport(long idTable, long idBill) // Unit Test
        {
            long tableCount = 0;
            long billCount = 0;

            List<Table> listTable = TableProvider.Instance.GetTableList();
            List<Bill> listBill = BillProvider.Instance.GetListBill();

            foreach (Table item in listTable)
            {
                if (item.Id == idTable)
                {
                    tableCount++;

                    break;
                }
            }

            foreach (Bill item in listBill)
            {
                if (item.Id == idBill)
                {
                    billCount++;

                    break;
                }
            }

            if (tableCount > 0 && billCount > 0)
            {
                long id = GetMaxReportId() + 1;

                Table table = TableProvider.Instance.GetTable_By_Id(idTable);
                Bill bill = BillProvider.Instance.GetBill_By_Id(idBill);

                string query = "INSERT INTO Report (Id,NameTable,Day,Month,Year,TimeCheckIn,TimeCheckOut,TotalPrice) VALUES (" + id.ToString() + "," + "'" + table.Name + "'" + "," + bill.Day + "," + bill.Month + "," + bill.Year + "," + "'" + bill.TimeCheckIn + "'" + "," + "'" + bill.TimeCheckOut + "'" + "," + bill.TotalPrice.ToString() + ")";

                DataProvider.Instance.ExecuteNonQuery(query);

                return true;
            }
            else
                return false;
        }

        public DataTable LoadPaidBill_By_MonthAndYear(long month, long year) // Unit Test
        {
            string query = "SELECT Id, NameTable as [Tên bàn], TotalPrice [Tổng tiền], Day || '/' || Month || '/' || Year as [Ngày thanh toán], TimeCheckIn as [Giờ tạo hóa đơn], TimeCheckOut as [Giờ xuất hóa đơn] FROM Report WHERE Month = " + month.ToString() + " AND Year = " + year.ToString();

            DataTable PaidBill = DataProvider.Instance.ExecuteQuery(query);

            return PaidBill;
        }

        public void LoadPaidBill(DataGridView dataThongKe, DateTimePicker dateTimeThongKe)
        {
            string monthYear = dateTimeThongKe.Value.Month.ToString() + "/" + dateTimeThongKe.Value.Year.ToString();

            string[] slitDateTime = monthYear.Split('/');

            long month = Convert.ToInt64(slitDateTime[0]);

            long year = Convert.ToInt64(slitDateTime[1]);

            dataThongKe.DataSource = LoadPaidBill_By_MonthAndYear(month, year);
        }
        #endregion
    }
}
