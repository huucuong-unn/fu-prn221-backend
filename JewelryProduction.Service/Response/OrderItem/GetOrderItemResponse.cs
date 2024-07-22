using JewelryProduction.Service.Response.Product;

namespace JewelryProduction.Service.Response.Counter
{
    public class GetOrderItemResponse
    {
        public Guid Id { get; set; }

        public Guid OrderId { get; set; }

        public GetProductResponse Product { get; set; }

        public Guid WarrantyId { get; set; }

        public decimal TotalAmount { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string? CreateBy { get; set; }

        public string? UpdateBy { get; set; }

        public string Status { get; set; }


    }
}