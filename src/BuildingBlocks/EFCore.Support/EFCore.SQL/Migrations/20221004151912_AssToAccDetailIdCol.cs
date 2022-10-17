using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class AssToAccDetailIdCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EntryDate",
                table: "SPPaymentModel",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EntryDate",
                table: "SPExpenseModel",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EntryDate",
                table: "SPContraModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountToAssortDetailsId",
                table: "BoilProcessMaster",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntryDate",
                table: "SPPaymentModel");

            migrationBuilder.DropColumn(
                name: "EntryDate",
                table: "SPExpenseModel");

            migrationBuilder.DropColumn(
                name: "EntryDate",
                table: "SPContraModel");

            migrationBuilder.DropColumn(
                name: "AccountToAssortDetailsId",
                table: "BoilProcessMaster");
        }
    }
}
