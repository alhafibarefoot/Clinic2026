using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.Lookup;

public partial class LtAddress1Country
{
    public int Id { get; set; }

    public string CountryCode { get; set; } = null!;

    public string NameEn { get; set; } = null!;

    public string? NameAr { get; set; }

    public string? Capital { get; set; }

    public string? NationalityEn { get; set; }

    public string? NationalityAr { get; set; }

    public bool? IsGcc { get; set; }

    public int? Iacocode { get; set; }

    public string? Alpha2Code { get; set; }

    public string? Alpha3Code { get; set; }

    public string? LfZoneCode { get; set; }

    public string? DialCode { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Ipaddress { get; set; }

    public bool? IsActive { get; set; }
}
