using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class RemoveExtraUserIdCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCompanyMappings_UserMaster_UserMasterId",
                table: "UserCompanyMappings");

            migrationBuilder.DropIndex(
                name: "IX_UserCompanyMappings_UserMasterId",
                table: "UserCompanyMappings");

            migrationBuilder.DropColumn(
                name: "UserMasterId",
                table: "UserCompanyMappings");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserCompanyMappings",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserCompanyMappings_UserId",
                table: "UserCompanyMappings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompanyMappings_UserMaster_UserId",
                table: "UserCompanyMappings",
                column: "UserId",
                principalTable: "UserMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCompanyMappings_UserMaster_UserId",
                table: "UserCompanyMappings");

            migrationBuilder.DropIndex(
                name: "IX_UserCompanyMappings_UserId",
                table: "UserCompanyMappings");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserCompanyMappings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserMasterId",
                table: "UserCompanyMappings",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserCompanyMappings_UserMasterId",
                table: "UserCompanyMappings",
                column: "UserMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompanyMappings_UserMaster_UserMasterId",
                table: "UserCompanyMappings",
                column: "UserMasterId",
                principalTable: "UserMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
