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

    public double? Regular0 { get; set; }

    public double? Regular1 { get; set; }

    public double? Regular2 { get; set; }

    public double? Regular3 { get; set; }

    public double? Regular4 { get; set; }

    public double? Regular5 { get; set; }

    public double? Regular6 { get; set; }

    public double? Regular7 { get; set; }

    public double? Regular8 { get; set; }

    public double? Regular9 { get; set; }

    public double? Regular10 { get; set; }

    public double? Regular11 { get; set; }

    public double? Regular12 { get; set; }

    public double? Regular13 { get; set; }

    public double? Regular14 { get; set; }

    public double? Regular15 { get; set; }

    public double? Shift0 { get; set; }

    public double? Shift1 { get; set; }

    public double? Shift2 { get; set; }

    public double? Shift3 { get; set; }

    public double? Shift4 { get; set; }

    public double? Shift5 { get; set; }

    public double? Shift6 { get; set; }

    public double? Shift7 { get; set; }

    public double? Shift8 { get; set; }

    public double? Shift9 { get; set; }

    public double? Shift10 { get; set; }

    public double? Shift11 { get; set; }

    public double? Shift12 { get; set; }

    public double? Shift13 { get; set; }

    public double? Shift14 { get; set; }

    public double? Shift15 { get; set; }

    public double? HourBase { get; set; }

    public double? OverTimeRegular { get; set; }

    public double? OverTimeVacation { get; set; }

    public int? StartStep { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Ipaddress { get; set; }

    public bool? IsActive { get; set; }
}
