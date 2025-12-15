using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.Lookup;

public partial class LtProductServiceMeasurement
{
    public int Id { get; set; }

    public string MeasuremntCode { get; set; } = null!;

    public string MeasurementBreif { get; set; } = null!;

    public string MeasurementType { get; set; } = null!;

    public string NameEn { get; set; } = null!;

    public string NameAr { get; set; } = null!;

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Ipaddress { get; set; }

    public bool? IsActive { get; set; }
}
