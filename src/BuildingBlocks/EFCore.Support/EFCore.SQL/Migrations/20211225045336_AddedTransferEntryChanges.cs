using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class AddedTransferEntryChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BranchName",
                table: "SPExpenseModel",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TransferCaratRate",
                table: "NumberProcessMaster",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "TransferEntryId",
                table: "NumberProcessMaster",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransferId",
                table: "NumberProcessMaster",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransferType",
                table: "NumberProcessMaster",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TransferCaratRate",
                table: "GalaProcessMaster",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "TransferEntryId",
                table: "GalaProcessMaster",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransferId",
                table: "GalaProcessMaster",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransferType",
                table: "GalaProcessMaster",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TransferCaratRate",
                table: "CharniProcessMaster",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "TransferEntryId",
                table: "CharniProcessMaster",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransferId",
                table: "CharniProcessMaster",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransferType",
                table: "CharniProcessMaster",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TransferCaratRate",
                table: "BoilProcessMaster",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "TransferEntryId",
                table: "BoilProcessMaster",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransferId",
                table: "BoilProcessMaster",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransferType",
                table: "BoilProcessMaster",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CaratCategoryType",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "TransferMaster",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JangadNo = table.Column<int>(nullable: false),
                    Date = table.Column<string>(nullable: true),
                    Time = table.Column<string>(nullable: true),
                    TRansferById = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    CompanyId = table.Column<string>(nullable: true),
                    FinancialYearId = table.Column<string>(nullable: true),
                    Image1 = table.Column<byte[]>(nullable: true),
                    Image2 = table.Column<byte[]>(nullable: true),
                    Image3 = table.Column<byte[]>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferMaster", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaratCategoryType");

            migrationBuilder.DropTable(
                name: "TransferMaster");

            migrationBuilder.DropColumn(
                name: "BranchName",
                table: "SPExpenseModel");

            migrationBuilder.DropColumn(
                name: "TransferCaratRate",
                table: "NumberProcessMaster");

            migrationBuilder.DropColumn(
                name: "TransferEntryId",
                table: "NumberProcessMaster");

            migrationBuilder.DropColumn(
                name: "TransferId",
                table: "NumberProcessMaster");

            migrationBuilder.DropColumn(
                name: "TransferType",
                table: "NumberProcessMaster");

            migrationBuilder.DropColumn(
                name: "TransferCaratRate",
                table: "GalaProcessMaster");

            migrationBuilder.DropColumn(
                name: "TransferEntryId",
                table: "GalaProcessMaster");

            migrationBuilder.DropColumn(
                name: "TransferId",
                table: "GalaProcessMaster");

            migrationBuilder.DropColumn(
                name: "TransferType",
                table: "GalaProcessMaster");

            migrationBuilder.DropColumn(
                name: "TransferCaratRate",
                table: "CharniProcessMaster");

            migrationBuilder.DropColumn(
                name: "TransferEntryId",
                table: "CharniProcessMaster");

            migrationBuilder.DropColumn(
                name: "TransferId",
                table: "CharniProcessMaster");

            migrationBuilder.DropColumn(
                name: "TransferType",
                table: "CharniProcessMaster");

            migrationBuilder.DropColumn(
                name: "TransferCaratRate",
                table: "BoilProcessMaster");

            migrationBuilder.DropColumn(
                name: "TransferEntryId",
                table: "BoilProcessMaster");

            migrationBuilder.DropColumn(
                name: "TransferId",
                table: "BoilProcessMaster");

            migrationBuilder.DropColumn(
                name: "TransferType",
                table: "BoilProcessMaster");
        }
    }
}
