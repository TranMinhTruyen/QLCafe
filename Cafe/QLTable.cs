using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe
{
    public partial class QLTable : Form
    {
        private BindingSource tableList = new BindingSource();

        private long idTable;

        public QLTable()
        {
            InitializeComponent();

            tableList.DataSource = TableProvider.Instance.LoadTable_To_Datagridview();

            dgvTable.DataSource = tableList;
        }

        private void QLTable_Load(object sender, EventArgs e)
        {
            TableProvider.Instance.Binding_Table(txtName, dgvTable);
        }

        private void dgvTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                string nameCategory = dgvTable.Rows[e.RowIndex].Cells[1].Value.ToString();

                if (nameCategory != "")
                {
                    idTable = (long)dgvTable.Rows[e.RowIndex].Cells[0].Value;
                }
                else
                    return;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name;

            if (txtName.Text == "")
                name = "Bàn chưa đặt tên";
            else
                name = lblban.Text + txtName.Text;

            if (TableProvider.Instance.InsertTable(name) == true)
            {
                MessageBox.Show("Đã thêm bàn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                tableList.DataSource = TableProvider.Instance.LoadTable_To_Datagridview();

                if (createTable != null)
                    createTable(this, new EventArgs());
            }
            else
                MessageBox.Show("Thêm bàn không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            string name;

            if (txtName.Text == "")
                name = "Bàn chưa đặt tên";
            else
                name = txtName.Text;

            if (TableProvider.Instance.UpdateTable(idTable, name) == true)
            {
                MessageBox.Show("Đã sửa bàn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                tableList.DataSource = TableProvider.Instance.LoadTable_To_Datagridview();

                if (updateTable != null)
                    updateTable(this, new EventArgs());
            }
            else
                MessageBox.Show("Sửa bàn không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #region Event Create
        // Create Event
        private event EventHandler createTable;
        public event EventHandler CreateTable
        {
            add { createTable += value; }
            remove { createTable -= value; }
        }

        // Update Event
        private event EventHandler updateTable;
        public event EventHandler UpdateTable
        {
            add { updateTable += value; }
            remove { updateTable -= value; }
        }

        // Delete Event
        private event EventHandler deleteTable;
        public event EventHandler DeleteTable
        {
            add { deleteTable += value; }
            remove { deleteTable -= value; }
        }
        #endregion

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (TableProvider.Instance.DeleteTable(idTable) == true)
            {
                MessageBox.Show("Xóa bàn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                tableList.DataSource = TableProvider.Instance.LoadTable_To_Datagridview();

                if (deleteTable != null)
                    deleteTable(this, new EventArgs());
            }
            else
                MessageBox.Show("Xóa bàn không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
