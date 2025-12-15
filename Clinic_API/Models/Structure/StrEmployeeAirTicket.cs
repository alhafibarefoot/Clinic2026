using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.Structure;

public partial class StrEmployeeAirTicket
{
    public int Id { get; set; }

    public string LfEmployeeCode { get; set; } = null!;

    public string Cpr { get; set; } = null!;

    public string? LfCountrySectorCode { get; set; }

    public string? LfPeriodCode { get; set; }

    public byte? InEveryPeriod { get; set; }

    public byte? DeserveTicket { get; set; }

    public double? CompensationValue { get; set; }

    public double? CompensationPersentage { get; set; }

    public string? AllowanceMonth { get; set; }

    public DateTime? EffectiveDateStart { get; set; }

    public byte? OpenTicket { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Ipaddress { get; set; }

    public bool? IsActive { get; set; }
}
