using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class PartyMasterUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BrokerageId",
                table: "PartyMaster",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContraEntryDetails_ContraEntryMasterId",
                table: "ContraEntryDetails",
                column: "ContraEntryMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContraEntryDetails_ContraEntryMaster_ContraEntryMasterId",
                table: "ContraEntryDetails",
                column: "ContraEntryMasterId",
                principalTable: "ContraEntryMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContraEntryDetails_ContraEntryMaster_ContraEntryMasterId",
                table: "ContraEntryDetails");

            migrationBuilder.DropIndex(
                name: "IX_ContraEntryDetails_ContraEntryMasterId",
                table: "ContraEntryDetails");

            migrationBuilder.DropColumn(
                name: "BrokerageId",
                table: "PartyMaster");
        }
    }
}
