using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class AddPurchaseSaleDetailsIdColumnInRejection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BrokerageId",
                table: "SPRejectionSendReceiveModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumberId",
                table: "SPRejectionSendReceiveModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PartyId",
                table: "SPRejectionSendReceiveModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PurchaseSaleDetailsId",
                table: "SPRejectionSendReceiveModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DurationName",
                table: "SPLoanReportModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PurchaseSaleDetailsId",
                table: "RejectionInOutMaster",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SPDashboardModel",
                columns: table => new
                {
                    TotalAmount = table.Column<double>(type: "number(18, 2)", nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SPDashboardModel");

            migrationBuilder.DropColumn(
                name: "BrokerageId",
                table: "SPRejectionSendReceiveModel");

            migrationBuilder.DropColumn(
                name: "NumberId",
                table: "SPRejectionSendReceiveModel");

            migrationBuilder.DropColumn(
                name: "PartyId",
                table: "SPRejectionSendReceiveModel");

            migrationBuilder.DropColumn(
                name: "PurchaseSaleDetailsId",
                table: "SPRejectionSendReceiveModel");

            migrationBuilder.DropColumn(
                name: "DurationName",
                table: "SPLoanReportModel");

            migrationBuilder.DropColumn(
                name: "PurchaseSaleDetailsId",
                table: "RejectionInOutMaster");
        }
    }
}
