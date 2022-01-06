using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class MicedReprtUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Amount = table.Column<decimal>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    TrType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SPMixedReportModel", x => x.Id);
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SPMixedReportModel");

            migrationBuilder.DropTable(
                name: "SPPaymentPSSlipDetails");
        }
    }
}
