using System;
using System.Collections.Generic;

namespace JewelryProduction.BusinessObject.Models;

public partial class Product
{
    public Guid Id { get; set; }

    public Guid ProductTypeId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Weight { get; set; }

    public string Material { get; set; } = null!;

    public decimal Price { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime UpdateDate { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<ProductStone> ProductStones { get; set; } = new List<ProductStone>();

    public virtual ProductType ProductType { get; set; } = null!;
}
