using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class GalaProcessMasterColumnNameUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CharniNo",
                table: "GalaProcessMaster");

            migrationBuilder.AddColumn<int>(
                name: "GalaNo",
                table: "GalaProcessMaster",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SPBoilProcessReceive",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: true),
                    BoilNo = table.Column<int>(nullable: false),
                    KapanId = table.Column<string>(nullable: true),
                    Kapan = table.Column<string>(nullable: true),
                    SlipNo = table.Column<string>(nullable: true),
                    ShapeId = table.Column<string>(nullable: true),
                    Shape = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    PurityId = table.Column<string>(nullable: true),
                    Purity = table.Column<string>(nullable: true),
                    TotalWeight = table.Column<decimal>(nullable: false),
                    AvailableWeight = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SPBoilProcessSend",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: true),
                    SlipNo = table.Column<long>(nullable: false),
                    KapanId = table.Column<string>(nullable: true),
                    Kapan = table.Column<string>(nullable: true),
                    PurchaseDetailsId = table.Column<string>(nullable: true),
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

            migrationBuilder.CreateTable(
                name: "SPCharniProcessReceive",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: true),
                    CharniNo = table.Column<int>(nullable: false),
                    BoilJangadNo = table.Column<int>(nullable: false),
                    EntryDate = table.Column<string>(nullable: true),
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
                name: "SPCharniProcessSend",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: true),
                    SlipNo = table.Column<string>(nullable: true),
                    KapanId = table.Column<string>(nullable: true),
                    Kapan = table.Column<string>(nullable: true),
                    BoilNo = table.Column<int>(nullable: false),
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
                name: "SPContraModel",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ContraId = table.Column<string>(nullable: true),
                    FromPartyId = table.Column<string>(nullable: true),
                    ToPartyId = table.Column<string>(nullable: true),
                    FromPartyName = table.Column<string>(nullable: true),
                    ToPartyName = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SPContraModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SPPaymentModel",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    GroupId = table.Column<string>(nullable: true),
                    FromPartyId = table.Column<string>(nullable: true),
                    ToPartyId = table.Column<string>(nullable: true),
                    FromName = table.Column<string>(nullable: true),
                    ToName = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    ChequeNo = table.Column<string>(nullable: true),
                    ChequeDate = table.Column<DateTime>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SPPaymentModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SPBoilProcessReceive");

            migrationBuilder.DropTable(
                name: "SPBoilProcessSend");

            migrationBuilder.DropTable(
                name: "SPCharniProcessReceive");

            migrationBuilder.DropTable(
                name: "SPCharniProcessSend");

            migrationBuilder.DropTable(
                name: "SPContraModel");

            migrationBuilder.DropTable(
                name: "SPPaymentModel");

            migrationBuilder.DropColumn(
                name: "GalaNo",
                table: "GalaProcessMaster");

            migrationBuilder.AddColumn<int>(
                name: "CharniNo",
                table: "GalaProcessMaster",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
