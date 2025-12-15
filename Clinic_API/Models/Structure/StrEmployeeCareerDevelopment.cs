using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.Structure;

public partial class StrEmployeeCareerDevelopment
{
    public int Id { get; set; }

    public DateTime CareerDevelopmentDate { get; set; }

    public string LfEmployeeCode { get; set; } = null!;

    public string LfGradeCode { get; set; } = null!;

    public byte GradeStep { get; set; }

    public decimal? BasicSalary { get; set; }

    public decimal? Social { get; set; }

    public decimal? Transportation { get; set; }

    public decimal? Car { get; set; }

    public decimal? Tel { get; set; }

    public decimal? Living { get; set; }

    public decimal? House { get; set; }

    public decimal? Differnace { get; set; }

    public string? Note { get; set; }

    public string? AttachmentFileName { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Ipaddress { get; set; }

    public bool? IsActive { get; set; }
}
