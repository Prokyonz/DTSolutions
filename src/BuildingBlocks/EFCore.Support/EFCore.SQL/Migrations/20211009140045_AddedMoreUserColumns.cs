using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class AddedMoreUserColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "UserMaster");

            migrationBuilder.AddColumn<string>(
                name: "AccountNo",
                table: "UserMaster",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankName",
                table: "UserMaster",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BrokerageId",
                table: "UserMaster",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "UserMaster",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfEnd",
                table: "UserMaster",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfJoin",
                table: "UserMaster",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DepartmentName",
                table: "UserMaster",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Designation",
                table: "UserMaster",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IFSCCode",
                table: "UserMaster",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "UserMaster",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserCode",
                table: "UserMaster",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserType",
                table: "UserMaster",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountNo",
                table: "UserMaster");

            migrationBuilder.DropColumn(
                name: "BankName",
                table: "UserMaster");

            migrationBuilder.DropColumn(
                name: "BrokerageId",
                table: "UserMaster");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "UserMaster");

            migrationBuilder.DropColumn(
                name: "DateOfEnd",
                table: "UserMaster");

            migrationBuilder.DropColumn(
                name: "DateOfJoin",
                table: "UserMaster");

            migrationBuilder.DropColumn(
                name: "DepartmentName",
                table: "UserMaster");

            migrationBuilder.DropColumn(
                name: "Designation",
                table: "UserMaster");

            migrationBuilder.DropColumn(
                name: "IFSCCode",
                table: "UserMaster");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "UserMaster");

            migrationBuilder.DropColumn(
                name: "UserCode",
                table: "UserMaster");

            migrationBuilder.DropColumn(
                name: "UserType",
                table: "UserMaster");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "UserMaster",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
