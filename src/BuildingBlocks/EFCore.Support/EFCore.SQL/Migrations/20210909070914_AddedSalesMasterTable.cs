using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class AddedSalesMasterTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SalesMaster",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<Guid>(nullable: false),
                    PartyId = table.Column<Guid>(nullable: false),
                    SalerId = table.Column<Guid>(nullable: false),
                    CurrencyId = table.Column<Guid>(nullable: false),
                    FinancialYearId = table.Column<Guid>(nullable: false),
                    BrokerageId = table.Column<Guid>(nullable: false),
                    CurrencyRate = table.Column<float>(nullable: false),
                    SaleBillNo = table.Column<long>(nullable: false),
                    SlipNo = table.Column<long>(nullable: false),
                    TransactionType = table.Column<int>(nullable: false),
                    Date = table.Column<string>(nullable: true),
                    Time = table.Column<string>(nullable: true),
                    DayName = table.Column<string>(nullable: true),
                    PartyLastBalanceWhileSale = table.Column<double>(nullable: false),
                    BrokerPercentage = table.Column<float>(nullable: false),
                    BrokerAmount = table.Column<double>(nullable: false),
                    RoundUpAmount = table.Column<double>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    GrossTotal = table.Column<double>(nullable: false),
                    DueDays = table.Column<int>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    PaymentDays = table.Column<int>(nullable: false),
                    PaymentDueDays = table.Column<int>(nullable: false),
                    IsSlip = table.Column<bool>(nullable: false),
                    IsPF = table.Column<bool>(nullable: false),
                    CommissionToPartyId = table.Column<Guid>(nullable: false),
                    CommissionPercentage = table.Column<float>(nullable: false),
                    CommissionAmount = table.Column<double>(nullable: false),
                    Image1 = table.Column<byte[]>(nullable: true),
                    Image2 = table.Column<byte[]>(nullable: true),
                    Image3 = table.Column<byte[]>(nullable: true),
                    AllowSlipPrint = table.Column<bool>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesMaster", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesMaster");
        }
    }
}
