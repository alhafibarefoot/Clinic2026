using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.View;

public partial class ViewEmployeeHierarchy
{
    public string? EmployeeCode { get; set; }

    public string? OfficialEmail { get; set; }

    public string? LfEmployeeCodeManager { get; set; }

    public string? ManagerEmail { get; set; }

    public string? LfEmployeeCodeDelegator { get; set; }

    public string? DelegatorEmail { get; set; }

    public string? NameEn { get; set; }

    public int? Level { get; set; }

    public string? ConnectionEmployeeCode { get; set; }

    public bool? IsActive { get; set; }
}
