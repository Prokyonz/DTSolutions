using Microsoft.EntityFrameworkCore;
using Repository.Entities;

namespace EFCore.SQL.DBContext
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext()
        {

        }

        public DbSet<CompanyMaster> CompanyMaster { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=abedre;Initial Catalog=DTSolution;Persist Security Info=True;User ID=sa;Password=Sql@007;").EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<CompanyMaster>().Property(c => c.Id).UseIdentityColumn();
            modelBuilder.Entity<BranchMaster>().Property(c => c.Id).UseIdentityColumn();
        }
    }
}
