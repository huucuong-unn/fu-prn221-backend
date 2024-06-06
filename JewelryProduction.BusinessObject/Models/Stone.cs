using System;
using System.Collections.Generic;

namespace JewelryProduction.BusinessObject.Models;

public partial class Stone
{
    public Guid Id { get; set; }

    public string? StoneType { get; set; }

    public string? Name { get; set; }

    public decimal? Price { get; set; }

    public string? Status { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? CreateBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public string? UpdateBy { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    
    public virtual ICollection<ProductStone> ProductStones { get; set; } = new List<ProductStone>();
}
