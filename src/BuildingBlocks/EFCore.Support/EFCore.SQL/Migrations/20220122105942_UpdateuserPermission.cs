using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class UpdateuserPermission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SPPurchaseSlipDetailsModel",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SlipNo = table.Column<long>(nullable: false),
                    Date = table.Column<string>(nullable: true),
                    PartyId = table.Column<string>(nullable: true),
                    Party = table.Column<string>(nullable: true),
                    BrokerageId = table.Column<string>(nullable: true),
                    Broker = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SPPurchaseSlipDetailsModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SPSlipDetailPrintModel",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SlipNo = table.Column<long>(nullable: false),
                    Date = table.Column<string>(nullable: true),
                    PartyId = table.Column<string>(nullable: true),
                    Party = table.Column<string>(nullable: true),
                    BrokerageId = table.Column<string>(nullable: true),
                    Broker = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(nullable: false),
                    CVDWeight = table.Column<decimal>(nullable: false),
                    LessDiscountPercentage = table.Column<decimal>(nullable: false),
                    RejectedWeight = table.Column<decimal>(nullable: false),
                    LessWeight = table.Column<decimal>(nullable: false),
                    NetWeight = table.Column<decimal>(nullable: false),
                    CRate = table.Column<decimal>(nullable: false),
                    Disc = table.Column<decimal>(nullable: false),
                    CVDCharge = table.Column<decimal>(nullable: false),
                    DueDays = table.Column<int>(nullable: false),
                    PaymentDays = table.Column<int>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    Final = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SPSlipDetailPrintModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SPPurchaseSlipDetailsModel");

            migrationBuilder.DropTable(
                name: "SPSlipDetailPrintModel");
        }
    }
}
