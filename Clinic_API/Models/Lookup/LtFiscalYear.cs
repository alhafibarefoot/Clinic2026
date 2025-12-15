using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.Lookup;

public partial class LtFiscalYear
{
    public int Id { get; set; }

    public string FiscalYearCode { get; set; } = null!;

    public string FiscalYearName { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public bool? IsClosed { get; set; }

    public int? YearCode { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Ipaddress { get; set; }

    public bool? IsActive { get; set; }

    public int? LastSerialNo { get; set; }

    public byte? PadLeftNo { get; set; }
}
