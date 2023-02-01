using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class AddKapanTypeColumnInSalesDetailsSummaryTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BranchName",
                table: "SPStockReportModelReport");

            migrationBuilder.DropColumn(
                name: "GalaNumber",
                table: "SPStockReportModelReport");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "SPStockReportModelReport");

            migrationBuilder.DropColumn(
                name: "NumberId",
                table: "SPStockReportModelReport");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "SPStockReportModelReport");

            migrationBuilder.RenameColumn(
                name: "TotalWeight",
                table: "SPStockReportModelReport",
                newName: "Weight");

            migrationBuilder.RenameColumn(
                name: "Rate",
                table: "SPStockReportModelReport",
                newName: "UsedWeight");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "SPStockReportModelReport",
                newName: "TipWeight");

            migrationBuilder.AddColumn<string>(
                name: "FinancialYearId",
                table: "SPStockReportModelReport",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "SPStockReportModelReport",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "LessWeight",
                table: "SPStockReportModelReport",
                type: "decimal(18, 4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "NetWeight",
                table: "SPStockReportModelReport",
                type: "decimal(18, 4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "PurchaseDetailsId",
                table: "SPStockReportModelReport",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PurchaseMasterId",
                table: "SPStockReportModelReport",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Purity",
                table: "SPStockReportModelReport",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PurityId",
                table: "SPStockReportModelReport",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RejectedWeight",
                table: "SPStockReportModelReport",
                type: "decimal(18, 4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Shape",
                table: "SPStockReportModelReport",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShapeId",
                table: "SPStockReportModelReport",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SizeId",
                table: "SPStockReportModelReport",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SlipNo",
                table: "SPStockReportModelReport",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StockId",
                table: "SPStockReportModelReport",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KapanType",
                table: "SPAssortmentProcessSend",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KapanType",
                table: "SalesDetailsSummary",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinancialYearId",
                table: "SPStockReportModelReport");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SPStockReportModelReport");

            migrationBuilder.DropColumn(
                name: "LessWeight",
                table: "SPStockReportModelReport");

            migrationBuilder.DropColumn(
                name: "NetWeight",
                table: "SPStockReportModelReport");

            migrationBuilder.DropColumn(
                name: "PurchaseDetailsId",
                table: "SPStockReportModelReport");

            migrationBuilder.DropColumn(
                name: "PurchaseMasterId",
                table: "SPStockReportModelReport");

            migrationBuilder.DropColumn(
                name: "Purity",
                table: "SPStockReportModelReport");

            migrationBuilder.DropColumn(
                name: "PurityId",
                table: "SPStockReportModelReport");

            migrationBuilder.DropColumn(
                name: "RejectedWeight",
                table: "SPStockReportModelReport");

            migrationBuilder.DropColumn(
                name: "Shape",
                table: "SPStockReportModelReport");

            migrationBuilder.DropColumn(
                name: "ShapeId",
                table: "SPStockReportModelReport");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "SPStockReportModelReport");

            migrationBuilder.DropColumn(
                name: "SlipNo",
                table: "SPStockReportModelReport");

            migrationBuilder.DropColumn(
                name: "StockId",
                table: "SPStockReportModelReport");

            migrationBuilder.DropColumn(
                name: "KapanType",
                table: "SPAssortmentProcessSend");

            migrationBuilder.DropColumn(
                name: "KapanType",
                table: "SalesDetailsSummary");

            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "SPStockReportModelReport",
                newName: "TotalWeight");

            migrationBuilder.RenameColumn(
                name: "UsedWeight",
                table: "SPStockReportModelReport",
                newName: "Rate");

            migrationBuilder.RenameColumn(
                name: "TipWeight",
                table: "SPStockReportModelReport",
                newName: "Amount");

            migrationBuilder.AddColumn<string>(
                name: "BranchName",
                table: "SPStockReportModelReport",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GalaNumber",
                table: "SPStockReportModelReport",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "SPStockReportModelReport",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumberId",
                table: "SPStockReportModelReport",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "SPStockReportModelReport",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
