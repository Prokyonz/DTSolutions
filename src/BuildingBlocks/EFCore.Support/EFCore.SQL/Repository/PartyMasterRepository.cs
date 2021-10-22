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
        private readonly DatabaseContext _databaseContext;

        public PartyMasterRepository()
        {
            _databaseContext = new DatabaseContext();
        }

        public async Task<PartyMaster> AddPartyAsync(PartyMaster partyMaster)
        {
            if (partyMaster.Id == null)
                partyMaster.Id = Guid.NewGuid().ToString();
            await _databaseContext.PartyMaster.AddAsync(partyMaster);
            await _databaseContext.SaveChangesAsync();
            return partyMaster;
        }

        public async Task<bool> DeletePartyAsync(string partyId, bool isPermanantDetele = false)
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

        public async Task<List<PartyMaster>> GetAllPartyAsync()
        {
            return await _databaseContext.PartyMaster.Where(s => s.IsDelete == false).ToListAsync();
        }

        public async Task<List<PartyMaster>> GetPartyAsync(int Type)
        {
            return await _databaseContext.PartyMaster.Where(s => s.IsDelete == false && s.Type==Type).ToListAsync();
        }

        public async Task<PartyMaster> UpdatePartyAsync(PartyMaster partyMaster)
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
}
