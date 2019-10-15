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
        public List<Drink> GetDrink_ByCategoryId(long idCategory) // Unit Test
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

        public List<Drink> LoadListDrink()
        {
            string query = "SELECT * FROM Drink";

            List<Drink> listDrink = new List<Drink>();

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Drink drink = new Drink(item);

                listDrink.Add(drink);
            }

            return listDrink;
        }

        public DataTable LoadNamePriceDrink_By_Category()
        {
            string query = "SELECT Drink.Id, Drink.Name as [Tên], Drink.Price as [Giá], Category.Name as [Loại] FROM Drink, Category where Drink.IdCategory = Category.Id";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            return data;
        }

        public void Binding_NamePriceDrink(TextBox txtName, NumericUpDown nudPrice, DataGridView dgvDrink)
        {
            txtName.DataBindings.Add(new Binding("Text", dgvDrink.DataSource, "Tên", true, DataSourceUpdateMode.Never));
            nudPrice.DataBindings.Add(new Binding("Value", dgvDrink.DataSource, "Giá", true, DataSourceUpdateMode.Never));
        }

        public long GetMaxDrinkId()
        {
            string query = "SELECT max(id) FROM Drink";

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

        public bool InsertDrink(string name, long price, long idCategory) // Unit Test
        {
            long id = GetMaxDrinkId() + 1;

            string query = "INSERT INTO Drink(Id,Name,Price,IdCategory) VALUES(" + id.ToString() + "," + "'" + name + "'" + "," + price.ToString() + "," + idCategory.ToString() + ")";

            long result = DataProvider.Instance.ExecuteNonQuery(query);

            if (result > 0)
                return true;
            else
                return false;
        }

        public bool UpdateDrink(long id, string name, long price, long idCategory) // Unit Test
        {
            string query = "UPDATE Drink SET Name = " + "'" + name + "'" + ", Price = " + price.ToString() + ", IdCategory = " + idCategory.ToString() + " WHERE Id = " + id.ToString();

            long result = DataProvider.Instance.ExecuteNonQuery(query);

            if (result > 0)
                return true;
            else
                return false;
        }

        public bool DeleteDrink(long idDrink) // Unit Test
        {
            long drinkCount = 0;

            List<Drink> listDrink = LoadListDrink();

            foreach (Drink item in listDrink)
            {
                if (item.Id == idDrink)
                {
                    drinkCount++;

                    break;
                }
            }

            if (drinkCount > 0)
            {
                BillInfoProvider.Instance.DeleteBillInfo_By_idDrink(idDrink);

                string query = "DELETE FROM Drink WHERE Id = " + idDrink.ToString();

                DataProvider.Instance.ExecuteNonQuery(query);

                return true;
            }
            else
                return false;
        }
        #endregion
    }
}
