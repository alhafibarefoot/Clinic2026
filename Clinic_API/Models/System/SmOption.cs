using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.System;

public partial class SmOption
{
    public int Id { get; set; }

    public string CriteriaName { get; set; } = null!;

    public string CriteriaValue { get; set; } = null!;
}
