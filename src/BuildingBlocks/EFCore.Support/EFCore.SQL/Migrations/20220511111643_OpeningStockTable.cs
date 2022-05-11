using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class OpeningStockTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "SPNumberProcessSendReceiveReportModels");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "SPNumberProcessSendReceiveReportModels");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SPNumberProcessSendReceiveReportModels");

            migrationBuilder.DropColumn(
                name: "Sr",
                table: "SPNumberProcessSendReceiveReportModels");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "SPNumberProcessSendReceiveReportModels");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "SPNumberProcessSendReceiveReportModels");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "SPGalaProcessSendReceiveReportModels");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "SPGalaProcessSendReceiveReportModels");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SPGalaProcessSendReceiveReportModels");

            migrationBuilder.DropColumn(
                name: "Sr",
                table: "SPGalaProcessSendReceiveReportModels");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "SPGalaProcessSendReceiveReportModels");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "SPGalaProcessSendReceiveReportModels");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "SPCharniSendReceiveReportModels");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "SPCharniSendReceiveReportModels");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SPCharniSendReceiveReportModels");

            migrationBuilder.DropColumn(
                name: "Sr",
                table: "SPCharniSendReceiveReportModels");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "SPCharniSendReceiveReportModels");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "SPCharniSendReceiveReportModels");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "SPBoilSendReceiveReportModels");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "SPBoilSendReceiveReportModels");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SPBoilSendReceiveReportModels");

            migrationBuilder.DropColumn(
                name: "Sr",
                table: "SPBoilSendReceiveReportModels");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "SPBoilSendReceiveReportModels");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "SPBoilSendReceiveReportModels");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EntryDate",
                table: "SPNumberProcessSendReceiveReportModels",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GalaName",
                table: "SPNumberProcessSendReceiveReportModels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GalaNumberId",
                table: "SPNumberProcessSendReceiveReportModels",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "LossWeight",
                table: "SPNumberProcessSendReceiveReportModels",
                type: "decimal(18, 4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "NumberId",
                table: "SPNumberProcessSendReceiveReportModels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumberName",
                table: "SPNumberProcessSendReceiveReportModels",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberNo",
                table: "SPNumberProcessSendReceiveReportModels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "RejectionWeight",
                table: "SPNumberProcessSendReceiveReportModels",
                type: "decimal(18, 4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalWeight",
                table: "SPNumberProcessSendReceiveReportModels",
                type: "decimal(18, 4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EntryDate",
                table: "SPGalaProcessSendReceiveReportModels",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GalaName",
                table: "SPGalaProcessSendReceiveReportModels",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GalaNo",
                table: "SPGalaProcessSendReceiveReportModels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "GalaNumberId",
                table: "SPGalaProcessSendReceiveReportModels",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "LossWeight",
                table: "SPGalaProcessSendReceiveReportModels",
                type: "decimal(18, 4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "RejectionWeight",
                table: "SPGalaProcessSendReceiveReportModels",
                type: "decimal(18, 4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalWeight",
                table: "SPGalaProcessSendReceiveReportModels",
                type: "decimal(18, 4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EntryDate",
                table: "SPCharniSendReceiveReportModels",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CharniNo",
                table: "SPCharniSendReceiveReportModels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "LossWeight",
                table: "SPCharniSendReceiveReportModels",
                type: "decimal(18, 4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "RejectionWeight",
                table: "SPCharniSendReceiveReportModels",
                type: "decimal(18, 4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalWeight",
                table: "SPCharniSendReceiveReportModels",
                type: "decimal(18, 4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EntryDate",
                table: "SPBoilSendReceiveReportModels",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BoilNo",
                table: "SPBoilSendReceiveReportModels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "LossWeight",
                table: "SPBoilSendReceiveReportModels",
                type: "decimal(18, 4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "RejectionWeight",
                table: "SPBoilSendReceiveReportModels",
                type: "decimal(18, 4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalWeight",
                table: "SPBoilSendReceiveReportModels",
                type: "decimal(18, 4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EntryDate",
                table: "SPAccountToAssortSendReceiveReportModels",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "SPAccountToAssortSendReceiveReportModels",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EntryDate",
                table: "SPAccountToAssoftReceiveReportModel",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumberId",
                table: "SPAccountToAssoftReceiveReportModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumberName",
                table: "SPAccountToAssoftReceiveReportModel",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "JangadPrintDetailModel",
                columns: table => new
                {
                    SNo = table.Column<long>(nullable: false),
                    SrNo = table.Column<int>(nullable: false),
                    Date = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    GSTNo = table.Column<string>(nullable: true),
                    PartyName = table.Column<string>(nullable: true),
                    BrokerName = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    Rate = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    TotalCts = table.Column<decimal>(type: "decimal(18, 4)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "OpeningStockMaster",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SrNo = table.Column<int>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    BranchId = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    KapanId = table.Column<string>(nullable: true),
                    ShapeId = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    PurityId = table.Column<string>(nullable: true),
                    NmberId = table.Column<string>(nullable: true),
                    TotalCts = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpeningStockMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SPJangadSendReceiveReportModel",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: true),
                    Sr = table.Column<int>(nullable: false),
                    SrNo = table.Column<int>(nullable: false),
                    FinancialYearId = table.Column<string>(nullable: true),
                    PartyId = table.Column<string>(nullable: true),
                    PartyName = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    SizeName = table.Column<string>(nullable: true),
                    BrokerId = table.Column<string>(nullable: true),
                    BrokerName = table.Column<string>(nullable: true),
                    Totalcts = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SPStockReportModelReport",
                columns: table => new
                {
                    Type = table.Column<string>(nullable: true),
                    KapanId = table.Column<string>(nullable: true),
                    Kapan = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    GalaNumber = table.Column<string>(nullable: true),
                    NumberId = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    AvailableWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    TotalWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JangadPrintDetailModel");

            migrationBuilder.DropTable(
                name: "OpeningStockMaster");

            migrationBuilder.DropTable(
                name: "SPJangadSendReceiveReportModel");

            migrationBuilder.DropTable(
                name: "SPStockReportModelReport");

            migrationBuilder.DropColumn(
                name: "GalaName",
                table: "SPNumberProcessSendReceiveReportModels");

            migrationBuilder.DropColumn(
                name: "GalaNumberId",
                table: "SPNumberProcessSendReceiveReportModels");

            migrationBuilder.DropColumn(
                name: "LossWeight",
                table: "SPNumberProcessSendReceiveReportModels");

            migrationBuilder.DropColumn(
                name: "NumberId",
                table: "SPNumberProcessSendReceiveReportModels");

            migrationBuilder.DropColumn(
                name: "NumberName",
                table: "SPNumberProcessSendReceiveReportModels");

            migrationBuilder.DropColumn(
                name: "NumberNo",
                table: "SPNumberProcessSendReceiveReportModels");

            migrationBuilder.DropColumn(
                name: "RejectionWeight",
                table: "SPNumberProcessSendReceiveReportModels");

            migrationBuilder.DropColumn(
                name: "TotalWeight",
                table: "SPNumberProcessSendReceiveReportModels");

            migrationBuilder.DropColumn(
                name: "GalaName",
                table: "SPGalaProcessSendReceiveReportModels");

            migrationBuilder.DropColumn(
                name: "GalaNo",
                table: "SPGalaProcessSendReceiveReportModels");

            migrationBuilder.DropColumn(
                name: "GalaNumberId",
                table: "SPGalaProcessSendReceiveReportModels");

            migrationBuilder.DropColumn(
                name: "LossWeight",
                table: "SPGalaProcessSendReceiveReportModels");

            migrationBuilder.DropColumn(
                name: "RejectionWeight",
                table: "SPGalaProcessSendReceiveReportModels");

            migrationBuilder.DropColumn(
                name: "TotalWeight",
                table: "SPGalaProcessSendReceiveReportModels");

            migrationBuilder.DropColumn(
                name: "CharniNo",
                table: "SPCharniSendReceiveReportModels");

            migrationBuilder.DropColumn(
                name: "LossWeight",
                table: "SPCharniSendReceiveReportModels");

            migrationBuilder.DropColumn(
                name: "RejectionWeight",
                table: "SPCharniSendReceiveReportModels");

            migrationBuilder.DropColumn(
                name: "TotalWeight",
                table: "SPCharniSendReceiveReportModels");

            migrationBuilder.DropColumn(
                name: "BoilNo",
                table: "SPBoilSendReceiveReportModels");

            migrationBuilder.DropColumn(
                name: "LossWeight",
                table: "SPBoilSendReceiveReportModels");

            migrationBuilder.DropColumn(
                name: "RejectionWeight",
                table: "SPBoilSendReceiveReportModels");

            migrationBuilder.DropColumn(
                name: "TotalWeight",
                table: "SPBoilSendReceiveReportModels");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "SPAccountToAssortSendReceiveReportModels");

            migrationBuilder.DropColumn(
                name: "NumberId",
                table: "SPAccountToAssoftReceiveReportModel");

            migrationBuilder.DropColumn(
                name: "NumberName",
                table: "SPAccountToAssoftReceiveReportModel");

            migrationBuilder.AlterColumn<string>(
                name: "EntryDate",
                table: "SPNumberProcessSendReceiveReportModels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "SPNumberProcessSendReceiveReportModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "SPNumberProcessSendReceiveReportModels",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "SPNumberProcessSendReceiveReportModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sr",
                table: "SPNumberProcessSendReceiveReportModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "SPNumberProcessSendReceiveReportModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "SPNumberProcessSendReceiveReportModels",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EntryDate",
                table: "SPGalaProcessSendReceiveReportModels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "SPGalaProcessSendReceiveReportModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "SPGalaProcessSendReceiveReportModels",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "SPGalaProcessSendReceiveReportModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sr",
                table: "SPGalaProcessSendReceiveReportModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "SPGalaProcessSendReceiveReportModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "SPGalaProcessSendReceiveReportModels",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EntryDate",
                table: "SPCharniSendReceiveReportModels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "SPCharniSendReceiveReportModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "SPCharniSendReceiveReportModels",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "SPCharniSendReceiveReportModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sr",
                table: "SPCharniSendReceiveReportModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "SPCharniSendReceiveReportModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "SPCharniSendReceiveReportModels",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EntryDate",
                table: "SPBoilSendReceiveReportModels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "SPBoilSendReceiveReportModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "SPBoilSendReceiveReportModels",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "SPBoilSendReceiveReportModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sr",
                table: "SPBoilSendReceiveReportModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "SPBoilSendReceiveReportModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "SPBoilSendReceiveReportModels",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EntryDate",
                table: "SPAccountToAssortSendReceiveReportModels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EntryDate",
                table: "SPAccountToAssoftReceiveReportModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
