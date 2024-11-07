using MyWork.Data;
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyWork
{
    public partial class frmQuanLyNo : Form
    {
        private int idNo = 0;
        string tukhoa = "";
        private double tongNo = 0;
        private double tongHoanThanh = 0;
        private double tongChuaHoanThanh = 0;
        public frmQuanLyNo()
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

        private void frmQuanLyNo_Load(object sender, EventArgs e)
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

        private void LoadData()
        {
            //if (Connection.loginSuceess == true)
            //{
            //    tukhoa = txtTuKhoa.Text.Trim();
            //    MyWorkEntities ctx = new MyWorkEntities();
            //    var data = ctx.QuanLyNoes.OrderByDescending(c => c.ID).ToList();
            //    if (!string.IsNullOrEmpty(tukhoa))
            //    {
            //        data = data.Where(c => c.NoiDung.Contains(tukhoa)).ToList();
            //    }

            //    // Kiểm tra xem có bản ghi nào trong tập hợp không
            //    if (data.Any())
            //    {
            //        // Tính tổng chi khi có ít nhất một bản ghi
            //        tongNo = data.Sum(item => item.SoNo);

            //        // Kiểm tra và tính tổng khi Complete == false
            //        var chuaHoanThanhItems = data.Where(item => item.Complete == false);
            //        tongChuaHoanThanh = chuaHoanThanhItems.Any() ? chuaHoanThanhItems.Sum(item => item.SoNo) : 0;

            //        // Kiểm tra và tính tổng khi Complete == true
            //        var hoanThanhItems = data.Where(item => item.Complete == true);
            //        tongHoanThanh = hoanThanhItems.Any() ? hoanThanhItems.Sum(item => item.SoNo) : 0;
            //    }
            //    else
            //    {
            //        // Nếu tập hợp rỗng, đặt tổng về 0 hoặc giá trị mặc định tùy ý
            //        tongNo = 0;
            //        tongChuaHoanThanh = 0;
            //        tongHoanThanh = 0;
            //    }

            //    DataTable dt = new DataTable();
            //    dt.Columns.Add("ID", typeof(int));
            //    dt.Columns.Add("NoiDung", typeof(string));
            //    dt.Columns.Add("SoNo", typeof(string));
            //    dt.Columns.Add("Status", typeof(string));
            //    dt.Columns.Add("ThoiGian", typeof(string));

            //    DataRow dr = null;

            //    foreach (var item in data)
            //    {
            //        dr = dt.NewRow();
            //        dr["ID"] = item.ID.ToString();

            //        if (Connection.loginSuceess == true)
            //        {
            //            dr["NoiDung"] = item.NoiDung;
            //            dr["SoNo"] = item.SoNo.ToString("N0");
            //            dr["Status"] = item.Complete == true ? "Hoàn thành" : "Chưa hoàn thành";
            //            dr["ThoiGian"] = item.ThoiGian.ToString("dd/MM/yyyy");
            //        }
            //        else
            //        {
            //            dr["NoiDung"] = "*****************";
            //            dr["SoNo"] = "*****************";
            //            dr["Status"] = "*****************";
            //            dr["ThoiGian"] = "*****************";
            //        }

            //        dt.Rows.Add(dr);
            //    }

            //    dt.Columns["ID"].ColumnName = "ID";
            //    dt.Columns["ThoiGian"].ColumnName = "Thời gian cập nhật";
            //    dt.Columns["NoiDung"].ColumnName = "Tiêu đề";
            //    dt.Columns["SoNo"].ColumnName = "Số nợ";
            //    dt.Columns["Status"].ColumnName = "Trạng thái";

            //    dt.AcceptChanges();

            //    dgvQuanLyNo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    dgvQuanLyNo.DataSource = dt;
            //    //dgvQuanLyNo.Columns[0].Visible = false;

            //    // Ngăn chặn cột tự động điều chỉnh kích thước
            //    dgvQuanLyNo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            //    // Cài đặt độ rộng cố định cho các cột khác trừ "Nội dung" và "Ghi chú"
            //    dgvQuanLyNo.Columns["ID"].Width = 35;
            //    dgvQuanLyNo.Columns["Thời gian cập nhật"].Width = 120;
            //    dgvQuanLyNo.Columns["Số nợ"].Width = 80;
            //    dgvQuanLyNo.Columns["Trạng thái"].Width = 100;

            //    // Tự động điều chỉnh kích thước cho cột "Nội dung" và "Ghi chú"
            //    dgvQuanLyNo.Columns["Tiêu đề"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //    lblTongTien.Text = tongNo.ToString("N0");
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
                frmChiTietNo frm = new frmChiTietNo();
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
            //    frmChiTietNo frm = new frmChiTietNo(idNo, true);
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
                frmChiTietNo frm = new frmChiTietNo();
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

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (Connection.loginSuceess == true)
            {
                if (idNo != 0)
                {
                    frmChiTietNo frm = new frmChiTietNo(idNo, false);
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
                dgvQuanLyNo.DataSource = null;
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
                saveFileDialog.FileName = "Quản lý nợ.xlsx"; // Set tên file mặc định
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ExportExcel(saveFileDialog.FileName);
                        MessageBox.Show("Xuất dữ liệu quản lý nợ ra Excel thành công!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xuất dữ liệu quản lý nợ ra Excel không thành công!\n" + ex.ToString());
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
            //    MyWorkEntities ctx = new MyWorkEntities();
            //    var data = ctx.QuanLyNoes.OrderByDescending(c => c.ThoiGian).ToList();
            //    Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.Application();
            //    Microsoft.Office.Interop.Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);

            //    try
            //    {
            //        // Tạo một sheet mới (Sheet1)
            //        Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.ActiveSheet;
            //        worksheet.Name = "QuanLyNo"; // Đặt tên cho sheet

            //        // Set tiêu đề excel
            //        worksheet.Cells[1, 1] = "ID";
            //        worksheet.Cells[1, 2] = "Thời gian";
            //        worksheet.Cells[1, 3] = "Tiêu đề";
            //        worksheet.Cells[1, 4] = "Số nợ";
            //        worksheet.Cells[1, 5] = "Ghi chú";

            //        // Định dạng tiêu đề chữ đậm, màu nền màu vàng và giữa tiêu đề
            //        var titleRange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 5]];
            //        titleRange.Font.Bold = true;
            //        titleRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
            //        titleRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            //        // Căn giữa tiêu đề
            //        titleRange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

            //        for (int i = 0; i < data.Count; i++)
            //        {
            //            worksheet.Cells[i + 2, 1] = data[i].ID.ToString();
            //            worksheet.Cells[i + 2, 2] = data[i].ThoiGian.ToString("dd/MM/yyyy");
            //            worksheet.Cells[i + 2, 3] = data[i].NoiDung;
            //            worksheet.Cells[i + 2, 4] = data[i].SoNo.ToString("N0");

            //            // Đặt màu nền cho dòng 2n và dòng 2n+1
            //            var dataRange = worksheet.Range[worksheet.Cells[i + 2, 1], worksheet.Cells[i + 2, 5]];
            //            if (i % 2 == 0)
            //            {
            //                dataRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
            //            }
            //            else
            //            {
            //                dataRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
            //            }
            //        }

            //        // Đặt chiều rộng của các cột
            //        worksheet.Columns[1].ColumnWidth = 15;
            //        worksheet.Columns[2].ColumnWidth = 15;
            //        worksheet.Columns[3].ColumnWidth = 100;
            //        worksheet.Columns[4].ColumnWidth = 25;
            //        worksheet.Columns[5].ColumnWidth = 100;

            //        // Đặt chế độ Wrap Text cho các dòng
            //        worksheet.Rows.WrapText = true;

            //        // Định dạng cho toàn bộ sheet
            //        var allTextRange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[data.Count + 1, 5]];
            //        allTextRange.Font.Name = "Times New Roman"; // Font chữ Times New Roman
            //        allTextRange.Font.Size = 12; // Kích thước font chữ
            //        allTextRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft; // Căn trái
            //        allTextRange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop; // Căn trên

            //        // Thêm border cho toàn bộ vùng văn bản
            //        allTextRange.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            //        allTextRange.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;

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

        private void dgvQuanLyNo_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Connection.loginSuceess == true)
            {
                idNo = Convert.ToInt32(dgvQuanLyNo.Rows[e.RowIndex].Cells["ID"].Value.ToString());
            }
            else
            {
                string message = "Bạn cần cấu hình mật khẩu chính xác!";
                string title = "Bạn không thể thực hiện chức năng này";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, title, buttons);
            }
        }

        private void dgvQuanLyNo_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Connection.loginSuceess == true)
            {
                frmChiTietNo frm = new frmChiTietNo(idNo, false);
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

        private void dgvQuanLyNo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvQuanLyNo.Columns["Trạng thái"].Index)
            {
                object cellValue = dgvQuanLyNo.Rows[e.RowIndex].Cells["Trạng thái"].Value;

                if (cellValue != null && cellValue.ToString() == "Chưa hoàn thành")
                {
                    e.CellStyle.BackColor = System.Drawing.Color.Yellow;

                    // Tô màu toàn bộ dòng
                    dgvQuanLyNo.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.Yellow;
                }
                else
                {
                    // Áp dụng định dạng cho các dòng khác
                    if (Connection.IsOdd(e.RowIndex))
                    {
                        dgvQuanLyNo.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(238, 238, 233);
                    }
                }
            }
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
    }
}
