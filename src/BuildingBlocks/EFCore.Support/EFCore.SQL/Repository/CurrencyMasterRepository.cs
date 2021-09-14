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
    public class CurrencyMasterRepository : ICurrencyMaster
    {
        private readonly DatabaseContext _databaseContext;

        public CurrencyMasterRepository()
        {
            _databaseContext = new DatabaseContext();
        }

        public async Task<List<CurrencyMaster>> GetAllCurrencyAsync()
        {
            return await _databaseContext.CurrencyMaster.Where(c => c.IsDelete == false).ToListAsync();
        }

        public async Task<CurrencyMaster> AddCurrencyAsync(CurrencyMaster currencyMaster)
        {
            if (currencyMaster.Id == null)
                currencyMaster.Id = Guid.NewGuid();
            await _databaseContext.CurrencyMaster.AddAsync(currencyMaster);
            await _databaseContext.SaveChangesAsync();
            return currencyMaster;
        }

        public async Task<bool> DeleteCurrencyAsync(Guid currencyId, bool isPermanantDetele = false)
        {
            var getCurrency = await _databaseContext.CurrencyMaster.Where(s => s.Id == currencyId).FirstOrDefaultAsync();
            if (getCurrency != null)
            {
                if (isPermanantDetele)
                    _databaseContext.CurrencyMaster.Remove(getCurrency);
                else
                    getCurrency.IsDelete = true;
                await _databaseContext.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<CurrencyMaster> UpdateCurrencyAsync(CurrencyMaster currencyMaster)
        {
            var getCurrency = await _databaseContext.CurrencyMaster.Where(s => s.Id == currencyMaster.Id).FirstOrDefaultAsync();
            if (getCurrency != null)
            {
                getCurrency.Name = currencyMaster.Name;
                getCurrency.ShortName = currencyMaster.ShortName;
                getCurrency.Value = currencyMaster.Value;
                getCurrency.UpdatedDate = currencyMaster.UpdatedDate;
                getCurrency.UpdatedBy = currencyMaster.UpdatedBy;
            }
            await _databaseContext.SaveChangesAsync();
            return currencyMaster;
        }
    }
}
