using System;
using System.Collections.Generic;

namespace JewelryProduction.BusinessObject.Models;

public partial class Request
{
    public Guid Id { get; set; }

    public Guid? CustomerId { get; set; }

    public Guid? CounterId { get; set; }

    public Guid? StaffId { get; set; }

    public string? Status { get; set; }
}
