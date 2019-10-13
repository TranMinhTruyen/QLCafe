using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe
{
    public class TableProvider
    {
        #region Singleton Table
        private static TableProvider instance;

        public static TableProvider Instance
        {
            get 
            {
                if (instance == null)
                    instance = new TableProvider();
                return TableProvider.instance;
            }
            private set { instance = value; }
        }

        private TableProvider() { }
        #endregion

        #region Methods
        public List<Table> GetTableList()
        {
            List<Table> listTable = new List<Table>();

            string query = "SELECT * FROM TableDrink";

            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in dataTable.Rows)
            {
                Table table = new Table(item);

                listTable.Add(table);
            }

            return listTable;
        }

        public void CreateTableList(FlowLayoutPanel flowPanel, List<Button> buttonList, List<Table> tableList)
        {
            flowPanel.Controls.Clear();

            foreach (Table item in tableList)
            {
                Button btn = new Button();

                btn.Width = 180;
                btn.Height = 180;
                btn.Margin = new Padding(12);

                btn.Font = new Font("Tahoma", 13);

                if(item.Status == 0)
                {
                    btn.Text = item.Name.ToString() + "\n (Trống)";
                }
                else if(item.Status == 1)
                {
                    btn.Text = item.Name.ToString() + "\n (Có người)";
                }

                flowPanel.Controls.Add(btn);

                btn.Tag = item;

                buttonList.Add(btn);
            }
        }

        public void TableChange(List<Button> buttonList, object sender)
        {
            foreach (Button item in buttonList)
            {
                item.BackColor = SystemColors.ControlLight;
            }

            Button btn = (Button)sender;

            btn.BackColor = Color.Red;
        }

        public void UpdateTableStatus_1(long idTable)
        {
            string query = "UPDATE TableDrink SET Status = 1 WHERE Id = " + idTable.ToString();

            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public void UpdateTableStatus_0(long idTable)
        {
            string query = "UPDATE TableDrink SET Status = 0 WHERE Id = " + idTable.ToString();

            DataProvider.Instance.ExecuteNonQuery(query);
        }
        #endregion
    }
}
