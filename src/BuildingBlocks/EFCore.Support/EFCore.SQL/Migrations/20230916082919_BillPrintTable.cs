using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class BillPrintTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CrDrType",
                table: "SPExpenseModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BillPrintModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    GSTN = table.Column<string>(nullable: true),
                    PAN = table.Column<string>(nullable: true),
                    InvoiceNo = table.Column<string>(nullable: true),
                    InvoiceDate = table.Column<DateTime>(nullable: false),
                    ReverseCharge = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    TCSApplicable = table.Column<string>(nullable: true),
                    DateOfSupply = table.Column<DateTime>(nullable: false),
                    PlaceOfSupply = table.Column<string>(nullable: true),
                    Terms = table.Column<string>(nullable: true),
                    BillPartyName = table.Column<string>(nullable: true),
                    BillPartyAddress = table.Column<string>(nullable: true),
                    BillPartyGSTIN = table.Column<string>(nullable: true),
                    BillPartyPAN = table.Column<string>(nullable: true),
                    BillPartyState = table.Column<string>(nullable: true),
                    BillPartyCode = table.Column<string>(nullable: true),
                    ShipPartyName = table.Column<string>(nullable: true),
                    ShipPartyAddress = table.Column<string>(nullable: true),
                    ShipPartyGSTIN = table.Column<string>(nullable: true),
                    ShipPartyPAN = table.Column<string>(nullable: true),
                    ShipPartyState = table.Column<string>(nullable: true),
                    ShipPartyCode = table.Column<string>(nullable: true),
                    AmountBeforeTax = table.Column<decimal>(nullable: false),
                    SGST = table.Column<decimal>(nullable: false),
                    CGST = table.Column<decimal>(nullable: false),
                    IGST = table.Column<decimal>(nullable: false),
                    TCS = table.Column<decimal>(nullable: false),
                    TotalAmount = table.Column<decimal>(nullable: false),
                    GstOnReverseCharge = table.Column<decimal>(nullable: false),
                    Declaration = table.Column<string>(nullable: true),
                    BankName = table.Column<string>(nullable: true),
                    AccountNo = table.Column<string>(nullable: true),
                    IFSC = table.Column<string>(nullable: true),
                    SrNo = table.Column<string>(nullable: true),
                    ProductDescription = table.Column<string>(nullable: true),
                    HSNCode = table.Column<string>(nullable: true),
                    UOM = table.Column<string>(nullable: true),
                    Qty = table.Column<decimal>(nullable: false),
                    Rate = table.Column<decimal>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    Discount = table.Column<decimal>(nullable: false),
                    TaxableValue = table.Column<decimal>(nullable: false),
                    TotalRow = table.Column<decimal>(nullable: false),
                    TotalQty = table.Column<decimal>(nullable: false),
                    TotalGridAmount = table.Column<decimal>(nullable: false),
                    TotalTaxValue = table.Column<decimal>(nullable: false),
                    FinalTotal = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillPrintModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PriceMasterMobile",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<string>(nullable: true),
                    CategoryId = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    NumberId = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceMasterMobile", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillPrintModel");

            migrationBuilder.DropTable(
                name: "PriceMasterMobile");

            migrationBuilder.DropColumn(
                name: "CrDrType",
                table: "SPExpenseModel");
        }
    }
}
