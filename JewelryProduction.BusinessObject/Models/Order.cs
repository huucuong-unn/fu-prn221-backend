using System;
using System.Collections.Generic;

namespace JewelryProduction.BusinessObject.Models;

public partial class Order
{
    public Guid Id { get; set; }

    public Guid? CustomerId { get; set; }

    public Guid? PromotionId { get; set; }

    public decimal? TotalAmount { get; set; }

    public string? OrderType { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? CreateBy { get; set; }

    public string? UpdateBy { get; set; }

    public string? Status { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
