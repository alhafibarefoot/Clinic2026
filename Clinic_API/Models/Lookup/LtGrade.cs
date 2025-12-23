using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.Lookup;

public partial class LtGrade
{
    public int Id { get; set; }

    public string LfGradeTypeCode { get; set; } = null!;

    public string GradeCode { get; set; } = null!;

    public string NameEn { get; set; } = null!;

    public string? NameAr { get; set; }

    public decimal? Regular0 { get; set; }

    public decimal? Regular1 { get; set; }

    public decimal? Regular2 { get; set; }

    public decimal? Regular3 { get; set; }

    public decimal? Regular4 { get; set; }

    public decimal? Regular5 { get; set; }

    public decimal? Regular6 { get; set; }

    public decimal? Regular7 { get; set; }

    public decimal? Regular8 { get; set; }

    public decimal? Regular9 { get; set; }

    public decimal? Regular10 { get; set; }

    public decimal? Regular11 { get; set; }

    public decimal? Regular12 { get; set; }

    public decimal? Regular13 { get; set; }

    public decimal? Regular14 { get; set; }

    public decimal? Regular15 { get; set; }

    public decimal? Shift0 { get; set; }

    public decimal? Shift1 { get; set; }

    public decimal? Shift2 { get; set; }

    public decimal? Shift3 { get; set; }

    public decimal? Shift4 { get; set; }

    public decimal? Shift5 { get; set; }

    public decimal? Shift6 { get; set; }

    public decimal? Shift7 { get; set; }

    public decimal? Shift8 { get; set; }

    public decimal? Shift9 { get; set; }

    public decimal? Shift10 { get; set; }

    public decimal? Shift11 { get; set; }

    public decimal? Shift12 { get; set; }

    public decimal? Shift13 { get; set; }

    public decimal? Shift14 { get; set; }

    public decimal? Shift15 { get; set; }

    public decimal? HourBase { get; set; }

    public decimal? OverTimeRegular { get; set; }

    public decimal? OverTimeVacation { get; set; }

    public int? StartStep { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Ipaddress { get; set; }

    public bool? IsActive { get; set; }
}
