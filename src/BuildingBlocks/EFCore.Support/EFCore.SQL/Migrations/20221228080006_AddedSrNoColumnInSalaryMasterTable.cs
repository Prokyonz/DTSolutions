using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class AddedSrNoColumnInSalaryMasterTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SrNo",
                table: "SalaryMaster",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SPRejectionSendReceiveModel",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: true),
                    CompanyId = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    SlipNo = table.Column<long>(nullable: false),
                    KapanId = table.Column<string>(nullable: true),
                    Kapan = table.Column<string>(nullable: true),
                    ShapeId = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    PurityId = table.Column<string>(nullable: true),
                    RejectedWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    ReturnCts = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    Available = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    Rate = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SPRejectionSendReceiveModel");

            migrationBuilder.DropColumn(
                name: "SrNo",
                table: "SalaryMaster");
        }
    }
}
