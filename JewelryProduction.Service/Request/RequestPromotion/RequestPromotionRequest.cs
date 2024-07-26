namespace JewelryProduction.Service.Request.RequestPromotion
{
    public class RequestPromotionRequest
    {
        public Guid Id { get; set; }

        public Guid? CustomerId { get; set; }

        public Guid? CounterId { get; set; }

        public Guid? StaffId { get; set; }

        public string? Status { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string? CreateBy { get; set; }

        public string? UpdateBy { get; set; }

    }
}
