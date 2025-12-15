using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.Structure;

public partial class StrEmployeeDeduction
{
    public int Id { get; set; }

    public string LfEmployeeCode { get; set; } = null!;

    public string LfGradeCode { get; set; } = null!;

    public string LfDeductionCode { get; set; } = null!;

    public decimal? DeductionAmount { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Note { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Ipaddress { get; set; }

    public bool? IsActive { get; set; }
}
