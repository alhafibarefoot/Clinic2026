using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.Structure;

public partial class StrCompanyDivision
{
    public int Id { get; set; }

    public string LfCompanyCode { get; set; } = null!;

    public string? LfParentDivisionCode { get; set; }

    public string DivisionCode { get; set; } = null!;

    public string NameEn { get; set; } = null!;

    public string? NameAr { get; set; }

    public string LfDivisionTypeCode { get; set; } = null!;

    public string? LfEmployeeCode { get; set; }

    public bool? IsCostCenter { get; set; }

    public string? LfAccountCode { get; set; }

    public bool? IsStore { get; set; }

    public bool? IsPos { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Ipaddress { get; set; }

    public bool? IsActive { get; set; }

    public string? VatRegistrationNumber { get; set; }

    public string? ReportHeader { get; set; }

    public string? ReportFooter { get; set; }

    public byte[]? Logo { get; set; }
}
