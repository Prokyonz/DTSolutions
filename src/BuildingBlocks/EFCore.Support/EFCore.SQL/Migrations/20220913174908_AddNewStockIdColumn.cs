using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class AddNewStockIdColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BranchName",
                table: "SPStockReportModelReport",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BranchName",
                table: "SPOpeningStockSPModel",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SlipNo",
                table: "SPAssortmentProcessSend",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<string>(
                name: "StockId",
                table: "AccountToAssortDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BranchName",
                table: "SPStockReportModelReport");

            migrationBuilder.DropColumn(
                name: "BranchName",
                table: "SPOpeningStockSPModel");

            migrationBuilder.DropColumn(
                name: "StockId",
                table: "AccountToAssortDetails");

            migrationBuilder.AlterColumn<long>(
                name: "SlipNo",
                table: "SPAssortmentProcessSend",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
