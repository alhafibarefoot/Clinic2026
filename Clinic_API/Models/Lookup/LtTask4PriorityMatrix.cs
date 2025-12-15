using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.Lookup;

public partial class LtTask4PriorityMatrix
{
    public int Id { get; set; }

    public string PriorityMatrixCode { get; set; } = null!;

    public int LfImpactId { get; set; }

    public int LfUrgencyId { get; set; }

    public int LfPriorityId { get; set; }

    public int? MatrixWeight { get; set; }

    public int PriorityRanking { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Ipaddress { get; set; }

    public bool? IsActive { get; set; }
}
