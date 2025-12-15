using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.Structure;

public partial class StrEmployeeDependant
{
    public int Id { get; set; }

    public string LfEmployeeCode { get; set; } = null!;

    public string Cpr { get; set; } = null!;

    public string NameEn { get; set; } = null!;

    public string? NameAr { get; set; }

    public string LfRelationShipCode { get; set; } = null!;

    public string LfCountryNationalityCode { get; set; } = null!;

    public string? LfGenderCode { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string? PrimaryMobile { get; set; }

    public bool? IsVisaCost { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Ipaddress { get; set; }

    public bool? IsActive { get; set; }
}
