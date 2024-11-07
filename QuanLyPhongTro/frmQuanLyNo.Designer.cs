namespace MyWork
{
    partial class frmQuanLyNo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuanLyNo));
            this.dgvQuanLyNo = new System.Windows.Forms.DataGridView();
            this.btnExportExcel = new DevExpress.XtraEditors.SimpleButton();
            this.btnLamMoi = new DevExpress.XtraEditors.SimpleButton();
            this.btnXemChiTiet = new DevExpress.XtraEditors.SimpleButton();
            this.btnSua = new DevExpress.XtraEditors.SimpleButton();
            this.btnThemMoi = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTuKhoa = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaoChep = new DevExpress.XtraEditors.SimpleButton();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblChuaHoanThanh = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblHoanThanh = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuanLyNo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvQuanLyNo
            // 
            this.dgvQuanLyNo.AllowUserToAddRows = false;
            this.dgvQuanLyNo.AllowUserToDeleteRows = false;
            this.dgvQuanLyNo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvQuanLyNo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQuanLyNo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuanLyNo.Location = new System.Drawing.Point(-1, 111);
            this.dgvQuanLyNo.Name = "dgvQuanLyNo";
            this.dgvQuanLyNo.ReadOnly = true;
            this.dgvQuanLyNo.Size = new System.Drawing.Size(1202, 522);
            this.dgvQuanLyNo.TabIndex = 1;
            this.dgvQuanLyNo.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvQuanLyNo_CellFormatting);
            this.dgvQuanLyNo.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvQuanLyNo_CellMouseClick);
            this.dgvQuanLyNo.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvQuanLyNo_CellMouseDoubleClick);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExportExcel.ImageOptions.Image")));
            this.btnExportExcel.Location = new System.Drawing.Point(335, 12);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(83, 25);
            this.btnExportExcel.TabIndex = 97;
            this.btnExportExcel.Text = "Xuất excel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLamMoi.ImageOptions.Image")));
            this.btnLamMoi.Location = new System.Drawing.Point(424, 12);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(70, 25);
            this.btnLamMoi.TabIndex = 96;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnXemChiTiet
            // 
            this.btnXemChiTiet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXemChiTiet.ImageOptions.Image")));
            this.btnXemChiTiet.Location = new System.Drawing.Point(247, 12);
            this.btnXemChiTiet.Name = "btnXemChiTiet";
            this.btnXemChiTiet.Size = new System.Drawing.Size(82, 25);
            this.btnXemChiTiet.TabIndex = 95;
            this.btnXemChiTiet.Text = "Xem chi tiết";
            this.btnXemChiTiet.Click += new System.EventHandler(this.btnXemChiTiet_Click);
            // 
            // btnSua
            // 
            this.btnSua.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.ImageOptions.Image")));
            this.btnSua.Location = new System.Drawing.Point(180, 12);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(61, 25);
            this.btnSua.TabIndex = 94;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThemMoi.ImageOptions.Image")));
            this.btnThemMoi.Location = new System.Drawing.Point(10, 12);
            this.btnThemMoi.Name = "btnThemMoi";
            this.btnThemMoi.Size = new System.Drawing.Size(78, 25);
            this.btnThemMoi.TabIndex = 93;
            this.btnThemMoi.Text = "Thêm mới";
            this.btnThemMoi.Click += new System.EventHandler(this.btnThemMoi_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 110;
            this.label3.Text = "Từ khóa:";
            // 
            // txtTuKhoa
            // 
            this.txtTuKhoa.Location = new System.Drawing.Point(64, 59);
            this.txtTuKhoa.Name = "txtTuKhoa";
            this.txtTuKhoa.Size = new System.Drawing.Size(233, 20);
            this.txtTuKhoa.TabIndex = 109;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTimKiem.ImageOptions.Image")));
            this.btnTimKiem.Location = new System.Drawing.Point(303, 54);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(70, 25);
            this.btnTimKiem.TabIndex = 108;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnSaoChep
            // 
            this.btnSaoChep.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSaoChep.ImageOptions.Image")));
            this.btnSaoChep.Location = new System.Drawing.Point(94, 12);
            this.btnSaoChep.Name = "btnSaoChep";
            this.btnSaoChep.Size = new System.Drawing.Size(82, 25);
            this.btnSaoChep.TabIndex = 111;
            this.btnSaoChep.Text = "Sao chép";
            this.btnSaoChep.Click += new System.EventHandler(this.btnSaoChep_Click);
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.ForeColor = System.Drawing.Color.Red;
            this.lblTongTien.Location = new System.Drawing.Point(39, 95);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(53, 13);
            this.lblTongTien.TabIndex = 139;
            this.lblTongTien.Text = "TongTien";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 138;
            this.label2.Text = "Tổng:";
            // 
            // lblChuaHoanThanh
            // 
            this.lblChuaHoanThanh.AutoSize = true;
            this.lblChuaHoanThanh.ForeColor = System.Drawing.Color.Red;
            this.lblChuaHoanThanh.Location = new System.Drawing.Point(421, 95);
            this.lblChuaHoanThanh.Name = "lblChuaHoanThanh";
            this.lblChuaHoanThanh.Size = new System.Drawing.Size(110, 13);
            this.lblChuaHoanThanh.TabIndex = 137;
            this.lblChuaHoanThanh.Text = "TienChuaHoanThanh";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(332, 95);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 13);
            this.label9.TabIndex = 136;
            this.label9.Text = "Chưa hoàn thành:";
            // 
            // lblHoanThanh
            // 
            this.lblHoanThanh.AutoSize = true;
            this.lblHoanThanh.ForeColor = System.Drawing.Color.Red;
            this.lblHoanThanh.Location = new System.Drawing.Point(210, 95);
            this.lblHoanThanh.Name = "lblHoanThanh";
            this.lblHoanThanh.Size = new System.Drawing.Size(85, 13);
            this.lblHoanThanh.TabIndex = 135;
            this.lblHoanThanh.Text = "TienHoanThanh";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(148, 95);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 13);
            this.label10.TabIndex = 134;
            this.label10.Text = "Hoàn thành:";
            // 
            // frmQuanLyNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 633);
            this.Controls.Add(this.lblTongTien);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblChuaHoanThanh);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblHoanThanh);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnSaoChep);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTuKhoa);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnXemChiTiet);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThemMoi);
            this.Controls.Add(this.dgvQuanLyNo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmQuanLyNo";
            this.Text = "Quản lý nợ";
            this.Load += new System.EventHandler(this.frmQuanLyNo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuanLyNo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvQuanLyNo;
        private DevExpress.XtraEditors.SimpleButton btnExportExcel;
        private DevExpress.XtraEditors.SimpleButton btnLamMoi;
        private DevExpress.XtraEditors.SimpleButton btnXemChiTiet;
        private DevExpress.XtraEditors.SimpleButton btnSua;
        private DevExpress.XtraEditors.SimpleButton btnThemMoi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTuKhoa;
        private DevExpress.XtraEditors.SimpleButton btnTimKiem;
        private DevExpress.XtraEditors.SimpleButton btnSaoChep;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblChuaHoanThanh;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblHoanThanh;
        private System.Windows.Forms.Label label10;
    }
}