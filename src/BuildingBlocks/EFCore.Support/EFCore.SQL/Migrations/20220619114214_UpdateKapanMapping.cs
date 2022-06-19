using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class UpdateKapanMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "SPPurchaseModel");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "SPPurchaseModel",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "CVDAmount",
                table: "SPPurchaseModel",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<decimal>(
                name: "LessWeight",
                table: "SPPurchaseModel",
                type: "decimal(18, 4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "NetWeight",
                table: "SPPurchaseModel",
                type: "decimal(18, 4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<double>(
                name: "RoundUpAmount",
                table: "SPPurchaseModel",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TransferCaratRate",
                table: "KapanMappingMaster",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "TransferEntryId",
                table: "KapanMappingMaster",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransferId",
                table: "KapanMappingMaster",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransferType",
                table: "KapanMappingMaster",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CVDAmount",
                table: "SPPurchaseModel");

            migrationBuilder.DropColumn(
                name: "LessWeight",
                table: "SPPurchaseModel");

            migrationBuilder.DropColumn(
                name: "NetWeight",
                table: "SPPurchaseModel");

            migrationBuilder.DropColumn(
                name: "RoundUpAmount",
                table: "SPPurchaseModel");

            migrationBuilder.DropColumn(
                name: "TransferCaratRate",
                table: "KapanMappingMaster");

            migrationBuilder.DropColumn(
                name: "TransferEntryId",
                table: "KapanMappingMaster");

            migrationBuilder.DropColumn(
                name: "TransferId",
                table: "KapanMappingMaster");

            migrationBuilder.DropColumn(
                name: "TransferType",
                table: "KapanMappingMaster");

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "SPPurchaseModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "SPPurchaseModel",
                type: "datetime2",
                nullable: true);
        }
    }
}
