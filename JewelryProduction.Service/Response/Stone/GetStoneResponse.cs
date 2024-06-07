namespace JewelryProduction.Service.Response.Stone
{
    public class GetStoneResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string StoneType { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateBy { get; set; }
    }
}