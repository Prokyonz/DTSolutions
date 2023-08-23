using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class AddNewColumnInExpenseDetails1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PurchaseDetailsId",
                table: "SPKapanMappingReportModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "SPKapanMapping",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CrDrType",
                table: "ExpenseDetails",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PurchaseDetailsId",
                table: "SPKapanMappingReportModel");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "SPKapanMapping");

            migrationBuilder.DropColumn(
                name: "CrDrType",
                table: "ExpenseDetails");
        }
    }
}
