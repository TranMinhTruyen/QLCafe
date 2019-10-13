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
        public List<BillInfo> GetBillInfoList(long idBill)
        {
            List<BillInfo> listBillInfo = new List<BillInfo>();

            string query = "SELECT * FROM BillInfo WHERE IdBill = " + idBill.ToString();

            DataTable dataBillInfo = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in dataBillInfo.Rows)
            {
                BillInfo billInfo = new BillInfo(item);

                listBillInfo.Add(billInfo);
            }

            return listBillInfo;
        }

        public void InsertBillInfo(long idDrink, long idBill, long countDrink = 1)
        {
            long id = GetMaxBillInfoId() + 1;
            string query = "INSERT INTO BillInfo (Id, IdDrink, IdBill, CountDrink) VALUES (" + id.ToString() + "," + idDrink.ToString() + "," + idBill.ToString() + "," + countDrink + ")";

            DataProvider.Instance.ExecuteNonQuery(query);
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

        public void UpdateBillInfo(long idDrink, long idBill)
        {
            string query = "UPDATE BillInfo SET CountDrink = CountDrink + 1 WHERE IdDrink = " + idDrink.ToString() + " AND IdBill = " + idBill.ToString();

            DataProvider.Instance.ExecuteNonQuery(query); 
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
        #endregion
    }
}
