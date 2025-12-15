using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.Lookup;

public partial class LtInsuranceCoverage
{
    public int Id { get; set; }

    public string LfInsuranceTypeCode { get; set; } = null!;

    public string LfInsuranceCoverageCode { get; set; } = null!;

    public bool? IsValid { get; set; }

    public decimal? CoveragePersentage { get; set; }

    public decimal? CoverageFee { get; set; }

    public string? Note { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Ipaddress { get; set; }

    public bool? IsActive { get; set; }
}
