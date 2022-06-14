using Repository.Entities;
using Repository.Entities.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface ITransferMaster
    {
        Task<List<TransferMaster>> GetAllTransferAsync();
        Task<TransferMaster> AddTransferAsync(TransferMaster transferMaster);
        Task<TransferMaster> UpdateTransferAsync(TransferMaster transferMaster);
        Task<bool> DeleteTransferAsync(string transferId, bool isPermanantDetele = false);
        Task<int> GetMaxSrNoAsync(string companyId, string financialYearId);
        Task<List<TransferCategoryList>> GetTransferCategoryList(string companyId, string financialYearId);
    }
}
