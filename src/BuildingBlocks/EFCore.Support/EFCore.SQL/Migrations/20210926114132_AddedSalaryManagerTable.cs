using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class AddedSalaryManagerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SalaryManager",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    BranchId = table.Column<Guid>(nullable: true),
                    SalaryMonthName = table.Column<string>(nullable: true),
                    SalaryMonthDateTime = table.Column<DateTime>(nullable: false),
                    MonthDays = table.Column<int>(nullable: false),
                    Holidays = table.Column<float>(nullable: false),
                    PayDays = table.Column<float>(nullable: false),
                    OvetimeDays = table.Column<float>(nullable: false),
                    AdvanceAmount = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    BonusAmount = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryManager", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalaryManager_UserMaster_UserId",
                        column: x => x.UserId,
                        principalTable: "UserMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalaryManager_UserId",
                table: "SalaryManager",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalaryManager");
        }
    }
}
