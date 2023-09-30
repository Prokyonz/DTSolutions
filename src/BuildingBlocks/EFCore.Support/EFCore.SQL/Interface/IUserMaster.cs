using EFCore.SQL.Models;
using Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface ICommon
    {
        bool DBTest();        
    }

    public interface IUserMaster : ICommon
    {
        Task<LoginResponse> Login(string userId, string password);
        Task<List<PermissionMaster>> GetAllPermissions();
        Task<List<UserPermissionChild>> GetUserPermissions(string userId);
        Task<List<UserMaster>> GetAllUserAsync();
        Task<UserMaster> AddUserAsync(UserMaster userMaster);
        Task<UserMaster> UpdateUserAsync(UserMaster userMaster);
        Task<bool> DeleteUserAsync(string userId, bool isPermanantDetele  = false);        
    }
}
