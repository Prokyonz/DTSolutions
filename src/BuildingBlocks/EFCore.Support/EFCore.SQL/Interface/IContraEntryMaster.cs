using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface IContraEntryMaster
    {
        Task<List<ContraEntryMaster>> GetAllContraEntryAsync(Guid companyId, Guid financialYearId);
        Task<int> GetMaxNo(Guid companyId, Guid financialYearId);
        Task<ContraEntryMaster> AddContraEntryAsync(ContraEntryMaster contraEntryMaster);
        Task<ContraEntryMaster> UpdateContraEntryAsync(ContraEntryMaster contraEntryMaster);
        Task<bool> DeleteContraEntryAsync(Guid contraEntryId);        
    }
}
