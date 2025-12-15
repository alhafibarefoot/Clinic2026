using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.View;

public partial class ViewEmployeeBasicGosi
{
    public string EmployeeCode { get; set; } = null!;

    public string NameEn { get; set; } = null!;

    public string? LfGradeCode { get; set; }

    public string GradeNameEn { get; set; } = null!;

    public int? GradeStepNo { get; set; }

    public decimal? BasicSalary { get; set; }

    public decimal? SumAllowances { get; set; }

    public decimal? Gosi { get; set; }

    public string? LfDeductionCode { get; set; }

    public decimal? DeductionAmount { get; set; }
}
