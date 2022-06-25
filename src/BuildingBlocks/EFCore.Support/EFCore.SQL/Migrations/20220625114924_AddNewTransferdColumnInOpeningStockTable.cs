using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class AddNewTransferdColumnInOpeningStockTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KapanName",
                table: "SPSalesModel");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "SPSalesModel",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "CVDAmount",
                table: "SPSalesModel",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<decimal>(
                name: "LessWeight",
                table: "SPSalesModel",
                type: "decimal(18, 4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "NetWeight",
                table: "SPSalesModel",
                type: "decimal(18, 4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<double>(
                name: "RoundUpAmount",
                table: "SPSalesModel",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "PurId",
                table: "SPPurchaseModel",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ClosingBalance",
                table: "SPLedgerBalanceReport",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "LedgerId",
                table: "SPLedgerBalanceReport",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TransferCaratRate",
                table: "OpeningStockMaster",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "TransferEntryId",
                table: "OpeningStockMaster",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransferType",
                table: "OpeningStockMaster",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SPBalanceSheetReport",
                columns: table => new
                {
                    ColType = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18, 4)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SPKapanLagadReportModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    SlipNo = table.Column<long>(nullable: false),
                    Party = table.Column<string>(nullable: true),
                    NetWeight = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Category = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    Kapan = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SPProfitLossReport",
                columns: table => new
                {
                    ColType = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18, 4)", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SPBalanceSheetReport");

            migrationBuilder.DropTable(
                name: "SPKapanLagadReportModel");

            migrationBuilder.DropTable(
                name: "SPProfitLossReport");

            migrationBuilder.DropColumn(
                name: "CVDAmount",
                table: "SPSalesModel");

            migrationBuilder.DropColumn(
                name: "LessWeight",
                table: "SPSalesModel");

            migrationBuilder.DropColumn(
                name: "NetWeight",
                table: "SPSalesModel");

            migrationBuilder.DropColumn(
                name: "RoundUpAmount",
                table: "SPSalesModel");

            migrationBuilder.DropColumn(
                name: "PurId",
                table: "SPPurchaseModel");

            migrationBuilder.DropColumn(
                name: "ClosingBalance",
                table: "SPLedgerBalanceReport");

            migrationBuilder.DropColumn(
                name: "LedgerId",
                table: "SPLedgerBalanceReport");

            migrationBuilder.DropColumn(
                name: "TransferCaratRate",
                table: "OpeningStockMaster");

            migrationBuilder.DropColumn(
                name: "TransferEntryId",
                table: "OpeningStockMaster");

            migrationBuilder.DropColumn(
                name: "TransferType",
                table: "OpeningStockMaster");

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "SPSalesModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KapanName",
                table: "SPSalesModel",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
