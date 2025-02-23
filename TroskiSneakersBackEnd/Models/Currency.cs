using System;
using System.Collections.Generic;

namespace TroskiSneakersBackEnd.Models;

public partial class Currency
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string? Name { get; set; }

    public string? Symbol { get; set; }

    public decimal ExchangeRate { get; set; }

    public bool IsBaseCurrency { get; set; }

    public bool IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public string? LastUpdatedBy { get; set; }

    public DateTime? LastUpdate { get; set; }
}
