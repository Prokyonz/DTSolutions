using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface IRoleMaster
    {
        Task<List<RoleMaster>> GetAllRoleAsync();
        Task<RoleMaster> AddRoleAsync(RoleMaster roleMaster);
        Task<RoleMaster> UpdateRoleAsync(RoleMaster roleMaster);
        Task<bool> DeleteRoleAsync(string roleId, bool isPermanantDetele = false);
    }
}
