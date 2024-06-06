namespace JewelryProduction.Service.Request.Counter
{
    public class GetCounterRequest
    {
        public string Name { get; set; }
        public decimal Income { get; set; }
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateBy { get; set; }
    }
}