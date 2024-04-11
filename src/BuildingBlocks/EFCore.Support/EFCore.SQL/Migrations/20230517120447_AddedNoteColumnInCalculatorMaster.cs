using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class AddedNoteColumnInCalculatorMaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "CalculatorMaster",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SPCalculatorModel",
                columns: table => new
                {
                    Date = table.Column<DateTime>(nullable: false),
                    SrNo = table.Column<int>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    BranchId = table.Column<string>(nullable: true),
                    BranchName = table.Column<string>(nullable: true),
                    PartyId = table.Column<string>(nullable: true),
                    PartyName = table.Column<string>(nullable: true),
                    BrokerId = table.Column<string>(nullable: true),
                    BrokerName = table.Column<string>(nullable: true),
                    NetCarat = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    Note = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    SizeName = table.Column<string>(nullable: true),
                    TotalCarat = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    NumberId = table.Column<string>(nullable: true),
                    Carat = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    NumberName = table.Column<string>(nullable: true),
                    Percentage = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18, 4)", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SPCalculatorModel");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "CalculatorMaster");
        }
    }
}
