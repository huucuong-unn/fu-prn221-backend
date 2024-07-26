using System;
using System.Collections.Generic;

namespace JewelryProduction.BusinessObject.Models;

public partial class User
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Role { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public decimal? Income { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? CreateBy { get; set; }

    public string? UpdateBy { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<RequestPromotion> RequestPromotions { get; set; } = new List<RequestPromotion>();

    public virtual ICollection<UserCounter> UserCounters { get; set; } = new List<UserCounter>();
}
