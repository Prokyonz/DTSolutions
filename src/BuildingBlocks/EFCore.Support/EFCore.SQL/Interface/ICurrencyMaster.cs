using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface ICurrencyMaster
    {
        Task<List<CurrencyMaster>> GetAllCurrencyAsync();
        Task<CurrencyMaster> AddCurrencyAsync(CurrencyMaster currencyMaster);
        Task<CurrencyMaster> UpdateCurrencyAsync(CurrencyMaster currencyMaster);
        Task<bool> DeleteCurrencyAsync(Guid currencyId, bool isPermanantDetele = false);
    }
}
