using MyWork.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
using System.Net.Http.Headers;

namespace MyWork
{
    public static class Connection
    {
        public static int idDangNhap = 1;
        public static bool loginSuceess = true;

        // Giải mã RTF bằng cách gán giá trị cho RichTextBox ảo
        public static string DecodeRtf(string rtfText)
        {
            using (RichTextBox richTextBox = new RichTextBox())
            {
                richTextBox.Rtf = rtfText;
                // Lấy văn bản từ RichTextBox
                string plainText = richTextBox.Text;
                return plainText;
            }
        }

        /// Sinh mã random
        public static string genString()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[3];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var finalString = new String(stringChars);
            return finalString;
        }

        public static bool IsOdd(int value)
        {
            return value % 2 != 0;
        }
    }

    public class SecurityMethod
    {
        private static string keyCode = "27112022";
        public static string RandomString(int length)
        {
            string str = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            int strlen = str.Length;
            Random rnd = new Random();
            string retVal = String.Empty;
            for (int i = 0; i < length; i++)
            {
                retVal += str[rnd.Next(strlen)];
            }
            return retVal;
        }

        public static string MD5Encrypt(string plainText)
        {
            byte[] data, output;
            UTF8Encoding encoder = new UTF8Encoding();
            MD5CryptoServiceProvider hasher = new MD5CryptoServiceProvider();
            data = encoder.GetBytes(plainText);
            output = hasher.ComputeHash(data);
            return BitConverter.ToString(output).Replace("-", "").ToLower();
        }

        /// Mã hóa chuỗi có mật khẩu
        public static string Encrypt(string toEncrypt)
        {
            bool useHashing = true;
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(keyCode));
            }
            else
            {
                keyArray = UTF8Encoding.UTF8.GetBytes(keyCode);
            }
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        /// Giải mã
        public static string Decrypt(string toDecrypt)
        {
            bool useHashing = true;
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(keyCode));
            }
            else
            {
                keyArray = UTF8Encoding.UTF8.GetBytes(keyCode);
            }
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
    }

    public class TrangThai
    {
        public int ID { get; set; }
        public string TenTrangThai { get; set; }
    }

    public class NhomTaiKhoan
    {
        public int ID { get; set; }
        public string TenTaiKhoan { get; set; }
    }

    public class SanCK
    {
        public string TenSanCK { get; set; }
    }

    public class TyLeSanCK
    {
        public int TyLeSan { get; set; }
    }

    public class HowToday
    {
        public int ID { get; set; }
        public string TenTrangThai { get; set; }
    }

    public class AnHien
    {
        public string Ten { get; set; }
        public bool GiaTri { get; set; }
    }

    public class LayDuLieuDung
    {
        public string Ten { get; set; }
        public bool GiaTri { get; set; }
    }

    public class TGLayDuLieuCK
    {
        public int GiaTri { get; set; }
        public string ThoiGian { get; set; }
    }

    public class TrangThaiKH
    {
        public int ID { get; set; }
        public string TenTrangThai { get; set; }
    }

    public class DuLieuCoPhieu
    {
        public int ID { get; set; }
        public string GiaTri { get; set; }
    }

    public class NguoiTao
    {
        public int UserID { get; set; }
        public string DisplayName { get; set; }
    }

    public class LoaiGDCK
    {
        public string ID { get; set; }
        public string Loai { get; set; }
    }

    public class HinhThucTinhLaiKep
    {
        public int ID { get; set; }
        public string HinhThuc { get; set; }
    }

    public class DoiAmDuongLich
    {
        public int ID { get; set; }
        public string DoiNgay { get; set; }
    }

    public class DongBaoHiem
    {
        public string ID { get; set; }
        public string DongBHCho { get; set; }
    }

    public class PhuongThucDongBaoHiem
    {
        public string ID { get; set; }
        public string PhuongThuc { get; set; }
    }

    public class LoaiTramNgon
    {
        public int ID { get; set; }
        public string TenLoaiTramNgon { get; set; }
    }

    public class TrangThaiBug
    {
        public int ID { get; set; }
        public string TenTrangThai { get; set; }
    }

    public class LoaiLoiTest
    {
        public string ID { get; set; }
        public string LoaiLoi { get; set; }
    }

    public class TrangThaiTest
    {
        public int ID { get; set; }
        public string TenTrangThai { get; set; }
    }

    public class KetQuaTest
    {
        public string ID { get; set; }
        public string TenKetQua { get; set; }
    }

    public class TestType
    {
        public string ID { get; set; }
        public string TenTestType { get; set; }
    }

    public class LoaiThuChi
    {
        public int ID { get; set; }
        public string ThuChi { get; set; }
    }

    public class HienThiTrangChu
    {
        public int ID { get; set; }
        public string HienThi { get; set; }
    }

    public class TrangThaiDongTien
    {
        public int ID { get; set; }
        public string TrangThai { get; set; }
    }

    public class LoaiTaiSan
    {
        public int ID { get; set; }
        public string TaiSan { get; set; }
    }

    public class LoaiBaiViet
    {
        public string ID { get; set; }
        public string TenLoai { get; set; }
    }

    public class KichHoat
    {
        public int ID { get; set; }
        public string HoatDong { get; set; }
    }

    public class TrangThaiThuChi
    {
        public bool ID { get; set; }
        public string TenTrangThai { get; set; }
    }

    public class CbLoaiBaiViet
    {
        public string ID { get; set; }
        public string TenLoai { get; set; }
    }

    public class TrangThaiLoaiCongViec
    {
        public int ID { get; set; }
        public string TenLoaiCongViec { get; set; }
    }

    public class TrangThaiHoanThanh
    {
        public int ID { get; set; }
        public string TenTrangThai { get; set; }
    }

    public class LoaiDongBo
    {
        public string ID { get; set; }
        public string TenLoai { get; set; }
    }

    public class FileInfo
    {
        public int FileID { get; set; }
        public string FileName { get; set; }
        public byte[] FileData { get; set; }
    }
}
