using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class PurchaseDeialsColumUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoundUpAmount",
                table: "PurchaseDetails");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "PurchaseDetails");

            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "PurchaseDetails",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<decimal>(
                name: "CurrencyAmount",
                table: "PurchaseDetails",
                type: "decimal(18, 4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CurrencyRate",
                table: "PurchaseDetails",
                type: "decimal(18, 4)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "PurchaseDetails");

            migrationBuilder.DropColumn(
                name: "CurrencyAmount",
                table: "PurchaseDetails");

            migrationBuilder.DropColumn(
                name: "CurrencyRate",
                table: "PurchaseDetails");

            migrationBuilder.AddColumn<double>(
                name: "RoundUpAmount",
                table: "PurchaseDetails",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Total",
                table: "PurchaseDetails",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
