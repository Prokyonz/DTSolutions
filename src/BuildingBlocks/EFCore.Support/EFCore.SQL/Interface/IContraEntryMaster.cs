using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface IContraEntryMaster
    {
        Task<List<ContraEntryMaster>> GetAllContraEntryAsync(string companyId, string financialYearId);
        Task<int> GetMaxNo(string companyId, string financialYearId);
        Task<ContraEntryMaster> AddContraEntryAsync(ContraEntryMaster contraEntryMaster);
        Task<ContraEntryMaster> UpdateContraEntryAsync(ContraEntryMaster contraEntryMaster);
        Task<bool> DeleteContraEntryAsync(string contraEntryId);        
    }
}
