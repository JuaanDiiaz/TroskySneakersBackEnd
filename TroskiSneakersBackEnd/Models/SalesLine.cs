using System;
using System.Collections.Generic;

namespace TroskiSneakersBackEnd.Models;

public partial class SalesLine
{
    public int Id { get; set; }

    public int SalesHeaderId { get; set; }

    public int ProductId { get; set; }

    public decimal Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal Subtotal { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual SalesHeader SalesHeader { get; set; } = null!;
}
