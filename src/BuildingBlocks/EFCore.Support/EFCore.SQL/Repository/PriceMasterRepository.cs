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
    public class PriceMasterRepository : IPriceMaster
    {
        private DatabaseContext _databaseContext;

        public PriceMasterRepository()
        {

        }

        public async Task<List<PriceMaster>> AddPriceAsync(List<PriceMaster> priceMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                //if (priceMaster.Id == null)
                //    priceMaster.Id = Guid.NewGuid().ToString();

                await _databaseContext.PriceMaster.AddRangeAsync(priceMaster);
                await _databaseContext.SaveChangesAsync();
            }
            return priceMaster;
        }

        public async Task<bool> DeletePriceAsync(string companyId, string categoryId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getPrice = await _databaseContext.PriceMaster.Where(s => s.CompanyId == companyId && s.CategoryId == categoryId).ToListAsync();
                if (getPrice != null)
                {
                    _databaseContext.PriceMaster.RemoveRange(getPrice);
                }
                await _databaseContext.SaveChangesAsync();
                return true;
            }
        }

        public async Task<List<PriceMaster>> GetAllPricesAsync(string companyId, string categoryId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getRecords = await _databaseContext.PriceMaster.Where(s => s.CompanyId == companyId && s.CategoryId == categoryId).ToListAsync();
                return getRecords;
            }
        }

        public async Task<PriceMaster> UpdatePriceAsync(PriceMaster priceMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getRecords = await _databaseContext.PriceMaster.Where(s => s.Id == priceMaster.Id).FirstOrDefaultAsync();
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
