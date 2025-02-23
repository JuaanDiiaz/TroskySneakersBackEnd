using System;
using System.Collections.Generic;

namespace TroskiSneakersBackEnd.Models;

public partial class SalesHeader
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public DateTime SaleDate { get; set; }

    public decimal Total { get; set; }

    public int PaymentMethodId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public string? LastUpdatedBy { get; set; }

    public DateTime? LastUpdate { get; set; }

    public virtual PaymentMethod PaymentMethod { get; set; } = null!;

    public virtual ICollection<SalesLine> SalesLines { get; set; } = new List<SalesLine>();
}
