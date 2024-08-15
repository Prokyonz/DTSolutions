using EFCore.SQL.DBContext;
using EFCore.SQL.Interface;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace EFCore.SQL.Repository
{    
    public class CompanyMasterRepository : ICompanyMaster, IDisposable
    {
        private readonly CacheKeyGenerator _cacheKeyGenerator;
        private readonly CacheService _cacheService;        
        private DatabaseContext _databaseContext;

        public CompanyMasterRepository()
        {
            _cacheService = new CacheService(false);
        }

        public CompanyMasterRepository(CacheKeyGenerator cacheKeyGenerator)
        {
            _cacheKeyGenerator = cacheKeyGenerator;
            _cacheService = new CacheService(_cacheKeyGenerator.IsCacheEnabled);
        }

        public string GetKey(string key)
        {
            if (_cacheKeyGenerator == null)
                return "NoKey";
            return _cacheKeyGenerator.CompanyId + _cacheKeyGenerator.FinancialYearId + _cacheKeyGenerator.UserId + key;
        }

        public void RemoveCache()
        {
            _cacheService.RemoveCacheItem(GetKey(CacheConstant.ALL_COMPANY));
            _cacheService.RemoveCacheItem(GetKey(CacheConstant.GET_PARENT_COMPANY));
            _cacheService.RemoveCacheItem(GetKey(CacheConstant.GET_USER_COMPANY_MAPPING));
        }

        public async Task<CompanyMaster> AddCompanyAsync(CompanyMaster companyMaster)
        {
            RemoveCache();

            using (_databaseContext = new DatabaseContext())
            {
                try
                {
                    if (companyMaster.Id == null)
                        companyMaster.Id = Guid.NewGuid().ToString();

                    await _databaseContext.CompanyMaster.AddAsync(companyMaster);
                    await _databaseContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw;
                }

                return companyMaster;
            }
        }

        public async Task<int> DeleteCompanyAsync(string CompanyId)
        {
            RemoveCache();

            using (_databaseContext = new DatabaseContext())
            {
                var resultCount = await _databaseContext.SPValidationModel.FromSqlRaw($"Validate_Records '" + CompanyId + "',1").ToListAsync();
                return resultCount[0].Status;

                //var getCompany = await _databaseContext.CompanyMaster.Where(s => s.Id == CompanyId).FirstOrDefaultAsync();
                //if (getCompany != null)
                //{
                //    getCompany.IsDelete = true;
                //}
                //await _databaseContext.SaveChangesAsync();
                //return true;
            }
        }

        public void Dispose()
        {
            if (_databaseContext != null)
            {
                _databaseContext.DisposeAsync();
            }
        }

        public async Task<List<CompanyMaster>> GetAllCompanyAsync()
        {
            List<CompanyMaster> allCompanies = _cacheService.GetCacheItem<List<CompanyMaster>>(GetKey(CacheConstant.ALL_COMPANY));

            if (allCompanies == null)
            {
                using (_databaseContext = new DatabaseContext())
                {
                    allCompanies = await _databaseContext.CompanyMaster.Where(s => s.IsDelete == false).Include("CompanyOptions").ToListAsync();
                    _cacheService.SetCacheItem(GetKey(CacheConstant.ALL_COMPANY), allCompanies, TimeSpan.FromHours(CacheConstant.CACHE_HOURS));
                }
            }

            return allCompanies;
        }

        public async Task<List<CompanyMaster>> GetParentCompanyAsync()
        {
            List<CompanyMaster> parentCompanies = _cacheService.GetCacheItem<List<CompanyMaster>>(GetKey(CacheConstant.GET_PARENT_COMPANY));

            if (parentCompanies == null)
            {
                using (_databaseContext = new DatabaseContext())
                {
                    parentCompanies = await _databaseContext.CompanyMaster.Where(s => s.IsDelete == false && s.Type == null).ToListAsync();
                    _cacheService.SetCacheItem(GetKey(CacheConstant.GET_PARENT_COMPANY), parentCompanies, TimeSpan.FromHours(CacheConstant.CACHE_HOURS));                    
                }
            }
            return parentCompanies;
        }

        public async Task<List<CompanyMaster>> GetUserCompanyMappingAsync(string userId)
        {            
            List<CompanyMaster> userCompanyMappings = _cacheService.GetCacheItem<List<CompanyMaster>>(GetKey(CacheConstant.GET_USER_COMPANY_MAPPING));

            if (userCompanyMappings == null)
            {
                using (_databaseContext = new DatabaseContext())
                {
                    var result = await _databaseContext.UserCompanyMappings.Where(w => w.UserId == userId).Select(s => s.CompanyId).ToListAsync();
                    userCompanyMappings = await _databaseContext.CompanyMaster.Where(w => result.Contains(w.Id)).Include("CompanyOptions").ToListAsync();

                    _cacheService.SetCacheItem(GetKey(CacheConstant.GET_USER_COMPANY_MAPPING), userCompanyMappings, TimeSpan.FromHours(CacheConstant.CACHE_HOURS));
                }
            }
            return userCompanyMappings;
        }

        public async Task<CompanyMaster> UpdateCompanyAsync(CompanyMaster companyMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var getCompany = await _databaseContext.CompanyMaster.Where(s => s.Id == companyMaster.Id).FirstOrDefaultAsync();
                    if (getCompany != null)
                    {
                        var getOldCompanyOptions = await _databaseContext.CompanyOptions.Where(w => w.CompanyMasterId == getCompany.Id).ToListAsync();
                        _databaseContext.CompanyOptions.RemoveRange(getOldCompanyOptions);

                        await _databaseContext.CompanyOptions.AddRangeAsync(companyMaster.CompanyOptions);

                        getCompany.Name = companyMaster.Name;
                        getCompany.Address = companyMaster.Address;
                        getCompany.Address2 = companyMaster.Address2;
                        getCompany.MobileNo = companyMaster.MobileNo;
                        getCompany.Details = companyMaster.Details;
                        getCompany.TermsCondition = companyMaster.TermsCondition;
                        getCompany.GSTNo = companyMaster.GSTNo;
                        getCompany.PanCardNo = companyMaster.PanCardNo;
                        getCompany.RegistrationNo = companyMaster.RegistrationNo;
                        getCompany.Type = companyMaster.Type;
                        getCompany.IsDelete = companyMaster.IsDelete;
                        getCompany.CreatedDate = companyMaster.CreatedDate;
                        getCompany.UpdatedDate = companyMaster.UpdatedDate;
                        getCompany.CreatedBy = companyMaster.CreatedBy;
                        getCompany.UpdatedBy = companyMaster.UpdatedBy;
                    }
                    await _databaseContext.SaveChangesAsync();
                    transactionScope.Complete();
                }
                return companyMaster;
            }
        }
    }
}
