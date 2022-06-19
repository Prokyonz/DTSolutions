using EFCore.SQL.DBContext;
using EFCore.SQL.Interface;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.SQL.Repository
{
    public class LedgerBalanceManagerRepository : ILedgerBalanceManager
    {
        private DatabaseContext _databaseContext;

        public LedgerBalanceManagerRepository()
        {

        }
        public async Task<LedgerBalanceManager> AddLedgerBalanceAsync(LedgerBalanceManager ledgerBalanceManager)
        {
            using (_databaseContext = new DatabaseContext())
            {
                if (ledgerBalanceManager.Id == null)
                    ledgerBalanceManager.Id = Guid.NewGuid().ToString();

                await _databaseContext.LedgerBalanceManager.AddAsync(ledgerBalanceManager);
                await _databaseContext.SaveChangesAsync();
                return ledgerBalanceManager;
            }
        }

        public async Task<bool> DeleteLedgerBalanceAsync(string id)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var result = await _databaseContext.LedgerBalanceManager.Where(w => w.Id == id).FirstOrDefaultAsync();

                if (result != null)
                {
                    _databaseContext.LedgerBalanceManager.Remove(result);
                    await _databaseContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
        }

        public async Task<List<LedgerBalanceManager>> GetAllLedgerBalanceAsync(string companyId, string financialYearId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.LedgerBalanceManager.Where(w => w.CompanyId == companyId && w.FinancialYearId == financialYearId).ToListAsync();
            }
        }

        public async Task<LedgerBalanceManager> UpdateLedgerBalanceAsync(LedgerBalanceManager ledgerBalanceManager)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var result = await _databaseContext.LedgerBalanceManager.Where(w => w.LedgerId == ledgerBalanceManager.LedgerId && w.TypeOfBalance == ledgerBalanceManager.TypeOfBalance).FirstOrDefaultAsync();

                if(result != null)
                {
                    result.UpdatedBy = ledgerBalanceManager.UpdatedBy;
                    result.UpdatedDate = ledgerBalanceManager.UpdatedDate;
                    result.LedgerId = ledgerBalanceManager.LedgerId;
                    result.Balance = ledgerBalanceManager.Balance;
                    result.TypeOfBalance = ledgerBalanceManager.TypeOfBalance;
                }

                await _databaseContext.SaveChangesAsync();
                return ledgerBalanceManager;
            }
        }
    }
}
