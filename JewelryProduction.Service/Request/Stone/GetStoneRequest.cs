namespace JewelryProduction.Service.Request.Stone
{
    public class GetStoneRequest
    {
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