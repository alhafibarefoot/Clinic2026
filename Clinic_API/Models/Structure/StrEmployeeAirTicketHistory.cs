using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.Structure;

public partial class StrEmployeeAirTicketHistory
{
    public int Id { get; set; }

    public string LfEmployeeCode { get; set; } = null!;

    public string Cpr { get; set; } = null!;

    public string? LfCountrySectorCode { get; set; }

    public decimal? ActualValue { get; set; }

    public decimal? CompensationValue { get; set; }

    public decimal? CompensationPersentage { get; set; }

    public DateTime? DateTaken { get; set; }

    public DateTime? DateReturn { get; set; }

    public string? Note { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Ipaddress { get; set; }

    public bool? IsActive { get; set; }
}
