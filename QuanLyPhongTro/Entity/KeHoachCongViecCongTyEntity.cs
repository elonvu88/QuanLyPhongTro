namespace MyWork.Entity
{
    public class KeHoachCongViecCongTyEntity
    {
        public int ID { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime StartTime { get; set; }
        public string Title { get; set; }
        public bool ShowOnHome { get; set; }
        public System.DateTime EndTime { get; set; }
        public int Type { get; set; }
        public int Status { get; set; }
    }
}
