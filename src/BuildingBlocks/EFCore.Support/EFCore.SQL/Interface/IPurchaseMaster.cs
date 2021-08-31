using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface IPurchaseMaster
    {
        Task<List<PurchaseMaster>> GetAllPurchaseAsync(Guid companyId, Guid financialYearId);
        Task<List<PurchaseMaster>> GetAllPurchaseAsync(Guid companyId, Guid branchId, Guid financialYearId);
        Task<PurchaseMaster> AddPurchaseAsync(PurchaseMaster purchaseMaster);
        Task<PurchaseMaster> UpdatePurchaseAsync(PurchaseMaster purchaseMaster);
        Task<bool> DeletePurchaseAsync(Guid purchaseId, bool isPermanantDetele = false);
    }
}
