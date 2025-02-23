using System;
using System.Collections.Generic;

namespace TroskiSneakersBackEnd.Models;

public partial class PurchaseOrderHeader
{
    public int Id { get; set; }

    public int SupplierId { get; set; }

    public DateTime OrderDate { get; set; }

    public string? Status { get; set; }

    public decimal? Total { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public string? LastUpdatedBy { get; set; }

    public DateTime? LastUpdate { get; set; }

    public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; } = new List<PurchaseOrderLine>();

    public virtual Supplier Supplier { get; set; } = null!;
}
