using System;
using System.Collections.Generic;

namespace JewelryProduction.BusinessObject.Models;

public partial class Material
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal BuyingPrice { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public decimal? SalePrice { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
