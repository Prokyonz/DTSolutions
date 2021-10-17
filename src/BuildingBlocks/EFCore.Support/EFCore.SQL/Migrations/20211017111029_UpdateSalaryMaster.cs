using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class UpdateSalaryMaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalaryManager_UserMaster_UserId",
                table: "SalaryManager");

            migrationBuilder.DropIndex(
                name: "IX_SalaryManager_UserId",
                table: "SalaryManager");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "SalaryManager");

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "SalaryManager",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PartyId",
                table: "SalaryManager",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_SalaryManager_PartyId",
                table: "SalaryManager",
                column: "PartyId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalaryManager_PartyMaster_PartyId",
                table: "SalaryManager",
                column: "PartyId",
                principalTable: "PartyMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalaryManager_PartyMaster_PartyId",
                table: "SalaryManager");

            migrationBuilder.DropIndex(
                name: "IX_SalaryManager_PartyId",
                table: "SalaryManager");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "SalaryManager");

            migrationBuilder.DropColumn(
                name: "PartyId",
                table: "SalaryManager");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "SalaryManager",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_SalaryManager_UserId",
                table: "SalaryManager",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalaryManager_UserMaster_UserId",
                table: "SalaryManager",
                column: "UserId",
                principalTable: "UserMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
