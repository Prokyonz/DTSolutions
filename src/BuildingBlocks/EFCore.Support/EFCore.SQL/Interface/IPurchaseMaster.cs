using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface IPurchaseMaster
    {
        Task<List<PurchaseMaster>> GetAllPurchaseAsync(Guid companyId, Guid financialYearId);
        Task<List<PurchaseMaster>> GetAllPurchaseAsync(Guid companyId, DateTime startDate, DateTime endDate);
        Task<List<PurchaseMaster>> GetAllPurchaseAsync(Guid companyId, Guid branchId, Guid financialYearId);
        Task<List<PurchaseMaster>> GetAllSalesAsync(Guid companyId, Guid branchId, DateTime startDate, DateTime endDate);
        Task<PurchaseMaster> AddPurchaseAsync(PurchaseMaster purchaseMaster);
        Task<PurchaseMaster> UpdatePurchaseAsync(PurchaseMaster purchaseMaster);
        Task<bool> DeletePurchaseAsync(Guid purchaseId, bool isPermanantDetele = false);
    }
}
