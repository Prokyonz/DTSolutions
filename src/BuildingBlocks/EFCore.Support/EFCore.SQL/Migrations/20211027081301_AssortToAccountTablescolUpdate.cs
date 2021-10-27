using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class AssortToAccountTablescolUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountToAssortMaster",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<string>(nullable: true),
                    BranchId = table.Column<string>(nullable: true),
                    FinancialId = table.Column<string>(nullable: true),
                    EntryDate = table.Column<DateTime>(nullable: true),
                    FromParyId = table.Column<string>(nullable: true),
                    ToPartyId = table.Column<string>(nullable: true),
                    KapanId = table.Column<string>(nullable: true),
                    Department = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountToAssortMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountToAssortMaster_CompanyMaster_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "CompanyMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountToAssortDetails",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountToAssortMasterId = table.Column<string>(nullable: true),
                    SlipNo = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    TotalWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    AssignWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountToAssortDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountToAssortDetails_AccountToAssortMaster_AccountToAssortMasterId",
                        column: x => x.AccountToAssortMasterId,
                        principalTable: "AccountToAssortMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountToAssortDetails_AccountToAssortMasterId",
                table: "AccountToAssortDetails",
                column: "AccountToAssortMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountToAssortMaster_CompanyId",
                table: "AccountToAssortMaster",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountToAssortDetails");

            migrationBuilder.DropTable(
                name: "AccountToAssortMaster");
        }
    }
}
