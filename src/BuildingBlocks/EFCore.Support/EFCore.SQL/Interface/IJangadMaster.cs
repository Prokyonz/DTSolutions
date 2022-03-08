using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface IJangadMaster
    {
        Task<List<JangadMaster>> GetAllJangadAsync(string companyId, string financialYearId, int entryType);
        Task<int> GetMaxSrNoAsync(string companyId, string financialYearId, int entryType);
        Task<JangadMaster> AddJangadAsync(JangadMaster jangadMaster);
        Task<JangadMaster[]> UpdateJangadAsync(JangadMaster[] jangadMaster);
        Task<bool> DeleteJangadAsync(string jangadId);
    }
}
