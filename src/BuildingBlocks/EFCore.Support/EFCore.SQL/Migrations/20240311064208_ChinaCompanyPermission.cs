using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class ChinaCompanyPermission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SPSlipDetailPrintModel",
                table: "SPSlipDetailPrintModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SPSalesModel",
                table: "SPSalesModel");            

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "SPSlipDetailPrintModel",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "SPSalesModel",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "CompanyOptions",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyMasterId = table.Column<string>(nullable: true),
                    IsPurchase = table.Column<bool>(nullable: false),
                    IsSales = table.Column<bool>(nullable: false),
                    PermissionName = table.Column<string>(nullable: true),
                    PermissionStatus = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyOptions_CompanyMaster_CompanyMasterId",
                        column: x => x.CompanyMasterId,
                        principalTable: "CompanyMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyOptions_CompanyMasterId",
                table: "CompanyOptions",
                column: "CompanyMasterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyOptions");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "SPSlipDetailPrintModel",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long))
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "SPSalesModel",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SPSlipDetailPrintModel",
                table: "SPSlipDetailPrintModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SPSalesModel",
                table: "SPSalesModel",
                column: "Id");
        }
    }
}
