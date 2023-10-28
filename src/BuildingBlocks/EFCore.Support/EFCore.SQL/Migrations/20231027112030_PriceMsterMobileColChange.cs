using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class PriceMsterMobileColChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberId",
                table: "PriceMasterMobile");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "PriceMasterMobile");

            migrationBuilder.AddColumn<string>(
                name: "NumberName",
                table: "PriceMasterMobile",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SizeName",
                table: "PriceMasterMobile",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberName",
                table: "PriceMasterMobile");

            migrationBuilder.DropColumn(
                name: "SizeName",
                table: "PriceMasterMobile");

            migrationBuilder.AddColumn<string>(
                name: "NumberId",
                table: "PriceMasterMobile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SizeId",
                table: "PriceMasterMobile",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
