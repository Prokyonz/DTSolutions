using EFCore.SQL.DBContext;
using EFCore.SQL.Interface;
using EFCore.SQL.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.SQL.Repository
{
    public class UserMasterRepository : IUserMaster
    {
        private DatabaseContext _databaseContext;

        public UserMasterRepository()
        {
            
        }

        public async Task<UserMaster> AddUserAsync(UserMaster userMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                if (userMaster.Id == null)
                    userMaster.Id = Guid.NewGuid().ToString();
                await _databaseContext.UserMaster.AddAsync(userMaster);

                //await _databaseContext.UserPermissionDetail.AddRangeAsync(userMaster.UserPermissionDetails);

                await _databaseContext.SaveChangesAsync();

                return userMaster;
            }
        }

        public async Task<bool> DeleteUserAsync(string userId, bool isPermanantDetele = false)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getUser = await _databaseContext.UserMaster.Where(s => s.Id == userId).FirstOrDefaultAsync();
                if (getUser != null)
                {
                    if (isPermanantDetele)
                        _databaseContext.UserMaster.Remove(getUser);
                    else
                        getUser.IsDelete = true;
                }
                await _databaseContext.SaveChangesAsync();

                return true;
            }
        }

        public async Task<List<PermissionMaster>> GetAllPermissions()
        {
            using (_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.PermissionMaster.ToListAsync();
            }
        }

        //public async Task<List<RoleClaimMaster>> GetAllClaims(string userId)
        //{
        //    return await _databaseContext.RoleClaimMaster.ToListAsync();
        //}

        public async Task<List<UserMaster>> GetAllUserAsync()
        {
            using (_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.UserMaster.Where(s => s.IsDelete == false).ToListAsync();
            }
        }

        public async Task<List<UserPermissionChild>> GetUserPermissions(string userId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.UserPermissionChild.Where(w => w.UserId == userId).ToListAsync();
            }

        }

        public async Task<LoginResponse> Login(string userId, string password)
        {
            using (_databaseContext = new DatabaseContext())
            {
                LoginResponse loginResponse = new LoginResponse();
                loginResponse.UserMaster = await _databaseContext.UserMaster.Where(w => w.UserName == userId && w.Password == password && w.IsDelete == false).Include("UserPermissionChilds").FirstOrDefaultAsync();
                if (loginResponse.UserMaster != null)
                {
                    //loginResponse.UserRoleMasters = await _databaseContext.UserRoleMaster.Where(w => w.UserId == loginResponse.UserMaster.Id).ToListAsync();

                    //if (loginResponse.UserRoleMasters.Count > 0) {
                    //    string roleId = loginResponse.UserRoleMasters[0].RoleId;
                    //    loginResponse.RoleClaimMasters = await _databaseContext.RoleClaimMaster.Where(w => w.RoleId == roleId).ToListAsync();
                    //}
                }

                return loginResponse;
            }
        }

        public async Task<UserMaster> UpdateUserAsync(UserMaster userMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getUser = await _databaseContext.UserMaster.Where(s => s.Id == userMaster.Id).FirstOrDefaultAsync();
                if (getUser != null)
                {
                    getUser.IsActive = userMaster.IsActive;
                    getUser.UserCode = userMaster.UserCode;
                    getUser.UserType = userMaster.UserType;
                    getUser.Name = userMaster.Name;
                    getUser.DepartmentName = userMaster.DepartmentName;
                    getUser.Designation = userMaster.Designation;
                    getUser.BrokerageId = userMaster.BrokerageId;
                    getUser.Address = userMaster.Address;
                    getUser.Address2 = userMaster.Address2;
                    getUser.MobileNo = userMaster.MobileNo;
                    getUser.HomeNo = userMaster.HomeNo;
                    getUser.ReferenceBy = userMaster.ReferenceBy;
                    getUser.AadharCardNo = userMaster.AadharCardNo;
                    getUser.DateOfBirth = userMaster.DateOfBirth;
                    getUser.DateOfJoin = userMaster.DateOfJoin;
                    getUser.DateOfEnd = userMaster.DateOfEnd;
                    getUser.AadharCardNo = userMaster.AadharCardNo;
                    getUser.UpdatedDate = userMaster.UpdatedDate;
                    getUser.UpdatedBy = userMaster.UpdatedBy;

                    if (userMaster.UserPermissionChilds != null)
                    {
                        var getAllPermisson = await _databaseContext.UserPermissionChild.Where(w => w.UserId == userMaster.Id).ToListAsync();
                        _databaseContext.UserPermissionChild.RemoveRange(getAllPermisson);
                    }

                    getUser.UserPermissionChilds = userMaster.UserPermissionChilds;

                    //await _databaseContext.UserPermissionDetail.AddRangeAsync(userMaster.UserPermissionDetails);
                }
                await _databaseContext.SaveChangesAsync();

                return userMaster;
            }
        }
    }
}
