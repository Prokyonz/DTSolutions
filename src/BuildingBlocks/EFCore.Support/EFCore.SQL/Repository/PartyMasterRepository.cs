﻿using EFCore.SQL.DBContext;
using EFCore.SQL.Interface;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EFCore.SQL.Repository
{
    public class PartyMasterRepository : IPartyMaster
    {
        private DatabaseContext _databaseContext;
        private readonly CacheKeyGenerator _cacheKeyGenerator;
        private readonly CacheService _cacheService;

        public PartyMasterRepository()
        {
            _cacheService = new CacheService();
        }

        public PartyMasterRepository(CacheKeyGenerator cacheKeyGenerator)
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

        public async Task<PartyMaster> AddPartyAsync(PartyMaster partyMaster)
        {
            _cacheService.RemoveCacheItem(CacheConstant.GET_PARTY_BY_PARTY_TYPE);
            _cacheService.RemoveCacheItem(CacheConstant.GET_BROKER);
            _cacheService.RemoveCacheItem(CacheConstant.ALL_MASTER_PARTY);
            _cacheService.RemoveCacheItem(CacheConstant.ALL_PARTY);


            using (_databaseContext = new DatabaseContext())
            {
                if (partyMaster.Id == null)
                    partyMaster.Id = Guid.NewGuid().ToString();

                await _databaseContext.PartyMaster.AddAsync(partyMaster);
                await _databaseContext.SaveChangesAsync();
                return partyMaster;
            }
        }

        public async Task<int> DeletePartyAsync(string partyId, bool isPermanantDetele = false)
        {
            _cacheService.RemoveCacheItem(CacheConstant.GET_PARTY_BY_PARTY_TYPE);
            _cacheService.RemoveCacheItem(CacheConstant.GET_BROKER);
            _cacheService.RemoveCacheItem(CacheConstant.ALL_MASTER_PARTY);
            _cacheService.RemoveCacheItem(CacheConstant.ALL_PARTY);

            using (_databaseContext = new DatabaseContext())
            {
                var resultCount = await _databaseContext.SPValidationModel.FromSqlRaw($"Validate_Records '" + partyId + "',4").ToListAsync();
                return resultCount[0].Status;
                //var getParty = await _databaseContext.PartyMaster.Where(s => s.Id == partyId).FirstOrDefaultAsync();
                //if (getParty != null)
                //{
                //    if (isPermanantDetele)
                //        _databaseContext.PartyMaster.Remove(getParty);
                //    else
                //        getParty.IsDelete = true;

                //    await _databaseContext.SaveChangesAsync();
                //    return true;
                //}                
            }
            return 0;
            //return false;
        }

        public async Task<List<PartyMaster>> GetAllPartyAsync()
        {
            List<PartyMaster> partyMasters;
            List<LedgerBalanceSPModel> LedgerData = await GetLedgerReport("", "");

            using (_databaseContext = new DatabaseContext())
            {
                //var result = await _databaseContext.LedgerBalanceManager.ToListAsync();                
                partyMasters = await _databaseContext.PartyMaster.Where(s => s.IsDelete == false).ToListAsync();
                foreach (var item in partyMasters)
                {
                    var getBalance = LedgerData.Where(w => w.LedgerId == item.Id).FirstOrDefault();

                    if (getBalance != null)
                    {
                        item.OpeningBalance = getBalance.ClosingBalance;
                    }
                    else
                    {
                        item.OpeningBalance = 0;
                    }
                }
            }
            return partyMasters;
        }

        public async Task<List<SPPartyMaster>> GetPartyMasterAsync(string companyId)
        {
            List<SPPartyMaster> allParties = _cacheService.GetCacheItem<List<SPPartyMaster>>(GetKey(CacheConstant.ALL_PARTY));

            if (allParties == null)
            {
                using (_databaseContext = new DatabaseContext())
                {
                    allParties = await _databaseContext.SPPartyMaster.FromSqlRaw($"GetPartyMasterReport '" + companyId + "'").ToListAsync();
                    _cacheService.SetCacheItem(GetKey(CacheConstant.ALL_MASTER_PARTY), allParties, TimeSpan.FromHours(CacheConstant.CACHE_HOURS));
                }
            }
            return allParties;
        }

        public async Task<List<PartyMaster>> GetAllPartyAsync(string companyId)
        {
            List<PartyMaster> partyMasters  = _cacheService.GetCacheItem<List<PartyMaster>>(GetKey(CacheConstant.ALL_PARTY));

            if (partyMasters == null)
            {
                using (_databaseContext = new DatabaseContext())
                {
                    var result = await _databaseContext.LedgerBalanceManager.ToListAsync();

                    partyMasters = await _databaseContext.PartyMaster.Where(s => s.IsDelete == false && s.CompanyId == companyId).ToListAsync();
                    foreach (var item in partyMasters)
                    {
                        var getBalance = result.Where(w => w.LedgerId == item.Id).FirstOrDefault();

                        if (getBalance != null)
                        {
                            item.OpeningBalance = getBalance.Balance;
                        }
                        else
                        {
                            item.OpeningBalance = 0;
                        }
                    }
                }
                _cacheService.SetCacheItem(GetKey(CacheConstant.ALL_PARTY), partyMasters, TimeSpan.FromHours(CacheConstant.CACHE_HOURS));
            }
            return partyMasters;
        }

        public async Task<List<PartyMaster>> GetAllPartyAsync(string companyId, int partyTypeMaster)
        {
            List<PartyMaster> partyMasters;
            //List<PartyMaster> partyMasters = _cacheService.GetCacheItem<List<PartyMaster>>(CacheConstant.GET_PARTY_BY_PARTY_TYPE);

            //if (partyMasters == null)
            //{
            List<LedgerBalanceSPModel> LedgerData = await GetLedgerReport(companyId, "");

            using (_databaseContext = new DatabaseContext())
            {
                partyMasters = await _databaseContext.PartyMaster.Where(s => s.CompanyId == companyId && s.IsDelete == false && s.Type == partyTypeMaster).ToListAsync();
                foreach (var item in partyMasters)
                {
                    var getBalance = LedgerData.Where(w => w.LedgerId == item.Id).FirstOrDefault();

                    if (getBalance != null)
                    {
                        item.OpeningBalance = getBalance.ClosingBalance;
                    }
                    else
                    {
                        item.OpeningBalance = 0;
                    }
                }
                //_cacheService.SetCacheItem(CacheConstant.GET_PARTY_BY_PARTY_TYPE, partyMasters, TimeSpan.FromHours(CacheConstant.CACHE_HOURS));
            }
            //}
            return partyMasters;
        }

        public async Task<List<PartyMaster>> GetAllPartyAsync(string companyId, int[] partyTypeMaster)
        {
            List<PartyMaster> partyMasters;
            List<LedgerBalanceSPModel> LedgerData = await GetLedgerReport(companyId, "");

            using (_databaseContext = new DatabaseContext())
            {
                //var result = await _databaseContext.LedgerBalanceManager.ToListAsync();

                partyMasters = await _databaseContext.PartyMaster.Where(w => w.CompanyId == companyId && w.IsDelete == false && partyTypeMaster.Contains(w.Type)).ToListAsync();
                foreach (var item in partyMasters)
                {
                    var getBalance = LedgerData.Where(w => w.LedgerId == item.Id).FirstOrDefault();

                    if (getBalance != null)
                    {
                        item.OpeningBalance = getBalance.ClosingBalance;
                    }
                    else
                    {
                        item.OpeningBalance = 0;
                    }
                }
            }
            return partyMasters;
        }
        public async Task<List<PartyMaster>> GetAllPartyAsync(string companyId, int partTypeMaster, int[] subType)
        {
            List<PartyMaster> partyMasters;
            //List<PartyMaster> partyMasters = _cacheService.GetCacheItem<List<PartyMaster>>(CacheConstant.GET_BROKER);

            //if (partyMasters == null)
            //{
            List<LedgerBalanceSPModel> LedgerData = await GetLedgerReport(companyId, "");

            using (_databaseContext = new DatabaseContext())
            {
                partyMasters = await _databaseContext.PartyMaster.Where(w => w.CompanyId == companyId && w.IsDelete == false && w.Type == partTypeMaster && subType.Contains(w.SubType)).ToListAsync();
                foreach (var item in partyMasters)
                {
                    var getBalance = LedgerData.Where(w => w.LedgerId == item.Id).FirstOrDefault();

                    if (getBalance != null)
                    {
                        item.OpeningBalance = getBalance.ClosingBalance;
                    }
                    else
                    {
                        item.OpeningBalance = 0;
                    }
                }
                //_cacheService.SetCacheItem(CacheConstant.GET_BROKER, partyMasters, TimeSpan.FromHours(CacheConstant.CACHE_HOURS));
            }
            //}
            return partyMasters;
        }

        public async Task<List<PartyMaster>> GetPartyAsync()
        {
            List<PartyMaster> partyMasters;
            List<LedgerBalanceSPModel> LedgerData = await GetLedgerReport("", "");

            using (_databaseContext = new DatabaseContext())
            {
                //var result = await _databaseContext.LedgerBalanceManager.ToListAsync();

                partyMasters = await _databaseContext.PartyMaster.Where(s => s.IsDelete == false && (s.Type == PartyTypeMaster.PartyBuy || s.Type == PartyTypeMaster.PartySale)).ToListAsync();
                foreach (var item in partyMasters)
                {
                    var getBalance = LedgerData.Where(w => w.LedgerId == item.Id).FirstOrDefault();

                    if (getBalance != null)
                    {
                        item.OpeningBalance = getBalance.ClosingBalance;
                    }
                    else
                    {
                        item.OpeningBalance = 0;
                    }
                }
            }
            return partyMasters;
        }

        public async Task<PartyMaster> UpdatePartyAsync(PartyMaster partyMaster)
        {
            _cacheService.RemoveCacheItem(CacheConstant.GET_PARTY_BY_PARTY_TYPE);
            _cacheService.RemoveCacheItem(CacheConstant.GET_BROKER);

            using (_databaseContext = new DatabaseContext())
            {
                var getParty = await _databaseContext.PartyMaster.Where(s => s.Id == partyMaster.Id).FirstOrDefaultAsync();
                if (getParty != null)
                {
                    getParty.Status = partyMaster.Status;
                    getParty.CompanyId = partyMaster.CompanyId;
                    getParty.BrokerageId = partyMaster.BrokerageId;
                    getParty.Type = partyMaster.Type;
                    getParty.SubType = partyMaster.SubType;
                    getParty.Name = partyMaster.Name;
                    getParty.ShortName = partyMaster.ShortName;
                    getParty.EmailId = partyMaster.EmailId;
                    getParty.Address = partyMaster.Address;
                    getParty.Address2 = partyMaster.Address2;
                    getParty.MobileNo = partyMaster.MobileNo;
                    getParty.OfficeNo = partyMaster.OfficeNo;
                    getParty.GSTNo = partyMaster.GSTNo;
                    getParty.PancardNo = partyMaster.PancardNo;
                    getParty.Salary = partyMaster.Salary;
                    getParty.OpeningBalance = partyMaster.OpeningBalance;
                    getParty.AadharCardNo = partyMaster.AadharCardNo;
                    getParty.UpdatedDate = partyMaster.UpdatedDate;
                    getParty.UpdatedBy = partyMaster.UpdatedBy;
                    getParty.CRDRType = partyMaster.CRDRType;
                }
                await _databaseContext.SaveChangesAsync();
                return partyMaster;
            }
        }

        public async Task<decimal> GetPartyBalance(string partyId, string companyId, string financialYearId)
        {            
            using (_databaseContext = new DatabaseContext())
            {
                List<LedgerBalanceSPModel> LedgerData = await _databaseContext.SPLedgerBalanceReport.FromSqlRaw("GetLedgerBalanceReportOfParty '" + companyId + "', '" + financialYearId + "','" + partyId + "'").ToListAsync();

                var ledger = LedgerData.Where(w => w.LedgerId == partyId).FirstOrDefault();

                if (ledger != null)
                    return ledger.ClosingBalance;

                //var result = await _databaseContext.LedgerBalanceManager.Where(w => w.LedgerId == partyId).FirstOrDefaultAsync();
                //if (result != null)
                //    return result.Balance;
                return 0;
            }
        }

        public async Task<List<LedgerBalanceSPModel>> GetLedgerReport(string companyId, string financialYearId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var result = await _databaseContext.SPLedgerBalanceReport.FromSqlRaw("GetLedgerBalanceReport '" + companyId + "', '" + financialYearId + "'").ToListAsync();
                return result;
            }
        }

        public async Task<List<ChildLedgerSPModel>> GetLedgerChildReport(string companyId, string finanialYearId, string ledgerId, int partyType = 0)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var result = await _databaseContext.SPLedgerChildReport.FromSqlRaw("GetLedgerChildReport '" + companyId + "', '" + finanialYearId + "', '" + ledgerId + "', " + partyType).ToListAsync();
                return result;
            }
        }
    }
}