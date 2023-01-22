using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class AddStockIdColumnInSalesdetailssummaryTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OverTimeRateHrs",
                table: "SPSalaryReport",
                newName: "OTPlusRate");

            migrationBuilder.RenameColumn(
                name: "OverTimeHrs",
                table: "SPSalaryReport",
                newName: "OTMinusRate");

            migrationBuilder.AddColumn<decimal>(
                name: "OTMinusHrs",
                table: "SPSalaryReport",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OTPlusHrs",
                table: "SPSalaryReport",
                type: "decimal(18, 4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "SrNo",
                table: "SPSalaryReport",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "StockId",
                table: "SalesDetailsSummary",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OTMinusHrs",
                table: "SPSalaryReport");

            migrationBuilder.DropColumn(
                name: "OTPlusHrs",
                table: "SPSalaryReport");

            migrationBuilder.DropColumn(
                name: "SrNo",
                table: "SPSalaryReport");

            migrationBuilder.DropColumn(
                name: "StockId",
                table: "SalesDetailsSummary");

            migrationBuilder.RenameColumn(
                name: "OTPlusRate",
                table: "SPSalaryReport",
                newName: "OverTimeRateHrs");

            migrationBuilder.RenameColumn(
                name: "OTMinusRate",
                table: "SPSalaryReport",
                newName: "OverTimeHrs");
        }
    }
}
