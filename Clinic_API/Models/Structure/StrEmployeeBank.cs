using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.Structure;

public partial class StrEmployeeBank
{
    public int Id { get; set; }

    public string LfEmployeeCode { get; set; } = null!;

    public string LfBankCode { get; set; } = null!;

    public string Iban { get; set; } = null!;

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Ipaddress { get; set; }

    public bool? IsActive { get; set; }
}
