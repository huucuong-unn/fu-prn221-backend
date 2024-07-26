using System;
using System.Collections.Generic;

namespace JewelryProduction.BusinessObject.Models;

public partial class Counter
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Income { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string CreateBy { get; set; } = null!;

    public DateTime UpdateDate { get; set; }

    public string UpdateBy { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<RequestPromotion> RequestPromotions { get; set; } = new List<RequestPromotion>();

    public virtual ICollection<UserCounter> UserCounters { get; set; } = new List<UserCounter>();
}
