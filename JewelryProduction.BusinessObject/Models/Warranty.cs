using System;
using System.Collections.Generic;

namespace JewelryProduction.BusinessObject.Models;

public partial class Warranty
{
    public Guid WarrantyProductId { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public string? Description { get; set; }

    public string? Status { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? CreateBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public string? UpdateBy { get; set; }

    public virtual Product WarrantyProduct { get; set; } = null!;
}
