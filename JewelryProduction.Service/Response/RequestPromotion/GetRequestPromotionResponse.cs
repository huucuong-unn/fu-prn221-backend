namespace JewelryProduction.Service.Response.RequestPromotion
{
    public class GetRequestPromotionResponse
    {
        public Guid Id { get; set; }

        public string? CustomerName { get; set; }

        public string? CounterName { get; set; }

        public string? StaffName { get; set; }

        public string? Status { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string? CreateBy { get; set; }

        public string? UpdateBy { get; set; }
    }
}
