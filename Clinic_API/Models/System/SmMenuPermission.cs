using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.System;

public partial class SmMenuPermission
{
    public int Id { get; set; }

    public int LfRoleId { get; set; }

    public int LfMenuId { get; set; }

    public bool? ViewF { get; set; }

    public bool? AddF { get; set; }

    public bool? EditF { get; set; }

    public bool? DeleteF { get; set; }

    public bool? ExportF { get; set; }

    public bool? UploadF { get; set; }

    public bool? DownLoadF { get; set; }

    public bool? SearchF { get; set; }

    public bool? PrintF { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Ipaddress { get; set; }

    public bool? IsActive { get; set; }

    public virtual SmMenu LfMenu { get; set; } = null!;

    public virtual TblRole LfRole { get; set; } = null!;
}
