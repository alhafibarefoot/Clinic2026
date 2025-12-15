using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.View;

public partial class ViewChartOfAccount
{
    public int? Id { get; set; }

    public string? ParentAccountCode { get; set; }

    public string? AccountCode { get; set; }

    public string? NameEn { get; set; }

    public string? NameAr { get; set; }

    public int? Level { get; set; }

    public string? Sorting { get; set; }

    public bool? IsTransaction { get; set; }

    public bool? IsActive { get; set; }
}
