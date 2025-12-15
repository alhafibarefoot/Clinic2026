using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.Lookup;

public partial class LtBank
{
    public int Id { get; set; }

    public string BankCode { get; set; } = null!;

    public string BreifName { get; set; } = null!;

    public string NameEn { get; set; } = null!;

    public string? NameAr { get; set; }

    public string? Address { get; set; }

    public string? ContactPersonP { get; set; }

    public string? ContactPersonS { get; set; }

    public string? ContactTelP { get; set; }

    public string? ContactTelS { get; set; }

    public string? ContactFaxP { get; set; }

    public string? ContactFaxS { get; set; }

    public string? ContactMobilP { get; set; }

    public string? ContactMobilS { get; set; }

    public string? ContactEmailP { get; set; }

    public string? ContactEmailS { get; set; }

    public string? WebSite { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Ipaddress { get; set; }

    public bool? IsActive { get; set; }
}
