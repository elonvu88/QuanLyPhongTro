using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyWork.Common
{
    public class EncryptionHelper
    {
        // Khóa mã hóa/giải mã
        private static string GetEncryptionKey()
        {
            // Khóa 32 ký tự cho AES-256
            var keyVaultName = "5Fv8#x2Z9@E6nD7!R3q1P#M4bL&2jCz";
            return keyVaultName; // Trả về giá trị của khóa mã hóa
        }

        private static bool GetEncryptionKeyOpen(string key)
        {
            bool result = false;
            var keyVaultName = "020693";
            if (key == keyVaultName)
            {
                result = true;
            }
            return result; // Trả về giá trị của khóa mã hóa
        }

        // Hàm mã hóa
        public static string Encrypt(string plainText)
        {
            string encryptionKey = GetEncryptionKey(); // Lấy khóa từ Key Vault
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] iv; // Biến để lưu IV ngẫu nhiên

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(encryptionKey);

                // Tạo IV ngẫu nhiên
                aes.GenerateIV();
                iv = aes.IV; // Lưu IV

                using (MemoryStream ms = new MemoryStream())
                {
                    // Ghi IV vào đầu chuỗi mã hóa
                    ms.Write(iv, 0, iv.Length);

                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(plainBytes, 0, plainBytes.Length);
                        cs.Close();
                    }
                    return Convert.ToBase64String(ms.ToArray()); // Trả về chuỗi đã mã hóa
                }
            }
        }

        // Hàm giải mã
        public static string Decrypt(string cipherText)
        {
            string encryptionKey = GetEncryptionKey(); // Lấy khóa từ Key Vault
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            byte[] iv = new byte[16]; // IV phải có độ dài 16 byte

            // Lấy IV từ chuỗi mã hóa
            Array.Copy(cipherBytes, 0, iv, 0, iv.Length);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(encryptionKey);
                aes.IV = iv; // Gán IV từ chuỗi mã hóa

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        // Ghi dữ liệu mã hóa (bỏ qua IV)
                        cs.Write(cipherBytes, iv.Length, cipherBytes.Length - iv.Length);
                        cs.Close();
                    }
                    return Encoding.UTF8.GetString(ms.ToArray()); // Trả về chuỗi văn bản gốc
                }
            }
        }
    }
}
