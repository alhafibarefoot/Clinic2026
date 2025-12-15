using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.TimeAttendance;

public partial class TimeAttendancePattern
{
    public int Id { get; set; }

    public string PatternCode { get; set; } = null!;

    public string NameEn { get; set; } = null!;

    public string? NameAr { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public DateTime? SundayTimeIn { get; set; }

    public DateTime? SundayTimeout { get; set; }

    public DateTime? SundayBeakTimeIn { get; set; }

    public DateTime? SundayBreakTimeOut { get; set; }

    public DateTime? SundayEarlyAllowance { get; set; }

    public DateTime? SundayExitAllowance { get; set; }

    public DateTime? MondayTimeIn { get; set; }

    public DateTime? MondayTimeout { get; set; }

    public DateTime? MondayBeakTimeIn { get; set; }

    public DateTime? MondayBreakTimeOut { get; set; }

    public DateTime? MondayEarlyAllowance { get; set; }

    public DateTime? MondayExitAllowance { get; set; }

    public DateTime? TuesdayTimeIn { get; set; }

    public DateTime? TuesdayTimeout { get; set; }

    public DateTime? TuesdayBeakTimeIn { get; set; }

    public DateTime? TuesdayBreakTimeOut { get; set; }

    public DateTime? TuesdayEarlyAllowance { get; set; }

    public DateTime? TuesdayExitAllowance { get; set; }

    public DateTime? WednesdayTimeIn { get; set; }

    public DateTime? WednesdayTimeout { get; set; }

    public DateTime? WednesdayBeakTimeIn { get; set; }

    public DateTime? WednesdayBreakTimeOut { get; set; }

    public DateTime? WednesdayEarlyAllowance { get; set; }

    public DateTime? WednesdayExitAllowance { get; set; }

    public DateTime? ThursdayTimeIn { get; set; }

    public DateTime? ThursdayTimeout { get; set; }

    public DateTime? ThursdayBeakTimeIn { get; set; }

    public DateTime? ThursdayBreakTimeOut { get; set; }

    public DateTime? ThursdayEarlyAllowance { get; set; }

    public DateTime? ThursdayExitAllowance { get; set; }

    public DateTime? FridayTimeIn { get; set; }

    public DateTime? FridayTimeout { get; set; }

    public DateTime? FridayBeakTimeIn { get; set; }

    public DateTime? FridayBreakTimeOut { get; set; }

    public DateTime? FridayEarlyAllowance { get; set; }

    public DateTime? FridayExitAllowance { get; set; }

    public DateTime? SaturdayTimeIn { get; set; }

    public DateTime? SaturdayTimeout { get; set; }

    public DateTime? SaturdayBeakTimeIn { get; set; }

    public DateTime? SaturdayBreakTimeOut { get; set; }

    public DateTime? SaturdayEarlyAllowance { get; set; }

    public DateTime? SaturdayExitAllowanceMin { get; set; }

    public bool? IsLongShift { get; set; }

    public bool? IsIncludWeekEndLeave { get; set; }

    public bool? IsIncludeVacationLeave { get; set; }

    public DateTime? OverTimeShift1Start { get; set; }

    public DateTime? OverTimeShift1End { get; set; }

    public DateTime? OverTimeShift2Start { get; set; }

    public DateTime? OverTimeShift2End { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Ipaddress { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? TimeInerval { get; set; }
}
