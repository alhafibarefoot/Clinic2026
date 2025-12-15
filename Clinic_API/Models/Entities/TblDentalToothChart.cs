using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.Entities;

public partial class TblDentalToothChart
{
    public int Id { get; set; }

    public int LfAppointmenttId { get; set; }

    public int ToothNumber { get; set; }

    public bool? DirectionSurfaceBuccal { get; set; }

    public bool? DirectionSurfaceMesial { get; set; }

    public bool? DirectionSurfaceLingual { get; set; }

    public bool? DirectionSurfaceOcclusal { get; set; }

    public bool? DirectionSurfaceDistal { get; set; }

    public bool? ExtendedFee { get; set; }

    public decimal? Fee { get; set; }

    public string? Condition { get; set; }

    public string? Notes { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Ipaddress { get; set; }

    public bool? IsActive { get; set; }
}
