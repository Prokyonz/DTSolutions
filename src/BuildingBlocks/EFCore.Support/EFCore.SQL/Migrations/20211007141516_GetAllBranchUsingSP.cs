using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.SQL.Migrations
{
    public partial class GetAllBranchUsingSP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"
                                    GO
                                    CREATE PROCEDURE GetBranchMasterRecords 
	                                    @firstName varchar(100), 
	                                    @lastName int
                                    AS
                                    BEGIN
                                        SELECT * from BranchMaster
                                    END";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"DROP PROCEDURE GetBranchMasterRecords";
            migrationBuilder.Sql(procedure);
        }
    }
}
