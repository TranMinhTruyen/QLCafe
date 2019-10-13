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

        public void InsertBill(long idTable)
        {
            long id = GetMaxBillId() + 1;

            string checkInDate = DateTime.Now.ToString();

            string query = "INSERT INTO Bill (Id,DateCheckIn,IdTable) VALUES (" + id.ToString() + "," + "'" + checkInDate + "'" + "," + idTable.ToString() + ")";

            DataProvider.Instance.ExecuteNonQuery(query);
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

        public void CreateNewBill_Or_UpdateBill(Table table, ComboBox cbDrink)
        {
            long idBillMax;
            long idDrink;

            long idBill = GetBillId_ByTableId(table.Id);

            if (idBill == -1)
            {
                InsertBill(table.Id);

                idBillMax = GetMaxBillId();
                idDrink = (cbDrink.SelectedItem as Drink).Id;

                BillInfoProvider.Instance.InsertBillInfo(idDrink, idBillMax);
            }
            else
            {
                idDrink = (cbDrink.SelectedItem as Drink).Id;

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

        public void UpdateStatusBill(long idBill)
        {
            string checkOutDate = DateTime.Now.ToString();

            string query = "UPDATE Bill SET DateCheckOut = " + "'" + checkOutDate + "'" + ", Status = 1 WHERE id = " + idBill.ToString();

            DataProvider.Instance.ExecuteNonQuery(query);
        } 
        #endregion
    }
}
