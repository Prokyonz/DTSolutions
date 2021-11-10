using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class UpdateColsForProcesses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinancialId",
                table: "NumberProcessMaster");

            migrationBuilder.DropColumn(
                name: "SlipId",
                table: "KapanMappingMaster");

            migrationBuilder.DropColumn(
                name: "FinancialId",
                table: "GalaProcessMaster");

            migrationBuilder.DropColumn(
                name: "FinancialId",
                table: "CharniProcessMaster");

            migrationBuilder.DropColumn(
                name: "FinancialId",
                table: "BoilProcessMaster");

            migrationBuilder.DropColumn(
                name: "FinancialId",
                table: "AccountToAssortMaster");

            migrationBuilder.RenameColumn(
                name: "TotalWeight",
                table: "AccountToAssortDetails",
                newName: "Weight");

            migrationBuilder.AddColumn<string>(
                name: "FinancialYearId",
                table: "NumberProcessMaster",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PurityId",
                table: "NumberProcessMaster",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PurityId",
                table: "KapanMappingMaster",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SlipNo",
                table: "KapanMappingMaster",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FinancialYearId",
                table: "GalaProcessMaster",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PurityId",
                table: "GalaProcessMaster",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FinancialYearId",
                table: "CharniProcessMaster",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PurityId",
                table: "CharniProcessMaster",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FinancialYearId",
                table: "BoilProcessMaster",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PurityId",
                table: "BoilProcessMaster",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FinancialYearId",
                table: "AccountToAssortMaster",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PurityId",
                table: "AccountToAssortDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShapeId",
                table: "AccountToAssortDetails",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SPKapanMapping",
                columns: table => new
                {
                    Date = table.Column<DateTime>(nullable: false),
                    SlipNo = table.Column<long>(nullable: false),
                    SizeId = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    NetWeight = table.Column<decimal>(nullable: false),
                    AvailableCts = table.Column<decimal>(nullable: false),
                    Cts = table.Column<decimal>(nullable: true),
                    PurchaseID = table.Column<string>(nullable: true),
                    PurchaseDetailId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SPKapanMapping");

            migrationBuilder.DropColumn(
                name: "FinancialYearId",
                table: "NumberProcessMaster");

            migrationBuilder.DropColumn(
                name: "PurityId",
                table: "NumberProcessMaster");

            migrationBuilder.DropColumn(
                name: "PurityId",
                table: "KapanMappingMaster");

            migrationBuilder.DropColumn(
                name: "SlipNo",
                table: "KapanMappingMaster");

            migrationBuilder.DropColumn(
                name: "FinancialYearId",
                table: "GalaProcessMaster");

            migrationBuilder.DropColumn(
                name: "PurityId",
                table: "GalaProcessMaster");

            migrationBuilder.DropColumn(
                name: "FinancialYearId",
                table: "CharniProcessMaster");

            migrationBuilder.DropColumn(
                name: "PurityId",
                table: "CharniProcessMaster");

            migrationBuilder.DropColumn(
                name: "FinancialYearId",
                table: "BoilProcessMaster");

            migrationBuilder.DropColumn(
                name: "PurityId",
                table: "BoilProcessMaster");

            migrationBuilder.DropColumn(
                name: "FinancialYearId",
                table: "AccountToAssortMaster");

            migrationBuilder.DropColumn(
                name: "PurityId",
                table: "AccountToAssortDetails");

            migrationBuilder.DropColumn(
                name: "ShapeId",
                table: "AccountToAssortDetails");

            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "AccountToAssortDetails",
                newName: "TotalWeight");

            migrationBuilder.AddColumn<string>(
                name: "FinancialId",
                table: "NumberProcessMaster",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SlipId",
                table: "KapanMappingMaster",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FinancialId",
                table: "GalaProcessMaster",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FinancialId",
                table: "CharniProcessMaster",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FinancialId",
                table: "BoilProcessMaster",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FinancialId",
                table: "AccountToAssortMaster",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
