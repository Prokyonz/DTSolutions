using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class ColUpdateInProcess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kapan",
                table: "SPAssortmentProcessSend");

            migrationBuilder.DropColumn(
                name: "KapanId",
                table: "SPAssortmentProcessSend");

            migrationBuilder.AddColumn<string>(
                name: "PurchaseDetailsId",
                table: "SPAssortmentProcessSend",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EntryDate",
                table: "NumberProcessMaster",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EntryTime",
                table: "NumberProcessMaster",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EntryDate",
                table: "GalaProcessMaster",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EntryTime",
                table: "GalaProcessMaster",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EntryDate",
                table: "CharniProcessMaster",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EntryTime",
                table: "CharniProcessMaster",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EntryDate",
                table: "BoilProcessMaster",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EntryTime",
                table: "BoilProcessMaster",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PurchaseDetailsId",
                table: "SPAssortmentProcessSend");

            migrationBuilder.DropColumn(
                name: "EntryTime",
                table: "NumberProcessMaster");

            migrationBuilder.DropColumn(
                name: "EntryTime",
                table: "GalaProcessMaster");

            migrationBuilder.DropColumn(
                name: "EntryTime",
                table: "CharniProcessMaster");

            migrationBuilder.DropColumn(
                name: "EntryTime",
                table: "BoilProcessMaster");

            migrationBuilder.AddColumn<string>(
                name: "Kapan",
                table: "SPAssortmentProcessSend",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KapanId",
                table: "SPAssortmentProcessSend",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EntryDate",
                table: "NumberProcessMaster",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EntryDate",
                table: "GalaProcessMaster",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EntryDate",
                table: "CharniProcessMaster",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EntryDate",
                table: "BoilProcessMaster",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
