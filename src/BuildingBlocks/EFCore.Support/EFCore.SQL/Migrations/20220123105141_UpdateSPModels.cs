using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class UpdateSPModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApprovalType",
                table: "SPSalesModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "SPSalesModel",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApprovalType",
                table: "SPPurchaseModel",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovalType",
                table: "SPSalesModel");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "SPSalesModel");

            migrationBuilder.AlterColumn<int>(
                name: "ApprovalType",
                table: "SPPurchaseModel",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
