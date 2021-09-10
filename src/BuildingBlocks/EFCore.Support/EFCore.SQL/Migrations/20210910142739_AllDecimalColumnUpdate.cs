using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class AllDecimalColumnUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sr",
                table: "SizeMaster");

            migrationBuilder.AlterColumn<decimal>(
                name: "CurrencyRate",
                table: "SalesMaster",
                type: "decimal(18, 4)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "CommissionPercentage",
                table: "SalesMaster",
                type: "decimal(18, 4)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "BrokerPercentage",
                table: "SalesMaster",
                type: "decimal(18, 4)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "Weight",
                table: "SalesDetails",
                type: "decimal(18, 4)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "TIPWeight",
                table: "SalesDetails",
                type: "decimal(18, 4)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "RejectedWeight",
                table: "SalesDetails",
                type: "decimal(18, 4)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "RejectedPercentage",
                table: "SalesDetails",
                type: "decimal(18, 4)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "NetWeight",
                table: "SalesDetails",
                type: "decimal(18, 4)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "LessWeightDiscount",
                table: "SalesDetails",
                type: "decimal(18, 4)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "LessWeight",
                table: "SalesDetails",
                type: "decimal(18, 4)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "LessDiscountPercentage",
                table: "SalesDetails",
                type: "decimal(18, 4)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "CVDWeight",
                table: "SalesDetails",
                type: "decimal(18, 4)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "PurchaseMaster",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<decimal>(
                name: "CurrencyRate",
                table: "PurchaseMaster",
                type: "decimal(18, 4)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "CommissionPercentage",
                table: "PurchaseMaster",
                type: "decimal(18, 4)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "BrokerPercentage",
                table: "PurchaseMaster",
                type: "decimal(18, 4)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "Weight",
                table: "PurchaseDetails",
                type: "decimal(18, 4)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "PurchaseDetails",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<decimal>(
                name: "TIPWeight",
                table: "PurchaseDetails",
                type: "decimal(18, 4)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "RejectedWeight",
                table: "PurchaseDetails",
                type: "decimal(18, 4)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "RejectedPercentage",
                table: "PurchaseDetails",
                type: "decimal(18, 4)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "NetWeight",
                table: "PurchaseDetails",
                type: "decimal(18, 4)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "LessWeightDiscount",
                table: "PurchaseDetails",
                type: "decimal(18, 4)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "LessWeight",
                table: "PurchaseDetails",
                type: "decimal(18, 4)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "LessDiscountPercentage",
                table: "PurchaseDetails",
                type: "decimal(18, 4)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "CVDWeight",
                table: "PurchaseDetails",
                type: "decimal(18, 4)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "MinWeight",
                table: "LessWeightDetails",
                type: "decimal(18, 4)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "MaxWeight",
                table: "LessWeightDetails",
                type: "decimal(18, 4)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "LessWeight",
                table: "LessWeightDetails",
                type: "decimal(18, 4)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                table: "CurrencyMaster",
                type: "decimal(18, 4)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Sr",
                table: "SizeMaster",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<float>(
                name: "CurrencyRate",
                table: "SalesMaster",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 4)");

            migrationBuilder.AlterColumn<float>(
                name: "CommissionPercentage",
                table: "SalesMaster",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 4)");

            migrationBuilder.AlterColumn<float>(
                name: "BrokerPercentage",
                table: "SalesMaster",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 4)");

            migrationBuilder.AlterColumn<float>(
                name: "Weight",
                table: "SalesDetails",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 4)");

            migrationBuilder.AlterColumn<float>(
                name: "TIPWeight",
                table: "SalesDetails",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 4)");

            migrationBuilder.AlterColumn<float>(
                name: "RejectedWeight",
                table: "SalesDetails",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 4)");

            migrationBuilder.AlterColumn<float>(
                name: "RejectedPercentage",
                table: "SalesDetails",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 4)");

            migrationBuilder.AlterColumn<float>(
                name: "NetWeight",
                table: "SalesDetails",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 4)");

            migrationBuilder.AlterColumn<float>(
                name: "LessWeightDiscount",
                table: "SalesDetails",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 4)");

            migrationBuilder.AlterColumn<float>(
                name: "LessWeight",
                table: "SalesDetails",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 4)");

            migrationBuilder.AlterColumn<float>(
                name: "LessDiscountPercentage",
                table: "SalesDetails",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 4)");

            migrationBuilder.AlterColumn<float>(
                name: "CVDWeight",
                table: "SalesDetails",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 4)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "PurchaseMaster",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "CurrencyRate",
                table: "PurchaseMaster",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 4)");

            migrationBuilder.AlterColumn<float>(
                name: "CommissionPercentage",
                table: "PurchaseMaster",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 4)");

            migrationBuilder.AlterColumn<float>(
                name: "BrokerPercentage",
                table: "PurchaseMaster",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 4)");

            migrationBuilder.AlterColumn<float>(
                name: "Weight",
                table: "PurchaseDetails",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 4)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "PurchaseDetails",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "TIPWeight",
                table: "PurchaseDetails",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 4)");

            migrationBuilder.AlterColumn<float>(
                name: "RejectedWeight",
                table: "PurchaseDetails",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 4)");

            migrationBuilder.AlterColumn<float>(
                name: "RejectedPercentage",
                table: "PurchaseDetails",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 4)");

            migrationBuilder.AlterColumn<float>(
                name: "NetWeight",
                table: "PurchaseDetails",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 4)");

            migrationBuilder.AlterColumn<float>(
                name: "LessWeightDiscount",
                table: "PurchaseDetails",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 4)");

            migrationBuilder.AlterColumn<float>(
                name: "LessWeight",
                table: "PurchaseDetails",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 4)");

            migrationBuilder.AlterColumn<float>(
                name: "LessDiscountPercentage",
                table: "PurchaseDetails",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 4)");

            migrationBuilder.AlterColumn<float>(
                name: "CVDWeight",
                table: "PurchaseDetails",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 4)");

            migrationBuilder.AlterColumn<float>(
                name: "MinWeight",
                table: "LessWeightDetails",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 4)");

            migrationBuilder.AlterColumn<float>(
                name: "MaxWeight",
                table: "LessWeightDetails",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 4)");

            migrationBuilder.AlterColumn<float>(
                name: "LessWeight",
                table: "LessWeightDetails",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 4)");

            migrationBuilder.AlterColumn<float>(
                name: "Value",
                table: "CurrencyMaster",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 4)");
        }
    }
}
