using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class ColsForTransfer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "SalesItemDetails");

            migrationBuilder.AddColumn<string>(
                name: "CharniSize",
                table: "SPNumberProcessSend",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CharniSizeId",
                table: "SPNumberProcessSend",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CharniSize",
                table: "SPNumberProcessReturn",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CharniSizeId",
                table: "SPNumberProcessReturn",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CharniSize",
                table: "SPNumberProcessReceive",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CharniSizeId",
                table: "SPNumberProcessReceive",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EntryType",
                table: "AccountToAssortMaster",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TransferEntryId",
                table: "AccountToAssortMaster",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransferId",
                table: "AccountToAssortMaster",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransferType",
                table: "AccountToAssortMaster",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "AccountToAssortDetails",
                type: "decimal(18, 4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "AccountToAssortDetails",
                type: "decimal(18, 4)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CharniSize",
                table: "SPNumberProcessSend");

            migrationBuilder.DropColumn(
                name: "CharniSizeId",
                table: "SPNumberProcessSend");

            migrationBuilder.DropColumn(
                name: "CharniSize",
                table: "SPNumberProcessReturn");

            migrationBuilder.DropColumn(
                name: "CharniSizeId",
                table: "SPNumberProcessReturn");

            migrationBuilder.DropColumn(
                name: "CharniSize",
                table: "SPNumberProcessReceive");

            migrationBuilder.DropColumn(
                name: "CharniSizeId",
                table: "SPNumberProcessReceive");

            migrationBuilder.DropColumn(
                name: "EntryType",
                table: "AccountToAssortMaster");

            migrationBuilder.DropColumn(
                name: "TransferEntryId",
                table: "AccountToAssortMaster");

            migrationBuilder.DropColumn(
                name: "TransferId",
                table: "AccountToAssortMaster");

            migrationBuilder.DropColumn(
                name: "TransferType",
                table: "AccountToAssortMaster");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "AccountToAssortDetails");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "AccountToAssortDetails");

            migrationBuilder.AddColumn<string>(
                name: "BranchId",
                table: "SalesItemDetails",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
