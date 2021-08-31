using Repository.Entities;
using System;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface IFinancialYearMaster
    {
        Task<FinancialYearMaster> AddFinancialYearAsync(FinancialYearMaster financialYearMaster);
        Task<bool> DeleteFinancialYearAsync(Guid financialYearId, bool isPermanantDetele = false);
    }
}
