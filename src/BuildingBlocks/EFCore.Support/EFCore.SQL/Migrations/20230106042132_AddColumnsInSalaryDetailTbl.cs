using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class AddColumnsInSalaryDetailTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OverTimeRateHrs",
                table: "SalaryDetails",
                newName: "OTPlusRate");

            migrationBuilder.RenameColumn(
                name: "OverTimeHrs",
                table: "SalaryDetails",
                newName: "OTPlusAmount");

            migrationBuilder.AddColumn<decimal>(
                name: "OTMinusAmount",
                table: "SalaryDetails",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OTMinusHrs",
                table: "SalaryDetails",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OTMinusRate",
                table: "SalaryDetails",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OTPlusHrs",
                table: "SalaryDetails",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OTMinusAmount",
                table: "SalaryDetails");

            migrationBuilder.DropColumn(
                name: "OTMinusHrs",
                table: "SalaryDetails");

            migrationBuilder.DropColumn(
                name: "OTMinusRate",
                table: "SalaryDetails");

            migrationBuilder.DropColumn(
                name: "OTPlusHrs",
                table: "SalaryDetails");

            migrationBuilder.RenameColumn(
                name: "OTPlusRate",
                table: "SalaryDetails",
                newName: "OverTimeRateHrs");

            migrationBuilder.RenameColumn(
                name: "OTPlusAmount",
                table: "SalaryDetails",
                newName: "OverTimeHrs");
        }
    }
}
