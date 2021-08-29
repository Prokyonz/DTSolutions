using Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface IPurityMaster
    {
        Task<List<PurityMaster>> GetAllPurityAsync();
        Task<PurityMaster> AddPurityAsync(PurityMaster purityMaster);
        Task<PurityMaster> UpdatePurityAsync(PurityMaster purityMaster);
        Task<bool> DeletePurityAsync(int purityId, bool isPermanantDetele = false);
    }
}
