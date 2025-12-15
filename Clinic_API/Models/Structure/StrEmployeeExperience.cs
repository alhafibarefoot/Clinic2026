using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.Structure;

public partial class StrEmployeeExperience
{
    public int Id { get; set; }

    public string LfEmployeeCode { get; set; } = null!;

    public string JobTitle { get; set; } = null!;

    public string LfCountryCode { get; set; } = null!;

    public string OrginizationSource { get; set; } = null!;

    public string? FunctionalTasks { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? AttachmentFileName { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Ipaddress { get; set; }

    public bool? IsActive { get; set; }
}
