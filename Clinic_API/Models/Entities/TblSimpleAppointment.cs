using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.Entities;

public partial class TblSimpleAppointment
{
    public int InputId { get; set; }

    public DateTime InputDate { get; set; }

    public string InputText { get; set; } = null!;
}
