using MyWork.Data;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace MyWork
{
    public partial class frmChiTietNo : Form
    {
        public int ID { get; set; }
        public System.DateTime ThoiGian { get; set; }
        public string NoiDung { get; set; }
        public string Detail { get; set; }
        public double SoNo { get; set; }
        public bool Complete { get; set; }

        public frmChiTietNo()
        {
            if (Connection.loginSuceess == true)
            {
                InitializeComponent();
            }
            else
            {
                string message = "Bạn cần cấu hình mật khẩu chính xác!";
                string title = "Bạn không thể thực hiện chức năng này";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, title, buttons);
            }
        }

        private void frmChiTietNo_Load(object sender, EventArgs e)
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
            if (Connection.loginSuceess == true)
            {
                lblID.Text = ID.ToString();
                txtNoiDung.Text = NoiDung;
                txtSoTien.Text = SoNo.ToString("N0");
                cbTrangThai.Checked = Complete;

                richEditControl1.Document.DefaultCharacterProperties.FontName = "Times New Roman";
                richEditControl1.Document.DefaultCharacterProperties.FontSize = 12;
                // Đặt chế độ xem đơn giản
                richEditControl1.ActiveViewType = RichEditViewType.Simple;
                // Kiểm tra và lấy section đầu tiên của tài liệu
                if (richEditControl1.Document.Sections.Count > 0)
                {
                    Section firstSection = richEditControl1.Document.Sections[0];

                    // Điều chỉnh lề của trang
                    firstSection.Margins.Left = 150;   // Đặt lề trái
                    firstSection.Margins.Right = 150;  // Đặt lề phải
                    firstSection.Margins.Top = 150;    // Đặt lề trên
                    firstSection.Margins.Bottom = 150; // Đặt lề dưới
                }
            }
            else
            {
                string message = "Bạn cần cấu hình mật khẩu chính xác!";
                string title = "Bạn không thể thực hiện chức năng này";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, title, buttons);
            }
        }

        public frmChiTietNo(int ID, bool isCopy)
        {
            //if (Connection.loginSuceess == true)
            //{
            //    InitializeComponent();
            //    if (ID != 0)
            //    {
            //        MyWorkEntities ctx = new MyWorkEntities();
            //        this.Text = "Cập nhật nợ";
            //        var data = ctx.QuanLyNoes.Where(c => c.ID == ID).FirstOrDefault();
            //        if (isCopy == true)
            //        {
            //            this.ID = 0;
            //            this.Text = "Thêm mới nợ";
            //        }
            //        else
            //        {
            //            this.ID = data.ID;
            //            this.Text = "Cập nhật nợ";
            //        }
            //        this.ThoiGian = data.ThoiGian;
            //        this.NoiDung = data.NoiDung;
            //        this.SoNo = data.SoNo;
            //        this.Detail = data.Detail;
            //        this.Complete = data.Complete;
            //        dtpThoiGian.Value = data.ThoiGian;
            //        string rtfText = SecurityMethod.Decrypt(Detail);
            //        byte[] byteArray = Encoding.ASCII.GetBytes(rtfText);
            //        richEditControl1.RtfText = Encoding.ASCII.GetString(byteArray);
            //    }
            //    else
            //    {
            //        this.ID = 0;
            //        this.ThoiGian = DateTime.Now;
            //        this.NoiDung = "";
            //        this.SoNo = 0;
            //        this.Complete = true;
            //        this.Text = "Thêm mới nợ";
            //    }
            //}
            //else
            //{
            //    string message = "Bạn cần cấu hình mật khẩu chính xác!";
            //    string title = "Bạn không thể thực hiện chức năng này";
            //    MessageBoxButtons buttons = MessageBoxButtons.OK;
            //    MessageBox.Show(message, title, buttons);
            //}
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            //if (Connection.loginSuceess == true)
            //{
            //    TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
            //    var _date = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
            //    DateTime dfromDate = new DateTime(_date.Year, _date.Month, 1);
            //    DateTime dtoDate = new DateTime(_date.Year, _date.Month, _date.Day);
            //    if (!string.IsNullOrEmpty(dtpThoiGian.Text))
            //    {
            //        dfromDate = DateTime.ParseExact(dtpThoiGian.Text + " 00:00:00", "dd/MM/yyyy HH:mm:ss", null);
            //    }
            //    MyWorkEntities ctx = new MyWorkEntities();
            //    QuanLyNo data = null;
            //    if (ID != 0)
            //    {
            //        data = ctx.QuanLyNoes.Where(c => c.ID == ID).FirstOrDefault();
            //        data.ThoiGian = dfromDate;
            //        string richText = richEditControl1.RtfText;
            //        MemoryStream stream = new MemoryStream(ASCIIEncoding.Default.GetBytes(richText));
            //        string rtfText; //string to save to db
            //        using (MemoryStream ms = new MemoryStream())
            //        {
            //            rtfText = Encoding.ASCII.GetString(stream.ToArray());
            //        }
            //        data.Detail = SecurityMethod.Encrypt(rtfText);
            //        data.NoiDung = txtNoiDung.Text.Trim();
            //        data.SoNo = double.Parse(txtSoTien.Text.Replace(",", "").Trim());
            //        data.Complete = cbTrangThai.Checked ? true : false;
            //        data.UpdateDate = DateTime.Now;
            //        data.SynStatus = false;
            //    }
            //    else
            //    {
            //        data = new QuanLyNo();
            //        int maxvalue = ctx.QuanLyNoes.OrderByDescending(c => c.ID).FirstOrDefault().ID;
            //        data.ID = maxvalue + 1;
            //        data.ThoiGian = dfromDate;
            //        string richText = richEditControl1.RtfText;
            //        MemoryStream stream = new MemoryStream(ASCIIEncoding.Default.GetBytes(richText));
            //        string rtfText; //string to save to db
            //        using (MemoryStream ms = new MemoryStream())
            //        {
            //            rtfText = Encoding.ASCII.GetString(stream.ToArray());
            //        }
            //        data.Detail = SecurityMethod.Encrypt(rtfText);
            //        data.NoiDung = txtNoiDung.Text.Trim();
            //        data.SoNo = double.Parse(txtSoTien.Text.Replace(",", "").Trim());
            //        data.Complete = cbTrangThai.Checked ? true : false;
            //        data.CreateDate = DateTime.Now;
            //        data.UpdateDate = DateTime.Now;
            //        data.SynDate = DateTime.Now;
            //        data.SynStatus = false;
            //        ctx.QuanLyNoes.Add(data);
            //    }

            //    // Thêm bản ghi vào bảng đồng bộ dữ liệu
            //    // Tìm giá trị ID mới
            //    int newID = ctx.LogSystems.Any() ? ctx.LogSystems.Max(x => x.ID) + 1 : 1;
            //    // Tạo đối tượng LogSystem mới với ID mới
            //    LogSystem newLog = new LogSystem();
            //    newLog.ID = newID;
            //    newLog.TenBang = "QuanLyNoes";
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
            //    MessageBox.Show("Cập nhật dữ liệu thành công!");
            //    this.Close();
            //}
            //else
            //{
            //    string message = "Bạn cần cấu hình mật khẩu chính xác!";
            //    string title = "Bạn không thể thực hiện chức năng này";
            //    MessageBoxButtons buttons = MessageBoxButtons.OK;
            //    MessageBox.Show(message, title, buttons);
            //}
        }
    }
}
