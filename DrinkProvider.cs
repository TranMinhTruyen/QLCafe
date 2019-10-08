using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public List<Drink> GetDrinkByCategoryId(long id)
        {
            List<Drink> list = new List<Drink>();

            string query = "SELECT * from Drink WHERE IdCategory = " + id.ToString();

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Drink drink = new Drink(item);

                list.Add(drink);
            }

            return list;
        } 
        #endregion
    }
}
