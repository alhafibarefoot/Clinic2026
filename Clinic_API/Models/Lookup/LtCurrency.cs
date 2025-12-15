using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.Lookup;

public partial class LtCurrency
{
    public int Id { get; set; }

    public string CurrencyCode { get; set; } = null!;

    public string CurrencyName { get; set; } = null!;

    public string CurrencyCode1 { get; set; } = null!;

    public decimal? ExchangeRate { get; set; }

    public bool? IsDefault { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Ipaddress { get; set; }

    public bool? IsActive { get; set; }
}
