using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.Finance;

public partial class FinCustomer
{
    public int Id { get; set; }

    public string CustomerCode { get; set; } = null!;

    public string? LfCustomerGroupCode { get; set; }

    public string? CprCr { get; set; }

    public string CustomerNameEn { get; set; } = null!;

    public string? CustomerNameAr { get; set; }

    public string? Address { get; set; }

    public string? LfCountryCode { get; set; }

    public string? ContactTelP { get; set; }

    public string? ContactMobilP { get; set; }

    public string? ContactMobilS { get; set; }

    public string? ContactEmailP { get; set; }

    public string? ContactEmailS { get; set; }

    public string? Pob { get; set; }

    public string? CustomerNote { get; set; }

    public int? DelayDaysLimit { get; set; }

    public double? DebitLimit { get; set; }

    public decimal? MaxDiscountRate { get; set; }

    public string? VatNumber { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Ipaddress { get; set; }

    public bool? IsActive { get; set; }

    public string? MigrateCustomerCode { get; set; }

    public virtual ICollection<FinCustomerLine> FinCustomerLines { get; set; } = new List<FinCustomerLine>();
}
