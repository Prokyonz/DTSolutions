using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class UpdateLessWeightMasterAndDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LessWeight",
                table: "LessWeightMasters");

            migrationBuilder.DropColumn(
                name: "MaxWeight",
                table: "LessWeightMasters");

            migrationBuilder.DropColumn(
                name: "MinWeight",
                table: "LessWeightMasters");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "LessWeightMasters",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "LessWeightMasters",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "LessWeightMasters",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "LessWeightMasters",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "LessWeightMasters",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LessWeightDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Sr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessWeightId = table.Column<Guid>(nullable: false),
                    MinWeight = table.Column<float>(nullable: false),
                    MaxWeight = table.Column<float>(nullable: false),
                    LessWeight = table.Column<float>(nullable: false),
                    LessWeightMasterId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessWeightDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessWeightDetails_LessWeightMasters_LessWeightMasterId",
                        column: x => x.LessWeightMasterId,
                        principalTable: "LessWeightMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LessWeightDetails_LessWeightMasterId",
                table: "LessWeightDetails",
                column: "LessWeightMasterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LessWeightDetails");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "LessWeightMasters");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "LessWeightMasters");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "LessWeightMasters");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "LessWeightMasters");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "LessWeightMasters");

            migrationBuilder.AddColumn<float>(
                name: "LessWeight",
                table: "LessWeightMasters",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "MaxWeight",
                table: "LessWeightMasters",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "MinWeight",
                table: "LessWeightMasters",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
