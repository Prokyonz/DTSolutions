using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class TimeColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EntryTime",
                table: "LoanMaster",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EntryTime",
                table: "GroupPaymentMaster",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EntryTime",
                table: "ContraEntryMaster",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntryTime",
                table: "LoanMaster");

            migrationBuilder.DropColumn(
                name: "EntryTime",
                table: "GroupPaymentMaster");

            migrationBuilder.DropColumn(
                name: "EntryTime",
                table: "ContraEntryMaster");
        }
    }
}
