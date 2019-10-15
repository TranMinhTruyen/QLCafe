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

        public bool UpdateTableStatus_1(long idTable) // Unit Test
        {
            long tableCount = 0;

            List<Table> listTable = GetTableList();

            foreach (Table item in listTable)
            {
                if (item.Id == idTable)
                {
                    tableCount++;

                    break;
                }
            }

            if (tableCount > 0)
            {
                string query = "UPDATE TableDrink SET Status = 1 WHERE Id = " + idTable.ToString();

                DataProvider.Instance.ExecuteNonQuery(query);

                return true;
            }
            else
                return false;
        }

        public bool UpdateTableStatus_0(long idTable) // Unit Test
        {
            long tableCount = 0;

            List<Table> listTable = GetTableList();

            foreach (Table item in listTable)
            {
                if (item.Id == idTable)
                {
                    tableCount++;

                    break;
                }
            }

            if (tableCount > 0)
            {
                string query = "UPDATE TableDrink SET Status = 0 WHERE Id = " + idTable.ToString();

                DataProvider.Instance.ExecuteNonQuery(query);

                return true;
            }
            else
                return false;
        }

        public bool SwitchTable(long idTableOld, long idTableNew) // Unit Test
        {
            long idBillOld = BillProvider.Instance.GetBillId_ByTableId(idTableOld);
            long idBillNew = BillProvider.Instance.GetBillId_ByTableId(idTableNew);

            long tableOldCount = 0;
            long tableNewCount = 0;

            List<Table> listTable = GetTableList();

            foreach (Table item in listTable)
            {
                if (item.Id == idTableOld)
                {
                    tableOldCount++;

                    break;
                }
            }

            foreach (Table item in listTable)
            {
                if (item.Id == idTableNew)
                {
                    tableNewCount++;

                    break;
                }
            }

            if (tableOldCount > 0 && tableNewCount > 0)
            {
                string query1 = "UPDATE Bill SET IdTable = " + idTableNew.ToString() + " WHERE IdTable =  " + idTableOld.ToString() + " AND id = " + idBillOld.ToString() + " AND Status = 0";

                DataProvider.Instance.ExecuteNonQuery(query1);

                string query2 = "UPDATE Bill SET IdTable = " + idTableOld.ToString() + " WHERE IdTable =  " + idTableNew.ToString() + " AND id = " + idBillNew.ToString() + " AND Status = 0";

                DataProvider.Instance.ExecuteNonQuery(query2);

                return true;
            }
            else
                return false;
        }

        public void LoadListTable(ComboBox cbTable, List<Table> listTable)
        {
            if(listTable.Count > 0)
            {
                cbTable.DataSource = listTable;
                cbTable.DisplayMember = "Name";
            }
            else
            {
                cbTable.Text = "None";
            }
        }
        #endregion
    }
}
