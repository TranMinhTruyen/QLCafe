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
        public static List<Button> buttonList = new List<Button>();
        public static List<Table> listTable = new List<Table>();
        public static List<long> listIdBillInfo = new List<long>();

        private string _message;

        public Form1()
        {
            InitializeComponent();

            LoadTable();

            TableProvider.Instance.LoadListTable(cbTable, listTable);

            CategoryProvider.Instance.LoadCategory(cbCategory);

            lvBill.Columns[1].Width = 0;
        }

        #region Info Account
        public Form1(string message): this()
        {
            _message = message;
            txtInfo.Text = _message;

            Admin(_message);
        }
        #endregion

        #region Table
        private void LoadTable()
        {
            listTable = TableProvider.Instance.GetTableList();

            foreach (Table item in listTable)
            {
                long idTable = BillProvider.Instance.GetBillId_By_TableId(item.Id);

                if (idTable == -1)
                {
                    TableProvider.Instance.UpdateTableStatus_0(item.Id);
                }
                else
                {
                    TableProvider.Instance.UpdateTableStatus_1(item.Id);
                }

            }

            listTable = TableProvider.Instance.GetTableList();

            TableProvider.Instance.CreateTableList(flowPanel, buttonList, listTable);

            foreach (Button item in buttonList)
            {
                item.BackColor = Color.White;
                item.ForeColor = Color.Black;
                item.Click += item_Click;
            }
        }

        private void btnChangeTable_Click(object sender, EventArgs e)
        {
            long idTableOld = (lvBill.Tag as Table).Id;

            long idTableNew = (cbTable.SelectedItem as Table).Id;

            TableProvider.Instance.SwitchTable(idTableOld, idTableNew);

            LoadTable();
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
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvBill.SelectedItems)
            {
                string idBillInfo = item.SubItems[1].Text;

                foreach (long id in listIdBillInfo)
                {
                    if (idBillInfo == id.ToString())
                    {
                        BillInfoProvider.Instance.DeleteBillInfo_By_IdBillInfo(id);
                    }
                }
            }

            Table table = lvBill.Tag as Table;

            if (table != null)
            {
                long idBill = BillProvider.Instance.GetBillId_By_TableId(table.Id);

                if (idBill != -1)
                {
                    List<BillInfo> a = BillInfoProvider.Instance.GetListBillInfo_By_IdBill(idBill);

                    if (a.Count == 0)
                        BillProvider.Instance.DeleteBill(idBill);

                    TableProvider.Instance.UpdateTableStatus_0(table.Id);

                    LoadTable();

                    MenuProvider.Instance.ShowMenu(table.Id, lvBill, txtTongTien);
                }
            }
            else
                MessageBox.Show("Bạn chưa chọn bàn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (lvBill.Tag == null)
            {
                MessageBox.Show("Chưa chọn bàn để thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Table table = lvBill.Tag as Table;
                long idBill = BillProvider.Instance.GetBillId_By_TableId(table.Id);
                if (idBill != -1)
                {
                    long totalPrice = Convert.ToInt64(txtTongTien.Text);

                    BillProvider.Instance.UpdateStatusBill(idBill, totalPrice);

                    TableProvider.Instance.UpdateTableStatus_0(table.Id);

                    ReportProvider.Instance.InsertReport(table.Id, idBill);

                    LoadTable();

                    MenuProvider.Instance.ShowMenu(table.Id, lvBill, txtTongTien);
                }
                else
                {
                    MessageBox.Show("Không có hóa đơn để thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        #endregion

        #region Exit
        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {

        }
        #endregion

        private void Admin(string message)
        {
            if (message == "Admin")
            {
                btnThongKe.Enabled = true;
                btnQLDrink.Enabled = true;
                btnQLCategory.Enabled = true;
                btnQLTable.Enabled = true;
                btnQLaccount.Enabled = true;
            }
            else if (message == "Staff")
            {
                btnThongKe.Enabled = false;
                btnQLDrink.Enabled = true;
                btnQLCategory.Enabled = true;
                btnQLTable.Enabled = false;
                btnQLaccount.Enabled = false;
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            ThongKeForm thongkeForm = new ThongKeForm();
            thongkeForm.ShowDialog();
            this.Show();
        }

        #region QL Drink
        private void btnQLDrink_Click(object sender, EventArgs e)
        {
            QLThucUongForm qlDrinkForm = new QLThucUongForm();
            qlDrinkForm.DeleteDrink += qlDrinkForm_DeleteDrink;
            qlDrinkForm.UpdateDrink += qlDrinkForm_UpdateDrink;
            qlDrinkForm.CreateDrink += qlDrinkForm_CreateDrink;
            qlDrinkForm.ShowDialog();
            this.Show();
        }

        void qlDrinkForm_CreateDrink(object sender, EventArgs e)
        {
            LoadTable();

            TableProvider.Instance.LoadListTable(cbTable, listTable);

            CategoryProvider.Instance.LoadCategory(cbCategory);

            if (lvBill.Tag != null)
                MenuProvider.Instance.ShowMenu((lvBill.Tag as Table).Id, lvBill, txtTongTien);
        }

        void qlDrinkForm_UpdateDrink(object sender, EventArgs e)
        {
            LoadTable();

            TableProvider.Instance.LoadListTable(cbTable, listTable);

            CategoryProvider.Instance.LoadCategory(cbCategory);

            if (lvBill.Tag != null)
                MenuProvider.Instance.ShowMenu((lvBill.Tag as Table).Id, lvBill, txtTongTien);
        }

        void qlDrinkForm_DeleteDrink(object sender, EventArgs e)
        {
            LoadTable();

            TableProvider.Instance.LoadListTable(cbTable, listTable);

            CategoryProvider.Instance.LoadCategory(cbCategory);

            if (lvBill.Tag != null)
                MenuProvider.Instance.ShowMenu((lvBill.Tag as Table).Id, lvBill, txtTongTien);
        }
        #endregion

        #region QL Category
        private void btnQLCategory_Click_1(object sender, EventArgs e)
        {
            QLCategoryForm qlCategoryForm = new QLCategoryForm();
            qlCategoryForm.DeleteCategory += qlCategoryForm_DeleteCategory;
            qlCategoryForm.UpdateCategory += qlCategoryForm_UpdateCategory;
            qlCategoryForm.CreateCategory += qlCategoryForm_CreateCategory;
            qlCategoryForm.ShowDialog();
            this.Show();
        }

        void qlCategoryForm_CreateCategory(object sender, EventArgs e)
        {
            LoadTable();

            TableProvider.Instance.LoadListTable(cbTable, listTable);

            CategoryProvider.Instance.LoadCategory(cbCategory);

            if (lvBill.Tag != null)
                MenuProvider.Instance.ShowMenu((lvBill.Tag as Table).Id, lvBill, txtTongTien);
        }

        void qlCategoryForm_UpdateCategory(object sender, EventArgs e)
        {
            LoadTable();

            TableProvider.Instance.LoadListTable(cbTable, listTable);

            CategoryProvider.Instance.LoadCategory(cbCategory);

            if (lvBill.Tag != null)
                MenuProvider.Instance.ShowMenu((lvBill.Tag as Table).Id, lvBill, txtTongTien);
        }

        void qlCategoryForm_DeleteCategory(object sender, EventArgs e)
        {
            LoadTable();

            TableProvider.Instance.LoadListTable(cbTable, listTable);

            CategoryProvider.Instance.LoadCategory(cbCategory);

            if (lvBill.Tag != null)
                MenuProvider.Instance.ShowMenu((lvBill.Tag as Table).Id, lvBill, txtTongTien);
        }
        #endregion

        #region QL Table
        private void btnQLTable_Click(object sender, EventArgs e)
        {
            QLTable qlTable = new QLTable();
            qlTable.CreateTable += qlTable_CreateTable;
            qlTable.UpdateTable += qlTable_UpdateTable;
            qlTable.DeleteTable += qlTable_DeleteTable;
            qlTable.ShowDialog();
            this.Show();
        }

        void qlTable_DeleteTable(object sender, EventArgs e)
        {
            LoadTable();

            TableProvider.Instance.LoadListTable(cbTable, listTable);

            CategoryProvider.Instance.LoadCategory(cbCategory);

            if (lvBill.Tag != null)
                MenuProvider.Instance.ShowMenu((lvBill.Tag as Table).Id, lvBill, txtTongTien);
        }

        void qlTable_UpdateTable(object sender, EventArgs e)
        {
            LoadTable();

            TableProvider.Instance.LoadListTable(cbTable, listTable);

            CategoryProvider.Instance.LoadCategory(cbCategory);

            if (lvBill.Tag != null)
                MenuProvider.Instance.ShowMenu((lvBill.Tag as Table).Id, lvBill, txtTongTien);
        }

        void qlTable_CreateTable(object sender, EventArgs e)
        {
            LoadTable();

            TableProvider.Instance.LoadListTable(cbTable, listTable);

            CategoryProvider.Instance.LoadCategory(cbCategory);

            if (lvBill.Tag != null)
                MenuProvider.Instance.ShowMenu((lvBill.Tag as Table).Id, lvBill, txtTongTien);
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát chương trình", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                Application.ExitThread();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnQLaccount_Click(object sender, EventArgs e)
        {
            Database2.Form1 qltaikhoang = new Database2.Form1();
            qltaikhoang.ShowDialog();
            this.Show();
        }

        private void txtInfo_Click(object sender, EventArgs e)
        {

        }

        private void btmLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                LoginForm form = new LoginForm();
                form.Show();
                this.Hide();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtTongTien_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Table table = lvBill.Tag as Table;

            if (table == null)
            {
                MessageBox.Show("Bạn chưa chọn bàn!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                BillProvider.Instance.DeleteBill_By_IdTable(table.Id);

                TableProvider.Instance.UpdateTableStatus_1(table.Id);

                LoadTable();

                MenuProvider.Instance.ShowMenu(table.Id, lvBill, txtTongTien);
            }
        }
    }
}
