using System;
using System.Collections.Generic;

namespace Clinic2026_API.Models.Inventory;

public partial class InvStock1Item
{
    public int Id { get; set; }

    public string ProductCode { get; set; } = null!;

    public string NameEn { get; set; } = null!;

    public string? NameAr { get; set; }

    public string LfSupplierCode { get; set; } = null!;

    public string? ProductCodeBySupplier { get; set; }

    public string LfBrandCode { get; set; } = null!;

    public string ProductNameBySupplier { get; set; } = null!;

    public string LfCategoryCode { get; set; } = null!;

    public string LfSeasonCode { get; set; } = null!;

    public string LfCollectionCode { get; set; } = null!;

    public string LfExitCode { get; set; } = null!;

    public string LfMeasurementCode { get; set; } = null!;

    public string? LfTaxCode { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Ipaddress { get; set; }

    public bool? IsActive { get; set; }

    public bool? ManuallyAdded { get; set; }
}
