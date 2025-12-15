using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.View;

public partial class ViewUsersMenuPermission
{
    public string LfUserName { get; set; } = null!;

    public int? LfRoleId { get; set; }

    public int LfMenuId { get; set; }

    public string NameEn { get; set; } = null!;

    public string? NameAr { get; set; }

    public bool? IsActive { get; set; }

    public int? ViewF { get; set; }

    public int? AddF { get; set; }

    public int? EditF { get; set; }

    public int? DeleteF { get; set; }

    public int? ExportF { get; set; }

    public int? UploadF { get; set; }

    public int? DownloadF { get; set; }

    public int? SearchF { get; set; }

    public int? PrintF { get; set; }

    public int? HirarSorting { get; set; }

    public int? MenuLevel { get; set; }

    public decimal? MenuSortOrder { get; set; }
}
