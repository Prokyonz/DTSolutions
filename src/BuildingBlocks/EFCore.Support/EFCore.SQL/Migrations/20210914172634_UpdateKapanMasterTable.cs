using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class UpdateKapanMasterTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "KapanMaster");

            migrationBuilder.AlterColumn<decimal>(
                name: "CaratLimit",
                table: "KapanMaster",
                type: "decimal(18, 4)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "KapanMaster",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "KapanMaster");

            migrationBuilder.AlterColumn<int>(
                name: "CaratLimit",
                table: "KapanMaster",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 4)");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "KapanMaster",
                type: "datetime2",
                nullable: true);
        }
    }
}
