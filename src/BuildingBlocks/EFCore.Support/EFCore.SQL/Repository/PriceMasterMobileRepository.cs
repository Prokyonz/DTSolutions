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

        public async Task<PriceMasterMobile> GetPricesAsync(string companyId, string categoryId, string SizeId, string NumberId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getRecords = await _databaseContext.PriceMasterMobile.Where(s => s.CompanyId == companyId && s.CategoryId == categoryId
                                    && s.SizeId == SizeId && s.NumberId == NumberId).FirstOrDefaultAsync();
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
                    getRecords.SizeId = priceMaster.SizeId;
                    getRecords.NumberId = priceMaster.NumberId;
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
    }
}
