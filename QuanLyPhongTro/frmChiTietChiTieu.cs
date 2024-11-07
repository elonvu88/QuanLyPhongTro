using MyWork.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyWork
{
    public partial class frmChiTietChiTieu : Form
    {
        public int ID { get; set; }
        public System.DateTime ThoiGian { get; set; }
        public string NoiDung { get; set; }
        public double SoTien { get; set; }
        public string GhiChu { get; set; }
        public int IdDanhMuc { get; set; }
        public bool Complete { get; set; }
        public System.DateTime CreateDate { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public System.DateTime SynDate { get; set; }
        public bool SynStatus { get; set; }

        public frmChiTietChiTieu()
        {
            InitializeComponent();
            //MyWorkEntities ctx = new MyWorkEntities();
            //var lstChiTieu = ctx.DanhMucChiTieux.OrderBy(c => c.ID).ToList();
            //cbHangMuc.DataSource = lstChiTieu;
            //cbHangMuc.ValueMember = "ID";
            //cbHangMuc.DisplayMember = "TenDanhMuc";
            //cbHangMuc.SelectedIndex = 1;

            //this.Complete = true;
            //this.Text = "Thêm mới chi tiêu";

        }

        private void frmChiTietChiTieu_Load(object sender, EventArgs e)
        {
            // Lấy kích thước của màn hình hiện tại
            Rectangle screenSize = Screen.PrimaryScreen.WorkingArea;
            // Tính toán kích thước mới cho Form (90% của kích thước màn hình)
            int newWidth = (int)(screenSize.Width * 0.9);
            int newHeight = (int)(screenSize.Height * 0.9);
            // Đặt kích thước cho Form
            this.Size = new Size(newWidth, newHeight);
            // Tính toán vị trí để Form ở giữa màn hình
            int newX = (screenSize.Width - newWidth) / 2;
            int newY = (screenSize.Height - newHeight) / 2;
            this.Location = new Point(newX, newY);
            lblID.Text = ID.ToString();
            txtNoiDung.Text = NoiDung;
            txtSoTien.Text = SoTien.ToString("N0");
            cbTrangThai.Checked = Complete;
            rtbGhiChu.Text = GhiChu;
        }

        public frmChiTietChiTieu(int ID, bool isCopy)
        {
            InitializeComponent();
            //MyWorkEntities ctx = new MyWorkEntities();
            //var lstChiTieu = ctx.DanhMucChiTieux.OrderBy(c => c.ID).ToList();
            //cbHangMuc.DataSource = lstChiTieu;
            //cbHangMuc.ValueMember = "ID";
            //cbHangMuc.DisplayMember = "TenDanhMuc";
            //cbHangMuc.SelectedIndex = 0;
            //if (ID != 0)
            //{
            //    if (isCopy == true)
            //    {
            //        this.Text = "Thêm mới chi tiêu";
            //    }
            //    else
            //    {
            //        this.Text = "Cập nhật chi tiêu";
            //    }
            //    var data = ctx.QuanLyChiTieux.Where(c => c.ID == ID).FirstOrDefault();
            //    if (isCopy == true)
            //    {
            //        this.ID = 0;
            //        this.ThoiGian = DateTime.Now;
            //    }
            //    else
            //    {
            //        this.ID = data.ID;
            //        this.ThoiGian = data.ThoiGian;
            //    }
            //    this.IdDanhMuc = data.IdDanhMuc;
            //    this.Complete = data.Complete;
            //    this.NoiDung = data.NoiDung;
            //    this.SoTien = data.SoTien;
            //    this.GhiChu = data.GhiChu;
            //    cbHangMuc.SelectedValue = data.IdDanhMuc;
            //    dtpThoiGian.Value = ThoiGian;
            //}
            //else
            //{
            //    this.ID = 0;
            //    this.ThoiGian = DateTime.Now;
            //    this.NoiDung = "";
            //    this.SoTien = 0;
            //    this.GhiChu = "";
            //    this.IdDanhMuc = 2;
            //    this.Complete = true;
            //    cbHangMuc.SelectedValue = IdDanhMuc;
            //    this.Text = "Thêm mới chi tiêu";
            //}
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            //if (!Connection.loginSuceess)
            //{
            //    MessageBox.Show("Bạn cần cấu hình mật khẩu chính xác!", "Bạn không thể thực hiện chức năng này", MessageBoxButtons.OK);
            //    return;
            //}

            //DateTime dfromDate = string.IsNullOrEmpty(dtpThoiGian.Text)
            //    ? DateTime.Today.AddDays(1 - DateTime.Today.Day)
            //    : DateTime.ParseExact(dtpThoiGian.Text + " 00:00:00", "dd/MM/yyyy HH:mm:ss", null);

            //using (var ctx = new MyWorkEntities())
            //{
            //    var data = ctx.QuanLyChiTieux.Find(ID) ?? new QuanLyChiTieu();

            //    data.ThoiGian = dfromDate;
            //    data.ThoiGianMoi = dfromDate.ToString("dd/MM/yyyy");
            //    data.NoiDung = txtNoiDung.Text.Trim();
            //    data.GhiChu = rtbGhiChu.Text.Trim();
            //    data.SoTien = double.Parse(txtSoTien.Text.Replace(",", "").Replace(".", "").Trim());
            //    data.Complete = cbTrangThai.Checked;
            //    int hangMucChiTieu = 0;
            //    if (cbHangMuc.SelectedItem != null)
            //    {
            //        hangMucChiTieu = (cbHangMuc.SelectedItem as DanhMucChiTieu).ID;
            //    }
            //    data.IdDanhMuc = hangMucChiTieu;
            //    if (ID != 0)
            //    {
            //        data.UpdateDate = DateTime.Now;

            //        if (data.IdDanhMuc > 6)
            //        {
            //            var dataNuoiCon = ctx.NuoiCons.Where(c => c.IDChiTieu == data.ID).FirstOrDefault();
            //            if (dataNuoiCon != null)
            //            {
            //                dataNuoiCon.ThoiGian = string.IsNullOrEmpty(dtpThoiGian.Text)
            //       ? DateTime.Today.AddDays(1 - DateTime.Today.Day)
            //       : DateTime.ParseExact(dtpThoiGian.Text + " 00:00:00", "dd/MM/yyyy HH:mm:ss", null);
            //                dataNuoiCon.IdDanhMuc = hangMucChiTieu;
            //                dataNuoiCon.NoiDung = txtNoiDung.Text.Trim();
            //                dataNuoiCon.GhiChu = rtbGhiChu.Text.Trim();
            //                dataNuoiCon.SoTien = double.Parse(txtSoTien.Text.Replace(",", "").Replace(".", "").Trim());
            //                dataNuoiCon.Complete = cbTrangThai.Checked;
            //                dataNuoiCon.IDChiTieu = data.ID;
            //                dataNuoiCon.UpdateDate = DateTime.Now;
            //                data.SynStatus = false;
            //                ctx.SaveChanges();
            //            }
            //        }
            //    }
            //    else
            //    {
            //        data.CreateDate = DateTime.Now;
            //        data.UpdateDate = DateTime.Now;
            //        data.SynDate = DateTime.Now;
            //        data.ID = ctx.QuanLyChiTieux.Any() ? ctx.QuanLyChiTieux.Max(c => c.ID) + 1 : 1;

            //        if (data.IdDanhMuc > 6)
            //        {
            //            NuoiCon dataNuoiCon = new NuoiCon();

            //            dataNuoiCon.ThoiGian = string.IsNullOrEmpty(dtpThoiGian.Text)
            //                ? DateTime.Today.AddDays(1 - DateTime.Today.Day)
            //                : DateTime.ParseExact(dtpThoiGian.Text + " 00:00:00", "dd/MM/yyyy HH:mm:ss", null);

            //            dataNuoiCon.GhiChu = rtbGhiChu.Text.Trim();
            //            dataNuoiCon.NoiDung = txtNoiDung.Text.Trim();
            //            dataNuoiCon.SoTien = double.Parse(txtSoTien.Text.Replace(",", "").Replace(".", "").Trim());
            //            dataNuoiCon.Complete = cbTrangThai.Checked;
            //            dataNuoiCon.IdDanhMuc = hangMucChiTieu;
            //            dataNuoiCon.IDChiTieu = data.ID;
            //            dataNuoiCon.CreateDate = DateTime.Now;
            //            dataNuoiCon.UpdateDate = DateTime.Now;
            //            dataNuoiCon.SynDate = DateTime.Now;
            //            dataNuoiCon.SynStatus = false;
            //            dataNuoiCon.ID = ctx.NuoiCons.Any() ? ctx.NuoiCons.Max(c => c.ID) + 1 : 1;
            //            ctx.NuoiCons.Add(dataNuoiCon);
            //            ctx.SaveChanges();
            //        }
            //    }
            //    data.SynStatus = false;
            //    ctx.QuanLyChiTieux.AddOrUpdate(data);

            //    // Thêm bản ghi vào bảng đồng bộ dữ liệu
            //    // Tìm giá trị ID mới
            //    int newID = ctx.LogSystems.Any() ? ctx.LogSystems.Max(x => x.ID) + 1 : 1;
            //    // Tạo đối tượng LogSystem mới với ID mới
            //    LogSystem newLog = new LogSystem();
            //    newLog.ID = newID;
            //    newLog.TenBang = "QuanLyChiTieux";
            //    newLog.IDBanGhi = data.ID;
            //    newLog.LoaiThayDoi = (ID != 0 ? "U" : "I");
            //    newLog.CreateDate = DateTime.Now;
            //    newLog.UpdateDate = DateTime.Now;
            //    newLog.CreateBy = Connection.idDangNhap;
            //    newLog.SynDate = DateTime.Now;
            //    newLog.SynStatus = false;
            //    newLog.JsonObject = JsonConvert.SerializeObject(data);
            //    ctx.LogSystems.Add(newLog);

            //    ctx.SaveChanges();
            //}
            //MessageBox.Show("Cập nhật dữ liệu thành công!");
            //this.Close();
        }
    }
}
