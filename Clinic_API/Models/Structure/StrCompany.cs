using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.Structure;

public partial class StrCompany
{
    public int Id { get; set; }

    public string? LfParentCompanyCode { get; set; }

    public string CompanyCode { get; set; } = null!;

    public string NameEn { get; set; } = null!;

    public string? NameAr { get; set; }

    public string LfDivisionTypeCode { get; set; } = null!;

    public string? Address { get; set; }

    public string? Pobox { get; set; }

    public string? ContactPerson { get; set; }

    public string? ContactTelNo { get; set; }

    public string? ContactMobileNo { get; set; }

    public string? ContactFaxNo { get; set; }

    public string? ContactEmail { get; set; }

    public string? VatRegistrationNumber { get; set; }

    public DateTime? VarStartRegistrationDate { get; set; }

    public string? WebSite { get; set; }

    public string? LatLong { get; set; }

    public int? AllowedRange { get; set; }

    public byte[]? Logo { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Ipaddress { get; set; }

    public bool? IsActive { get; set; }
}
