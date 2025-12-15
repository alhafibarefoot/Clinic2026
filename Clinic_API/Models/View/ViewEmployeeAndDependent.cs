using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.View;

public partial class ViewEmployeeAndDependent
{
    public string EmployeeCode { get; set; } = null!;

    public string? Cpr { get; set; }

    public string NameEn { get; set; } = null!;

    public string? NameAr { get; set; }

    public string? LfGradeCode { get; set; }

    public bool? IsActive { get; set; }

    public int? Age { get; set; }
}
