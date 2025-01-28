using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class AddJangadColumnForNumberAndKapan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JangadId",
                table: "JangadSPReceiveModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KapanId",
                table: "JangadMaster",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumberId",
                table: "JangadMaster",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SPJangadSendReceiveReportNewModel",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: true),
                    SrNo = table.Column<int>(nullable: false),
                    Sr = table.Column<int>(nullable: false),
                    ReceivedSrNo = table.Column<int>(nullable: false),
                    FinancialYearId = table.Column<string>(nullable: true),
                    PartyId = table.Column<string>(nullable: true),
                    PartyName = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    SizeName = table.Column<string>(nullable: true),
                    BrokerId = table.Column<string>(nullable: true),
                    BrokerName = table.Column<string>(nullable: true),
                    Totalcts = table.Column<decimal>(type: "decimal(18, 4)", nullable: true),
                    Rate = table.Column<decimal>(type: "decimal(18, 4)", nullable: true),
                    Amount = table.Column<double>(nullable: true),
                    EntryType = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    TotalctsReceived = table.Column<decimal>(type: "decimal(18, 4)", nullable: true),
                    RateReceived = table.Column<decimal>(type: "decimal(18, 4)", nullable: true),
                    AmountReceived = table.Column<double>(nullable: true),
                    TotalctsSales = table.Column<decimal>(type: "decimal(18, 4)", nullable: true),
                    RateSales = table.Column<double>(nullable: true),
                    AmountSales = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SPJangadSendReceiveReportNewModel");

            migrationBuilder.DropColumn(
                name: "JangadId",
                table: "JangadSPReceiveModel");

            migrationBuilder.DropColumn(
                name: "KapanId",
                table: "JangadMaster");

            migrationBuilder.DropColumn(
                name: "NumberId",
                table: "JangadMaster");
        }
    }
}
