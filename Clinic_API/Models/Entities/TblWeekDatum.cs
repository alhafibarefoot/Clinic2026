using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.Entities;

public partial class TblWeekDatum
{
    public int RowNo { get; set; }

    /// <summary>
    /// Time slots (00:00 - 23:30)
    /// </summary>
    public string? TimeSlots { get; set; }

    /// <summary>
    /// Days 1-10 used for tblAppointmentCategory data in Daily mode
    /// </summary>
    public string? Day1Data { get; set; }

    /// <summary>
    /// Days 1-10 used for tblAppointmentCategory data in Daily mode
    /// </summary>
    public string? Day2Data { get; set; }

    /// <summary>
    /// Days 1-10 used for tblAppointmentCategory data in Daily mode
    /// </summary>
    public string? Day3Data { get; set; }

    /// <summary>
    /// Days 1-10 used for tblAppointmentCategory data in Daily mode
    /// </summary>
    public string? Day4Data { get; set; }

    /// <summary>
    /// Days 1-10 used for tblAppointmentCategory data in Daily mode
    /// </summary>
    public string? Day5Data { get; set; }

    /// <summary>
    /// Days 1-10 used for tblAppointmentCategory data in Daily mode
    /// </summary>
    public string? Day6Data { get; set; }

    /// <summary>
    /// Days 1-10 used for tblAppointmentCategory data in Daily mode
    /// </summary>
    public string? Day7Data { get; set; }

    /// <summary>
    /// Days 1-10 used for tblAppointmentCategory data in Daily mode
    /// </summary>
    public string? Day8Data { get; set; }

    /// <summary>
    /// Days 1-10 used for tblAppointmentCategory data in Daily mode
    /// </summary>
    public string? Day9Data { get; set; }

    /// <summary>
    /// Days 1-10 used for tblAppointmentCategory data in Daily mode
    /// </summary>
    public string? Day10Data { get; set; }
}
