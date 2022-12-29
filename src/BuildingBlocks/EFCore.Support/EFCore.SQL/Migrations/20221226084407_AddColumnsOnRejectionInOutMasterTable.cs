using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class AddColumnsOnRejectionInOutMasterTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CharniSizeId",
                table: "RejectionInOutMaster",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GalaSizeId",
                table: "RejectionInOutMaster",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumberSizeId",
                table: "RejectionInOutMaster",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PurityId",
                table: "RejectionInOutMaster",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TableEntryID",
                table: "RejectionInOutMaster",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TableName",
                table: "RejectionInOutMaster",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SPSalaryReport",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: true),
                    SalaryMasterId = table.Column<string>(nullable: true),
                    Sr = table.Column<int>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    BranchId = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    FromPartyId = table.Column<string>(nullable: true),
                    FromPartyName = table.Column<string>(nullable: true),
                    SalaryMonth = table.Column<int>(nullable: false),
                    SalaryMonthDateTime = table.Column<DateTime>(nullable: false),
                    MonthDays = table.Column<int>(nullable: false),
                    Holidays = table.Column<float>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    ToPartyId = table.Column<string>(nullable: true),
                    ToPartyName = table.Column<string>(nullable: true),
                    SalaryAmount = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    WorkingDays = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    WorkedDays = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    OverTimeHrs = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    OverTimeRateHrs = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    AdvanceAmount = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    BonusAmount = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    RoundOfAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18, 4)", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SPSalaryReport");

            migrationBuilder.DropColumn(
                name: "CharniSizeId",
                table: "RejectionInOutMaster");

            migrationBuilder.DropColumn(
                name: "GalaSizeId",
                table: "RejectionInOutMaster");

            migrationBuilder.DropColumn(
                name: "NumberSizeId",
                table: "RejectionInOutMaster");

            migrationBuilder.DropColumn(
                name: "PurityId",
                table: "RejectionInOutMaster");

            migrationBuilder.DropColumn(
                name: "TableEntryID",
                table: "RejectionInOutMaster");

            migrationBuilder.DropColumn(
                name: "TableName",
                table: "RejectionInOutMaster");
        }
    }
}
