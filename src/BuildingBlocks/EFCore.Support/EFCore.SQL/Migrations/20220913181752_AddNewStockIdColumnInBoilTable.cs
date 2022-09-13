using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class AddNewStockIdColumnInBoilTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StockId",
                table: "SPAssortmentProcessSend",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StockId",
                table: "BoilProcessMaster",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StockId",
                table: "SPAssortmentProcessSend");

            migrationBuilder.DropColumn(
                name: "StockId",
                table: "BoilProcessMaster");
        }
    }
}
