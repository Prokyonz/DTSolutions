using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class AddStockIdColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "SalesItemDetails",
                newName: "AvailableWeight");

            migrationBuilder.AddColumn<string>(
                name: "StockId",
                table: "OpeningStockMaster",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StockId",
                table: "OpeningStockMaster");

            migrationBuilder.RenameColumn(
                name: "AvailableWeight",
                table: "SalesItemDetails",
                newName: "Weight");
        }
    }
}
