using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class JangadColsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CharniSizeId",
                table: "SPRejectionSendReceiveModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JangadId",
                table: "SalesMaster",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CharniSizeId",
                table: "SPRejectionSendReceiveModel");

            migrationBuilder.DropColumn(
                name: "JangadId",
                table: "SalesMaster");
        }
    }
}
