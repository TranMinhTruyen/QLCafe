namespace Cafe
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnQLTable = new System.Windows.Forms.Button();
            this.btnQLCategory = new System.Windows.Forms.Button();
            this.btnQLDrink = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.txtInfo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnBillAdd = new System.Windows.Forms.Button();
            this.cbDrink = new System.Windows.Forms.ComboBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.lvBill = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnChangeTable = new System.Windows.Forms.Button();
            this.flowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.cbTable = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnQLTable);
            this.panel1.Controls.Add(this.btnQLCategory);
            this.panel1.Controls.Add(this.btnQLDrink);
            this.panel1.Controls.Add(this.btnThongKe);
            this.panel1.Controls.Add(this.txtInfo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1142, 98);
            this.panel1.TabIndex = 2;
            // 
            // btnQLTable
            // 
            this.btnQLTable.Font = new System.Drawing.Font("Tahoma", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLTable.Location = new System.Drawing.Point(652, 5);
            this.btnQLTable.Margin = new System.Windows.Forms.Padding(4);
            this.btnQLTable.Name = "btnQLTable";
            this.btnQLTable.Size = new System.Drawing.Size(156, 80);
            this.btnQLTable.TabIndex = 0;
            this.btnQLTable.Text = "Quản lý bàn";
            this.btnQLTable.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQLTable.UseVisualStyleBackColor = true;
            this.btnQLTable.Click += new System.EventHandler(this.btnQLTable_Click);
            // 
            // btnQLCategory
            // 
            this.btnQLCategory.Font = new System.Drawing.Font("Tahoma", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLCategory.Location = new System.Drawing.Point(488, 5);
            this.btnQLCategory.Margin = new System.Windows.Forms.Padding(4);
            this.btnQLCategory.Name = "btnQLCategory";
            this.btnQLCategory.Size = new System.Drawing.Size(156, 80);
            this.btnQLCategory.TabIndex = 0;
            this.btnQLCategory.Text = "Quản lý loại thức uống";
            this.btnQLCategory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQLCategory.UseVisualStyleBackColor = true;
            this.btnQLCategory.Click += new System.EventHandler(this.btnQLCategory_Click);
            // 
            // btnQLDrink
            // 
            this.btnQLDrink.Font = new System.Drawing.Font("Tahoma", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLDrink.Location = new System.Drawing.Point(324, 5);
            this.btnQLDrink.Margin = new System.Windows.Forms.Padding(4);
            this.btnQLDrink.Name = "btnQLDrink";
            this.btnQLDrink.Size = new System.Drawing.Size(156, 80);
            this.btnQLDrink.TabIndex = 0;
            this.btnQLDrink.Text = "Quản lý thức uống";
            this.btnQLDrink.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQLDrink.UseVisualStyleBackColor = true;
            this.btnQLDrink.Click += new System.EventHandler(this.btnQLDrink_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.Font = new System.Drawing.Font("Tahoma", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKe.Location = new System.Drawing.Point(160, 5);
            this.btnThongKe.Margin = new System.Windows.Forms.Padding(4);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(156, 80);
            this.btnThongKe.TabIndex = 0;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // txtInfo
            // 
            this.txtInfo.BackColor = System.Drawing.SystemColors.Info;
            this.txtInfo.Font = new System.Drawing.Font("Tahoma", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInfo.Location = new System.Drawing.Point(7, 7);
            this.txtInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(145, 77);
            this.txtInfo.TabIndex = 5;
            this.txtInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(9, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 62);
            this.label1.TabIndex = 5;
            this.label1.Text = "Bàn số:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTongTien
            // 
            this.txtTongTien.Font = new System.Drawing.Font("Tahoma", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongTien.Location = new System.Drawing.Point(141, 360);
            this.txtTongTien.Margin = new System.Windows.Forms.Padding(4);
            this.txtTongTien.Multiline = true;
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(315, 34);
            this.txtTongTien.TabIndex = 4;
            this.txtTongTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 363);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 27);
            this.label4.TabIndex = 5;
            this.label4.Text = "Tổng cộng:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Font = new System.Drawing.Font("Tahoma", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThanhToan.Location = new System.Drawing.Point(939, 542);
            this.btnThanhToan.Margin = new System.Windows.Forms.Padding(4);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(190, 42);
            this.btnThanhToan.TabIndex = 0;
            this.btnThanhToan.Text = "Thanh Toán";
            this.btnThanhToan.UseVisualStyleBackColor = true;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnBillAdd);
            this.panel2.Controls.Add(this.cbDrink);
            this.panel2.Controls.Add(this.cbCategory);
            this.panel2.Controls.Add(this.lvBill);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtTongTien);
            this.panel2.Location = new System.Drawing.Point(656, 129);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(473, 404);
            this.panel2.TabIndex = 6;
            // 
            // btnBillAdd
            // 
            this.btnBillAdd.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBillAdd.Location = new System.Drawing.Point(326, 7);
            this.btnBillAdd.Name = "btnBillAdd";
            this.btnBillAdd.Size = new System.Drawing.Size(130, 53);
            this.btnBillAdd.TabIndex = 8;
            this.btnBillAdd.Text = "Thêm món";
            this.btnBillAdd.UseVisualStyleBackColor = true;
            this.btnBillAdd.Click += new System.EventHandler(this.btnBillAdd_Click);
            // 
            // cbDrink
            // 
            this.cbDrink.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDrink.FormattingEnabled = true;
            this.cbDrink.Location = new System.Drawing.Point(9, 36);
            this.cbDrink.Name = "cbDrink";
            this.cbDrink.Size = new System.Drawing.Size(311, 24);
            this.cbDrink.TabIndex = 7;
            // 
            // cbCategory
            // 
            this.cbCategory.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(9, 7);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(311, 24);
            this.cbCategory.TabIndex = 7;
            this.cbCategory.SelectedIndexChanged += new System.EventHandler(this.cbCategory_SelectedIndexChanged);
            // 
            // lvBill
            // 
            this.lvBill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvBill.Location = new System.Drawing.Point(9, 66);
            this.lvBill.Name = "lvBill";
            this.lvBill.Size = new System.Drawing.Size(447, 284);
            this.lvBill.TabIndex = 6;
            this.lvBill.UseCompatibleStateImageBehavior = false;
            this.lvBill.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.DisplayIndex = 3;
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.DisplayIndex = 0;
            this.columnHeader2.Text = "Mặt hàng";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.DisplayIndex = 1;
            this.columnHeader3.Text = "Số lượng";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 69;
            // 
            // columnHeader4
            // 
            this.columnHeader4.DisplayIndex = 2;
            this.columnHeader4.Text = "Đơn giá";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 107;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Tổng tiền";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 114;
            // 
            // btnChangeTable
            // 
            this.btnChangeTable.Font = new System.Drawing.Font("Tahoma", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeTable.Location = new System.Drawing.Point(463, 542);
            this.btnChangeTable.Margin = new System.Windows.Forms.Padding(4);
            this.btnChangeTable.Name = "btnChangeTable";
            this.btnChangeTable.Size = new System.Drawing.Size(190, 42);
            this.btnChangeTable.TabIndex = 0;
            this.btnChangeTable.Text = "Chuyển bàn";
            this.btnChangeTable.UseVisualStyleBackColor = true;
            this.btnChangeTable.Click += new System.EventHandler(this.btnChangeTable_Click);
            // 
            // flowPanel
            // 
            this.flowPanel.AutoScroll = true;
            this.flowPanel.Location = new System.Drawing.Point(12, 122);
            this.flowPanel.Name = "flowPanel";
            this.flowPanel.Size = new System.Drawing.Size(637, 411);
            this.flowPanel.TabIndex = 7;
            // 
            // cbTable
            // 
            this.cbTable.Font = new System.Drawing.Font("Tahoma", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTable.FormattingEnabled = true;
            this.cbTable.Location = new System.Drawing.Point(269, 546);
            this.cbTable.Name = "cbTable";
            this.cbTable.Size = new System.Drawing.Size(187, 35);
            this.cbTable.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 550);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(247, 27);
            this.label2.TabIndex = 5;
            this.label2.Text = "Bàn muốn chuyển sang:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 593);
            this.Controls.Add(this.cbTable);
            this.Controls.Add(this.flowPanel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnChangeTable);
            this.Controls.Add(this.btnThanhToan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý cà phê";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView lvBill;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label txtInfo;
        private System.Windows.Forms.Button btnBillAdd;
        private System.Windows.Forms.ComboBox cbDrink;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Button btnChangeTable;
        private System.Windows.Forms.FlowLayoutPanel flowPanel;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ComboBox cbTable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnQLDrink;
        private System.Windows.Forms.Button btnQLCategory;
        private System.Windows.Forms.Button btnQLTable;
    }
}

