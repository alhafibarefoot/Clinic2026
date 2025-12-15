using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.View;

public partial class ViewEmployeeDiffernaceAllowanceDefault
{
    public string LfEmployeeCode { get; set; } = null!;

    public string LfGradeCode { get; set; } = null!;

    public string LfAllowanceCode { get; set; } = null!;

    public decimal? DefaultAmount { get; set; }

    public decimal? AllowanceAmount { get; set; }

    public int Diff { get; set; }
}
