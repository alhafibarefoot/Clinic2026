using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.View;

public partial class ViewMenuPermission
{
    public int RoleId { get; set; }

    public int MenuId { get; set; }

    public bool? ViewF { get; set; }

    public bool? AddF { get; set; }

    public bool? EditF { get; set; }

    public bool? DeleteF { get; set; }

    public bool? ExportF { get; set; }

    public bool? UploadF { get; set; }

    public bool? DownLoadF { get; set; }

    public bool? SearchF { get; set; }

    public bool? PrintF { get; set; }

    public int? LfParentMenuId { get; set; }

    public decimal? MenuSortOrder { get; set; }
}
