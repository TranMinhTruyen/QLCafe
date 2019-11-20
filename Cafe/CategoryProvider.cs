using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe
{
    public class CategoryProvider
    {
        #region Singleton Category
        private static CategoryProvider instance;

        public static CategoryProvider Instance
        {
            get 
            {
                if (instance == null)
                    instance = new CategoryProvider();
                return CategoryProvider.instance;
            }
            private set { CategoryProvider.instance = value; }
        }

        private CategoryProvider() { }
        #endregion

        #region Methods
        public List<Category> GetListCategory()
        {
            List<Category> listCategory = new List<Category>();

            string query = "select * from Category";

            DataTable dataCategory = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in dataCategory.Rows)
            {
                Category category = new Category(item);

                listCategory.Add(category);
            }

            return listCategory;
        }

        public long GetCategoryId(ComboBox cbCategory, object sender)
        {
            cbCategory = sender as ComboBox;

            if (cbCategory.SelectedItem == null)
                return -1;
            else
            {
                Category select = cbCategory.SelectedItem as Category;

                long id = select.Id;

                return id;
            }
        }

        public Category GetCategory_By_Name(string categoryName)
        {
            Category category = null;

            string query = "SELECT * from Category WHERE Name = '" + categoryName.ToString() + "'";

            DataTable dataCategory = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in dataCategory.Rows)
            {
                category = new Category(item);

                return category;
            }

            return category;
        }

        public long GetMaxCategoryID()
        {
            string query = "SELECT max(id) FROM Category";

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

        public void LoadCategory(ComboBox cbCategory)
        {
            List<Category> listCategory = GetListCategory();

            if (listCategory.Count != 0)
            {
                cbCategory.DataSource = listCategory;
                cbCategory.DisplayMember = "Name";
            }
            else
                cbCategory.Text = "Chưa có danh sách loại thức uống";
        }

        public bool InsertCategory(string name)
        {
            long id = GetMaxCategoryID() + 1;

            string query = "INSERT INTO Category(Id,Name) VALUES(" + id.ToString() + "," + "'" + name + "'" + ")";

            long result = DataProvider.Instance.ExecuteNonQuery(query);

            if (result > 0)
                return true;
            else
                return false;
        } // Unit Test

        public bool UpdateCategory(long id, string name) // Unit Test
        {
            string query = "UPDATE Category SET Name = " + "'" + name + "' WHERE Id = " + id.ToString();

            long result = DataProvider.Instance.ExecuteNonQuery(query);

            if (result > 0)
                return true;
            else
                return false;
        }

        public bool DeleteCategory(long idCategory) // Unit Test
        {
            long categoryCount = 0;

            List<Category> listCategory = GetListCategory();

            foreach (Category item in listCategory)
            {
                if (item.Id == idCategory)
                {
                    categoryCount++;

                    break;
                }
            }

            if (categoryCount > 0)
            {
                List<Drink> drinkList = DrinkProvider.Instance.GetDrink_ByCategoryId(idCategory);

                foreach (Drink item in drinkList)
                {
                    DrinkProvider.Instance.DeleteDrink(item.Id);
                }

                string query = "DELETE FROM Category WHERE Id = " + idCategory.ToString();

                DataProvider.Instance.ExecuteNonQuery(query);

                return true;
            }
            else
                return false;
        }

        public void LoadCategory_By_Datagridview(string nameCategory, ComboBox cbCategory)
        {
            Category category = GetCategory_By_Name(nameCategory);

            int index = -1;
            int i = 0;

            foreach (Category item in cbCategory.Items)
            {
                if (category != null)
                {
                    if (item.Name == category.Name)
                    {
                        index = i;

                        break;
                    }
                    i++;
                }
                else
                    cbCategory.Text = "";
            }

            cbCategory.SelectedIndex = index;
        }

        public DataTable LoadCategory_To_Datagridview()
        {
            string query = "SELECT Id, Name as [Tên] FROM Category";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            return data;
        }

        public void Binding_Category(TextBox txtName, DataGridView dgvDrink)
        {
            txtName.DataBindings.Add(new Binding("Text", dgvDrink.DataSource, "Tên", true, DataSourceUpdateMode.Never));
        }
        #endregion
    }

}
