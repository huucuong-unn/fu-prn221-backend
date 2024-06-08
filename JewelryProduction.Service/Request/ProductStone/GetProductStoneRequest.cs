namespace JewelryProduction.Service.Request.ProductStone
{
    public class GetProductStoneRequest
    {
        public Guid ProductId { get; set; }
        public Guid StoneId { get; set; }
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateBy { get; set; }
    }
}