using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            List<Category> list = new List<Category>();

            string query = "select * from Category";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Category category = new Category(item);

                list.Add(category);
            }

            return list;
        }
        #endregion
    }

}
