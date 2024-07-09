namespace JewelryProduction.Service.Request.Promotions
{
    public class BasePromotionRequest
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public string? Status { get; set; }

        public DateTime? CreateDate { get; set; }

        public string? CreateBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string? UpdateBy { get; set; }

        public decimal Value { get; set; }
    }
}
