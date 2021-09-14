using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class UpdateCurrencyMasterTable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShotName",
                table: "CurrencyMaster");

            migrationBuilder.AddColumn<string>(
                name: "ShortName",
                table: "CurrencyMaster",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortName",
                table: "CurrencyMaster");

            migrationBuilder.AddColumn<string>(
                name: "ShotName",
                table: "CurrencyMaster",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
