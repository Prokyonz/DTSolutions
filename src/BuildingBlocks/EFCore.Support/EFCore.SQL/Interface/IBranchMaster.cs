using Repository.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface IBranchMaster
    {
        Task<List<BranchMaster>> GetAllBranchAsync(int companyId);
        Task<BranchMaster> AddBranchAsync(BranchMaster branchMaster);
        Task<BranchMaster> UpdateBranchAsync(BranchMaster branchMaster);
        Task<bool> DeleteBranchAsync(int branchId);
    }
}
