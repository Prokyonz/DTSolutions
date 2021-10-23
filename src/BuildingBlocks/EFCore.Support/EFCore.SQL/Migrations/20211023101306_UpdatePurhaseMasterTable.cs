using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class UpdatePurhaseMasterTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommissionToPartyId",
                table: "PurchaseMaster");

            migrationBuilder.DropColumn(
                name: "PaymentDueDays",
                table: "PurchaseMaster");

            migrationBuilder.AddColumn<DateTime>(
                name: "PaymentDueDate",
                table: "PurchaseMaster",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentDueDate",
                table: "PurchaseMaster");

            migrationBuilder.AddColumn<Guid>(
                name: "CommissionToPartyId",
                table: "PurchaseMaster",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "PaymentDueDays",
                table: "PurchaseMaster",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
