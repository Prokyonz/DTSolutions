using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class AddExtraColumnsInTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "CalculatorMaster",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FinancialYearId",
                table: "CalculatorMaster",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "CalculatorMaster");

            migrationBuilder.DropColumn(
                name: "FinancialYearId",
                table: "CalculatorMaster");
        }
    }
}
