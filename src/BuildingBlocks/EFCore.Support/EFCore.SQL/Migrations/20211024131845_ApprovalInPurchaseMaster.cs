using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class ApprovalInPurchaseMaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApprovalType",
                table: "PurchaseMaster",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "PurchaseMaster",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovalType",
                table: "PurchaseMaster");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "PurchaseMaster");
        }
    }
}
