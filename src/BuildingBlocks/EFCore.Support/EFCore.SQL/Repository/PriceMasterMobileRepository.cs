using EFCore.SQL.DBContext;
using EFCore.SQL.Interface;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.SQL.Repository
{
    public class PriceMasterMobileRepository : IPriceMasterMobile
    {
        private DatabaseContext _databaseContext;

        public PriceMasterMobileRepository()
        {

        }

        public async Task<List<PriceMasterMobile>> AddPriceAsync(List<PriceMasterMobile> priceMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                //if (priceMaster.Id == null)
                //    priceMaster.Id = Guid.NewGuid().ToString();

                await _databaseContext.PriceMasterMobile.AddRangeAsync(priceMaster);
                await _databaseContext.SaveChangesAsync();
            }
            return priceMaster;
        }

        public async Task<bool> DeletePriceAsync(string companyId, string categoryId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getPrice = await _databaseContext.PriceMasterMobile.Where(s => s.CompanyId == companyId && s.CategoryId == categoryId).ToListAsync();
                if (getPrice != null)
                {
                    _databaseContext.PriceMasterMobile.RemoveRange(getPrice);
                }
                await _databaseContext.SaveChangesAsync();
                return true;
            }
        }

        public async Task<List<PriceMasterMobile>> GetAllPricesAsync(string companyId, string categoryId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getRecords = await _databaseContext.PriceMasterMobile.Where(s => s.CompanyId == companyId && s.CategoryId == categoryId).ToListAsync();
                return getRecords;
            }
        }

        public async Task<PriceMasterMobile> GetPricesAsync(string companyId, string categoryId, string Size, string Number)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getRecords = await _databaseContext.PriceMasterMobile.Where(s => s.CompanyId == companyId && s.CategoryId == categoryId
                                    && s.SizeName == Size && s.NumberName == Number).FirstOrDefaultAsync();
                return getRecords;
            }
        }

        public async Task<PriceMasterMobile> UpdatePriceAsync(PriceMasterMobile priceMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getRecords = await _databaseContext.PriceMasterMobile.Where(s => s.Id == priceMaster.Id).FirstOrDefaultAsync();
                if (getRecords != null)
                {
                    getRecords.CategoryId = priceMaster.CategoryId;
                    getRecords.SizeName = priceMaster.SizeName;
                    getRecords.NumberName = priceMaster.NumberName;
                    getRecords.Price = priceMaster.Price;
                    getRecords.UpdatedDate = DateTime.Now;
                    getRecords.UpdatedBy = priceMaster.UpdatedBy;
                }

                await _databaseContext.SaveChangesAsync();
                return priceMaster;
            }
        }

        public async Task<List<PriceSPModel>> GetDefaultPriceList()
        {
            using (_databaseContext = new DatabaseContext())
            {
                var defaultPriceList = await _databaseContext.PriceSPModel.FromSqlRaw($"GetDefaultSizeNumberDetailsForPriceMaster").ToListAsync();
                return defaultPriceList;
            }
        }

        public async Task<List<PriceMasterMobile>> GetMobileData()
        {
            using (_databaseContext = new DatabaseContext())
            {
                var defaultPriceList = await _databaseContext.PriceMasterMobile.FromSqlRaw($"Select * from PriceMasterMobile").ToListAsync();
                return defaultPriceList;
            }
        }

        public bool CheckDuplicateEntry(string size, string number, decimal price)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var defaultPriceList = _databaseContext.PriceMasterMobile.Any(x => x.SizeName == size && x.Price == price && x.NumberName == number);
                return defaultPriceList;
            }
        }

        public async Task<List<string>> GetAllSizesAsync()
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getRecords = await _databaseContext.PriceMasterMobile.Select(x => x.SizeName).Distinct().ToListAsync();
                return getRecords;
            }
        }

        public async Task<List<string>> GetAllNumberAsync()
        {
            using (_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.PriceMasterMobile.Select(s => s.NumberName).Distinct().ToListAsync();
            }
        }

        public async Task<List<PriceMasterMobile>> GetPriceBySize(string size, string companyId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.PriceMasterMobile.Where(s => s.SizeName == size && s.CompanyId == companyId).OrderBy(x => x.NumberName).ToListAsync();
            }
        }
    }
}
