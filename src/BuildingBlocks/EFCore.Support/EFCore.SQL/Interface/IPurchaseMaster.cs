using Repository.Entities;
using Repository.Entities.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface IPurchaseMaster
    {
        Task<List<PurchaseMaster>> GetAllPurchaseAsync(string companyId, string financialYearId);
        Task<List<PurchaseMaster>> GetAllPurchaseAsync(string companyId, DateTime startDate, DateTime endDate);
        Task<List<PurchaseMaster>> GetAllPurchaseAsync(string companyId, string branchId, string financialYearId);
        Task<List<PurchaseMaster>> GetAllPurchaseAsync(string companyId, string branchId, DateTime startDate, DateTime endDate);
        Task<PurchaseMaster> GetPurchaseAsync(string purchaseId);
        Task<List<PurchaseDetails>> GetPurchaseDetailAsync(string purchaseId);
        Task<List<PurchaseSPModel>> GetPurchaseReport(string companyId, string financialYearId, string currentWeek = null, string fromdate =null, string todate = null);
        Task<List<PurchaseSlipDetailsSPModel>> GetAvailableSlipDetailsReport(int ActionType, string companyId, string financialYearId);
        Task<List<SlipDetailPrintSPModel>> GetSlipDetails(int ActionType, string companyId, string SlipNo, string financialYearId);
        Task<PurchaseMaster> AddPurchaseAsync(PurchaseMaster purchaseMaster);
        Task<PurchaseMaster> UpdatePurchaseAsync(PurchaseMaster purchaseMaster);
        Task<bool> DeletePurchaseAsync(string purchaseId, bool isPermanantDetele = false);
        Task<long> GetMaxSlipNo(string branchId, string financialYearId);
        Task<long> GetMaxSrNo(string companyId, string financialYearId);

        Task<bool> UpdateApprovalStatus(string purchaseId, string message, int status);

        Task<List<PFReportSPModel>> GetPFReportAsync(string companyId, string financialYearId, int PFType);
        Task<List<WeeklyPurchaseReport>> GetWeeklyPurchaseReportAsync(string companyId, string financialYearId);
        List<PurchaseChildSPModel> GetPurchaseDetailsAsync(string purchaseId);
    }
}
