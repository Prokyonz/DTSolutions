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
        public DbSet<BranchMaster> BranchMaster { get; set; }
        public DbSet<UserMaster> UserMaster { get; set; }
        public DbSet<PartyMaster> PartyMaster { get; set; }
        public DbSet<ModuleMaster> ModuleMaster { get; set; }
        public DbSet<RoleMaster> RoleMaster { get; set; }
        public DbSet<PermissionMaster> PermissionMaster { get; set; }
        public DbSet<RoleClaimMaster> RoleClaimMaster { get; set; }
        public DbSet<UserRoleMaster> UserRoleMaster { get; set; }
        public DbSet<KapanMaster> KapanMaster { get; set; }
        public DbSet<CurrencyMaster> CurrencyMaster{ get; set; }
        public DbSet<LessWeightMaster> LessWeightMasters { get; set; }
        public DbSet<ShapeMaster> ShapeMaster { get; set; }
        public DbSet<SizeMaster> SizeMaster { get; set; }
        public DbSet<PurityMaster> PurityMaster { get; set; }
        public DbSet<GalaMaster> GalaMaster { get; set; }
        public DbSet<NumberMaster> NumberMaster { get; set; }
        public DbSet<BrokerageMaster> BrokerageMaster { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=abedre;Initial Catalog=DTSolution;Persist Security Info=True;User ID=sa;Password=Sql@007;").EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<CompanyMaster>().Property(c => c.Id).UseIdentityColumn();
            modelBuilder.Entity<BranchMaster>().Property(c => c.Id).UseIdentityColumn();
            modelBuilder.Entity<UserMaster>().Property(c => c.Id).UseIdentityColumn();
            modelBuilder.Entity<PartyMaster>().Property(c => c.Id).UseIdentityColumn();
            modelBuilder.Entity<ModuleMaster>().Property(c => c.Id).UseIdentityColumn();
            modelBuilder.Entity<RoleMaster>().Property(c => c.Id).UseIdentityColumn();
            modelBuilder.Entity<PermissionMaster>().Property(c => c.Id).UseIdentityColumn();
            modelBuilder.Entity<RoleClaimMaster>().Property(c => c.Id).UseIdentityColumn();
            modelBuilder.Entity<UserRoleMaster>().Property(c => c.Id).UseIdentityColumn();
            modelBuilder.Entity<KapanMaster>().Property(c => c.Id).UseIdentityColumn();
            modelBuilder.Entity<CurrencyMaster>().Property(c => c.Id).UseIdentityColumn();
            modelBuilder.Entity<LessWeightMaster>().Property(c => c.Id).UseIdentityColumn();
            modelBuilder.Entity<ShapeMaster>().Property(c => c.Id).UseIdentityColumn();
            modelBuilder.Entity<GalaMaster>().Property(c => c.Id).UseIdentityColumn();
            modelBuilder.Entity<NumberMaster>().Property(c => c.Id).UseIdentityColumn();
            modelBuilder.Entity<BrokerageMaster>().Property(c => c.Id).UseIdentityColumn();

        }
    }
}
