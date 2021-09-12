using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class UpdateKapanANDCurrency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KapanMaster_BranchMaster_BranchId",
                table: "KapanMaster");

            migrationBuilder.DropIndex(
                name: "IX_KapanMaster_BranchId",
                table: "KapanMaster");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "KapanMaster");

            migrationBuilder.DropColumn(
                name: "Details",
                table: "CurrencyMaster");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "KapanMaster",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "KapanMaster",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "KapanMaster",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "KapanMaster",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "CurrencyMaster",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "CurrencyMaster",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ShotName",
                table: "CurrencyMaster",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "CurrencyMaster",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "CurrencyMaster",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "KapanMaster");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "KapanMaster");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "KapanMaster");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "KapanMaster");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CurrencyMaster");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "CurrencyMaster");

            migrationBuilder.DropColumn(
                name: "ShotName",
                table: "CurrencyMaster");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "CurrencyMaster");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "CurrencyMaster");

            migrationBuilder.AddColumn<Guid>(
                name: "BranchId",
                table: "KapanMaster",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "CurrencyMaster",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KapanMaster_BranchId",
                table: "KapanMaster",
                column: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_KapanMaster_BranchMaster_BranchId",
                table: "KapanMaster",
                column: "BranchId",
                principalTable: "BranchMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
