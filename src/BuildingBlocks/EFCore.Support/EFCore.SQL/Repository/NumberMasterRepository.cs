using EFCore.SQL.DBContext;
using EFCore.SQL.Interface;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.SQL.Repository
{
    public class NumberMasterRepository : INumberMaster
    {
        private DatabaseContext _databaseContext;
        private readonly CacheKeyGenerator _cacheKeyGenerator;
        private readonly CacheService _cacheService;

        public NumberMasterRepository()
        {
            
        }
        public NumberMasterRepository(CacheKeyGenerator cacheKeyGenerator)
        {
            _cacheKeyGenerator = cacheKeyGenerator;
            _cacheService = new CacheService(_cacheKeyGenerator.IsCacheEnabled);
        }

        #region CacheMethod
        public string GetKey(string key)
        {
            if (_cacheKeyGenerator == null)
                return "NoKey";
            return _cacheKeyGenerator.CompanyId + _cacheKeyGenerator.FinancialYearId + _cacheKeyGenerator.UserId + key;
        }

        public void RemoveCache()
        {
            _cacheService.RemoveCacheItem(GetKey(CacheConstant.ALL_SIZE));
        }
        #endregion

        public async Task<List<NumberMaster>> GetAllNumberAsync()
        {
            using (_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.NumberMaster.Where(s => s.IsDelete == false).ToListAsync();
            }
        }

        public async Task<NumberMaster> AddNumberAsync(NumberMaster numberMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                if (numberMaster.Id == null)
                    numberMaster.Id = Guid.NewGuid().ToString();
                await _databaseContext.NumberMaster.AddAsync(numberMaster);
                await _databaseContext.SaveChangesAsync();
                return numberMaster;
            }
        }

        public async Task<int> DeleteNumberAsync(string numberId, bool isPermanantDetele = false)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var resultCount = await _databaseContext.SPValidationModel.FromSqlRaw($"Validate_Records '" + numberId + "',9").ToListAsync();
                return resultCount[0].Status;
                //var getNumber = await _databaseContext.NumberMaster.Where(s => s.Id == numberId).FirstOrDefaultAsync();
                //if (getNumber != null)
                //{
                //    if (isPermanantDetele)
                //        _databaseContext.NumberMaster.Remove(getNumber);
                //    else
                //        getNumber.IsDelete = true;
                //    await _databaseContext.SaveChangesAsync();

                //    return true;
                //}

                //return false;
            }
        }

        public async Task<NumberMaster> UpdateNumberAsync(NumberMaster numberMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getNumber = await _databaseContext.NumberMaster.Where(s => s.Id == numberMaster.Id).FirstOrDefaultAsync();
                if (getNumber != null)
                {
                    getNumber.Name = numberMaster.Name;
                    getNumber.UpdatedDate = numberMaster.UpdatedDate;
                    getNumber.UpdatedBy = numberMaster.UpdatedBy;
                }
                await _databaseContext.SaveChangesAsync();
                return numberMaster;
            }
        }
    }
}