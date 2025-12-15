using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.System;

public partial class SmMenu
{
    public int Id { get; set; }

    public int? LfParentMenuId { get; set; }

    public string NameEn { get; set; } = null!;

    public string? NameAr { get; set; }

    public decimal? MenuSortOrder { get; set; }

    public int? Type { get; set; }

    public string? Form { get; set; }

    public string? Report { get; set; }

    public string? Macro { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Ipaddress { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<SmMenuPermission> SmMenuPermissions { get; set; } = new List<SmMenuPermission>();
}
