using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class AddedNewRemarkColumnInKapanMappingMaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KapanId",
                table: "SPKapanMapping",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SrNo",
                table: "SPContraModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "KapanMappingMaster",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KapanId",
                table: "SPKapanMapping");

            migrationBuilder.DropColumn(
                name: "SrNo",
                table: "SPContraModel");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "KapanMappingMaster");
        }
    }
}
