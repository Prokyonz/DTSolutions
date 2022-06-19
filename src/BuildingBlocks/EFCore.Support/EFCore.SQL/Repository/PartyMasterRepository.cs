using EFCore.SQL.DBContext;
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

        public PartyMasterRepository()
        {

        }

        public async Task<PartyMaster> AddPartyAsync(PartyMaster partyMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                if (partyMaster.Id == null)
                    partyMaster.Id = Guid.NewGuid().ToString();
                await _databaseContext.PartyMaster.AddAsync(partyMaster);
                await _databaseContext.SaveChangesAsync();
                return partyMaster;
            }
        }

        public async Task<bool> DeletePartyAsync(string partyId, bool isPermanantDetele = false)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getParty = await _databaseContext.PartyMaster.Where(s => s.Id == partyId).FirstOrDefaultAsync();
                if (getParty != null)
                {
                    if (isPermanantDetele)
                        _databaseContext.PartyMaster.Remove(getParty);
                    else
                        getParty.IsDelete = true;

                    await _databaseContext.SaveChangesAsync();
                    return true;
                }                
            }
            return false;
        }

        public async Task<List<PartyMaster>> GetAllPartyAsync()
        {
            List<PartyMaster> partyMasters;
            using (_databaseContext = new DatabaseContext())
            {
                var result = await _databaseContext.LedgerBalanceManager.ToListAsync();

                partyMasters =  await _databaseContext.PartyMaster.Where(s => s.IsDelete == false).ToListAsync();
                foreach (var item in partyMasters)
                {
                    var getBalance = result.Where(w => w.LedgerId == item.Id).FirstOrDefault();

                    if(getBalance != null)
                    {
                        item.OpeningBalance = getBalance.Balance;
                    } else
                    {
                        item.OpeningBalance = 0;
                    }
                }                
            }
            return partyMasters;
        }

        public async Task<List<PartyMaster>> GetAllPartyAsync(string companyId)
        {
            List<PartyMaster> partyMasters;
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
            return partyMasters;
        }

        public async Task<List<PartyMaster>> GetAllPartyAsync(string companyId, int partyTypeMaster)
        {
            List<PartyMaster> partyMasters;
            using (_databaseContext = new DatabaseContext())
            {
                var result = await _databaseContext.LedgerBalanceManager.ToListAsync();

                partyMasters = await _databaseContext.PartyMaster.Where(s => s.CompanyId == companyId && s.IsDelete == false && s.Type == partyTypeMaster).ToListAsync();
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
            return partyMasters;
        }

        public async Task<List<PartyMaster>> GetAllPartyAsync(string companyId, int[] partyTypeMaster)
        {
            List<PartyMaster> partyMasters;
            using (_databaseContext = new DatabaseContext())
            {
                var result = await _databaseContext.LedgerBalanceManager.ToListAsync();

                partyMasters = await _databaseContext.PartyMaster.Where(w => w.CompanyId == companyId && w.IsDelete == false && partyTypeMaster.Contains(w.Type)).ToListAsync();
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
            return partyMasters;
        }
        public async Task<List<PartyMaster>> GetAllPartyAsync(string companyId, int partTypeMaster, int subType)
        {
            List<PartyMaster> partyMasters;
            using (_databaseContext = new DatabaseContext())
            {
                var result = await _databaseContext.LedgerBalanceManager.ToListAsync();

                partyMasters = await _databaseContext.PartyMaster.Where(w => w.CompanyId == companyId && w.IsDelete == false && w.Type == partTypeMaster && w.SubType == subType).ToListAsync();
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
            return partyMasters;
        }

        public async Task<List<PartyMaster>> GetPartyAsync()
        {
            List<PartyMaster> partyMasters;
            using (_databaseContext = new DatabaseContext())
            {
                var result = await _databaseContext.LedgerBalanceManager.ToListAsync();

                partyMasters = await _databaseContext.PartyMaster.Where(s => s.IsDelete == false && s.Type == PartyTypeMaster.Party).ToListAsync();
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
            return partyMasters;
        }

        public async Task<PartyMaster> UpdatePartyAsync(PartyMaster partyMaster)
        {
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
                    getParty.OpeningBalance = partyMaster.OpeningBalance;
                    getParty.AadharCardNo = partyMaster.AadharCardNo;
                    getParty.UpdatedDate = partyMaster.UpdatedDate;
                    getParty.UpdatedBy = partyMaster.UpdatedBy;
                }
                await _databaseContext.SaveChangesAsync();
                return partyMaster;
            }
        }

        public async Task<decimal> GetPartyBalance(string partyId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var result = await _databaseContext.LedgerBalanceManager.Where(w => w.LedgerId == partyId).FirstOrDefaultAsync();
                if (result != null)
                    return result.Balance;
                return 0;
            }
        }

        public async Task<List<LedgerBalanceSPModel>> GetLedgerReport(string companyId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var result = await _databaseContext.SPLedgerBalanceReport.FromSqlRaw("GetLedgerBalanceReport '" + companyId + "'").ToListAsync();
                return result;
            }
        }
    }
}