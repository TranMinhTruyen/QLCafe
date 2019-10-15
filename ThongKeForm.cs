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
    public partial class ThongKeForm : Form
    {
        public ThongKeForm()
        {
            InitializeComponent();

            BillProvider.Instance.LoadPaidBill(dgvThongKe, dtpThongKe);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            BillProvider.Instance.LoadPaidBill(dgvThongKe, dtpThongKe);
        }
    }
}
