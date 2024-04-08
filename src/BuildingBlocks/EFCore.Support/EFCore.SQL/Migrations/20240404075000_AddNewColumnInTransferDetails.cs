using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class AddNewColumnInTransferDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TransferMasterId",
                table: "TransferDetails",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FromNumberIdORKapanId",
                table: "TransferDetails",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransferDetails_TransferMasterId",
                table: "TransferDetails",
                column: "TransferMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransferDetails_TransferMaster_TransferMasterId",
                table: "TransferDetails",
                column: "TransferMasterId",
                principalTable: "TransferMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransferDetails_TransferMaster_TransferMasterId",
                table: "TransferDetails");

            migrationBuilder.DropIndex(
                name: "IX_TransferDetails_TransferMasterId",
                table: "TransferDetails");

            migrationBuilder.DropColumn(
                name: "FromNumberIdORKapanId",
                table: "TransferDetails");

            migrationBuilder.AlterColumn<string>(
                name: "TransferMasterId",
                table: "TransferDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
