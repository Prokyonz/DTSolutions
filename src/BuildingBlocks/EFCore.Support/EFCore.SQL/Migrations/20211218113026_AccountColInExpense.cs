using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class AccountColInExpense : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GalaSizeId",
                table: "SalesItemDetails");

            migrationBuilder.AddColumn<string>(
                name: "Kapan",
                table: "SPAssortmentProcessSend",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KapanId",
                table: "SPAssortmentProcessSend",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GalaNumberId",
                table: "SalesItemDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "fromPartyId",
                table: "ExpenseDetails",
                nullable: true);

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
                    Remarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SPSalesModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SPSalesModel");

            migrationBuilder.DropColumn(
                name: "Kapan",
                table: "SPAssortmentProcessSend");

            migrationBuilder.DropColumn(
                name: "KapanId",
                table: "SPAssortmentProcessSend");

            migrationBuilder.DropColumn(
                name: "GalaNumberId",
                table: "SalesItemDetails");

            migrationBuilder.DropColumn(
                name: "fromPartyId",
                table: "ExpenseDetails");

            migrationBuilder.AddColumn<string>(
                name: "GalaSizeId",
                table: "SalesItemDetails",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
