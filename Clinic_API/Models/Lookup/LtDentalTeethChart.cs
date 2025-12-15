using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.Lookup;

public partial class LtDentalTeethChart
{
    public int Id { get; set; }

    public int ToothId { get; set; }

    public byte[]? ToothImage { get; set; }

    public int? ToothFda { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Ipaddress { get; set; }

    public bool? IsActive { get; set; }
}
