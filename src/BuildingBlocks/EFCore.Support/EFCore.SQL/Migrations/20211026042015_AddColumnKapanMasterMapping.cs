using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class AddColumnKapanMasterMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BranchId",
                table: "KapanMappingMaster",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "KapanMappingMaster",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "KapanMappingMaster",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "KapanMappingMaster",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "KapanMappingMaster",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "KapanMappingMaster",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "KapanMappingMaster");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "KapanMappingMaster");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "KapanMappingMaster");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "KapanMappingMaster");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "KapanMappingMaster");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "KapanMappingMaster");
        }
    }
}
