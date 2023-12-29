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
        private DatabaseContext _databaseContext;

        public CurrencyMasterRepository()
        {
            
        }

        public async Task<List<CurrencyMaster>> GetAllCurrencyAsync(string CompanyId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.CurrencyMaster.Where(c => c.IsDelete == false && c.CompanyId == CompanyId).ToListAsync();
            }
        }

        public async Task<CurrencyMaster> AddCurrencyAsync(CurrencyMaster currencyMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                if (currencyMaster.Id == null)
                    currencyMaster.Id = Guid.NewGuid().ToString();
                await _databaseContext.CurrencyMaster.AddAsync(currencyMaster);
                await _databaseContext.SaveChangesAsync();
                return currencyMaster;
            }
        }

        public async Task<int> DeleteCurrencyAsync(string currencyId, bool isPermanantDetele = false)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var resultCount = await _databaseContext.SPValidationModel.FromSqlRaw($"Validate_Records '" + currencyId + "',10").ToListAsync();
                return resultCount[0].Status;
                //var getCurrency = await _databaseContext.CurrencyMaster.Where(s => s.Id == currencyId).FirstOrDefaultAsync();
                //if (getCurrency != null)
                //{
                //    if (isPermanantDetele)
                //        _databaseContext.CurrencyMaster.Remove(getCurrency);
                //    else
                //        getCurrency.IsDelete = true;
                //    await _databaseContext.SaveChangesAsync();

                //    return true;
                //}

                //return false;
            }
        }

        public async Task<CurrencyMaster> UpdateCurrencyAsync(CurrencyMaster currencyMaster)
        {
            using (_databaseContext = new DatabaseContext())
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
}
