using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.Finance;

public partial class FinPatient
{
    public int Id { get; set; }

    public string PatientCode { get; set; } = null!;

    public string? LfCustomerGroupCode { get; set; }

    public string? Employer { get; set; }

    public string? Cpr { get; set; }

    public string NameEn { get; set; } = null!;

    public string? NameAr { get; set; }

    public string? LfCountryCodeNationality { get; set; }

    public string? Address { get; set; }

    public string? ContactTelP { get; set; }

    public string? ContactMobilP { get; set; }

    public string? ContactMobilS { get; set; }

    public string? ContactEmailP { get; set; }

    public string? ContactEmailS { get; set; }

    public string? Pob { get; set; }

    public string? PatientNote { get; set; }

    public int? DelayDaysLimit { get; set; }

    public double? DebitLimit { get; set; }

    public decimal? MaxDiscountRate { get; set; }

    public string? VatNumber { get; set; }

    public string? LfJobTitleCode { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? PassportNo { get; set; }

    public string? LfGenderCode { get; set; }

    public string? LfBloodCode { get; set; }

    public decimal? Weight { get; set; }

    public decimal? Height { get; set; }

    public string? MigratePatientCode { get; set; }

    public byte[]? Photo { get; set; }

    public byte[]? Qr { get; set; }

    public bool? IsVip { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Ipaddress { get; set; }

    public bool? IsActive { get; set; }

    public string? LfInsuranceCustomerCode { get; set; }

    public string? PolicyNo { get; set; }

    public DateTime? PolicyStartDate { get; set; }

    public DateTime? PolicyEndDate { get; set; }

    public decimal? ServiceCoveragePersentage { get; set; }

    public decimal? ConsultationCoverageFee { get; set; }

    public string? MigratePatientCustomerCode { get; set; }

    public virtual ICollection<FinPatientLine> FinPatientLines { get; set; } = new List<FinPatientLine>();
}
