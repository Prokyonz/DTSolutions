using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface IKapanMaster
    {
        Task<List<KapanMaster>> GetAllKapanAsync();
        Task<KapanMaster> AddKapanAsync(KapanMaster kapanMaster);
        Task<KapanMaster> UpdateKapanAsync(KapanMaster kapanMaster);
        Task<bool> DeleteKapanAsync(string kapanId, bool isPermanantDetele = false);
        Task<List<KapanMaster>> GetAssortProcessKapanDetails(string companyId, string branchId);
    }
}
