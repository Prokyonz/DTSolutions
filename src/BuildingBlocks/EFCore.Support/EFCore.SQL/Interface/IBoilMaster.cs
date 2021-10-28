using Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface IBoilMaster
    {
        Task<List<BoilProcessMaster>> GetBoilAsync(string companyId, string branchId, string financialYearId, int boilType);
        Task<int> GetMaxSrNoAsync(string companyId, string branchId, string financialYearId, int boilTpe);
        Task<BoilProcessMaster> AddBoilAsync(BoilProcessMaster boilMaster);
        Task<BoilProcessMaster> UpdateBoilAsync(BoilProcessMaster boilMaster);
        Task<bool> DeleteBoilAsync(string boilMasterId);
    }
}
