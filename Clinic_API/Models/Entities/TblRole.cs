using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.Entities;

public partial class TblRole
{
    public int Id { get; set; }

    public string RoleEn { get; set; } = null!;

    public string RoleAr { get; set; } = null!;

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Ipaddress { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<SmMenuPermission> SmMenuPermissions { get; set; } = new List<SmMenuPermission>();

    public virtual ICollection<TblUserRole> TblUserRoles { get; set; } = new List<TblUserRole>();
}
