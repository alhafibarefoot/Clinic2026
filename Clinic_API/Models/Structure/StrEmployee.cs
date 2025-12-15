using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.Structure;

public partial class StrEmployee
{
    public int EmployeeId { get; set; }

    public string LfCompanyCode { get; set; } = null!;

    public string? LfDivisionCode { get; set; }

    public string? LfEmployeeCodeManager { get; set; }

    public string EmployeeCode { get; set; } = null!;

    public string? Cpr { get; set; }

    public string? LfAbbreviationCode { get; set; }

    public string NameEn { get; set; } = null!;

    public string NameAr { get; set; } = null!;

    public string? LfJobTitleCode { get; set; }

    public string? LfCompanyLocationCode { get; set; }

    public string? LfContractTypeCode { get; set; }

    public string? LfCountryCodeNationality { get; set; }

    public string? LfGenderCode { get; set; }

    public string? LfBloodCode { get; set; }

    public string? LfSocialStatusCode { get; set; }

    public string? LfRelegionCode { get; set; }

    public string? LfGradeCode { get; set; }

    public int? GradeStepNo { get; set; }

    public string? OfficialEmail { get; set; }

    public string? PersonalEmail { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? PlaceOfBirth { get; set; }

    public string? Address { get; set; }

    public string? OfficeTelephone { get; set; }

    public string? PrimaryMobile { get; set; }

    public string? SecondaryMobile { get; set; }

    public DateTime? DateEmployemnt { get; set; }

    public DateTime? DateStartService { get; set; }

    public DateTime? DateContractStart { get; set; }

    public DateTime? DateContractEnd { get; set; }

    public DateTime? DateContractRenew { get; set; }

    public DateTime? DateDiscontinued { get; set; }

    public string? DiscontinuedReason { get; set; }

    public string? LfDiscontinuedCode { get; set; }

    public string? GosiNumber { get; set; }

    public DateTime? GosiRegistrationDate { get; set; }

    public DateTime? GosiRenwalDate { get; set; }

    public DateTime? GosiDiscontinuedDate { get; set; }

    public DateTime? StopTillDate { get; set; }

    public string? StopReason { get; set; }

    public string? LfPorbationPeriodCode { get; set; }

    public int? PorbationPeriod { get; set; }

    public string? LfNoticePeriodCode { get; set; }

    public int? NoticePeriod { get; set; }

    public DateTime? GratuityIndemnityEntitlementSdate { get; set; }

    public DateTime? GratuityIndemnityEntitlementEdate { get; set; }

    public string? LfPaymentMethodCode { get; set; }

    public string? LfPaymentPeriodCode { get; set; }

    public int? PaymentStart { get; set; }

    public int? PaymentEnd { get; set; }

    public string? LfCurrencyCode { get; set; }

    public string? LfPattern { get; set; }

    public string? AccessCardNo { get; set; }

    public bool? AccessCardIsActive { get; set; }

    public byte[]? Photo { get; set; }

    public byte[]? Qr { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Ipaddress { get; set; }

    public bool? IsActive { get; set; }

    public string? LfEmployeeCodeDelegator { get; set; }

    public bool? IsHeathCareAppointment { get; set; }
}
