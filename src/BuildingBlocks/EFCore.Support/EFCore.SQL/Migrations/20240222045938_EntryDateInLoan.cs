using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class EntryDateInLoan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EntryDate",
                table: "SPLoanReportModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EntryTime",
                table: "SPLoanReportModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EntryDate",
                table: "LoanMaster",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntryDate",
                table: "SPLoanReportModel");

            migrationBuilder.DropColumn(
                name: "EntryTime",
                table: "SPLoanReportModel");

            migrationBuilder.DropColumn(
                name: "EntryDate",
                table: "LoanMaster");
        }
    }
}
