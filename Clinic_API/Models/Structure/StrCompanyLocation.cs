using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.Structure;

public partial class StrCompanyLocation
{
    public int Id { get; set; }

    public string LfDivisionCode { get; set; } = null!;

    public string LocationCode { get; set; } = null!;

    public string Floor { get; set; } = null!;

    public string Place { get; set; } = null!;

    public string? OfficeNo { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Ipaddress { get; set; }

    public bool? IsActive { get; set; }
}
