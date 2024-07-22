using JewelryProduction.Service.Response.Counter;

namespace JewelryProduction.Service.Response.Order
{
    public class GetOrderReponse
    {
        public Guid? Id { get; set; }

        public Guid? CustomerId { get; set; }

        public Guid? PromotionId { get; set; }

        public decimal? TotalAmount { get; set; }

        public string? OrderType { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string? CreateBy { get; set; }

        public string? UpdateBy { get; set; }

        public string? Status { get; set; }

        public List<GetOrderItemResponse>? OrderItems { get; set; }

        public Guid? CounterId { get; set; }

        public BusinessObject.Models.Customer? Customer { get; set; }

    }
}
