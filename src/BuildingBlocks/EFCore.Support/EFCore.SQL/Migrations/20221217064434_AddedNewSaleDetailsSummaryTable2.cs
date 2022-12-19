using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class AddedNewSaleDetailsSummaryTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesDetailsSummary_SalesMaster_SalesDetailsMasterId",
                table: "SalesDetailsSummary");

            migrationBuilder.DropIndex(
                name: "IX_SalesDetailsSummary_SalesDetailsMasterId",
                table: "SalesDetailsSummary");

            migrationBuilder.DropColumn(
                name: "SalesDetailsMasterId",
                table: "SalesDetailsSummary");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SalesDetailsMasterId",
                table: "SalesDetailsSummary",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesDetailsSummary_SalesDetailsMasterId",
                table: "SalesDetailsSummary",
                column: "SalesDetailsMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesDetailsSummary_SalesMaster_SalesDetailsMasterId",
                table: "SalesDetailsSummary",
                column: "SalesDetailsMasterId",
                principalTable: "SalesMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
