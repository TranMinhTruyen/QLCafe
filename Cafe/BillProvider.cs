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
        public long GetBillId_By_TableId(long idTable) // Unit Test
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

        public Bill GetBill_By_Id(long idBill) // Unit Test
        {
            try
            {
                string query = "SELECT * FROM Bill WHERE Id =" + idBill.ToString();

                DataTable dataBill = DataProvider.Instance.ExecuteQuery(query);

                Bill bill = new Bill(dataBill.Rows[0]);

                return bill;
            }
            catch
            {
                return null;
            }
        }

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

        public List<Bill> GetListBill_By_TableID(long idTable) // Unit Test
        {
            List<Bill> listBillid = new List<Bill>();

            string query = "SELECT * from Bill WHERE IdTable = " + idTable.ToString();

            DataTable dataBill = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in dataBill.Rows)
            {
                Bill billId = new Bill(item);

                listBillid.Add(billId);
            }

            return listBillid;
        }

        public List<Bill> GetListBill()
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

        public List<long> GetListBillId_By_IdDrink(long idDrink) // Unit Test
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

        public bool InsertBill(long idTable)  // Unit Test
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

                string queryBill = "INSERT INTO Bill (Id,Day,Month,Year,TimeCheckIn,IdTable) VALUES (" + id.ToString() + "," + day + "," + month + "," + year + "," + "'" + timeCheckIn + "'" + "," + idTable.ToString() + ")";

                DataProvider.Instance.ExecuteNonQuery(queryBill);

                return true;
            }
            else
                return false;

        }

        public void CreateNewBill_Or_UpdateBill(Table table, ComboBox cbDrink)
        {
            long idBillMax;

            long idDrink = (cbDrink.SelectedItem as Drink).Id; ;
            long idBill = GetBillId_By_TableId(table.Id);

            if (idBill == -1)
            {
                InsertBill(table.Id);

                idBillMax = GetMaxBillId();

                BillInfoProvider.Instance.InsertBillInfo(idDrink, idBillMax);
            }
            else
            {
                BillInfo billInfo = BillInfoProvider.Instance.GetBillInfo_ByDrinkID_And_BillId(idDrink, idBill);

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

            List<Bill> listBill = BillProvider.Instance.GetListBill();

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

        public bool DeleteBill(long idBill) // Unit Test
        {
            long billCount = 0;

            List<Bill> listBill = GetListBill();

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

        public bool DeleteBill_By_IdTable(long idTable) // Unit Test
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

            List<Bill> listTableId = GetListBill_By_TableID(idTable);

            if (tableCount > 0)
            {
                foreach (Bill item in listTableId)
                {
                    BillInfoProvider.Instance.DeleteBillInfo_By_idBill(item.Id);
                }

                foreach (Bill item in listTableId)
                {
                    string queryDeleteBill = "DELETE FROM Bill WHERE IdTable = " + item.IdTable.ToString();

                    DataProvider.Instance.ExecuteNonQuery(queryDeleteBill);
                }

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
