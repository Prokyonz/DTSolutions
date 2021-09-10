using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class RemoveLessWeightIdFromBranchMaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LessWeightId",
                table: "BranchMaster");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LessWeightId",
                table: "BranchMaster",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
