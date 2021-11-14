using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Entities.Model;
using Repository.Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

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
        public DbSet<LessWeightDetails> LessWeightDetails { get; set; }
        public DbSet<ShapeMaster> ShapeMaster { get; set; }
        public DbSet<SizeMaster> SizeMaster { get; set; }
        public DbSet<PurityMaster> PurityMaster { get; set; }
        public DbSet<GalaMaster> GalaMaster { get; set; }
        public DbSet<NumberMaster> NumberMaster { get; set; }
        public DbSet<BrokerageMaster> BrokerageMaster { get; set; }
        public DbSet<FinancialYearMaster> FinancialYearMaster { get; set; }
        public DbSet<PurchaseMaster> PurchaseMaster  { get; set; }
        public DbSet<PurchaseDetails> PurchaseDetails { get; set; }
        public DbSet<SalesMaster> SalesMaster { get; set; }
        public DbSet<SalesDetails> SalesDetails { get; set; }
        public DbSet<ExpenseMaster> ExpenseMaster { get; set; }
        public DbSet<ExpenseDetails> ExpenseDetails { get; set; }
        public DbSet<SalaryMaster> SalaryMaster { get; set; }
        public DbSet<SalaryDetail> SalaryDetails { get; set; }
        public DbSet<GroupPaymentMaster> GroupPaymentMaster { get; set; }
        public DbSet<PaymentMaster> PaymentMaster { get; set; }
        public DbSet<PaymentDetails> PaymentDetails { get; set; }
        public DbSet<ContraEntryMaster> ContraEntryMaster { get; set; }
        public DbSet<ContraEntryDetails> ContraEntryDetails { get; set; }
        public DbSet<SlipTransferEntry> SlipTransferEntry { get; set; }
        public DbSet<KapanMappingMaster> KapanMappingMaster { get; set; }        
        public DbSet<AccountToAssortMaster> AccountToAssortMaster { get; set; }
        public DbSet<AccountToAssortDetails> AccountToAssortDetails { get; set; }
        public DbSet<BoilProcessMaster> BoilProcessMaster { get; set; }
        public DbSet<CharniProcessMaster> CharniProcessMaster { get; set; }
        public DbSet<GalaProcessMaster> GalaProcessMaster { get; set; }
        public  DbSet<NumberProcessMaster> NumberProcessMaster { get; set; }

        public virtual DbSet<KapanMapping> SPKapanMapping { get; set; }

        public virtual DbSet<AssortmentProcessSend> SPAssortmentProcessSend { get; set; }
        public virtual DbSet<BoilProcessSend> SPBoilProcessSend { get; set; }
        public virtual DbSet<BoilProcessReceive> SPBoilProcessReceive { get; set; }
        public virtual DbSet<CharniProcessSend> SPCharniProcessSend { get; set; }
        public virtual DbSet<PaymentSPModel> SPPaymentModel { get; set; }
        public virtual DbSet<ContraSPModel> SPContraModel { get; set; }
        public virtual DbSet<CharniProcessReceive> SPCharniProcessReceive { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=103.83.81.7;Initial Catalog=karmajew_DiamondTrading;Persist Security Info=True;User ID=karmajew_DiamondTrading;Password=DT@123456;").EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<CompanyMaster>().Property(c => c.Sr).UseIdentityColumn();            
            modelBuilder.Entity<BranchMaster>().Property(c => c.Sr).UseIdentityColumn();
            modelBuilder.Entity<UserMaster>().Property(c => c.Sr).UseIdentityColumn();
            modelBuilder.Entity<PartyMaster>().Property(c => c.Sr).UseIdentityColumn();
            modelBuilder.Entity<ModuleMaster>().Property(c => c.Sr).UseIdentityColumn();
            modelBuilder.Entity<RoleMaster>().Property(c => c.Sr).UseIdentityColumn();
            modelBuilder.Entity<PermissionMaster>().Property(c => c.Sr).UseIdentityColumn();
            modelBuilder.Entity<RoleClaimMaster>().Property(c => c.Sr).UseIdentityColumn();
            modelBuilder.Entity<UserRoleMaster>().Property(c => c.Sr).UseIdentityColumn();
            modelBuilder.Entity<KapanMaster>().Property(c => c.Sr).UseIdentityColumn();
            modelBuilder.Entity<CurrencyMaster>().Property(c => c.Sr).UseIdentityColumn();
            modelBuilder.Entity<LessWeightMaster>().Property(c => c.Sr).UseIdentityColumn();
            modelBuilder.Entity<LessWeightDetails>().Property(c => c.Sr).UseIdentityColumn().Metadata.SetAfterSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);
            modelBuilder.Entity<ShapeMaster>().Property(c => c.Sr).UseIdentityColumn();
            modelBuilder.Entity<PurityMaster>().Property(c => c.Sr).UseIdentityColumn();
            modelBuilder.Entity<GalaMaster>().Property(c => c.Sr).UseIdentityColumn();
            modelBuilder.Entity<NumberMaster>().Property(c => c.Sr).UseIdentityColumn();
            modelBuilder.Entity<BrokerageMaster>().Property(c => c.Sr).UseIdentityColumn();
            modelBuilder.Entity<FinancialYearMaster>().Property(c => c.Sr).UseIdentityColumn();
            modelBuilder.Entity<PurchaseMaster>().Property(c => c.Sr).UseIdentityColumn();
            modelBuilder.Entity<PurchaseDetails>().Property(c => c.Sr).UseIdentityColumn();
            modelBuilder.Entity<ContraEntryMaster>().Property(c => c.Sr).UseIdentityColumn();
            modelBuilder.Entity<ContraEntryDetails>().Property(c => c.Sr).UseIdentityColumn();
            modelBuilder.Entity<SalesMaster>().Property(c => c.Sr).UseIdentityColumn();
            modelBuilder.Entity<SalesDetails>().Property(c => c.Sr).UseIdentityColumn();
            modelBuilder.Entity<ExpenseMaster>().Property(c => c.Sr).UseIdentityColumn();
            modelBuilder.Entity<ExpenseDetails>().Property(c => c.Sr).UseIdentityColumn();
            modelBuilder.Entity<SalaryMaster>().Property(c => c.Sr).UseIdentityColumn();
            modelBuilder.Entity<SalaryDetail>().Property(c => c.Sr).UseIdentityColumn();
            modelBuilder.Entity<GroupPaymentMaster>().Property(c => c.Sr).UseIdentityColumn();
            modelBuilder.Entity<PaymentMaster>().Property(c => c.Sr).UseIdentityColumn();
            modelBuilder.Entity<PaymentDetails>().Property(c => c.Sr).UseIdentityColumn();
            modelBuilder.Entity<SlipTransferEntry>().Property(c => c.Sr).UseIdentityColumn();
            modelBuilder.Entity<KapanMappingMaster>().Property(c => c.Sr).UseIdentityColumn();
            modelBuilder.Entity<BoilProcessMaster>().Property(c => c.Sr).UseIdentityColumn();
            modelBuilder.Entity<AccountToAssortMaster>().Property(c => c.Sr).UseIdentityColumn();
            modelBuilder.Entity<AccountToAssortDetails>().Property(c => c.Sr).UseIdentityColumn();
            modelBuilder.Entity<CharniProcessMaster>().Property(c => c.Sr).UseIdentityColumn();
            modelBuilder.Entity<GalaProcessMaster>().Property(c => c.Sr).UseIdentityColumn();
            modelBuilder.Entity<NumberProcessMaster>().Property(c => c.Sr).UseIdentityColumn();

            modelBuilder.Entity<KapanMapping>().HasNoKey();
            modelBuilder.Entity<AssortmentProcessSend>().HasNoKey();
            modelBuilder.Entity<BoilProcessSend>().HasNoKey();
            modelBuilder.Entity<BoilProcessReceive>().HasNoKey();
            modelBuilder.Entity<CharniProcessSend>().HasNoKey();
            modelBuilder.Entity<CharniProcessReceive>().HasNoKey();
        }
    }
}