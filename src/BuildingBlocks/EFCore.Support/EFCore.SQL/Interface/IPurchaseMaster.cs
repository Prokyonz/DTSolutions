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
        Task<List<PurchaseSPModel>> GetPurchaseReport(string companyId, string financialYearId);
        Task<PurchaseMaster> AddPurchaseAsync(PurchaseMaster purchaseMaster);
        Task<PurchaseMaster> UpdatePurchaseAsync(PurchaseMaster purchaseMaster);
        Task<bool> DeletePurchaseAsync(string purchaseId, bool isPermanantDetele = false);
        Task<long> GetMaxSlipNo(string branchId, string financialYearId);
        Task<long> GetMaxSrNo(string companyId, string financialYearId);
    }
}
