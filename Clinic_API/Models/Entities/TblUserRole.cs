using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.Entities;

public partial class TblUserRole
{
    public int Id { get; set; }

    public string LfUserName { get; set; } = null!;

    public int LfRoleId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Ipaddress { get; set; }

    public bool? IsActive { get; set; }

    public virtual TblRole LfRole { get; set; } = null!;
}
