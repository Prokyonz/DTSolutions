using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class UpdateSlipTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BranchId",
                table: "SlipTransferEntry",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FinancialYearId",
                table: "SlipTransferEntry",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SrNo",
                table: "SlipTransferEntry",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "SlipTransferEntry");

            migrationBuilder.DropColumn(
                name: "FinancialYearId",
                table: "SlipTransferEntry");

            migrationBuilder.DropColumn(
                name: "SrNo",
                table: "SlipTransferEntry");
        }
    }
}
