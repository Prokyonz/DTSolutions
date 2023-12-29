using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class UserCompanyMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BoilSendId",
                table: "SPBoilSendReceiveReportModels",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SPValidationModel",
                columns: table => new
                {
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "UserCompanyMappings",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    CompanyId = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UserMasterId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCompanyMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCompanyMappings_UserMaster_UserMasterId",
                        column: x => x.UserMasterId,
                        principalTable: "UserMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCompanyMappings_UserMasterId",
                table: "UserCompanyMappings",
                column: "UserMasterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SPValidationModel");

            migrationBuilder.DropTable(
                name: "UserCompanyMappings");

            migrationBuilder.DropColumn(
                name: "BoilSendId",
                table: "SPBoilSendReceiveReportModels");
        }
    }
}
