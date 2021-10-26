using Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface IKapanMappingMaster
    {
        Task<List<KapanMappingMaster>> GetKapanMappingMaster(string companyId, string branchId, string financialYearId);
        Task<List<KapanMappingMaster>> GetPendingKapanMapping(string companyId, string branchId, string financialYearId);
        Task<KapanMappingMaster> AddKapanMappingAsync(KapanMappingMaster kapanMappingMaster);
        Task<KapanMappingMaster> UpdateKapanMappingMasterAsync(KapanMappingMaster kapanMappingMaster);
        Task<bool> DeleteKapanMappingAsync(string kapanMappingId);
    }
}
