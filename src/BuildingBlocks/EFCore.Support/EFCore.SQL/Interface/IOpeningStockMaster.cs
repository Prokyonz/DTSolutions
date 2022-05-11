using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface IOpeningStockMaster
    {
        Task<List<OpeningStockMaster>> GetAllOpeningStockAsync(string companyId, string financialYearId);
        Task<int> GetMaxAsync(string companyId, string financialYearId);
        Task<OpeningStockMaster> AddOpeningStockAsync(OpeningStockMaster openingStockMaster);
        Task<OpeningStockMaster> UpdateBranchAsync(OpeningStockMaster openingStockMaster);
        Task<bool> DeleteBranchAsync(string stockMasterId);
    }
}
