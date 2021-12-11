using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class AddGalaColumnInSalesDetailsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GalaSize",
                table: "SalesItemDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GalaSizeId",
                table: "SalesItemDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GalaSizeId",
                table: "SalesDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GalaSize",
                table: "SalesItemDetails");

            migrationBuilder.DropColumn(
                name: "GalaSizeId",
                table: "SalesItemDetails");

            migrationBuilder.DropColumn(
                name: "GalaSizeId",
                table: "SalesDetails");
        }
    }
}
