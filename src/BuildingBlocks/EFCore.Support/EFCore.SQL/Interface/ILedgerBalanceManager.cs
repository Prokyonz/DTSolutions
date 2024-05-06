using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface ILedgerBalanceManager
    {
        Task<List<LedgerBalanceManager>> GetAllLedgerBalanceAsync(string companyId, string financialYearId);
        Task<LedgerBalanceManager> AddLedgerBalanceAsync(LedgerBalanceManager ledgerBalanceManager);
        Task<LedgerBalanceManager> UpdateLedgerBalanceAsync(LedgerBalanceManager ledgerBalanceManager);
        Task<bool> DeleteLedgerBalanceAsync(string id);
        Task<LedgerBalanceManager> GetLedgerBalance(string partyId);
    }
}
