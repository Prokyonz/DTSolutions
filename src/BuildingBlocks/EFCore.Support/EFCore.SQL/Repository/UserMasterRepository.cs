using EFCore.SQL.DBContext;
using EFCore.SQL.Interface;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.SQL.Repository
{
    public class UserMasterRepository: IUserMaster
    {
        private readonly DatabaseContext _databaseContext;

        public UserMasterRepository()
        {
            _databaseContext = new DatabaseContext();
        }

        public async Task<UserMaster> AddUserAsync(UserMaster userMaster)
        {
            await _databaseContext.UserMaster.AddAsync(userMaster);
            return userMaster;
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            var getUser = await _databaseContext.UserMaster.Where(s => s.Id == userId).FirstOrDefaultAsync();
            if(getUser != null)
            {
                getUser.IsDetele = true;
            }
            await _databaseContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<UserMaster>> GetAllUserAsync()
        {
            return await _databaseContext.UserMaster.Where(s => s.IsDetele == false).ToListAsync();
        }

        public async Task<UserMaster> UpdateUserAsync(UserMaster userMaster)
        {
            var getUser = await _databaseContext.UserMaster.Where(s => s.Id == userMaster.Id).FirstOrDefaultAsync();
            if (getUser != null)
            {                
                getUser.Name = userMaster.Name;
                getUser.EmailId = userMaster.EmailId;
                getUser.Type = userMaster.Type;
                getUser.Address = userMaster.Address;
                getUser.Address2 = userMaster.Address2;
                getUser.MobileNo = userMaster.MobileNo;
                getUser.HomeNo = userMaster.HomeNo;
                getUser.ReferenceBy = userMaster.ReferenceBy;
                getUser.AadharCardNo = userMaster.AadharCardNo;                
                getUser.UpdateDate = userMaster.UpdateDate;
                getUser.UpdatedBy = userMaster.UpdatedBy;
            }
            await _databaseContext.SaveChangesAsync();
            return userMaster;
        }
    }
}
