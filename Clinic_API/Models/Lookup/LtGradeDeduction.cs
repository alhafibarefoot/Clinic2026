using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.Lookup;

public partial class LtGradeDeduction
{
    public int Id { get; set; }

    public string LfGradeCode { get; set; } = null!;

    public string LfDeductionCode { get; set; } = null!;

    public double? DefaultAmount { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Ipaddress { get; set; }

    public bool? IsActive { get; set; }
}
