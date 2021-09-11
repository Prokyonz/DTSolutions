using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface IFinancialYearMaster
    {
        Task<FinancialYearMaster> AddFinancialYearAsync(FinancialYearMaster financialYearMaster);
        Task<FinancialYearMaster> UpdateFinancialYearAsync(FinancialYearMaster financialYearMaster);
        Task<bool> DeleteFinancialYearAsync(Guid financialYearId, bool isPermanantDetele = false);
        Task<List<FinancialYearMaster>> GetAllFinancialYear();
    }
}
