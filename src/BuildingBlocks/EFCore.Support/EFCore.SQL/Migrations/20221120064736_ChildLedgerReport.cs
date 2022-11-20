using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class ChildLedgerReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "SPPaymentModel");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "SPPaymentModel");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "SPCashBankReport",
                newName: "Debit");

            migrationBuilder.AddColumn<string>(
                name: "ApprovalType",
                table: "SPPaymentModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BrokerName",
                table: "SPPayableReceivableReport",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EntryDate",
                table: "SPPayableReceivableReport",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "SPPayableReceivableReport",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SlipNo",
                table: "SPPayableReceivableReport",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "EntryDate",
                table: "SPMixedReportModel",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LoanType",
                table: "SPLoanReportModel",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "ClosingBalance",
                table: "SPLedgerBalanceReport",
                type: "decimal(18, 4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "PartyType",
                table: "SPLedgerBalanceReport",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "InwardAvg",
                table: "SPKapanLagadReportModel",
                type: "decimal(18, 2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OperationType",
                table: "SPKapanLagadReportModel",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "OutwardAvg",
                table: "SPKapanLagadReportModel",
                type: "decimal(18, 2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PerCts",
                table: "SPKapanLagadReportModel",
                type: "decimal(18, 2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "SPKapanLagadReportModel",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalSizeGroupWeight",
                table: "SPKapanLagadReportModel",
                type: "decimal(18, 2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sr",
                table: "SPContraModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Credit",
                table: "SPCashBankReport",
                type: "decimal(18, 4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "EntryDate",
                table: "SPCashBankReport",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountToAssortDetailsId",
                table: "SPBoilProcessSend",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SPLedgerChildReport",
                columns: table => new
                {
                    EntryType = table.Column<string>(nullable: true),
                    FromPartyId = table.Column<string>(nullable: true),
                    FromPartyName = table.Column<string>(nullable: true),
                    ToPartyId = table.Column<string>(nullable: true),
                    ToPartyName = table.Column<string>(nullable: true),
                    Debit = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    Credit = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    Date = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SPLedgerChildReport");

            migrationBuilder.DropColumn(
                name: "ApprovalType",
                table: "SPPaymentModel");

            migrationBuilder.DropColumn(
                name: "BrokerName",
                table: "SPPayableReceivableReport");

            migrationBuilder.DropColumn(
                name: "EntryDate",
                table: "SPPayableReceivableReport");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SPPayableReceivableReport");

            migrationBuilder.DropColumn(
                name: "SlipNo",
                table: "SPPayableReceivableReport");

            migrationBuilder.DropColumn(
                name: "EntryDate",
                table: "SPMixedReportModel");

            migrationBuilder.DropColumn(
                name: "PartyType",
                table: "SPLedgerBalanceReport");

            migrationBuilder.DropColumn(
                name: "InwardAvg",
                table: "SPKapanLagadReportModel");

            migrationBuilder.DropColumn(
                name: "OperationType",
                table: "SPKapanLagadReportModel");

            migrationBuilder.DropColumn(
                name: "OutwardAvg",
                table: "SPKapanLagadReportModel");

            migrationBuilder.DropColumn(
                name: "PerCts",
                table: "SPKapanLagadReportModel");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "SPKapanLagadReportModel");

            migrationBuilder.DropColumn(
                name: "TotalSizeGroupWeight",
                table: "SPKapanLagadReportModel");

            migrationBuilder.DropColumn(
                name: "Sr",
                table: "SPContraModel");

            migrationBuilder.DropColumn(
                name: "Credit",
                table: "SPCashBankReport");

            migrationBuilder.DropColumn(
                name: "EntryDate",
                table: "SPCashBankReport");

            migrationBuilder.DropColumn(
                name: "AccountToAssortDetailsId",
                table: "SPBoilProcessSend");

            migrationBuilder.RenameColumn(
                name: "Debit",
                table: "SPCashBankReport",
                newName: "Amount");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "SPPaymentModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "SPPaymentModel",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LoanType",
                table: "SPLoanReportModel",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ClosingBalance",
                table: "SPLedgerBalanceReport",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 4)");
        }
    }
}
