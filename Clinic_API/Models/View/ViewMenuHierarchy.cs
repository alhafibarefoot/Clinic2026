using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.View;

public partial class ViewMenuHierarchy
{
    public int? Id { get; set; }

    public int? ParentId { get; set; }

    public string? NameEn { get; set; }

    public string? NameAr { get; set; }

    public int? Sorting { get; set; }

    public int? MenuLevel { get; set; }

    public bool? IsActive { get; set; }
}
