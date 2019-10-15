using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    public class BillInfoProvider
    {
        #region Singleton BillInfo
        private static BillInfoProvider instance;

        public static BillInfoProvider Instance
        {
            get 
            {
                if (instance == null)
                    instance = new BillInfoProvider();
                return BillInfoProvider.instance; 
            }
            private set { BillInfoProvider.instance = value; }
        }

        private BillInfoProvider() { }
        #endregion

        #region Methods
        public bool InsertBillInfo(long idDrink, long idBill, long countDrink = 1) // Unit Test
        {
            long drinkCount = 0;
            long billCount = 0;

            List<Drink> listDrink = DrinkProvider.Instance.LoadListDrink();
            List<Bill> listBill = BillProvider.Instance.LoadListBill();

            foreach (Drink item in listDrink)
            {
                if (item.Id == idDrink)
                {
                    drinkCount++;

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

            if (billCount > 0 && drinkCount > 0)
            {
                long id = GetMaxBillInfoId() + 1;
                string query = "INSERT INTO BillInfo (Id, IdDrink, IdBill, CountDrink) VALUES (" + id.ToString() + "," + idDrink.ToString() + "," + idBill.ToString() + "," + drinkCount + ")";

                DataProvider.Instance.ExecuteNonQuery(query);

                return true;
            }
            else
                return false;
        }

        public long GetMaxBillInfoId()
        {
            string query = "SELECT max(id) FROM BillInfo";
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

        public bool UpdateBillInfo(long idDrink, long idBill) // Unit Test
        {
            long drinkCount = 0;
            long billCount = 0;

            List<Drink> listDrink = DrinkProvider.Instance.LoadListDrink();
            List<Bill> listBill = BillProvider.Instance.LoadListBill();

            foreach (Drink item in listDrink)
            {
                if(item.Id == idDrink)
                {
                    drinkCount++;

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

            if (drinkCount > 0 && billCount > 0)
            {
                string query = "UPDATE BillInfo SET CountDrink = CountDrink + 1 WHERE IdDrink = " + idDrink.ToString() + " AND IdBill = " + idBill.ToString();

                DataProvider.Instance.ExecuteNonQuery(query);

                return true;
            }
            else
            {
                return false;
            }
        }

        public BillInfo GetBillInfoId_ByDrinkID(long idDrink, long idBill) // Unit Test
        {
           try
           {
               string query = "SELECT * FROM BillInfo WHERE IdDrink = " + idDrink.ToString() + " AND IdBill = " + idBill.ToString();

               DataTable dataBillInfo = DataProvider.Instance.ExecuteQuery(query);

               BillInfo billInfo = new BillInfo(dataBillInfo.Rows[0]);

               return billInfo;
           }
           catch
           {
               return null;
           }
        }

        public bool DeleteBillInfo_By_idDrink(long idDrink) // Unit Test
        {
            long drinkCount = 0;

            List<Drink> listDrink = DrinkProvider.Instance.LoadListDrink();

            foreach (Drink item in listDrink)
            {
                if (item.Id == idDrink)
                {
                    drinkCount++;

                    break;
                }
            }

            List<long> listBillId = BillProvider.Instance.GetBillId_By_IdDrink(idDrink);

            if (drinkCount > 0)
            {
                string query = "DELETE FROM BillInfo WHERE IdDrink = " + idDrink.ToString();

                DataProvider.Instance.ExecuteNonQuery(query);

                foreach (long item in listBillId)
                {
                    List<BillInfo> listBillInfo = GetListBillInfo_By_Id(item);

                    if (listBillInfo.Count < 1)
                        BillProvider.Instance.DeleteBill(item);
                }

                return true;
            }
            else
                return false;
        }

        public List<BillInfo> GetListBillInfo_By_Id(long id)
        {
            List<BillInfo> a = new List<BillInfo>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM BillInfo WHERE IdBill = " + id.ToString());

            foreach (DataRow item in data.Rows)
            {
                BillInfo billInfo = new BillInfo(item);

                a.Add(billInfo);
            }

            return a;
        }
        #endregion
    }
}
