
namespace MyWork.Entity
{
    public class KeHoachCongViecCaNhanEntity
    {
        public int ID { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
        public string Title { get; set; }
        public bool ShowOnHome { get; set; }
        public int Type { get; set; }
        public short FileNumber { get; set; }
        public int Status { get; set; }
    }
}
