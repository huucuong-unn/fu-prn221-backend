using System;

namespace JewelryProduction.Service.Request.Product
{
    public class GetProductRequest
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Weight { get; set; }
        public Guid MaterialId { get; set; } //moithem
        public decimal Price { get; set; }
        public string? Status { get; set; } 
        public DateTime CreateDate { get; set; } 
        public DateTime? UpdateDate { get; set; } 
        public Guid? CounterId { get; set; }
        public Guid ProductTypeId { get; set; }
        public string ProductCode { get; set; }

        public List<Guid> StoneIds { get; set; } = new List<Guid>();

    }
}