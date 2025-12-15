using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.Finance;

public partial class FinSupplierLine
{
    public int Id { get; set; }

    public string LfDivisionCode { get; set; } = null!;

    public string LfSupplierCode { get; set; } = null!;

    public decimal? OpenBalanceDebit { get; set; }

    public decimal? OpenBalanceCredit { get; set; }

    public decimal? OpenBalance { get; set; }

    public decimal? CurrentBalanceDebit { get; set; }

    public decimal? CurrentBalanceCredit { get; set; }

    public decimal? CurrentBalance { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Ipaddress { get; set; }

    public bool? IsActive { get; set; }

    public virtual FinSupplier LfSupplierCodeNavigation { get; set; } = null!;
}
