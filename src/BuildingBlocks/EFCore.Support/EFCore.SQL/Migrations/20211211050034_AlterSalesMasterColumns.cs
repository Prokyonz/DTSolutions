using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class AlterSalesMasterColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesDetails_PurchaseMaster_SalesId",
                table: "SalesDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesDetails_SalesMaster_SalesMasterId",
                table: "SalesDetails");

            migrationBuilder.DropIndex(
                name: "IX_SalesDetails_SalesMasterId",
                table: "SalesDetails");

            migrationBuilder.DropColumn(
                name: "PaymentDueDays",
                table: "SalesMaster");

            migrationBuilder.DropColumn(
                name: "FromCategory",
                table: "SalesDetails");

            migrationBuilder.DropColumn(
                name: "SalesMasterId",
                table: "SalesDetails");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "SalesDetails");

            migrationBuilder.AddColumn<bool>(
                name: "IsTransfer",
                table: "SalesMaster",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "PaymentDueDate",
                table: "SalesMaster",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "TransferParentId",
                table: "SalesMaster",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "RoundUpAmount",
                table: "SalesDetails",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "SalesDetails",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "SalesDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CharniSizeId",
                table: "SalesDetails",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CurrencyAmount",
                table: "SalesDetails",
                type: "decimal(18, 4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CurrencyRate",
                table: "SalesDetails",
                type: "decimal(18, 4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsTransfer",
                table: "SalesDetails",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "NumberSizeId",
                table: "SalesDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransferParentId",
                table: "SalesDetails",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SalesItemDetails",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: true),
                    CompanyId = table.Column<string>(nullable: true),
                    BranchId = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    KapanId = table.Column<string>(nullable: true),
                    Kapan = table.Column<string>(nullable: true),
                    ShapeId = table.Column<string>(nullable: true),
                    Shape = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    PurityId = table.Column<string>(nullable: true),
                    Purity = table.Column<string>(nullable: true),
                    CharniSizeId = table.Column<string>(nullable: true),
                    CharniSize = table.Column<string>(nullable: true),
                    NumberSizeId = table.Column<string>(nullable: true),
                    NumberSize = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SPNumberProcessReturn",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: true),
                    SlipNo = table.Column<string>(nullable: true),
                    KapanId = table.Column<string>(nullable: true),
                    Kapan = table.Column<string>(nullable: true),
                    ShapeId = table.Column<string>(nullable: true),
                    Shape = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    PurityId = table.Column<string>(nullable: true),
                    Purity = table.Column<string>(nullable: true),
                    NumberId = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(nullable: false),
                    AvailableWeight = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.AddForeignKey(
                name: "FK_SalesDetails_SalesMaster_SalesId",
                table: "SalesDetails",
                column: "SalesId",
                principalTable: "SalesMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesDetails_SalesMaster_SalesId",
                table: "SalesDetails");

            migrationBuilder.DropTable(
                name: "SalesItemDetails");

            migrationBuilder.DropTable(
                name: "SPNumberProcessReturn");

            migrationBuilder.DropColumn(
                name: "IsTransfer",
                table: "SalesMaster");

            migrationBuilder.DropColumn(
                name: "PaymentDueDate",
                table: "SalesMaster");

            migrationBuilder.DropColumn(
                name: "TransferParentId",
                table: "SalesMaster");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "SalesDetails");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "SalesDetails");

            migrationBuilder.DropColumn(
                name: "CharniSizeId",
                table: "SalesDetails");

            migrationBuilder.DropColumn(
                name: "CurrencyAmount",
                table: "SalesDetails");

            migrationBuilder.DropColumn(
                name: "CurrencyRate",
                table: "SalesDetails");

            migrationBuilder.DropColumn(
                name: "IsTransfer",
                table: "SalesDetails");

            migrationBuilder.DropColumn(
                name: "NumberSizeId",
                table: "SalesDetails");

            migrationBuilder.DropColumn(
                name: "TransferParentId",
                table: "SalesDetails");

            migrationBuilder.AddColumn<int>(
                name: "PaymentDueDays",
                table: "SalesMaster",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<double>(
                name: "RoundUpAmount",
                table: "SalesDetails",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FromCategory",
                table: "SalesDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SalesMasterId",
                table: "SalesDetails",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Total",
                table: "SalesDetails",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_SalesDetails_SalesMasterId",
                table: "SalesDetails",
                column: "SalesMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesDetails_PurchaseMaster_SalesId",
                table: "SalesDetails",
                column: "SalesId",
                principalTable: "PurchaseMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesDetails_SalesMaster_SalesMasterId",
                table: "SalesDetails",
                column: "SalesMasterId",
                principalTable: "SalesMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
