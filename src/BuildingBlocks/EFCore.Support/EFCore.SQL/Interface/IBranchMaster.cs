using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface IBranchMaster
    {
        Task<List<BranchMaster>> GetAllBranchAsync();
        Task<BranchMaster> AddBranchAsync(BranchMaster branchMaster);
        Task<BranchMaster> UpdateBranchAsync(BranchMaster branchMaster);
        Task<bool> DeleteBranchAsync(Guid branchId);
    }
}
