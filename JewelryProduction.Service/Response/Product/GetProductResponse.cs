using System;

namespace JewelryProduction.Service.Response.Product
{
    public class GetProductResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Weight { get; set; }
        public Guid? MaterialId { get; set; }
        public string? MaterialName { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public Guid ProductTypeId { get; set; }
        public string? ProductType { get; set; }
        public DateTime CreateDate { get; set; }  
        public DateTime UpdateDate { get; set; }    
        public Guid? CounterId { get; set; }
        public string? CounterName { get; set; }
        public string? ProductCode { get; set; }
    }
}