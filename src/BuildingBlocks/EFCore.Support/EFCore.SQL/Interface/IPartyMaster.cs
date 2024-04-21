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
        Task<List<SPPartyMaster>> GetPartyMasterAsync(string companyId);
        Task<List<PartyMaster>> GetAllPartyAsync(string companyId, int partyTypeMaster);
        Task<List<PartyMaster>> GetAllPartyAsync(string companyId, int[] partyTypeMaster);
        Task<decimal> GetPartyBalance(string partyId, string companyId, string financialYearId);
        Task<PartyMaster> AddPartyAsync(PartyMaster partyMaster);
        Task<PartyMaster> UpdatePartyAsync(PartyMaster partyMaster);
        Task<int> DeletePartyAsync(string partyId, bool isPermanantDetele = false);
        Task<List<LedgerBalanceSPModel>> GetLedgerReport(string companyId, string financialYearId);
        Task<List<ChildLedgerSPModel>> GetLedgerChildReport(string companyId, string finanialYearId, string ledgerId, int partyType = 0);
    }
}
