using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.Finance;

public partial class FinSupplier
{
    public int Id { get; set; }

    public string SupplierCode { get; set; } = null!;

    public string? LfSupplierGroupCode { get; set; }

    public string? CprCr { get; set; }

    public string SupplierNameEn { get; set; } = null!;

    public string? SupplierNameAr { get; set; }

    public string? Address { get; set; }

    public string? LfCountryCode { get; set; }

    public string? ContactTelP { get; set; }

    public string? ContactMobilP { get; set; }

    public string? ContactMobilS { get; set; }

    public string? ContactEmailP { get; set; }

    public string? ContactEmailS { get; set; }

    public string? Pob { get; set; }

    public string? SupplierNote { get; set; }

    public int? DelayDaysLimit { get; set; }

    public decimal? CreditLimit { get; set; }

    public decimal? MaxDiscountRate { get; set; }

    public string? VatNumber { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Ipaddress { get; set; }

    public bool? IsActive { get; set; }

    public string? MigrateSupplierCode { get; set; }

    public virtual ICollection<FinSupplierLine> FinSupplierLines { get; set; } = new List<FinSupplierLine>();
}
