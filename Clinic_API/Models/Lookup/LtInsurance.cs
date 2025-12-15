using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.Lookup;

public partial class LtInsurance
{
    public int Id { get; set; }

    public string InsuranceTypeCode { get; set; } = null!;

    public string NameEn { get; set; } = null!;

    public string? NameAr { get; set; }

    public byte? AgeLimit { get; set; }

    public byte? WifeLimit { get; set; }

    public byte? ChildLimit { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Ipaddress { get; set; }

    public bool? IsActive { get; set; }
}
