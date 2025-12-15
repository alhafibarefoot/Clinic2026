using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.Entities;

public partial class TblMonthDatum
{
    public int RowNo { get; set; }

    /// <summary>
    /// Week number (1-52)
    /// </summary>
    public DateTime? WeekNo { get; set; }

    /// <summary>
    /// Day cells data (1-7)
    /// </summary>
    public string? Day1Data { get; set; }

    /// <summary>
    /// Day cells data (1-7)
    /// </summary>
    public string? Day2Data { get; set; }

    /// <summary>
    /// Day cells data (1-7)
    /// </summary>
    public string? Day3Data { get; set; }

    /// <summary>
    /// Day cells data (1-7)
    /// </summary>
    public string? Day4Data { get; set; }

    /// <summary>
    /// Day cells data (1-7)
    /// </summary>
    public string? Day5Data { get; set; }

    /// <summary>
    /// Day cells data (1-7)
    /// </summary>
    public string? Day6Data { get; set; }

    /// <summary>
    /// Day cells data (1-7)
    /// </summary>
    public string? Day7Data { get; set; }

    /// <summary>
    /// Day cells date (1-7)
    /// </summary>
    public string? Day1Date { get; set; }

    /// <summary>
    /// Day cells date (1-7)
    /// </summary>
    public string? Day2Date { get; set; }

    /// <summary>
    /// Day cells date (1-7)
    /// </summary>
    public string? Day3Date { get; set; }

    /// <summary>
    /// Day cells date (1-7)
    /// </summary>
    public string? Day4Date { get; set; }

    /// <summary>
    /// Day cells date (1-7)
    /// </summary>
    public string? Day5Date { get; set; }

    /// <summary>
    /// Day cells date (1-7)
    /// </summary>
    public string? Day6Date { get; set; }

    /// <summary>
    /// Day cells date (1-7)
    /// </summary>
    public string? Day7Date { get; set; }

    public string? HideDay { get; set; }
}
