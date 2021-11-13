using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class AddColInAssort : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EntryDate",
                table: "AccountToAssortMaster",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EntryTime",
                table: "AccountToAssortMaster",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CharniProcessId",
                table: "AccountToAssortDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GalaProcessId",
                table: "AccountToAssortDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumberProcessId",
                table: "AccountToAssortDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntryTime",
                table: "AccountToAssortMaster");

            migrationBuilder.DropColumn(
                name: "CharniProcessId",
                table: "AccountToAssortDetails");

            migrationBuilder.DropColumn(
                name: "GalaProcessId",
                table: "AccountToAssortDetails");

            migrationBuilder.DropColumn(
                name: "NumberProcessId",
                table: "AccountToAssortDetails");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EntryDate",
                table: "AccountToAssortMaster",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
