using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class RemoveExenseMaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseDetails_ExpenseMaster_ExpenseId",
                table: "ExpenseDetails");

            migrationBuilder.DropIndex(
                name: "IX_ExpenseDetails_ExpenseId",
                table: "ExpenseDetails");

            migrationBuilder.DropColumn(
                name: "ExpenseId",
                table: "ExpenseDetails");

            migrationBuilder.AddColumn<Guid>(
                name: "BranchId",
                table: "ExpenseDetails",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "ExpenseDetails",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ExpenseMasterId",
                table: "ExpenseDetails",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseDetails_ExpenseMasterId",
                table: "ExpenseDetails",
                column: "ExpenseMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseDetails_ExpenseMaster_ExpenseMasterId",
                table: "ExpenseDetails",
                column: "ExpenseMasterId",
                principalTable: "ExpenseMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseDetails_ExpenseMaster_ExpenseMasterId",
                table: "ExpenseDetails");

            migrationBuilder.DropIndex(
                name: "IX_ExpenseDetails_ExpenseMasterId",
                table: "ExpenseDetails");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "ExpenseDetails");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "ExpenseDetails");

            migrationBuilder.DropColumn(
                name: "ExpenseMasterId",
                table: "ExpenseDetails");

            migrationBuilder.AddColumn<Guid>(
                name: "ExpenseId",
                table: "ExpenseDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseDetails_ExpenseId",
                table: "ExpenseDetails",
                column: "ExpenseId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseDetails_ExpenseMaster_ExpenseId",
                table: "ExpenseDetails",
                column: "ExpenseId",
                principalTable: "ExpenseMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
