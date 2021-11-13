using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class AddColInAcctoAssort : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PurchaseDetailsId",
                table: "AccountToAssortDetails",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SPAssortmentProcessSend",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: true),
                    SlipNo = table.Column<long>(nullable: false),
                    KapanId = table.Column<string>(nullable: true),
                    Kapan = table.Column<string>(nullable: true),
                    ShapeId = table.Column<string>(nullable: true),
                    Shape = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    PurityId = table.Column<string>(nullable: true),
                    Purity = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    NetWeight = table.Column<decimal>(nullable: false),
                    TIPWeight = table.Column<decimal>(nullable: false),
                    LessWeight = table.Column<decimal>(nullable: false),
                    Weight = table.Column<decimal>(nullable: false),
                    RejectedWeight = table.Column<decimal>(nullable: false),
                    AvailableWeight = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SPAssortmentProcessSend");

            migrationBuilder.DropColumn(
                name: "PurchaseDetailsId",
                table: "AccountToAssortDetails");
        }
    }
}
