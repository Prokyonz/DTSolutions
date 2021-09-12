using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class UpdateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "FinancialYearMaster");

            migrationBuilder.DropColumn(
                name: "StatDate",
                table: "FinancialYearMaster");

            migrationBuilder.DropColumn(
                name: "AadharCardNo",
                table: "BranchMaster");

            migrationBuilder.AddColumn<string>(
                name: "PancardNo",
                table: "PartyMaster",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "PartyMaster",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "FinancialYearMaster",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "FinancialYearMaster",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "RegistrationNo",
                table: "BranchMaster",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PancardNo",
                table: "PartyMaster");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "PartyMaster");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "FinancialYearMaster");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "FinancialYearMaster");

            migrationBuilder.DropColumn(
                name: "RegistrationNo",
                table: "BranchMaster");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "FinancialYearMaster",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StatDate",
                table: "FinancialYearMaster",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "AadharCardNo",
                table: "BranchMaster",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
