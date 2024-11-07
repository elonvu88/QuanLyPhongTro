using DocumentFormat.OpenXml.Drawing.Charts;
using MyWork.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace MyWork
{
    public partial class frmDongBoDuLieu : Form
    {
        private string tuKhoa = "";
        private string loaiDongBo = "";
        private int idNguoiViet = 0;
        private int pageSize = 50; // Số bản ghi trên mỗi trang
        private int currentPage = 1; // Trang hiện tại
        int totalPages = 0;

        List<NguoiTao> lstNguoiViet = new List<NguoiTao>()
        {
            new NguoiTao(){UserID = 0, DisplayName = "Tất cả"},
            new NguoiTao(){UserID = 1, DisplayName = "Vũ Khánh"},
            new NguoiTao(){UserID = 2, DisplayName = "Đào Hằng"},
        };

        List<LoaiDongBo> lstLoaiDongBo = new List<LoaiDongBo>()
        {
            new LoaiDongBo(){ID = "", TenLoai = "Tất cả"},
            new LoaiDongBo(){ID = "I", TenLoai = "I - Insert"},
            new LoaiDongBo(){ID = "U", TenLoai = "U - Upate"},
            new LoaiDongBo(){ID = "D", TenLoai = "D - Delete"},
        };

        public frmDongBoDuLieu()
        {
            InitializeComponent();
        }
        private void frmDongBoDuLieu_Load(object sender, EventArgs e)
        {
        }

        private void SetupPageSizeComboBox()
        {
            List<int> pageSizeOptions = new List<int> { 50, 100, 200, 500, 1000 };
            // Gán danh sách vào ComboBox
            cbSoBanGhi.DataSource = pageSizeOptions;
            // Thiết lập giá trị mặc định cho ComboBox (chẳng hạn, bạn có thể chọn một giá trị từ danh sách)
            cbSoBanGhi.SelectedItem = pageSizeOptions.FirstOrDefault();
        }

        private void LoadData()
        {
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

        private void dgvSMS_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
        }

        private void btnExportExcel_Click_1(object sender, EventArgs e)
        {
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
        }

        private void btnDongBoDuLieu_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
        }

        private void btnDongBoCSDL_Click(object sender, EventArgs e)
        {
        }

        private void btnXoaDuLieuDu_Click(object sender, EventArgs e)
        {
        }

    }
}
