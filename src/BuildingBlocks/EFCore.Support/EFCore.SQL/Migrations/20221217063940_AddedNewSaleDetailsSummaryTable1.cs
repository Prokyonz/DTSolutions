using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class AddedNewSaleDetailsSummaryTable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesDetailsSummary_SalesMaster_SalesDetailsId",
                table: "SalesDetailsSummary");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesDetailsSummary_SalesDetails_SalesDetailsId1",
                table: "SalesDetailsSummary");

            migrationBuilder.DropIndex(
                name: "IX_SalesDetailsSummary_SalesDetailsId1",
                table: "SalesDetailsSummary");

            migrationBuilder.DropColumn(
                name: "SalesDetailsId1",
                table: "SalesDetailsSummary");

            migrationBuilder.AddColumn<string>(
                name: "SalesDetailsMasterId",
                table: "SalesDetailsSummary",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesDetailsSummary_SalesDetailsMasterId",
                table: "SalesDetailsSummary",
                column: "SalesDetailsMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesDetailsSummary_SalesDetails_SalesDetailsId",
                table: "SalesDetailsSummary",
                column: "SalesDetailsId",
                principalTable: "SalesDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesDetailsSummary_SalesMaster_SalesDetailsMasterId",
                table: "SalesDetailsSummary",
                column: "SalesDetailsMasterId",
                principalTable: "SalesMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesDetailsSummary_SalesDetails_SalesDetailsId",
                table: "SalesDetailsSummary");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesDetailsSummary_SalesMaster_SalesDetailsMasterId",
                table: "SalesDetailsSummary");

            migrationBuilder.DropIndex(
                name: "IX_SalesDetailsSummary_SalesDetailsMasterId",
                table: "SalesDetailsSummary");

            migrationBuilder.DropColumn(
                name: "SalesDetailsMasterId",
                table: "SalesDetailsSummary");

            migrationBuilder.AddColumn<string>(
                name: "SalesDetailsId1",
                table: "SalesDetailsSummary",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesDetailsSummary_SalesDetailsId1",
                table: "SalesDetailsSummary",
                column: "SalesDetailsId1");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesDetailsSummary_SalesMaster_SalesDetailsId",
                table: "SalesDetailsSummary",
                column: "SalesDetailsId",
                principalTable: "SalesMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesDetailsSummary_SalesDetails_SalesDetailsId1",
                table: "SalesDetailsSummary",
                column: "SalesDetailsId1",
                principalTable: "SalesDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
