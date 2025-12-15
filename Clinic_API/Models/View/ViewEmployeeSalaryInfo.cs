using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.View;

public partial class ViewEmployeeSalaryInfo
{
    public string EmployeeCode { get; set; } = null!;

    public string? Cpr { get; set; }

    public string NameEn { get; set; } = null!;

    public string NameAr { get; set; } = null!;

    public string GradeNameEn { get; set; } = null!;

    public string JobTitle { get; set; } = null!;

    public string? LfGradeCode { get; set; }

    public int? GradeStepNo { get; set; }

    public decimal? BasicSalary { get; set; }

    public byte[]? Photo { get; set; }

    public bool? IsActive { get; set; }
}
