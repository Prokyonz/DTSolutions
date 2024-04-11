using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class AddedNewColumnsForNumberPurchase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsNumberPurchase",
                table: "PurchaseDetails",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PurchaseDetailsId",
                table: "NumberProcessMaster",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PurchaseMasterId",
                table: "NumberProcessMaster",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsNumberPurchase",
                table: "PurchaseDetails");

            migrationBuilder.DropColumn(
                name: "PurchaseDetailsId",
                table: "NumberProcessMaster");

            migrationBuilder.DropColumn(
                name: "PurchaseMasterId",
                table: "NumberProcessMaster");
        }
    }
}
