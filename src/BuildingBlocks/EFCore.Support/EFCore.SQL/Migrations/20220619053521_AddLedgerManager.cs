using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class AddLedgerManager : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PurchaseMasterId",
                table: "SPAssortmentProcessSend",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LedgerBalanceManager",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    LedgerId = table.Column<string>(nullable: true),
                    Balance = table.Column<decimal>(nullable: false),
                    TypeOfBalance = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LedgerBalanceManager", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SPLedgerBalanceReport",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: true),
                    CompanyId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    SubType = table.Column<string>(nullable: true),
                    OpeningBalance = table.Column<decimal>(type: "decimal(18, 4)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SPOpeningStockSPModel",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    SrNo = table.Column<int>(nullable: false),
                    KapanId = table.Column<string>(nullable: true),
                    KapanName = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    SizeName = table.Column<string>(nullable: true),
                    NumberId = table.Column<string>(nullable: true),
                    NumberName = table.Column<string>(nullable: true),
                    TotalCts = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    CompanyId = table.Column<string>(nullable: true),
                    BranchId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SPOpeningStockSPModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SPPayableReceivableReport",
                columns: table => new
                {
                    Type = table.Column<string>(nullable: true),
                    PartyId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Total = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SPPFReportModels",
                columns: table => new
                {
                    Type = table.Column<string>(nullable: true),
                    CompanyId = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    PartyId = table.Column<string>(nullable: true),
                    PartyName = table.Column<string>(nullable: true),
                    BrokerId = table.Column<string>(nullable: true),
                    BrokerName = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    NumberId = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    NetWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    Rate = table.Column<double>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SPTransferCategoryList",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    CategoryID = table.Column<int>(nullable: false),
                    Category = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SPWeeklyPurchaseReport",
                columns: table => new
                {
                    WeekNo = table.Column<string>(nullable: true),
                    Period = table.Column<string>(nullable: true),
                    Amount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LedgerBalanceManager");

            migrationBuilder.DropTable(
                name: "SPLedgerBalanceReport");

            migrationBuilder.DropTable(
                name: "SPOpeningStockSPModel");

            migrationBuilder.DropTable(
                name: "SPPayableReceivableReport");

            migrationBuilder.DropTable(
                name: "SPPFReportModels");

            migrationBuilder.DropTable(
                name: "SPTransferCategoryList");

            migrationBuilder.DropTable(
                name: "SPWeeklyPurchaseReport");

            migrationBuilder.DropColumn(
                name: "PurchaseMasterId",
                table: "SPAssortmentProcessSend");
        }
    }
}
