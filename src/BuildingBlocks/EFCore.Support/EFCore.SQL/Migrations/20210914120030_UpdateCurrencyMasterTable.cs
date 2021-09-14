using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class UpdateCurrencyMasterTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "CurrencyMaster");

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "CurrencyMaster",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "CurrencyMaster",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "CurrencyMaster");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "CurrencyMaster");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "CurrencyMaster",
                type: "datetime2",
                nullable: true);
        }
    }
}
