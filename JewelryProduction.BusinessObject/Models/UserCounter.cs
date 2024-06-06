using System;
using System.Collections.Generic;

namespace JewelryProduction.BusinessObject.Models;

public partial class UserCounter
{
    public Guid StaffId { get; set; }

    public Guid CounterId { get; set; }

    public string? Status { get; set; }

    public virtual User Staff { get; set; } = null!;
}
