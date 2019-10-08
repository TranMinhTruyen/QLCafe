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
        private string _message;

        public Form1()
        {
            InitializeComponent();

            LoadCategory();
        }

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

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
                return;

            Category select = cb.SelectedItem as Category;

            long id = select.Id;

            LoadDrinkByCategoryId(id);
        }

        private void LoadCategory()
        {
            List<Category> listCategory = CategoryProvider.Instance.GetListCategory();

            cbCategory.DataSource = listCategory;
            cbCategory.DisplayMember = "Name";
        }

        private void LoadDrinkByCategoryId(long id)
        {
            List<Drink> listDrink = DrinkProvider.Instance.GetDrinkByCategoryId(id);

            cbDrink.DataSource = listDrink;
            cbDrink.DisplayMember = "Name";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
