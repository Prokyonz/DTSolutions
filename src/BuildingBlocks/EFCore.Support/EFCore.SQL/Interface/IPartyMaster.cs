using Repository.Entities;
using Repository.Entities.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface IPartyMaster
    {
        Task<List<PartyMaster>> GetAllPartyAsync();
        Task<List<PartyMaster>> GetAllPartyAsync(string companyId);
        Task<List<PartyMaster>> GetAllPartyAsync(string companyId, int partyTypeMaster);
        Task<List<PartyMaster>> GetAllPartyAsync(string companyId, int[] partyTypeMaster);
        Task<decimal> GetPartyBalance(string partyId);
        Task<PartyMaster> AddPartyAsync(PartyMaster partyMaster);
        Task<PartyMaster> UpdatePartyAsync(PartyMaster partyMaster);
        Task<bool> DeletePartyAsync(string partyId, bool isPermanantDetele = false);
        Task<List<LedgerBalanceSPModel>> GetLedgerReport(string companyId);
    }
}
