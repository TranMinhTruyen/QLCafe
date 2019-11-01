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
    public partial class QLCategoryForm : Form
    {
        private BindingSource categoryList = new BindingSource();

        private long idCategory;

        public QLCategoryForm()
        {
            InitializeComponent();

            categoryList.DataSource = CategoryProvider.Instance.LoadCategory_To_Datagridview();

            dgvCategory.DataSource = categoryList;
        }

        private void QLCategoryForm_Load(object sender, EventArgs e)
        {
            CategoryProvider.Instance.Binding_Category(txtName, dgvCategory);
        }

        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                string nameCategory = dgvCategory.Rows[e.RowIndex].Cells[1].Value.ToString();

                if (nameCategory != "")
                {
                    idCategory = (long)dgvCategory.Rows[e.RowIndex].Cells[0].Value;
                }
                else
                    return;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name;

            if (txtName.Text == "")
                name = "Loại thức uống chưa đặt tên";
            else
                name = txtName.Text;

            if (CategoryProvider.Instance.InsertCategory(name) == true)
            {
                MessageBox.Show("Đã thêm loại thức uống thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                categoryList.DataSource = CategoryProvider.Instance.LoadCategory_To_Datagridview();

                if (createCategory != null)
                    createCategory(this, new EventArgs());
            }
            else
                MessageBox.Show("Thêm loại thức uống không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            string name;

            if (txtName.Text == "")
                name = "Loại thức uống chưa đặt tên";
            else
                name = txtName.Text;

            if (CategoryProvider.Instance.UpdateCategory(idCategory, name) == true)
            {
                MessageBox.Show("Đã sửa loại thức uống thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                categoryList.DataSource = CategoryProvider.Instance.LoadCategory_To_Datagridview();

                if (updateCategory != null)
                    updateCategory(this, new EventArgs());
            }
            else
                MessageBox.Show("Sửa loại thức uống không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (CategoryProvider.Instance.DeleteCategory(idCategory) == true)
            {
                MessageBox.Show("Xóa loại thức uống thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                categoryList.DataSource = CategoryProvider.Instance.LoadCategory_To_Datagridview();

                if (deleteCategory != null)
                    deleteCategory(this, new EventArgs());
            }
            else
                MessageBox.Show("Xóa loại thức uống không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #region Event Create
        // Create Event
        private event EventHandler createCategory;
        public event EventHandler CreateCategory
        {
            add { createCategory += value; }
            remove { createCategory -= value; }
        }

        // Update Event
        private event EventHandler updateCategory;
        public event EventHandler UpdateCategory
        {
            add { updateCategory += value; }
            remove { updateCategory -= value; }
        }

        // Delete Event
        private event EventHandler deleteCategory;
        public event EventHandler DeleteCategory
        {
            add { deleteCategory += value; }
            remove { deleteCategory -= value; }
        }
        #endregion

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
