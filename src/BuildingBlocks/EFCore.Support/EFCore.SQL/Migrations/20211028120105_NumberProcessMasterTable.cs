using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class NumberProcessMasterTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoilMaster");

            migrationBuilder.CreateTable(
                name: "BoilProcessMaster",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoilNo = table.Column<int>(nullable: false),
                    JangadNo = table.Column<int>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    BranchId = table.Column<string>(nullable: true),
                    EntryDate = table.Column<DateTime>(nullable: true),
                    FinancialId = table.Column<string>(nullable: true),
                    BoilType = table.Column<int>(nullable: false),
                    KapanId = table.Column<string>(nullable: true),
                    ShapeId = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    LossWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    RejectionWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    HandOverById = table.Column<string>(nullable: true),
                    HandOverToId = table.Column<string>(nullable: true),
                    SlipNo = table.Column<string>(nullable: true),
                    BoilCategoy = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoilProcessMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NumberProcessMaster",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false),
                    NumberNo = table.Column<int>(nullable: false),
                    JangadNo = table.Column<int>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    BranchId = table.Column<string>(nullable: true),
                    EntryDate = table.Column<DateTime>(nullable: true),
                    FinancialId = table.Column<string>(nullable: true),
                    NumberProcessType = table.Column<int>(nullable: false),
                    KapanId = table.Column<string>(nullable: true),
                    ShapeId = table.Column<string>(nullable: true),
                    SizeId = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    GalaNumberId = table.Column<string>(nullable: true),
                    NumberId = table.Column<string>(nullable: true),
                    NumberWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    LossWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    RejectionWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    HandOverById = table.Column<string>(nullable: true),
                    HandOverToId = table.Column<string>(nullable: true),
                    SlipNo = table.Column<string>(nullable: true),
                    NumberCategoy = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumberProcessMaster", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoilProcessMaster");

            migrationBuilder.DropTable(
                name: "NumberProcessMaster");

            migrationBuilder.CreateTable(
                name: "BoilMaster",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BoilCategoy = table.Column<int>(type: "int", nullable: false),
                    BoilNo = table.Column<int>(type: "int", nullable: false),
                    BoilType = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinancialId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HandOverById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HandOverToId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    JangadNo = table.Column<int>(type: "int", nullable: false),
                    KapanId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LossWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    RejectionWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShapeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SizeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SlipNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sr = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoilMaster", x => x.Id);
                });
        }
    }
}
