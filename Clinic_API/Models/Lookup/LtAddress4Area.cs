using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.Lookup;

public partial class LtAddress4Area
{
    public int Id { get; set; }

    public string LfRegionCode { get; set; } = null!;

    public string AreaCode { get; set; } = null!;

    public int BlockNo { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Ipaddress { get; set; }

    public bool? IsActive { get; set; }
}
