using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class SalaryUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalaryDetails_PartyMaster_PartyId",
                table: "SalaryDetails");

            migrationBuilder.DropIndex(
                name: "IX_SalaryDetails_PartyId",
                table: "SalaryDetails");

            migrationBuilder.DropColumn(
                name: "SalaryMonthName",
                table: "SalaryMaster");

            migrationBuilder.DropColumn(
                name: "OvetimeDays",
                table: "SalaryDetails");

            migrationBuilder.DropColumn(
                name: "PartyId",
                table: "SalaryDetails");

            migrationBuilder.DropColumn(
                name: "PayDays",
                table: "SalaryDetails");

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "SPMixedReportModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "SPCashBankReport",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FromPartyId",
                table: "SalaryMaster",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SalaryMonth",
                table: "SalaryMaster",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "SalaryDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "SalaryDetails",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "OverTimeHrs",
                table: "SalaryDetails",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OverTimeRateHrs",
                table: "SalaryDetails",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "RoundOfAmount",
                table: "SalaryDetails",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SalaryAmount",
                table: "SalaryDetails",
                type: "decimal(18, 4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ToPartyId",
                table: "SalaryDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "SalaryDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "SalaryDetails",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "WorkedDays",
                table: "SalaryDetails",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WorkingDays",
                table: "SalaryDetails",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "SPMixedReportModel");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "SPCashBankReport");

            migrationBuilder.DropColumn(
                name: "FromPartyId",
                table: "SalaryMaster");

            migrationBuilder.DropColumn(
                name: "SalaryMonth",
                table: "SalaryMaster");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "SalaryDetails");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "SalaryDetails");

            migrationBuilder.DropColumn(
                name: "OverTimeHrs",
                table: "SalaryDetails");

            migrationBuilder.DropColumn(
                name: "OverTimeRateHrs",
                table: "SalaryDetails");

            migrationBuilder.DropColumn(
                name: "RoundOfAmount",
                table: "SalaryDetails");

            migrationBuilder.DropColumn(
                name: "SalaryAmount",
                table: "SalaryDetails");

            migrationBuilder.DropColumn(
                name: "ToPartyId",
                table: "SalaryDetails");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "SalaryDetails");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "SalaryDetails");

            migrationBuilder.DropColumn(
                name: "WorkedDays",
                table: "SalaryDetails");

            migrationBuilder.DropColumn(
                name: "WorkingDays",
                table: "SalaryDetails");

            migrationBuilder.AddColumn<string>(
                name: "SalaryMonthName",
                table: "SalaryMaster",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "OvetimeDays",
                table: "SalaryDetails",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "PartyId",
                table: "SalaryDetails",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "PayDays",
                table: "SalaryDetails",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateIndex(
                name: "IX_SalaryDetails_PartyId",
                table: "SalaryDetails",
                column: "PartyId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalaryDetails_PartyMaster_PartyId",
                table: "SalaryDetails",
                column: "PartyId",
                principalTable: "PartyMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
