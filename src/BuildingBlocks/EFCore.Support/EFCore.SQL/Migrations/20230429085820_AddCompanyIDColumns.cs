using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class AddCompanyIDColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "KapanMaster",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "CurrencyMaster",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "BrokerageMaster",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "KapanMaster");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "CurrencyMaster");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "BrokerageMaster");
        }
    }
}
