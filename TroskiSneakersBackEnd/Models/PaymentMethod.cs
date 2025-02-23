using System;
using System.Collections.Generic;

namespace TroskiSneakersBackEnd.Models;

public partial class PaymentMethod
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public bool Active { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public string? LastUpdatedBy { get; set; }

    public DateTime? LastUpdate { get; set; }

    public virtual ICollection<SalesHeader> SalesHeaders { get; set; } = new List<SalesHeader>();
}
