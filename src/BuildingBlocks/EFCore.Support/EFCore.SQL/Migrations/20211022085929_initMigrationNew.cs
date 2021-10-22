using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class initMigrationNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BoilMaster",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoilNo = table.Column<int>(nullable: false),
                    JangadNo = table.Column<int>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    BranchId = table.Column<string>(nullable: true),
                    EntryDate = table.Column<DateTime>(nullable: true),
                    FinancialId = table.Column<string>(nullable: true),
                    BoilType = table.Column<int>(nullable: false),
                    KapanId = table.Column<string>(nullable: true),
                    ShapeId = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    LossWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    RejectionWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    HandOverById = table.Column<string>(nullable: true),
                    HandOverToId = table.Column<string>(nullable: true),
                    SlipNo = table.Column<string>(nullable: true),
                    BoilCategoy = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoilMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BrokerageMaster",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Percentage = table.Column<float>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrokerageMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyMaster",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    MobileNo = table.Column<string>(nullable: true),
                    OfficeNo = table.Column<string>(nullable: true),
                    Details = table.Column<string>(nullable: true),
                    TermsCondition = table.Column<string>(nullable: true),
                    GSTNo = table.Column<string>(nullable: true),
                    PanCardNo = table.Column<string>(nullable: true),
                    RegistrationNo = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContraEntryMaster",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<string>(nullable: true),
                    BranchId = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    ToPartyId = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContraEntryMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyMaster",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(nullable: true),
                    Value = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseMaster",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinancialYearMaster",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialYearMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GalaMaster",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GalaMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupPaymentMaster",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<string>(nullable: true),
                    BranchId = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    ToPartyId = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupPaymentMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KapanMappingMaster",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseMasterId = table.Column<string>(nullable: true),
                    PurchaseDetailsId = table.Column<string>(nullable: true),
                    KapanId = table.Column<string>(nullable: true),
                    SlipId = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KapanMappingMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KapanMaster",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Details = table.Column<string>(nullable: true),
                    CaratLimit = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    IsStatus = table.Column<bool>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KapanMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LessWeightMasters",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessWeightMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModuleMaster",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsDetele = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NumberMaster",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumberMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseMaster",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<string>(nullable: true),
                    BranchId = table.Column<string>(nullable: true),
                    PartyId = table.Column<string>(nullable: true),
                    ByuerId = table.Column<string>(nullable: true),
                    CurrencyId = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    BrokerageId = table.Column<string>(nullable: true),
                    CurrencyRate = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    PurchaseBillNo = table.Column<long>(nullable: false),
                    SlipNo = table.Column<long>(nullable: false),
                    TransactionType = table.Column<int>(nullable: false),
                    Date = table.Column<string>(nullable: true),
                    Time = table.Column<string>(nullable: true),
                    DayName = table.Column<string>(nullable: true),
                    PartyLastBalanceWhilePurchase = table.Column<double>(nullable: false),
                    BrokerPercentage = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    BrokerAmount = table.Column<double>(nullable: false),
                    RoundUpAmount = table.Column<double>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    GrossTotal = table.Column<double>(nullable: false),
                    DueDays = table.Column<int>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    PaymentDays = table.Column<int>(nullable: false),
                    PaymentDueDays = table.Column<int>(nullable: false),
                    IsSlip = table.Column<bool>(nullable: false),
                    IsPF = table.Column<bool>(nullable: false),
                    CommissionToPartyId = table.Column<Guid>(nullable: false),
                    CommissionPercentage = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    CommissionAmount = table.Column<double>(nullable: false),
                    Image1 = table.Column<byte[]>(nullable: true),
                    Image2 = table.Column<byte[]>(nullable: true),
                    Image3 = table.Column<byte[]>(nullable: true),
                    AllowSlipPrint = table.Column<bool>(nullable: false),
                    IsTransfer = table.Column<bool>(nullable: false),
                    TransferParentId = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurityMaster",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurityMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleMaster",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Isdelete = table.Column<bool>(nullable: false),
                    CratedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalaryMaster",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<string>(nullable: true),
                    BranchId = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    SalaryMonthName = table.Column<string>(nullable: true),
                    SalaryMonthDateTime = table.Column<DateTime>(nullable: false),
                    MonthDays = table.Column<int>(nullable: false),
                    Holidays = table.Column<float>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesMaster",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<string>(nullable: true),
                    PartyId = table.Column<string>(nullable: true),
                    SalerId = table.Column<string>(nullable: true),
                    CurrencyId = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    BrokerageId = table.Column<string>(nullable: true),
                    CurrencyRate = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    SaleBillNo = table.Column<long>(nullable: false),
                    SlipNo = table.Column<long>(nullable: false),
                    TransactionType = table.Column<int>(nullable: false),
                    Date = table.Column<string>(nullable: true),
                    Time = table.Column<string>(nullable: true),
                    DayName = table.Column<string>(nullable: true),
                    PartyLastBalanceWhileSale = table.Column<double>(nullable: false),
                    BrokerPercentage = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    BrokerAmount = table.Column<double>(nullable: false),
                    RoundUpAmount = table.Column<double>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    GrossTotal = table.Column<double>(nullable: false),
                    DueDays = table.Column<int>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    PaymentDays = table.Column<int>(nullable: false),
                    PaymentDueDays = table.Column<int>(nullable: false),
                    IsSlip = table.Column<bool>(nullable: false),
                    IsPF = table.Column<bool>(nullable: false),
                    CommissionToPartyId = table.Column<string>(nullable: true),
                    CommissionPercentage = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    CommissionAmount = table.Column<double>(nullable: false),
                    Image1 = table.Column<byte[]>(nullable: true),
                    Image2 = table.Column<byte[]>(nullable: true),
                    Image3 = table.Column<byte[]>(nullable: true),
                    AllowSlipPrint = table.Column<bool>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShapeMaster",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShapeMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SizeMaster",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SizeMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BranchMaster",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<string>(nullable: true),
                    LessWeightId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    MobileNo = table.Column<string>(nullable: true),
                    OfficeNo = table.Column<string>(nullable: true),
                    Details = table.Column<string>(nullable: true),
                    TermsCondition = table.Column<string>(nullable: true),
                    GSTNo = table.Column<string>(nullable: true),
                    PanCardNo = table.Column<string>(nullable: true),
                    RegistrationNo = table.Column<string>(nullable: true),
                    CVDWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    TipWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchMaster_CompanyMaster_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "CompanyMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PartyMaster",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<string>(nullable: true),
                    BrokerageId = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    SubType = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(nullable: true),
                    EmailId = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    MobileNo = table.Column<string>(nullable: true),
                    OfficeNo = table.Column<string>(nullable: true),
                    GSTNo = table.Column<string>(nullable: true),
                    AadharCardNo = table.Column<string>(nullable: true),
                    PancardNo = table.Column<string>(nullable: true),
                    OpeningBalance = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartyMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartyMaster_CompanyMaster_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "CompanyMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContraEntryDetails",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContraEntryMasterId = table.Column<string>(nullable: true),
                    FromParty = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContraEntryDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContraEntryDetails_ContraEntryMaster_ContraEntryMasterId",
                        column: x => x.ContraEntryMasterId,
                        principalTable: "ContraEntryMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMaster",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<string>(nullable: true),
                    FromPartyId = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    CrDrType = table.Column<int>(nullable: false),
                    ChequeNo = table.Column<string>(nullable: true),
                    ChequeDate = table.Column<DateTime>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentMaster_GroupPaymentMaster_GroupId",
                        column: x => x.GroupId,
                        principalTable: "GroupPaymentMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LessWeightDetails",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessWeightId = table.Column<string>(nullable: true),
                    MinWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    MaxWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    LessWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessWeightDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessWeightDetails_LessWeightMasters_LessWeightId",
                        column: x => x.LessWeightId,
                        principalTable: "LessWeightMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PermissionMaster",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PermissionMaster_ModuleMaster_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "ModuleMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseDetails",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseId = table.Column<string>(nullable: true),
                    KapanId = table.Column<string>(nullable: true),
                    ShapeId = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    PurityId = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    TIPWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    CVDWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    RejectedPercentage = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    RejectedWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    LessWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    LessDiscountPercentage = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    LessWeightDiscount = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    NetWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    BuyingRate = table.Column<double>(nullable: false),
                    CVDCharge = table.Column<double>(nullable: false),
                    CVDAmount = table.Column<double>(nullable: false),
                    RoundUpAmount = table.Column<double>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    IsTransfer = table.Column<bool>(nullable: false),
                    TransferParentId = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseDetails_PurchaseMaster_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "PurchaseMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SlipTransferEntry",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseMasterId = table.Column<string>(nullable: true),
                    SlipTransferEntryDate = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlipTransferEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SlipTransferEntry_PurchaseMaster_PurchaseMasterId",
                        column: x => x.PurchaseMasterId,
                        principalTable: "PurchaseMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaimMaster",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: true),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaimMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaimMaster_RoleMaster_RoleId",
                        column: x => x.RoleId,
                        principalTable: "RoleMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesDetails",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesId = table.Column<string>(nullable: true),
                    KapanId = table.Column<string>(nullable: true),
                    ShapeId = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    PurityId = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    TIPWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    CVDWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    RejectedPercentage = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    RejectedWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    LessWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    LessDiscountPercentage = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    LessWeightDiscount = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    NetWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    SaleRate = table.Column<double>(nullable: false),
                    CVDCharge = table.Column<double>(nullable: false),
                    CVDAmount = table.Column<double>(nullable: false),
                    RoundUpAmount = table.Column<double>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    FromCategory = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    SalesMasterId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesDetails_PurchaseMaster_SalesId",
                        column: x => x.SalesId,
                        principalTable: "PurchaseMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesDetails_SalesMaster_SalesMasterId",
                        column: x => x.SalesMasterId,
                        principalTable: "SalesMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserMaster",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserCode = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    UserType = table.Column<int>(nullable: false),
                    BrokerageId = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    MobileNo = table.Column<string>(nullable: true),
                    HomeNo = table.Column<string>(nullable: true),
                    ReferenceBy = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    AadharCardNo = table.Column<string>(nullable: true),
                    DepartmentName = table.Column<string>(nullable: true),
                    Designation = table.Column<string>(nullable: true),
                    DateOfJoin = table.Column<DateTime>(nullable: false),
                    DateOfEnd = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    BankName = table.Column<string>(nullable: true),
                    AccountNo = table.Column<string>(nullable: true),
                    IFSCCode = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    BranchMasterId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserMaster_BranchMaster_BranchMasterId",
                        column: x => x.BranchMasterId,
                        principalTable: "BranchMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseDetails",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<string>(nullable: true),
                    BranchId = table.Column<string>(nullable: true),
                    PartyId = table.Column<string>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    ExpenseMasterId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpenseDetails_ExpenseMaster_ExpenseMasterId",
                        column: x => x.ExpenseMasterId,
                        principalTable: "ExpenseMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExpenseDetails_PartyMaster_PartyId",
                        column: x => x.PartyId,
                        principalTable: "PartyMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalaryDetails",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalaryMasterId = table.Column<string>(nullable: true),
                    PartyId = table.Column<string>(nullable: true),
                    PayDays = table.Column<float>(nullable: false),
                    OvetimeDays = table.Column<float>(nullable: false),
                    AdvanceAmount = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    BonusAmount = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18, 4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalaryDetails_PartyMaster_PartyId",
                        column: x => x.PartyId,
                        principalTable: "PartyMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalaryDetails_SalaryMaster_SalaryMasterId",
                        column: x => x.SalaryMasterId,
                        principalTable: "SalaryMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaymentDetails",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentId = table.Column<string>(nullable: true),
                    GroupId = table.Column<string>(nullable: true),
                    PurchaseId = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentDetails_PaymentMaster_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "PaymentMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoleMaster",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoleMaster_RoleMaster_RoleId",
                        column: x => x.RoleId,
                        principalTable: "RoleMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoleMaster_UserMaster_UserId",
                        column: x => x.UserId,
                        principalTable: "UserMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BranchMaster_CompanyId",
                table: "BranchMaster",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ContraEntryDetails_ContraEntryMasterId",
                table: "ContraEntryDetails",
                column: "ContraEntryMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseDetails_ExpenseMasterId",
                table: "ExpenseDetails",
                column: "ExpenseMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseDetails_PartyId",
                table: "ExpenseDetails",
                column: "PartyId");

            migrationBuilder.CreateIndex(
                name: "IX_LessWeightDetails_LessWeightId",
                table: "LessWeightDetails",
                column: "LessWeightId");

            migrationBuilder.CreateIndex(
                name: "IX_PartyMaster_CompanyId",
                table: "PartyMaster",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentDetails_PaymentId",
                table: "PaymentDetails",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMaster_GroupId",
                table: "PaymentMaster",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionMaster_ModuleId",
                table: "PermissionMaster",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetails_PurchaseId",
                table: "PurchaseDetails",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaimMaster_RoleId",
                table: "RoleClaimMaster",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryDetails_PartyId",
                table: "SalaryDetails",
                column: "PartyId");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryDetails_SalaryMasterId",
                table: "SalaryDetails",
                column: "SalaryMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesDetails_SalesId",
                table: "SalesDetails",
                column: "SalesId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesDetails_SalesMasterId",
                table: "SalesDetails",
                column: "SalesMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_SlipTransferEntry_PurchaseMasterId",
                table: "SlipTransferEntry",
                column: "PurchaseMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMaster_BranchMasterId",
                table: "UserMaster",
                column: "BranchMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleMaster_RoleId",
                table: "UserRoleMaster",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleMaster_UserId",
                table: "UserRoleMaster",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoilMaster");

            migrationBuilder.DropTable(
                name: "BrokerageMaster");

            migrationBuilder.DropTable(
                name: "ContraEntryDetails");

            migrationBuilder.DropTable(
                name: "CurrencyMaster");

            migrationBuilder.DropTable(
                name: "ExpenseDetails");

            migrationBuilder.DropTable(
                name: "FinancialYearMaster");

            migrationBuilder.DropTable(
                name: "GalaMaster");

            migrationBuilder.DropTable(
                name: "KapanMappingMaster");

            migrationBuilder.DropTable(
                name: "KapanMaster");

            migrationBuilder.DropTable(
                name: "LessWeightDetails");

            migrationBuilder.DropTable(
                name: "NumberMaster");

            migrationBuilder.DropTable(
                name: "PaymentDetails");

            migrationBuilder.DropTable(
                name: "PermissionMaster");

            migrationBuilder.DropTable(
                name: "PurchaseDetails");

            migrationBuilder.DropTable(
                name: "PurityMaster");

            migrationBuilder.DropTable(
                name: "RoleClaimMaster");

            migrationBuilder.DropTable(
                name: "SalaryDetails");

            migrationBuilder.DropTable(
                name: "SalesDetails");

            migrationBuilder.DropTable(
                name: "ShapeMaster");

            migrationBuilder.DropTable(
                name: "SizeMaster");

            migrationBuilder.DropTable(
                name: "SlipTransferEntry");

            migrationBuilder.DropTable(
                name: "UserRoleMaster");

            migrationBuilder.DropTable(
                name: "ContraEntryMaster");

            migrationBuilder.DropTable(
                name: "ExpenseMaster");

            migrationBuilder.DropTable(
                name: "LessWeightMasters");

            migrationBuilder.DropTable(
                name: "PaymentMaster");

            migrationBuilder.DropTable(
                name: "ModuleMaster");

            migrationBuilder.DropTable(
                name: "PartyMaster");

            migrationBuilder.DropTable(
                name: "SalaryMaster");

            migrationBuilder.DropTable(
                name: "SalesMaster");

            migrationBuilder.DropTable(
                name: "PurchaseMaster");

            migrationBuilder.DropTable(
                name: "RoleMaster");

            migrationBuilder.DropTable(
                name: "UserMaster");

            migrationBuilder.DropTable(
                name: "GroupPaymentMaster");

            migrationBuilder.DropTable(
                name: "BranchMaster");

            migrationBuilder.DropTable(
                name: "CompanyMaster");
        }
    }
}
