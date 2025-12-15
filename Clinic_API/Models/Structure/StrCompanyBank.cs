using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.Structure;

public partial class StrCompanyBank
{
    public int Id { get; set; }

    public string BankCode { get; set; } = null!;

    public string LfDivisionCode { get; set; } = null!;

    public string LfBankCode { get; set; } = null!;

    public string? LfBankAccountTypeCode { get; set; }

    public string? LfCurrencyCode { get; set; }

    public string? LfAccountCode { get; set; }

    public string? BankAccountNo { get; set; }

    public string? BankIban { get; set; }

    public string? BankSwift { get; set; }

    public bool? IsCheckPrinting { get; set; }

    public bool? IsBankReconcilation { get; set; }

    public string? Note { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Ipaddress { get; set; }

    public bool? IsActive { get; set; }
}
