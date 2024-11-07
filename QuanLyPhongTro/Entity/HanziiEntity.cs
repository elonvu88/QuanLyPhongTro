using System;

namespace MyWork.Entity
{
    public class HanziiEntity
    {
        public int ID { get; set; }
        public string TiengTrung { get; set; }
        public string ChuPhonThe { get; set; }
        public string LoaiTu { get; set; }
        public string PhienAm { get; set; }
        public string TuGanNghia { get; set; }
        public string TuTraiNghia { get; set; }
        public string CauChuyen { get; set; }
        public string DichCauChuyen { get; set; }
        public string HanViet { get; set; }
        public string TiengViet { get; set; }
        public string CumTuPhoiHop { get; set; }
        public string GhiChu { get; set; }
        public string ViDu { get; set; }
        public int CreateBy { get; set; }
        public Nullable<int> NguonLayDuLieu { get; set; }
    }
}
