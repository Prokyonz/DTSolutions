using Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface IBoilMaster
    {
        Task<List<BoilMaster>> GetBoilAsync(string companyId, string branchId, string financialYearId, int boilType);
        Task<int> GetMaxSrNoAsync(string companyId, string branchId, string financialYearId, int boilTpe);
        Task<BoilMaster> AddBoilAsync(BoilMaster boilMaster);
        Task<BoilMaster> UpdateBoilAsync(BoilMaster boilMaster);
        Task<bool> DeleteBoilAsync(string boilMasterId);
    }
}
