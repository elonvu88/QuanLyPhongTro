using System;

namespace MyWork.Entity
{
    public class TiengAnhEntity
    {
        public int ID { get; set; }
        public string TuTiengAnh { get; set; }
        public string LoaiTu { get; set; }
        public string PhienAm { get; set; }
        public string TiengViet { get; set; }
        public string ViDu { get; set; }
        public string GhiChu { get; set; }
        public Nullable<int> CreateBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<System.DateTime> SynDate { get; set; }
        public Nullable<bool> SynStatus { get; set; }
    }
}
