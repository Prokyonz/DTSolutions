using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class RemoveRoleTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "SPMixedReportModel");

            migrationBuilder.AddColumn<double>(
                name: "Credit",
                table: "SPMixedReportModel",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Debit",
                table: "SPMixedReportModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CharniSize",
                table: "SPGalaProcessReceive",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CharniSizeId",
                table: "SPGalaProcessReceive",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Credit",
                table: "SPMixedReportModel");

            migrationBuilder.DropColumn(
                name: "Debit",
                table: "SPMixedReportModel");

            migrationBuilder.DropColumn(
                name: "CharniSize",
                table: "SPGalaProcessReceive");

            migrationBuilder.DropColumn(
                name: "CharniSizeId",
                table: "SPGalaProcessReceive");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "SPMixedReportModel",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
