using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.Finance;

public partial class FinPatientLine
{
    public int Id { get; set; }

    public string LfDivisionCode { get; set; } = null!;

    public string LfPatientCode { get; set; } = null!;

    public decimal? OpenBalanceDebit { get; set; }

    public decimal? OpenBalanceCredit { get; set; }

    public decimal? OpenBalance { get; set; }

    public decimal? CurrentBalanceDebit { get; set; }

    public decimal? CurrentBalanceCredit { get; set; }

    public decimal? CurrentBalance { get; set; }

    public string? LfLoyaltyCardCode { get; set; }

    public string? LoyaltyCardNo { get; set; }

    public DateTime? LoyaltyCardIssueDate { get; set; }

    public DateTime? LoyaltyCardExpiryDate { get; set; }

    public decimal? LoyaltyCardPointsOpenBalance { get; set; }

    public decimal? LoyaltyCardsCurrentUsedPoints { get; set; }

    public decimal? LoyaltyCardsAdjustPoints { get; set; }

    public decimal? LoyaltyCardsCurrentEarnedPoints { get; set; }

    public decimal? LoyaltyCardsCurrentRedeemedPoints { get; set; }

    public decimal? LoyaltyCardsCurrentCancelledPoints { get; set; }

    public decimal? LoyaltyCardPointsCurrentBalance { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Ipaddress { get; set; }

    public bool? IsActive { get; set; }

    public virtual FinPatient LfPatientCodeNavigation { get; set; } = null!;
}
