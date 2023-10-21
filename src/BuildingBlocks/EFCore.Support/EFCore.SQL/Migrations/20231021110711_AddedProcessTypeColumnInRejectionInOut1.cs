using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class AddedProcessTypeColumnInRejectionInOut1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SlipNo",
                table: "SPRejectionSendReceiveModel",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<string>(
                name: "ProcessType",
                table: "SPRejectionSendReceiveModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KapanId",
                table: "RejectionInOutMaster",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProcessType",
                table: "SPRejectionSendReceiveModel");

            migrationBuilder.DropColumn(
                name: "KapanId",
                table: "RejectionInOutMaster");

            migrationBuilder.AlterColumn<long>(
                name: "SlipNo",
                table: "SPRejectionSendReceiveModel",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
