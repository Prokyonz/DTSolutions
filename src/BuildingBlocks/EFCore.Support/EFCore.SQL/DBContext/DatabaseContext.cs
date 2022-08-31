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
        //public DbSet<ModuleMaster> ModuleMaster { get; set; }
        //public DbSet<RoleMaster> RoleMaster { get; set; }
        //public DbSet<PermissionMaster> PermissionMaster { get; set; }
        //public DbSet<RoleClaimMaster> RoleClaimMaster { get; set; }
        //public DbSet<UserRoleMaster> UserRoleMaster { get; set; }
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
        public DbSet<TransferMaster> TransferMaster { get; set; }
        public DbSet<LoanMaster> LoanMaster { get; set; }
        public DbSet<PermissionMaster> PermissionMaster { get; set; }
        public DbSet<UserPermissionChild> UserPermissionChild { get; set; }
        public DbSet<ApprovalPermissionMaster> ApprovalPermissionMaster { get; set; }
        public DbSet<JangadMaster> JangadMaster { get; set; }
        public DbSet<PriceMaster> PriceMaster { get; set; }
        public DbSet<RejectionInOutMaster> RejectionInOutMaster { get; set; }
        public DbSet<OpeningStockMaster> OpeningStockMaster { get; set; }
        public DbSet<LedgerBalanceManager> LedgerBalanceManager { get; set; }




        public virtual DbSet<PriceSPModel> PriceSPModel { get; set; }
        public virtual DbSet<JangadSPReceiveModel> JangadSPReceiveModel { get; set; }
        public virtual DbSet<JangadPrintDetailModel> JangadPrintDetailModel { get; set; }
        public virtual DbSet<KapanMapping> SPKapanMapping { get; set; }
        public virtual DbSet<AssortmentProcessSend> SPAssortmentProcessSend { get; set; }
        public virtual DbSet<BoilProcessSend> SPBoilProcessSend { get; set; }
        public virtual DbSet<BoilProcessReceive> SPBoilProcessReceive { get; set; }
        public virtual DbSet<CharniProcessSend> SPCharniProcessSend { get; set; }
        public virtual DbSet<PaymentSPModel> SPPaymentModel { get; set; }
        public virtual DbSet<ContraSPModel> SPContraModel { get; set; }
        public virtual DbSet<CharniProcessReceive> SPCharniProcessReceive { get; set; }
        public virtual DbSet<GalaProcessSend> SPGalaProcessSend { get; set; }
        public virtual DbSet<GalaProcessReceive> SPGalaProcessReceive { get; set; }
        public virtual DbSet<NumberProcessSend> SPNumberProcessSend { get; set; }
        public virtual DbSet<NumberProcessReturn> SPNumberProcessReturn { get; set; }
        public virtual DbSet<NumberProcessReceive> SPNumberProcessReceive { get; set; }
        public virtual DbSet<PurchaseSPModel> SPPurchaseModel { get; set; }
        public virtual DbSet<PurchaseSlipDetailsSPModel> SPPurchaseSlipDetailsModel { get; set; }
        public virtual DbSet<SlipDetailPrintSPModel> SPSlipDetailPrintModel { get; set; }
        public virtual DbSet<KapanLagadReportSPModel> SPKapanLagadReportModel { get; set; }
        public virtual DbSet<SalesSPModel> SPSalesModel { get; set; }
        public virtual DbSet<ExpenseSPModel> SPExpenseModel { get; set; }
        public virtual DbSet<LoanSPModel> SPLoanReportModel { get; set; }
        public virtual DbSet<MixedSPModel> SPMixedReportModel { get; set; }
        public virtual DbSet<SalesItemDetails> SalesItemDetails { get; set; }
        public virtual DbSet<CaratCategoryType> CaratCategoryType { get; set; }
        public virtual DbSet<PaymentPSSlipDetails> SPPaymentPSSlipDetails { get; set; }
        public virtual DbSet<KapanMappingReportModel> SPKapanMappingReportModel { get; set; }
        public virtual DbSet<AccountToAssortSendReceiveReportModel> SPAccountToAssortSendReceiveReportModels  { get; set; }
        public virtual DbSet<AccountToAssoftReceiveReportModel> SPAccountToAssoftReceiveReportModel { get; set; }
        public virtual DbSet<BoilSendReceiveReportModel> SPBoilSendReceiveReportModels { get; set; }
        public virtual DbSet<CharniSendReceiveReportModel> SPCharniSendReceiveReportModels { get; set; }
        public virtual DbSet<GalaProcessSendReceiveReportModel> SPGalaProcessSendReceiveReportModels { get; set; }
        public virtual DbSet<NumberProcessSendReceiveReportModel> SPNumberProcessSendReceiveReportModels { get; set; }
        public virtual DbSet<JangadSPReportModel> SPJangadSendReceiveReportModel { get; set; }
        public virtual DbSet<StockReportModelReport> SPStockReportModelReport  { get; set; }
        public virtual DbSet<OpeningStockSPModel> SPOpeningStockSPModel { get; set; }
        public virtual DbSet<PFReportSPModel> SPPFReportModels { get; set; }
        public virtual DbSet<WeeklyPurchaseReport> SPWeeklyPurchaseReport { get; set; }
        public virtual DbSet<LedgerBalanceSPModel> SPLedgerBalanceReport { get; set; }

        public virtual DbSet<TransferCategoryList> SPTransferCategoryList { get; set; }
        public virtual DbSet<PayableReceivableSPModel> SPPayableReceivableReport { get; set; }
        public virtual DbSet<BalanceSheetSPModel> SPBalanceSheetReport { get; set; }
        public virtual DbSet<ProfitLossSPModel> SPProfitLossReport { get; set; }
        public virtual DbSet<SalesChildSPModel> SPSalesChildReport { get; set; }
        public virtual DbSet<PurchaseChildSPModel> SPPurchaseChildReport { get; set; }
        public virtual DbSet<CashBankSPReport> SPCashBankReport { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=103.83.81.7;Initial Catalog=karmajew_DiamondTrading;Persist Security Info=True;User ID=karmajew_DiamondTrading;Password=DT@123456;").EnableSensitiveDataLogging();
            optionsBuilder.UseSqlServer("Data Source=103.83.81.7;Initial Catalog=karmajew_DiamondTradingLive;Persist Security Info=True;User ID=karmajew_DiamondTrading;Password=DT@123456;").EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<CompanyMaster>().Property(c => c.Sr).UseIdentityColumn();            
            modelBuilder.Entity<BranchMaster>().Property(c => c.Sr).UseIdentityColumn();
            modelBuilder.Entity<UserMaster>().Property(c => c.Sr).UseIdentityColumn();
            modelBuilder.Entity<PartyMaster>().Property(c => c.Sr).UseIdentityColumn();
            //modelBuilder.Entity<ModuleMaster>().Property(c => c.Sr).UseIdentityColumn();
            //modelBuilder.Entity<RoleMaster>().Property(c => c.Sr).UseIdentityColumn();
            modelBuilder.Entity<PermissionMaster>().Property(c => c.Sr).UseIdentityColumn();
            //modelBuilder.Entity<RoleClaimMaster>().Property(c => c.Sr).UseIdentityColumn();
            //modelBuilder.Entity<UserRoleMaster>().Property(c => c.Sr).UseIdentityColumn();
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
            modelBuilder.Entity<TransferMaster>().Property(c => c.Sr).UseIdentityColumn();
            modelBuilder.Entity<LoanMaster>().Property(c => c.Sr).UseIdentityColumn();
            modelBuilder.Entity<UserPermissionChild>().Property(c => c.Sr).UseIdentityColumn();
            modelBuilder.Entity<ApprovalPermissionMaster>().Property(c => c.Sr).UseIdentityColumn();
            modelBuilder.Entity<JangadMaster>().Property(c => c.Sr).UseIdentityColumn();
            modelBuilder.Entity<PriceMaster>().Property(c => c.Sr).UseIdentityColumn();
            modelBuilder.Entity<RejectionInOutMaster>().Property(c => c.Sr).UseIdentityColumn();
            modelBuilder.Entity<OpeningStockMaster>().Property(c => c.Sr).UseIdentityColumn();
            modelBuilder.Entity<LedgerBalanceManager>().Property(c => c.Sr).UseIdentityColumn();


            modelBuilder.Entity<KapanMapping>().HasNoKey();
            modelBuilder.Entity<AssortmentProcessSend>().HasNoKey();
            modelBuilder.Entity<BoilProcessSend>().HasNoKey();
            modelBuilder.Entity<BoilProcessReceive>().HasNoKey();
            modelBuilder.Entity<CharniProcessSend>().HasNoKey();
            modelBuilder.Entity<CharniProcessReceive>().HasNoKey();
            modelBuilder.Entity<GalaProcessSend>().HasNoKey();
            modelBuilder.Entity<GalaProcessReceive>().HasNoKey();
            modelBuilder.Entity<NumberProcessSend>().HasNoKey();
            modelBuilder.Entity<NumberProcessReturn>().HasNoKey();
            modelBuilder.Entity<NumberProcessReceive>().HasNoKey();
            modelBuilder.Entity<ExpenseSPModel>().HasNoKey();
            modelBuilder.Entity<SalesItemDetails>().HasNoKey();
            modelBuilder.Entity<LoanSPModel>().HasNoKey();
            modelBuilder.Entity<CaratCategoryType>().HasNoKey();
            modelBuilder.Entity<PaymentPSSlipDetails>().HasNoKey();
            modelBuilder.Entity<KapanMappingReportModel>().HasNoKey();
            modelBuilder.Entity<AccountToAssortSendReceiveReportModel>().HasNoKey();
            modelBuilder.Entity<AccountToAssoftReceiveReportModel>().HasNoKey();
            modelBuilder.Entity<BoilSendReceiveReportModel>().HasNoKey();
            modelBuilder.Entity<CharniSendReceiveReportModel>().HasNoKey();
            modelBuilder.Entity<PriceSPModel>().HasNoKey();
            modelBuilder.Entity<JangadSPReceiveModel>().HasNoKey();
            modelBuilder.Entity<JangadPrintDetailModel>().HasNoKey();
            modelBuilder.Entity<GalaProcessSendReceiveReportModel>().HasNoKey();
            modelBuilder.Entity<NumberProcessSendReceiveReportModel>().HasNoKey();
            modelBuilder.Entity<JangadSPReportModel>().HasNoKey();
            modelBuilder.Entity<StockReportModelReport>().HasNoKey();
            modelBuilder.Entity<PFReportSPModel>().HasNoKey();
            modelBuilder.Entity<LedgerBalanceSPModel>().HasNoKey();
            modelBuilder.Entity<TransferCategoryList>().HasNoKey();
            modelBuilder.Entity<WeeklyPurchaseReport>().HasNoKey();
            modelBuilder.Entity<PayableReceivableSPModel>().HasNoKey();
            modelBuilder.Entity<BalanceSheetSPModel>().HasNoKey();
            modelBuilder.Entity<ProfitLossSPModel>().HasNoKey();
            modelBuilder.Entity<KapanLagadReportSPModel>().HasNoKey();
            modelBuilder.Entity<SalesChildSPModel>().HasNoKey();
            modelBuilder.Entity<PurchaseChildSPModel>().HasNoKey();
            modelBuilder.Entity<CashBankSPReport>().HasNoKey();
        }
    }
}