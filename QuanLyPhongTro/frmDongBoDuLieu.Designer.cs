namespace MyWork
{
    partial class frmDongBoDuLieu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDongBoDuLieu));
            this.dgvSMS = new System.Windows.Forms.DataGridView();
            this.btnExportExcel = new DevExpress.XtraEditors.SimpleButton();
            this.btnTimKiem = new DevExpress.XtraEditors.SimpleButton();
            this.txtTuKhoa = new System.Windows.Forms.TextBox();
            this.btnLamMoi = new DevExpress.XtraEditors.SimpleButton();
            this.lblThongTinHienThi = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbSoBanGhi = new System.Windows.Forms.ComboBox();
            this.txtTrangHienTai = new System.Windows.Forms.TextBox();
            this.btnSau = new DevExpress.XtraEditors.SimpleButton();
            this.btnCuoi = new DevExpress.XtraEditors.SimpleButton();
            this.btnTruoc = new DevExpress.XtraEditors.SimpleButton();
            this.btnDauTien = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.cbNguoiViet = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbLoai = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpBatDau = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpKetThuc = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDongBoDuLieu = new DevExpress.XtraEditors.SimpleButton();
            this.btnDongBoCSDL = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoaDuLieuDu = new DevExpress.XtraEditors.SimpleButton();
            this.btnImportExcel = new DevExpress.XtraEditors.SimpleButton();
            this.btnImportHowSToday = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSMS)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSMS
            // 
            this.dgvSMS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSMS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSMS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSMS.Location = new System.Drawing.Point(0, 96);
            this.dgvSMS.Name = "dgvSMS";
            this.dgvSMS.Size = new System.Drawing.Size(1260, 532);
            this.dgvSMS.TabIndex = 2;
            this.dgvSMS.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvSMS_CellFormatting);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExportExcel.ImageOptions.Image")));
            this.btnExportExcel.Location = new System.Drawing.Point(113, 12);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(83, 25);
            this.btnExportExcel.TabIndex = 85;
            this.btnExportExcel.Text = "Xuất excel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click_1);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTimKiem.ImageOptions.Image")));
            this.btnTimKiem.Location = new System.Drawing.Point(1084, 42);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(70, 25);
            this.btnTimKiem.TabIndex = 94;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtTuKhoa
            // 
            this.txtTuKhoa.Location = new System.Drawing.Point(865, 47);
            this.txtTuKhoa.Name = "txtTuKhoa";
            this.txtTuKhoa.Size = new System.Drawing.Size(213, 20);
            this.txtTuKhoa.TabIndex = 104;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLamMoi.ImageOptions.Image")));
            this.btnLamMoi.Location = new System.Drawing.Point(436, 12);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(70, 25);
            this.btnLamMoi.TabIndex = 105;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // lblThongTinHienThi
            // 
            this.lblThongTinHienThi.AutoSize = true;
            this.lblThongTinHienThi.Location = new System.Drawing.Point(1, 80);
            this.lblThongTinHienThi.Name = "lblThongTinHienThi";
            this.lblThongTinHienThi.Size = new System.Drawing.Size(173, 13);
            this.lblThongTinHienThi.TabIndex = 127;
            this.lblThongTinHienThi.Text = "Hiển thị 1 tới 50 của ( 100 bản ghi )";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(98, 642);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 135;
            this.label6.Text = "Bản ghi";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(0, 642);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 134;
            this.label7.Text = "Hiển thị";
            // 
            // cbSoBanGhi
            // 
            this.cbSoBanGhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbSoBanGhi.FormattingEnabled = true;
            this.cbSoBanGhi.Location = new System.Drawing.Point(46, 633);
            this.cbSoBanGhi.Name = "cbSoBanGhi";
            this.cbSoBanGhi.Size = new System.Drawing.Size(46, 21);
            this.cbSoBanGhi.TabIndex = 133;
            this.cbSoBanGhi.SelectedIndexChanged += new System.EventHandler(this.cbSoBanGhi_SelectedIndexChanged);
            // 
            // txtTrangHienTai
            // 
            this.txtTrangHienTai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTrangHienTai.Location = new System.Drawing.Point(1146, 633);
            this.txtTrangHienTai.Name = "txtTrangHienTai";
            this.txtTrangHienTai.Size = new System.Drawing.Size(35, 20);
            this.txtTrangHienTai.TabIndex = 132;
            this.txtTrangHienTai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTrangHienTai_KeyDown);
            // 
            // btnSau
            // 
            this.btnSau.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSau.Location = new System.Drawing.Point(1187, 633);
            this.btnSau.Name = "btnSau";
            this.btnSau.Size = new System.Drawing.Size(32, 20);
            this.btnSau.TabIndex = 131;
            this.btnSau.Text = "Sau";
            this.btnSau.Click += new System.EventHandler(this.btnSau_Click);
            // 
            // btnCuoi
            // 
            this.btnCuoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCuoi.Location = new System.Drawing.Point(1225, 633);
            this.btnCuoi.Name = "btnCuoi";
            this.btnCuoi.Size = new System.Drawing.Size(32, 20);
            this.btnCuoi.TabIndex = 130;
            this.btnCuoi.Text = "Cuối";
            this.btnCuoi.Click += new System.EventHandler(this.btnCuoi_Click);
            // 
            // btnTruoc
            // 
            this.btnTruoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTruoc.Location = new System.Drawing.Point(1098, 634);
            this.btnTruoc.Name = "btnTruoc";
            this.btnTruoc.Size = new System.Drawing.Size(42, 20);
            this.btnTruoc.TabIndex = 129;
            this.btnTruoc.Text = "Trước";
            this.btnTruoc.Click += new System.EventHandler(this.btnTruoc_Click);
            // 
            // btnDauTien
            // 
            this.btnDauTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDauTien.Location = new System.Drawing.Point(1060, 634);
            this.btnDauTien.Name = "btnDauTien";
            this.btnDauTien.Size = new System.Drawing.Size(32, 20);
            this.btnDauTien.TabIndex = 128;
            this.btnDauTien.Text = "Đầu";
            this.btnDauTien.Click += new System.EventHandler(this.btnDauTien_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 137;
            this.label2.Text = "Người tạo:";
            // 
            // cbNguoiViet
            // 
            this.cbNguoiViet.FormattingEnabled = true;
            this.cbNguoiViet.Location = new System.Drawing.Point(69, 46);
            this.cbNguoiViet.Name = "cbNguoiViet";
            this.cbNguoiViet.Size = new System.Drawing.Size(209, 21);
            this.cbNguoiViet.TabIndex = 136;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(284, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 139;
            this.label1.Text = "Loại:";
            // 
            // cbLoai
            // 
            this.cbLoai.FormattingEnabled = true;
            this.cbLoai.Location = new System.Drawing.Point(320, 47);
            this.cbLoai.Name = "cbLoai";
            this.cbLoai.Size = new System.Drawing.Size(137, 21);
            this.cbLoai.TabIndex = 138;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(465, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 95;
            this.label4.Text = "Bắt đầu:";
            // 
            // dtpBatDau
            // 
            this.dtpBatDau.CustomFormat = "dd/MM/yyyy";
            this.dtpBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBatDau.Location = new System.Drawing.Point(516, 47);
            this.dtpBatDau.Name = "dtpBatDau";
            this.dtpBatDau.Size = new System.Drawing.Size(112, 20);
            this.dtpBatDau.TabIndex = 91;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(642, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 93;
            this.label5.Text = "Kết thúc:";
            // 
            // dtpKetThuc
            // 
            this.dtpKetThuc.CustomFormat = "dd/MM/yyyy";
            this.dtpKetThuc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpKetThuc.Location = new System.Drawing.Point(696, 46);
            this.dtpKetThuc.Name = "dtpKetThuc";
            this.dtpKetThuc.Size = new System.Drawing.Size(107, 20);
            this.dtpKetThuc.TabIndex = 92;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(809, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 103;
            this.label3.Text = "Từ khóa:";
            // 
            // btnDongBoDuLieu
            // 
            this.btnDongBoDuLieu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDongBoDuLieu.ImageOptions.Image")));
            this.btnDongBoDuLieu.Location = new System.Drawing.Point(202, 12);
            this.btnDongBoDuLieu.Name = "btnDongBoDuLieu";
            this.btnDongBoDuLieu.Size = new System.Drawing.Size(104, 25);
            this.btnDongBoDuLieu.TabIndex = 140;
            this.btnDongBoDuLieu.Text = "Đồng bộ dữ liệu";
            this.btnDongBoDuLieu.Click += new System.EventHandler(this.btnDongBoDuLieu_Click);
            // 
            // btnDongBoCSDL
            // 
            this.btnDongBoCSDL.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDongBoCSDL.ImageOptions.Image")));
            this.btnDongBoCSDL.Location = new System.Drawing.Point(312, 12);
            this.btnDongBoCSDL.Name = "btnDongBoCSDL";
            this.btnDongBoCSDL.Size = new System.Drawing.Size(118, 25);
            this.btnDongBoCSDL.TabIndex = 142;
            this.btnDongBoCSDL.Text = "Đồng bộ database";
            this.btnDongBoCSDL.Click += new System.EventHandler(this.btnDongBoCSDL_Click);
            // 
            // btnXoaDuLieuDu
            // 
            this.btnXoaDuLieuDu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaDuLieuDu.ImageOptions.Image")));
            this.btnXoaDuLieuDu.Location = new System.Drawing.Point(4, 12);
            this.btnXoaDuLieuDu.Name = "btnXoaDuLieuDu";
            this.btnXoaDuLieuDu.Size = new System.Drawing.Size(103, 25);
            this.btnXoaDuLieuDu.TabIndex = 143;
            this.btnXoaDuLieuDu.Text = "Xóa dữ liệu dư";
            this.btnXoaDuLieuDu.Click += new System.EventHandler(this.btnXoaDuLieuDu_Click);
            // 
            // btnImportExcel
            // 
            this.btnImportExcel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnImportExcel.ImageOptions.Image")));
            this.btnImportExcel.Location = new System.Drawing.Point(512, 12);
            this.btnImportExcel.Name = "btnImportExcel";
            this.btnImportExcel.Size = new System.Drawing.Size(107, 25);
            this.btnImportExcel.TabIndex = 144;
            this.btnImportExcel.Text = "Nhập excel Hazii";
            // 
            // btnImportHowSToday
            // 
            this.btnImportHowSToday.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnImportHowSToday.ImageOptions.Image")));
            this.btnImportHowSToday.Location = new System.Drawing.Point(625, 12);
            this.btnImportHowSToday.Name = "btnImportHowSToday";
            this.btnImportHowSToday.Size = new System.Drawing.Size(150, 25);
            this.btnImportHowSToday.TabIndex = 145;
            this.btnImportHowSToday.Text = "Nhập excel How \'S Today";
            // 
            // frmDongBoDuLieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1260, 658);
            this.Controls.Add(this.btnImportHowSToday);
            this.Controls.Add(this.btnImportExcel);
            this.Controls.Add(this.btnXoaDuLieuDu);
            this.Controls.Add(this.btnDongBoCSDL);
            this.Controls.Add(this.btnDongBoDuLieu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbLoai);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbNguoiViet);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbSoBanGhi);
            this.Controls.Add(this.txtTrangHienTai);
            this.Controls.Add(this.btnSau);
            this.Controls.Add(this.btnCuoi);
            this.Controls.Add(this.btnTruoc);
            this.Controls.Add(this.btnDauTien);
            this.Controls.Add(this.lblThongTinHienThi);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.txtTuKhoa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpKetThuc);
            this.Controls.Add(this.dtpBatDau);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.dgvSMS);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDongBoDuLieu";
            this.Text = "Đồng bộ dữ liệu";
            this.Load += new System.EventHandler(this.frmDongBoDuLieu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSMS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvSMS;
        private DevExpress.XtraEditors.SimpleButton btnExportExcel;
        private DevExpress.XtraEditors.SimpleButton btnTimKiem;
        private System.Windows.Forms.TextBox txtTuKhoa;
        private DevExpress.XtraEditors.SimpleButton btnLamMoi;
        private System.Windows.Forms.Label lblThongTinHienThi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbSoBanGhi;
        private System.Windows.Forms.TextBox txtTrangHienTai;
        private DevExpress.XtraEditors.SimpleButton btnSau;
        private DevExpress.XtraEditors.SimpleButton btnCuoi;
        private DevExpress.XtraEditors.SimpleButton btnTruoc;
        private DevExpress.XtraEditors.SimpleButton btnDauTien;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbNguoiViet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbLoai;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpBatDau;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpKetThuc;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton btnDongBoDuLieu;
        private DevExpress.XtraEditors.SimpleButton btnDongBoCSDL;
        private DevExpress.XtraEditors.SimpleButton btnXoaDuLieuDu;
        private DevExpress.XtraEditors.SimpleButton btnImportExcel;
        private DevExpress.XtraEditors.SimpleButton btnImportHowSToday;
    }
}