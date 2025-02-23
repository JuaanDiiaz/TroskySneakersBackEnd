using System;
using System.Collections.Generic;

namespace TroskiSneakersBackEnd.Models;

public partial class PurchaseOrderLine
{
    public int Id { get; set; }

    public int PurchaseOrderHeaderId { get; set; }

    public int ProductId { get; set; }

    public decimal Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal Subtotal { get; set; }

    public virtual PurchaseOrderHeader PurchaseOrderHeader { get; set; } = null!;
}
