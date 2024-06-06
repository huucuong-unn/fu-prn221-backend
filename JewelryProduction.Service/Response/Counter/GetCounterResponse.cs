namespace JewelryProduction.Service.Response.Counter
{
    public class GetCounterResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Income { get; set; }
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateBy { get; set; }
    }
}