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
    public class SizeMasterRepository : ISizeMaster
    {
        private readonly CacheKeyGenerator _cacheKeyGenerator;
        private readonly CacheService _cacheService;
        private DatabaseContext _databaseContext;

        public SizeMasterRepository()
        {
            _cacheService = new CacheService(false);
        }

        public SizeMasterRepository(CacheKeyGenerator cacheKeyGenerator)
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

        public async Task<List<SizeMaster>> GetAllSizeAsync()
        {
            List<SizeMaster> allSizes = _cacheService.GetCacheItem<List<SizeMaster>>(GetKey(CacheConstant.ALL_SIZE));
            if (allSizes == null)
            {
                using (_databaseContext = new DatabaseContext())
                {
                    allSizes = await _databaseContext.SizeMaster.Where(s => s.IsDelete == false).ToListAsync();
                    _cacheService.SetCacheItem(GetKey(CacheConstant.ALL_SIZE), allSizes, TimeSpan.FromHours(CacheConstant.CACHE_HOURS));
                    return allSizes;
                }
            } else
            {
                return allSizes;
            }
        }

        public async Task<SizeMaster> AddSizeAsync(SizeMaster sizeMaster)
        {
            RemoveCache();

            using (_databaseContext = new DatabaseContext())
            {
                if (sizeMaster.Id == null)
                    sizeMaster.Id = Guid.NewGuid().ToString();
                await _databaseContext.SizeMaster.AddAsync(sizeMaster);
                await _databaseContext.SaveChangesAsync();
                return sizeMaster;
            }
        }

        public async Task<int> DeleteSizeAsync(string sizeId, bool isPermanantDetele = false)
        {
            RemoveCache();

            using (_databaseContext = new DatabaseContext())
            {
                var resultCount = await _databaseContext.SPValidationModel.FromSqlRaw($"Validate_Records '" + sizeId + "',5").ToListAsync();
                return resultCount[0].Status;

                //var getSize = await _databaseContext.SizeMaster.Where(s => s.Id == purityId).FirstOrDefaultAsync();
                //if (getSize != null)
                //{
                //    if (isPermanantDetele)
                //        _databaseContext.SizeMaster.Remove(getSize);
                //    else
                //        getSize.IsDelete = true;
                //    await _databaseContext.SaveChangesAsync();

                //    return true;
                //}

                //return false;
            }
        }

        public async Task<SizeMaster> UpdateSizeAsync(SizeMaster sizeMaster)
        {
            RemoveCache();

            using (_databaseContext = new DatabaseContext())
            {
                var getSize = await _databaseContext.SizeMaster.Where(s => s.Id == sizeMaster.Id).FirstOrDefaultAsync();
                if (getSize != null)
                {
                    getSize.Name = sizeMaster.Name;
                    getSize.UpdatedDate = sizeMaster.UpdatedDate;
                    getSize.UpdatedBy = sizeMaster.UpdatedBy;
                }
                await _databaseContext.SaveChangesAsync();
                return sizeMaster;
            }
        }
    }
}
