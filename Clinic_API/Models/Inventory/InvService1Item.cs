using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.Inventory;

public partial class InvService1Item
{
    public int Id { get; set; }

    public string LfCategoryCode { get; set; } = null!;

    public string ProductCode { get; set; } = null!;

    public string NameEn { get; set; } = null!;

    public string? NameAr { get; set; }

    public decimal? SalePriceFee { get; set; }

    public byte? ServiceDurationMinutes { get; set; }

    public decimal? SalePriceExtendedFee { get; set; }

    public byte? ServiceExtendedDurationMinutes { get; set; }

    public string? LfTaxCode { get; set; }

    public decimal? CostPriceFee { get; set; }

    public decimal? CostPriceExtendedFee { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Ipaddress { get; set; }

    public bool? IsActive { get; set; }

    public bool? SalePriceFeeIncludeVat { get; set; }

    public bool? SalePriceExtendFeeIncludeVat { get; set; }

    public int? MigrateCode { get; set; }

    public double? Sorting { get; set; }
}
