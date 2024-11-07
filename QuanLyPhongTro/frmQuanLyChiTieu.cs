using MyWork.Data;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;

namespace MyWork
{
    public partial class frmQuanLyChiTieu : Form
    {
        private double tongChi = 0;
        private double tongThu = 0;
        private double tongHoanThanh = 0;
        private double tongChuaHoanThanh = 0;
        private int idChiTieu = 0;
        private int hangMucChiTieu = 1;
        private string tuKhoa = "";
        private int soTien = 0;
        private int pageSize = 500; // Số bản ghi trên mỗi trang
        private int currentPage = 1; // Trang hiện tại
        private int totalPages = 0;
        private int _totalPages = 0;
        private int startIndex = 0; // Biến để theo dõi chỉ số của bản ghi đầu tiên hiện đang được hiển thị
        private int _startIndex = 0; // Biến để theo dõi chỉ số của bản ghi đầu tiên hiện đang được hiển thị

        public frmQuanLyChiTieu()
        {
            if (Connection.loginSuceess == true)
            {
                InitializeComponent();
                dtpBatDau.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-1);
                dtpKetThuc.Value = DateTime.Now.AddYears(3);
            }
            else
            {
                string message = "Bạn cần cấu hình mật khẩu chính xác!";
                string title = "Bạn không thể thực hiện chức năng này";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, title, buttons);
            }
        }

        private void frmQuanLyChiTieu_Load(object sender, EventArgs e)
        {
            //if (Connection.loginSuceess == true)
            //{
            //    SetupPageSizeComboBox();
            //    MyWorkEntities ctx = new MyWorkEntities();
            //    var lstChiTieu = ctx.DanhMucChiTieux.OrderBy(c => c.ID).ToList();
            //    cbHangMuc.DataSource = lstChiTieu;
            //    cbHangMuc.ValueMember = "ID";
            //    cbHangMuc.DisplayMember = "TenDanhMuc";
            //    cbHangMuc.SelectedIndex = 0;
            //    LoadData();
            //    LoadDataThongKeChiTieu();
            //    LoadChartData();
            //    LoadChartDataDM();

            //    // Đặt thuộc tính Anchor của cả bốn nút thành Bottom
            //    btnDau.Anchor = AnchorStyles.Bottom;
            //    btnTruocThongKe.Anchor = AnchorStyles.Bottom;
            //    btnSauThongKe.Anchor = AnchorStyles.Bottom;
            //    btnThongKeCuoi.Anchor = AnchorStyles.Bottom;

            //    // Tính toán chiều rộng và tổng chiều rộng của cả bốn nút
            //    int buttonWidth = btnDau.Width; // Giả sử cả bốn nút có cùng chiều rộng
            //    int totalButtonWidth = 4 * buttonWidth; // Tổng chiều rộng của cả bốn nút
            //    int formWidth = this.ClientSize.Width; // Chiều rộng của form
            //    int startX = (formWidth - totalButtonWidth) / 2; // Tính toán vị trí bắt đầu của nút "Đầu"

            //    // Đặt vị trí cho từng nút theo thứ tự từ trái sang phải
            //    btnDau.Location = new Point(startX, btnDau.Location.Y);
            //    btnTruocThongKe.Location = new Point(startX + buttonWidth, btnTruocThongKe.Location.Y);
            //    btnSauThongKe.Location = new Point(startX + 2 * buttonWidth, btnSauThongKe.Location.Y);
            //    btnThongKeCuoi.Location = new Point(startX + 3 * buttonWidth, btnThongKeCuoi.Location.Y);


            //    // Đặt thuộc tính Anchor của cả bốn nút thành Bottom
            //    btnDauDM.Anchor = AnchorStyles.Bottom;
            //    btnTruocDM.Anchor = AnchorStyles.Bottom;
            //    btnSauDM.Anchor = AnchorStyles.Bottom;
            //    btnCuoiDM.Anchor = AnchorStyles.Bottom;

            //    // Tính toán chiều rộng và tổng chiều rộng của cả bốn nút
            //    int _buttonWidth = btnDauDM.Width; // Giả sử cả bốn nút có cùng chiều rộng
            //    int _totalButtonWidth = 4 * buttonWidth; // Tổng chiều rộng của cả bốn nút
            //    int _formWidth = this.ClientSize.Width; // Chiều rộng của form
            //    int _startX = (_formWidth - _totalButtonWidth) / 2; // Tính toán vị trí bắt đầu của nút "Đầu"

            //    // Đặt vị trí cho từng nút theo thứ tự từ trái sang phải
            //    btnDauDM.Location = new Point(_startX, btnDauDM.Location.Y);
            //    btnTruocDM.Location = new Point(_startX + _buttonWidth, btnTruocDM.Location.Y);
            //    btnSauDM.Location = new Point(_startX + 2 * _buttonWidth, btnSauDM.Location.Y);
            //    btnCuoiDM.Location = new Point(_startX + 3 * _buttonWidth, btnCuoiDM.Location.Y);
            //}
            //else
            //{
            //    string message = "Bạn cần cấu hình mật khẩu chính xác!";
            //    string title = "Bạn không thể thực hiện chức năng này";
            //    MessageBoxButtons buttons = MessageBoxButtons.OK;
            //    MessageBox.Show(message, title, buttons);
            //}
        }

        public void LoadData()
        {
            //if (Connection.loginSuceess == true)
            //{
            //    tongChi = 0;
            //    tongChuaHoanThanh = 0;
            //    tongHoanThanh = 0;
            //    tuKhoa = txtTuKhoa.Text.Trim().ToLower();
            //    if (!string.IsNullOrEmpty(txtSoTien.Text.Trim()))
            //    {
            //        soTien = int.Parse(txtSoTien.Text.Trim());
            //    }
            //    if (cbHangMuc.SelectedItem != null)
            //    {
            //        hangMucChiTieu = (cbHangMuc.SelectedItem as DanhMucChiTieu).ID;
            //    }
            //    TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
            //    var _date = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
            //    DateTime dfthoigian = new DateTime(_date.Year, _date.Month, 1);
            //    DateTime dfend = new DateTime(_date.Year, _date.Month, 1);

            //    if (!string.IsNullOrEmpty(dtpBatDau.Text))
            //    {
            //        dfthoigian = DateTime.ParseExact(dtpBatDau.Text + " 00:00:00", "dd/MM/yyyy HH:mm:ss", null);
            //    }

            //    if (!string.IsNullOrEmpty(dtpKetThuc.Text))
            //    {
            //        dfend = DateTime.ParseExact(dtpKetThuc.Text + " 00:00:00", "dd/MM/yyyy HH:mm:ss", null);
            //    }
            //    MyWorkEntities ctx = new MyWorkEntities();
            //    var _hangMucChiTieu = ctx.DanhMucChiTieux.ToList();
            //    var data = ctx.QuanLyChiTieux.Where(c => c.ThoiGian >= dfthoigian && c.ThoiGian <= dfend).OrderByDescending(c => c.ThoiGian).AsQueryable();

            //    if (hangMucChiTieu != 1)
            //    {
            //        data = data.Where(c => c.IdDanhMuc == hangMucChiTieu);
            //    }
            //    if (soTien > 0)
            //    {
            //        data = data.Where(c => c.SoTien >= soTien);
            //    }
            //    if (!string.IsNullOrEmpty(tuKhoa))
            //    {
            //        data = data.Where(c => c.NoiDung.ToLower().Contains(tuKhoa) || c.GhiChu.ToLower().Contains(tuKhoa));
            //    }
            //    // Tính tổng trước khi phân trang
            //    // Kiểm tra xem có bản ghi nào trong tập hợp không
            //    if (data.Any())
            //    {
            //        // Tính tổng chi khi có ít nhất một bản ghi
            //        tongChi = data.Sum(item => item.SoTien);

            //        // Kiểm tra và tính tổng khi Complete == false
            //        var chuaHoanThanhItems = data.Where(item => item.Complete == false);
            //        tongChuaHoanThanh = chuaHoanThanhItems.Any() ? chuaHoanThanhItems.Sum(item => item.SoTien) : 0;

            //        // Kiểm tra và tính tổng khi Complete == true
            //        var hoanThanhItems = data.Where(item => item.Complete == true);
            //        tongHoanThanh = hoanThanhItems.Any() ? hoanThanhItems.Sum(item => item.SoTien) : 0;
            //    }
            //    else
            //    {
            //        // Nếu tập hợp rỗng, đặt tổng về 0 hoặc giá trị mặc định tùy ý
            //        tongChi = 0;
            //        tongChuaHoanThanh = 0;
            //        tongHoanThanh = 0;
            //    }

            //    // Tính tổng số bản ghi từ query
            //    int totalRecords = data.Count();
            //    // Tính tổng số trang
            //    totalPages = CalculateTotalPages(totalRecords);
            //    // Tính chỉ số bắt đầu và kết thúc của dãy bản ghi trên trang hiện tại
            //    int startIndex = (currentPage - 1) * pageSize + 1;
            //    int endIndex = startIndex + pageSize - 1;
            //    // Áp dụng phân trang
            //    data = data.Skip(startIndex - 1).Take(pageSize);

            //    System.Data.DataTable dt = new System.Data.DataTable();
            //    dt.Columns.Add("ID", typeof(int));
            //    dt.Columns.Add("ThoiGian", typeof(string));
            //    dt.Columns.Add("NoiDung", typeof(string));
            //    dt.Columns.Add("GhiChu", typeof(string));
            //    dt.Columns.Add("SoTien", typeof(string));
            //    dt.Columns.Add("HangMuc", typeof(string));
            //    dt.Columns.Add("CreateDate", typeof(string));
            //    dt.Columns.Add("UpdateDate", typeof(string));
            //    dt.Columns.Add("Complete", typeof(string));

            //    DataRow dr = null;

            //    foreach (var item in data)
            //    {
            //        dr = dt.NewRow();
            //        dr["ID"] = item.ID.ToString();

            //        if (Connection.loginSuceess == true)
            //        {
            //            dr["ThoiGian"] = item.ThoiGian.ToString("dd/MM/yyyy");
            //            dr["NoiDung"] = item.NoiDung;
            //            dr["GhiChu"] = item.GhiChu;
            //            dr["SoTien"] = item.SoTien.ToString("N0");
            //            dr["HangMuc"] = _hangMucChiTieu.Where(c => c.ID == item.IdDanhMuc).First().TenDanhMuc;
            //            dr["CreateDate"] = item.CreateDate.ToString("dd/MM/yyyy HH:mm:ss");
            //            dr["UpdateDate"] = item.UpdateDate.ToString("dd/MM/yyyy HH:mm:ss");
            //            dr["Complete"] = item.Complete == true ? "Hoàn thành" : "Chưa hoàn thành";
            //        }
            //        else
            //        {
            //            dr["ThoiGian"] = "*****************";
            //            dr["NoiDung"] = "*****************";
            //            dr["GhiChu"] = "*****************";
            //            dr["SoTien"] = "*****************";
            //            dr["HangMuc"] = "*****************";
            //            dr["CreateDate"] = "*****************";
            //            dr["UpdateDate"] = "*****************";
            //            dr["Complete"] = "*****************";
            //        }
            //        dt.Rows.Add(dr);
            //    }

            //    dt.Columns["ID"].ColumnName = "ID";
            //    dt.Columns["ThoiGian"].ColumnName = "Thời gian";
            //    dt.Columns["NoiDung"].ColumnName = "Nội dung";
            //    dt.Columns["GhiChu"].ColumnName = "Ghi chú";
            //    dt.Columns["SoTien"].ColumnName = "Số tiền";
            //    dt.Columns["HangMuc"].ColumnName = "Hạng mục";
            //    dt.Columns["CreateDate"].ColumnName = "Thời gian tạo";
            //    dt.Columns["UpdateDate"].ColumnName = "Thời gian cập nhật";
            //    dt.Columns["Complete"].ColumnName = "Trạng thái";

            //    dt.AcceptChanges();

            //    dgvQuanLyChiTieu.DataSource = dt;

            //    // Cài đặt độ rộng cố định cho các cột
            //    dgvQuanLyChiTieu.Columns["ID"].Width = 50;
            //    dgvQuanLyChiTieu.Columns["Thời gian"].Width = 80;
            //    dgvQuanLyChiTieu.Columns["Số tiền"].Width = 80;
            //    dgvQuanLyChiTieu.Columns["Số tiền"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //    dgvQuanLyChiTieu.Columns["Hạng mục"].Width = 100;
            //    dgvQuanLyChiTieu.Columns["Thời gian tạo"].Width = 120;
            //    dgvQuanLyChiTieu.Columns["Thời gian cập nhật"].Width = 120;
            //    dgvQuanLyChiTieu.Columns["Trạng thái"].Width = 100;

            //    // Cài đặt độ rộng tự động cho cột "Nội dung"
            //    dgvQuanLyChiTieu.Columns["Nội dung"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //    // Cài đặt độ rộng tự động cho cột "Ghi chú"
            //    dgvQuanLyChiTieu.Columns["Ghi chú"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //    dgvQuanLyChiTieu.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    dgvQuanLyChiTieu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            //    UpdatePaginationControls();
            //    // Thêm thông tin về bản ghi bắt đầu, bản ghi kết thúc và tổng số bản ghi
            //    lblThongTinHienThi.Text = string.Format("Hiển thị {0} tới {1} của ( {2} bản ghi )", startIndex.ToString("N0"), endIndex.ToString("N0"), totalRecords.ToString("N0"));

            //    lblTongTien.Text = tongChi.ToString("N0");
            //    lblChuaHoanThanh.Text = tongChuaHoanThanh.ToString("N0");
            //    lblHoanThanh.Text = tongHoanThanh.ToString("N0");
            //}
            //else
            //{
            //    string message = "Bạn cần cấu hình mật khẩu chính xác!";
            //    string title = "Bạn không thể thực hiện chức năng này";
            //    MessageBoxButtons buttons = MessageBoxButtons.OK;
            //    MessageBox.Show(message, title, buttons);
            //}
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            if (Connection.loginSuceess == true)
            {
                frmChiTietChiTieu frm = new frmChiTietChiTieu();
                frm.ShowDialog();
            }
            else
            {
                string message = "Bạn cần cấu hình mật khẩu chính xác!";
                string title = "Bạn không thể thực hiện chức năng này";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, title, buttons);
            }
        }

        private void btnSaoChep_Click(object sender, EventArgs e)
        {
            //if (Connection.loginSuceessCongViec == true)
            //{
            //    frmChiTietChiTieu frm = new frmChiTietChiTieu(idChiTieu, true);
            //    frm.ShowDialog();
            //}
            //else
            //{
            //    string message = "Bạn cần cấu hình mật khẩu chính xác!";
            //    string title = "Bạn không thể thực hiện chức năng này";
            //    MessageBoxButtons buttons = MessageBoxButtons.OK;
            //    MessageBox.Show(message, title, buttons);
            //}
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (Connection.loginSuceess == true)
            {
                if (idChiTieu != 0)
                {
                    frmChiTietChiTieu frm = new frmChiTietChiTieu(idChiTieu, false);
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn nhật ký cần sửa!");
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

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (Connection.loginSuceess == true)
            {
                if (idChiTieu != 0)
                {
                    frmChiTietChiTieu frm = new frmChiTietChiTieu(idChiTieu, false);
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn nhật ký cần xem!");
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

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            if (Connection.loginSuceess == true)
            {
                dtpBatDau.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-1);
                dtpKetThuc.Value = DateTime.Now.AddYears(3);
                cbHangMuc.SelectedValue = "";
                txtTuKhoa.Text = "";
                cbHangMuc.SelectedIndex = 0;
                LoadData();
            }
            else
            {
                string message = "Bạn cần cấu hình mật khẩu chính xác!";
                string title = "Bạn không thể thực hiện chức năng này";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, title, buttons);
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (Connection.loginSuceess == true)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "Xuất dữ liệu ra Excel";
                saveFileDialog.Filter = "Excel (*.xlsx)|*.xlsx| Excel 2003 (*.xls)|*.xls";
                saveFileDialog.FileName = "Quản lý chi tiêu.xlsx"; // Set tên file mặc định
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ExportExcel(saveFileDialog.FileName);
                        MessageBox.Show("Xuất dữ liệu chi tiêu ra Excel thành công!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xuất dữ liệu chi tiêu ra Excel không thành công!\n" + ex.ToString());
                        MessageBox.Show(ex.ToString());
                    }
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

        private void ExportExcel(string path)
        {
            //if (Connection.loginSuceess == true)
            //{
            //    TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
            //    var _date = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
            //    DateTime dfthoigian = new DateTime(_date.Year, _date.Month, 1);
            //    DateTime dfend = new DateTime(_date.Year, _date.Month, 1);

            //    if (!string.IsNullOrEmpty(dtpBatDau.Text))
            //    {
            //        dfthoigian = DateTime.ParseExact(dtpBatDau.Text + " 00:00:00", "dd/MM/yyyy HH:mm:ss", null);
            //    }

            //    if (!string.IsNullOrEmpty(dtpKetThuc.Text))
            //    {
            //        dfend = DateTime.ParseExact(dtpKetThuc.Text + " 23:59:59", "dd/MM/yyyy HH:mm:ss", null);
            //    }
            //    MyWorkEntities ctx = new MyWorkEntities();
            //    var _hangMucChiTieu = ctx.DanhMucChiTieux.ToList();
            //    var data = ctx.QuanLyChiTieux.Where(c => c.ThoiGian >= dfthoigian && c.ThoiGian <= dfend && c.Complete == true).OrderByDescending(c => c.ThoiGian).ToList();
            //    Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.Application();
            //    Microsoft.Office.Interop.Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);
            //    try
            //    {
            //        // Tạo một sheet mới (Sheet1)
            //        Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.ActiveSheet;
            //        worksheet.Name = "QuanLyChiTieu"; // Đặt tên cho sheet
            //        // Set tiêu đề excel
            //        worksheet.Cells[1, 1] = "ID";
            //        worksheet.Cells[1, 2] = "Thời gian";
            //        worksheet.Cells[1, 3] = "Nội dung";
            //        worksheet.Cells[1, 4] = "Ghi chú";
            //        worksheet.Cells[1, 5] = "Số tiền";
            //        worksheet.Cells[1, 6] = "Hạng mục";

            //        for (int i = 0; i < data.Count; i++)
            //        {
            //            worksheet.Cells[i + 2, 1] = data[i].ID.ToString();
            //            worksheet.Cells[i + 2, 2] = "'" + data[i].ThoiGianMoi;
            //            worksheet.Cells[i + 2, 3] = data[i].NoiDung;
            //            worksheet.Cells[i + 2, 4] = data[i].GhiChu;
            //            worksheet.Cells[i + 2, 5] = "'" + data[i].SoTien.ToString("N0");
            //            worksheet.Cells[i + 2, 6] = _hangMucChiTieu.Where(c => c.ID == data[i].IdDanhMuc).First().TenDanhMuc;
            //        }

            //        // Đặt chiều rộng của các cột
            //        worksheet.Columns[1].ColumnWidth = 10;
            //        worksheet.Columns[2].ColumnWidth = 15;
            //        worksheet.Columns[3].ColumnWidth = 80;
            //        worksheet.Columns[4].ColumnWidth = 80;
            //        worksheet.Columns[5].ColumnWidth = 20;
            //        worksheet.Columns[6].ColumnWidth = 20;

            //        // Đặt màu nền và chữ đậm cho tiêu đề
            //        var titleRange = worksheet.Range["A1:F1"];
            //        titleRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow); // Màu nền vàng
            //        titleRange.Font.Bold = true; // Chữ đậm

            //        // Bổ sung border cho tiêu đề
            //        titleRange.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            //        titleRange.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;

            //        // Đặt màu nền trắng cho dòng chẵn và màu nền xám nhạt cho dòng lẻ
            //        var dataRange = worksheet.Range[$"A2:F{data.Count + 1}"];
            //        for (int i = 1; i <= data.Count; i++)
            //        {
            //            var rowRange = worksheet.Range[$"A{i + 1}:F{i + 1}"];
            //            if (i % 2 == 0)
            //                rowRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White); // Màu nền trắng
            //            else
            //                rowRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray); // Màu nền xám nhạt

            //            // Bổ sung border cho dòng dữ liệu
            //            rowRange.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            //            rowRange.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
            //        }

            //        worksheet.Cells.NumberFormat = "@";
            //        // Đặt chế độ Wrap Text cho các dòng
            //        worksheet.Rows.WrapText = true;

            //        // Định dạng cho toàn bộ sheet
            //        var allTextRange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[data.Count + 1, 6]];
            //        allTextRange.Font.Name = "Times New Roman"; // Font chữ Times New Roman
            //        allTextRange.Font.Size = 12; // Kích thước font chữ
            //        allTextRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft; // Căn trái
            //        allTextRange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop; // Căn trên

            //        // Lưu workbook
            //        workbook.SaveCopyAs(path);
            //        workbook.Saved = true;
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine($"Error: {ex.Message}");
            //    }
            //    finally
            //    {
            //        // Đóng workbook và giải phóng tài nguyên
            //        workbook.Close(false);
            //        application.Quit();

            //        // Giải phóng tài nguyên COM
            //        System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
            //        System.Runtime.InteropServices.Marshal.ReleaseComObject(application);
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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (Connection.loginSuceess == true)
            {
                LoadData();
            }
            else
            {
                string message = "Bạn cần cấu hình mật khẩu chính xác!";
                string title = "Bạn không thể thực hiện chức năng này";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, title, buttons);
            }
        }

        private void dgvQuanLyChiTieu_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Connection.loginSuceess == true)
            {
                idChiTieu = Convert.ToInt32(dgvQuanLyChiTieu.Rows[e.RowIndex].Cells["ID"].Value.ToString());
            }
            else
            {
                string message = "Bạn cần cấu hình mật khẩu chính xác!";
                string title = "Bạn không thể thực hiện chức năng này";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, title, buttons);
            }
        }

        private void dgvQuanLyChiTieu_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Connection.loginSuceess == true)
            {
                frmChiTietChiTieu frm = new frmChiTietChiTieu(idChiTieu, false);
                frm.ShowDialog();
            }
            else
            {
                string message = "Bạn cần cấu hình mật khẩu chính xác!";
                string title = "Bạn không thể thực hiện chức năng này";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, title, buttons);
            }
        }

        private void dgvQuanLyChiTieu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string columnNameSoTien = "Số tiền"; // Thay "Số tiền" bằng tên thực tế của cột
            string columnNameTrangThai = "Trạng thái"; // Thay "Trạng thái" bằng tên thực tế của cột

            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dgvQuanLyChiTieu.Columns[columnNameSoTien].Index)
                {
                    object cellValueSoTien = dgvQuanLyChiTieu.Rows[e.RowIndex].Cells[columnNameSoTien].Value;
                    object cellValueTrangThai = dgvQuanLyChiTieu.Rows[e.RowIndex].Cells[columnNameTrangThai].Value;
                    if (cellValueSoTien != null && decimal.TryParse(cellValueSoTien.ToString(), out decimal soTien) && soTien >= 1000000)
                    {
                        e.CellStyle.BackColor = System.Drawing.Color.Yellow;
                        dgvQuanLyChiTieu.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.Yellow;
                    }
                    else if (cellValueTrangThai != null && cellValueTrangThai.ToString() == "Chưa hoàn thành")
                    {
                        e.CellStyle.BackColor = System.Drawing.Color.Yellow;
                        dgvQuanLyChiTieu.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.Yellow;
                    }
                    else
                    {
                        if (Connection.IsOdd(e.RowIndex))
                        {
                            dgvQuanLyChiTieu.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(238, 238, 233);
                        }
                    }
                }
            }
        }

        private void SetupPageSizeComboBox()
        {
            List<int> pageSizeOptions = new List<int> { 500, 1000, 2000, 5000, 10000 };
            // Gán danh sách vào ComboBox
            cbSoBanGhi.DataSource = pageSizeOptions;
            // Thiết lập giá trị mặc định cho ComboBox (chẳng hạn, bạn có thể chọn một giá trị từ danh sách)
            cbSoBanGhi.SelectedItem = pageSizeOptions.FirstOrDefault();
        }

        private void UpdatePaginationControls()
        {
            btnDauTien.Enabled = currentPage > 1;
            btnTruoc.Enabled = currentPage > 1;
            btnSau.Enabled = currentPage < totalPages;
            btnCuoi.Enabled = currentPage < totalPages;
            txtTrangHienTai.Text = currentPage.ToString("N0");
            cbSoBanGhi.SelectedItem = pageSize.ToString("N0");
        }

        private int CalculateTotalPages(int totalRow)
        {
            int totalRecords = totalRow;
            int totalPages = totalRecords / pageSize;
            if (totalRecords % pageSize > 0)
            {
                totalPages++;
            }
            return totalPages;
        }

        private void cbSoBanGhi_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy giá trị số bản ghi từ combobox và cập nhật pageSize
            if (int.TryParse(cbSoBanGhi.SelectedItem.ToString().Replace(",", ""), out pageSize))
            {
                LoadData();
            }
        }

        private void txtTrangHienTai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int requestedPage;
                if (int.TryParse(txtTrangHienTai.Text.Replace(",", ""), out requestedPage) && requestedPage > 0 && requestedPage <= totalPages)
                {
                    currentPage = requestedPage;
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Số trang không hợp lệ!");
                }
                // Ngăn chặn sự kiện tiếp tục được xử lý
                e.Handled = true;
            }
        }

        private void btnDauTien_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadData();
        }

        private void btnTruoc_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadData();
            }
        }

        private void btnSau_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadData();
            }
        }

        private void btnCuoi_Click(object sender, EventArgs e)
        {
            currentPage = totalPages;
            LoadData();
        }

        private void btnThemMoiThongKe_Click(object sender, EventArgs e)
        {
            //DialogResult result = MessageBox.Show("Bạn có muốn thêm dữ liệu mới không?", "Xác nhận", MessageBoxButtons.OKCancel);
            //if (result == DialogResult.OK)
            //{
            //    // Nếu người dùng chọn OK
            //    var ctx = new MyWorkEntities();
            //    // Lấy bản ghi cuối cùng và tính toán thời gian mới
            //    var lastRecord = ctx.ThongKeChiTieux.OrderByDescending(c => c.ID).FirstOrDefault();
            //    DateTime nextMonth;
            //    if (lastRecord != null)
            //    {
            //        // Lấy ngày 1 của tháng tiếp theo sau thời gian kết thúc của bản ghi cuối cùng
            //        DateTime lastEndDate = lastRecord.ThoiGianKetThuc;
            //        nextMonth = new DateTime(lastEndDate.Year, lastEndDate.Month, 1).AddMonths(1);
            //    }
            //    else
            //    {
            //        // Nếu không có bản ghi nào trong cơ sở dữ liệu, sử dụng thời gian hiện tại
            //        DateTime now = DateTime.Now;
            //        nextMonth = new DateTime(now.Year, now.Month, 1).AddMonths(1);
            //    }
            //    string formattedDate = $"Tháng {nextMonth.Month}/{nextMonth.Year}";

            //    // Tạo đối tượng mới và gán giá trị
            //    var data = new ThongKeChiTieu();
            //    data.ID = lastRecord != null ? lastRecord.ID + 1 : 1;
            //    data.ThoiGian = formattedDate;
            //    data.SoTienChi = 0;
            //    data.SoTienThu = 0;
            //    // Cập nhật thoigianbatdau và thoigianketthuc
            //    DateTime lastRecordEndTime = lastRecord != null ? lastRecord.ThoiGianBatDau : DateTime.Now;
            //    // Tính toán thời gian bắt đầu và kết thúc cho tháng mới
            //    DateTime startDate = new DateTime(lastRecordEndTime.Year, lastRecordEndTime.Month, 1).AddMonths(1);
            //    // Đặt thời gian giờ phút giây của startDate thành 0:00:00
            //    startDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, 0, 0, 0);
            //    // Ngày cuối cùng của tháng theo startDate với thời gian là 23:59:59
            //    DateTime endDate = new DateTime(startDate.Year, startDate.Month, DateTime.DaysInMonth(startDate.Year, startDate.Month), 23, 59, 59);
            //    data.ThoiGianBatDau = startDate;
            //    data.ThoiGianKetThuc = endDate;
            //    // Thêm vào cơ sở dữ liệu và lưu thay đổi
            //    ctx.ThongKeChiTieux.Add(data);
            //    ctx.SaveChanges();
            //    // Load lại dữ liệu
            //    LoadDataThongKeChiTieu();
            //}
        }

        public void LoadDataThongKeChiTieu()
        {
            //if (Connection.loginSuceess == true)
            //{
            //    double tongChiTieu = 0;
            //    double tongThu = 0;
            //    MyWorkEntities ctx = new MyWorkEntities();
            //    var data = ctx.ThongKeChiTieux.OrderByDescending(c => c.ID).AsQueryable();
            //    tongChiTieu = data.Sum(c => c.SoTienChi);
            //    tongThu = data.Sum(c => c.SoTienThu);
            //    System.Data.DataTable dt = new System.Data.DataTable();
            //    dt.Columns.Add("ID", typeof(int));
            //    dt.Columns.Add("ThoiGian", typeof(string));
            //    dt.Columns.Add("ThoiGianBatDau", typeof(string));
            //    dt.Columns.Add("ThoiGianKetThuc", typeof(string));
            //    dt.Columns.Add("SoTienChi", typeof(string));
            //    dt.Columns.Add("SoTienThu", typeof(string));
            //    dt.Columns.Add("SinhHoatPhi", typeof(string));
            //    dt.Columns.Add("HocTap", typeof(string));
            //    dt.Columns.Add("SeChia", typeof(string));
            //    dt.Columns.Add("Om", typeof(string));
            //    dt.Columns.Add("BHNhanTho", typeof(string));
            //    dt.Columns.Add("ConCai", typeof(string));

            //    DataRow dr = null;

            //    foreach (var item in data)
            //    {
            //        dr = dt.NewRow();
            //        dr["ID"] = item.ID.ToString();
            //        dr["ThoiGian"] = item.ThoiGian;
            //        dr["ThoiGianBatDau"] = item.ThoiGianBatDau.ToString("dd/MM/yyyy");
            //        dr["ThoiGianKetThuc"] = item.ThoiGianKetThuc.ToString("dd/MM/yyyy");
            //        dr["SoTienChi"] = item.SoTienChi.ToString("N0");
            //        dr["SoTienThu"] = item.SoTienThu.ToString("N0");
            //        dr["SinhHoatPhi"] = item.SinhHoatPhi.ToString("N0");
            //        dr["HocTap"] = item.HocTap.ToString("N0");
            //        dr["SeChia"] = item.SeChia.ToString("N0");
            //        dr["Om"] = item.Om.ToString("N0");
            //        dr["BHNhanTho"] = item.BHNhanTho.ToString("N0");
            //        dr["ConCai"] = item.ConCai.ToString("N0");
            //        dt.Rows.Add(dr);
            //    }

            //    dt.Columns["ID"].ColumnName = "ID";
            //    dt.Columns["ThoiGian"].ColumnName = "Thời gian";
            //    dt.Columns["ThoiGianBatDau"].ColumnName = "Thời gian bắt đầu";
            //    dt.Columns["ThoiGianKetThuc"].ColumnName = "Thời gian kết thúc";
            //    dt.Columns["SoTienChi"].ColumnName = "Số tiền chi";
            //    dt.Columns["SoTienThu"].ColumnName = "Số tiền thu";
            //    dt.Columns["SinhHoatPhi"].ColumnName = "Sinh hoạt phí";
            //    dt.Columns["HocTap"].ColumnName = "Học tập";
            //    dt.Columns["SeChia"].ColumnName = "Sẻ chia";
            //    dt.Columns["Om"].ColumnName = "Ốm";
            //    dt.Columns["BHNhanTho"].ColumnName = "BH Nhân Thọ";
            //    dt.Columns["ConCai"].ColumnName = "Con cái";

            //    dt.AcceptChanges();

            //    dgvThongKe.DataSource = dt;

            //    // Cài đặt độ rộng cố định cho các cột
            //    dgvThongKe.Columns["ID"].Width = 50;
            //    dgvThongKe.Columns["Thời gian"].Width = 120;
            //    dgvThongKe.Columns["Số tiền chi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //    dgvThongKe.Columns["Số tiền thu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //    dgvThongKe.Columns["Thời gian bắt đầu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //    dgvThongKe.Columns["Thời gian kết thúc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //    dgvThongKe.Columns["Sinh hoạt phí"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //    dgvThongKe.Columns["Học tập"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //    dgvThongKe.Columns["Sẻ chia"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //    dgvThongKe.Columns["Ốm"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //    dgvThongKe.Columns["BH Nhân Thọ"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //    dgvThongKe.Columns["Con cái"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                
            //    dgvThongKe.Columns["Số tiền chi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //    dgvThongKe.Columns["Số tiền thu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //    dgvThongKe.Columns["Sinh hoạt phí"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //    dgvThongKe.Columns["Học tập"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //    dgvThongKe.Columns["Sẻ chia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //    dgvThongKe.Columns["Ốm"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //    dgvThongKe.Columns["BH Nhân Thọ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //    dgvThongKe.Columns["Con cái"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //    dgvThongKe.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    dgvThongKe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            //    lblTongChiTieu.Text = tongChiTieu.ToString("N0");
            //    lblTongThu.Text = tongThu.ToString("N0");
            //}
            //else
            //{
            //    string message = "Bạn cần cấu hình mật khẩu chính xác!";
            //    string title = "Bạn không thể thực hiện chức năng này";
            //    MessageBoxButtons buttons = MessageBoxButtons.OK;
            //    MessageBox.Show(message, title, buttons);
            //}
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            LoadDataThongKeChiTieu();
        }

        private void btnXuatExcelThongKe_Click(object sender, EventArgs e)
        {
            if (Connection.loginSuceess == true)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "Xuất dữ liệu ra Excel";
                saveFileDialog.Filter = "Excel (*.xlsx)|*.xlsx| Excel 2003 (*.xls)|*.xls";
                saveFileDialog.FileName = "Thống kê chi tiêu.xlsx"; // Set tên file mặc định
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ExportExcelThongKeChiTieu(saveFileDialog.FileName);
                        MessageBox.Show("Xuất dữ liệu thống kê chi tiêu ra Excel thành công!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xuất dữ liệu thống kê chi tiêu ra Excel không thành công!\n" + ex.ToString());
                        MessageBox.Show(ex.ToString());
                    }
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

        private void ExportExcelThongKeChiTieu(string path)
        {
            //if (Connection.loginSuceess == true)
            //{
            //    MyWorkEntities ctx = new MyWorkEntities();
            //    var data = ctx.ThongKeChiTieux.OrderByDescending(c => c.ID).ToList();
            //    Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.Application();
            //    Microsoft.Office.Interop.Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);

            //    try
            //    {
            //        // Tạo một sheet mới (Sheet1)
            //        Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.ActiveSheet;
            //        worksheet.Name = "ThongKeChiTieu"; // Đặt tên cho sheet
            //        // Set tiêu đề excel
            //        worksheet.Cells[1, 1] = "ID";
            //        worksheet.Cells[1, 2] = "Thời gian";
            //        worksheet.Cells[1, 3] = "Chi";
            //        worksheet.Cells[1, 4] = "Thu";
            //        worksheet.Cells[1, 5] = "Sinh hoạt phí";
            //        worksheet.Cells[1, 6] = "Học tập";
            //        worksheet.Cells[1, 7] = "Sẻ chia";
            //        worksheet.Cells[1, 8] = "Ốm";
            //        worksheet.Cells[1, 9] = "BH Nhân thọ";
            //        worksheet.Cells[1, 10] = "Con cái";
            //        for (int i = 0; i < data.Count; i++)
            //        {
            //            worksheet.Cells[i + 2, 1] = data[i].ID.ToString();
            //            worksheet.Cells[i + 2, 2] = data[i].ThoiGian;
            //            worksheet.Cells[i + 2, 3] = "'" + data[i].SoTienChi.ToString("N0");
            //            worksheet.Cells[i + 2, 4] = "'" + data[i].SoTienThu.ToString("N0");
            //            worksheet.Cells[i + 2, 5] = "'" + data[i].SinhHoatPhi.ToString("N0");
            //            worksheet.Cells[i + 2, 6] = "'" + data[i].HocTap.ToString("N0");
            //            worksheet.Cells[i + 2, 7] = "'" + data[i].SeChia.ToString("N0");
            //            worksheet.Cells[i + 2, 8] = "'" + data[i].Om.ToString("N0");
            //            worksheet.Cells[i + 2, 9] = "'" + data[i].BHNhanTho.ToString("N0");
            //            worksheet.Cells[i + 2, 10] = "'" + data[i].ConCai.ToString("N0");
            //        }

            //        // Đặt chiều rộng của các cột
            //        worksheet.Columns[1].ColumnWidth = 15;
            //        worksheet.Columns[2].ColumnWidth = 25;
            //        worksheet.Columns[3].ColumnWidth = 25;
            //        worksheet.Columns[4].ColumnWidth = 25;
            //        worksheet.Columns[5].ColumnWidth = 25;
            //        worksheet.Columns[6].ColumnWidth = 25;
            //        worksheet.Columns[7].ColumnWidth = 25;
            //        worksheet.Columns[8].ColumnWidth = 25;
            //        worksheet.Columns[9].ColumnWidth = 25;
            //        worksheet.Columns[10].ColumnWidth = 25;

            //        // Đặt màu nền và chữ đậm cho tiêu đề
            //        var titleRange = worksheet.Range["A1:J1"];
            //        titleRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow); // Màu nền vàng
            //        titleRange.Font.Bold = true; // Chữ đậm

            //        // Bổ sung border cho tiêu đề
            //        titleRange.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            //        titleRange.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;

            //        // Đặt màu nền trắng cho dòng chẵn và màu nền xám nhạt cho dòng lẻ
            //        var dataRange = worksheet.Range[$"A2:J{data.Count + 1}"];
            //        for (int i = 1; i <= data.Count; i++)
            //        {
            //            var rowRange = worksheet.Range[$"A{i + 1}:J{i + 1}"];
            //            if (i % 2 == 0)
            //                rowRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White); // Màu nền trắng
            //            else
            //                rowRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray); // Màu nền xám nhạt

            //            // Bổ sung border cho dòng dữ liệu
            //            rowRange.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            //            rowRange.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
            //        }

            //        worksheet.Cells.NumberFormat = "@";
            //        // Đặt chế độ Wrap Text cho các dòng
            //        worksheet.Rows.WrapText = true;

            //        // Định dạng cho toàn bộ sheet
            //        var allTextRange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[data.Count + 1, 10]];
            //        allTextRange.Font.Name = "Times New Roman"; // Font chữ Times New Roman
            //        allTextRange.Font.Size = 12; // Kích thước font chữ
            //        allTextRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft; // Căn trái
            //        allTextRange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop; // Căn trên

            //        // Lưu workbook
            //        workbook.SaveCopyAs(path);
            //        workbook.Saved = true;
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine($"Error: {ex.Message}");
            //    }
            //    finally
            //    {
            //        // Đóng workbook và giải phóng tài nguyên
            //        workbook.Close(false);
            //        application.Quit();

            //        // Giải phóng tài nguyên COM
            //        System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
            //        System.Runtime.InteropServices.Marshal.ReleaseComObject(application);
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

        private void dgvThongKe_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            for (int i = 0; i <= dgvThongKe.Rows.Count - 1; i++)
            {
                if (Connection.IsOdd(i))
                {
                    dgvThongKe.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(238, 238, 233);
                }
            }
        }

        /// Biểu đồ thống kê chi tiêu
        //private void LoadChartData()
        //{
        //    // Kiểm tra trạng thái của các checkbox
        //    bool baoHiem1 = cbBaoHiem1.Checked;
        //    bool sinhHoatPhi = cbSinhHoatPhi.Checked;
        //    bool hocTap = cbHocTap.Checked;
        //    bool seChia = cbSeChia.Checked;
        //    bool Om = cbOm.Checked;
        //    bool conCai = cbConCai.Checked;

        //    // Truy vấn dữ liệu từ bảng ThongKeChiTieu
        //    using (var ctx = new MyWorkEntities())
        //    {
        //        var targetDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1);
        //        var filteredCount = ctx.ThongKeChiTieux.Count(c => targetDate >= c.ThoiGianKetThuc);
        //        startIndex = Math.Min(startIndex, filteredCount - 1);
        //        var data = ctx.ThongKeChiTieux
        //            .Where(c => targetDate >= c.ThoiGianKetThuc)
        //            .OrderByDescending(c => c.ID)
        //            .Skip(startIndex)
        //            .Take(6)
        //            .ToList(); // Chỉ lấy 6 bản ghi từ chỉ số startIndex

        //        // Kiểm tra nếu không có dữ liệu
        //        if (data.Count == 0)
        //        {
        //            // Không có dữ liệu, không cần tải và thoát khỏi phương thức
        //            return;
        //        }

        //        // Tính toán giá trị lớn nhất trong dữ liệu cho cả số tiền chi và số tiền thu
        //        double maxValueChi = 0;
        //        double maxValueThu = 0;

        //        foreach (var item in data)
        //        {
        //            double chiTien = item.SoTienChi;
        //            if (!baoHiem1)
        //                chiTien -= item.BHNhanTho;

        //            // Trừ các chi phí nếu checkbox không được chọn
        //            if (!sinhHoatPhi) chiTien -= item.SinhHoatPhi;
        //            if (!hocTap) chiTien -= item.HocTap;
        //            if (!seChia) chiTien -= item.SeChia;
        //            if (!seChia) chiTien -= item.Om;
        //            if (!conCai) chiTien -= item.ConCai;

        //            maxValueChi = Math.Max(maxValueChi, chiTien);
        //            maxValueThu = Math.Max(maxValueThu, item.SoTienThu);
        //        }

        //        // Xóa các Series hiện có trên biểu đồ
        //        cThongKeChiTieuTheoThang.Series.Clear();

        //        // Tạo một Series mới cho biểu đồ cho số tiền chi
        //        Series seriesChi = new Series("Thống kê chi tiêu");
        //        seriesChi.ChartType = SeriesChartType.Column;

        //        // Tạo một Series mới cho biểu đồ cho số tiền thu
        //        Series seriesThu = new Series("Thống kê thu nhập");
        //        seriesThu.ChartType = SeriesChartType.Column;

        //        // Thêm các điểm dữ liệu từ kết quả truy vấn vào Series cho số tiền chi
        //        foreach (var item in data)
        //        {
        //            double chiTien = item.SoTienChi;
        //            if (!baoHiem1)
        //                chiTien -= item.BHNhanTho;

        //            // Trừ các chi phí nếu checkbox không được chọn
        //            if (!sinhHoatPhi) chiTien -= item.SinhHoatPhi;
        //            if (!hocTap) chiTien -= item.HocTap;
        //            if (!seChia) chiTien -= item.SeChia;
        //            if (!Om) chiTien -= item.Om;
        //            if (!conCai) chiTien -= item.ConCai;

        //            // Định dạng số tiền chi theo định dạng "N0"
        //            double formattedAmountChi = double.Parse(chiTien.ToString("N0"));

        //            // Thêm điểm dữ liệu cho số tiền chi vào Series
        //            DataPoint pointChi = new DataPoint();
        //            pointChi.SetValueXY(item.ThoiGian, formattedAmountChi);
        //            seriesChi.Points.Add(pointChi);
        //            pointChi.Label = formattedAmountChi.ToString("N0"); // Gán số tiền làm ghi chú trên cột
        //            pointChi.Tag = chiTien; // Lưu số tiền gốc vào thuộc tính Tag của điểm dữ liệu
        //        }

        //        // Thêm các điểm dữ liệu từ kết quả truy vấn vào Series cho số tiền thu
        //        foreach (var item in data)
        //        {
        //            // Định dạng số tiền thu theo định dạng "N0"
        //            double formattedAmountThu = double.Parse(item.SoTienThu.ToString("N0"));

        //            // Thêm điểm dữ liệu cho số tiền thu vào Series
        //            DataPoint pointThu = new DataPoint();
        //            pointThu.SetValueXY(item.ThoiGian, formattedAmountThu);
        //            seriesThu.Points.Add(pointThu);
        //            pointThu.Label = formattedAmountThu.ToString("N0"); // Gán số tiền làm ghi chú trên cột
        //            pointThu.Tag = item.SoTienThu; // Lưu số tiền gốc vào thuộc tính Tag của điểm dữ liệu
        //        }

        //        // Đặt kiểu biểu đồ cho Series (ví dụ: Column, Line, ...)
        //        seriesChi.Color = Color.FromArgb(255, 86, 157, 255); // Màu xanh dương cho số tiền chi
        //        seriesThu.Color = Color.FromArgb(255, 255, 0, 0);   // Màu đỏ cho số tiền thu

        //        // Thiết lập màu sắc cho tiêu đề trục x và trục y
        //        cThongKeChiTieuTheoThang.ChartAreas[0].AxisX.TitleForeColor = Color.FromArgb(255, 0, 128, 0); // Màu xanh lá cây
        //        cThongKeChiTieuTheoThang.ChartAreas[0].AxisY.TitleForeColor = Color.FromArgb(255, 255, 128, 0); // Màu cam

        //        // Thiết lập định dạng số cho trục y
        //        cThongKeChiTieuTheoThang.ChartAreas[0].AxisY.LabelStyle.Format = "N0";

        //        // Tính toán giá trị lớn nhất của dữ liệu và làm tròn lên
        //        double maxValueRoundedChi = Math.Ceiling(maxValueChi / 10000000) * 10000000;
        //        double maxValueRoundedThu = Math.Ceiling(maxValueThu / 10000000) * 10000000;

        //        // Thiết lập giá trị tối đa cho trục y
        //        cThongKeChiTieuTheoThang.ChartAreas[0].AxisY.Maximum = Math.Max((maxValueRoundedChi * 1.1) + 10000000, (maxValueRoundedThu * 1.1) + 10000000); // Tăng giá trị tối đa thêm 10% để tránh chặn các cột cao nhất

        //        // Thêm Series vào control Chart
        //        cThongKeChiTieuTheoThang.Series.Add(seriesChi);
        //        cThongKeChiTieuTheoThang.Series.Add(seriesThu);

        //        // Đặt tiêu đề cho trục x và trục y
        //        cThongKeChiTieuTheoThang.ChartAreas[0].AxisX.Title = "Thời Gian";
        //        cThongKeChiTieuTheoThang.ChartAreas[0].AxisY.Title = "Số Tiền";

        //        // Thêm sự kiện Customize cho biểu đồ để hiển thị thông tin khi di chuột vào
        //        cThongKeChiTieuTheoThang.GetToolTipText += Chart_GetToolTipText;

        //        // Kiểm tra xem có thể điều hướng qua bản ghi trước không
        //        btnTruoc.Enabled = startIndex > 0;

        //        // Kiểm tra xem có thể điều hướng qua bản ghi sau không
        //        btnSau.Enabled = filteredCount > startIndex + 6;

        //        // Kiểm tra xem có thể điều hướng qua bản ghi đầu không
        //        btnDau.Enabled = startIndex > 0;

        //        // Kiểm tra xem có thể điều hướng qua bản ghi cuối không
        //        btnCuoi.Enabled = startIndex + 6 < filteredCount;
        //    }
        //}

        //private void Chart_GetToolTipText(object sender, ToolTipEventArgs e)
        //{
        //    // Kiểm tra xem chuột có đang ở trên một điểm dữ liệu không
        //    if (e.HitTestResult.PointIndex >= 0)
        //    {
        //        // Lấy Series của điểm dữ liệu
        //        Series series = (Series)e.HitTestResult.Series;

        //        // Kiểm tra xem có điểm dữ liệu nào không
        //        if (series != null && series.Points != null && series.Points.Count > e.HitTestResult.PointIndex)
        //        {
        //            // Lấy điểm dữ liệu được nhấp chuột
        //            DataPoint dataPoint = series.Points[e.HitTestResult.PointIndex];

        //            // Kiểm tra xem thuộc tính Tag có tồn tại không
        //            if (dataPoint != null && dataPoint.Tag != null)
        //            {
        //                // Hiển thị thông tin thời gian và số tiền của điểm dữ liệu
        //                e.Text = $"Thời Gian: {dataPoint.AxisLabel}";

        //                // Nếu Series là của số tiền chi, thêm thông tin về số tiền chi vào chuỗi
        //                if (series.Name == "Thống kê chi tiêu")
        //                {
        //                    e.Text += $"\nSố Tiền Chi: {((double)dataPoint.Tag).ToString("N0")} VND";
        //                }
        //                // Nếu Series là của số tiền thu, thêm thông tin về số tiền thu vào chuỗi
        //                else if (series.Name == "Thống kê thu nhập")
        //                {
        //                    e.Text += $"\nSố Tiền Thu: {((double)dataPoint.Tag).ToString("N0")} VND";
        //                }
        //            }
        //        }
        //    }
        //}

        private void btnDau_Click(object sender, EventArgs e)
        {
            // Đặt chỉ số bắt đầu về 0 để lấy bản ghi đầu tiên
            startIndex = 0;
            //LoadChartData(); // Tải dữ liệu mới với chỉ số mới
        }

        private void btnTruocThongKe_Click(object sender, EventArgs e)
        {
            // Đảm bảo chỉ số bắt đầu không âm
            startIndex = Math.Max(0, startIndex - 6);
            //LoadChartData();
        }

        private void btnSauThongKe_Click(object sender, EventArgs e)
        {
            startIndex += 6; // Tăng chỉ số bắt đầu để lấy các bản ghi tiếp theo
            //LoadChartData();
        }

        private void btnThongKeCuoi_Click(object sender, EventArgs e)
        {
            //var ctx = new MyWorkEntities();
            //var targetDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1);
            //totalPages = ctx.ThongKeChiTieux.Count(c => targetDate >= c.ThoiGianKetThuc);
            //startIndex = Math.Max(0, totalPages - 6);
            //LoadChartData();
        }

        private void btnDauDM_Click(object sender, EventArgs e)
        {
            _startIndex = 0;
            LoadChartDataDM();
        }

        private void btnTruocDM_Click(object sender, EventArgs e)
        {
            // Đảm bảo chỉ số bắt đầu không âm
            _startIndex = Math.Max(0, _startIndex - 4);
            LoadChartDataDM();
        }

        private void btnSauDM_Click(object sender, EventArgs e)
        {
            _startIndex += 4; // Tăng chỉ số bắt đầu để lấy các bản ghi tiếp theo
            LoadChartDataDM();
        }

        private void btnCuoiDM_Click(object sender, EventArgs e)
        {
            //var ctx = new MyWorkEntities();
            //var targetDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1);
            //_totalPages = ctx.ThongKeChiTieux.Count(c => targetDate >= c.ThoiGianKetThuc);
            //_startIndex = Math.Max(0, _totalPages - 4);
            LoadChartDataDM();
        }

        private void LoadChartDataDM()
        {
            //using (var ctx = new MyWorkEntities())
            //{
            //    var targetDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1);
            //    var filteredCount = ctx.ThongKeChiTieux.Count(c => targetDate >= c.ThoiGianKetThuc);
            //    _startIndex = Math.Min(_startIndex, filteredCount - 1);
            //    var data = ctx.ThongKeChiTieux
            //        .Where(c => targetDate >= c.ThoiGianKetThuc)
            //        .OrderByDescending(c => c.ID)
            //        .Skip(_startIndex)
            //        .Take(4)
            //        .ToList();

            //    if (data.Count == 0)
            //    {
            //        return;
            //    }

            //    // Tạo các Series mới cho biểu đồ cho 4 cột dữ liệu
            //    Series seriesSinhHoatPhi = new Series("Sinh Hoạt Phí");
            //    seriesSinhHoatPhi.ChartType = SeriesChartType.Column;

            //    Series seriesHocTap = new Series("Học Tập");
            //    seriesHocTap.ChartType = SeriesChartType.Column;

            //    Series seriesSeChia = new Series("Sẻ Chia");
            //    seriesSeChia.ChartType = SeriesChartType.Column;

            //    Series seriesOm = new Series("Ốm");
            //    seriesOm.ChartType = SeriesChartType.Column;

            //    Series seriesBHNhanTho = new Series("BH Nhân Thọ");
            //    seriesBHNhanTho.ChartType = SeriesChartType.Column;

            //    Series seriesConCai = new Series("Con Cái");
            //    seriesConCai.ChartType = SeriesChartType.Column;

            //    // Xóa các Series hiện có trên biểu đồ
            //    cThongKeChiTieuTheoDanhMuc.Series.Clear();

            //    // Thêm dữ liệu từ các cột mới vào các Series tương ứng
            //    foreach (var item in data)
            //    {
            //        DataPoint pointSinhHoatPhi = new DataPoint();
            //        pointSinhHoatPhi.SetValueXY(item.ThoiGian, item.SinhHoatPhi);
            //        seriesSinhHoatPhi.Points.Add(pointSinhHoatPhi);
            //        pointSinhHoatPhi.Label = item.SinhHoatPhi.ToString("N0"); // Gán số tiền làm ghi chú trên cột
            //        pointSinhHoatPhi.Tag = item.SinhHoatPhi; // Lưu số tiền gốc vào thuộc tính Tag của điểm dữ liệu

            //        DataPoint pointHocTap = new DataPoint();
            //        pointHocTap.SetValueXY(item.ThoiGian, item.HocTap);
            //        seriesHocTap.Points.Add(pointHocTap);
            //        pointHocTap.Label = item.HocTap.ToString("N0"); // Gán số tiền làm ghi chú trên cột
            //        pointHocTap.Tag = item.HocTap; // Lưu số tiền gốc vào thuộc tính Tag của điểm dữ liệu

            //        DataPoint pointSeChia = new DataPoint();
            //        pointSeChia.SetValueXY(item.ThoiGian, item.SeChia);
            //        seriesSeChia.Points.Add(pointSeChia);
            //        pointSeChia.Label = item.SeChia.ToString("N0"); // Gán số tiền làm ghi chú trên cột
            //        pointSeChia.Tag = item.SeChia; // Lưu số tiền gốc vào thuộc tính Tag của điểm dữ liệu

            //        DataPoint pointOm = new DataPoint();
            //        pointSeChia.SetValueXY(item.ThoiGian, item.Om);
            //        seriesOm.Points.Add(pointOm);
            //        pointOm.Label = item.Om.ToString("N0"); // Gán số tiền làm ghi chú trên cột
            //        pointOm.Tag = item.Om; // Lưu số tiền gốc vào thuộc tính Tag của điểm dữ liệu

            //        DataPoint pointBHNhanTho = new DataPoint();
            //        pointBHNhanTho.SetValueXY(item.ThoiGian, item.BHNhanTho);
            //        seriesBHNhanTho.Points.Add(pointBHNhanTho);
            //        pointBHNhanTho.Label = item.BHNhanTho.ToString("N0"); // Gán số tiền làm ghi chú trên cột
            //        pointBHNhanTho.Tag = item.BHNhanTho; // Lưu số tiền gốc vào thuộc tính Tag của điểm dữ liệu

            //        DataPoint pointConCai = new DataPoint();
            //        pointConCai.SetValueXY(item.ThoiGian, item.ConCai);
            //        seriesConCai.Points.Add(pointConCai);
            //        pointConCai.Label = item.ConCai.ToString("N0"); // Gán số tiền làm ghi chú trên cột
            //        pointConCai.Tag = item.ConCai; // Lưu số tiền gốc vào thuộc tính Tag của điểm dữ liệu
            //    }

            //    // Thêm các Series vào control Chart
            //    cThongKeChiTieuTheoDanhMuc.Series.Add(seriesSinhHoatPhi);
            //    cThongKeChiTieuTheoDanhMuc.Series.Add(seriesHocTap);
            //    cThongKeChiTieuTheoDanhMuc.Series.Add(seriesSeChia);
            //    cThongKeChiTieuTheoDanhMuc.Series.Add(seriesOm);
            //    cThongKeChiTieuTheoDanhMuc.Series.Add(seriesBHNhanTho);
            //    cThongKeChiTieuTheoDanhMuc.Series.Add(seriesConCai);

            //    // Đặt tiêu đề cho trục x và trục y
            //    cThongKeChiTieuTheoDanhMuc.ChartAreas[0].AxisX.Title = "Thời Gian";
            //    cThongKeChiTieuTheoDanhMuc.ChartAreas[0].AxisY.Title = "Số Tiền";

            //    // Thêm sự kiện Customize cho biểu đồ để hiển thị thông tin khi di chuột vào
            //    cThongKeChiTieuTheoDanhMuc.GetToolTipText += ChartDM_GetToolTipText;

            //    // Kiểm tra xem có thể điều hướng qua bản ghi trước không
            //    btnTruocDM.Enabled = _startIndex > 0;

            //    // Kiểm tra xem có thể điều hướng qua bản ghi sau không
            //    btnSauDM.Enabled = filteredCount > _startIndex + 4;

            //    // Kiểm tra xem có thể điều hướng qua bản ghi đầu không
            //    btnDauDM.Enabled = _startIndex > 0;

            //    // Kiểm tra xem có thể điều hướng qua bản ghi cuối không
            //    btnCuoiDM.Enabled = _startIndex + 4 < filteredCount;
            //}
        }

        private void ChartDM_GetToolTipText(object sender, ToolTipEventArgs e)
        {
            // Kiểm tra xem chuột có đang ở trên một điểm dữ liệu không
            if (e.HitTestResult.PointIndex >= 0)
            {
                // Lấy Series của điểm dữ liệu
                Series series = (Series)e.HitTestResult.Series;

                // Kiểm tra xem có điểm dữ liệu nào không
                if (series != null && series.Points != null && series.Points.Count > e.HitTestResult.PointIndex)
                {
                    // Lấy điểm dữ liệu được nhấp chuột
                    DataPoint dataPoint = series.Points[e.HitTestResult.PointIndex];

                    // Hiển thị thông tin thời gian và số tiền của điểm dữ liệu
                    e.Text = $"Thời Gian: {dataPoint.AxisLabel}\n";

                    // Kiểm tra xem thuộc tính Tag có tồn tại không và hiển thị thông tin tương ứng
                    if (dataPoint != null && dataPoint.Tag != null)
                    {
                        if (series.Name == "Sinh Hoạt Phí")
                        {
                            e.Text += $"Sinh Hoạt Phí: {((double)dataPoint.Tag).ToString("N0")} VND";
                        }
                        else if (series.Name == "Học Tập")
                        {
                            e.Text += $"Học Tập: {((double)dataPoint.Tag).ToString("N0")} VND";
                        }
                        else if (series.Name == "Sẻ Chia")
                        {
                            e.Text += $"Se Chia: {((double)dataPoint.Tag).ToString("N0")} VND";
                        }
                        else if (series.Name == "BH Nhân Thọ")
                        {
                            e.Text += $"BH Nhân Thọ: {((double)dataPoint.Tag).ToString("N0")} VND";
                        }
                        else if (series.Name == "Con Cái")
                        {
                            e.Text += $"Con Cái: {((double)dataPoint.Tag).ToString("N0")} VND";
                        }
                    }
                }
            }
        }

        private void btnThongKe_Click_1(object sender, EventArgs e)
        {
            //frmThemThongKeChiTieu _frmThemThongKeChiTieu = new frmThemThongKeChiTieu();
            //_frmThemThongKeChiTieu.ShowDialog();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            //DateTime dfromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0); // Bắt đầu từ 00:00:00
            //DateTime dfendDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month), 23, 59, 59); // Kết thúc vào 23:59:59
            //using (var context = new MyWorkEntities())
            //{
            //    // Lấy dữ liệu từ bảng QuanLyChiTieu dựa trên thời gian
            //    var ChiTieu = context.QuanLyChiTieux
            //        .Where(q => q.ThoiGian >= dfromDate && q.ThoiGian <= dfendDate && q.Complete == true).ToList();
            //    var sumSoTienThu = context.ThuChis.Where(q => q.ThoiGian >= dfromDate && q.ThoiGian <= dfendDate && q.Status == true).Sum(q => (double?)q.Thu);
            //    // Lấy dữ liệu từ bảng ThongKeChiTieu
            //    var thongKeChiTieus = context.ThongKeChiTieux.Where(t => t.ThoiGianBatDau >= dfromDate && t.ThoiGianKetThuc <= dfendDate).FirstOrDefault();
            //    if (thongKeChiTieus != null)
            //    {
            //        // Sử dụng tổng SoTienChi đã tính trước đó
            //        thongKeChiTieus.SoTienChi = ChiTieu.Sum(q => q.SoTien);
            //        thongKeChiTieus.SoTienThu = context.ThuChis.Where(q => q.ThoiGian >= dfromDate && q.ThoiGian <= dfendDate && q.Status == true).Sum(q => (double?)q.Thu) ?? 0;
            //        thongKeChiTieus.SinhHoatPhi = ChiTieu.Where(q => q.IdDanhMuc == 2).Sum(q => q.SoTien);
            //        thongKeChiTieus.HocTap = ChiTieu.Where(q => q.IdDanhMuc == 3).Sum(q => q.SoTien);
            //        thongKeChiTieus.SeChia = ChiTieu.Where(q => q.IdDanhMuc == 4).Sum(q => q.SoTien);
            //        // Gộp các IdDanhMuc từ 6 đến 10 vào ConCai
            //        thongKeChiTieus.ConCai = ChiTieu.Where(q => q.IdDanhMuc >= 5 && q.IdDanhMuc <= 10).Sum(q => q.SoTien);
            //        // Lưu các thay đổi vào cơ sở dữ liệu
            //        context.SaveChanges();
            //    }
            //    else
            //    {
            //        // Nếu người dùng chọn OK
            //        var ctx = new MyWorkEntities();
            //        // Lấy bản ghi cuối cùng và tính toán thời gian mới
            //        var lastRecord = ctx.ThongKeChiTieux.OrderByDescending(c => c.ID).FirstOrDefault();
            //        DateTime nextMonth;
            //        if (lastRecord != null)
            //        {
            //            nextMonth = lastRecord.ThoiGianKetThuc.AddSeconds(1).AddMonths(1); // Bắt đầu từ ngày sau thời gian kết thúc của bản ghi cuối cùng
            //        }
            //        else
            //        {
            //            nextMonth = DateTime.Now.AddMonths(1); // Sử dụng thời gian hiện tại nếu không có bản ghi nào trong cơ sở dữ liệu
            //        }
            //        string formattedDate = $"Tháng {nextMonth.Month}/{nextMonth.Year}";
            //        // Tạo đối tượng mới và gán giá trị
            //        var data = new ThongKeChiTieu();
            //        data.ID = lastRecord != null ? lastRecord.ID + 1 : 1;
            //        data.ThoiGian = formattedDate;
            //        data.SoTienChi = 0;
            //        data.SoTienThu = 0;

            //        // Cập nhật thoigianbatdau và thoigianketthuc
            //        DateTime lastRecordEndTime = lastRecord != null ? lastRecord.ThoiGianKetThuc : DateTime.Now;

            //        // Tính toán thời gian bắt đầu và kết thúc cho tháng mới
            //        DateTime startDate = lastRecordEndTime.AddDays(1); // Bắt đầu từ ngày sau thời gian kết thúc của bản ghi cuối cùng
            //        DateTime endDate = new DateTime(startDate.Year, startDate.Month, DateTime.DaysInMonth(startDate.Year, startDate.Month), 23, 59, 59);
            //        data.ThoiGianBatDau = startDate;
            //        data.ThoiGianKetThuc = endDate;

            //        // Thêm vào cơ sở dữ liệu và lưu thay đổi
            //        ctx.ThongKeChiTieux.Add(data);
            //        ctx.SaveChanges();
            //    }
            //    // Load lại dữ liệu
            //    LoadDataThongKeChiTieu();
            //}
        }

        private void cbBaoHiem_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cbBaoHiem1_CheckedChanged(object sender, EventArgs e)
        {
            //LoadChartData();
        }

        private void cbHocTap_CheckedChanged(object sender, EventArgs e)
        {
            //LoadChartData();
        }

        private void cbSinhHoatPhi_CheckedChanged(object sender, EventArgs e)
        {
            //LoadChartData();
        }

        private void cbSeChia_CheckedChanged(object sender, EventArgs e)
        {
            //LoadChartData();
        }

        private void cbConCai_CheckedChanged(object sender, EventArgs e)
        {
            //LoadChartData();
        }

        private void cbOm_CheckedChanged(object sender, EventArgs e)
        {
            //LoadChartData();
        }
    }
}
