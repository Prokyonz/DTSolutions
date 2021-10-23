using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface IPartyMaster
    {        

        Task<List<PartyMaster>> GetAllPartyAsync();
        Task<decimal> GetPartyBalance(string partyId);
        Task<PartyMaster> AddPartyAsync(PartyMaster partyMaster);
        Task<PartyMaster> UpdatePartyAsync(PartyMaster partyMaster);
        Task<bool> DeletePartyAsync(string partyId, bool isPermanantDetele = false);
    }
}
