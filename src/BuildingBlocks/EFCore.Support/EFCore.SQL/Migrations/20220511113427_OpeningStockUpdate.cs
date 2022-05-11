using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class OpeningStockUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NmberId",
                table: "OpeningStockMaster");

            migrationBuilder.AddColumn<string>(
                name: "NumberId",
                table: "OpeningStockMaster",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberId",
                table: "OpeningStockMaster");

            migrationBuilder.AddColumn<string>(
                name: "NmberId",
                table: "OpeningStockMaster",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
