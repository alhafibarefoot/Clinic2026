using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.Entities;

public partial class TblAppointmentCategory
{
    public int CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public string? CategoryNameA { get; set; }

    public double? CatColor { get; set; }

    public string? CatHtml { get; set; }
}
