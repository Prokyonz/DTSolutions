using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class UpdateTablesSP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Week_End_Date",
                table: "SPWeeklyPurchaseReport",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Week_Start_Date",
                table: "SPWeeklyPurchaseReport",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AdjustAmount",
                table: "SPPurchaseModel",
                type: "decimal(18, 2)",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Rate",
                table: "SPKapanLagadReportModel",
                type: "decimal(18, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "NetWeight",
                table: "SPKapanLagadReportModel",
                type: "decimal(18, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "SPKapanLagadReportModel",
                type: "decimal(18, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)");

            migrationBuilder.CreateTable(
                name: "SPCashBankReport",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    ToParty = table.Column<string>(nullable: true),
                    FromParty = table.Column<string>(nullable: true),
                    CrDrType = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18, 4)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SPPurchaseChildReport",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: true),
                    PurchaseId = table.Column<string>(nullable: true),
                    KapanId = table.Column<string>(nullable: true),
                    ShapeId = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    PurityId = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    TIPWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    CVDWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    RejectedPercentage = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    RejectedWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    LessWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    LessDiscountPercentage = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    LessWeightDiscount = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    NetWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    BuyingRate = table.Column<double>(nullable: false),
                    CVDCharge = table.Column<double>(nullable: false),
                    CVDAmount = table.Column<double>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    CurrencyRate = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    CurrencyAmount = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    IsTransfer = table.Column<bool>(nullable: false),
                    TransferParentId = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    PurityName = table.Column<string>(nullable: true),
                    SizeName = table.Column<string>(nullable: true),
                    ShapeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SPSalesChildReport",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: true),
                    SalesId = table.Column<string>(nullable: true),
                    KapanId = table.Column<string>(nullable: true),
                    ShapeId = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    PurityId = table.Column<string>(nullable: true),
                    CharniSizeId = table.Column<string>(nullable: true),
                    GalaSizeId = table.Column<string>(nullable: true),
                    NumberSizeId = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    TIPWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    CVDWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    RejectedPercentage = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    RejectedWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    LessWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    LessDiscountPercentage = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    LessWeightDiscount = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    NetWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    SaleRate = table.Column<double>(nullable: false),
                    CVDCharge = table.Column<double>(nullable: false),
                    CVDAmount = table.Column<double>(nullable: false),
                    RoundUpAmount = table.Column<double>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    CurrencyRate = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    CurrencyAmount = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    IsTransfer = table.Column<bool>(nullable: false),
                    TransferParentId = table.Column<string>(nullable: true),
                    Category = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    PurityName = table.Column<string>(nullable: true),
                    SizeName = table.Column<string>(nullable: true),
                    GalaSizeName = table.Column<string>(nullable: true),
                    ShapeName = table.Column<string>(nullable: true),
                    NumberSizeName = table.Column<string>(nullable: true),
                    CharniSizeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SPCashBankReport");

            migrationBuilder.DropTable(
                name: "SPPurchaseChildReport");

            migrationBuilder.DropTable(
                name: "SPSalesChildReport");

            migrationBuilder.DropColumn(
                name: "Week_End_Date",
                table: "SPWeeklyPurchaseReport");

            migrationBuilder.DropColumn(
                name: "Week_Start_Date",
                table: "SPWeeklyPurchaseReport");

            migrationBuilder.DropColumn(
                name: "AdjustAmount",
                table: "SPPurchaseModel");

            migrationBuilder.AlterColumn<decimal>(
                name: "Rate",
                table: "SPKapanLagadReportModel",
                type: "decimal(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "NetWeight",
                table: "SPKapanLagadReportModel",
                type: "decimal(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "SPKapanLagadReportModel",
                type: "decimal(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)",
                oldNullable: true);
        }
    }
}
