using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.Structure;

public partial class StrEmployeeInsurance
{
    public int Id { get; set; }

    public string LfEmployeeCode { get; set; } = null!;

    public string Cpr { get; set; } = null!;

    public string? LfInsuranceTypeCode { get; set; }

    public string? PolicyNo { get; set; }

    public string? InsuranceCardNo { get; set; }

    public DateTime? InsuranceCardStart { get; set; }

    public DateTime? InsuranceCardEnd { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Ipaddress { get; set; }

    public bool? IsActive { get; set; }
}
