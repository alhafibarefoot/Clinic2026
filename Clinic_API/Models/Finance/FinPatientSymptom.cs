using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.Finance;

public partial class FinPatientSymptom
{
    public int Id { get; set; }

    public string LfPatientCode { get; set; } = null!;

    public string LfSymptomsCode { get; set; } = null!;

    public string? PatientNote { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Ipaddress { get; set; }

    public bool? IsActive { get; set; }
}
