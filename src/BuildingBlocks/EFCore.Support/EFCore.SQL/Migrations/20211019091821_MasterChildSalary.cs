using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class MasterChildSalary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalaryManager");

            migrationBuilder.CreateTable(
                name: "SalaryMaster",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<Guid>(nullable: true),
                    BranchId = table.Column<Guid>(nullable: true),
                    SalaryMonthName = table.Column<string>(nullable: true),
                    SalaryMonthDateTime = table.Column<DateTime>(nullable: false),
                    MonthDays = table.Column<int>(nullable: false),
                    Holidays = table.Column<float>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalaryDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalaryMasterId = table.Column<Guid>(nullable: false),
                    PartyId = table.Column<Guid>(nullable: false),
                    PayDays = table.Column<float>(nullable: false),
                    OvetimeDays = table.Column<float>(nullable: false),
                    AdvanceAmount = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    BonusAmount = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18, 4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalaryDetails_PartyMaster_PartyId",
                        column: x => x.PartyId,
                        principalTable: "PartyMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalaryDetails_SalaryMaster_SalaryMasterId",
                        column: x => x.SalaryMasterId,
                        principalTable: "SalaryMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalaryDetails_PartyId",
                table: "SalaryDetails",
                column: "PartyId");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryDetails_SalaryMasterId",
                table: "SalaryDetails",
                column: "SalaryMasterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalaryDetails");

            migrationBuilder.DropTable(
                name: "SalaryMaster");

            migrationBuilder.CreateTable(
                name: "SalaryManager",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdvanceAmount = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    BonusAmount = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Holidays = table.Column<float>(type: "real", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    MonthDays = table.Column<int>(type: "int", nullable: false),
                    OvetimeDays = table.Column<float>(type: "real", nullable: false),
                    PartyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PayDays = table.Column<float>(type: "real", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalaryMonthDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalaryMonthName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sr = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalAmount = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryManager", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalaryManager_PartyMaster_PartyId",
                        column: x => x.PartyId,
                        principalTable: "PartyMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalaryManager_PartyId",
                table: "SalaryManager",
                column: "PartyId");
        }
    }
}
