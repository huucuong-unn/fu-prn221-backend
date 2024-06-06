using System;
using System.Collections.Generic;

namespace JewelryProduction.BusinessObject.Models;

public partial class OrderItem
{
    public Guid Id { get; set; }

    public Guid? OrderId { get; set; }

    public Guid? ProductId { get; set; }

    public Guid? WarrantyId { get; set; }

    public decimal? TotalAmount { get; set; }

    public int? Quantity { get; set; }

    public decimal? UnitPrice { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? CreateBy { get; set; }

    public string? UpdateBy { get; set; }

    public string? Status { get; set; }

    public virtual Order? Order { get; set; }
}
