using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class KapanMasterandUserMaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailId",
                table: "UserMaster");

            migrationBuilder.DropColumn(
                name: "IsDetele",
                table: "UserMaster");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "UserMaster");

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "UserMaster",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "UserMaster",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "UserMaster",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "KapanMappingMaster",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseMasterId = table.Column<Guid>(nullable: false),
                    PurchaseDetailsId = table.Column<Guid>(nullable: false),
                    KapanId = table.Column<Guid>(nullable: false),
                    SlipId = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KapanMappingMaster", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KapanMappingMaster");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "UserMaster");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "UserMaster");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "UserMaster");

            migrationBuilder.AddColumn<string>(
                name: "EmailId",
                table: "UserMaster",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDetele",
                table: "UserMaster",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "UserMaster",
                type: "datetime2",
                nullable: true);
        }
    }
}
