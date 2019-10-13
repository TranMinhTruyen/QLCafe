using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cafe
{
    public partial class Form1 : Form
    {
        private static List<Button> buttonList = new List<Button>();
        private static List<Table> listTable = new List<Table>();

        private string _message;

        public Form1()
        {
            InitializeComponent();

            LoadTable();

            CategoryProvider.Instance.LoadCategory(cbCategory);
        }

        #region Info Account
        public Form1(string message): this()
        {
            _message = message;
            txtInfo.Text = _message;

            if(_message == "Admin")
            {
                btnQLThucUong.Enabled = true;
            }
            else if(_message == "Staff")
            {
                btnQLThucUong.Enabled = false;
            }
        }
        #endregion

        #region Table
        private void LoadTable()
        {
            listTable = TableProvider.Instance.GetTableList();

            foreach (Table item in listTable)
            {
                long idTable = BillProvider.Instance.GetBillId_ByTableId(item.Id);

                if (idTable == -1)
                {
                    TableProvider.Instance.UpdateTableStatus_0(item.Id);
                }
            }

            listTable = TableProvider.Instance.GetTableList();

            TableProvider.Instance.CreateTableList(flowPanel, buttonList, listTable);

            foreach (Button item in buttonList)
            {
                item.Click += item_Click;
            }
        }
        #endregion

        #region Menu
        void item_Click(object sender, EventArgs e)
        {
            long idTable = ((sender as Button).Tag as Table).Id;

            lvBill.Tag = (sender as Button).Tag;

            TableProvider.Instance.TableChange(buttonList, sender);

            MenuProvider.Instance.ShowMenu(idTable, lvBill, txtTongTien);
        }
        #endregion

        #region Category
        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrinkProvider.Instance.LoadDrink_ByCategoryId(cbDrink, cbCategory, sender);
        }
        #endregion

        #region Drink
        #endregion

        #region Bill
        private void btnBillAdd_Click(object sender, EventArgs e)
        {
            Table table = lvBill.Tag as Table;

            if (table == null)
            {
                MessageBox.Show("Bạn chưa chọn bàn!!!","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                BillProvider.Instance.CreateNewBill_Or_UpdateBill(table, cbDrink);

                TableProvider.Instance.UpdateTableStatus_1(table.Id);

                LoadTable();

                MenuProvider.Instance.ShowMenu(table.Id, lvBill, txtTongTien);
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            Table table = lvBill.Tag as Table;

            long idBill = BillProvider.Instance.GetBillId_ByTableId(table.Id);

            if (idBill != -1)
            {
                BillProvider.Instance.UpdateStatusBill(idBill);

                TableProvider.Instance.UpdateTableStatus_0(table.Id);

                LoadTable();

                MenuProvider.Instance.ShowMenu(table.Id, lvBill, txtTongTien);
            }
            else
            {
                MessageBox.Show("Không có hóa đơn để thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region Exit
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        #endregion
    }
}
