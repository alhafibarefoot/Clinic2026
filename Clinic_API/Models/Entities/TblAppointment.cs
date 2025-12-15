using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.Entities;

public partial class TblAppointment
{
    public int ApptId { get; set; }

    /// <summary>
    /// Linked to STR_Employee(ID)
    /// </summary>
    public int? EmployeeId { get; set; }

    /// <summary>
    /// Linked to tblAppointmentCategory (ID)
    /// </summary>
    public int? CategoryId { get; set; }

    /// <summary>
    /// Appointment subject /patient Name (required)
    /// </summary>
    public string ApptSubject { get; set; } = null!;

    /// <summary>
    /// Appointment Location (Optional)
    /// </summary>
    public string? ApptLocation { get; set; }

    /// <summary>
    /// Appointment start date and time (required)
    /// </summary>
    public DateTime ApptStart { get; set; }

    /// <summary>
    /// Appointment end date and time (required)
    /// </summary>
    public DateTime ApptEnd { get; set; }

    /// <summary>
    /// Appointment miscellaneous notes (optional)
    /// </summary>
    public string? ApptNotes { get; set; }

    /// <summary>
    /// = True for All Day Event
    /// </summary>
    public bool? AllDayEvent { get; set; }

    /// <summary>
    /// Holds unique value for each group of recurring appointments
    /// </summary>
    public int? RecurrenceId { get; set; }

    /// <summary>
    /// Recurrence pattern codes
    /// </summary>
    public string? Pattern { get; set; }

    public string? LfPatientCode { get; set; }

    public string? LfCompanyLocationCode { get; set; }
}
