using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class LessWeightColInRejection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "SPStockReportModelReport",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "SPNumberkReportModelReport",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "LessWeight",
                table: "RejectionInOutMaster",
                type: "decimal(18, 4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "SPPartyMaster",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    BrokerageId = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    SubType = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(nullable: true),
                    EmailId = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    MobileNo = table.Column<string>(nullable: true),
                    OfficeNo = table.Column<string>(nullable: true),
                    GSTNo = table.Column<string>(nullable: true),
                    AadharCardNo = table.Column<string>(nullable: true),
                    PancardNo = table.Column<string>(nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    OpeningBalance = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    CRDRType = table.Column<int>(nullable: false),
                    TypeName = table.Column<string>(nullable: true),
                    SubTypeName = table.Column<string>(nullable: true),
                    Balance = table.Column<decimal>(type: "decimal(18, 4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SPPartyMaster", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SPPartyMaster");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "SPStockReportModelReport");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "SPNumberkReportModelReport");

            migrationBuilder.DropColumn(
                name: "LessWeight",
                table: "RejectionInOutMaster");
        }
    }
}
