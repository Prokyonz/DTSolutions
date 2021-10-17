using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class UpdateSlipTransferEntryFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SlipTransferEntry_PurchaseMasterId",
                table: "SlipTransferEntry",
                column: "PurchaseMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_SlipTransferEntry_PurchaseMaster_PurchaseMasterId",
                table: "SlipTransferEntry",
                column: "PurchaseMasterId",
                principalTable: "PurchaseMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SlipTransferEntry_PurchaseMaster_PurchaseMasterId",
                table: "SlipTransferEntry");

            migrationBuilder.DropIndex(
                name: "IX_SlipTransferEntry_PurchaseMasterId",
                table: "SlipTransferEntry");
        }
    }
}
