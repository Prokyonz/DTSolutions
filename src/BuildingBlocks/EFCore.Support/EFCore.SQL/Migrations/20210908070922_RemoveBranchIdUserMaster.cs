using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class RemoveBranchIdUserMaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMaster_BranchMaster_BranchId",
                table: "UserMaster");

            migrationBuilder.DropIndex(
                name: "IX_UserMaster_BranchId",
                table: "UserMaster");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "UserMaster");

            migrationBuilder.AddColumn<Guid>(
                name: "BranchMasterId",
                table: "UserMaster",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserMaster_BranchMasterId",
                table: "UserMaster",
                column: "BranchMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMaster_BranchMaster_BranchMasterId",
                table: "UserMaster",
                column: "BranchMasterId",
                principalTable: "BranchMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMaster_BranchMaster_BranchMasterId",
                table: "UserMaster");

            migrationBuilder.DropIndex(
                name: "IX_UserMaster_BranchMasterId",
                table: "UserMaster");

            migrationBuilder.DropColumn(
                name: "BranchMasterId",
                table: "UserMaster");

            migrationBuilder.AddColumn<Guid>(
                name: "BranchId",
                table: "UserMaster",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_UserMaster_BranchId",
                table: "UserMaster",
                column: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMaster_BranchMaster_BranchId",
                table: "UserMaster",
                column: "BranchId",
                principalTable: "BranchMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
