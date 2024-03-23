using Repository.Entities;
using Repository.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface IContraEntryMaster
    {
        Task<List<ContraEntryMaster>> GetAllContraEntryAsync(string companyId, string financialYearId);
        Task<List<ContraSPModel>> GetContraReport(string companyId, string financialYearId, string fromDate, string toDate);
        Task<ContraEntryMaster> GetContraEntryAsync(string companyId, string financialYearId, int Id);
        Task<int> GetMaxNo(string companyId, string financialYearId);
        Task<ContraEntryMaster> AddContraEntryAsync(ContraEntryMaster contraEntryMaster);
        Task<ContraEntryMaster> UpdateContraEntryAsync(ContraEntryMaster contraEntryMaster);
        Task<bool> DeleteContraEntryAsync(int SrNo, string companyId, string financialYearId);        
    }
}
