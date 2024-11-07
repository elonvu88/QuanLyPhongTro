
namespace MyWork.Entity
{
    public class SoHanhPhucEntity
    {
        public int ID { get; set; }
        public string TieuDe { get; set; }
        public string KeHoach { get; set; }
        public string HanhPhuc { get; set; }
        public string HoanThien { get; set; }
        public string GioiGiang { get; set; }
        public string SuyNiem { get; set; }
        public bool ShowOnHome { get; set; }
        public System.DateTime CreateDate { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public int CreateBy { get; set; }
    }
}
