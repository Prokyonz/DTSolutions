using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class AddedNewSaleDetailsSummaryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "SPLedgerChildReport",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SlipNo",
                table: "SPLedgerChildReport",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SalesDetailsSummary",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesId = table.Column<string>(nullable: true),
                    SalesDetailsId = table.Column<string>(nullable: true),
                    CompanyId = table.Column<string>(nullable: true),
                    BranchId = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    SlipNo = table.Column<string>(nullable: true),
                    KapanId = table.Column<string>(nullable: true),
                    ShapeId = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    PurityId = table.Column<string>(nullable: true),
                    CharniSizeId = table.Column<string>(nullable: true),
                    GalaSizeId = table.Column<string>(nullable: true),
                    NumberSizeId = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    Category = table.Column<int>(nullable: false),
                    PurchaseId = table.Column<string>(nullable: true),
                    PurchaseDetailsId = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    SalesDetailsId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesDetailsSummary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesDetailsSummary_SalesMaster_SalesDetailsId",
                        column: x => x.SalesDetailsId,
                        principalTable: "SalesMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesDetailsSummary_SalesDetails_SalesDetailsId1",
                        column: x => x.SalesDetailsId1,
                        principalTable: "SalesDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalesDetailsSummary_SalesDetailsId",
                table: "SalesDetailsSummary",
                column: "SalesDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesDetailsSummary_SalesDetailsId1",
                table: "SalesDetailsSummary",
                column: "SalesDetailsId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesDetailsSummary");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "SPLedgerChildReport");

            migrationBuilder.DropColumn(
                name: "SlipNo",
                table: "SPLedgerChildReport");
        }
    }
}
