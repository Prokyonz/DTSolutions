using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface IUserMaster
    {
        Task<List<UserMaster>> GetAllUserAsync();
        Task<UserMaster> AddUserAsync(UserMaster userMaster);
        Task<UserMaster> UpdateUserAsync(UserMaster userMaster);
        Task<bool> DeleteUserAsync(Guid userId, bool isPermanantDetele  = false);        
    }
}
