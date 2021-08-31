using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class AddPurchaseDetailsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PurchaseDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Sr = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KapanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShapeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SizeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PurityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    TIPWeight = table.Column<float>(type: "real", nullable: false),
                    CVDWeight = table.Column<float>(type: "real", nullable: false),
                    RejectedPercentage = table.Column<float>(type: "real", nullable: false),
                    RejectedWeight = table.Column<float>(type: "real", nullable: false),
                    LessWeight = table.Column<float>(type: "real", nullable: false),
                    LessDiscountPercentage = table.Column<float>(type: "real", nullable: false),
                    LessWeightDiscount = table.Column<float>(type: "real", nullable: false),
                    NetWeight = table.Column<float>(type: "real", nullable: false),
                    BuyingRate = table.Column<double>(type: "float", nullable: false),
                    CVDCharge = table.Column<double>(type: "float", nullable: false),
                    CVDAmount = table.Column<double>(type: "float", nullable: false),
                    RoundUpAmount = table.Column<double>(type: "float", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    IsTransfer = table.Column<bool>(type: "bit", nullable: false),
                    TransferParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseDetails_PurchaseMaster_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "PurchaseMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetails_PurchaseId",
                table: "PurchaseDetails",
                column: "PurchaseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseDetails");
        }
    }
}
