using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class AddContraTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContraEntryDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContraEntryMasterId = table.Column<Guid>(nullable: false),
                    FromParty = table.Column<Guid>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContraEntryDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContraEntryMaster",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<Guid>(nullable: false),
                    BranchId = table.Column<Guid>(nullable: false),
                    FinancialYearId = table.Column<Guid>(nullable: false),
                    ToPartyId = table.Column<Guid>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContraEntryMaster", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContraEntryDetails");

            migrationBuilder.DropTable(
                name: "ContraEntryMaster");
        }
    }
}
