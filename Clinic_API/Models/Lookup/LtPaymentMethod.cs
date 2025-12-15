using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.Lookup;

public partial class LtPaymentMethod
{
    public int Id { get; set; }

    public string PaymentMethodCode { get; set; } = null!;

    public string NameEn { get; set; } = null!;

    public string? NameAr { get; set; }

    public bool? IsCreditCard { get; set; }

    public bool? IsLoyalityCard { get; set; }

    public decimal? HotPoint { get; set; }

    public short? ValidityPeriodDay { get; set; }

    public byte[]? PaymentTypeLogo { get; set; }

    public string? LfAccountCode { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Ipaddress { get; set; }

    public bool? IsActive { get; set; }
}
