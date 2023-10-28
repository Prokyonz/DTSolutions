using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface ICurrencyMaster
    {
        Task<List<CurrencyMaster>> GetAllCurrencyAsync(string CompanyId);
        Task<CurrencyMaster> AddCurrencyAsync(CurrencyMaster currencyMaster);
        Task<CurrencyMaster> UpdateCurrencyAsync(CurrencyMaster currencyMaster);
        Task<int> DeleteCurrencyAsync(string currencyId, bool isPermanantDetele = false);
    }
}
