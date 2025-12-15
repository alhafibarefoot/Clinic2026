using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.TimeAttendance;

public partial class TimeAttendanceLeaveType
{
    public int Id { get; set; }

    public string LeaveTypeCode { get; set; } = null!;

    public string NameEn { get; set; } = null!;

    public string? NameAr { get; set; }

    public int? YearlyLeavesInDays { get; set; }

    public bool? IsCarryFarward { get; set; }

    public int? CarryFarwardLimitinDay { get; set; }

    public int? NextAllowanceByDay { get; set; }

    public bool? IsPayable { get; set; }

    public byte? RecuringTimeAccepted { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Ipaddress { get; set; }

    public bool? IsActive { get; set; }
}
