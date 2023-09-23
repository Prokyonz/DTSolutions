using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class AddedBillPrintColsComapny : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PartyName",
                table: "SPExpenseModel");

            migrationBuilder.AddColumn<int>(
                name: "SrNo",
                table: "SPPaymentModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FromPartyName",
                table: "SPExpenseModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToPartyName",
                table: "SPExpenseModel",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GroupId",
                table: "PaymentDetails",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BranchId",
                table: "BillPrintModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "BillPrintModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FinancialYearId",
                table: "BillPrintModel",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentDetails_GroupId",
                table: "PaymentDetails",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentDetails_GroupPaymentMaster_GroupId",
                table: "PaymentDetails",
                column: "GroupId",
                principalTable: "GroupPaymentMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentDetails_GroupPaymentMaster_GroupId",
                table: "PaymentDetails");

            migrationBuilder.DropIndex(
                name: "IX_PaymentDetails_GroupId",
                table: "PaymentDetails");

            migrationBuilder.DropColumn(
                name: "SrNo",
                table: "SPPaymentModel");

            migrationBuilder.DropColumn(
                name: "FromPartyName",
                table: "SPExpenseModel");

            migrationBuilder.DropColumn(
                name: "ToPartyName",
                table: "SPExpenseModel");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "BillPrintModel");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "BillPrintModel");

            migrationBuilder.DropColumn(
                name: "FinancialYearId",
                table: "BillPrintModel");

            migrationBuilder.AddColumn<string>(
                name: "PartyName",
                table: "SPExpenseModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GroupId",
                table: "PaymentDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
