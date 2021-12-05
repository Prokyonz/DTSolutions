using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class AddCharniSizeIDColumnToGalaProcessMasterTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CharniSize",
                table: "SPGalaProcessSend",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CharniSizeId",
                table: "SPGalaProcessSend",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CharniSizeId",
                table: "GalaProcessMaster",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SPExpenseModel",
                columns: table => new
                {
                    Sr = table.Column<int>(nullable: false),
                    SrNo = table.Column<int>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    BranchId = table.Column<string>(nullable: true),
                    PartyId = table.Column<string>(nullable: true),
                    PartyName = table.Column<string>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SPExpenseModel");

            migrationBuilder.DropColumn(
                name: "CharniSize",
                table: "SPGalaProcessSend");

            migrationBuilder.DropColumn(
                name: "CharniSizeId",
                table: "SPGalaProcessSend");

            migrationBuilder.DropColumn(
                name: "CharniSizeId",
                table: "GalaProcessMaster");
        }
    }
}
