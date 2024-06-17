using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class AddedSlipPrintFlag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SizeName",
                table: "SPSalesModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "SPRejectionSendReceiveModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SizeName",
                table: "SPPurchaseModel",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSlipPrint",
                table: "SalesMaster",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSlipPrint",
                table: "PurchaseMaster",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "SPRejectionPendingReport",
                columns: table => new
                {
                    CompanyId = table.Column<string>(nullable: true),
                    PartyId = table.Column<string>(nullable: true),
                    PartyName = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    SlipNo = table.Column<string>(nullable: true),
                    ProcessType = table.Column<string>(nullable: true),
                    RejectionWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "TransferViewModel",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    TransferMasterId = table.Column<string>(nullable: true),
                    JangadNo = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: true),
                    Time = table.Column<string>(nullable: true),
                    TRansferById = table.Column<string>(nullable: true),
                    CompanyId = table.Column<string>(nullable: true),
                    CharniSizeId = table.Column<string>(nullable: true),
                    FromCategory = table.Column<int>(nullable: false),
                    BranchId = table.Column<string>(nullable: true),
                    ShapeId = table.Column<string>(nullable: true),
                    Carat = table.Column<decimal>(nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    ToCategory = table.Column<int>(nullable: false),
                    ToSizeId = table.Column<string>(nullable: true),
                    ToBranchId = table.Column<string>(nullable: true),
                    ToNumberIdORKapanId = table.Column<string>(nullable: true),
                    ToCarat = table.Column<decimal>(nullable: false),
                    ToRate = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    ToAmount = table.Column<double>(nullable: false),
                    FromNumberIdORKapanId = table.Column<string>(nullable: true),
                    Sr = table.Column<int>(nullable: false),
                    TrasnferDetailsSR = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferViewModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SPRejectionPendingReport");

            migrationBuilder.DropTable(
                name: "TransferViewModel");

            migrationBuilder.DropColumn(
                name: "SizeName",
                table: "SPSalesModel");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "SPRejectionSendReceiveModel");

            migrationBuilder.DropColumn(
                name: "SizeName",
                table: "SPPurchaseModel");

            migrationBuilder.DropColumn(
                name: "IsSlipPrint",
                table: "SalesMaster");

            migrationBuilder.DropColumn(
                name: "IsSlipPrint",
                table: "PurchaseMaster");
        }
    }
}
