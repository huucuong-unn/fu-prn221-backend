namespace JewelryProduction.Service.Response.ProductStone
{
    public class GetProductStoneResponse
    {
        public Guid ProductId { get; set; }

        public Guid StoneId { get; set; }

        public string CreateBy { get; set; } = null!;

        public string UpdateBy { get; set; } = null!;

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public string Status { get; set; } = null!;
    }
}