using System;
using System.Collections.Generic;

namespace JewelryProduction.BusinessObject.Models;

public partial class Counter
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public decimal? Income { get; set; }

    public string? Status { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? CreateBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public string? UpdateBy { get; set; }

    public virtual ICollection<UserCounter> UserCounters { get; set; } = new List<UserCounter>();
}
