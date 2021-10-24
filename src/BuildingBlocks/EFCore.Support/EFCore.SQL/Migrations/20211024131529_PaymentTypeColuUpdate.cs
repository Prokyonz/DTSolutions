using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class PaymentTypeColuUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CrDrType",
                table: "PaymentMaster");

            migrationBuilder.AddColumn<int>(
                name: "CrDrType",
                table: "GroupPaymentMaster",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CrDrType",
                table: "GroupPaymentMaster");

            migrationBuilder.AddColumn<int>(
                name: "CrDrType",
                table: "PaymentMaster",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
