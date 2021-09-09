using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class AddedSalesDetailsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SalesDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesId = table.Column<Guid>(nullable: false),
                    KapanId = table.Column<Guid>(nullable: false),
                    ShapeId = table.Column<Guid>(nullable: false),
                    SizeId = table.Column<Guid>(nullable: false),
                    PurityId = table.Column<Guid>(nullable: false),
                    Weight = table.Column<float>(nullable: false),
                    TIPWeight = table.Column<float>(nullable: false),
                    CVDWeight = table.Column<float>(nullable: false),
                    RejectedPercentage = table.Column<float>(nullable: false),
                    RejectedWeight = table.Column<float>(nullable: false),
                    LessWeight = table.Column<float>(nullable: false),
                    LessDiscountPercentage = table.Column<float>(nullable: false),
                    LessWeightDiscount = table.Column<float>(nullable: false),
                    NetWeight = table.Column<float>(nullable: false),
                    SaleRate = table.Column<double>(nullable: false),
                    CVDCharge = table.Column<double>(nullable: false),
                    CVDAmount = table.Column<double>(nullable: false),
                    RoundUpAmount = table.Column<double>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    FromCategory = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    SalesMasterId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesDetails_PurchaseMaster_SalesId",
                        column: x => x.SalesId,
                        principalTable: "PurchaseMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesDetails_SalesMaster_SalesMasterId",
                        column: x => x.SalesMasterId,
                        principalTable: "SalesMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalesDetails_SalesId",
                table: "SalesDetails",
                column: "SalesId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesDetails_SalesMasterId",
                table: "SalesDetails",
                column: "SalesMasterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesDetails");
        }
    }
}
