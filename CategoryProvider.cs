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

        public long GetCategoryId(ComboBox cbCategory , object sender)
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
        #endregion
    }

}
