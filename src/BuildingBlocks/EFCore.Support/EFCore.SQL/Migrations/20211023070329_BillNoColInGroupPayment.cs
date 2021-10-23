using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class BillNoColInGroupPayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BillNo",
                table: "GroupPaymentMaster",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FinancialYearId",
                table: "ExpenseDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BillNo",
                table: "GroupPaymentMaster");

            migrationBuilder.DropColumn(
                name: "FinancialYearId",
                table: "ExpenseDetails");
        }
    }
}
