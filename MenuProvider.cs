using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe
{
    public class MenuProvider
    {
        #region Singleton Menu
        private static MenuProvider instance;

        public static MenuProvider Instance
        {
            get 
            {
                if (instance == null)
                    instance = new MenuProvider();
                return MenuProvider.instance; 
            }
            private set { MenuProvider.instance = value; }
        }

        private MenuProvider() { }
        #endregion

        #region Methods
        public List<Menu> GetListMenu(long idTable)
        {
            List<Menu> listMenu = new List<Menu>();

            string query = "SELECT Drink.Name, BillInfo.CountDrink, Drink.Price, Drink.Price * BillInfo.CountDrink AS TotalPrice FROM Drink, Bill, BillInfo WHERE BillInfo.IdBill = Bill.Id AND BillInfo.IdDrink = Drink.Id AND Bill.Status = 0 AND Bill.IdTable = " + idTable.ToString();

            DataTable dataMenu = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in dataMenu.Rows)
            {
                Menu bill = new Menu(item);

                listMenu.Add(bill);
            }

            return listMenu;
        }

        public void ShowMenu(long idTable, ListView lvMenu, TextBox txtTongTien)
        {
            lvMenu.Items.Clear();

            long sumPrice = 0;

            List<Menu> listBill = GetListMenu(idTable);

            foreach (Menu item in listBill)
            {
                ListViewItem lvItem = new ListViewItem();

                lvItem.SubItems.Add(item.Name.ToString());
                lvItem.SubItems.Add(item.CountDrink.ToString());
                lvItem.SubItems.Add(item.Price.ToString());
                lvItem.SubItems.Add(item.TotalPrice.ToString());

                sumPrice += item.TotalPrice;

                lvMenu.Items.Add(lvItem);
            }

            txtTongTien.Text = sumPrice.ToString();
        }
        #endregion
    }
}
