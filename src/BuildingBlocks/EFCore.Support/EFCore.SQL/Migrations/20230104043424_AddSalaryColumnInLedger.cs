using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class AddSalaryColumnInLedger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Salary",
                table: "PartyMaster",
                type: "decimal(18, 4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "SPRejectionSendReceiveReport",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: true),
                    SrNo = table.Column<int>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    BranchId = table.Column<string>(nullable: true),
                    EntryDate = table.Column<DateTime>(nullable: true),
                    PartyId = table.Column<string>(nullable: true),
                    PartyName = table.Column<string>(nullable: true),
                    BrokerageId = table.Column<string>(nullable: true),
                    BrokerName = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    TransType = table.Column<int>(nullable: false),
                    SlipNo = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    SizeName = table.Column<string>(nullable: true),
                    PurityId = table.Column<string>(nullable: true),
                    PurityName = table.Column<string>(nullable: true),
                    CharniSizeId = table.Column<string>(nullable: true),
                    CharniSizeName = table.Column<string>(nullable: true),
                    GalaSizeId = table.Column<string>(nullable: true),
                    GalaSizeName = table.Column<string>(nullable: true),
                    NumberSizeId = table.Column<string>(nullable: true),
                    NumberSizeName = table.Column<string>(nullable: true),
                    Rate = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    TotalCarat = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    Remarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SPRejectionSendReceiveReport");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "PartyMaster");
        }
    }
}
