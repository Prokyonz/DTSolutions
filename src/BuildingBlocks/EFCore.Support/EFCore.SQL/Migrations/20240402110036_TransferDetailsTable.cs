using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class TransferDetailsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransferDetails",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransferMasterId = table.Column<string>(nullable: true),
                    FromCategory = table.Column<string>(nullable: true),
                    BranchId = table.Column<string>(nullable: true),
                    ShapeId = table.Column<string>(nullable: true),
                    Carat = table.Column<decimal>(nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    ToCategory = table.Column<string>(nullable: true),
                    ToSizeId = table.Column<string>(nullable: true),
                    ToBranchId = table.Column<string>(nullable: true),
                    ToNumberIdORKapanId = table.Column<string>(nullable: true),
                    ToCarat = table.Column<decimal>(nullable: false),
                    ToRate = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    ToAmount = table.Column<double>(nullable: false),
                    Date = table.Column<string>(nullable: true),
                    Time = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferDetails", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransferDetails");
        }
    }
}
