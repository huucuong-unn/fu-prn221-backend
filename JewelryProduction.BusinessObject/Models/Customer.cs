using System;
using System.Collections.Generic;

namespace JewelryProduction.BusinessObject.Models;

public partial class Customer
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Description { get; set; }

    public int? Point { get; set; }

    public string? Status { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? CreateBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public string? UpdateBy { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
