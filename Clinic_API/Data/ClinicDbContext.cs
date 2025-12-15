using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Clinic2026_API.Data;

using Clinic2026_API.Models.Entities;
using Clinic2026_API.Models.Finance;
using Clinic2026_API.Models.Lookup;
using Clinic2026_API.Models.Inventory;
using Clinic2026_API.Models.System;
using Clinic2026_API.Models.Structure;
using Clinic2026_API.Models.View;
using Clinic2026_API.Models.TimeAttendance;

public partial class ClinicDbContext : DbContext
{
    public ClinicDbContext()
    {
    }

    public ClinicDbContext(DbContextOptions<ClinicDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<FinChartOfAccount> FinChartOfAccounts { get; set; }

    public virtual DbSet<FinChartOfAccountLine> FinChartOfAccountLines { get; set; }

    public virtual DbSet<FinCustomer> FinCustomers { get; set; }

    public virtual DbSet<FinCustomerLine> FinCustomerLines { get; set; }

    public virtual DbSet<FinPatient> FinPatients { get; set; }

    public virtual DbSet<FinPatientAllergy> FinPatientAllergies { get; set; }

    public virtual DbSet<FinPatientDiagnosis> FinPatientDiagnoses { get; set; }

    public virtual DbSet<FinPatientLine> FinPatientLines { get; set; }

    public virtual DbSet<FinPatientSymptom> FinPatientSymptoms { get; set; }

    public virtual DbSet<FinSupplier> FinSuppliers { get; set; }

    public virtual DbSet<FinSupplierLine> FinSupplierLines { get; set; }

    public virtual DbSet<InvService1Item> InvService1Items { get; set; }

    public virtual DbSet<InvStock1Item> InvStock1Items { get; set; }

    public virtual DbSet<LtAbbreviation> LtAbbreviations { get; set; }

    public virtual DbSet<LtAccountingDocumentType> LtAccountingDocumentTypes { get; set; }

    public virtual DbSet<LtAcountMapping> LtAcountMappings { get; set; }

    public virtual DbSet<LtAddress0Continent> LtAddress0Continents { get; set; }

    public virtual DbSet<LtAddress0Zone> LtAddress0Zones { get; set; }

    public virtual DbSet<LtAddress1Country> LtAddress1Countries { get; set; }

    public virtual DbSet<LtAddress2Governorate> LtAddress2Governorates { get; set; }

    public virtual DbSet<LtAddress3Region> LtAddress3Regions { get; set; }

    public virtual DbSet<LtAddress4Area> LtAddress4Areas { get; set; }

    public virtual DbSet<LtAddress5Road> LtAddress5Roads { get; set; }

    public virtual DbSet<LtAgeCategory> LtAgeCategories { get; set; }

    public virtual DbSet<LtAllowance> LtAllowances { get; set; }

    public virtual DbSet<LtAssetStatus> LtAssetStatuses { get; set; }

    public virtual DbSet<LtAssetWrokLog> LtAssetWrokLogs { get; set; }

    public virtual DbSet<LtAttacmentType> LtAttacmentTypes { get; set; }

    public virtual DbSet<LtBank> LtBanks { get; set; }

    public virtual DbSet<LtBankAccountType> LtBankAccountTypes { get; set; }

    public virtual DbSet<LtBlood> LtBloods { get; set; }

    public virtual DbSet<LtCompanyOwner> LtCompanyOwners { get; set; }

    public virtual DbSet<LtContractType> LtContractTypes { get; set; }

    public virtual DbSet<LtCurrency> LtCurrencies { get; set; }

    public virtual DbSet<LtCustomerGroupType> LtCustomerGroupTypes { get; set; }

    public virtual DbSet<LtDeduction> LtDeductions { get; set; }

    public virtual DbSet<LtDentalTeethChart> LtDentalTeethCharts { get; set; }

    public virtual DbSet<LtDiscontinuedType> LtDiscontinuedTypes { get; set; }

    public virtual DbSet<LtDivisionType> LtDivisionTypes { get; set; }

    public virtual DbSet<LtEducation1Resource> LtEducation1Resources { get; set; }

    public virtual DbSet<LtEducation2Level> LtEducation2Levels { get; set; }

    public virtual DbSet<LtFileScreenAction> LtFileScreenActions { get; set; }

    public virtual DbSet<LtFiscalYear> LtFiscalYears { get; set; }

    public virtual DbSet<LtGender> LtGenders { get; set; }

    public virtual DbSet<LtGrade> LtGrades { get; set; }

    public virtual DbSet<LtGradeAllowance> LtGradeAllowances { get; set; }

    public virtual DbSet<LtGradeDeduction> LtGradeDeductions { get; set; }

    public virtual DbSet<LtGradeType> LtGradeTypes { get; set; }

    public virtual DbSet<LtIcon> LtIcons { get; set; }

    public virtual DbSet<LtInsurance> LtInsurances { get; set; }

    public virtual DbSet<LtInsuranceCoverage> LtInsuranceCoverages { get; set; }

    public virtual DbSet<LtInsuranceHealthCoverage> LtInsuranceHealthCoverages { get; set; }

    public virtual DbSet<LtJobTitle> LtJobTitles { get; set; }

    public virtual DbSet<LtLanguage> LtLanguages { get; set; }

    public virtual DbSet<LtLookupTableReferance> LtLookupTableReferances { get; set; }

    public virtual DbSet<LtMedicalAllergy> LtMedicalAllergies { get; set; }

    public virtual DbSet<LtMedicalDiagnosis> LtMedicalDiagnoses { get; set; }

    public virtual DbSet<LtMedicalPatientPain> LtMedicalPatientPains { get; set; }

    public virtual DbSet<LtMedicalSpecialty> LtMedicalSpecialties { get; set; }

    public virtual DbSet<LtMedicalSymptom> LtMedicalSymptoms { get; set; }

    public virtual DbSet<LtMedicalTreatment> LtMedicalTreatments { get; set; }

    public virtual DbSet<LtPaymentMethod> LtPaymentMethods { get; set; }

    public virtual DbSet<LtPeriod> LtPeriods { get; set; }

    public virtual DbSet<LtProductServiceBrand> LtProductServiceBrands { get; set; }

    public virtual DbSet<LtProductServiceCategory> LtProductServiceCategories { get; set; }

    public virtual DbSet<LtProductServiceClassification> LtProductServiceClassifications { get; set; }

    public virtual DbSet<LtProductServiceMeasurement> LtProductServiceMeasurements { get; set; }

    public virtual DbSet<LtProject> LtProjects { get; set; }

    public virtual DbSet<LtPurchaseStatus> LtPurchaseStatuses { get; set; }

    public virtual DbSet<LtRelationShip> LtRelationShips { get; set; }

    public virtual DbSet<LtRelegion> LtRelegions { get; set; }

    public virtual DbSet<LtRequest1Type> LtRequest1Types { get; set; }

    public virtual DbSet<LtRequest2Channal> LtRequest2Channals { get; set; }

    public virtual DbSet<LtReward> LtRewards { get; set; }

    public virtual DbSet<LtShippingMethod> LtShippingMethods { get; set; }

    public virtual DbSet<LtShippingTerm> LtShippingTerms { get; set; }

    public virtual DbSet<LtSocialStatus> LtSocialStatuses { get; set; }

    public virtual DbSet<LtSupplierGroupType> LtSupplierGroupTypes { get; set; }

    public virtual DbSet<LtTask1Impact> LtTask1Impacts { get; set; }

    public virtual DbSet<LtTask2Urgency> LtTask2Urgencies { get; set; }

    public virtual DbSet<LtTask3Priority> LtTask3Priorities { get; set; }

    public virtual DbSet<LtTask4PriorityMatrix> LtTask4PriorityMatrices { get; set; }

    public virtual DbSet<LtTask5Rate> LtTask5Rates { get; set; }

    public virtual DbSet<LtTask6Tier> LtTask6Tiers { get; set; }

    public virtual DbSet<LtTax> LtTaxes { get; set; }

    public virtual DbSet<LtTaxGroup> LtTaxGroups { get; set; }

    public virtual DbSet<LtWorkFlowStatus> LtWorkFlowStatuses { get; set; }

    public virtual DbSet<SmMenu> SmMenus { get; set; }

    public virtual DbSet<SmMenuPermission> SmMenuPermissions { get; set; }

    public virtual DbSet<SmOption> SmOptions { get; set; }

    public virtual DbSet<StrCompany> StrCompanies { get; set; }

    public virtual DbSet<StrCompanyAttachment> StrCompanyAttachments { get; set; }

    public virtual DbSet<StrCompanyBank> StrCompanyBanks { get; set; }

    public virtual DbSet<StrCompanyDivision> StrCompanyDivisions { get; set; }

    public virtual DbSet<StrCompanyLocation> StrCompanyLocations { get; set; }

    public virtual DbSet<StrEmployee> StrEmployees { get; set; }

    public virtual DbSet<StrEmployeeAirTicket> StrEmployeeAirTickets { get; set; }

    public virtual DbSet<StrEmployeeAirTicketHistory> StrEmployeeAirTicketHistories { get; set; }

    public virtual DbSet<StrEmployeeAllowance> StrEmployeeAllowances { get; set; }

    public virtual DbSet<StrEmployeeAttachment> StrEmployeeAttachments { get; set; }

    public virtual DbSet<StrEmployeeBank> StrEmployeeBanks { get; set; }

    public virtual DbSet<StrEmployeeCareerDevelopment> StrEmployeeCareerDevelopments { get; set; }

    public virtual DbSet<StrEmployeeCertificate> StrEmployeeCertificates { get; set; }

    public virtual DbSet<StrEmployeeCourse> StrEmployeeCourses { get; set; }

    public virtual DbSet<StrEmployeeDeduction> StrEmployeeDeductions { get; set; }

    public virtual DbSet<StrEmployeeDependant> StrEmployeeDependants { get; set; }

    public virtual DbSet<StrEmployeeEmergency> StrEmployeeEmergencies { get; set; }

    public virtual DbSet<StrEmployeeEvalution> StrEmployeeEvalutions { get; set; }

    public virtual DbSet<StrEmployeeExperience> StrEmployeeExperiences { get; set; }

    public virtual DbSet<StrEmployeeInsurance> StrEmployeeInsurances { get; set; }

    public virtual DbSet<StrEmployeeReward> StrEmployeeRewards { get; set; }

    public virtual DbSet<TblAppointment> TblAppointments { get; set; }

    public virtual DbSet<TblAppointmentCategory> TblAppointmentCategories { get; set; }

    public virtual DbSet<TblCalendarSetting> TblCalendarSettings { get; set; }

    public virtual DbSet<TblDentalToothChart> TblDentalToothCharts { get; set; }

    public virtual DbSet<TblMonthDatum> TblMonthData { get; set; }

    public virtual DbSet<TblRole> TblRoles { get; set; }

    public virtual DbSet<TblSimpleAppointment> TblSimpleAppointments { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    public virtual DbSet<TblUserRole> TblUserRoles { get; set; }

    public virtual DbSet<TblWeekDatum> TblWeekData { get; set; }

    public virtual DbSet<TimeAttendanceLeaveType> TimeAttendanceLeaveTypes { get; set; }

    public virtual DbSet<TimeAttendanceOfficialVacation> TimeAttendanceOfficialVacations { get; set; }

    public virtual DbSet<TimeAttendancePattern> TimeAttendancePatterns { get; set; }

    public virtual DbSet<ViewChartOfAccount> ViewChartOfAccounts { get; set; }

    public virtual DbSet<ViewEmployeeAndDependent> ViewEmployeeAndDependents { get; set; }

    public virtual DbSet<ViewEmployeeBasicGosi> ViewEmployeeBasicGosis { get; set; }

    public virtual DbSet<ViewEmployeeDiffernaceAllowanceDefault> ViewEmployeeDiffernaceAllowanceDefaults { get; set; }

    public virtual DbSet<ViewEmployeeHierarchy> ViewEmployeeHierarchies { get; set; }

    public virtual DbSet<ViewEmployeeSalaryInfo> ViewEmployeeSalaryInfos { get; set; }

    public virtual DbSet<ViewMenuHierarchy> ViewMenuHierarchies { get; set; }

    public virtual DbSet<ViewMenuPermission> ViewMenuPermissions { get; set; }

    public virtual DbSet<ViewUsersMenuPermission> ViewUsersMenuPermissions { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1256_CI_AS");

        modelBuilder.Entity<FinChartOfAccount>(entity =>
        {
            entity.HasKey(e => new { e.LfCompanyCode, e.AccountCode }).HasName("PK_Fin_ChartOfAccount");

            entity.ToTable("FIN_ChartOfAccount");

            entity.Property(e => e.LfCompanyCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Company_Code");
            entity.Property(e => e.AccountCode).HasMaxLength(30);
            entity.Property(e => e.AccountNature)
                .HasMaxLength(6)
                .UseCollation("Arabic_CI_AS");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.IsTransaction)
                .HasDefaultValue(false)
                .HasColumnName("isTransaction");
            entity.Property(e => e.MigrateAccountCode).HasMaxLength(30);
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(150)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(150)
                .HasColumnName("Name_En");
            entity.Property(e => e.ParentAccountCode).HasMaxLength(30);
        });

        modelBuilder.Entity<FinChartOfAccountLine>(entity =>
        {
            entity.HasKey(e => new { e.LfCompanyCode, e.LfDivisionCode, e.LfAccountCode });

            entity.ToTable("FIN_ChartOfAccount_Line");

            entity.Property(e => e.LfCompanyCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Company_Code");
            entity.Property(e => e.LfDivisionCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Division_Code");
            entity.Property(e => e.LfAccountCode)
                .HasMaxLength(30)
                .HasColumnName("LF_AccountCode");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.CurrentBalance)
                .HasComputedColumnSql("([CurrentBalanceDebit]-[CurrentBalanceCredit])", false)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.CurrentBalanceCredit)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.CurrentBalanceDebit)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.OpenBalance)
                .HasComputedColumnSql("([OpenBalanceDebit]-[OpenBalanceCredit])", false)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.OpenBalanceCredit)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.OpenBalanceDebit)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
        });

        modelBuilder.Entity<FinCustomer>(entity =>
        {
            entity.HasKey(e => e.CustomerCode);

            entity.ToTable("FIN_Customer");

            entity.Property(e => e.CustomerCode)
                .HasMaxLength(30)
                .HasColumnName("Customer_Code");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.ContactEmailP)
                .HasMaxLength(120)
                .HasColumnName("ContactEmail_P");
            entity.Property(e => e.ContactEmailS)
                .HasMaxLength(120)
                .HasColumnName("ContactEmail_S");
            entity.Property(e => e.ContactMobilP)
                .HasMaxLength(25)
                .HasColumnName("ContactMobil_P");
            entity.Property(e => e.ContactMobilS)
                .HasMaxLength(25)
                .HasColumnName("ContactMobil_S");
            entity.Property(e => e.ContactTelP)
                .HasMaxLength(25)
                .HasColumnName("ContactTel_P");
            entity.Property(e => e.CprCr)
                .HasMaxLength(9)
                .HasColumnName("CPR_CR");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.CustomerNameAr).HasMaxLength(150);
            entity.Property(e => e.CustomerNameEn).HasMaxLength(150);
            entity.Property(e => e.CustomerNote).HasMaxLength(255);
            entity.Property(e => e.CustomerNote).HasMaxLength(255);
            entity.Property(e => e.DebitLimit).HasDefaultValue(0.0);
            entity.Property(e => e.DelayDaysLimit).HasDefaultValue(0);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.LfCountryCode)
                .HasMaxLength(12)
                .HasDefaultValue("CTR-0001")
                .HasColumnName("LF_Country_Code");
            entity.Property(e => e.LfCustomerGroupCode)
                .HasMaxLength(12)
                .HasDefaultValue("CUG-0001")
                .HasColumnName("LF_CustomerGroup_Code");
            entity.Property(e => e.MaxDiscountRate)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.MigrateCustomerCode).HasMaxLength(30);
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Pob)
                .HasMaxLength(75)
                .HasColumnName("POB");
            entity.Property(e => e.VatNumber)
                .HasMaxLength(50)
                .HasColumnName("VAT_Number");
        });

        modelBuilder.Entity<FinCustomerLine>(entity =>
        {
            entity.HasKey(e => new { e.LfDivisionCode, e.LfCustomerCode }).HasName("PK_FIN_CustomerLine_1");

            entity.ToTable("FIN_CustomerLine");

            entity.Property(e => e.LfDivisionCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Division_Code");
            entity.Property(e => e.LfCustomerCode)
                .HasMaxLength(30)
                .HasColumnName("LF_Customer_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.CurrentBalance)
                .HasComputedColumnSql("([CurrentBalanceDebit]-[CurrentBalanceCredit])", false)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.CurrentBalanceCredit)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.CurrentBalanceDebit)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.LfLoyaltyCardCode)
                .HasMaxLength(12)
                .HasDefaultValue("PYTY-0008")
                .HasColumnName("LF_LoyaltyCard_Code");
            entity.Property(e => e.LoyaltyCardExpiryDate).HasColumnType("smalldatetime");
            entity.Property(e => e.LoyaltyCardIssueDate).HasColumnType("smalldatetime");
            entity.Property(e => e.LoyaltyCardNo)
                .HasMaxLength(50)
                .HasColumnName("LoyaltyCardNO");
            entity.Property(e => e.LoyaltyCardPointsCurrentBalance)
                .HasComputedColumnSql("(((([LoyaltyCardPointsOpenBalance]+[LoyaltyCardsCurrentEarnedPoints])+[LoyaltyCardsAdjustPoints])+[LoyaltyCardsCurrentRedeemedPoints])-([LoyaltyCardsCurrentUsedPoints]+[LoyaltyCardsCurrentCancelledPoints]))", true)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.LoyaltyCardPointsOpenBalance)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.LoyaltyCardsAdjustPoints)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.LoyaltyCardsCurrentCancelledPoints)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.LoyaltyCardsCurrentEarnedPoints)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.LoyaltyCardsCurrentRedeemedPoints)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.LoyaltyCardsCurrentUsedPoints)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.OpenBalance)
                .HasComputedColumnSql("([OpenBalanceDebit]-[OpenBalanceCredit])", false)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.OpenBalanceCredit)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.OpenBalanceDebit)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");

            entity.HasOne(d => d.LfCustomerCodeNavigation).WithMany(p => p.FinCustomerLines)
                .HasForeignKey(d => d.LfCustomerCode)
                .HasConstraintName("FK_FIN_CustomerLine_FIN_Customer");
        });

        modelBuilder.Entity<FinPatient>(entity =>
        {
            entity.HasKey(e => e.PatientCode);

            entity.ToTable("FIN_Patient");

            entity.Property(e => e.PatientCode)
                .HasMaxLength(30)
                .HasColumnName("Patient_Code");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.ConsultationCoverageFee)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.ContactEmailP)
                .HasMaxLength(120)
                .HasColumnName("ContactEmail_P");
            entity.Property(e => e.ContactEmailS)
                .HasMaxLength(120)
                .HasColumnName("ContactEmail_S");
            entity.Property(e => e.ContactMobilP)
                .HasMaxLength(25)
                .HasColumnName("ContactMobil_P");
            entity.Property(e => e.ContactMobilS)
                .HasMaxLength(25)
                .HasColumnName("ContactMobil_S");
            entity.Property(e => e.ContactTelP)
                .HasMaxLength(25)
                .HasColumnName("ContactTel_P");
            entity.Property(e => e.Cpr)
                .HasMaxLength(9)
                .HasColumnName("CPR");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.DateOfBirth)
                .HasColumnType("smalldatetime")
                .HasColumnName("Date_of_Birth");
            entity.Property(e => e.DebitLimit)
                .HasDefaultValue(0.0)
                .HasColumnType("float");
            entity.Property(e => e.DelayDaysLimit).HasDefaultValue(0);
            entity.Property(e => e.Employer).HasMaxLength(100);
            entity.Property(e => e.Height)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.IsVip)
                .HasDefaultValue(false)
                .HasColumnName("isVip");
            entity.Property(e => e.LfBloodCode)
                .HasMaxLength(12)
                .HasDefaultValue("BLOD-0002")
                .HasColumnName("LF_Blood_Code");
            entity.Property(e => e.LfCountryCodeNationality)
                .HasMaxLength(12)
                .HasDefaultValue("CTR-0001")
                .HasColumnName("LF_Country_Code_Nationality");
            entity.Property(e => e.LfCustomerGroupCode)
                .HasMaxLength(12)
                .HasDefaultValue("CUG-0001")
                .HasColumnName("LF_CustomerGroup_Code");
            entity.Property(e => e.LfGenderCode)
                .HasMaxLength(12)
                .HasDefaultValue("GEND-0002")
                .HasColumnName("LF_Gender_Code");
            entity.Property(e => e.LfInsuranceCustomerCode)
                .HasMaxLength(30)
                .HasColumnName("LF_Insurance_Customer_Code");
            entity.Property(e => e.LfJobTitleCode)
                .HasMaxLength(100)
                .HasDefaultValue("JOBT-0015")
                .HasColumnName("LF_JobTitle_Code");
            entity.Property(e => e.MaxDiscountRate)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.MigratePatientCode).HasMaxLength(30);
            entity.Property(e => e.MigratePatientCustomerCode).HasMaxLength(30);
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr).HasMaxLength(150);
            entity.Property(e => e.NameEn).HasMaxLength(150);
            entity.Property(e => e.PassportNo).HasMaxLength(70);
            entity.Property(e => e.PatientNote).HasMaxLength(255);
            entity.Property(e => e.Pob)
                .HasMaxLength(75)
                .HasColumnName("POB");
            entity.Property(e => e.PolicyEndDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("Policy_EndDate");
            entity.Property(e => e.PolicyNo).HasMaxLength(50);
            entity.Property(e => e.PolicyStartDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("Policy_StartDate");
            entity.Property(e => e.Qr).HasColumnName("QR");
            entity.Property(e => e.ServiceCoveragePersentage)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.VatNumber)
                .HasMaxLength(50)
                .HasColumnName("VAT_Number");
            entity.Property(e => e.Weight)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
        });

        modelBuilder.Entity<FinPatientAllergy>(entity =>
        {
            entity.HasKey(e => new { e.LfPatientCode, e.LfAllergiesCode }).HasName("PK_FIN_PatientAllergies_1");

            entity.ToTable("FIN_PatientAllergies");

            entity.Property(e => e.LfPatientCode)
                .HasMaxLength(30)
                .HasColumnName("LF_Patient_Code");
            entity.Property(e => e.LfAllergiesCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Allergies_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.PatientNote).HasMaxLength(255);
        });

        modelBuilder.Entity<FinPatientDiagnosis>(entity =>
        {
            entity.HasKey(e => new { e.LfPatientCode, e.LfDiagnosisCode }).HasName("PK_FIN_PatientDiagnosis_1");

            entity.ToTable("FIN_PatientDiagnosis");

            entity.Property(e => e.LfPatientCode)
                .HasMaxLength(30)
                .HasColumnName("LF_Patient_Code");
            entity.Property(e => e.LfDiagnosisCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Diagnosis_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.PatientNote).HasMaxLength(255);
        });

        modelBuilder.Entity<FinPatientLine>(entity =>
        {
            entity.HasKey(e => new { e.LfDivisionCode, e.LfPatientCode }).HasName("PK_FIN_PatientLine_1");

            entity.ToTable("FIN_PatientLine");

            entity.Property(e => e.LfDivisionCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Division_Code");
            entity.Property(e => e.LfPatientCode)
                .HasMaxLength(30)
                .HasColumnName("LF_Patient_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.CurrentBalance)
                .HasComputedColumnSql("([CurrentBalanceDebit]-[CurrentBalanceCredit])", false)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.CurrentBalanceCredit)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.CurrentBalanceDebit)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.LfLoyaltyCardCode)
                .HasMaxLength(12)
                .HasDefaultValue("PYTY-0008")
                .HasColumnName("LF_LoyaltyCard_Code");
            entity.Property(e => e.LoyaltyCardExpiryDate).HasColumnType("smalldatetime");
            entity.Property(e => e.LoyaltyCardIssueDate).HasColumnType("smalldatetime");
            entity.Property(e => e.LoyaltyCardNo)
                .HasMaxLength(50)
                .HasColumnName("LoyaltyCardNO");
            entity.Property(e => e.LoyaltyCardPointsCurrentBalance)
                .HasComputedColumnSql("(((([LoyaltyCardPointsOpenBalance]+[LoyaltyCardsCurrentEarnedPoints])+[LoyaltyCardsAdjustPoints])+[LoyaltyCardsCurrentRedeemedPoints])-([LoyaltyCardsCurrentUsedPoints]+[LoyaltyCardsCurrentCancelledPoints]))", true)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.LoyaltyCardPointsOpenBalance)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.LoyaltyCardsAdjustPoints)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.LoyaltyCardsCurrentCancelledPoints)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.LoyaltyCardsCurrentEarnedPoints)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.LoyaltyCardsCurrentRedeemedPoints)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.LoyaltyCardsCurrentUsedPoints)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.OpenBalance)
                .HasComputedColumnSql("([OpenBalanceDebit]-[OpenBalanceCredit])", false)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.OpenBalanceCredit)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.OpenBalanceDebit)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");

            entity.HasOne(d => d.LfPatientCodeNavigation).WithMany(p => p.FinPatientLines)
                .HasForeignKey(d => d.LfPatientCode)
                .HasConstraintName("FK_FIN_PatientLine_FIN_Patient");
        });

        modelBuilder.Entity<FinPatientSymptom>(entity =>
        {
            entity.HasKey(e => new { e.LfPatientCode, e.LfSymptomsCode }).HasName("PK_FIN_PatientSymptoms_1");

            entity.ToTable("FIN_PatientSymptoms");

            entity.Property(e => e.LfPatientCode)
                .HasMaxLength(30)
                .HasColumnName("LF_Patient_Code");
            entity.Property(e => e.LfSymptomsCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Symptoms_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.PatientNote).HasMaxLength(255);
        });

        modelBuilder.Entity<FinSupplier>(entity =>
        {
            entity.HasKey(e => e.SupplierCode);

            entity.ToTable("FIN_Supplier");

            entity.Property(e => e.SupplierCode)
                .HasMaxLength(30)
                .HasColumnName("Supplier_Code");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.ContactEmailP)
                .HasMaxLength(120)
                .HasColumnName("ContactEmail_P");
            entity.Property(e => e.ContactEmailS)
                .HasMaxLength(120)
                .HasColumnName("ContactEmail_S");
            entity.Property(e => e.ContactMobilP)
                .HasMaxLength(25)
                .HasColumnName("ContactMobil_P");
            entity.Property(e => e.ContactMobilS)
                .HasMaxLength(25)
                .HasColumnName("ContactMobil_S");
            entity.Property(e => e.ContactTelP)
                .HasMaxLength(25)
                .HasColumnName("ContactTel_P");
            entity.Property(e => e.CprCr)
                .HasMaxLength(9)
                .HasColumnName("CPR_CR");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.CreditLimit)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.DelayDaysLimit).HasDefaultValue(0);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.LfCountryCode)
                .HasMaxLength(12)
                .HasDefaultValue("CUG-0001")
                .HasColumnName("LF_Country_Code");
            entity.Property(e => e.LfSupplierGroupCode)
                .HasMaxLength(12)
                .HasDefaultValue("SUG-0001")
                .HasColumnName("LF_SupplierGroup_Code");
            entity.Property(e => e.MaxDiscountRate)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.MigrateSupplierCode).HasMaxLength(30);
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Pob)
                .HasMaxLength(75)
                .HasColumnName("POB");
            entity.Property(e => e.SupplierNameAr).HasMaxLength(150);
            entity.Property(e => e.SupplierNameEn).HasMaxLength(150);
            entity.Property(e => e.SupplierNote).HasMaxLength(255);
            entity.Property(e => e.VatNumber)
                .HasMaxLength(50)
                .HasColumnName("VAT_Number");
        });

        modelBuilder.Entity<FinSupplierLine>(entity =>
        {
            entity.HasKey(e => new { e.LfDivisionCode, e.LfSupplierCode });

            entity.ToTable("FIN_SupplierLine");

            entity.Property(e => e.LfDivisionCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Division_Code");
            entity.Property(e => e.LfSupplierCode)
                .HasMaxLength(30)
                .HasColumnName("LF_Supplier_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.CurrentBalance)
                .HasComputedColumnSql("([CurrentBalanceDebit]-[CurrentBalanceCredit])", false)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.CurrentBalanceCredit)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.CurrentBalanceDebit)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.OpenBalance)
                .HasComputedColumnSql("([OpenBalanceDebit]-[OpenBalanceCredit])", false)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.OpenBalanceCredit)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.OpenBalanceDebit)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");

            entity.HasOne(d => d.LfSupplierCodeNavigation).WithMany(p => p.FinSupplierLines)
                .HasForeignKey(d => d.LfSupplierCode)
                .HasConstraintName("FK_FIN_SupplierLine_FIN_Supplier");
        });


        modelBuilder.Entity<InvService1Item>(entity =>
        {
            entity.HasKey(e => e.ProductCode).HasName("PK_LT_ProductType");

            entity.ToTable("INV_Service_1_Item");

            entity.Property(e => e.ProductCode)
                .HasMaxLength(20)
                .HasColumnName("Product_Code");
            entity.Property(e => e.CostPriceExtendedFee)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.CostPriceFee)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.LfCategoryCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Category_Code");
            entity.Property(e => e.LfTaxCode)
                .HasMaxLength(12)
                .HasDefaultValue("TAX-0001")
                .HasColumnName("LF_Tax_Code");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(150)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(150)
                .HasColumnName("Name_En");
            entity.Property(e => e.SalePriceExtendFeeIncludeVat)
                .HasDefaultValue(true)
                .HasColumnName("SalePriceExtendFee_IncludeVat");
            entity.Property(e => e.SalePriceExtendedFee)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.SalePriceFee)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.SalePriceFeeIncludeVat)
                .HasDefaultValue(true)
                .HasColumnName("SalePriceFee_IncludeVat");
            entity.Property(e => e.ServiceDurationMinutes).HasDefaultValue((byte)0);
            entity.Property(e => e.ServiceExtendedDurationMinutes).HasDefaultValue((byte)0);
        });

        modelBuilder.Entity<InvStock1Item>(entity =>
        {
            entity.HasKey(e => e.ProductCode).HasName("PK_LT_ProductService_3_Product_2_Inventory");

            entity.ToTable("INV_Stock_1_Item");

            entity.Property(e => e.ProductCode)
                .HasMaxLength(20)
                .HasColumnName("Product_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.LfBrandCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Brand_Code");
            entity.Property(e => e.LfCategoryCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Category_Code");
            entity.Property(e => e.LfCollectionCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Collection_Code");
            entity.Property(e => e.LfExitCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Exit_Code");
            entity.Property(e => e.LfMeasurementCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Measurement_Code");
            entity.Property(e => e.LfSeasonCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Season_Code");
            entity.Property(e => e.LfSupplierCode)
                .HasMaxLength(30)
                .HasColumnName("LF_Supplier_Code");
            entity.Property(e => e.LfTaxCode)
                .HasMaxLength(12)
                .HasDefaultValue("TAX-0001")
                .HasColumnName("LF_Tax_Code");
            entity.Property(e => e.ManuallyAdded).HasDefaultValue(false);
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(150)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(150)
                .HasColumnName("Name_En");
            entity.Property(e => e.ProductCodeBySupplier)
                .HasMaxLength(50)
                .HasColumnName("ProductCode_BySupplier");
            entity.Property(e => e.ProductNameBySupplier)
                .HasMaxLength(100)
                .HasColumnName("ProductName_BySupplier");
        });

        modelBuilder.Entity<LtAbbreviation>(entity =>
        {
            entity.HasKey(e => e.AbbreviationCode).HasName("PK_LT_Salutation");

            entity.ToTable("LT_Abbreviation");

            entity.HasIndex(e => e.NameEn, "IX_LT_Abbreviation").IsUnique();

            entity.HasIndex(e => e.NameAr, "IX_LT_Abbreviation_1");

            entity.HasIndex(e => e.IsActive, "IX_LT_Abbreviation_2");

            entity.Property(e => e.AbbreviationCode)
                .HasMaxLength(12)
                .HasColumnName("Abbreviation_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .HasColumnName("Name_En");
        });

        modelBuilder.Entity<LtAccountingDocumentType>(entity =>
        {
            entity.HasKey(e => e.AccountingDocumentTypeCode).HasName("PK_LT_AccountingDocumentID");

            entity.ToTable("LT_AccountingDocumentType");

            entity.HasIndex(e => e.NameEn, "IX_LT_AccountingDocumentType").IsUnique();

            entity.HasIndex(e => e.NameAr, "IX_LT_AccountingDocumentType_1");

            entity.HasIndex(e => e.IsActive, "IX_LT_AccountingDocumentType_2");

            entity.Property(e => e.AccountingDocumentTypeCode)
                .HasMaxLength(12)
                .HasColumnName("AccountingDocumentType_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.DocumentBreif).HasMaxLength(2);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.LastSerialNo).HasDefaultValue(0);
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(50)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .HasColumnName("Name_En");
            entity.Property(e => e.TemporarySerialNo).HasDefaultValue(0);
        });

        modelBuilder.Entity<LtAcountMapping>(entity =>
        {
            entity.HasKey(e => e.AcronymCode).HasName("PK_LT_AcountMapping_1");

            entity.ToTable("LT_AcountMapping");

            entity.HasIndex(e => e.NameEn, "IX_LT_AcountMapping").IsUnique();

            entity.HasIndex(e => e.NameAr, "IX_LT_AcountMapping_1");

            entity.HasIndex(e => e.IsActive, "IX_LT_AcountMapping_2");

            entity.Property(e => e.AcronymCode)
                .HasMaxLength(12)
                .HasColumnName("Acronym_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.LfAccountCode)
                .HasMaxLength(30)
                .HasColumnName("LF_AccountCode");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .HasColumnName("Name_En");
        });

        modelBuilder.Entity<LtAddress0Continent>(entity =>
        {
            entity.HasKey(e => e.ContinentCode);

            entity.ToTable("LT_Address_0_Continent");

            entity.HasIndex(e => e.NameEn, "IX_LT_Address_0_Continent").IsUnique();

            entity.HasIndex(e => e.NameAr, "IX_LT_Address_0_Continent_1");

            entity.HasIndex(e => e.IsActive, "IX_LT_Address_0_Continent_2");

            entity.Property(e => e.ContinentCode)
                .HasMaxLength(12)
                .HasColumnName("Continent_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(50)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .HasColumnName("Name_En");
        });

        modelBuilder.Entity<LtAddress0Zone>(entity =>
        {
            entity.HasKey(e => e.ZoneCode).HasName("PK_LT_Address_00_Zone");

            entity.ToTable("LT_Address_0_Zone");

            entity.HasIndex(e => new { e.LfContinentCode, e.ZoneCode }, "IX_LT_Address_0_Zone").IsUnique();

            entity.HasIndex(e => e.NameEn, "IX_LT_Address_0_Zone_1").IsUnique();

            entity.HasIndex(e => e.NameAr, "IX_LT_Address_0_Zone_2");

            entity.HasIndex(e => e.IsActive, "IX_LT_Address_0_Zone_3");

            entity.Property(e => e.ZoneCode)
                .HasMaxLength(12)
                .HasColumnName("Zone_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.LfContinentCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Continent_Code");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(50)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .HasColumnName("Name_En");
        });

        modelBuilder.Entity<LtAddress1Country>(entity =>
        {
            entity.HasKey(e => e.CountryCode).HasName("PK_LT_Country");

            entity.ToTable("LT_Address_1_Country");

            entity.HasIndex(e => e.NameEn, "IX_LT_Address_1_Country").IsUnique();

            entity.HasIndex(e => e.NameAr, "IX_LT_Address_1_Country_1");

            entity.HasIndex(e => new { e.IsActive, e.IsGcc }, "IX_LT_Address_1_Country_2");

            entity.Property(e => e.CountryCode)
                .HasMaxLength(12)
                .HasColumnName("Country_Code");
            entity.Property(e => e.Alpha2Code).HasMaxLength(5);
            entity.Property(e => e.Alpha3Code).HasMaxLength(5);
            entity.Property(e => e.Capital).HasMaxLength(50);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.DialCode).HasMaxLength(8);
            entity.Property(e => e.Iacocode).HasColumnName("IACOCode");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.IsGcc).HasColumnName("IsGCC");
            entity.Property(e => e.LfZoneCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Zone_Code");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(50)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .HasColumnName("Name_En");
            entity.Property(e => e.NationalityAr)
                .HasMaxLength(50)
                .HasColumnName("Nationality_Ar");
            entity.Property(e => e.NationalityEn)
                .HasMaxLength(50)
                .HasColumnName("Nationality_En");
        });

        modelBuilder.Entity<LtAddress2Governorate>(entity =>
        {
            entity.HasKey(e => e.GovernorateCode).HasName("PK_LT_Governorate");

            entity.ToTable("LT_Address_2_Governorate");

            entity.HasIndex(e => e.NameEn, "IX_LT_Address_2_Governorate").IsUnique();

            entity.HasIndex(e => e.NameAr, "IX_LT_Address_2_Governorate_1");

            entity.HasIndex(e => e.IsActive, "IX_LT_Address_2_Governorate_2");

            entity.Property(e => e.GovernorateCode)
                .HasMaxLength(12)
                .HasColumnName("Governorate_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.LfCountryCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Country_Code");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(50)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .HasColumnName("Name_En");
        });

        modelBuilder.Entity<LtAddress3Region>(entity =>
        {
            entity.HasKey(e => e.RegionCode).HasName("PK_LT_Region");

            entity.ToTable("LT_Address_3_Region");

            entity.HasIndex(e => new { e.RegionCode, e.NameEn }, "IX_LT_Address_3_Region").IsUnique();

            entity.HasIndex(e => e.NameAr, "IX_LT_Address_3_Region_1");

            entity.HasIndex(e => e.IsActive, "IX_LT_Address_3_Region_2");

            entity.Property(e => e.RegionCode)
                .HasMaxLength(12)
                .HasColumnName("Region_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.LfGovernorateCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Governorate_Code");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(50)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .HasColumnName("Name_En");
        });

        modelBuilder.Entity<LtAddress4Area>(entity =>
        {
            entity.HasKey(e => e.AreaCode);

            entity.ToTable("LT_Address_4_Area");

            entity.HasIndex(e => new { e.AreaCode, e.BlockNo }, "IX_LT_Address_4_Area").IsUnique();

            entity.HasIndex(e => e.IsActive, "IX_LT_Address_4_Area_1");

            entity.Property(e => e.AreaCode)
                .HasMaxLength(12)
                .HasColumnName("Area_Code");
            entity.Property(e => e.BlockNo).HasColumnName("BlockNO");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.LfRegionCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Region_Code");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
        });

        modelBuilder.Entity<LtAddress5Road>(entity =>
        {
            entity.HasKey(e => e.RoadCode).HasName("PK_LT_Road");

            entity.ToTable("LT_Address_5_Road");

            entity.HasIndex(e => e.NameAr, "IX_LT_Address_5_Road");

            entity.HasIndex(e => new { e.RoadNo, e.NameEn }, "IX_LT_Address_5_Road_1");

            entity.HasIndex(e => e.IsActive, "IX_LT_Address_5_Road_2");

            entity.Property(e => e.RoadCode)
                .HasMaxLength(12)
                .HasColumnName("Road_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.LfAreaCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Area_Code");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(80)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(80)
                .HasColumnName("Name_En");
            entity.Property(e => e.RoadNo).HasColumnName("RoadNO");
        });

        modelBuilder.Entity<LtAgeCategory>(entity =>
        {
            entity.HasKey(e => e.AgeCategoryCode).HasName("PK_LT_Age_Categeory");

            entity.ToTable("LT_Age_Category");

            entity.HasIndex(e => e.NameEn, "IX_LT_Age_Category").IsUnique();

            entity.HasIndex(e => e.NameAr, "IX_LT_Age_Category_1");

            entity.HasIndex(e => e.IsActive, "IX_LT_Age_Category_2");

            entity.Property(e => e.AgeCategoryCode)
                .HasMaxLength(12)
                .IsFixedLength()
                .HasColumnName("AgeCategory_Code");
            entity.Property(e => e.AgeEnd).HasColumnName("ageEnd");
            entity.Property(e => e.AgeStart).HasColumnName("ageStart");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(50)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .HasColumnName("Name_En");
        });

        modelBuilder.Entity<LtAllowance>(entity =>
        {
            entity.HasKey(e => e.AllowanceCode);

            entity.ToTable("LT_Allowance");

            entity.HasIndex(e => e.NameEn, "IX_LT_Allowance").IsUnique();

            entity.HasIndex(e => e.NameAr, "IX_LT_Allowance_1");

            entity.HasIndex(e => e.IsActive, "IX_LT_Allowance_2");

            entity.Property(e => e.AllowanceCode)
                .HasMaxLength(12)
                .HasColumnName("Allowance_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.LfAccountCode)
                .HasMaxLength(30)
                .HasColumnName("LF_AccountCode");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .HasColumnName("Name_En");
        });

        modelBuilder.Entity<LtAssetStatus>(entity =>
        {
            entity.HasKey(e => e.AssetStatusCode).HasName("PK_AssetsStatus");

            entity.ToTable("LT_Asset_Status");

            entity.HasIndex(e => e.NameEn, "IX_LT_Asset_Status").IsUnique();

            entity.HasIndex(e => e.NameAr, "IX_LT_Asset_Status_1");

            entity.HasIndex(e => e.IsActive, "IX_LT_Asset_Status_2");

            entity.Property(e => e.AssetStatusCode)
                .HasMaxLength(12)
                .IsFixedLength()
                .HasColumnName("AssetStatus_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(220)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(220)
                .HasColumnName("Name_En");
            entity.Property(e => e.Status).HasMaxLength(32);
        });

        modelBuilder.Entity<LtAssetWrokLog>(entity =>
        {
            entity.HasKey(e => e.AssetWrokLogCode);

            entity.ToTable("LT_Asset_WrokLog");

            entity.HasIndex(e => e.NameEn, "IX_LT_Asset_WrokLog").IsUnique();

            entity.HasIndex(e => e.NameAr, "IX_LT_Asset_WrokLog_1");

            entity.HasIndex(e => e.IsActive, "IX_LT_Asset_WrokLog_2");

            entity.Property(e => e.AssetWrokLogCode)
                .HasMaxLength(12)
                .IsFixedLength()
                .HasColumnName("AssetWrokLog_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(50)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .HasColumnName("Name_En");
        });

        modelBuilder.Entity<LtAttacmentType>(entity =>
        {
            entity.HasKey(e => e.AttachmentTypeCode);

            entity.ToTable("LT_AttacmentType");

            entity.HasIndex(e => e.NameEn, "IX_LT_AttacmentType").IsUnique();

            entity.HasIndex(e => e.NameAr, "IX_LT_AttacmentType_1");

            entity.HasIndex(e => e.IsActive, "IX_LT_AttacmentType_2");

            entity.Property(e => e.AttachmentTypeCode)
                .HasMaxLength(12)
                .HasColumnName("AttachmentType_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .HasColumnName("Name_En");
        });

        modelBuilder.Entity<LtBank>(entity =>
        {
            entity.HasKey(e => e.BankCode).HasName("PK_LT_BankID");

            entity.ToTable("LT_Bank");

            entity.HasIndex(e => e.BreifName, "IX_LT_Bank").IsUnique();

            entity.HasIndex(e => e.NameEn, "IX_LT_Bank_1").IsUnique();

            entity.HasIndex(e => e.NameAr, "IX_LT_Bank_2");

            entity.HasIndex(e => e.IsActive, "IX_LT_Bank_3");

            entity.Property(e => e.BankCode)
                .HasMaxLength(12)
                .HasColumnName("Bank_Code");
            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.BreifName).HasMaxLength(8);
            entity.Property(e => e.ContactEmailP)
                .HasMaxLength(75)
                .HasColumnName("ContactEmail_P");
            entity.Property(e => e.ContactEmailS)
                .HasMaxLength(75)
                .HasColumnName("ContactEmail_S");
            entity.Property(e => e.ContactFaxP)
                .HasMaxLength(15)
                .HasColumnName("ContactFax_P");
            entity.Property(e => e.ContactFaxS)
                .HasMaxLength(15)
                .HasColumnName("ContactFax_S");
            entity.Property(e => e.ContactMobilP)
                .HasMaxLength(15)
                .HasColumnName("ContactMobil_P");
            entity.Property(e => e.ContactMobilS)
                .HasMaxLength(15)
                .HasColumnName("ContactMobil_S");
            entity.Property(e => e.ContactPersonP)
                .HasMaxLength(50)
                .HasColumnName("ContactPerson_P");
            entity.Property(e => e.ContactPersonS)
                .HasMaxLength(50)
                .HasColumnName("ContactPerson_S");
            entity.Property(e => e.ContactTelP)
                .HasMaxLength(15)
                .HasColumnName("ContactTel_P");
            entity.Property(e => e.ContactTelS)
                .HasMaxLength(15)
                .HasColumnName("ContactTel_S");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .HasColumnName("Name_En");
            entity.Property(e => e.WebSite).HasMaxLength(75);
        });

        modelBuilder.Entity<LtBankAccountType>(entity =>
        {
            entity.HasKey(e => e.BankAccountTypeCode).HasName("PK_LT_BankTypeID");

            entity.ToTable("LT_BankAccountType");

            entity.HasIndex(e => e.NameEn, "IX_LT_BankAccountType").IsUnique();

            entity.HasIndex(e => e.NameAr, "IX_LT_BankAccountType_1");

            entity.HasIndex(e => e.IsActive, "IX_LT_BankAccountType_2");

            entity.Property(e => e.BankAccountTypeCode)
                .HasMaxLength(12)
                .HasColumnName("BankAccountType_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(50)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .HasColumnName("Name_En");
        });

        modelBuilder.Entity<LtBlood>(entity =>
        {
            entity.HasKey(e => e.BloodCode);

            entity.ToTable("LT_Blood");

            entity.HasIndex(e => e.NameEn, "IX_LT_Blood").IsUnique();

            entity.HasIndex(e => e.NameAr, "IX_LT_Blood_1");

            entity.HasIndex(e => e.IsActive, "IX_LT_Blood_2");

            entity.Property(e => e.BloodCode)
                .HasMaxLength(12)
                .HasColumnName("Blood_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .HasColumnName("Name_En");
        });

        modelBuilder.Entity<LtCompanyOwner>(entity =>
        {
            entity.HasKey(e => e.OwnerCode).HasName("PK_LT_CompanyOwner_1");

            entity.ToTable("LT_CompanyOwner");

            entity.Property(e => e.OwnerCode)
                .HasMaxLength(30)
                .HasColumnName("Owner_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.LfAccountCodeCapital)
                .HasMaxLength(30)
                .HasColumnName("LF_Account_Code_Capital");
            entity.Property(e => e.LfAccountCodePersentage)
                .HasMaxLength(30)
                .HasColumnName("LF_Account_Code_Persentage");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .HasColumnName("Name_En");
            entity.Property(e => e.ShareholdingCapital)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.ShareholdingPersentage)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
        });

        modelBuilder.Entity<LtContractType>(entity =>
        {
            entity.HasKey(e => e.ContractTypeCode);

            entity.ToTable("LT_ContractType");

            entity.HasIndex(e => e.NameEn, "IX_LT_ContractType").IsUnique();

            entity.HasIndex(e => e.NameAr, "IX_LT_ContractType_1");

            entity.HasIndex(e => new { e.IsActive, e.IsUpgradable }, "IX_LT_ContractType_2");

            entity.Property(e => e.ContractTypeCode)
                .HasMaxLength(12)
                .HasColumnName("ContractType_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.IsUpgradable)
                .HasDefaultValue(false)
                .HasColumnName("isUpgradable");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(50)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .HasColumnName("Name_En");
        });

        modelBuilder.Entity<LtCurrency>(entity =>
        {
            entity.HasKey(e => e.CurrencyCode).HasName("PK_LT_CurrencyID");

            entity.ToTable("LT_Currency");

            entity.HasIndex(e => e.CurrencyName, "IX_LT_Currency").IsUnique();

            entity.HasIndex(e => e.CurrencyCode1, "IX_LT_Currency_1").IsUnique();

            entity.HasIndex(e => new { e.IsActive, e.IsDefault }, "IX_LT_Currency_2");

            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(12)
                .HasColumnName("Currency_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.CurrencyCode1)
                .HasMaxLength(3)
                .HasColumnName("CurrencyCode");
            entity.Property(e => e.CurrencyName).HasMaxLength(50);
            entity.Property(e => e.ExchangeRate)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.IsDefault).HasColumnName("isDefault");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
        });

        modelBuilder.Entity<LtCustomerGroupType>(entity =>
        {
            entity.HasKey(e => e.CustomerGroupCode).HasName("PK_CustomerGroupID");

            entity.ToTable("LT_CustomerGroupType");

            entity.HasIndex(e => e.NameEn, "IX_LT_CustomerGroupType").IsUnique();

            entity.HasIndex(e => e.NameAr, "IX_LT_CustomerGroupType_1");

            entity.HasIndex(e => new { e.IsActive, e.IsDefault }, "IX_LT_CustomerGroupType_2");

            entity.Property(e => e.CustomerGroupCode)
                .HasMaxLength(12)
                .HasColumnName("CustomerGroup_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.IsDefault).HasColumnName("isDefault");
            entity.Property(e => e.LfAccountCode)
                .HasMaxLength(30)
                .HasColumnName("LF_AccountCode");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(50)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .HasColumnName("Name_En");
        });

        modelBuilder.Entity<LtDeduction>(entity =>
        {
            entity.HasKey(e => e.DeductionCode);

            entity.ToTable("LT_Deduction");

            entity.HasIndex(e => e.NameEn, "IX_LT_Deduction").IsUnique();

            entity.HasIndex(e => e.NameAr, "IX_LT_Deduction_1");

            entity.HasIndex(e => e.IsActive, "IX_LT_Deduction_2");

            entity.Property(e => e.DeductionCode)
                .HasMaxLength(12)
                .HasColumnName("Deduction_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.LfAccountCode)
                .HasMaxLength(30)
                .HasColumnName("LF_AccountCode");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .HasColumnName("Name_En");
        });

        modelBuilder.Entity<LtDentalTeethChart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ToothTable");

            entity.ToTable("LT_DentalTeethChart");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.ToothFda)
                .HasDefaultValue(0)
                .HasColumnName("ToothFDA");
            entity.Property(e => e.ToothId).HasColumnName("ToothID");
        });

        modelBuilder.Entity<LtDiscontinuedType>(entity =>
        {
            entity.HasKey(e => e.DiscontinuedCode);

            entity.ToTable("LT_DiscontinuedType");

            entity.HasIndex(e => e.NameEn, "IX_LT_DiscontinuedType").IsUnique();

            entity.HasIndex(e => e.NameAr, "IX_LT_DiscontinuedType_1");

            entity.HasIndex(e => e.IsActive, "IX_LT_DiscontinuedType_2");

            entity.Property(e => e.DiscontinuedCode)
                .HasMaxLength(12)
                .HasColumnName("Discontinued_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .HasColumnName("Name_En");
        });

        modelBuilder.Entity<LtDivisionType>(entity =>
        {
            entity.HasKey(e => e.DivisionTypeCode);

            entity.ToTable("LT_DivisionType");

            entity.HasIndex(e => e.NameEn, "IX_LT_DivisionType").IsUnique();

            entity.HasIndex(e => e.NameAr, "IX_LT_DivisionType_1");

            entity.HasIndex(e => e.IsActive, "IX_LT_DivisionType_2");

            entity.Property(e => e.DivisionTypeCode)
                .HasMaxLength(12)
                .HasColumnName("DivisionType_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(50)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .HasColumnName("Name_En");
        });

        modelBuilder.Entity<LtEducation1Resource>(entity =>
        {
            entity.HasKey(e => e.EducationResourceCode).HasName("PK_tblSourceEducation");

            entity.ToTable("LT_Education_1_Resource");

            entity.HasIndex(e => e.NameEn, "IX_LT_Education_1_Resource").IsUnique();

            entity.HasIndex(e => e.NameAr, "IX_LT_Education_1_Resource_1");

            entity.HasIndex(e => e.IsActive, "IX_LT_Education_1_Resource_2");

            entity.Property(e => e.EducationResourceCode)
                .HasMaxLength(12)
                .HasColumnName("Education_Resource_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .HasColumnName("Name_En");
        });

        modelBuilder.Entity<LtEducation2Level>(entity =>
        {
            entity.HasKey(e => e.EducationLevelCode).HasName("PK_LT_Education_2_Stage");

            entity.ToTable("LT_Education_2_Level");

            entity.HasIndex(e => e.NameEn, "IX_LT_Education_2_Level").IsUnique();

            entity.HasIndex(e => e.NameAr, "IX_LT_Education_2_Level_1");

            entity.HasIndex(e => e.IsActive, "IX_LT_Education_2_Level_2");

            entity.Property(e => e.EducationLevelCode)
                .HasMaxLength(12)
                .HasColumnName("Education_Level_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .HasColumnName("Name_En");
        });

        modelBuilder.Entity<LtFileScreenAction>(entity =>
        {
            entity.HasKey(e => e.FileScreenActionCode).HasName("PK_ActionID");

            entity.ToTable("LT_FileScreen_Action");

            entity.HasIndex(e => e.NameEn, "IX_LT_FileScreen_Action").IsUnique();

            entity.HasIndex(e => e.IsActive, "IX_LT_FileScreen_Action_1");

            entity.Property(e => e.FileScreenActionCode)
                .HasMaxLength(12)
                .HasColumnName("FileScreenAction_code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(50)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .HasColumnName("Name_En");
        });

        modelBuilder.Entity<LtFiscalYear>(entity =>
        {
            entity.HasKey(e => e.FiscalYearCode).HasName("PK_LT_FinancialYear_1");

            entity.ToTable("LT_FiscalYear");

            entity.HasIndex(e => new { e.FiscalYearCode, e.StartDate, e.EndDate }, "IX_LT_FinancialYear_2").IsUnique();

            entity.HasIndex(e => new { e.IsActive, e.IsClosed }, "IX_LT_FiscalYear");

            entity.Property(e => e.FiscalYearCode)
                .HasMaxLength(12)
                .HasColumnName("FiscalYear_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.EndDate).HasColumnType("smalldatetime");
            entity.Property(e => e.FiscalYearName).HasMaxLength(100);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.IsClosed)
                .HasDefaultValue(false)
                .HasColumnName("isClosed");
            entity.Property(e => e.LastSerialNo).HasDefaultValue(0);
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.PadLeftNo).HasDefaultValue((byte)3);
            entity.Property(e => e.StartDate).HasColumnType("smalldatetime");
            entity.Property(e => e.YearCode).HasComputedColumnSql("(datepart(year,[StartDate]))", false);
        });

        modelBuilder.Entity<LtGender>(entity =>
        {
            entity.HasKey(e => e.GenderCode);

            entity.ToTable("LT_Gender");

            entity.HasIndex(e => e.NameEn, "IX_LT_Gender").IsUnique();

            entity.HasIndex(e => e.IsActive, "IX_LT_Gender_1");

            entity.Property(e => e.GenderCode)
                .HasMaxLength(12)
                .HasColumnName("Gender_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .HasColumnName("Name_En");
        });

        modelBuilder.Entity<LtGrade>(entity =>
        {
            entity.HasKey(e => e.GradeCode);

            entity.ToTable("LT_Grade");

            entity.HasIndex(e => e.NameEn, "IX_LT_Grade").IsUnique();

            entity.HasIndex(e => e.NameAr, "IX_LT_Grade_1");

            entity.HasIndex(e => e.IsActive, "IX_LT_Grade_2");

            entity.Property(e => e.GradeCode)
                .HasMaxLength(12)
                .HasColumnName("Grade_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.HourBase)
                .HasDefaultValue(0.0)
                .HasColumnType("float");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.LfGradeTypeCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Grade_TypeCode");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(50)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .HasColumnName("Name_En");
            entity.Property(e => e.OverTimeRegular)
                .HasDefaultValue(0.0)
                .HasColumnType("float");
            entity.Property(e => e.OverTimeVacation)
                .HasDefaultValue(0.0)
                .HasColumnType("float");
            entity.Property(e => e.Regular0)
                .HasDefaultValue(0.0)
                .HasColumnType("float");
            entity.Property(e => e.Regular1)
                .HasDefaultValue(0.0)
                .HasColumnType("float");
            entity.Property(e => e.Regular10)
                .HasDefaultValue(0.0)
                .HasColumnType("float");
            entity.Property(e => e.Regular11)
                .HasDefaultValue(0.0)
                .HasColumnType("float");
            entity.Property(e => e.Regular12)
                .HasDefaultValue(0.0)
                .HasColumnType("float");
            entity.Property(e => e.Regular13)
                .HasDefaultValue(0.0)
                .HasColumnType("float");
            entity.Property(e => e.Regular14)
                .HasDefaultValue(0.0)
                .HasColumnType("float");
            entity.Property(e => e.Regular15)
                .HasDefaultValue(0.0)
                .HasColumnType("float");
            entity.Property(e => e.Regular2)
                .HasDefaultValue(0.0)
                .HasColumnType("float");
            entity.Property(e => e.Regular3)
                .HasDefaultValue(0.0)
                .HasColumnType("float");
            entity.Property(e => e.Regular4)
                .HasDefaultValue(0.0)
                .HasColumnType("float");
            entity.Property(e => e.Regular5)
                .HasDefaultValue(0.0)
                .HasColumnType("float");
            entity.Property(e => e.Regular6)
                .HasDefaultValue(0.0)
                .HasColumnType("float");
            entity.Property(e => e.Regular7)
                .HasDefaultValue(0.0)
                .HasColumnType("float");
            entity.Property(e => e.Regular8)
                .HasDefaultValue(0.0)
                .HasColumnType("float");
            entity.Property(e => e.Regular9)
                .HasDefaultValue(0.0)
                .HasColumnType("float");
            entity.Property(e => e.Shift0)
                .HasDefaultValue(0.0)
                .HasColumnType("float");
            entity.Property(e => e.Shift1)
                .HasDefaultValue(0.0)
                .HasColumnType("float");
            entity.Property(e => e.Shift10)
                .HasDefaultValue(0.0)
                .HasColumnType("float");
            entity.Property(e => e.Shift11)
                .HasDefaultValue(0.0)
                .HasColumnType("float");
            entity.Property(e => e.Shift12)
                .HasDefaultValue(0.0)
                .HasColumnType("float");
            entity.Property(e => e.Shift13)
                .HasDefaultValue(0.0)
                .HasColumnType("float");
            entity.Property(e => e.Shift14)
                .HasDefaultValue(0.0)
                .HasColumnType("float");
            entity.Property(e => e.Shift15)
                .HasDefaultValue(0.0)
                .HasColumnType("float");
            entity.Property(e => e.Shift2)
                .HasDefaultValue(0.0)
                .HasColumnType("float");
            entity.Property(e => e.Shift3)
                .HasDefaultValue(0.0)
                .HasColumnType("float");
            entity.Property(e => e.Shift4)
                .HasDefaultValue(0.0)
                .HasColumnType("float");
            entity.Property(e => e.Shift5)
                .HasDefaultValue(0.0)
                .HasColumnType("float");
            entity.Property(e => e.Shift6)
                .HasDefaultValue(0.0)
                .HasColumnType("float");
            entity.Property(e => e.Shift7)
                .HasDefaultValue(0.0)
                .HasColumnType("float");
            entity.Property(e => e.Shift8)
                .HasDefaultValue(0.0)
                .HasColumnType("float");
            entity.Property(e => e.Shift9)
                .HasDefaultValue(0.0)
                .HasColumnType("float");
            entity.Property(e => e.StartStep).HasDefaultValue(0);
        });

        modelBuilder.Entity<LtGradeAllowance>(entity =>
        {
            entity.HasKey(e => new { e.LfGradeCode, e.LfAllowanceCode });

            entity.ToTable("LT_Grade_Allowance");

            entity.HasIndex(e => e.IsActive, "IX_LT_Grade_Allowance");

            entity.Property(e => e.LfGradeCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Grade_Code");
            entity.Property(e => e.LfAllowanceCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Allowance_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.DefaultAmount)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
        });

        modelBuilder.Entity<LtGradeDeduction>(entity =>
        {
            entity.HasKey(e => new { e.LfGradeCode, e.LfDeductionCode }).HasName("PK_LT_Grade_DefaultFixedDeduction");

            entity.ToTable("LT_Grade_Deduction");

            entity.HasIndex(e => e.IsActive, "IX_LT_Grade_Deduction");

            entity.Property(e => e.LfGradeCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Grade_Code");
            entity.Property(e => e.LfDeductionCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Deduction_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.DefaultAmount)
                .HasDefaultValue(0.0)
                .HasColumnType("float");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
        });

        modelBuilder.Entity<LtGradeType>(entity =>
        {
            entity.HasKey(e => e.GradeTypeCode);

            entity.ToTable("LT_GradeType");

            entity.HasIndex(e => e.NameEn, "IX_LT_GradeType").IsUnique();

            entity.HasIndex(e => e.NameAr, "IX_LT_GradeType_1");

            entity.HasIndex(e => e.IsActive, "IX_LT_GradeType_2");

            entity.Property(e => e.GradeTypeCode)
                .HasMaxLength(12)
                .HasColumnName("Grade_TypeCode");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(50)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .HasColumnName("Name_En");
        });

        modelBuilder.Entity<LtIcon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_LT_Icon_ID");

            entity.ToTable("LT_Icon");

            entity.HasIndex(e => e.IconName, "IX_LT_Icon");

            entity.HasIndex(e => e.IsActive, "IX_LT_Icon_1");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.IconName)
                .HasMaxLength(255)
                .HasDefaultValue("");
            entity.Property(e => e.IconType)
                .HasMaxLength(255)
                .HasDefaultValue("iconfont");
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
        });

        modelBuilder.Entity<LtInsurance>(entity =>
        {
            entity.HasKey(e => e.InsuranceTypeCode);

            entity.ToTable("LT_Insurance");

            entity.HasIndex(e => e.NameEn, "IX_LT_Insurance").IsUnique();

            entity.HasIndex(e => e.NameAr, "IX_LT_Insurance_1");

            entity.HasIndex(e => e.IsActive, "IX_LT_Insurance_2");

            entity.Property(e => e.InsuranceTypeCode)
                .HasMaxLength(12)
                .HasColumnName("InsuranceType_Code");
            entity.Property(e => e.AgeLimit).HasDefaultValue((byte)24);
            entity.Property(e => e.ChildLimit).HasDefaultValue((byte)5);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .HasColumnName("Name_En");
            entity.Property(e => e.WifeLimit).HasDefaultValue((byte)1);
        });

        modelBuilder.Entity<LtInsuranceCoverage>(entity =>
        {
            entity.HasKey(e => new { e.LfInsuranceTypeCode, e.LfInsuranceCoverageCode });

            entity.ToTable("LT_InsuranceCoverage");

            entity.HasIndex(e => new { e.IsActive, e.IsValid }, "IX_LT_InsuranceCoverage");

            entity.Property(e => e.LfInsuranceTypeCode)
                .HasMaxLength(12)
                .HasColumnName("LF_InsuranceType_Code");
            entity.Property(e => e.LfInsuranceCoverageCode)
                .HasMaxLength(12)
                .HasColumnName("LF_InsuranceCoverage_Code");
            entity.Property(e => e.CoverageFee)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("Coverage_Fee");
            entity.Property(e => e.CoveragePersentage)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("Coverage_Persentage");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.IsValid)
                .HasDefaultValue(false)
                .HasColumnName("isValid");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Note).HasMaxLength(255);
        });

        modelBuilder.Entity<LtInsuranceHealthCoverage>(entity =>
        {
            entity.HasKey(e => e.InsuranceCoverageCode);

            entity.ToTable("LT_InsuranceHealthCoverage");

            entity.HasIndex(e => e.NameEn, "IX_LT_InsuranceHealthCoverage").IsUnique();

            entity.HasIndex(e => e.IsActive, "IX_LT_InsuranceHealthCoverage_1");

            entity.Property(e => e.InsuranceCoverageCode)
                .HasMaxLength(12)
                .HasColumnName("InsuranceCoverage_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .HasColumnName("Name_En");
        });

        modelBuilder.Entity<LtJobTitle>(entity =>
        {
            entity.HasKey(e => e.JobTitleCode);

            entity.ToTable("LT_JobTitle");

            entity.HasIndex(e => e.NameEn, "IX_LT_JobTitle").IsUnique();

            entity.HasIndex(e => e.NameAr, "IX_LT_JobTitle_1");

            entity.HasIndex(e => e.IsActive, "IX_LT_JobTitle_2");

            entity.Property(e => e.JobTitleCode)
                .HasMaxLength(12)
                .HasColumnName("JobTitle_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.JobDescription).HasColumnName("Job_Description");
            entity.Property(e => e.LfEducationLevelCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Education_Level_Code");
            entity.Property(e => e.LfGradeTypeCodeMax)
                .HasMaxLength(12)
                .HasColumnName("LF_Grade_TypeCodeMax");
            entity.Property(e => e.LfGradeTypeCodeMin)
                .HasMaxLength(12)
                .HasColumnName("LF_Grade_TypeCodeMin");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(120)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(120)
                .HasColumnName("Name_En");
        });

        modelBuilder.Entity<LtLanguage>(entity =>
        {
            entity.HasKey(e => e.LanguageCode);

            entity.ToTable("LT_Language");

            entity.Property(e => e.LanguageCode)
                .HasMaxLength(12)
                .HasColumnName("Language_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .HasColumnName("Name_En");
        });

        modelBuilder.Entity<LtLookupTableReferance>(entity =>
        {
            entity.HasKey(e => e.LookupCode).HasName("PK_LT_LookupTableReferance_1");

            entity.ToTable("LT_LookupTableReferance");

            entity.HasIndex(e => e.NameEn, "IX_LT_LookupTableReferance").IsUnique();

            entity.HasIndex(e => e.NameAr, "IX_LT_LookupTableReferance_1");

            entity.HasIndex(e => e.IsActive, "IX_LT_LookupTableReferance_2");

            entity.Property(e => e.LookupCode).HasMaxLength(4);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.LastSerialNo).HasDefaultValue(0);
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(50)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .HasColumnName("Name_En");
            entity.Property(e => e.PadLeftNo).HasDefaultValue((byte)4);
            entity.Property(e => e.TemporarySerialNo).HasDefaultValue(0);
        });

        modelBuilder.Entity<LtMedicalAllergy>(entity =>
        {
            entity.HasKey(e => e.AllergiesCode).HasName("PK_LT_MedicalAllergies_1");

            entity.ToTable("LT_MedicalAllergies");

            entity.Property(e => e.AllergiesCode)
                .HasMaxLength(12)
                .HasColumnName("Allergies_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.LfParentAllergiesCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Parent_Allergies_Code");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .HasColumnName("Name_En");
        });

        modelBuilder.Entity<LtMedicalDiagnosis>(entity =>
        {
            entity.HasKey(e => new { e.LfMedicalSpecialtyCode, e.DiagnosisCode });

            entity.ToTable("LT_MedicalDiagnosis");

            entity.HasIndex(e => e.NameEn, "IX_LT_MedicalDiagnosis");

            entity.HasIndex(e => e.NameAr, "IX_LT_MedicalDiagnosis_1");

            entity.HasIndex(e => e.IsActive, "IX_LT_MedicalDiagnosis_2");

            entity.Property(e => e.LfMedicalSpecialtyCode)
                .HasMaxLength(12)
                .HasColumnName("LF_MedicalSpecialty_Code");
            entity.Property(e => e.DiagnosisCode)
                .HasMaxLength(12)
                .HasColumnName("Diagnosis_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .HasColumnName("Name_En");
        });

        modelBuilder.Entity<LtMedicalPatientPain>(entity =>
        {
            entity.HasKey(e => new { e.LfMedicalSpecialtyCode, e.PatientPainCode });

            entity.ToTable("LT_MedicalPatientPain");

            entity.Property(e => e.LfMedicalSpecialtyCode)
                .HasMaxLength(12)
                .HasColumnName("LF_MedicalSpecialty_Code");
            entity.Property(e => e.PatientPainCode)
                .HasMaxLength(12)
                .HasColumnName("PatientPain_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .HasColumnName("Name_En");
            entity.Property(e => e.PainDescreption).HasColumnName("Pain_Descreption");
        });

        modelBuilder.Entity<LtMedicalSpecialty>(entity =>
        {
            entity.HasKey(e => e.MedicalSpecialtyCode);

            entity.ToTable("LT_MedicalSpecialty");

            entity.HasIndex(e => e.NameEn, "IX_LT_MedicalSpecialty").IsUnique();

            entity.HasIndex(e => e.NameAr, "IX_LT_MedicalSpecialty_1");

            entity.HasIndex(e => e.IsActive, "IX_LT_MedicalSpecialty_2");

            entity.Property(e => e.MedicalSpecialtyCode)
                .HasMaxLength(12)
                .HasColumnName("MedicalSpecialty_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.MedicalTypeLogo).HasColumnName("medicalTypeLogo");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .HasColumnName("Name_En");
        });

        modelBuilder.Entity<LtMedicalSymptom>(entity =>
        {
            entity.HasKey(e => e.SymptomsCode).HasName("PK_LT_MedicalSymptoms_1");

            entity.ToTable("LT_MedicalSymptoms");

            entity.Property(e => e.SymptomsCode)
                .HasMaxLength(12)
                .HasColumnName("Symptoms_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.LfParentSymptomsCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Parent_Symptoms_Code");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .HasColumnName("Name_En");
        });

        modelBuilder.Entity<LtMedicalTreatment>(entity =>
        {
            entity.HasKey(e => e.TreatmentsCode).HasName("PK_LT_MedicalTreatments_1");

            entity.ToTable("LT_MedicalTreatments");

            entity.Property(e => e.TreatmentsCode)
                .HasMaxLength(12)
                .HasColumnName("Treatments_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.LfMedicalSpecialtyCode)
                .HasMaxLength(12)
                .HasColumnName("LF_MedicalSpecialty_Code");
            entity.Property(e => e.LfParentTreatmentsCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Parent_Treatments_Code");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .HasColumnName("Name_En");
        });

        modelBuilder.Entity<LtPaymentMethod>(entity =>
        {
            entity.HasKey(e => e.PaymentMethodCode).HasName("PK_PaymentT_ID");

            entity.ToTable("LT_PaymentMethod");

            entity.HasIndex(e => e.NameEn, "IX_LT_PaymentMethod").IsUnique();

            entity.HasIndex(e => e.NameAr, "IX_LT_PaymentMethod_1");

            entity.HasIndex(e => new { e.IsActive, e.IsCreditCard, e.IsLoyalityCard }, "IX_LT_PaymentMethod_2");

            entity.Property(e => e.PaymentMethodCode)
                .HasMaxLength(12)
                .HasColumnName("PaymentMethod_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.HotPoint)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.IsCreditCard)
                .HasDefaultValue(false)
                .HasColumnName("isCreditCard");
            entity.Property(e => e.IsLoyalityCard)
                .HasDefaultValue(false)
                .HasColumnName("isLoyalityCard");
            entity.Property(e => e.LfAccountCode)
                .HasMaxLength(30)
                .HasColumnName("LF_AccountCode");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(50)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .HasColumnName("Name_En");
            entity.Property(e => e.ValidityPeriodDay).HasDefaultValue((short)0);
        });

        modelBuilder.Entity<LtPeriod>(entity =>
        {
            entity.HasKey(e => e.PeriodCode);

            entity.ToTable("LT_Period");

            entity.HasIndex(e => e.NameEn, "IX_LT_Period").IsUnique();

            entity.HasIndex(e => e.NameAr, "IX_LT_Period_1");

            entity.HasIndex(e => e.IsActive, "IX_LT_Period_2");

            entity.Property(e => e.PeriodCode)
                .HasMaxLength(12)
                .HasColumnName("Period_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.LfPeriodCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Period_Code");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .HasColumnName("Name_En");
        });

        modelBuilder.Entity<LtProductServiceBrand>(entity =>
        {
            entity.HasKey(e => e.BrandCode).HasName("PK_LT_Prodcut_4_Brand");

            entity.ToTable("LT_ProductService_Brand");

            entity.HasIndex(e => e.NameEn, "IX_LT_ProductService_4_Brand").IsUnique();

            entity.HasIndex(e => e.NameAr, "IX_LT_ProductService_4_Brand_1");

            entity.HasIndex(e => e.IsActive, "IX_LT_ProductService_4_Brand_2");

            entity.Property(e => e.BrandCode)
                .HasMaxLength(12)
                .HasColumnName("Brand_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .HasColumnName("Name_En");
        });

        modelBuilder.Entity<LtProductServiceCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryCode).HasName("PK_LT_ProductCategeory");

            entity.ToTable("LT_ProductService_Category");

            entity.HasIndex(e => e.NameAr, "IX_LT_ProductService_2_Categeory_1");

            entity.HasIndex(e => e.IsActive, "IX_LT_ProductService_2_Categeory_2");

            entity.HasIndex(e => new { e.LfParentCategoryCode, e.NameEn }, "IX_LT_ProductService_2_Category").IsUnique();

            entity.Property(e => e.CategoryCode)
                .HasMaxLength(12)
                .HasColumnName("Category_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.LfAccountCode)
                .HasMaxLength(30)
                .HasColumnName("LF_AccountCode");
            entity.Property(e => e.LfClassificationCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Classification_Code");
            entity.Property(e => e.LfParentCategoryCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Parent_Category_Code");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .HasColumnName("Name_En");
        });

        modelBuilder.Entity<LtProductServiceClassification>(entity =>
        {
            entity.HasKey(e => e.ClassificationCode).HasName("PK_LT_ProductClassification");

            entity.ToTable("LT_ProductService_Classification");

            entity.HasIndex(e => e.NameEn, "IX_LT_ProductCategory").IsUnique();

            entity.HasIndex(e => e.NameAr, "IX_LT_ProductService_1_Classification");

            entity.HasIndex(e => e.IsActive, "IX_LT_ProductService_1_Classification_1");

            entity.Property(e => e.ClassificationCode)
                .HasMaxLength(12)
                .HasColumnName("Classification_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .HasColumnName("Name_En");
        });

        modelBuilder.Entity<LtProductServiceMeasurement>(entity =>
        {
            entity.HasKey(e => e.MeasuremntCode).HasName("PK_LT_Measurement");

            entity.ToTable("LT_ProductService_Measurement");

            entity.HasIndex(e => e.NameEn, "IX_LT_Measurement").IsUnique();

            entity.HasIndex(e => e.MeasurementBreif, "IX_LT_Measurement_1").IsUnique();

            entity.HasIndex(e => e.NameAr, "IX_LT_Measurement_2");

            entity.HasIndex(e => e.IsActive, "IX_LT_Measurement_3");

            entity.Property(e => e.MeasuremntCode)
                .HasMaxLength(12)
                .HasColumnName("Measuremnt_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.MeasurementBreif).HasMaxLength(20);
            entity.Property(e => e.MeasurementType).HasMaxLength(50);
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(50)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .HasColumnName("Name_En");
        });

        modelBuilder.Entity<LtProject>(entity =>
        {
            entity.HasKey(e => e.ProjectCode).HasName("PK_LT_ProjectID");

            entity.ToTable("LT_Project");

            entity.HasIndex(e => e.NameEn, "IX_LT_Project").IsUnique();

            entity.HasIndex(e => e.NameAr, "IX_LT_Project_1");

            entity.HasIndex(e => e.IsActive, "IX_LT_Project_2");

            entity.Property(e => e.ProjectCode)
                .HasMaxLength(12)
                .HasColumnName("Project_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.LfAccountCode)
                .HasMaxLength(30)
                .HasColumnName("LF_Account_Code");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .HasColumnName("Name_En");
        });

        modelBuilder.Entity<LtPurchaseStatus>(entity =>
        {
            entity.HasKey(e => e.PurchaseStatusCode).HasName("PK_PurchasesStatus");

            entity.ToTable("LT_Purchase_Status");

            entity.Property(e => e.PurchaseStatusCode)
                .HasMaxLength(12)
                .HasColumnName("PurchaseStatus_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(220)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(220)
                .HasColumnName("Name_En");
        });

        modelBuilder.Entity<LtRelationShip>(entity =>
        {
            entity.HasKey(e => e.RelationShipCode);

            entity.ToTable("LT_RelationShip");

            entity.HasIndex(e => e.NameEn, "IX_LT_RelationShip").IsUnique();

            entity.HasIndex(e => e.NameAr, "IX_LT_RelationShip_1");

            entity.HasIndex(e => e.IsActive, "IX_LT_RelationShip_2");

            entity.Property(e => e.RelationShipCode)
                .HasMaxLength(12)
                .HasColumnName("RelationShip_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .HasColumnName("Name_En");
        });

        modelBuilder.Entity<LtRelegion>(entity =>
        {
            entity.HasKey(e => e.RelegionCode);

            entity.ToTable("LT_Relegion");

            entity.HasIndex(e => e.NameEn, "IX_LT_Relegion").IsUnique();

            entity.HasIndex(e => e.NameAr, "IX_LT_Relegion_1");

            entity.HasIndex(e => e.IsActive, "IX_LT_Relegion_2");

            entity.Property(e => e.RelegionCode)
                .HasMaxLength(12)
                .HasColumnName("Relegion_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .HasColumnName("Name_En");
        });

        modelBuilder.Entity<LtRequest1Type>(entity =>
        {
            entity.HasKey(e => e.RequestTypeCode);

            entity.ToTable("LT_Request_1_Type");

            entity.HasIndex(e => e.NameEn, "IX_LT_Request_1_Type").IsUnique();

            entity.HasIndex(e => e.NameAr, "IX_LT_Request_1_Type_1");

            entity.HasIndex(e => e.IsActive, "IX_LT_Request_1_Type_2");

            entity.Property(e => e.RequestTypeCode)
                .HasMaxLength(12)
                .HasColumnName("RequestType_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .HasColumnName("Name_En");
        });

        modelBuilder.Entity<LtRequest2Channal>(entity =>
        {
            entity.HasKey(e => e.RequestTypeChannal).HasName("PK_109_Channal");

            entity.ToTable("LT_Request_2_Channal");

            entity.HasIndex(e => e.NameEn, "IX_LT_Request_2_Channal").IsUnique();

            entity.HasIndex(e => e.NameAr, "IX_LT_Request_2_Channal_1");

            entity.HasIndex(e => e.IsActive, "IX_LT_Request_2_Channal_2");

            entity.Property(e => e.RequestTypeChannal)
                .HasMaxLength(12)
                .HasColumnName("RequestType_Channal");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(50)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .HasColumnName("Name_En");
        });

        modelBuilder.Entity<LtReward>(entity =>
        {
            entity.HasKey(e => e.RewardCode);

            entity.ToTable("LT_Reward");

            entity.HasIndex(e => e.NameEn, "IX_LT_Reward").IsUnique();

            entity.HasIndex(e => e.NameAr, "IX_LT_Reward_1");

            entity.HasIndex(e => e.IsActive, "IX_LT_Reward_2");

            entity.Property(e => e.RewardCode)
                .HasMaxLength(12)
                .HasColumnName("Reward_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .HasColumnName("Name_En");
        });

        modelBuilder.Entity<LtShippingMethod>(entity =>
        {
            entity.HasKey(e => e.ShippingMethodCode).HasName("PK_ShippingMethod");

            entity.ToTable("LT_Shipping_Method");

            entity.Property(e => e.ShippingMethodCode)
                .HasMaxLength(12)
                .HasColumnName("ShippingMethod_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(220)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(220)
                .HasColumnName("Name_En");
        });

        modelBuilder.Entity<LtShippingTerm>(entity =>
        {
            entity.HasKey(e => e.ShippingTermCode).HasName("PK_ShippingTerm");

            entity.ToTable("LT_Shipping_Term");

            entity.Property(e => e.ShippingTermCode)
                .HasMaxLength(12)
                .HasColumnName("ShippingTerm_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr).HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn).HasColumnName("Name_En");
        });

        modelBuilder.Entity<LtSocialStatus>(entity =>
        {
            entity.HasKey(e => e.SocialStatusCode);

            entity.ToTable("LT_SocialStatus");

            entity.HasIndex(e => e.NameEn, "IX_LT_SocialStatus").IsUnique();

            entity.HasIndex(e => e.NameAr, "IX_LT_SocialStatus_1");

            entity.HasIndex(e => e.IsActive, "IX_LT_SocialStatus_2");

            entity.Property(e => e.SocialStatusCode)
                .HasMaxLength(12)
                .HasColumnName("Social_Status_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .HasColumnName("Name_En");
        });

        modelBuilder.Entity<LtSupplierGroupType>(entity =>
        {
            entity.HasKey(e => e.SupplierGroupCode).HasName("PK_SupplierGroupTypeID");

            entity.ToTable("LT_SupplierGroupType");

            entity.HasIndex(e => e.NameEn, "IX_LT_SupplierGroupType").IsUnique();

            entity.HasIndex(e => e.NameAr, "IX_LT_SupplierGroupType_1");

            entity.HasIndex(e => new { e.IsActive, e.IsDefault }, "IX_LT_SupplierGroupType_2");

            entity.Property(e => e.SupplierGroupCode)
                .HasMaxLength(12)
                .HasColumnName("SupplierGroup_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.IsDefault).HasColumnName("isDefault");
            entity.Property(e => e.LfAccountCode)
                .HasMaxLength(30)
                .HasColumnName("LF_AccountCode");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(50)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .HasColumnName("Name_En");
        });

        modelBuilder.Entity<LtTask1Impact>(entity =>
        {
            entity.HasKey(e => e.ImpactCode);

            entity.ToTable("LT_Task_1_Impact");

            entity.HasIndex(e => e.NameEn, "IX_LT_Task_1_Impact").IsUnique();

            entity.HasIndex(e => e.NameAr, "IX_LT_Task_1_Impact_1");

            entity.HasIndex(e => e.IsActive, "IX_LT_Task_1_Impact_2");

            entity.Property(e => e.ImpactCode)
                .HasMaxLength(12)
                .HasColumnName("Impact_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(50)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .HasColumnName("Name_En");
        });

        modelBuilder.Entity<LtTask2Urgency>(entity =>
        {
            entity.HasKey(e => e.UrgencyCode);

            entity.ToTable("LT_Task_2_Urgency");

            entity.HasIndex(e => e.NameEn, "IX_LT_Task_2_Urgency").IsUnique();

            entity.HasIndex(e => e.NameAr, "IX_LT_Task_2_Urgency_1");

            entity.HasIndex(e => e.IsActive, "IX_LT_Task_2_Urgency_2");

            entity.Property(e => e.UrgencyCode)
                .HasMaxLength(12)
                .HasColumnName("Urgency_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(50)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .HasColumnName("Name_En");
        });

        modelBuilder.Entity<LtTask3Priority>(entity =>
        {
            entity.ToTable("LT_Task_3_Priority");

            entity.HasIndex(e => e.NameEn, "IX_LT_Task_3_Priority").IsUnique();

            entity.HasIndex(e => e.NameAr, "IX_LT_Task_3_Priority_1");

            entity.HasIndex(e => e.IsActive, "IX_LT_Task_3_Priority_2");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.HourServe).HasDefaultValue(48);
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.IsDefault).HasColumnName("isDefault");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(50)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .HasColumnName("Name_En");
            entity.Property(e => e.PriorityCode)
                .HasMaxLength(12)
                .HasColumnName("Priority_Code");
        });

        modelBuilder.Entity<LtTask4PriorityMatrix>(entity =>
        {
            entity.HasKey(e => e.PriorityMatrixCode);

            entity.ToTable("LT_Task_4_PriorityMatrix");

            entity.HasIndex(e => new { e.LfImpactId, e.LfPriorityId, e.LfUrgencyId }, "IX_LT_Task_4_PriorityMatrix").IsUnique();

            entity.HasIndex(e => e.IsActive, "IX_LT_Task_4_PriorityMatrix_1");

            entity.Property(e => e.PriorityMatrixCode)
                .HasMaxLength(12)
                .HasColumnName("PriorityMatrix_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.LfImpactId).HasColumnName("LF_Impact_ID");
            entity.Property(e => e.LfPriorityId).HasColumnName("LF_Priority_ID");
            entity.Property(e => e.LfUrgencyId).HasColumnName("LF_Urgency_ID");
            entity.Property(e => e.MatrixWeight).HasComputedColumnSql("(([LF_Impact_ID]*[LF_Urgency_ID])*[LF_Priority_ID])", false);
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.PriorityRanking).HasComputedColumnSql("(case when ([LF_Impact_ID]*[LF_Urgency_ID])*[LF_Priority_ID]<=(8) then (1) when ([LF_Impact_ID]*[LF_Urgency_ID])*[LF_Priority_ID]<(20) then (2) when ([LF_Impact_ID]*[LF_Urgency_ID])*[LF_Priority_ID]<=(30) then (3) when ([LF_Impact_ID]*[LF_Urgency_ID])*[LF_Priority_ID]<=(60) then (4) else (5) end)", false);
        });

        modelBuilder.Entity<LtTask5Rate>(entity =>
        {
            entity.HasKey(e => e.RatingCode).HasName("PK_LT_Task_4_Rating");

            entity.ToTable("LT_Task_5_Rate");

            entity.HasIndex(e => e.NameEn, "IX_LT_Task_5_Rate").IsUnique();

            entity.HasIndex(e => e.NameAr, "IX_LT_Task_5_Rate_1");

            entity.HasIndex(e => e.IsActive, "IX_LT_Task_5_Rate_2");

            entity.Property(e => e.RatingCode)
                .HasMaxLength(12)
                .HasColumnName("Rating_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(50)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .HasColumnName("Name_En");
        });

        modelBuilder.Entity<LtTask6Tier>(entity =>
        {
            entity.HasKey(e => e.TierCode);

            entity.ToTable("LT_Task_6_Tier");

            entity.HasIndex(e => e.NameEn, "IX_LT_Task_6_Tier").IsUnique();

            entity.HasIndex(e => e.NameAr, "IX_LT_Task_6_Tier_1");

            entity.HasIndex(e => e.IsActive, "IX_LT_Task_6_Tier_2");

            entity.Property(e => e.TierCode)
                .HasMaxLength(12)
                .HasColumnName("Tier_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(50)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .HasColumnName("Name_En");
        });

        modelBuilder.Entity<LtTax>(entity =>
        {
            entity.HasKey(e => e.TaxCode);

            entity.ToTable("LT_Tax");

            entity.HasIndex(e => e.NameEn, "IX_LT_Tax").IsUnique();

            entity.HasIndex(e => e.NameAr, "IX_LT_Tax_1");

            entity.HasIndex(e => e.IsActive, "IX_LT_Tax_2");

            entity.Property(e => e.TaxCode)
                .HasMaxLength(12)
                .HasColumnName("Tax_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.DateImplemented).HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.IsDefault)
                .HasDefaultValue(false)
                .HasColumnName("isDefault");
            entity.Property(e => e.LfAccountCode)
                .HasMaxLength(30)
                .HasColumnName("LF_AccountCode");
            entity.Property(e => e.LfTaxGroupCode)
                .HasMaxLength(12)
                .HasColumnName("LF_TaxGroup_Code");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(50)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .HasColumnName("Name_En");
            entity.Property(e => e.Rate)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
        });

        modelBuilder.Entity<LtTaxGroup>(entity =>
        {
            entity.HasKey(e => e.TaxGroupCode).HasName("PK_TaxGroupID");

            entity.ToTable("LT_TaxGroup");

            entity.HasIndex(e => e.NameEn, "IX_LT_TaxGroup").IsUnique();

            entity.HasIndex(e => e.NameAr, "IX_LT_TaxGroup_1");

            entity.HasIndex(e => new { e.IsActive, e.TaxAppliedToShipping }, "IX_LT_TaxGroup_2");

            entity.Property(e => e.TaxGroupCode)
                .HasMaxLength(12)
                .HasColumnName("TaxGroup_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(50)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .HasColumnName("Name_En");
            entity.Property(e => e.TaxAppliedToShipping).HasDefaultValue(false);
        });

        modelBuilder.Entity<LtWorkFlowStatus>(entity =>
        {
            entity.HasKey(e => e.WorkFlowStatusCode).HasName("PK_DocumentStatusID");

            entity.ToTable("LT_WorkFlowStatus");

            entity.HasIndex(e => e.NameEn, "IX_LT_DocumentStatus").IsUnique();

            entity.HasIndex(e => e.NameAr, "IX_LT_WorkFlowStatus");

            entity.HasIndex(e => e.IsActive, "IX_LT_WorkFlowStatus_1");

            entity.Property(e => e.WorkFlowStatusCode)
                .HasMaxLength(12)
                .HasColumnName("WorkFlowStatus_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(50)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .HasColumnName("Name_En");
        });

        modelBuilder.Entity<SmMenu>(entity =>
        {
            entity.ToTable("SM_Menu");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Form).HasMaxLength(50);
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.LfParentMenuId).HasColumnName("LF_Parent_Menu_Id");
            entity.Property(e => e.Macro).HasMaxLength(50);
            entity.Property(e => e.MenuSortOrder)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("Menu_Sort_Order");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .UseCollation("Arabic_CI_AS")
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .UseCollation("Arabic_CI_AS")
                .HasColumnName("Name_En");
            entity.Property(e => e.Report).HasMaxLength(50);
        });

        modelBuilder.Entity<SmMenuPermission>(entity =>
        {
            entity.HasKey(e => new { e.LfRoleId, e.LfMenuId });

            entity.ToTable("SM_Menu_Permission");

            entity.HasIndex(e => e.IsActive, "IX_SM_Menu_Permission");

            entity.Property(e => e.LfRoleId).HasColumnName("LF_Role_Id");
            entity.Property(e => e.LfMenuId).HasColumnName("LF_Menu_Id");
            entity.Property(e => e.AddF).HasDefaultValue(true);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.DeleteF).HasDefaultValue(true);
            entity.Property(e => e.DownLoadF).HasDefaultValue(true);
            entity.Property(e => e.EditF).HasDefaultValue(true);
            entity.Property(e => e.ExportF).HasDefaultValue(true);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.PrintF).HasDefaultValue(true);
            entity.Property(e => e.SearchF).HasDefaultValue(true);
            entity.Property(e => e.UploadF).HasDefaultValue(true);
            entity.Property(e => e.ViewF).HasDefaultValue(false);

            entity.HasOne(d => d.LfMenu).WithMany(p => p.SmMenuPermissions)
                .HasForeignKey(d => d.LfMenuId)
                .HasConstraintName("FK_SM_Menu_Permission_SM_Menu");

            entity.HasOne(d => d.LfRole).WithMany(p => p.SmMenuPermissions)
                .HasForeignKey(d => d.LfRoleId)
                .HasConstraintName("FK_SM_Menu_Permission_tblRole");
        });

        modelBuilder.Entity<SmOption>(entity =>
        {
            entity.HasKey(e => e.CriteriaName).HasName("PK_STR_CompanyOption_1");

            entity.ToTable("SM_Option");

            entity.Property(e => e.CriteriaName)
                .HasMaxLength(100)
                .UseCollation("Arabic_CI_AS");
            entity.Property(e => e.CriteriaValue)
                .HasMaxLength(200)
                .UseCollation("Arabic_CI_AS");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<StrCompany>(entity =>
        {
            entity.HasKey(e => e.CompanyCode);

            entity.ToTable("STR_Company");

            entity.HasIndex(e => e.NameEn, "IX_STR_Company").IsUnique();

            entity.HasIndex(e => e.NameAr, "IX_STR_Company_1");

            entity.HasIndex(e => e.IsActive, "IX_STR_Company_2");

            entity.Property(e => e.CompanyCode)
                .HasMaxLength(12)
                .HasColumnName("Company_Code");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.ContactEmail).HasMaxLength(75);
            entity.Property(e => e.ContactFaxNo).HasMaxLength(15);
            entity.Property(e => e.ContactMobileNo).HasMaxLength(15);
            entity.Property(e => e.ContactPerson).HasMaxLength(100);
            entity.Property(e => e.ContactTelNo).HasMaxLength(15);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.LatLong)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LfDivisionTypeCode)
                .HasMaxLength(12)
                .HasColumnName("LF_DivisionType_Code");
            entity.Property(e => e.LfParentCompanyCode)
                .HasMaxLength(12)
                .HasColumnName("LF_ParentCompany_Code");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .HasColumnName("Name_En");
            entity.Property(e => e.Pobox)
                .HasMaxLength(75)
                .HasColumnName("POBox");
            entity.Property(e => e.VarStartRegistrationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("Var_StartRegistrationDate");
            entity.Property(e => e.VatRegistrationNumber)
                .HasMaxLength(50)
                .HasColumnName("Vat_RegistrationNumber");
            entity.Property(e => e.WebSite).HasMaxLength(75);
        });

        modelBuilder.Entity<StrCompanyAttachment>(entity =>
        {
            entity.HasKey(e => new { e.LfCompanyCode, e.LfAttachmentTypeCode, e.AttchmentFileName }).HasName("PK_STR_Company_Attachment_1");

            entity.ToTable("STR_Company_Attachment");

            entity.Property(e => e.LfCompanyCode)
                .HasMaxLength(12)
                .HasDefaultValueSql("((0))")
                .HasColumnName("LF_Company_Code");
            entity.Property(e => e.LfAttachmentTypeCode)
                .HasMaxLength(12)
                .HasColumnName("LF_AttachmentType_Code");
            entity.Property(e => e.AttchmentFileName).HasMaxLength(100);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.EndDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("End_Date");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.StartDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("Start_Date");
        });

        modelBuilder.Entity<StrCompanyBank>(entity =>
        {
            entity.HasKey(e => e.BankCode);

            entity.ToTable("STR_CompanyBank");

            entity.HasIndex(e => new { e.LfDivisionCode, e.LfBankCode, e.LfBankAccountTypeCode }, "IX_STR_CompanyBank").IsUnique();

            entity.Property(e => e.BankCode)
                .HasMaxLength(12)
                .HasColumnName("Bank_Code");
            entity.Property(e => e.BankAccountNo)
                .HasMaxLength(50)
                .HasColumnName("Bank_AccountNo");
            entity.Property(e => e.BankIban)
                .HasMaxLength(50)
                .HasColumnName("Bank_IBAN");
            entity.Property(e => e.BankSwift)
                .HasMaxLength(50)
                .HasColumnName("Bank_Swift");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.IsBankReconcilation)
                .HasDefaultValue(false)
                .HasColumnName("isBankReconcilation");
            entity.Property(e => e.IsCheckPrinting)
                .HasDefaultValue(false)
                .HasColumnName("isCheckPrinting");
            entity.Property(e => e.LfAccountCode)
                .HasMaxLength(30)
                .HasColumnName("LF_AccountCode");
            entity.Property(e => e.LfBankAccountTypeCode)
                .HasMaxLength(12)
                .HasDefaultValue("BANT-0002")
                .HasColumnName("LF_BankAccountType_Code");
            entity.Property(e => e.LfBankCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Bank_Code");
            entity.Property(e => e.LfCurrencyCode)
                .HasMaxLength(12)
                .HasDefaultValue("CUR-0007")
                .HasColumnName("LF_Currency_Code");
            entity.Property(e => e.LfDivisionCode)
                .HasMaxLength(12)
                .HasDefaultValue("COM-0001")
                .HasColumnName("LF_Division_Code");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Note).HasMaxLength(200);
        });

        modelBuilder.Entity<StrCompanyDivision>(entity =>
        {
            entity.HasKey(e => e.DivisionCode).HasName("PK_STR_CompanyDivisionID");

            entity.ToTable("STR_CompanyDivision");

            entity.HasIndex(e => new { e.LfCompanyCode, e.DivisionCode }, "IX_STR_CompanyDivision").IsUnique();

            entity.HasIndex(e => new { e.NameEn, e.NameAr }, "IX_STR_CompanyDivision_1");

            entity.HasIndex(e => new { e.IsActive, e.IsCostCenter }, "IX_STR_CompanyDivision_2");

            entity.Property(e => e.DivisionCode)
                .HasMaxLength(12)
                .HasColumnName("Division_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.IsCostCenter)
                .HasDefaultValue(false)
                .HasColumnName("isCostCenter");
            entity.Property(e => e.IsPos)
                .HasDefaultValue(false)
                .HasColumnName("isPOS");
            entity.Property(e => e.IsStore)
                .HasDefaultValue(false)
                .HasColumnName("isStore");
            entity.Property(e => e.LfAccountCode)
                .HasMaxLength(30)
                .HasColumnName("LF_AccountCode");
            entity.Property(e => e.LfCompanyCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Company_Code");
            entity.Property(e => e.LfDivisionTypeCode)
                .HasMaxLength(12)
                .HasColumnName("LF_DivisionType_Code");
            entity.Property(e => e.LfEmployeeCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Employee_Code");
            entity.Property(e => e.LfParentDivisionCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Parent_Division_Code");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(50)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .HasColumnName("Name_En");
            entity.Property(e => e.ReportFooter).UseCollation("Arabic_CI_AI");
            entity.Property(e => e.ReportHeader).UseCollation("Arabic_CI_AI");
            entity.Property(e => e.VatRegistrationNumber)
                .HasMaxLength(50)
                .UseCollation("Arabic_CI_AI")
                .HasColumnName("Vat_RegistrationNumber");
        });

        modelBuilder.Entity<StrCompanyLocation>(entity =>
        {
            entity.HasKey(e => e.LocationCode).HasName("PK_STR_Company_Location");

            entity.ToTable("STR_CompanyLocation");

            entity.Property(e => e.LocationCode)
                .HasMaxLength(12)
                .HasColumnName("Location_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Floor).HasMaxLength(50);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.LfDivisionCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Division_Code");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.OfficeNo).HasMaxLength(50);
            entity.Property(e => e.Place).HasMaxLength(50);
        });

        modelBuilder.Entity<StrEmployee>(entity =>
        {
            entity.HasKey(e => e.EmployeeCode).HasName("PK_tblUsers");

            entity.ToTable("STR_Employee");

            entity.HasIndex(e => new { e.EmployeeCode, e.LfGradeCode }, "IX_STR_Employee").IsUnique();

            entity.HasIndex(e => new { e.Cpr, e.NameEn, e.NameAr }, "IX_STR_Employee_1");

            entity.HasIndex(e => e.IsActive, "IX_STR_Employee_2");

            entity.Property(e => e.EmployeeCode)
                .HasMaxLength(12)
                .HasDefaultValueSql("((0))")
                .HasColumnName("Employee_Code");
            entity.Property(e => e.AccessCardIsActive).HasDefaultValue(true);
            entity.Property(e => e.AccessCardNo).HasMaxLength(50);
            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.Cpr)
                .HasMaxLength(9)
                .HasColumnName("CPR");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.DateContractEnd)
                .HasColumnType("smalldatetime")
                .HasColumnName("Date_Contract_End");
            entity.Property(e => e.DateContractRenew)
                .HasColumnType("smalldatetime")
                .HasColumnName("Date_Contract_Renew");
            entity.Property(e => e.DateContractStart)
                .HasColumnType("smalldatetime")
                .HasColumnName("Date_Contract_Start");
            entity.Property(e => e.DateDiscontinued)
                .HasColumnType("smalldatetime")
                .HasColumnName("Date_Discontinued");
            entity.Property(e => e.DateEmployemnt)
                .HasColumnType("smalldatetime")
                .HasColumnName("Date_Employemnt");
            entity.Property(e => e.DateOfBirth)
                .HasColumnType("smalldatetime")
                .HasColumnName("Date_of_Birth");
            entity.Property(e => e.DateStartService)
                .HasColumnType("smalldatetime")
                .HasColumnName("Date_StartService");
            entity.Property(e => e.DiscontinuedReason)
                .HasMaxLength(100)
                .HasColumnName("Discontinued_Reason");
            entity.Property(e => e.EmployeeId)
                .ValueGeneratedOnAdd()
                .HasColumnName("EmployeeID");
            entity.Property(e => e.GosiDiscontinuedDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("GOSI_Discontinued_Date");
            entity.Property(e => e.GosiNumber)
                .HasMaxLength(50)
                .HasColumnName("GOSI_Number");
            entity.Property(e => e.GosiRegistrationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("GOSI_Registration_Date");
            entity.Property(e => e.GosiRenwalDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("GOSI_Renwal_Date");
            entity.Property(e => e.GradeStepNo)
                .HasDefaultValue(0)
                .HasColumnName("Grade_Step_No");
            entity.Property(e => e.GratuityIndemnityEntitlementEdate).HasColumnType("smalldatetime");
            entity.Property(e => e.GratuityIndemnityEntitlementSdate).HasColumnType("smalldatetime");
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.IsHeathCareAppointment)
                .HasDefaultValue(false)
                .HasColumnName("isHeathCareAppointment");
            entity.Property(e => e.LfAbbreviationCode)
                .HasMaxLength(12)
                .HasDefaultValue("ABBR-0002")
                .HasColumnName("LF_Abbreviation_Code");
            entity.Property(e => e.LfBloodCode)
                .HasMaxLength(12)
                .HasDefaultValue("BLOD-0002")
                .HasColumnName("LF_Blood_Code");
            entity.Property(e => e.LfCompanyCode)
                .HasMaxLength(12)
                .HasDefaultValue("COM-0001")
                .HasColumnName("LF_Company_Code");
            entity.Property(e => e.LfCompanyLocationCode)
                .HasMaxLength(12)
                .HasDefaultValue("LOC-0001")
                .HasColumnName("LF_Company_Location_Code");
            entity.Property(e => e.LfContractTypeCode)
                .HasMaxLength(12)
                .HasDefaultValue("CONT-0007")
                .HasColumnName("LF_ContractType_Code");
            entity.Property(e => e.LfCountryCodeNationality)
                .HasMaxLength(12)
                .HasDefaultValue("CTR-0001")
                .HasColumnName("LF_Country_Code_Nationality");
            entity.Property(e => e.LfCurrencyCode)
                .HasMaxLength(12)
                .HasDefaultValue("CUR-0007")
                .HasColumnName("LF_Currency_Code");
            entity.Property(e => e.LfDiscontinuedCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Discontinued_Code");
            entity.Property(e => e.LfDivisionCode)
                .HasMaxLength(12)
                .HasDefaultValue("DIV-0001")
                .HasColumnName("LF_Division_Code");
            entity.Property(e => e.LfEmployeeCodeDelegator)
                .HasMaxLength(12)
                .HasDefaultValueSql("((0))")
                .HasColumnName("LF_Employee_Code_Delegator");
            entity.Property(e => e.LfEmployeeCodeManager)
                .HasMaxLength(12)
                .HasDefaultValueSql("((0))")
                .HasColumnName("LF_Employee_Code_Manager");
            entity.Property(e => e.LfGenderCode)
                .HasMaxLength(12)
                .HasDefaultValue("GEND-0002")
                .HasColumnName("LF_Gender_Code");
            entity.Property(e => e.LfGradeCode)
                .HasMaxLength(12)
                .HasDefaultValue("GRAD-0028")
                .HasColumnName("LF_Grade_Code");
            entity.Property(e => e.LfJobTitleCode)
                .HasMaxLength(12)
                .HasDefaultValue("JOBT-0015")
                .HasColumnName("LF_JobTitle_Code");
            entity.Property(e => e.LfNoticePeriodCode)
                .HasMaxLength(12)
                .HasDefaultValue("PERI-0005")
                .HasColumnName("LF_Notice_Period_Code");
            entity.Property(e => e.LfPattern)
                .HasMaxLength(12)
                .HasDefaultValue("PATT-0001")
                .HasColumnName("LF_Pattern");
            entity.Property(e => e.LfPaymentMethodCode)
                .HasMaxLength(12)
                .HasDefaultValue("PYTY-0009")
                .HasColumnName("LF_PaymentMethod_Code");
            entity.Property(e => e.LfPaymentPeriodCode)
                .HasMaxLength(12)
                .HasDefaultValue("PERI-0005")
                .HasColumnName("LF_Payment_Period_Code");
            entity.Property(e => e.LfPorbationPeriodCode)
                .HasMaxLength(12)
                .HasDefaultValue("PERI-0005")
                .HasColumnName("LF_Porbation_Period_Code");
            entity.Property(e => e.LfRelegionCode)
                .HasMaxLength(12)
                .HasDefaultValue("RELG-0001")
                .HasColumnName("LF_Relegion_Code");
            entity.Property(e => e.LfSocialStatusCode)
                .HasMaxLength(12)
                .HasDefaultValue("SOST-0003")
                .HasColumnName("LF_Social_Status_Code");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .HasColumnName("Name_En");
            entity.Property(e => e.NoticePeriod).HasDefaultValue(1);
            entity.Property(e => e.OfficeTelephone).HasMaxLength(15);
            entity.Property(e => e.OfficialEmail).HasMaxLength(50);
            entity.Property(e => e.PaymentEnd).HasDefaultValue(30);
            entity.Property(e => e.PaymentStart).HasDefaultValue(1);
            entity.Property(e => e.PersonalEmail).HasMaxLength(50);
            entity.Property(e => e.PlaceOfBirth)
                .HasMaxLength(50)
                .HasColumnName("Place_Of_Birth");
            entity.Property(e => e.PorbationPeriod).HasDefaultValue(3);
            entity.Property(e => e.PrimaryMobile).HasMaxLength(15);
            entity.Property(e => e.Qr).HasColumnName("QR");
            entity.Property(e => e.SecondaryMobile).HasMaxLength(15);
            entity.Property(e => e.StopReason)
                .HasMaxLength(50)
                .HasColumnName("Stop_Reason");
            entity.Property(e => e.StopTillDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("Stop_Till_Date");
        });

        modelBuilder.Entity<StrEmployeeAirTicket>(entity =>
        {
            entity.HasKey(e => new { e.LfEmployeeCode, e.Cpr });

            entity.ToTable("STR_Employee_AirTicket");

            entity.HasIndex(e => e.IsActive, "IX_STR_Employee_AirTicket");

            entity.Property(e => e.LfEmployeeCode)
                .HasMaxLength(12)
                .HasDefaultValueSql("((0))")
                .HasColumnName("LF_Employee_Code");
            entity.Property(e => e.Cpr)
                .HasMaxLength(9)
                .HasColumnName("CPR");
            entity.Property(e => e.AllowanceMonth).HasMaxLength(3);
            entity.Property(e => e.CompensationPersentage)
                .HasDefaultValue(0.0)
                .HasColumnType("float");
            entity.Property(e => e.CompensationValue)
                .HasDefaultValue(0.0)
                .HasColumnType("float");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.DeserveTicket).HasDefaultValue((byte)0);
            entity.Property(e => e.EffectiveDateStart).HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.InEveryPeriod).HasDefaultValue((byte)0);
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.LfCountrySectorCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Country_Sector_Code");
            entity.Property(e => e.LfPeriodCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Period_Code");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.OpenTicket).HasDefaultValue((byte)0);
        });

        modelBuilder.Entity<StrEmployeeAirTicketHistory>(entity =>
        {
            entity.HasKey(e => new { e.LfEmployeeCode, e.Cpr });

            entity.ToTable("STR_Employee_AirTicket_History");

            entity.HasIndex(e => e.IsActive, "IX_STR_Employee_AirTicket_History");

            entity.Property(e => e.LfEmployeeCode)
                .HasMaxLength(12)
                .HasDefaultValueSql("((0))")
                .HasColumnName("LF_Employee_Code");
            entity.Property(e => e.Cpr)
                .HasMaxLength(9)
                .HasColumnName("CPR");
            entity.Property(e => e.ActualValue)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.CompensationPersentage)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.CompensationValue)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.DateReturn).HasColumnType("smalldatetime");
            entity.Property(e => e.DateTaken).HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.LfCountrySectorCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Country_Sector_Code");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Note).HasMaxLength(50);
        });

        modelBuilder.Entity<StrEmployeeAllowance>(entity =>
        {
            entity.HasKey(e => new { e.LfEmployeeCode, e.LfGradeCode, e.LfAllowanceCode }).HasName("PK_STR_Employee_FixedAllowance");

            entity.ToTable("STR_Employee_Allowance");

            entity.HasIndex(e => e.IsActive, "IX_STR_Employee_Allowance");

            entity.Property(e => e.LfEmployeeCode)
                .HasMaxLength(12)
                .HasDefaultValueSql("((0))")
                .HasColumnName("LF_Employee_Code");
            entity.Property(e => e.LfGradeCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Grade_Code");
            entity.Property(e => e.LfAllowanceCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Allowance_Code");
            entity.Property(e => e.AllowanceAmount)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.EndDate).HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Note)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.StartDate).HasColumnType("smalldatetime");
        });

        modelBuilder.Entity<StrEmployeeAttachment>(entity =>
        {
            entity.HasKey(e => new { e.LfEmployeeCode, e.LfAttachmentTypeCode, e.AttchmentFileName }).HasName("PK_STR_Employee_Attachment_1");

            entity.ToTable("STR_Employee_Attachment");

            entity.HasIndex(e => e.IsActive, "IX_STR_Employee_Attachment");

            entity.Property(e => e.LfEmployeeCode)
                .HasMaxLength(12)
                .HasDefaultValueSql("((0))")
                .HasColumnName("LF_Employee_Code");
            entity.Property(e => e.LfAttachmentTypeCode)
                .HasMaxLength(12)
                .HasColumnName("LF_AttachmentType_Code");
            entity.Property(e => e.AttchmentFileName).HasMaxLength(100);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.EndDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("End_Date");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.StartDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("Start_Date");
        });

        modelBuilder.Entity<StrEmployeeBank>(entity =>
        {
            entity.HasKey(e => new { e.LfEmployeeCode, e.Iban }).HasName("PK_STR_Employee_BankInfo");

            entity.ToTable("STR_Employee_Bank");

            entity.HasIndex(e => e.IsActive, "IX_STR_Employee_Bank");

            entity.Property(e => e.LfEmployeeCode)
                .HasMaxLength(12)
                .HasDefaultValueSql("((0))")
                .HasColumnName("LF_Employee_Code");
            entity.Property(e => e.Iban)
                .HasMaxLength(22)
                .HasColumnName("IBAN");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.LfBankCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Bank_Code");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
        });

        modelBuilder.Entity<StrEmployeeCareerDevelopment>(entity =>
        {
            entity.HasKey(e => new { e.CareerDevelopmentDate, e.LfEmployeeCode, e.LfGradeCode, e.GradeStep });

            entity.ToTable("STR_Employee_CareerDevelopment");

            entity.HasIndex(e => e.IsActive, "IX_STR_Employee_CareerDevelopment");

            entity.Property(e => e.CareerDevelopmentDate).HasColumnType("smalldatetime");
            entity.Property(e => e.LfEmployeeCode)
                .HasMaxLength(12)
                .HasDefaultValueSql("((0))")
                .HasColumnName("LF_Employee_Code");
            entity.Property(e => e.LfGradeCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Grade_Code");
            entity.Property(e => e.GradeStep).HasColumnName("Grade_Step");
            entity.Property(e => e.AttachmentFileName).HasMaxLength(100);
            entity.Property(e => e.BasicSalary)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.Car)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Differnace)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.House)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.Living)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Note).HasMaxLength(100);
            entity.Property(e => e.Social)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.Tel)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.Transportation)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
        });

        modelBuilder.Entity<StrEmployeeCertificate>(entity =>
        {
            entity.HasKey(e => new { e.LfEmployeeCode, e.LfEducationLevelCode, e.AcadimicQualification, e.LfCountryCode, e.AcadmicSource });

            entity.ToTable("STR_Employee_Certificate");

            entity.HasIndex(e => e.IsActive, "IX_STR_Employee_Certificate");

            entity.Property(e => e.LfEmployeeCode)
                .HasMaxLength(12)
                .HasDefaultValueSql("((0))")
                .HasColumnName("LF_Employee_Code");
            entity.Property(e => e.LfEducationLevelCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Education_Level_Code");
            entity.Property(e => e.AcadimicQualification).HasMaxLength(100);
            entity.Property(e => e.LfCountryCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Country_Code");
            entity.Property(e => e.AcadmicSource).HasMaxLength(100);
            entity.Property(e => e.AttachmentFileName).HasMaxLength(100);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.EndDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("End_Date");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.StartDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("Start_Date");
        });

        modelBuilder.Entity<StrEmployeeCourse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_STR_Employee_Course_WorkShop_1");

            entity.ToTable("STR_Employee_Course");

            entity.HasIndex(e => new { e.IsActive, e.IsSpouncer }, "IX_STR_Employee_Course");

            entity.Property(e => e.AttachmentFileName).HasMaxLength(100);
            entity.Property(e => e.CourseOrWorkShop)
                .HasMaxLength(100)
                .HasColumnName("Course_Or_WorkShop");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.EndDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("End_Date");
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.IsSpouncer)
                .HasDefaultValue(false)
                .HasColumnName("isSpouncer");
            entity.Property(e => e.LfCountryCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Country_Code");
            entity.Property(e => e.LfEmployeeCode)
                .HasMaxLength(12)
                .HasDefaultValueSql("((0))")
                .HasColumnName("LF_Employee_Code");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.OrginizationSource).HasMaxLength(100);
            entity.Property(e => e.StartDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("Start_Date");
        });

        modelBuilder.Entity<StrEmployeeDeduction>(entity =>
        {
            entity.HasKey(e => new { e.LfEmployeeCode, e.LfGradeCode, e.LfDeductionCode }).HasName("PK_STR_Employee_FixedDeduction");

            entity.ToTable("STR_Employee_Deduction");

            entity.HasIndex(e => e.IsActive, "IX_STR_Employee_Deduction");

            entity.Property(e => e.LfEmployeeCode)
                .HasMaxLength(12)
                .HasDefaultValueSql("((0))")
                .HasColumnName("LF_Employee_Code");
            entity.Property(e => e.LfGradeCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Grade_Code");
            entity.Property(e => e.LfDeductionCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Deduction_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.DeductionAmount)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.EndDate).HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Note).HasMaxLength(100);
            entity.Property(e => e.StartDate).HasColumnType("smalldatetime");
        });

        modelBuilder.Entity<StrEmployeeDependant>(entity =>
        {
            entity.HasKey(e => new { e.LfEmployeeCode, e.Cpr });

            entity.ToTable("STR_Employee_Dependant");

            entity.HasIndex(e => new { e.IsActive, e.IsVisaCost }, "IX_STR_Employee_Dependant");

            entity.Property(e => e.LfEmployeeCode)
                .HasMaxLength(12)
                .HasDefaultValueSql("((0))")
                .HasColumnName("LF_Employee_Code");
            entity.Property(e => e.Cpr)
                .HasMaxLength(9)
                .HasColumnName("CPR");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.DateOfBirth)
                .HasColumnType("smalldatetime")
                .HasColumnName("Date_of_Birth");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.IsVisaCost).HasDefaultValue(false);
            entity.Property(e => e.LfCountryNationalityCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Country_Nationality_Code");
            entity.Property(e => e.LfGenderCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Gender_Code");
            entity.Property(e => e.LfRelationShipCode)
                .HasMaxLength(12)
                .HasColumnName("LF_RelationShip_Code");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .HasColumnName("Name_En");
            entity.Property(e => e.PrimaryMobile).HasMaxLength(15);
        });

        modelBuilder.Entity<StrEmployeeEmergency>(entity =>
        {
            entity.HasKey(e => new { e.LfEmployeeCode, e.EmergencyMobile }).HasName("PK_STR_Employee_EmergencyContact");

            entity.ToTable("STR_Employee_Emergency");

            entity.HasIndex(e => e.IsActive, "IX_STR_Employee_Emergency");

            entity.Property(e => e.LfEmployeeCode)
                .HasMaxLength(12)
                .HasDefaultValueSql("((0))")
                .HasColumnName("LF_Employee_Code");
            entity.Property(e => e.EmergencyMobile).HasMaxLength(15);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .HasColumnName("Name_En");
            entity.Property(e => e.RelationDes).HasMaxLength(50);
        });

        modelBuilder.Entity<StrEmployeeEvalution>(entity =>
        {
            entity.HasKey(e => new { e.LfEmployeeCode, e.StartDate, e.EndDate });

            entity.ToTable("STR_Employee_Evalution");

            entity.HasIndex(e => e.IsActive, "IX_STR_Employee_Evalution");

            entity.Property(e => e.LfEmployeeCode)
                .HasMaxLength(12)
                .HasDefaultValueSql("((0))")
                .HasColumnName("LF_Employee_Code");
            entity.Property(e => e.StartDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("Start_Date");
            entity.Property(e => e.EndDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("End_Date");
            entity.Property(e => e.AttachmentFileName).HasMaxLength(100);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Grade).HasColumnType("float");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
        });

        modelBuilder.Entity<StrEmployeeExperience>(entity =>
        {
            entity.HasKey(e => new { e.LfEmployeeCode, e.JobTitle, e.StartDate });

            entity.ToTable("STR_Employee_Experience");

            entity.HasIndex(e => e.IsActive, "IX_STR_Employee_Experience");

            entity.Property(e => e.LfEmployeeCode)
                .HasMaxLength(12)
                .HasDefaultValueSql("((0))")
                .HasColumnName("LF_Employee_Code");
            entity.Property(e => e.JobTitle).HasMaxLength(100);
            entity.Property(e => e.StartDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("Start_Date");
            entity.Property(e => e.AttachmentFileName).HasMaxLength(100);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.EndDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("End_Date");
            entity.Property(e => e.FunctionalTasks).HasMaxLength(100);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.LfCountryCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Country_Code");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.OrginizationSource).HasMaxLength(100);
        });

        modelBuilder.Entity<StrEmployeeInsurance>(entity =>
        {
            entity.HasKey(e => new { e.LfEmployeeCode, e.Cpr });

            entity.ToTable("STR_Employee_Insurance");

            entity.HasIndex(e => e.IsActive, "IX_STR_Employee_Insurance");

            entity.Property(e => e.LfEmployeeCode)
                .HasMaxLength(12)
                .HasDefaultValueSql("((0))")
                .HasColumnName("LF_Employee_Code");
            entity.Property(e => e.Cpr)
                .HasMaxLength(9)
                .HasColumnName("CPR");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.InsuranceCardEnd).HasColumnType("smalldatetime");
            entity.Property(e => e.InsuranceCardNo).HasMaxLength(50);
            entity.Property(e => e.InsuranceCardStart).HasColumnType("smalldatetime");
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.LfInsuranceTypeCode)
                .HasMaxLength(12)
                .HasColumnName("LF_InsuranceType_Code");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.PolicyNo).HasMaxLength(50);
        });

        modelBuilder.Entity<StrEmployeeReward>(entity =>
        {
            entity.HasKey(e => new { e.LfEmployeeCode, e.LfRewardCode, e.StartDate, e.EndDate });

            entity.ToTable("STR_Employee_Reward");

            entity.HasIndex(e => e.IsActive, "IX_STR_Employee_Reward");

            entity.Property(e => e.LfEmployeeCode)
                .HasMaxLength(12)
                .HasDefaultValueSql("((0))")
                .HasColumnName("LF_Employee_Code");
            entity.Property(e => e.LfRewardCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Reward_Code");
            entity.Property(e => e.StartDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("Start_Date");
            entity.Property(e => e.EndDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("End_Date");
            entity.Property(e => e.AttachmentFileName).HasMaxLength(100);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.RewardDescription)
                .HasMaxLength(50)
                .HasColumnName("Reward_Description");
        });

        modelBuilder.Entity<TblAppointment>(entity =>
        {
            entity.HasKey(e => e.ApptId);

            entity.ToTable("tblAppointments");

            entity.HasIndex(e => e.EmployeeId, "IX_tblAppointments");

            entity.HasIndex(e => e.CategoryId, "IX_tblAppointments_1");

            entity.HasIndex(e => e.RecurrenceId, "IX_tblAppointments_2");

            entity.Property(e => e.ApptId).HasColumnName("ApptID");
            entity.Property(e => e.AllDayEvent).HasComment("= True for All Day Event");
            entity.Property(e => e.ApptEnd)
                .HasComment("Appointment end date and time (required)")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.ApptLocation)
                .HasMaxLength(255)
                .HasComment("Appointment Location (Optional)");
            entity.Property(e => e.ApptNotes).HasComment("Appointment miscellaneous notes (optional)");
            entity.Property(e => e.ApptStart)
                .HasComment("Appointment start date and time (required)")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.ApptSubject)
                .HasMaxLength(255)
                .HasComment("Appointment subject /patient Name (required)");
            entity.Property(e => e.CategoryId)
                .HasDefaultValue(0)
                .HasComment("Linked to tblAppointmentCategory (ID)")
                .HasColumnName("CategoryID");
            entity.Property(e => e.EmployeeId)
                .HasDefaultValue(1)
                .HasComment("Linked to STR_Employee(ID)")
                .HasColumnName("EmployeeID");
            entity.Property(e => e.LfCompanyLocationCode)
                .HasMaxLength(12)
                .HasDefaultValue("LOC-0001")
                .HasColumnName("LF_Company_Location_Code");
            entity.Property(e => e.LfPatientCode)
                .HasMaxLength(30)
                .HasDefaultValue("PAT-000001")
                .HasColumnName("LF_Patient_Code");
            entity.Property(e => e.Pattern)
                .HasMaxLength(255)
                .HasComment("Recurrence pattern codes");
            entity.Property(e => e.RecurrenceId)
                .HasComment("Holds unique value for each group of recurring appointments")
                .HasColumnName("RecurrenceID");
        });

        modelBuilder.Entity<TblAppointmentCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId);

            entity.ToTable("tblAppointmentCategory");

            entity.Property(e => e.CategoryId)
                .ValueGeneratedNever()
                .HasColumnName("CategoryID");
            entity.Property(e => e.CatHtml).HasColumnName("CatHTML");
            entity.Property(e => e.CategoryName).HasMaxLength(50);
            entity.Property(e => e.CategoryNameA).HasMaxLength(50);
        });

        modelBuilder.Entity<TblCalendarSetting>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblCalendarSettings");

            entity.HasIndex(e => e.ApptDuration, "IX_tblCalendarSettings").IsUnique();

            entity.Property(e => e.AlterTimes).HasComment("=Yes to show time in every time slot on Weekly/Daily calendar, = No to show time in alternate time slots");
            entity.Property(e => e.ApptDuration).HasComment("Duration of appointments in minutes (5, 10, 15 or 30 minutes only)");
            entity.Property(e => e.ApptFirstTimeSlot)
                .HasComment("First time slot displayed on weekly and daily calendars")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.ApptLastTimeSlot)
                .HasComment("Last time slot displayed on weekly and daily calendars")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.ClockType).HasComment("=Yes for 24 hour clock or 12 Hour clock on Weekly & Daily calendars");
            entity.Property(e => e.Ditto).HasComment("=Set to True to show \" char in subsequent rows");
            entity.Property(e => e.FirstDayOfWeek)
                .HasDefaultValue((short)0)
                .HasComment("=vbSunday to vbSaturday to determine which day shows as the first day of the week");
            entity.Property(e => e.MonthHide).HasComment("=True to display appts on greyed out dates on overlapping months");
            entity.Property(e => e.MultiAppts).HasComment("=False to allow multiple appts for a time slot, set to True to show error message if user tries to enter appt for used time slot");
            entity.Property(e => e.OpenAppt).HasComment("=False to display calendar using 'Find Appt' option, set to True to open 'Appointment Schedule' form when appt found");
            entity.Property(e => e.OpenCalendar)
                .HasDefaultValue((short)0)
                .HasComment("= 0 - 3 to select which calendar to open on start up.");
            entity.Property(e => e.ShowLocation).HasComment("=True to show the Location field on calendars");
            entity.Property(e => e.ShowPublicHols).HasComment("=True to show Public Holiday Dates on calendars in red");
            entity.Property(e => e.ShowStart).HasComment("=True to show the Start Time on calendars");
            entity.Property(e => e.ShowStartEnd).HasComment("=True to show the Start and End Time on calendars");
            entity.Property(e => e.ShowSubject).HasComment("=True to show the Subject field on calendars");
            entity.Property(e => e.StartTime)
                .HasComment("Starting time for Weekly and Daily calendars")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.WeekdayLength)
                .HasDefaultValue((short)0)
                .HasComment("=1 to 4 to show the number of weekday characters on Month headers on Yearly calendar");
        });

        modelBuilder.Entity<TblDentalToothChart>(entity =>
        {
            entity.HasKey(e => new { e.LfAppointmenttId, e.ToothNumber });

            entity.ToTable("tblDentalToothChart");

            entity.Property(e => e.LfAppointmenttId).HasColumnName("LF_AppointmenttID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.DirectionSurfaceBuccal)
                .HasDefaultValue(false)
                .HasColumnName("Direction_Surface_Buccal");
            entity.Property(e => e.DirectionSurfaceDistal)
                .HasDefaultValue(false)
                .HasColumnName("Direction_Surface_Distal");
            entity.Property(e => e.DirectionSurfaceLingual)
                .HasDefaultValue(false)
                .HasColumnName("Direction_Surface_Lingual");
            entity.Property(e => e.DirectionSurfaceMesial)
                .HasDefaultValue(false)
                .HasColumnName("Direction_Surface_Mesial");
            entity.Property(e => e.DirectionSurfaceOcclusal)
                .HasDefaultValue(false)
                .HasColumnName("Direction_Surface_Occlusal");
            entity.Property(e => e.Fee)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
        });

        modelBuilder.Entity<TblMonthDatum>(entity =>
        {
            entity.HasKey(e => e.RowNo);

            entity.ToTable("tblMonthData");

            entity.Property(e => e.RowNo).ValueGeneratedNever();
            entity.Property(e => e.Day1Data).HasComment("Day cells data (1-7)");
            entity.Property(e => e.Day1Date).HasComment("Day cells date (1-7)");
            entity.Property(e => e.Day2Data).HasComment("Day cells data (1-7)");
            entity.Property(e => e.Day2Date).HasComment("Day cells date (1-7)");
            entity.Property(e => e.Day3Data).HasComment("Day cells data (1-7)");
            entity.Property(e => e.Day3Date).HasComment("Day cells date (1-7)");
            entity.Property(e => e.Day4Data).HasComment("Day cells data (1-7)");
            entity.Property(e => e.Day4Date).HasComment("Day cells date (1-7)");
            entity.Property(e => e.Day5Data).HasComment("Day cells data (1-7)");
            entity.Property(e => e.Day5Date).HasComment("Day cells date (1-7)");
            entity.Property(e => e.Day6Data).HasComment("Day cells data (1-7)");
            entity.Property(e => e.Day6Date).HasComment("Day cells date (1-7)");
            entity.Property(e => e.Day7Data).HasComment("Day cells data (1-7)");
            entity.Property(e => e.Day7Date).HasComment("Day cells date (1-7)");
            entity.Property(e => e.HideDay).HasMaxLength(255);
            entity.Property(e => e.WeekNo)
                .HasComment("Week number (1-52)")
                .HasColumnType("smalldatetime");
        });

        modelBuilder.Entity<TblRole>(entity =>
        {
            entity.ToTable("tblRole");

            entity.HasIndex(e => new { e.RoleEn, e.RoleAr, e.IsActive }, "IX_tblRole");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.RoleAr)
                .HasMaxLength(50)
                .HasColumnName("Role_Ar");
            entity.Property(e => e.RoleEn)
                .HasMaxLength(50)
                .HasColumnName("Role_En");
        });

        modelBuilder.Entity<TblSimpleAppointment>(entity =>
        {
            entity.HasKey(e => e.InputId);

            entity.ToTable("tblSimpleAppointment");

            entity.Property(e => e.InputId).HasColumnName("InputID");
            entity.Property(e => e.InputDate).HasColumnType("smalldatetime");
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.UserName);

            entity.ToTable("tblUser");

            entity.HasIndex(e => e.UserName, "IX_tblUser").IsUnique();

            entity.HasIndex(e => e.IsActive, "IX_tblUser_1");

            entity.Property(e => e.UserName).HasMaxLength(50);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.LfEmployeeCode)
                .HasMaxLength(12)
                .HasDefaultValueSql("((0))")
                .HasColumnName("LF_Employee_Code");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.UserPassword).HasMaxLength(50);
        });

        modelBuilder.Entity<TblUserRole>(entity =>
        {
            entity.HasKey(e => new { e.LfUserName, e.LfRoleId });

            entity.ToTable("tblUserRole");

            entity.HasIndex(e => e.IsActive, "IX_tblUserRole");

            entity.Property(e => e.LfUserName)
                .HasMaxLength(50)
                .HasColumnName("LF_UserName");
            entity.Property(e => e.LfRoleId).HasColumnName("LF_Role_Id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");

            entity.HasOne(d => d.LfRole).WithMany(p => p.TblUserRoles)
                .HasForeignKey(d => d.LfRoleId)
                .HasConstraintName("FK_tblUserRole_tblRole");
        });

        modelBuilder.Entity<TblWeekDatum>(entity =>
        {
            entity.HasKey(e => e.RowNo);

            entity.ToTable("tblWeekData");

            entity.Property(e => e.RowNo).ValueGeneratedNever();
            entity.Property(e => e.Day10Data).HasComment("Days 1-10 used for tblAppointmentCategory data in Daily mode");
            entity.Property(e => e.Day1Data).HasComment("Days 1-10 used for tblAppointmentCategory data in Daily mode");
            entity.Property(e => e.Day2Data).HasComment("Days 1-10 used for tblAppointmentCategory data in Daily mode");
            entity.Property(e => e.Day3Data).HasComment("Days 1-10 used for tblAppointmentCategory data in Daily mode");
            entity.Property(e => e.Day4Data).HasComment("Days 1-10 used for tblAppointmentCategory data in Daily mode");
            entity.Property(e => e.Day5Data).HasComment("Days 1-10 used for tblAppointmentCategory data in Daily mode");
            entity.Property(e => e.Day6Data).HasComment("Days 1-10 used for tblAppointmentCategory data in Daily mode");
            entity.Property(e => e.Day7Data).HasComment("Days 1-10 used for tblAppointmentCategory data in Daily mode");
            entity.Property(e => e.Day8Data).HasComment("Days 1-10 used for tblAppointmentCategory data in Daily mode");
            entity.Property(e => e.Day9Data).HasComment("Days 1-10 used for tblAppointmentCategory data in Daily mode");
            entity.Property(e => e.TimeSlots).HasComment("Time slots (00:00 - 23:30)");
        });

        modelBuilder.Entity<TimeAttendanceLeaveType>(entity =>
        {
            entity.HasKey(e => e.LeaveTypeCode);

            entity.ToTable("TimeAttendance_LeaveType");

            entity.HasIndex(e => new { e.IsActive, e.IsCarryFarward, e.IsPayable }, "IX_TimeAttendance_LeaveType");

            entity.Property(e => e.LeaveTypeCode)
                .HasMaxLength(12)
                .HasColumnName("LeaveType_Code");
            entity.Property(e => e.CarryFarwardLimitinDay).HasDefaultValue(0);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.IsCarryFarward)
                .HasDefaultValue(false)
                .HasColumnName("isCarryFarward");
            entity.Property(e => e.IsPayable)
                .HasDefaultValue(true)
                .HasColumnName("isPayable");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(50)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .HasColumnName("Name_En");
            entity.Property(e => e.NextAllowanceByDay).HasDefaultValue(0);
            entity.Property(e => e.YearlyLeavesInDays).HasDefaultValue(0);
        });

        modelBuilder.Entity<TimeAttendanceOfficialVacation>(entity =>
        {
            entity.HasKey(e => e.OfficialVacationCode);

            entity.ToTable("TimeAttendance_OfficialVacation");

            entity.HasIndex(e => e.IsActive, "IX_TimeAttendance_OfficialVacation");

            entity.Property(e => e.OfficialVacationCode)
                .HasMaxLength(12)
                .HasColumnName("OfficialVacation_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(80)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(80)
                .HasColumnName("Name_En");
            entity.Property(e => e.VacationDay).HasColumnType("smalldatetime");
        });

        modelBuilder.Entity<TimeAttendancePattern>(entity =>
        {
            entity.HasKey(e => e.PatternCode);

            entity.ToTable("TimeAttendance_Pattern");

            entity.HasIndex(e => e.NameEn, "IX_TimeAttendance_Pattern").IsUnique();

            entity.HasIndex(e => e.NameAr, "IX_TimeAttendance_Pattern_1");

            entity.HasIndex(e => new { e.IsActive, e.IsIncludeVacationLeave, e.IsIncludWeekEndLeave, e.IsLongShift }, "IX_TimeAttendance_Pattern_2");

            entity.Property(e => e.PatternCode)
                .HasMaxLength(12)
                .HasColumnName("Pattern_Code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.EndDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("End_Date");
            entity.Property(e => e.FridayBeakTimeIn)
                .HasDefaultValue(new DateTime(2025, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("smalldatetime")
                .HasColumnName("Friday_Beak_TimeIn");
            entity.Property(e => e.FridayBreakTimeOut)
                .HasDefaultValue(new DateTime(2025, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("smalldatetime")
                .HasColumnName("Friday_Break_TimeOut");
            entity.Property(e => e.FridayEarlyAllowance)
                .HasDefaultValue(new DateTime(2025, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("smalldatetime")
                .HasColumnName("Friday_EarlyAllowance");
            entity.Property(e => e.FridayExitAllowance)
                .HasDefaultValue(new DateTime(2025, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("smalldatetime")
                .HasColumnName("Friday_ExitAllowance");
            entity.Property(e => e.FridayTimeIn)
                .HasDefaultValue(new DateTime(2025, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("smalldatetime")
                .HasColumnName("Friday_TimeIn");
            entity.Property(e => e.FridayTimeout)
                .HasDefaultValue(new DateTime(2025, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("smalldatetime")
                .HasColumnName("Friday_Timeout");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasDefaultValue("::1")
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.IsIncludWeekEndLeave)
                .HasDefaultValue(false)
                .HasColumnName("isIncludWeekEndLeave");
            entity.Property(e => e.IsIncludeVacationLeave)
                .HasDefaultValue(false)
                .HasColumnName("isIncludeVacationLeave");
            entity.Property(e => e.IsLongShift)
                .HasDefaultValue(false)
                .HasColumnName("isLongShift");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasDefaultValue("EF Migration");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.MondayBeakTimeIn)
                .HasDefaultValue(new DateTime(2025, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("smalldatetime")
                .HasColumnName("Monday_Beak_TimeIn");
            entity.Property(e => e.MondayBreakTimeOut)
                .HasDefaultValue(new DateTime(2025, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("smalldatetime")
                .HasColumnName("MondayBreak_TimeOut");
            entity.Property(e => e.MondayEarlyAllowance)
                .HasDefaultValue(new DateTime(2025, 12, 7, 8, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("smalldatetime")
                .HasColumnName("Monday_EarlyAllowance");
            entity.Property(e => e.MondayExitAllowance)
                .HasDefaultValue(new DateTime(2025, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("smalldatetime")
                .HasColumnName("Monday_ExitAllowance");
            entity.Property(e => e.MondayTimeIn)
                .HasDefaultValue(new DateTime(2025, 12, 7, 7, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("smalldatetime")
                .HasColumnName("Monday_TimeIn");
            entity.Property(e => e.MondayTimeout)
                .HasDefaultValue(new DateTime(2025, 12, 7, 14, 15, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("smalldatetime")
                .HasColumnName("Monday_Timeout");
            entity.Property(e => e.NameAr)
                .HasMaxLength(80)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(80)
                .HasColumnName("Name_En");
            entity.Property(e => e.OverTimeShift1End)
                .HasDefaultValue(new DateTime(2025, 12, 7, 19, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("smalldatetime");
            entity.Property(e => e.OverTimeShift1Start)
                .HasDefaultValue(new DateTime(2025, 12, 7, 14, 15, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("smalldatetime");
            entity.Property(e => e.OverTimeShift2End)
                .HasDefaultValue(new DateTime(2025, 12, 7, 7, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("smalldatetime");
            entity.Property(e => e.OverTimeShift2Start)
                .HasDefaultValue(new DateTime(2025, 12, 7, 19, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("smalldatetime");
            entity.Property(e => e.SaturdayBeakTimeIn)
                .HasDefaultValue(new DateTime(2025, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("smalldatetime")
                .HasColumnName("Saturday_Beak_TimeIn");
            entity.Property(e => e.SaturdayBreakTimeOut)
                .HasDefaultValue(new DateTime(2025, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("smalldatetime")
                .HasColumnName("Saturday_Break_TimeOut");
            entity.Property(e => e.SaturdayEarlyAllowance)
                .HasDefaultValue(new DateTime(2025, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("smalldatetime")
                .HasColumnName("Saturday_EarlyAllowance");
            entity.Property(e => e.SaturdayExitAllowanceMin)
                .HasDefaultValue(new DateTime(2025, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("smalldatetime")
                .HasColumnName("Saturday_ExitAllowance_Min");
            entity.Property(e => e.SaturdayTimeIn)
                .HasDefaultValue(new DateTime(2025, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("smalldatetime")
                .HasColumnName("Saturday_TimeIn");
            entity.Property(e => e.SaturdayTimeout)
                .HasDefaultValue(new DateTime(2025, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("smalldatetime")
                .HasColumnName("Saturday_Timeout");
            entity.Property(e => e.StartDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("Start_Date");
            entity.Property(e => e.SundayBeakTimeIn)
                .HasDefaultValue(new DateTime(2025, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("smalldatetime")
                .HasColumnName("Sunday_Beak_TimeIn");
            entity.Property(e => e.SundayBreakTimeOut)
                .HasDefaultValue(new DateTime(2025, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("smalldatetime")
                .HasColumnName("SundayBreak_TimeOut");
            entity.Property(e => e.SundayEarlyAllowance)
                .HasDefaultValue(new DateTime(2025, 12, 7, 8, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("smalldatetime")
                .HasColumnName("Sunday_EarlyAllowance");
            entity.Property(e => e.SundayExitAllowance)
                .HasDefaultValue(new DateTime(2025, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("smalldatetime")
                .HasColumnName("Sunday_ExitAllowance");
            entity.Property(e => e.SundayTimeIn)
                .HasDefaultValue(new DateTime(2025, 12, 7, 7, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("smalldatetime")
                .HasColumnName("Sunday_TimeIn");
            entity.Property(e => e.SundayTimeout)
                .HasDefaultValue(new DateTime(2025, 12, 7, 14, 15, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("smalldatetime")
                .HasColumnName("Sunday_Timeout");
            entity.Property(e => e.ThursdayBeakTimeIn)
                .HasDefaultValue(new DateTime(2025, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("smalldatetime")
                .HasColumnName("Thursday_Beak_TimeIn");
            entity.Property(e => e.ThursdayBreakTimeOut)
                .HasDefaultValue(new DateTime(2025, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("smalldatetime")
                .HasColumnName("Thursday_Break_TimeOut");
            entity.Property(e => e.ThursdayEarlyAllowance)
                .HasDefaultValue(new DateTime(2025, 12, 7, 8, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("smalldatetime")
                .HasColumnName("Thursday_EarlyAllowance");
            entity.Property(e => e.ThursdayExitAllowance)
                .HasDefaultValue(new DateTime(2025, 12, 7, 14, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("smalldatetime")
                .HasColumnName("Thursday_ExitAllowance");
            entity.Property(e => e.ThursdayTimeIn)
                .HasDefaultValue(new DateTime(2025, 12, 7, 7, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("smalldatetime")
                .HasColumnName("Thursday_TimeIn");
            entity.Property(e => e.ThursdayTimeout)
                .HasDefaultValue(new DateTime(2025, 12, 7, 14, 15, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("smalldatetime")
                .HasColumnName("Thursday_Timeout");
            entity.Property(e => e.TimeInerval)
                .HasDefaultValue(new DateTime(2025, 12, 7, 0, 30, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("smalldatetime");
            entity.Property(e => e.TuesdayBeakTimeIn)
                .HasDefaultValue(new DateTime(2025, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("smalldatetime")
                .HasColumnName("Tuesday_Beak_TimeIn");
            entity.Property(e => e.TuesdayBreakTimeOut)
                .HasDefaultValue(new DateTime(2025, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("smalldatetime")
                .HasColumnName("Tuesday_Break_TimeOut");
            entity.Property(e => e.TuesdayEarlyAllowance)
                .HasDefaultValue(new DateTime(2025, 12, 7, 8, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("smalldatetime")
                .HasColumnName("Tuesday_EarlyAllowance");
            entity.Property(e => e.TuesdayExitAllowance)
                .HasDefaultValue(new DateTime(2025, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("smalldatetime")
                .HasColumnName("Tuesday_ExitAllowance");
            entity.Property(e => e.TuesdayTimeIn)
                .HasDefaultValue(new DateTime(2025, 12, 7, 7, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("smalldatetime")
                .HasColumnName("Tuesday_TimeIn");
            entity.Property(e => e.TuesdayTimeout)
                .HasDefaultValue(new DateTime(2025, 12, 7, 14, 15, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("smalldatetime")
                .HasColumnName("Tuesday_Timeout");
            entity.Property(e => e.WednesdayBeakTimeIn)
                .HasDefaultValue(new DateTime(2025, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("smalldatetime")
                .HasColumnName("Wednesday_Beak_TimeIn");
            entity.Property(e => e.WednesdayBreakTimeOut)
                .HasDefaultValue(new DateTime(2025, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("smalldatetime")
                .HasColumnName("Wednesday_Break_TimeOut");
            entity.Property(e => e.WednesdayEarlyAllowance)
                .HasDefaultValue(new DateTime(2025, 12, 7, 8, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("smalldatetime")
                .HasColumnName("Wednesday_EarlyAllowance");
            entity.Property(e => e.WednesdayExitAllowance)
                .HasDefaultValue(new DateTime(2025, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("smalldatetime")
                .HasColumnName("Wednesday_ExitAllowance");
            entity.Property(e => e.WednesdayTimeIn)
                .HasDefaultValue(new DateTime(2025, 12, 7, 7, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("smalldatetime")
                .HasColumnName("Wednesday_TimeIn");
            entity.Property(e => e.WednesdayTimeout)
                .HasDefaultValue(new DateTime(2025, 12, 7, 14, 15, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("smalldatetime")
                .HasColumnName("Wednesday_Timeout");
        });

        modelBuilder.Entity<ViewChartOfAccount>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("View_ChartOfAccount");

            entity.Property(e => e.AccountCode).HasMaxLength(30);
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.IsTransaction).HasColumnName("isTransaction");
            entity.Property(e => e.NameAr)
                .HasMaxLength(150)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(150)
                .HasColumnName("Name_En");
            entity.Property(e => e.ParentAccountCode).HasMaxLength(30);
            entity.Property(e => e.Sorting).HasMaxLength(61);
        });

        modelBuilder.Entity<ViewEmployeeAndDependent>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("View_Employee_AND_Dependents");

            entity.Property(e => e.Cpr)
                .HasMaxLength(9)
                .HasColumnName("CPR");
            entity.Property(e => e.EmployeeCode)
                .HasMaxLength(12)
                .HasColumnName("Employee_Code");
            entity.Property(e => e.IsActive)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("isActive");
            entity.Property(e => e.LfGradeCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Grade_Code");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .HasColumnName("Name_En");
        });

        modelBuilder.Entity<ViewEmployeeBasicGosi>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ViewEmployeeBasic_GOSI");

            entity.Property(e => e.EmployeeCode)
                .HasMaxLength(12)
                .HasColumnName("Employee_Code");
            entity.Property(e => e.Gosi)
                .HasColumnName("GOSI")
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.GradeNameEn)
                .HasMaxLength(50)
                .HasColumnName("Grade_Name_En");
            entity.Property(e => e.GradeStepNo).HasColumnName("Grade_Step_No");
            entity.Property(e => e.LfDeductionCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Deduction_Code");
            entity.Property(e => e.DeductionAmount)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.LfGradeCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Grade_Code");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .HasColumnName("Name_En");
            entity.Property(e => e.BasicSalary)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.SumAllowances)
                .HasColumnType("decimal(18, 3)");
        });

        modelBuilder.Entity<ViewEmployeeDiffernaceAllowanceDefault>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("View_Employee_DiffernaceAllowanceDefault");

            entity.Property(e => e.LfAllowanceCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Allowance_Code");
            entity.Property(e => e.LfEmployeeCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Employee_Code");
            entity.Property(e => e.LfGradeCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Grade_Code");
            entity.Property(e => e.AllowanceAmount)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.DefaultAmount)
                .HasColumnType("decimal(18, 3)");
        });

        modelBuilder.Entity<ViewEmployeeHierarchy>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("View_Employee_hierarchy");

            entity.Property(e => e.ConnectionEmployeeCode)
                .HasMaxLength(12)
                .HasColumnName("connection_Employee_code");
            entity.Property(e => e.DelegatorEmail).HasMaxLength(50);
            entity.Property(e => e.EmployeeCode)
                .HasMaxLength(12)
                .HasColumnName("employee_code");
            entity.Property(e => e.IsActive)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("isActive");
            entity.Property(e => e.LfEmployeeCodeDelegator)
                .HasMaxLength(12)
                .HasColumnName("LF_Employee_Code_Delegator");
            entity.Property(e => e.LfEmployeeCodeManager)
                .HasMaxLength(12)
                .HasColumnName("LF_Employee_Code_Manager");
            entity.Property(e => e.ManagerEmail).HasMaxLength(50);
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .HasColumnName("Name_En");
            entity.Property(e => e.OfficialEmail).HasMaxLength(50);
        });

        modelBuilder.Entity<ViewEmployeeSalaryInfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ViewEmployeeSalaryInfo");

            entity.Property(e => e.Cpr)
                .HasMaxLength(9)
                .HasColumnName("CPR");
            entity.Property(e => e.EmployeeCode)
                .HasMaxLength(12)
                .HasColumnName("Employee_Code");
            entity.Property(e => e.GradeNameEn)
                .HasMaxLength(50)
                .HasColumnName("Grade_Name_En");
            entity.Property(e => e.GradeStepNo).HasColumnName("Grade_Step_No");
            entity.Property(e => e.IsActive)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("isActive");
            entity.Property(e => e.JobTitle).HasMaxLength(120);
            entity.Property(e => e.LfGradeCode)
                .HasMaxLength(12)
                .HasColumnName("LF_Grade_Code");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .HasColumnName("Name_En");
            entity.Property(e => e.BasicSalary)
                .HasColumnType("decimal(18, 3)");
        });

        modelBuilder.Entity<ViewMenuHierarchy>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("View_Menu_hierarchy");

            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .UseCollation("Arabic_CI_AS")
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .UseCollation("Arabic_CI_AS")
                .HasColumnName("Name_En");
            entity.Property(e => e.ParentId)
                .HasMaxLength(12)
                .HasColumnName("Parent_Id");
        });

        modelBuilder.Entity<ViewMenuPermission>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("View_MenuPermissions");

            entity.Property(e => e.LfParentMenuId)
                .HasMaxLength(12)
                .HasColumnName("LF_Parent_Menu_Id");
            entity.Property(e => e.MenuId).HasColumnName("Menu_id");
            entity.Property(e => e.MenuSortOrder)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("Menu_Sort_Order");
            entity.Property(e => e.RoleId).HasColumnName("Role_ID");
        });

        modelBuilder.Entity<ViewUsersMenuPermission>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("View_Users_Menu_Permission");

            entity.Property(e => e.HirarSorting).HasColumnName("Hirar_Sorting");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.LfMenuId).HasColumnName("LF_Menu_Id");
            entity.Property(e => e.LfRoleId).HasColumnName("LF_Role_Id");
            entity.Property(e => e.LfUserName)
                .HasMaxLength(50)
                .HasColumnName("LF_UserName");
            entity.Property(e => e.MenuSortOrder)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("Menu_Sort_Order");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .UseCollation("Arabic_CI_AS")
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .UseCollation("Arabic_CI_AS")
                .HasColumnName("Name_En");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
