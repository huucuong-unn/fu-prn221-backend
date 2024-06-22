using System;
using System.Collections.Generic;

namespace JewelryProduction.BusinessObject.Models;

public partial class Promotion
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string CreateBy { get; set; } = null!;

    public DateTime UpdateDate { get; set; }

    public string UpdateBy { get; set; } = null!;

    public decimal Value { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
