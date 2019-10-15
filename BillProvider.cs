using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe
{
    public class BillProvider
    {
        #region Singleton Bill
        private static BillProvider instance;

        public static BillProvider Instance
        {
            get 
            {
                if (instance == null)
                    instance = new BillProvider();
                return BillProvider.instance; 
            }
            private set { BillProvider.instance = value; }
        }

        private BillProvider() { }
        #endregion

        #region Methods
        public long GetBillId_ByTableId(long idTable) // Unit Test
        {
            string query = "SELECT * FROM Bill WHERE IdTable = " + idTable.ToString() + " AND Status = 0";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            if (data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);

                return bill.Id;
            }

            return -1;
        }

        public bool InsertBill(long idTable)
        {
            long tableCount = 0;

            List<Table> listTable = TableProvider.Instance.GetTableList();

            foreach (Table item in listTable)
            {
                if (item.Id == idTable)
                {
                    tableCount++;

                    break;
                }
            }

            if (tableCount > 0)
            {
                long id = GetMaxBillId() + 1;

                DateTime now = DateTime.Now;

                string day = now.Day.ToString();
                string month = now.Month.ToString();
                string year = now.Year.ToString();
                string timeCheckIn = DateTime.Now.ToString("hh:mm:ss tt");

                string query = "INSERT INTO Bill (Id,Day,Month,Year,TimeCheckIn,IdTable) VALUES (" + id.ToString() + "," + day + "," + month + "," + year + "," + "'" + timeCheckIn + "'" + "," + idTable.ToString() + ")";

                DataProvider.Instance.ExecuteNonQuery(query);

                return true;
            }
            else
                return false;

        } // Unit Test

        public long GetMaxBillId()
        {
            string query = "SELECT max(id) FROM Bill";

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

        public void CreateNewBill_Or_UpdateBill(Table table, ComboBox cbDrink)
        {
            long idBillMax;

            long idDrink = (cbDrink.SelectedItem as Drink).Id; ;
            long idBill = GetBillId_ByTableId(table.Id);

            if (idBill == -1)
            {
                InsertBill(table.Id);

                idBillMax = GetMaxBillId();

                BillInfoProvider.Instance.InsertBillInfo(idDrink, idBillMax);
            }
            else
            {
                BillInfo billInfo = BillInfoProvider.Instance.GetBillInfoId_ByDrinkID(idDrink, idBill);

                if (billInfo != null)
                {
                    BillInfoProvider.Instance.UpdateBillInfo(idDrink, idBill);
                }
                else
                {
                    BillInfoProvider.Instance.InsertBillInfo(idDrink, idBill);
                }
            }
        }

        public bool UpdateStatusBill(long idBill, long totalPrice) // Unit Test
        {
            long billCount = 0;

            List<Bill> listBill = BillProvider.Instance.LoadListBill();

            foreach (Bill item in listBill)
            {
                if (item.Id == idBill)
                {
                    billCount++;

                    break;
                }
            }

            if (billCount > 0)
            {
                string timeCheckOut = DateTime.Now.ToString("hh:mm:ss tt");
                string query = "UPDATE Bill SET TimeCheckOut = " + "'" + timeCheckOut + "'" + ", Status = 1, TotalPrice = " + totalPrice.ToString() + " WHERE id = " + idBill.ToString();

                DataProvider.Instance.ExecuteNonQuery(query);

                return true;
            }
            else
                return false;

        }

        public DataTable LoadPaidBill_By_MonthAndYear(long month, long year) // Unit Test
        {
            string query = "SELECT TableDrink.Name as [Tên bàn], Bill.TotalPrice [Tổng tiền], Bill.Day || '/' || Bill.Month || '/' || Bill.Year as [Ngày thanh toán], Bill.TimeCheckIn as [Giờ tạo hóa đơn], bill.TimeCheckOut as [Giờ xuất hóa đơn] FROM Bill, TableDrink WHERE Bill.Month = " + month.ToString() + " AND Bill.Year = " + year.ToString()+ " AND Bill.Status = 1 AND TableDrink.Id = Bill.IdTable";

            DataTable PaidBill = DataProvider.Instance.ExecuteQuery(query);

            return PaidBill;
        }

        public void LoadPaidBill(DataGridView dataThongKe, DateTimePicker dateTimeThongKe)
        {
            string monthYear = dateTimeThongKe.Value.Month.ToString() + "/" + dateTimeThongKe.Value.Year.ToString();

            string[] slitDateTime = monthYear.Split('/');

            long month = Convert.ToInt64(slitDateTime[0]);

            long year = Convert.ToInt64(slitDateTime[1]);

            dataThongKe.DataSource = BillProvider.Instance.LoadPaidBill_By_MonthAndYear(month, year);
        }

        public List<Bill> LoadListBill()
        {
            string query = "SELECT * FROM Bill";

            List<Bill> listBill = new List<Bill>();

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Bill bill = new Bill(item);

                listBill.Add(bill);
            }

            return listBill;
        }

        public List<long> GetBillId_By_IdDrink(long idDrink) // Unit Test
        {
            List<long> listBillId = new List<long>();

            string query = "SELECT IdBill FROM BillInfo WHERE IdDrink = " + idDrink.ToString();

            DataTable dataBillInfo = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in dataBillInfo.Rows)
            {
                long billId = (long)item[0];

                listBillId.Add(billId);
            }

            return listBillId;
        }

        public bool DeleteBill(long idBill) // Unit Test
        {
            long billCount = 0;

            List<Bill> listBill = LoadListBill();

            foreach (Bill item in listBill)
            {
                if (item.Id == idBill)
                {
                    billCount++;

                    break;
                }
            }

            if (billCount > 0)
            {
                string query = "DELETE FROM Bill WHERE Id = " + idBill.ToString();

                DataProvider.Instance.ExecuteNonQuery(query);

                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
