using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface IPurityMaster
    {
        Task<PurityMaster> GetPurityById(Guid purityId, bool isDeleteInclude = false);
        Task<List<PurityMaster>> GetAllPurityAsync(bool isDeleteInclude = false);
        Task<PurityMaster> AddPurityAsync(PurityMaster purityMaster);
        Task<PurityMaster> UpdatePurityAsync(PurityMaster purityMaster);
        Task<bool> DeletePurityAsync(Guid purityId, bool isPermanantDetele = false);
    }
}
