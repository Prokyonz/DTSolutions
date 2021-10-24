using EFCore.SQL.DBContext;
using EFCore.SQL.Interface;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
                return false;
            }

        }

        public async Task<List<PartyMaster>> GetAllPartyAsync()
        {
            using (_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.PartyMaster.Where(s => s.IsDelete == false).ToListAsync();
            }
        }

        public async Task<List<PartyMaster>> GetAllPartyAsync(string companyId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.PartyMaster.Where(s => s.IsDelete == false && s.CompanyId == companyId).ToListAsync();
            }
        }

        public async Task<List<PartyMaster>> GetAllPartyAsync(string companyId, int partyTypeMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.PartyMaster.Where(s => s.IsDelete == false && s.Type == partyTypeMaster).ToListAsync();
            }
        }

        public async Task<List<PartyMaster>> GetPartyAsync()
        {
            using (_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.PartyMaster.Where(s => s.IsDelete == false && s.Type == PartyTypeMaster.Party).ToListAsync();
            }
        }

        public async Task<List<PartyMaster>> GetEmployeeAsync(int SubType)
        {
            using (_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.PartyMaster.Where(s => s.IsDelete == false && s.Type == PartyTypeMaster.Employee && s.SubType == SubType).ToListAsync();
            }
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
                var result = await _databaseContext.PartyMaster.Where(w => w.Id == partyId).FirstOrDefaultAsync();
                if (result != null)
                    return result.OpeningBalance;
                return 0;
            }
        }        
    }
}
