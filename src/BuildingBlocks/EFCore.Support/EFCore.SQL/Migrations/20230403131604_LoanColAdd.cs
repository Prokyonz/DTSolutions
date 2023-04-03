using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class LoanColAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableWeight",
                table: "SPStockReportModelReport");

            migrationBuilder.DropColumn(
                name: "FinancialYearId",
                table: "SPStockReportModelReport");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SPStockReportModelReport");

            migrationBuilder.DropColumn(
                name: "Kapan",
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
                name: "Shape",
                table: "SPStockReportModelReport");

            migrationBuilder.DropColumn(
                name: "ShapeId",
                table: "SPStockReportModelReport");

            migrationBuilder.DropColumn(
                name: "Size",
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

            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "SPStockReportModelReport",
                newName: "OutwardRate");

            migrationBuilder.RenameColumn(
                name: "UsedWeight",
                table: "SPStockReportModelReport",
                newName: "OutwardNetWeight");

            migrationBuilder.RenameColumn(
                name: "TipWeight",
                table: "SPStockReportModelReport",
                newName: "OutwardAmount");

            migrationBuilder.RenameColumn(
                name: "RejectedWeight",
                table: "SPStockReportModelReport",
                newName: "InwardRate");

            migrationBuilder.RenameColumn(
                name: "NetWeight",
                table: "SPStockReportModelReport",
                newName: "InwardNetWeight");

            migrationBuilder.RenameColumn(
                name: "LessWeight",
                table: "SPStockReportModelReport",
                newName: "InwardAmount");

            migrationBuilder.AddColumn<string>(
                name: "BranchName",
                table: "SPStockReportModelReport",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "SPStockReportModelReport",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Party",
                table: "SPStockReportModelReport",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CashBankPartyId",
                table: "LoanMaster",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SPNumberkReportModelReport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    OperationType = table.Column<string>(nullable: true),
                    BranchName = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    Kapan = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    InwardNetWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    InwardRate = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    InwardAmount = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    OutwardNetWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    OutwardRate = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    OutwardAmount = table.Column<decimal>(type: "decimal(18, 4)", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SPNumberkReportModelReport");

            migrationBuilder.DropColumn(
                name: "BranchName",
                table: "SPStockReportModelReport");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "SPStockReportModelReport");

            migrationBuilder.DropColumn(
                name: "Party",
                table: "SPStockReportModelReport");

            migrationBuilder.DropColumn(
                name: "CashBankPartyId",
                table: "LoanMaster");

            migrationBuilder.RenameColumn(
                name: "OutwardRate",
                table: "SPStockReportModelReport",
                newName: "Weight");

            migrationBuilder.RenameColumn(
                name: "OutwardNetWeight",
                table: "SPStockReportModelReport",
                newName: "UsedWeight");

            migrationBuilder.RenameColumn(
                name: "OutwardAmount",
                table: "SPStockReportModelReport",
                newName: "TipWeight");

            migrationBuilder.RenameColumn(
                name: "InwardRate",
                table: "SPStockReportModelReport",
                newName: "RejectedWeight");

            migrationBuilder.RenameColumn(
                name: "InwardNetWeight",
                table: "SPStockReportModelReport",
                newName: "NetWeight");

            migrationBuilder.RenameColumn(
                name: "InwardAmount",
                table: "SPStockReportModelReport",
                newName: "LessWeight");

            migrationBuilder.AddColumn<decimal>(
                name: "AvailableWeight",
                table: "SPStockReportModelReport",
                type: "decimal(18, 4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "FinancialYearId",
                table: "SPStockReportModelReport",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "SPStockReportModelReport",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Kapan",
                table: "SPStockReportModelReport",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PurchaseDetailsId",
                table: "SPStockReportModelReport",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PurchaseMasterId",
                table: "SPStockReportModelReport",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Purity",
                table: "SPStockReportModelReport",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PurityId",
                table: "SPStockReportModelReport",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Shape",
                table: "SPStockReportModelReport",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShapeId",
                table: "SPStockReportModelReport",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "SPStockReportModelReport",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SizeId",
                table: "SPStockReportModelReport",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SlipNo",
                table: "SPStockReportModelReport",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StockId",
                table: "SPStockReportModelReport",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
