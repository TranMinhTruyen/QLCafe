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
    public partial class QLThucUongForm : Form
    {
        private BindingSource drinkList = new BindingSource();

        private long idDrink;

        public QLThucUongForm()
        {
            InitializeComponent();

            drinkList.DataSource = DrinkProvider.Instance.LoadNamePriceDrink_By_Category();

            dgvDrink.DataSource = drinkList;
        }

        private void QLThucUongForm_Load(object sender, EventArgs e)
        {
            DrinkProvider.Instance.Binding_NamePriceDrink(txtName, nudPrice, dgvDrink);

            CategoryProvider.Instance.LoadCategory(cbCategory);
        }

        private void dgvDrink_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                string nameCategory = dgvDrink.Rows[e.RowIndex].Cells[3].Value.ToString();

                if (nameCategory != "")
                {
                    CategoryProvider.Instance.LoadCategory_By_Datagridview(nameCategory, cbCategory);

                    idDrink = (long)dgvDrink.Rows[e.RowIndex].Cells[0].Value;
                }
                else
                    return;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name;

            if(txtName.Text == "")
                name = "Món chưa đặt tên";
            else
                name = txtName.Text;

            long price = (long)nudPrice.Value;
            long idCategory = (long)(cbCategory.SelectedItem as Category).Id;

            if(DrinkProvider.Instance.InsertDrink(name, price, idCategory) == true)
            {
                MessageBox.Show("Đã thêm món thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                drinkList.DataSource = DrinkProvider.Instance.LoadNamePriceDrink_By_Category();

                if (createDrink != null)
                    createDrink(this, new EventArgs());
            }
            else
                MessageBox.Show("Thêm món không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            string name;

            if (txtName.Text == "")
                name = "Món chưa đặt tên";
            else
                name = txtName.Text;

            long price = (long)nudPrice.Value;
            long idCategory = (long)(cbCategory.SelectedItem as Category).Id;

            if(DrinkProvider.Instance.UpdateDrink(idDrink, name, price, idCategory) == true)
            {
                MessageBox.Show("Đã sửa món thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                drinkList.DataSource = DrinkProvider.Instance.LoadNamePriceDrink_By_Category();

                if (updateDrink != null)
                    updateDrink(this, new EventArgs());
            }
            else
                MessageBox.Show("Sửa món không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DrinkProvider.Instance.DeleteDrink(idDrink) == true)
            {
                MessageBox.Show("Xóa món thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                drinkList.DataSource = DrinkProvider.Instance.LoadNamePriceDrink_By_Category();

                if (deleteDrink != null)
                    deleteDrink(this, new EventArgs());
            }
            else
                MessageBox.Show("Xóa món không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #region Event Create
        // Create Event
        private event EventHandler createDrink;
        public event EventHandler CreateDrink
        {
            add { createDrink += value; }
            remove { createDrink -= value; }
        }

        // Update Event
        private event EventHandler updateDrink;
        public event EventHandler UpdateDrink
        {
            add { updateDrink += value; }
            remove { updateDrink -= value; }
        }

        // Delete Event
        private event EventHandler deleteDrink;
        public event EventHandler DeleteDrink
        {
            add { deleteDrink += value;}
            remove { deleteDrink -= value; }
        }
        #endregion
    }
}
