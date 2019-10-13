using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe
{
    public class DrinkProvider
    {
        #region Singleton Drink
        private static DrinkProvider instance;

        public static DrinkProvider Instance
        {
            get 
            {
                if (instance == null)
                    instance = new DrinkProvider();
                return DrinkProvider.instance;
            }
            private set { DrinkProvider.instance = value; }
        }

        private DrinkProvider() { }
        #endregion

        #region Methods
        public List<Drink> GetDrink_ByCategoryId(long idCategory)
        {
            List<Drink> listDrink = new List<Drink>();

            string query = "SELECT * from Drink WHERE IdCategory = " + idCategory.ToString();

            DataTable dataDrink = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in dataDrink.Rows)
            {
                Drink drink = new Drink(item);

                listDrink.Add(drink);
            }

            return listDrink;
        }

        // User For Checking Another Method
        public long GetDrinkId(long idDrink) // Unit Test
        {
            string query = "SELECT * FROM Drink WHERE Id = " + idDrink.ToString();

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            if (data.Rows.Count > 0)
            {
                Drink drink = new Drink(data.Rows[0]);

                return drink.Id;
            }

            return -1;
        }

        public void LoadDrink_ByCategoryId(ComboBox cbDrink , ComboBox cbCategory, object sender)
        {
            long idCategory = CategoryProvider.Instance.GetCategoryId(cbCategory, sender);

            if (idCategory != -1)
            {
                List<Drink> listDrink = GetDrink_ByCategoryId(idCategory);

                cbDrink.DataSource = listDrink;
                cbDrink.DisplayMember = "Name";
            }
            else
                cbDrink.Text = "Chưa có danh sách thức uống";
        }
        #endregion
    }
}
