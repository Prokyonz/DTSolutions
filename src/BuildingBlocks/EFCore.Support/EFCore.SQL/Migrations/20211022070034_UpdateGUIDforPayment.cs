using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class UpdateGUIDforPayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentDetails_PaymentMaster_PaymentId",
                table: "PaymentDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentMaster_GroupPaymentMaster_GroupId",
                table: "PaymentMaster");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "PaymentMaster",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GroupId",
                table: "PaymentMaster",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "FromPartyId",
                table: "PaymentMaster",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "PaymentMaster",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "PaymentMaster",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "PaymentDetails",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PurchaseId",
                table: "PaymentDetails",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "PaymentId",
                table: "PaymentDetails",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "GroupId",
                table: "PaymentDetails",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "PaymentDetails",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "PaymentDetails",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "GroupPaymentMaster",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ToPartyId",
                table: "GroupPaymentMaster",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "FinancialYearId",
                table: "GroupPaymentMaster",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "GroupPaymentMaster",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyId",
                table: "GroupPaymentMaster",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "BranchId",
                table: "GroupPaymentMaster",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "GroupPaymentMaster",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentDetails_PaymentMaster_PaymentId",
                table: "PaymentDetails",
                column: "PaymentId",
                principalTable: "PaymentMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentMaster_GroupPaymentMaster_GroupId",
                table: "PaymentMaster",
                column: "GroupId",
                principalTable: "GroupPaymentMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentDetails_PaymentMaster_PaymentId",
                table: "PaymentDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentMaster_GroupPaymentMaster_GroupId",
                table: "PaymentMaster");

            migrationBuilder.AlterColumn<Guid>(
                name: "UpdatedBy",
                table: "PaymentMaster",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "GroupId",
                table: "PaymentMaster",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "FromPartyId",
                table: "PaymentMaster",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                table: "PaymentMaster",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "PaymentMaster",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<Guid>(
                name: "UpdatedBy",
                table: "PaymentDetails",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PurchaseId",
                table: "PaymentDetails",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PaymentId",
                table: "PaymentDetails",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "GroupId",
                table: "PaymentDetails",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                table: "PaymentDetails",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "PaymentDetails",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<Guid>(
                name: "UpdatedBy",
                table: "GroupPaymentMaster",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ToPartyId",
                table: "GroupPaymentMaster",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "FinancialYearId",
                table: "GroupPaymentMaster",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                table: "GroupPaymentMaster",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CompanyId",
                table: "GroupPaymentMaster",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "BranchId",
                table: "GroupPaymentMaster",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "GroupPaymentMaster",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentDetails_PaymentMaster_PaymentId",
                table: "PaymentDetails",
                column: "PaymentId",
                principalTable: "PaymentMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentMaster_GroupPaymentMaster_GroupId",
                table: "PaymentMaster",
                column: "GroupId",
                principalTable: "GroupPaymentMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
