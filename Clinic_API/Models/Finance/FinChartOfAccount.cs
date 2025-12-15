using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.Finance;

public partial class FinChartOfAccount
{
    public int Id { get; set; }

    public string LfCompanyCode { get; set; } = null!;

    public string? ParentAccountCode { get; set; }

    public string AccountCode { get; set; } = null!;

    public int? AccountLevel { get; set; }

    public string? AccountNature { get; set; }

    public string NameEn { get; set; } = null!;

    public string? NameAr { get; set; }

    public string? MigrateAccountCode { get; set; }

    public bool? IsTransaction { get; set; }

    public double? Sorting { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Ipaddress { get; set; }

    public bool? IsActive { get; set; }
}
