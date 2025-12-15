using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.Entities;

public partial class TblCalendarSetting
{
    /// <summary>
    /// = 0 - 3 to select which calendar to open on start up.
    /// </summary>
    public short? OpenCalendar { get; set; }

    /// <summary>
    /// Duration of appointments in minutes (5, 10, 15 or 30 minutes only)
    /// </summary>
    public short ApptDuration { get; set; }

    /// <summary>
    /// First time slot displayed on weekly and daily calendars
    /// </summary>
    public DateTime? ApptFirstTimeSlot { get; set; }

    /// <summary>
    /// Last time slot displayed on weekly and daily calendars
    /// </summary>
    public DateTime? ApptLastTimeSlot { get; set; }

    /// <summary>
    /// Starting time for Weekly and Daily calendars
    /// </summary>
    public DateTime? StartTime { get; set; }

    /// <summary>
    /// =Yes for 24 hour clock or 12 Hour clock on Weekly &amp; Daily calendars
    /// </summary>
    public bool? ClockType { get; set; }

    /// <summary>
    /// =Yes to show time in every time slot on Weekly/Daily calendar, = No to show time in alternate time slots
    /// </summary>
    public bool? AlterTimes { get; set; }

    /// <summary>
    /// =False to allow multiple appts for a time slot, set to True to show error message if user tries to enter appt for used time slot
    /// </summary>
    public bool? MultiAppts { get; set; }

    /// <summary>
    /// =False to display calendar using &apos;Find Appt&apos; option, set to True to open &apos;Appointment Schedule&apos; form when appt found
    /// </summary>
    public bool? OpenAppt { get; set; }

    /// <summary>
    /// =True to show Public Holiday Dates on calendars in red
    /// </summary>
    public bool? ShowPublicHols { get; set; }

    /// <summary>
    /// =vbSunday to vbSaturday to determine which day shows as the first day of the week
    /// </summary>
    public short? FirstDayOfWeek { get; set; }

    /// <summary>
    /// =1 to 4 to show the number of weekday characters on Month headers on Yearly calendar
    /// </summary>
    public short? WeekdayLength { get; set; }

    /// <summary>
    /// =True to display appts on greyed out dates on overlapping months
    /// </summary>
    public bool? MonthHide { get; set; }

    /// <summary>
    /// =Set to True to show &quot; char in subsequent rows
    /// </summary>
    public bool? Ditto { get; set; }

    /// <summary>
    /// =True to show the Start Time on calendars
    /// </summary>
    public bool? ShowStart { get; set; }

    /// <summary>
    /// =True to show the Start and End Time on calendars
    /// </summary>
    public bool? ShowStartEnd { get; set; }

    /// <summary>
    /// =True to show the Subject field on calendars
    /// </summary>
    public bool? ShowSubject { get; set; }

    /// <summary>
    /// =True to show the Location field on calendars
    /// </summary>
    public bool? ShowLocation { get; set; }
}
