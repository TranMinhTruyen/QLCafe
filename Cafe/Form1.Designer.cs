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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btmLogout = new System.Windows.Forms.Button();
            this.btnQLaccount = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.btnQLCategory = new System.Windows.Forms.Button();
            this.btnQLTable = new System.Windows.Forms.Button();
            this.btnQLDrink = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.txtInfo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnBillAdd = new System.Windows.Forms.Button();
            this.cbDrink = new System.Windows.Forms.ComboBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.lvBill = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnChangeTable = new System.Windows.Forms.Button();
            this.flowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.cbTable = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btmLogout);
            this.panel1.Controls.Add(this.btnQLaccount);
            this.panel1.Controls.Add(this.btClose);
            this.panel1.Controls.Add(this.btnQLCategory);
            this.panel1.Controls.Add(this.btnQLTable);
            this.panel1.Controls.Add(this.btnQLDrink);
            this.panel1.Controls.Add(this.btnThongKe);
            this.panel1.Controls.Add(this.txtInfo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1530, 80);
            this.panel1.TabIndex = 2;
            // 
            // btmLogout
            // 
            this.btmLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btmLogout.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btmLogout.FlatAppearance.BorderSize = 3;
            this.btmLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btmLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btmLogout.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btmLogout.Image = ((System.Drawing.Image)(resources.GetObject("btmLogout.Image")));
            this.btmLogout.Location = new System.Drawing.Point(1230, 6);
            this.btmLogout.Name = "btmLogout";
            this.btmLogout.Size = new System.Drawing.Size(190, 65);
            this.btmLogout.TabIndex = 9;
            this.btmLogout.Text = "Đăng xuất";
            this.btmLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btmLogout.UseVisualStyleBackColor = false;
            this.btmLogout.Click += new System.EventHandler(this.btmLogout_Click);
            // 
            // btnQLaccount
            // 
            this.btnQLaccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnQLaccount.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnQLaccount.FlatAppearance.BorderSize = 3;
            this.btnQLaccount.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnQLaccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLaccount.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLaccount.Image = ((System.Drawing.Image)(resources.GetObject("btnQLaccount.Image")));
            this.btnQLaccount.Location = new System.Drawing.Point(1034, 6);
            this.btnQLaccount.Name = "btnQLaccount";
            this.btnQLaccount.Size = new System.Drawing.Size(190, 65);
            this.btnQLaccount.TabIndex = 8;
            this.btnQLaccount.Text = "Quản lý tài khoảng";
            this.btnQLaccount.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQLaccount.UseVisualStyleBackColor = false;
            this.btnQLaccount.Click += new System.EventHandler(this.btnQLaccount_Click);
            // 
            // btClose
            // 
            this.btClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btClose.BackgroundImage")));
            this.btClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btClose.FlatAppearance.BorderSize = 0;
            this.btClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btClose.Location = new System.Drawing.Point(1458, 6);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(65, 65);
            this.btClose.TabIndex = 7;
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btnQLCategory
            // 
            this.btnQLCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnQLCategory.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnQLCategory.FlatAppearance.BorderSize = 3;
            this.btnQLCategory.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control;
            this.btnQLCategory.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnQLCategory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnQLCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLCategory.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLCategory.Image = ((System.Drawing.Image)(resources.GetObject("btnQLCategory.Image")));
            this.btnQLCategory.Location = new System.Drawing.Point(642, 6);
            this.btnQLCategory.Name = "btnQLCategory";
            this.btnQLCategory.Size = new System.Drawing.Size(190, 65);
            this.btnQLCategory.TabIndex = 6;
            this.btnQLCategory.Text = "Quản lý loại thức uống";
            this.btnQLCategory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQLCategory.UseVisualStyleBackColor = false;
            this.btnQLCategory.Click += new System.EventHandler(this.btnQLCategory_Click_1);
            // 
            // btnQLTable
            // 
            this.btnQLTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnQLTable.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnQLTable.FlatAppearance.BorderSize = 3;
            this.btnQLTable.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control;
            this.btnQLTable.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnQLTable.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnQLTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLTable.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLTable.Image = ((System.Drawing.Image)(resources.GetObject("btnQLTable.Image")));
            this.btnQLTable.Location = new System.Drawing.Point(838, 6);
            this.btnQLTable.Name = "btnQLTable";
            this.btnQLTable.Size = new System.Drawing.Size(190, 65);
            this.btnQLTable.TabIndex = 0;
            this.btnQLTable.Text = "Quản lý bàn";
            this.btnQLTable.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQLTable.UseVisualStyleBackColor = false;
            this.btnQLTable.Click += new System.EventHandler(this.btnQLTable_Click);
            // 
            // btnQLDrink
            // 
            this.btnQLDrink.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnQLDrink.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnQLDrink.FlatAppearance.BorderSize = 3;
            this.btnQLDrink.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control;
            this.btnQLDrink.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnQLDrink.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnQLDrink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLDrink.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLDrink.Image = ((System.Drawing.Image)(resources.GetObject("btnQLDrink.Image")));
            this.btnQLDrink.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQLDrink.Location = new System.Drawing.Point(446, 6);
            this.btnQLDrink.Name = "btnQLDrink";
            this.btnQLDrink.Size = new System.Drawing.Size(190, 65);
            this.btnQLDrink.TabIndex = 0;
            this.btnQLDrink.Text = "Quản lý thức uống";
            this.btnQLDrink.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQLDrink.UseVisualStyleBackColor = false;
            this.btnQLDrink.Click += new System.EventHandler(this.btnQLDrink_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnThongKe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnThongKe.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnThongKe.FlatAppearance.BorderSize = 3;
            this.btnThongKe.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control;
            this.btnThongKe.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnThongKe.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongKe.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKe.Image = ((System.Drawing.Image)(resources.GetObject("btnThongKe.Image")));
            this.btnThongKe.Location = new System.Drawing.Point(249, 6);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(190, 65);
            this.btnThongKe.TabIndex = 0;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThongKe.UseVisualStyleBackColor = false;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // txtInfo
            // 
            this.txtInfo.BackColor = System.Drawing.SystemColors.Info;
            this.txtInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtInfo.Font = new System.Drawing.Font("Tahoma", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInfo.Location = new System.Drawing.Point(0, 0);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(243, 76);
            this.txtInfo.TabIndex = 5;
            this.txtInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtInfo.Click += new System.EventHandler(this.txtInfo_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(7, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 50);
            this.label1.TabIndex = 5;
            this.label1.Text = "Bàn số:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTongTien
            // 
            this.txtTongTien.Font = new System.Drawing.Font("Tahoma", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongTien.Location = new System.Drawing.Point(259, 425);
            this.txtTongTien.Multiline = true;
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(225, 28);
            this.txtTongTien.TabIndex = 4;
            this.txtTongTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(152, 428);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 22);
            this.label4.TabIndex = 5;
            this.label4.Text = "Tổng cộng:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BackColor = System.Drawing.Color.White;
            this.btnThanhToan.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnThanhToan.FlatAppearance.BorderSize = 5;
            this.btnThanhToan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThanhToan.Font = new System.Drawing.Font("Tahoma", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThanhToan.Image = ((System.Drawing.Image)(resources.GetObject("btnThanhToan.Image")));
            this.btnThanhToan.Location = new System.Drawing.Point(259, 454);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(225, 43);
            this.btnThanhToan.TabIndex = 0;
            this.btnThanhToan.Text = "Thanh Toán";
            this.btnThanhToan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThanhToan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnXoa);
            this.panel2.Controls.Add(this.btnBillAdd);
            this.panel2.Controls.Add(this.cbDrink);
            this.panel2.Controls.Add(this.cbCategory);
            this.panel2.Controls.Add(this.lvBill);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtTongTien);
            this.panel2.Controls.Add(this.btnThanhToan);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1032, 80);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(498, 506);
            this.panel2.TabIndex = 6;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(434, 2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(57, 57);
            this.btnXoa.TabIndex = 9;
            this.btnXoa.Text = "button1";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnBillAdd
            // 
            this.btnBillAdd.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnBillAdd.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.btnBillAdd.FlatAppearance.BorderSize = 3;
            this.btnBillAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.btnBillAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBillAdd.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBillAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnBillAdd.Image")));
            this.btnBillAdd.Location = new System.Drawing.Point(372, 2);
            this.btnBillAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnBillAdd.Name = "btnBillAdd";
            this.btnBillAdd.Size = new System.Drawing.Size(57, 57);
            this.btnBillAdd.TabIndex = 8;
            this.btnBillAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBillAdd.UseVisualStyleBackColor = false;
            this.btnBillAdd.Click += new System.EventHandler(this.btnBillAdd_Click);
            // 
            // cbDrink
            // 
            this.cbDrink.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDrink.FormattingEnabled = true;
            this.cbDrink.Location = new System.Drawing.Point(2, 32);
            this.cbDrink.Margin = new System.Windows.Forms.Padding(2);
            this.cbDrink.Name = "cbDrink";
            this.cbDrink.Size = new System.Drawing.Size(366, 27);
            this.cbDrink.TabIndex = 7;
            // 
            // cbCategory
            // 
            this.cbCategory.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(2, 2);
            this.cbCategory.Margin = new System.Windows.Forms.Padding(2);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(366, 27);
            this.cbCategory.TabIndex = 7;
            this.cbCategory.SelectedIndexChanged += new System.EventHandler(this.cbCategory_SelectedIndexChanged);
            // 
            // lvBill
            // 
            this.lvBill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvBill.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvBill.FullRowSelect = true;
            this.lvBill.HideSelection = false;
            this.lvBill.Location = new System.Drawing.Point(2, 63);
            this.lvBill.Margin = new System.Windows.Forms.Padding(2);
            this.lvBill.Name = "lvBill";
            this.lvBill.Size = new System.Drawing.Size(494, 357);
            this.lvBill.TabIndex = 6;
            this.lvBill.UseCompatibleStateImageBehavior = false;
            this.lvBill.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mặt hàng";
            this.columnHeader1.Width = 169;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Số lượng";
            this.columnHeader2.Width = 79;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Đơn giá";
            this.columnHeader3.Width = 95;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Tổng tiền";
            this.columnHeader4.Width = 147;
            // 
            // btnChangeTable
            // 
            this.btnChangeTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnChangeTable.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnChangeTable.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnChangeTable.FlatAppearance.BorderSize = 3;
            this.btnChangeTable.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnChangeTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeTable.Font = new System.Drawing.Font("Tahoma", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeTable.Image = ((System.Drawing.Image)(resources.GetObject("btnChangeTable.Image")));
            this.btnChangeTable.Location = new System.Drawing.Point(354, 0);
            this.btnChangeTable.Name = "btnChangeTable";
            this.btnChangeTable.Size = new System.Drawing.Size(162, 57);
            this.btnChangeTable.TabIndex = 0;
            this.btnChangeTable.Text = "Chuyển bàn";
            this.btnChangeTable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnChangeTable.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnChangeTable.UseVisualStyleBackColor = false;
            this.btnChangeTable.Click += new System.EventHandler(this.btnChangeTable_Click);
            // 
            // flowPanel
            // 
            this.flowPanel.AutoScroll = true;
            this.flowPanel.BackColor = System.Drawing.SystemColors.Control;
            this.flowPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowPanel.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.flowPanel.Location = new System.Drawing.Point(0, 80);
            this.flowPanel.Margin = new System.Windows.Forms.Padding(2);
            this.flowPanel.Name = "flowPanel";
            this.flowPanel.Size = new System.Drawing.Size(1027, 438);
            this.flowPanel.TabIndex = 7;
            // 
            // cbTable
            // 
            this.cbTable.Font = new System.Drawing.Font("Tahoma", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTable.FormattingEnabled = true;
            this.cbTable.Location = new System.Drawing.Point(207, 14);
            this.cbTable.Margin = new System.Windows.Forms.Padding(2);
            this.cbTable.Name = "cbTable";
            this.cbTable.Size = new System.Drawing.Size(142, 30);
            this.cbTable.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Tahoma", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 57);
            this.label2.TabIndex = 5;
            this.label2.Text = "Bàn muốn chuyển sang:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.cbTable);
            this.panel3.Controls.Add(this.btnChangeTable);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(507, 523);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(520, 61);
            this.panel3.TabIndex = 9;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1530, 586);
            this.ControlBox = false;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.flowPanel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QUẢN LÝ CAFE";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing_1);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Label txtInfo;
        private System.Windows.Forms.Button btnBillAdd;
        private System.Windows.Forms.ComboBox cbDrink;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Button btnChangeTable;
        private System.Windows.Forms.FlowLayoutPanel flowPanel;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ComboBox cbTable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnQLDrink;
        private System.Windows.Forms.Button btnQLTable;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnQLCategory;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btnQLaccount;
        private System.Windows.Forms.Button btmLogout;
        private System.Windows.Forms.Button btnXoa;
    }
}

