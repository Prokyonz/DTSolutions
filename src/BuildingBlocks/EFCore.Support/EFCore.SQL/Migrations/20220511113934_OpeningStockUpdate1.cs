using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class OpeningStockUpdate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "OpeningStockMaster",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EntryDate",
                table: "OpeningStockMaster",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EntryTime",
                table: "OpeningStockMaster",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "OpeningStockMaster");

            migrationBuilder.DropColumn(
                name: "EntryDate",
                table: "OpeningStockMaster");

            migrationBuilder.DropColumn(
                name: "EntryTime",
                table: "OpeningStockMaster");
        }
    }
}
