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

        public Table GetTable_By_Id(long idTable) // Unit Test
        {
            try
            {
                string query = "SELECT * FROM TableDrink WHERE Id =" + idTable.ToString();

                DataTable dataTable = DataProvider.Instance.ExecuteQuery(query);

                Table table = new Table(dataTable.Rows[0]);

                return table;
            }
            catch
            {
                return null;
            }
        }

        public long GetMaxTableID()
        {
            string query = "SELECT max(id) FROM TableDrink";

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

        public bool InsertTable(string name) // Unit Test
        {
            long id = GetMaxTableID() + 1;

            string query = "INSERT INTO TableDrink(Id,Name) VALUES(" + id.ToString() + "," + "'" + name + "'" + ")";

            long result = DataProvider.Instance.ExecuteNonQuery(query);

            if (result > 0)
                return true;
            else
                return false;
        }

        public bool UpdateTable(long idTable, string name) // Unit Test
        {
            string query = "UPDATE TableDrink SET Name = " + "'" + name + "' WHERE Id = " + idTable.ToString();

            long result = DataProvider.Instance.ExecuteNonQuery(query);

            if (result > 0)
                return true;
            else
                return false;
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

        public bool DeleteTable(long idTable) // Unit Test
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
                BillProvider.Instance.DeleteBill_By_IdTable(idTable);

                string query = "DELETE FROM TableDrink WHERE Id = " + idTable.ToString();

                DataProvider.Instance.ExecuteNonQuery(query);

                return true;
            }
            else
                return false;
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

        public bool SwitchTable(long idTableOld, long idTableNew) // Unit Test
        {
            long idBillOld = BillProvider.Instance.GetBillId_By_TableId(idTableOld);
            long idBillNew = BillProvider.Instance.GetBillId_By_TableId(idTableNew);

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

        public DataTable LoadTable_To_Datagridview()
        {
            string query = "SELECT Id, Name as [Tên] FROM TableDrink";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            return data;
        }

        public void Binding_Table(TextBox txtName, DataGridView dgvTable)
        {
            txtName.DataBindings.Add(new Binding("Text", dgvTable.DataSource, "Tên", true, DataSourceUpdateMode.Never));
        }
        #endregion
    }
}
