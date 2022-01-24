using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class ApprovalColAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApprovalType",
                table: "TransferMaster",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "TransferMaster",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApprovalType",
                table: "SPSalesModel",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ApprovalType",
                table: "SlipTransferEntry",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "SlipTransferEntry",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonName",
                table: "SlipTransferEntry",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApprovalType",
                table: "GroupPaymentMaster",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "GroupPaymentMaster",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApprovalType",
                table: "ExpenseDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "ExpenseDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovalType",
                table: "TransferMaster");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "TransferMaster");

            migrationBuilder.DropColumn(
                name: "ApprovalType",
                table: "SlipTransferEntry");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "SlipTransferEntry");

            migrationBuilder.DropColumn(
                name: "PersonName",
                table: "SlipTransferEntry");

            migrationBuilder.DropColumn(
                name: "ApprovalType",
                table: "GroupPaymentMaster");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "GroupPaymentMaster");

            migrationBuilder.DropColumn(
                name: "ApprovalType",
                table: "ExpenseDetails");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "ExpenseDetails");

            migrationBuilder.AlterColumn<int>(
                name: "ApprovalType",
                table: "SPSalesModel",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
