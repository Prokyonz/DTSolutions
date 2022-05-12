using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApprovalPermissionMaster",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisplayName = table.Column<string>(nullable: true),
                    KeyName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalPermissionMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BoilProcessMaster",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoilNo = table.Column<int>(nullable: false),
                    PurchaseDetailsId = table.Column<string>(nullable: true),
                    JangadNo = table.Column<int>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    BranchId = table.Column<string>(nullable: true),
                    EntryDate = table.Column<string>(nullable: true),
                    EntryTime = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    BoilType = table.Column<int>(nullable: false),
                    KapanId = table.Column<string>(nullable: true),
                    ShapeId = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    PurityId = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    LossWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    RejectionWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    HandOverById = table.Column<string>(nullable: true),
                    HandOverToId = table.Column<string>(nullable: true),
                    SlipNo = table.Column<string>(nullable: true),
                    BoilCategoy = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    TransferId = table.Column<string>(nullable: true),
                    TransferType = table.Column<string>(nullable: true),
                    TransferEntryId = table.Column<string>(nullable: true),
                    TransferCaratRate = table.Column<double>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoilProcessMaster", x => x.Id);
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
                name: "CaratCategoryType",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "CharniProcessMaster",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharniNo = table.Column<int>(nullable: false),
                    JangadNo = table.Column<int>(nullable: false),
                    BoilJangadNo = table.Column<int>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    BranchId = table.Column<string>(nullable: true),
                    EntryDate = table.Column<string>(nullable: true),
                    EntryTime = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    CharniType = table.Column<int>(nullable: false),
                    KapanId = table.Column<string>(nullable: true),
                    ShapeId = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    PurityId = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    CharniSizeId = table.Column<string>(nullable: true),
                    CharniWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    LossWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    RejectionWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    HandOverById = table.Column<string>(nullable: true),
                    HandOverToId = table.Column<string>(nullable: true),
                    SlipNo = table.Column<string>(nullable: true),
                    CharniCategoy = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    TransferId = table.Column<string>(nullable: true),
                    TransferType = table.Column<string>(nullable: true),
                    TransferEntryId = table.Column<string>(nullable: true),
                    TransferCaratRate = table.Column<double>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharniProcessMaster", x => x.Id);
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
                name: "GalaProcessMaster",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GalaNo = table.Column<int>(nullable: false),
                    JangadNo = table.Column<int>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    BranchId = table.Column<string>(nullable: true),
                    EntryDate = table.Column<string>(nullable: true),
                    EntryTime = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    GalaProcessType = table.Column<int>(nullable: false),
                    KapanId = table.Column<string>(nullable: true),
                    ShapeId = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    PurityId = table.Column<string>(nullable: true),
                    CharniSizeId = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    GalaNumberId = table.Column<string>(nullable: true),
                    GalaWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    LossWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    RejectionWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    HandOverById = table.Column<string>(nullable: true),
                    HandOverToId = table.Column<string>(nullable: true),
                    SlipNo = table.Column<string>(nullable: true),
                    GalaCategoy = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    TransferId = table.Column<string>(nullable: true),
                    TransferType = table.Column<string>(nullable: true),
                    TransferEntryId = table.Column<string>(nullable: true),
                    TransferCaratRate = table.Column<double>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GalaProcessMaster", x => x.Id);
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
                    CrDrType = table.Column<int>(nullable: false),
                    ToPartyId = table.Column<string>(nullable: true),
                    BillNo = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    ApprovalType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupPaymentMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JangadMaster",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SrNo = table.Column<int>(nullable: false),
                    ReceivedSrNo = table.Column<int>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    BranchId = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    PartyId = table.Column<string>(nullable: true),
                    BrokerId = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    Totalcts = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    Image1 = table.Column<byte[]>(nullable: true),
                    Image2 = table.Column<byte[]>(nullable: true),
                    Image3 = table.Column<byte[]>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    EntryType = table.Column<int>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JangadMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JangadPrintDetailModel",
                columns: table => new
                {
                    SNo = table.Column<long>(nullable: false),
                    SrNo = table.Column<int>(nullable: false),
                    Date = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    GSTNo = table.Column<string>(nullable: true),
                    PartyName = table.Column<string>(nullable: true),
                    BrokerName = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    Rate = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    TotalCts = table.Column<decimal>(type: "decimal(18, 4)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "JangadSPReceiveModel",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: true),
                    SrNo = table.Column<int>(nullable: false),
                    SizeId = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    PartyId = table.Column<string>(nullable: true),
                    PartyName = table.Column<string>(nullable: true),
                    BrokerId = table.Column<string>(nullable: true),
                    BrokerName = table.Column<string>(nullable: true),
                    Rate = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    TotalWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    AvailableWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "KapanMappingMaster",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<string>(nullable: true),
                    BranchId = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    PurchaseMasterId = table.Column<string>(nullable: true),
                    PurchaseDetailsId = table.Column<string>(nullable: true),
                    KapanId = table.Column<string>(nullable: true),
                    PurityId = table.Column<string>(nullable: true),
                    SlipNo = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
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
                name: "LoanMaster",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<string>(nullable: true),
                    LoanType = table.Column<int>(nullable: false),
                    PartyId = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    DuratonType = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    InterestRate = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TotalInterest = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    NetAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanMaster", x => x.Id);
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
                name: "NumberProcessMaster",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberNo = table.Column<int>(nullable: false),
                    JangadNo = table.Column<int>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    BranchId = table.Column<string>(nullable: true),
                    EntryDate = table.Column<string>(nullable: true),
                    EntryTime = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    NumberProcessType = table.Column<int>(nullable: false),
                    KapanId = table.Column<string>(nullable: true),
                    ShapeId = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    PurityId = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    GalaNumberId = table.Column<string>(nullable: true),
                    NumberId = table.Column<string>(nullable: true),
                    NumberWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    LossWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    RejectionWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    HandOverById = table.Column<string>(nullable: true),
                    HandOverToId = table.Column<string>(nullable: true),
                    SlipNo = table.Column<string>(nullable: true),
                    NumberCategoy = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    TransferId = table.Column<string>(nullable: true),
                    TransferType = table.Column<string>(nullable: true),
                    TransferEntryId = table.Column<string>(nullable: true),
                    TransferCaratRate = table.Column<double>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    CharniSizeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumberProcessMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpeningStockMaster",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SrNo = table.Column<int>(nullable: false),
                    EntryDate = table.Column<string>(nullable: true),
                    EntryTime = table.Column<string>(nullable: true),
                    Category = table.Column<int>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    BranchId = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    KapanId = table.Column<string>(nullable: true),
                    ShapeId = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    PurityId = table.Column<string>(nullable: true),
                    NumberId = table.Column<string>(nullable: true),
                    TotalCts = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpeningStockMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PermissionMaster",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisplayName = table.Column<string>(nullable: true),
                    Category = table.Column<int>(nullable: false),
                    KeyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PriceMaster",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<string>(nullable: true),
                    CategoryId = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    NumberId = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PriceSPModel",
                columns: table => new
                {
                    CompanyId = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    NumberId = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 4)", nullable: false)
                },
                constraints: table =>
                {
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
                    ApprovalType = table.Column<int>(nullable: false),
                    Message = table.Column<string>(nullable: true),
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
                    PaymentDueDate = table.Column<DateTime>(nullable: false),
                    IsSlip = table.Column<bool>(nullable: false),
                    IsPF = table.Column<bool>(nullable: false),
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
                name: "RejectionInOutMaster",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SrNo = table.Column<int>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    BranchId = table.Column<string>(nullable: true),
                    EntryDate = table.Column<string>(nullable: true),
                    PartyId = table.Column<string>(nullable: true),
                    BrokerageId = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    TransType = table.Column<int>(nullable: false),
                    SlipNo = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    Rate = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    TotalCarat = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    Image1 = table.Column<byte[]>(nullable: true),
                    Image2 = table.Column<byte[]>(nullable: true),
                    Image3 = table.Column<byte[]>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RejectionInOutMaster", x => x.Id);
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
                name: "SalesItemDetails",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: true),
                    CompanyId = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    KapanId = table.Column<string>(nullable: true),
                    Kapan = table.Column<string>(nullable: true),
                    ShapeId = table.Column<string>(nullable: true),
                    Shape = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    PurityId = table.Column<string>(nullable: true),
                    Purity = table.Column<string>(nullable: true),
                    CharniSizeId = table.Column<string>(nullable: true),
                    CharniSize = table.Column<string>(nullable: true),
                    GalaNumberId = table.Column<string>(nullable: true),
                    GalaSize = table.Column<string>(nullable: true),
                    NumberSizeId = table.Column<string>(nullable: true),
                    NumberSize = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SalesMaster",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<string>(nullable: true),
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
                    PaymentDueDate = table.Column<DateTime>(nullable: false),
                    IsSlip = table.Column<bool>(nullable: false),
                    IsPF = table.Column<bool>(nullable: false),
                    CommissionToPartyId = table.Column<string>(nullable: true),
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
                    UpdatedBy = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    ApprovalType = table.Column<int>(nullable: false)
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
                name: "SPAccountToAssoftReceiveReportModel",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: true),
                    Dept = table.Column<string>(nullable: true),
                    Sr = table.Column<int>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    BranchId = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    JangadNo = table.Column<int>(nullable: false),
                    EntryDate = table.Column<DateTime>(nullable: true),
                    HandOverById = table.Column<string>(nullable: true),
                    HandOverByName = table.Column<string>(nullable: true),
                    HandOverToId = table.Column<string>(nullable: true),
                    HandOverToName = table.Column<string>(nullable: true),
                    KapanId = table.Column<string>(nullable: true),
                    KapanName = table.Column<string>(nullable: true),
                    ShapeId = table.Column<string>(nullable: true),
                    ShapeName = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    SizeName = table.Column<string>(nullable: true),
                    NumberId = table.Column<string>(nullable: true),
                    NumberName = table.Column<string>(nullable: true),
                    PurityId = table.Column<string>(nullable: true),
                    PurityName = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    SlipNo = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SPAccountToAssortSendReceiveReportModels",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: true),
                    ChildId = table.Column<string>(nullable: true),
                    Sr = table.Column<int>(nullable: false),
                    Department = table.Column<string>(nullable: true),
                    CompanyId = table.Column<string>(nullable: true),
                    BranchId = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    EntryDate = table.Column<DateTime>(nullable: true),
                    FromPartyId = table.Column<string>(nullable: true),
                    FromPartyName = table.Column<string>(nullable: true),
                    ToPartyId = table.Column<string>(nullable: true),
                    ToPartyName = table.Column<string>(nullable: true),
                    KapanId = table.Column<string>(nullable: true),
                    KapanName = table.Column<string>(nullable: true),
                    AccountToAssortType = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    SlipNo = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    SizeName = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    AssignWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SPAssortmentProcessSend",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: true),
                    SlipNo = table.Column<long>(nullable: false),
                    PurchaseDetailsId = table.Column<string>(nullable: true),
                    KapanId = table.Column<string>(nullable: true),
                    Kapan = table.Column<string>(nullable: true),
                    ShapeId = table.Column<string>(nullable: true),
                    Shape = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    PurityId = table.Column<string>(nullable: true),
                    Purity = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    NetWeight = table.Column<decimal>(nullable: false),
                    TIPWeight = table.Column<decimal>(nullable: false),
                    LessWeight = table.Column<decimal>(nullable: false),
                    Weight = table.Column<decimal>(nullable: false),
                    RejectedWeight = table.Column<decimal>(nullable: false),
                    AvailableWeight = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SPBoilProcessReceive",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: true),
                    BoilNo = table.Column<int>(nullable: false),
                    KapanId = table.Column<string>(nullable: true),
                    Kapan = table.Column<string>(nullable: true),
                    SlipNo = table.Column<string>(nullable: true),
                    ShapeId = table.Column<string>(nullable: true),
                    Shape = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    PurityId = table.Column<string>(nullable: true),
                    Purity = table.Column<string>(nullable: true),
                    TotalWeight = table.Column<decimal>(nullable: false),
                    AvailableWeight = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SPBoilProcessSend",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: true),
                    SlipNo = table.Column<long>(nullable: false),
                    KapanId = table.Column<string>(nullable: true),
                    Kapan = table.Column<string>(nullable: true),
                    PurchaseDetailsId = table.Column<string>(nullable: true),
                    ShapeId = table.Column<string>(nullable: true),
                    Shape = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    PurityId = table.Column<string>(nullable: true),
                    Purity = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    NetWeight = table.Column<decimal>(nullable: false),
                    TIPWeight = table.Column<decimal>(nullable: false),
                    LessWeight = table.Column<decimal>(nullable: false),
                    Weight = table.Column<decimal>(nullable: false),
                    RejectedWeight = table.Column<decimal>(nullable: false),
                    AvailableWeight = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SPBoilSendReceiveReportModels",
                columns: table => new
                {
                    BoilType = table.Column<int>(nullable: false),
                    BoilNo = table.Column<int>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    BranchId = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    JangadNo = table.Column<int>(nullable: false),
                    EntryDate = table.Column<DateTime>(nullable: true),
                    HandOverById = table.Column<string>(nullable: true),
                    HandOverByName = table.Column<string>(nullable: true),
                    HandOverToId = table.Column<string>(nullable: true),
                    HandOverToName = table.Column<string>(nullable: true),
                    KapanId = table.Column<string>(nullable: true),
                    KapanName = table.Column<string>(nullable: true),
                    ShapeId = table.Column<string>(nullable: true),
                    ShapeName = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    SizeName = table.Column<string>(nullable: true),
                    PurityId = table.Column<string>(nullable: true),
                    PurityName = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    SlipNo = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    LossWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    RejectionWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    TotalWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SPCharniProcessReceive",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: true),
                    CharniNo = table.Column<int>(nullable: false),
                    BoilJangadNo = table.Column<int>(nullable: false),
                    EntryDate = table.Column<string>(nullable: true),
                    KapanId = table.Column<string>(nullable: true),
                    Kapan = table.Column<string>(nullable: true),
                    SlipNo = table.Column<string>(nullable: true),
                    ShapeId = table.Column<string>(nullable: true),
                    Shape = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    PurityId = table.Column<string>(nullable: true),
                    Purity = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(nullable: false),
                    AvailableWeight = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SPCharniProcessSend",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: true),
                    SlipNo = table.Column<string>(nullable: true),
                    KapanId = table.Column<string>(nullable: true),
                    Kapan = table.Column<string>(nullable: true),
                    BoilNo = table.Column<int>(nullable: false),
                    ShapeId = table.Column<string>(nullable: true),
                    Shape = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    PurityId = table.Column<string>(nullable: true),
                    Purity = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(nullable: false),
                    AvailableWeight = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SPCharniSendReceiveReportModels",
                columns: table => new
                {
                    CharniType = table.Column<int>(nullable: false),
                    CharniNo = table.Column<int>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    BranchId = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    JangadNo = table.Column<int>(nullable: false),
                    EntryDate = table.Column<DateTime>(nullable: true),
                    HandOverById = table.Column<string>(nullable: true),
                    HandOverByName = table.Column<string>(nullable: true),
                    HandOverToId = table.Column<string>(nullable: true),
                    HandOverToName = table.Column<string>(nullable: true),
                    KapanId = table.Column<string>(nullable: true),
                    KapanName = table.Column<string>(nullable: true),
                    ShapeId = table.Column<string>(nullable: true),
                    ShapeName = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    SizeName = table.Column<string>(nullable: true),
                    PurityId = table.Column<string>(nullable: true),
                    PurityName = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    SlipNo = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    LossWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    RejectionWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    TotalWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SPContraModel",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ContraId = table.Column<string>(nullable: true),
                    FromPartyId = table.Column<string>(nullable: true),
                    ToPartyId = table.Column<string>(nullable: true),
                    FromPartyName = table.Column<string>(nullable: true),
                    ToPartyName = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SPContraModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SPExpenseModel",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: true),
                    Sr = table.Column<int>(nullable: false),
                    SrNo = table.Column<int>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    BranchId = table.Column<string>(nullable: true),
                    BranchName = table.Column<string>(nullable: true),
                    PartyId = table.Column<string>(nullable: true),
                    PartyName = table.Column<string>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SPGalaProcessReceive",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: true),
                    GalaNo = table.Column<int>(nullable: false),
                    KapanId = table.Column<string>(nullable: true),
                    Kapan = table.Column<string>(nullable: true),
                    SlipNo = table.Column<string>(nullable: true),
                    ShapeId = table.Column<string>(nullable: true),
                    Shape = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    PurityId = table.Column<string>(nullable: true),
                    Purity = table.Column<string>(nullable: true),
                    CharniSizeId = table.Column<string>(nullable: true),
                    CharniSize = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(nullable: false),
                    AvailableWeight = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SPGalaProcessSend",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: true),
                    SlipNo = table.Column<string>(nullable: true),
                    KapanId = table.Column<string>(nullable: true),
                    Kapan = table.Column<string>(nullable: true),
                    ShapeId = table.Column<string>(nullable: true),
                    Shape = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    PurityId = table.Column<string>(nullable: true),
                    Purity = table.Column<string>(nullable: true),
                    CharniSize = table.Column<string>(nullable: true),
                    CharniSizeId = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(nullable: false),
                    AvailableWeight = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SPGalaProcessSendReceiveReportModels",
                columns: table => new
                {
                    GalaProcessType = table.Column<int>(nullable: false),
                    GalaNo = table.Column<int>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    BranchId = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    JangadNo = table.Column<int>(nullable: false),
                    EntryDate = table.Column<DateTime>(nullable: true),
                    HandOverById = table.Column<string>(nullable: true),
                    HandOverByName = table.Column<string>(nullable: true),
                    HandOverToId = table.Column<string>(nullable: true),
                    HandOverToName = table.Column<string>(nullable: true),
                    KapanId = table.Column<string>(nullable: true),
                    KapanName = table.Column<string>(nullable: true),
                    ShapeId = table.Column<string>(nullable: true),
                    ShapeName = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    SizeName = table.Column<string>(nullable: true),
                    GalaNumberId = table.Column<string>(nullable: true),
                    GalaName = table.Column<string>(nullable: true),
                    PurityId = table.Column<string>(nullable: true),
                    PurityName = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    SlipNo = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    LossWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    RejectionWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    TotalWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SPJangadSendReceiveReportModel",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: true),
                    Sr = table.Column<int>(nullable: false),
                    SrNo = table.Column<int>(nullable: false),
                    FinancialYearId = table.Column<string>(nullable: true),
                    PartyId = table.Column<string>(nullable: true),
                    PartyName = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    SizeName = table.Column<string>(nullable: true),
                    BrokerId = table.Column<string>(nullable: true),
                    BrokerName = table.Column<string>(nullable: true),
                    Totalcts = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SPKapanMapping",
                columns: table => new
                {
                    Date = table.Column<DateTime>(nullable: false),
                    SlipNo = table.Column<long>(nullable: false),
                    SizeId = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    NetWeight = table.Column<decimal>(nullable: false),
                    AvailableCts = table.Column<decimal>(nullable: false),
                    Cts = table.Column<decimal>(nullable: true),
                    PurchaseID = table.Column<string>(nullable: true),
                    PurchaseDetailId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SPKapanMappingReportModel",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: true),
                    Sr = table.Column<int>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    BranchId = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    SlipNo = table.Column<string>(nullable: true),
                    KapanId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SPLoanReportModel",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: true),
                    Sr = table.Column<int>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    LoanType = table.Column<int>(nullable: false),
                    PartyId = table.Column<string>(nullable: true),
                    PartyName = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    DuratonType = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    InterestRate = table.Column<decimal>(nullable: false),
                    TotalInterest = table.Column<decimal>(nullable: false),
                    NetAmount = table.Column<decimal>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SPMixedReportModel",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    FromPartyId = table.Column<string>(nullable: true),
                    ToPartyId = table.Column<string>(nullable: true),
                    FromName = table.Column<string>(nullable: true),
                    ToName = table.Column<string>(nullable: true),
                    Credit = table.Column<double>(nullable: true),
                    Debit = table.Column<double>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    TrType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SPMixedReportModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SPNumberProcessReceive",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: true),
                    NumberNo = table.Column<int>(nullable: false),
                    KapanId = table.Column<string>(nullable: true),
                    Kapan = table.Column<string>(nullable: true),
                    SlipNo = table.Column<string>(nullable: true),
                    ShapeId = table.Column<string>(nullable: true),
                    Shape = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    PurityId = table.Column<string>(nullable: true),
                    Purity = table.Column<string>(nullable: true),
                    CharniSizeId = table.Column<string>(nullable: true),
                    CharniSize = table.Column<string>(nullable: true),
                    GalaNumberId = table.Column<string>(nullable: true),
                    GalaNumber = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(nullable: false),
                    AvailableWeight = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SPNumberProcessReturn",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: true),
                    SlipNo = table.Column<string>(nullable: true),
                    KapanId = table.Column<string>(nullable: true),
                    Kapan = table.Column<string>(nullable: true),
                    ShapeId = table.Column<string>(nullable: true),
                    Shape = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    PurityId = table.Column<string>(nullable: true),
                    Purity = table.Column<string>(nullable: true),
                    CharniSizeId = table.Column<string>(nullable: true),
                    CharniSize = table.Column<string>(nullable: true),
                    NumberId = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(nullable: false),
                    AvailableWeight = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SPNumberProcessSend",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: true),
                    SlipNo = table.Column<string>(nullable: true),
                    KapanId = table.Column<string>(nullable: true),
                    Kapan = table.Column<string>(nullable: true),
                    ShapeId = table.Column<string>(nullable: true),
                    Shape = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    PurityId = table.Column<string>(nullable: true),
                    Purity = table.Column<string>(nullable: true),
                    CharniSizeId = table.Column<string>(nullable: true),
                    CharniSize = table.Column<string>(nullable: true),
                    GalaNumberId = table.Column<string>(nullable: true),
                    GalaNumber = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(nullable: false),
                    AvailableWeight = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SPNumberProcessSendReceiveReportModels",
                columns: table => new
                {
                    NumberProcessType = table.Column<int>(nullable: false),
                    NumberNo = table.Column<int>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    BranchId = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    JangadNo = table.Column<int>(nullable: false),
                    EntryDate = table.Column<DateTime>(nullable: true),
                    HandOverById = table.Column<string>(nullable: true),
                    HandOverByName = table.Column<string>(nullable: true),
                    HandOverToId = table.Column<string>(nullable: true),
                    HandOverToName = table.Column<string>(nullable: true),
                    KapanId = table.Column<string>(nullable: true),
                    KapanName = table.Column<string>(nullable: true),
                    ShapeId = table.Column<string>(nullable: true),
                    ShapeName = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    SizeName = table.Column<string>(nullable: true),
                    GalaNumberId = table.Column<string>(nullable: true),
                    GalaName = table.Column<string>(nullable: true),
                    NumberId = table.Column<string>(nullable: true),
                    NumberName = table.Column<string>(nullable: true),
                    PurityId = table.Column<string>(nullable: true),
                    PurityName = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    SlipNo = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    LossWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    RejectionWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    TotalWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SPPaymentModel",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    GroupId = table.Column<string>(nullable: true),
                    FromPartyId = table.Column<string>(nullable: true),
                    ToPartyId = table.Column<string>(nullable: true),
                    FromName = table.Column<string>(nullable: true),
                    ToName = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    ChequeNo = table.Column<string>(nullable: true),
                    ChequeDate = table.Column<DateTime>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SPPaymentModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SPPaymentPSSlipDetails",
                columns: table => new
                {
                    PurchaseId = table.Column<string>(nullable: true),
                    Date = table.Column<string>(nullable: true),
                    PartyId = table.Column<string>(nullable: true),
                    Party = table.Column<string>(nullable: true),
                    SlipNo = table.Column<long>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    BranchId = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    Year = table.Column<string>(nullable: true),
                    GrossTotal = table.Column<double>(nullable: false),
                    RemainAmount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SPPurchaseModel",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    PurchaseBillNo = table.Column<long>(nullable: false),
                    SlipNo = table.Column<long>(nullable: false),
                    Date = table.Column<string>(nullable: true),
                    Time = table.Column<string>(nullable: true),
                    PartyId = table.Column<string>(nullable: true),
                    PartyName = table.Column<string>(nullable: true),
                    MobileNo = table.Column<string>(nullable: true),
                    BuyerId = table.Column<string>(nullable: true),
                    BuyerName = table.Column<string>(nullable: true),
                    BuyerMobileNo = table.Column<string>(nullable: true),
                    BrokerageId = table.Column<string>(nullable: true),
                    BrokerName = table.Column<string>(nullable: true),
                    BrokerMobileNo = table.Column<string>(nullable: true),
                    Total = table.Column<double>(nullable: false),
                    GrossTotal = table.Column<double>(nullable: false),
                    DueDays = table.Column<int>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: true),
                    PaymentDays = table.Column<int>(nullable: false),
                    PaymentDueDate = table.Column<DateTime>(nullable: true),
                    IsPF = table.Column<bool>(nullable: false),
                    IsSlip = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    KapanId = table.Column<string>(nullable: true),
                    KapanName = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    BuyingRate = table.Column<double>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    ApprovalType = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SPPurchaseModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SPPurchaseSlipDetailsModel",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SlipNo = table.Column<long>(nullable: false),
                    Date = table.Column<string>(nullable: true),
                    PartyId = table.Column<string>(nullable: true),
                    Party = table.Column<string>(nullable: true),
                    BrokerageId = table.Column<string>(nullable: true),
                    Broker = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SPPurchaseSlipDetailsModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SPSalesModel",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    SaleBillNo = table.Column<long>(nullable: false),
                    SlipNo = table.Column<long>(nullable: false),
                    Date = table.Column<string>(nullable: true),
                    Time = table.Column<string>(nullable: true),
                    PartyId = table.Column<string>(nullable: true),
                    PartyName = table.Column<string>(nullable: true),
                    MobileNo = table.Column<string>(nullable: true),
                    SalerId = table.Column<string>(nullable: true),
                    SalerName = table.Column<string>(nullable: true),
                    SalerMobileNo = table.Column<string>(nullable: true),
                    BrokerageId = table.Column<string>(nullable: true),
                    BrokerName = table.Column<string>(nullable: true),
                    BrokerMobileNo = table.Column<string>(nullable: true),
                    Total = table.Column<double>(nullable: false),
                    GrossTotal = table.Column<double>(nullable: false),
                    DueDays = table.Column<int>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: true),
                    PaymentDays = table.Column<int>(nullable: false),
                    PaymentDueDate = table.Column<DateTime>(nullable: true),
                    IsPF = table.Column<bool>(nullable: false),
                    IsSlip = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    KapanId = table.Column<string>(nullable: true),
                    KapanName = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    SaleRate = table.Column<double>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    ApprovalType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SPSalesModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SPSlipDetailPrintModel",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SlipNo = table.Column<long>(nullable: false),
                    Date = table.Column<string>(nullable: true),
                    PartyId = table.Column<string>(nullable: true),
                    Party = table.Column<string>(nullable: true),
                    BrokerageId = table.Column<string>(nullable: true),
                    Broker = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(nullable: false),
                    CVDWeight = table.Column<decimal>(nullable: false),
                    LessDiscountPercentage = table.Column<decimal>(nullable: false),
                    RejectedWeight = table.Column<decimal>(nullable: false),
                    LessWeight = table.Column<decimal>(nullable: false),
                    NetWeight = table.Column<decimal>(nullable: false),
                    CRate = table.Column<decimal>(nullable: false),
                    Disc = table.Column<decimal>(nullable: false),
                    CVDCharge = table.Column<decimal>(nullable: false),
                    DueDays = table.Column<int>(nullable: false),
                    PaymentDays = table.Column<int>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    Final = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SPSlipDetailPrintModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SPStockReportModelReport",
                columns: table => new
                {
                    Type = table.Column<string>(nullable: true),
                    KapanId = table.Column<string>(nullable: true),
                    Kapan = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    GalaNumber = table.Column<string>(nullable: true),
                    NumberId = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    AvailableWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    TotalWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "TransferMaster",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JangadNo = table.Column<int>(nullable: false),
                    Date = table.Column<string>(nullable: true),
                    Time = table.Column<string>(nullable: true),
                    TRansferById = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    CompanyId = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    Image1 = table.Column<byte[]>(nullable: true),
                    Image2 = table.Column<byte[]>(nullable: true),
                    Image3 = table.Column<byte[]>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    CharniSizeId = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    ApprovalType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountToAssortMaster",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<string>(nullable: true),
                    BranchId = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    EntryDate = table.Column<string>(nullable: true),
                    EntryTime = table.Column<string>(nullable: true),
                    AccountToAssortType = table.Column<int>(nullable: false),
                    FromParyId = table.Column<string>(nullable: true),
                    ToPartyId = table.Column<string>(nullable: true),
                    KapanId = table.Column<string>(nullable: true),
                    Department = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    TransferId = table.Column<string>(nullable: true),
                    TransferEntryId = table.Column<string>(nullable: true),
                    TransferType = table.Column<string>(nullable: true),
                    EntryType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountToAssortMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountToAssortMaster_CompanyMaster_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "CompanyMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    Amount = table.Column<double>(nullable: false),
                    CurrencyRate = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    CurrencyAmount = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
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
                    PersonName = table.Column<string>(nullable: true),
                    PurchaseMasterId = table.Column<string>(nullable: true),
                    SlipTransferEntryDate = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    ApprovalType = table.Column<int>(nullable: false)
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
                    CharniSizeId = table.Column<string>(nullable: true),
                    GalaSizeId = table.Column<string>(nullable: true),
                    NumberSizeId = table.Column<string>(nullable: true),
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
                    RoundUpAmount = table.Column<double>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    CurrencyRate = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    CurrencyAmount = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    IsTransfer = table.Column<bool>(nullable: false),
                    TransferParentId = table.Column<string>(nullable: true),
                    Category = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesDetails_SalesMaster_SalesId",
                        column: x => x.SalesId,
                        principalTable: "SalesMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountToAssortDetails",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountToAssortMasterId = table.Column<string>(nullable: true),
                    PurchaseDetailsId = table.Column<string>(nullable: true),
                    SlipNo = table.Column<string>(nullable: true),
                    ShapeId = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    PurityId = table.Column<string>(nullable: true),
                    BoilProcessId = table.Column<string>(nullable: true),
                    CharniProcessId = table.Column<string>(nullable: true),
                    GalaProcessId = table.Column<string>(nullable: true),
                    NumberProcessId = table.Column<string>(nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    AssignWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountToAssortDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountToAssortDetails_AccountToAssortMaster_AccountToAssortMasterId",
                        column: x => x.AccountToAssortMasterId,
                        principalTable: "AccountToAssortMaster",
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
                    SrNo = table.Column<int>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    BranchId = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    PartyId = table.Column<string>(nullable: true),
                    fromPartyId = table.Column<string>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    ApprovalType = table.Column<int>(nullable: false),
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
                    SlipNo = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
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
                name: "UserPermissionChild",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionMasterId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    KeyName = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermissionChild", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPermissionChild_UserMaster_UserId",
                        column: x => x.UserId,
                        principalTable: "UserMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountToAssortDetails_AccountToAssortMasterId",
                table: "AccountToAssortDetails",
                column: "AccountToAssortMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountToAssortMaster_CompanyId",
                table: "AccountToAssortMaster",
                column: "CompanyId");

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
                name: "IX_PurchaseDetails_PurchaseId",
                table: "PurchaseDetails",
                column: "PurchaseId");

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
                name: "IX_SlipTransferEntry_PurchaseMasterId",
                table: "SlipTransferEntry",
                column: "PurchaseMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMaster_BranchMasterId",
                table: "UserMaster",
                column: "BranchMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermissionChild_UserId",
                table: "UserPermissionChild",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountToAssortDetails");

            migrationBuilder.DropTable(
                name: "ApprovalPermissionMaster");

            migrationBuilder.DropTable(
                name: "BoilProcessMaster");

            migrationBuilder.DropTable(
                name: "BrokerageMaster");

            migrationBuilder.DropTable(
                name: "CaratCategoryType");

            migrationBuilder.DropTable(
                name: "CharniProcessMaster");

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
                name: "GalaProcessMaster");

            migrationBuilder.DropTable(
                name: "JangadMaster");

            migrationBuilder.DropTable(
                name: "JangadPrintDetailModel");

            migrationBuilder.DropTable(
                name: "JangadSPReceiveModel");

            migrationBuilder.DropTable(
                name: "KapanMappingMaster");

            migrationBuilder.DropTable(
                name: "KapanMaster");

            migrationBuilder.DropTable(
                name: "LessWeightDetails");

            migrationBuilder.DropTable(
                name: "LoanMaster");

            migrationBuilder.DropTable(
                name: "NumberMaster");

            migrationBuilder.DropTable(
                name: "NumberProcessMaster");

            migrationBuilder.DropTable(
                name: "OpeningStockMaster");

            migrationBuilder.DropTable(
                name: "PaymentDetails");

            migrationBuilder.DropTable(
                name: "PermissionMaster");

            migrationBuilder.DropTable(
                name: "PriceMaster");

            migrationBuilder.DropTable(
                name: "PriceSPModel");

            migrationBuilder.DropTable(
                name: "PurchaseDetails");

            migrationBuilder.DropTable(
                name: "PurityMaster");

            migrationBuilder.DropTable(
                name: "RejectionInOutMaster");

            migrationBuilder.DropTable(
                name: "SalaryDetails");

            migrationBuilder.DropTable(
                name: "SalesDetails");

            migrationBuilder.DropTable(
                name: "SalesItemDetails");

            migrationBuilder.DropTable(
                name: "ShapeMaster");

            migrationBuilder.DropTable(
                name: "SizeMaster");

            migrationBuilder.DropTable(
                name: "SlipTransferEntry");

            migrationBuilder.DropTable(
                name: "SPAccountToAssoftReceiveReportModel");

            migrationBuilder.DropTable(
                name: "SPAccountToAssortSendReceiveReportModels");

            migrationBuilder.DropTable(
                name: "SPAssortmentProcessSend");

            migrationBuilder.DropTable(
                name: "SPBoilProcessReceive");

            migrationBuilder.DropTable(
                name: "SPBoilProcessSend");

            migrationBuilder.DropTable(
                name: "SPBoilSendReceiveReportModels");

            migrationBuilder.DropTable(
                name: "SPCharniProcessReceive");

            migrationBuilder.DropTable(
                name: "SPCharniProcessSend");

            migrationBuilder.DropTable(
                name: "SPCharniSendReceiveReportModels");

            migrationBuilder.DropTable(
                name: "SPContraModel");

            migrationBuilder.DropTable(
                name: "SPExpenseModel");

            migrationBuilder.DropTable(
                name: "SPGalaProcessReceive");

            migrationBuilder.DropTable(
                name: "SPGalaProcessSend");

            migrationBuilder.DropTable(
                name: "SPGalaProcessSendReceiveReportModels");

            migrationBuilder.DropTable(
                name: "SPJangadSendReceiveReportModel");

            migrationBuilder.DropTable(
                name: "SPKapanMapping");

            migrationBuilder.DropTable(
                name: "SPKapanMappingReportModel");

            migrationBuilder.DropTable(
                name: "SPLoanReportModel");

            migrationBuilder.DropTable(
                name: "SPMixedReportModel");

            migrationBuilder.DropTable(
                name: "SPNumberProcessReceive");

            migrationBuilder.DropTable(
                name: "SPNumberProcessReturn");

            migrationBuilder.DropTable(
                name: "SPNumberProcessSend");

            migrationBuilder.DropTable(
                name: "SPNumberProcessSendReceiveReportModels");

            migrationBuilder.DropTable(
                name: "SPPaymentModel");

            migrationBuilder.DropTable(
                name: "SPPaymentPSSlipDetails");

            migrationBuilder.DropTable(
                name: "SPPurchaseModel");

            migrationBuilder.DropTable(
                name: "SPPurchaseSlipDetailsModel");

            migrationBuilder.DropTable(
                name: "SPSalesModel");

            migrationBuilder.DropTable(
                name: "SPSlipDetailPrintModel");

            migrationBuilder.DropTable(
                name: "SPStockReportModelReport");

            migrationBuilder.DropTable(
                name: "TransferMaster");

            migrationBuilder.DropTable(
                name: "UserPermissionChild");

            migrationBuilder.DropTable(
                name: "AccountToAssortMaster");

            migrationBuilder.DropTable(
                name: "ContraEntryMaster");

            migrationBuilder.DropTable(
                name: "ExpenseMaster");

            migrationBuilder.DropTable(
                name: "LessWeightMasters");

            migrationBuilder.DropTable(
                name: "PaymentMaster");

            migrationBuilder.DropTable(
                name: "PartyMaster");

            migrationBuilder.DropTable(
                name: "SalaryMaster");

            migrationBuilder.DropTable(
                name: "SalesMaster");

            migrationBuilder.DropTable(
                name: "PurchaseMaster");

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
