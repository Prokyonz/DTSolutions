using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class EntryDateInExpenseDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "SPStockReportModelReport",
                type: "decimal(18, 4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Rate",
                table: "SPStockReportModelReport",
                type: "decimal(18, 4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "BranchName",
                table: "SPSalesModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KapanName",
                table: "SPSalesModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BranchName",
                table: "SPPurchaseModel",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ProfitLossPer",
                table: "SPKapanLagadReportModel",
                type: "decimal(18, 2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Records",
                table: "SPKapanLagadReportModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EntryDate",
                table: "ExpenseDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "SPStockReportModelReport");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "SPStockReportModelReport");

            migrationBuilder.DropColumn(
                name: "BranchName",
                table: "SPSalesModel");

            migrationBuilder.DropColumn(
                name: "KapanName",
                table: "SPSalesModel");

            migrationBuilder.DropColumn(
                name: "BranchName",
                table: "SPPurchaseModel");

            migrationBuilder.DropColumn(
                name: "ProfitLossPer",
                table: "SPKapanLagadReportModel");

            migrationBuilder.DropColumn(
                name: "Records",
                table: "SPKapanLagadReportModel");

            migrationBuilder.DropColumn(
                name: "EntryDate",
                table: "ExpenseDetails");
        }
    }
}
