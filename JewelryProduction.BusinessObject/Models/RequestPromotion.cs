using System;
using System.Collections.Generic;

namespace JewelryProduction.BusinessObject.Models;

public partial class RequestPromotion
{
    public Guid Id { get; set; }

    public Guid? CustomerId { get; set; }

    public Guid? CounterId { get; set; }

    public Guid? StaffId { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? CreateBy { get; set; }

    public string? UpdateBy { get; set; }
}
