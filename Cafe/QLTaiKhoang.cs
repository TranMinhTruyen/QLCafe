using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Database2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            HienThi();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
        //Hiển thị database
        public void HienThi()
        {
            string query = "SELECT * FROM Account";
            DataTable dt = Cafe.DataProvider.Instance.ExecuteQuery(query);
            dataGridView1.DataSource = dt;

        }
        //Thêm 
        private void button1_Click(object sender, EventArgs e)
        {
            string acc = txtACC.Text;
            string pass = txtPASS.Text;
            string type = txtTYPE.Text;
            bool check = Cafe.AccoutProvider.Instance.CheckAccoutExit(acc,pass);
            if (check == false)
            {
                string query = "INSERT INTO Account (Username,Password,Type) VALUES (" + "'" + acc + "'" + "," + "'" + pass + "'" + "," + "'" + type + "'" + ")";
                Cafe.DataProvider.Instance.ExecuteNonQuery(query);
                HienThi();
            }
            else
            {
                MessageBox.Show("Tài khoản đã tồn tại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        //Xóa
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                string acc = dataGridView1.SelectedCells[0].Value.ToString();
                string query = "DELETE FROM Account WHERE Username = " + "'" + acc + "'" + "";
                Cafe.DataProvider.Instance.ExecuteNonQuery(query);
                HienThi();
            }
        }
        //Sửa
        private void button3_Click(object sender, EventArgs e)
        {
            string key = dataGridView1.SelectedCells[0].Value.ToString();
            string acc = txtACC.Text;
            string pass = txtPASS.Text;
            string type = txtTYPE.Text;
            string query = "UPDATE Account SET Username = " + "'" + acc + "'" + ",Password= " + "'" + pass + "'" + ",Type= " + "'" + type + "'" + " WHERE Username = " + "'" + key + "'" + "";
            Cafe.DataProvider.Instance.ExecuteNonQuery(query);
            HienThi();
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtACC.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtPASS.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtTYPE.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void txtPASS_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
