using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class AdduserPermissionDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UserPermissionDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserMasterId",
                table: "UserPermissionDetail",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserPermissionDetail_UserMasterId",
                table: "UserPermissionDetail",
                column: "UserMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPermissionDetail_UserMaster_UserMasterId",
                table: "UserPermissionDetail",
                column: "UserMasterId",
                principalTable: "UserMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPermissionDetail_UserMaster_UserMasterId",
                table: "UserPermissionDetail");

            migrationBuilder.DropIndex(
                name: "IX_UserPermissionDetail_UserMasterId",
                table: "UserPermissionDetail");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserPermissionDetail");

            migrationBuilder.DropColumn(
                name: "UserMasterId",
                table: "UserPermissionDetail");
        }
    }
}
