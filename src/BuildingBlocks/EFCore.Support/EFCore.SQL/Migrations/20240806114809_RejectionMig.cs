using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class RejectionMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FromCategoryName",
                table: "TransferViewModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToCategoryName",
                table: "TransferViewModel",
                nullable: true);            

            migrationBuilder.AddColumn<bool>(
                name: "IsSlipPrint",
                table: "SPPurchaseSlipDetailsModel",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Credit",
                table: "SPLedgerBalanceReport",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Debit",
                table: "SPLedgerBalanceReport",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<double>(
                name: "TransferCaratRate",
                table: "RejectionInOutMaster",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "TransferEntryId",
                table: "RejectionInOutMaster",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransferId",
                table: "RejectionInOutMaster",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransferType",
                table: "RejectionInOutMaster",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromCategoryName",
                table: "TransferViewModel");

            migrationBuilder.DropColumn(
                name: "ToCategoryName",
                table: "TransferViewModel");

            migrationBuilder.DropColumn(
                name: "IsSlipPrint",
                table: "SPPurchaseSlipDetailsModel");

            migrationBuilder.DropColumn(
                name: "Credit",
                table: "SPLedgerBalanceReport");

            migrationBuilder.DropColumn(
                name: "Debit",
                table: "SPLedgerBalanceReport");

            migrationBuilder.DropColumn(
                name: "TransferCaratRate",
                table: "RejectionInOutMaster");

            migrationBuilder.DropColumn(
                name: "TransferEntryId",
                table: "RejectionInOutMaster");

            migrationBuilder.DropColumn(
                name: "TransferId",
                table: "RejectionInOutMaster");

            migrationBuilder.DropColumn(
                name: "TransferType",
                table: "RejectionInOutMaster");            
        }
    }
}
