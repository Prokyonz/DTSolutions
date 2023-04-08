using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class AddedCalaculatorRepository : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SlipTransferEntry_PurchaseMaster_PurchaseMasterId",
                table: "SlipTransferEntry");

            migrationBuilder.DropIndex(
                name: "IX_SlipTransferEntry_PurchaseMasterId",
                table: "SlipTransferEntry");

            migrationBuilder.DropColumn(
                name: "PersonName",
                table: "SlipTransferEntry");

            migrationBuilder.DropColumn(
                name: "PurchaseMasterId",
                table: "SlipTransferEntry");

            migrationBuilder.AddColumn<decimal>(
                name: "ClosingAmount",
                table: "SPStockReportModelReport",
                type: "decimal(18, 4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ClosingNetWeight",
                table: "SPStockReportModelReport",
                type: "decimal(18, 4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ClosingRate",
                table: "SPStockReportModelReport",
                type: "decimal(18, 4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ClosingAmount",
                table: "SPNumberkReportModelReport",
                type: "decimal(18, 4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ClosingNetWeight",
                table: "SPNumberkReportModelReport",
                type: "decimal(18, 4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ClosingRate",
                table: "SPNumberkReportModelReport",
                type: "decimal(18, 4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "CashBankName",
                table: "SPLoanReportModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CashBankPartyId",
                table: "SPLoanReportModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Party",
                table: "SlipTransferEntry",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PurchaseSaleId",
                table: "SlipTransferEntry",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SlipType",
                table: "SlipTransferEntry",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CalculatorMaster",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    PartyId = table.Column<string>(nullable: true),
                    DealerId = table.Column<string>(nullable: true),
                    BranchId = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    NumberId = table.Column<string>(nullable: true),
                    Carat = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    Percentage = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculatorMaster", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalculatorMaster");

            migrationBuilder.DropColumn(
                name: "ClosingAmount",
                table: "SPStockReportModelReport");

            migrationBuilder.DropColumn(
                name: "ClosingNetWeight",
                table: "SPStockReportModelReport");

            migrationBuilder.DropColumn(
                name: "ClosingRate",
                table: "SPStockReportModelReport");

            migrationBuilder.DropColumn(
                name: "ClosingAmount",
                table: "SPNumberkReportModelReport");

            migrationBuilder.DropColumn(
                name: "ClosingNetWeight",
                table: "SPNumberkReportModelReport");

            migrationBuilder.DropColumn(
                name: "ClosingRate",
                table: "SPNumberkReportModelReport");

            migrationBuilder.DropColumn(
                name: "CashBankName",
                table: "SPLoanReportModel");

            migrationBuilder.DropColumn(
                name: "CashBankPartyId",
                table: "SPLoanReportModel");

            migrationBuilder.DropColumn(
                name: "Party",
                table: "SlipTransferEntry");

            migrationBuilder.DropColumn(
                name: "PurchaseSaleId",
                table: "SlipTransferEntry");

            migrationBuilder.DropColumn(
                name: "SlipType",
                table: "SlipTransferEntry");

            migrationBuilder.AddColumn<string>(
                name: "PersonName",
                table: "SlipTransferEntry",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PurchaseMasterId",
                table: "SlipTransferEntry",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SlipTransferEntry_PurchaseMasterId",
                table: "SlipTransferEntry",
                column: "PurchaseMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_SlipTransferEntry_PurchaseMaster_PurchaseMasterId",
                table: "SlipTransferEntry",
                column: "PurchaseMasterId",
                principalTable: "PurchaseMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
