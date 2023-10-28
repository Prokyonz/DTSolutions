using EFCore.SQL.Models;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface IUserMaster
    {
        Task<LoginResponse> Login(string userId, string password);
        Task<List<PermissionMaster>> GetAllPermissions();
        Task<List<UserPermissionChild>> GetUserPermissions(string userId);
        Task<List<UserMaster>> GetAllUserAsync();
        Task<UserMaster> AddUserAsync(UserMaster userMaster);
        Task<UserMaster> UpdateUserAsync(UserMaster userMaster);
        Task<int> DeleteUserAsync(string userId, bool isPermanantDetele  = false);        
    }
}
