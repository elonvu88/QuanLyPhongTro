using DevExpress.Utils.Svg;
using DevExpress.XtraBars;
using MyWork.Common;
using MyWork.Data;
using System;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Windows.Forms;
using System.Xml;

namespace MyWork
{
    public partial class frmHome : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        bool isFormOpened = false;
        public frmHome()
        {
            InitializeComponent();
            this.KeyPreview = true;
            bsiAmDuongLich.Caption = string.Format("Hôm nay: {0} - {1} (AL)", DateTime.Now.ToString("dd/MM/yyyy"), AmDuongLich());
            bsiInfor.Caption = string.Format("Còn lại: {0}", DemSoNgayToiTet());
            bsiTramNgon.Caption = "Nếu không tìm cách kiếm tiền trong lúc ngủ, bạn sẽ phải làm việc tới khi chết.";
        }

        /// HomePage Load.
        private void frmHome_Load(object sender, EventArgs e)
        {
        }

        private void CheckAndUseConnectionString()
        {
        }

        /// Trang chủ
        private void bbiTrangChu_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        /// Mở khóa ứng dụng
        private void bbiMoKhoaUngDung_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        /// Cấu hình đầu tư.
        private void bbiCauHinhDauTu_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        /// Sao lưu cơ sở dữ liệu.
        private void bbiSaoLuuCoSoDuLieu_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        /// Đồng bộ dữ liệu.
        private void bbiDongBo_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        /// Đổi mật khẩu.
        private void bbiDoiMatKhau_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (checkFormOpen("frmAnhDaiDien") == false)
            {
                frmDoiMatKhau _frmDoiMatKhau = new frmDoiMatKhau();
                _frmDoiMatKhau.Show();
            }
        }

        /// Ảnh đại diện.
        private void bbiAnhDaiDien_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        /// Quản lý thời gian
        private void bbiQuanLyThoiGian_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        ///  File quan trọng
        private void bbiQuanLyFile_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        ///  Sổ Hạnh Phúc
        private void bbiSoHanhPhuc_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        /// Công việc cá nhân.
        private void bbiCongViecCaNhan_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        /// Quản lý tài khoản.
        private void bbiQuanLyTaiKhoan_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        /// Ngày Sinh/Mất.
        private void bbiNgaySinh_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        /// Bài viết cá nhân.
        private void bbiBaiVietCaNhan_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        /// Hanzii
        private void bbiHanzii_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        /// Tiền của bố mẹ.
        private void bbiTienCuaBoMe_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        /// Quỹ hiểu và thương.
        private void bbiQuyHieuVaThuong_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        /// Nhật ký
        private void bbiNhatKy_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        /// Sự kiện
        private void bbiSuKien_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        /// Thu/Chi.
        private void bbiThuChi_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        /// SMS.
        private void bbiSMS_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        // Wechat Message
        private void bbiWechat_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        /// Nuôi con.
        private void bbiNuoiCon_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        /// Bảo hiểm nhân thọ.
        private void bbiBaoHiemNhanTho_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        /// Cưới hỏi.
        private void bbiCuoiHoi_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        /// Quản lý nợ.
        private void bbiQuanLyNo_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (checkFormOpen("frmQuanLyNo") == false)
            {
                frmQuanLyNo _frmQuanLyNo = new frmQuanLyNo();
                _frmQuanLyNo.MdiParent = this;
                _frmQuanLyNo.Show();
            }
        }

        /// Quản lý chi tiêu.
        private void bbiQuanLyChiTieu_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (checkFormOpen("frmQuanLyChiTieu") == false)
            {
                frmQuanLyChiTieu _frmQuanLyChiTieu = new frmQuanLyChiTieu();
                _frmQuanLyChiTieu.MdiParent = this;
                _frmQuanLyChiTieu.Show();
            }
        }

        /// Quản lý Dòng tiền.
        private void bbiDongTien_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        /// Phương châm đầu tư.
        private void bbiBaiViet_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        /// Bài viết CK hàng ngày.
        private void bbiCKHangNgay_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        /// Cổ phiếu.
        private void bbiCoPhieu_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        /// Đầu tư.
        private void bbiDauTu_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        /// Công việc công ty.
        private void bbiCongViecCongTy_ItemClick(object sender, ItemClickEventArgs e)
        {
            //if (checkFormOpen("frmKHCVCongTy") == false)
            //{
            //    frmKHCVCongTy _frmKHCVCongTy = new frmKHCVCongTy();
            //    _frmKHCVCongTy.MdiParent = this;
            //    _frmKHCVCongTy.Show();
            //}
        }

        /// Test case.
        private void bbiTestCase_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        /// Ghi nhận lỗi.
        private void bbiLogBug_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        /// Trâm ngôn.
        private void bbiTramNgon_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        /// Giới thiệu phần mềm.
        private void bbiGioiThieuPhanMem_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        /// Khóa ứng dụng.
        private void btnKhoaUngDung_ItemClick(object sender, ItemClickEventArgs e)
        {
            LockApplication();
        }

        private void LockApplication()
        {
        }

        private bool checkFormOpen(string tenForm)
        {
            bool checkOpen = false;
            Form fc = System.Windows.Forms.Application.OpenForms[tenForm];
            if (fc != null)
            {
                checkOpen = true;
            }
            return checkOpen;
        }

        private string AmDuongLich()
        {
            LunarDate result = LunarYearTools.SolarToLunar(DateTime.Now, 7);
            return string.Format("{0}/{1}/{2}", result.Day, result.Month, result.Year);
        }

        /// Đếm số ngày tới tết
        private string DemSoNgayToiTet()
        {
            return "";
        }

        /// Quỹ cho Con
        private void bbiQuyChoCon_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        /// Quỹ khẩn cấp
        private void bbiQuyKhanCap_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void bbiTiengAnh_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        /// File công việc
        private void bbiFileCongViec_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void bbiLaiKep_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void bbiHieuSuatDauTu_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void bbiPhiDichVuCK_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void bbiFileTongHop_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void bbiHocCK_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void bbiBBCVCN_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void bbiBBCVCT_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void bbiHowSToday_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void frmHome_KeyDown(object sender, KeyEventArgs e)
        {
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                const int CS_NOCLOSE = 0x200;
                cp.ClassStyle |= CS_NOCLOSE; // Loại bỏ nút "X"
                return cp;
            }
        }
    }
}