using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class AddFKLessWeightDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LessWeightDetails_LessWeightMasters_LessWeightMasterId",
                table: "LessWeightDetails");

            migrationBuilder.DropIndex(
                name: "IX_LessWeightDetails_LessWeightMasterId",
                table: "LessWeightDetails");

            migrationBuilder.DropColumn(
                name: "LessWeightMasterId",
                table: "LessWeightDetails");

            migrationBuilder.CreateIndex(
                name: "IX_LessWeightDetails_LessWeightId",
                table: "LessWeightDetails",
                column: "LessWeightId");

            migrationBuilder.AddForeignKey(
                name: "FK_LessWeightDetails_LessWeightMasters_LessWeightId",
                table: "LessWeightDetails",
                column: "LessWeightId",
                principalTable: "LessWeightMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LessWeightDetails_LessWeightMasters_LessWeightId",
                table: "LessWeightDetails");

            migrationBuilder.DropIndex(
                name: "IX_LessWeightDetails_LessWeightId",
                table: "LessWeightDetails");

            migrationBuilder.AddColumn<Guid>(
                name: "LessWeightMasterId",
                table: "LessWeightDetails",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LessWeightDetails_LessWeightMasterId",
                table: "LessWeightDetails",
                column: "LessWeightMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_LessWeightDetails_LessWeightMasters_LessWeightMasterId",
                table: "LessWeightDetails",
                column: "LessWeightMasterId",
                principalTable: "LessWeightMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
