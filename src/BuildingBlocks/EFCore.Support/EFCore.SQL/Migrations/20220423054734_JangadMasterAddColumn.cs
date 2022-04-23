using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class JangadMasterAddColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "SPExpenseModel",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReceivedSrNo",
                table: "JangadMaster",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "JangadSPReceiveModel",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: true),
                    SrNo = table.Column<int>(nullable: false),
                    SizeId = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    PartyId = table.Column<string>(nullable: true),
                    PartyName = table.Column<string>(nullable: true),
                    BrokerId = table.Column<string>(nullable: true),
                    BrokerName = table.Column<string>(nullable: true),
                    Rate = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    TotalWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    AvailableWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "PriceSPModel",
                columns: table => new
                {
                    CompanyId = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    NumberId = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 4)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SPAccountToAssoftReceiveReportModel",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: true),
                    Dept = table.Column<string>(nullable: true),
                    Sr = table.Column<int>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    BranchId = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    JangadNo = table.Column<int>(nullable: false),
                    EntryDate = table.Column<string>(nullable: true),
                    HandOverById = table.Column<string>(nullable: true),
                    HandOverByName = table.Column<string>(nullable: true),
                    HandOverToId = table.Column<string>(nullable: true),
                    HandOverToName = table.Column<string>(nullable: true),
                    KapanId = table.Column<string>(nullable: true),
                    KapanName = table.Column<string>(nullable: true),
                    ShapeId = table.Column<string>(nullable: true),
                    ShapeName = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    SizeName = table.Column<string>(nullable: true),
                    PurityId = table.Column<string>(nullable: true),
                    PurityName = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    SlipNo = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SPAccountToAssortSendReceiveReportModels",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: true),
                    ChildId = table.Column<string>(nullable: true),
                    Sr = table.Column<int>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    BranchId = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    EntryDate = table.Column<string>(nullable: true),
                    FromPartyId = table.Column<string>(nullable: true),
                    FromPartyName = table.Column<string>(nullable: true),
                    ToPartyId = table.Column<string>(nullable: true),
                    ToPartyName = table.Column<string>(nullable: true),
                    KapanId = table.Column<string>(nullable: true),
                    KapanName = table.Column<string>(nullable: true),
                    AccountToAssortType = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    SlipNo = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    SizeName = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    AssignWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SPBoilSendReceiveReportModels",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: true),
                    BoilType = table.Column<int>(nullable: false),
                    Sr = table.Column<int>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    BranchId = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    JangadNo = table.Column<int>(nullable: false),
                    EntryDate = table.Column<string>(nullable: true),
                    HandOverById = table.Column<string>(nullable: true),
                    HandOverByName = table.Column<string>(nullable: true),
                    HandOverToId = table.Column<string>(nullable: true),
                    HandOverToName = table.Column<string>(nullable: true),
                    KapanId = table.Column<string>(nullable: true),
                    KapanName = table.Column<string>(nullable: true),
                    ShapeId = table.Column<string>(nullable: true),
                    ShapeName = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    SizeName = table.Column<string>(nullable: true),
                    PurityId = table.Column<string>(nullable: true),
                    PurityName = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    SlipNo = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SPCharniSendReceiveReportModels",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: true),
                    CharniType = table.Column<int>(nullable: false),
                    Sr = table.Column<int>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    BranchId = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    JangadNo = table.Column<int>(nullable: false),
                    EntryDate = table.Column<string>(nullable: true),
                    HandOverById = table.Column<string>(nullable: true),
                    HandOverByName = table.Column<string>(nullable: true),
                    HandOverToId = table.Column<string>(nullable: true),
                    HandOverToName = table.Column<string>(nullable: true),
                    KapanId = table.Column<string>(nullable: true),
                    KapanName = table.Column<string>(nullable: true),
                    ShapeId = table.Column<string>(nullable: true),
                    ShapeName = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    SizeName = table.Column<string>(nullable: true),
                    PurityId = table.Column<string>(nullable: true),
                    PurityName = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    SlipNo = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SPGalaProcessSendReceiveReportModels",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: true),
                    GalaProcessType = table.Column<int>(nullable: false),
                    Sr = table.Column<int>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    BranchId = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    JangadNo = table.Column<int>(nullable: false),
                    EntryDate = table.Column<string>(nullable: true),
                    HandOverById = table.Column<string>(nullable: true),
                    HandOverByName = table.Column<string>(nullable: true),
                    HandOverToId = table.Column<string>(nullable: true),
                    HandOverToName = table.Column<string>(nullable: true),
                    KapanId = table.Column<string>(nullable: true),
                    KapanName = table.Column<string>(nullable: true),
                    ShapeId = table.Column<string>(nullable: true),
                    ShapeName = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    SizeName = table.Column<string>(nullable: true),
                    PurityId = table.Column<string>(nullable: true),
                    PurityName = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    SlipNo = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SPKapanMappingReportModel",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: true),
                    Sr = table.Column<int>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    BranchId = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    SlipNo = table.Column<string>(nullable: true),
                    KapanId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SPNumberProcessSendReceiveReportModels",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: true),
                    NumberProcessType = table.Column<int>(nullable: false),
                    Sr = table.Column<int>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    BranchId = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    JangadNo = table.Column<int>(nullable: false),
                    EntryDate = table.Column<string>(nullable: true),
                    HandOverById = table.Column<string>(nullable: true),
                    HandOverByName = table.Column<string>(nullable: true),
                    HandOverToId = table.Column<string>(nullable: true),
                    HandOverToName = table.Column<string>(nullable: true),
                    KapanId = table.Column<string>(nullable: true),
                    KapanName = table.Column<string>(nullable: true),
                    ShapeId = table.Column<string>(nullable: true),
                    ShapeName = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    SizeName = table.Column<string>(nullable: true),
                    PurityId = table.Column<string>(nullable: true),
                    PurityName = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    SlipNo = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JangadSPReceiveModel");

            migrationBuilder.DropTable(
                name: "PriceSPModel");

            migrationBuilder.DropTable(
                name: "SPAccountToAssoftReceiveReportModel");

            migrationBuilder.DropTable(
                name: "SPAccountToAssortSendReceiveReportModels");

            migrationBuilder.DropTable(
                name: "SPBoilSendReceiveReportModels");

            migrationBuilder.DropTable(
                name: "SPCharniSendReceiveReportModels");

            migrationBuilder.DropTable(
                name: "SPGalaProcessSendReceiveReportModels");

            migrationBuilder.DropTable(
                name: "SPKapanMappingReportModel");

            migrationBuilder.DropTable(
                name: "SPNumberProcessSendReceiveReportModels");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SPExpenseModel");

            migrationBuilder.DropColumn(
                name: "ReceivedSrNo",
                table: "JangadMaster");
        }
    }
}
