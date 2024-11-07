using System.Numerics;

namespace MyWork.Common
{
    /// Đọc số sang chữ
    public class NumberToWordsConverter
    {
        private static readonly string[] UnitsMap = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
        private static readonly string[] TensMap = { "mười", "mười một", "mười hai", "mười ba", "mười bốn", "mười lăm", "mười sáu", "mười bảy", "mười tám", "mười chín" };
        private static readonly string[] TensUnitsMap = { "mười", "hai mươi", "ba mươi", "bốn mươi", "năm mươi", "sáu mươi", "bảy mươi", "tám mươi", "chín mươi" };

        public static string NumberToWords(BigInteger number)
        {
            if (number == 0)
                return "không";

            if (number < 0)
                return "âm " + NumberToWords(BigInteger.Abs(number));

            string words = "";

            // Định dạng chuỗi số thành các nhóm ba chữ số, cách nhau bằng dấu phẩy
            string formattedNumber = number.ToString("#,##0");
            string[] groups = formattedNumber.Split(',');

            int groupCounter = groups.Length - 1;
            foreach (string group in groups)
            {
                if (string.IsNullOrEmpty(group))
                {
                    groupCounter--;
                    continue;
                }

                int threeDigitBlock = int.Parse(group);
                string blockWords = NumberToWordsHelper(threeDigitBlock);

                if (!string.IsNullOrWhiteSpace(blockWords))
                {
                    words += blockWords + " " + GetUnit(groupCounter) + " ";
                }

                groupCounter--;
            }

            return words.Trim();
        }

        private static string NumberToWordsHelper(int number)
        {
            if (number == 0)
                return "";

            if (number < 10)
                return UnitsMap[number];

            if (number < 20)
                return TensMap[number - 10];

            if (number < 100)
                return TensUnitsMap[number / 10 - 1] + (number % 10 > 0 ? " " + UnitsMap[number % 10] : "");

            if (number < 1000)
                return UnitsMap[number / 100] + " trăm " + (number % 100 > 0 ? NumberToWordsHelper(number % 100) : "");

            return "";
        }

        private static string GetUnit(int index)
        {
            switch (index)
            {
                case 1: return "nghìn";
                case 2: return "triệu";
                case 3: return "tỷ";
                case 4: return "nghìn tỷ";
                case 5: return "triệu tỷ";
                case 6: return "tỷ tỷ";
                default: return "";
            }
        }
    }
}
