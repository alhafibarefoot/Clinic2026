using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.Lookup;

public partial class LtCustomerGroupType
{
    public int Id { get; set; }

    public string CustomerGroupCode { get; set; } = null!;

    public string NameEn { get; set; } = null!;

    public string? NameAr { get; set; }

    public bool? IsDefault { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Ipaddress { get; set; }

    public bool? IsActive { get; set; }

    public string? LfAccountCode { get; set; }
}
