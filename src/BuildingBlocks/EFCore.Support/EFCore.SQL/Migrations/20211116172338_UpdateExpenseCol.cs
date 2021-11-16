using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class UpdateExpenseCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SrNo",
                table: "ExpenseDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SPGalaProcessReceive",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: true),
                    GalaNo = table.Column<int>(nullable: false),
                    KapanId = table.Column<string>(nullable: true),
                    Kapan = table.Column<string>(nullable: true),
                    SlipNo = table.Column<string>(nullable: true),
                    ShapeId = table.Column<string>(nullable: true),
                    Shape = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    PurityId = table.Column<string>(nullable: true),
                    Purity = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(nullable: false),
                    AvailableWeight = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SPGalaProcessSend",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: true),
                    SlipNo = table.Column<string>(nullable: true),
                    KapanId = table.Column<string>(nullable: true),
                    Kapan = table.Column<string>(nullable: true),
                    ShapeId = table.Column<string>(nullable: true),
                    Shape = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    PurityId = table.Column<string>(nullable: true),
                    Purity = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(nullable: false),
                    AvailableWeight = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SPNumberProcessReceive",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: true),
                    NumberNo = table.Column<int>(nullable: false),
                    KapanId = table.Column<string>(nullable: true),
                    Kapan = table.Column<string>(nullable: true),
                    SlipNo = table.Column<string>(nullable: true),
                    ShapeId = table.Column<string>(nullable: true),
                    Shape = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    PurityId = table.Column<string>(nullable: true),
                    Purity = table.Column<string>(nullable: true),
                    GalaNumberId = table.Column<string>(nullable: true),
                    GalaNumber = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(nullable: false),
                    AvailableWeight = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SPNumberProcessSend",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: true),
                    SlipNo = table.Column<string>(nullable: true),
                    KapanId = table.Column<string>(nullable: true),
                    Kapan = table.Column<string>(nullable: true),
                    ShapeId = table.Column<string>(nullable: true),
                    Shape = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    PurityId = table.Column<string>(nullable: true),
                    Purity = table.Column<string>(nullable: true),
                    GalaNumberId = table.Column<string>(nullable: true),
                    GalaNumber = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(nullable: false),
                    AvailableWeight = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SPPurchaseModel",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    PurchaseBillNo = table.Column<long>(nullable: false),
                    SlipNo = table.Column<long>(nullable: false),
                    Date = table.Column<string>(nullable: true),
                    Time = table.Column<string>(nullable: true),
                    PartyId = table.Column<string>(nullable: true),
                    PartyName = table.Column<string>(nullable: true),
                    MobileNo = table.Column<string>(nullable: true),
                    BuyerId = table.Column<string>(nullable: true),
                    BuyerName = table.Column<string>(nullable: true),
                    BuyerMobileNo = table.Column<string>(nullable: true),
                    BrokerageId = table.Column<string>(nullable: true),
                    BrokerName = table.Column<string>(nullable: true),
                    BrokerMobileNo = table.Column<string>(nullable: true),
                    Total = table.Column<double>(nullable: false),
                    GrossTotal = table.Column<double>(nullable: false),
                    DueDays = table.Column<int>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: true),
                    PaymentDays = table.Column<int>(nullable: false),
                    PaymentDueDate = table.Column<DateTime>(nullable: true),
                    IsPF = table.Column<bool>(nullable: false),
                    IsSlip = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    KapanId = table.Column<string>(nullable: true),
                    KapanName = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    BuyingRate = table.Column<double>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    ApprovalType = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SPPurchaseModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SPGalaProcessReceive");

            migrationBuilder.DropTable(
                name: "SPGalaProcessSend");

            migrationBuilder.DropTable(
                name: "SPNumberProcessReceive");

            migrationBuilder.DropTable(
                name: "SPNumberProcessSend");

            migrationBuilder.DropTable(
                name: "SPPurchaseModel");

            migrationBuilder.DropColumn(
                name: "SrNo",
                table: "ExpenseDetails");
        }
    }
}
