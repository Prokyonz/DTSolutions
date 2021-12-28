using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class AddColPayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "PaymentDetails",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "SlipNo",
                table: "PaymentDetails",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SPLoanReportModel",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: true),
                    Sr = table.Column<int>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    LoanType = table.Column<int>(nullable: false),
                    PartyId = table.Column<string>(nullable: true),
                    PartyName = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    DuratonType = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    InterestRate = table.Column<decimal>(nullable: false),
                    TotalInterest = table.Column<decimal>(nullable: false),
                    NetAmount = table.Column<decimal>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SPLoanReportModel");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "PaymentDetails");

            migrationBuilder.DropColumn(
                name: "SlipNo",
                table: "PaymentDetails");
        }
    }
}
