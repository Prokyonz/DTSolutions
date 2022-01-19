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
        private readonly DatabaseContext _databaseContext;

        public UserMasterRepository()
        {
            _databaseContext = new DatabaseContext();
        }

        public async Task<UserMaster> AddUserAsync(UserMaster userMaster)
        {
            if (userMaster.Id == null)
                userMaster.Id = Guid.NewGuid().ToString();
            await _databaseContext.UserMaster.AddAsync(userMaster);
            await _databaseContext.SaveChangesAsync();
            return userMaster;
        }

        public async Task<bool> DeleteUserAsync(string userId, bool isPermanantDetele = false)
        {
            var getUser = await _databaseContext.UserMaster.Where(s => s.Id == userId).FirstOrDefaultAsync();            
            if(getUser != null)
            {
                if(isPermanantDetele)
                    _databaseContext.UserMaster.Remove(getUser);
                else
                    getUser.IsDelete = true;
            }
            await _databaseContext.SaveChangesAsync();
            return true;
        }

        //public async Task<List<RoleClaimMaster>> GetAllClaims(string userId)
        //{
        //    return await _databaseContext.RoleClaimMaster.ToListAsync();
        //}

        public async Task<List<UserMaster>> GetAllUserAsync()
        {
            return await _databaseContext.UserMaster.Where(s => s.IsDelete == false).ToListAsync();
        }

        public async Task<LoginResponse> Login(string userId, string password)
        {
            LoginResponse loginResponse  = new LoginResponse();

            loginResponse.UserMaster = await _databaseContext.UserMaster.Where(w => w.Name == userId && w.Password == password).FirstOrDefaultAsync();
            if(loginResponse.UserMaster != null) {
                //loginResponse.UserRoleMasters = await _databaseContext.UserRoleMaster.Where(w => w.UserId == loginResponse.UserMaster.Id).ToListAsync();

                //if (loginResponse.UserRoleMasters.Count > 0) {
                //    string roleId = loginResponse.UserRoleMasters[0].RoleId;
                //    loginResponse.RoleClaimMasters = await _databaseContext.RoleClaimMaster.Where(w => w.RoleId == roleId).ToListAsync();
                //}
            }
            return loginResponse;
        }

        public async Task<UserMaster> UpdateUserAsync(UserMaster userMaster)
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
            }
            await _databaseContext.SaveChangesAsync();
            return userMaster;
        }
    }
}
