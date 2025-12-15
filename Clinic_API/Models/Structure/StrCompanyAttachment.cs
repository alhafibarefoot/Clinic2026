using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.Structure;

public partial class StrCompanyAttachment
{
    public int Id { get; set; }

    public string LfCompanyCode { get; set; } = null!;

    public string LfAttachmentTypeCode { get; set; } = null!;

    public string AttchmentFileName { get; set; } = null!;

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Ipaddress { get; set; }

    public bool? IsActive { get; set; }
}
