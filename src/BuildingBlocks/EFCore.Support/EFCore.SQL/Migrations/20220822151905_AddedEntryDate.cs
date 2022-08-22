using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class AddedEntryDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EntryDate",
                table: "GroupPaymentMaster",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EntryDate",
                table: "ContraEntryMaster",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntryDate",
                table: "GroupPaymentMaster");

            migrationBuilder.DropColumn(
                name: "EntryDate",
                table: "ContraEntryMaster");
        }
    }
}
