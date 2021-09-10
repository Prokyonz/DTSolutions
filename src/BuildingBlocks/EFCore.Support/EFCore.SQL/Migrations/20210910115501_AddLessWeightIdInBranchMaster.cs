using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class AddLessWeightIdInBranchMaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LessWeightMasters_BranchMaster_BranchId",
                table: "LessWeightMasters");

            migrationBuilder.DropIndex(
                name: "IX_LessWeightMasters_BranchId",
                table: "LessWeightMasters");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "LessWeightMasters");

            migrationBuilder.AddColumn<Guid>(
                name: "LessWeightId",
                table: "BranchMaster",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LessWeightId",
                table: "BranchMaster");

            migrationBuilder.AddColumn<Guid>(
                name: "BranchId",
                table: "LessWeightMasters",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_LessWeightMasters_BranchId",
                table: "LessWeightMasters",
                column: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_LessWeightMasters_BranchMaster_BranchId",
                table: "LessWeightMasters",
                column: "BranchId",
                principalTable: "BranchMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
