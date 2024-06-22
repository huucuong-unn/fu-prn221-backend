using System;
using System.Collections.Generic;

namespace JewelryProduction.BusinessObject.Models;

public partial class ProductStone
{
    public Guid ProductId { get; set; }

    public Guid StoneId { get; set; }

    public string CreateBy { get; set; } = null!;

    public string? UpdateBy { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public string? Status { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Stone Stone { get; set; } = null!;
}
