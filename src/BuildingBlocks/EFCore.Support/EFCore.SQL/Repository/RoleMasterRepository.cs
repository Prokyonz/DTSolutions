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
    public class RoleMasterRepository : IRoleMaster
    {
        private readonly DatabaseContext _databaseContext;

        public RoleMasterRepository()
        {
            _databaseContext = new DatabaseContext();
        }
        public async Task<RoleMaster> AddRoleAsync(RoleMaster roleMaster)
        {
            if (roleMaster.Id == null)
                roleMaster.Id = Guid.NewGuid().ToString();
            await _databaseContext.RoleMaster.AddAsync(roleMaster);
            await _databaseContext.SaveChangesAsync();
            return roleMaster;
        }

        public async Task<bool> DeleteRoleAsync(string roleId, bool isPermanantDetele = false)
        {
            var getRole = await _databaseContext.RoleMaster.Where(s => s.Id == roleId).FirstOrDefaultAsync();
            if (getRole != null)
            {
                if (isPermanantDetele)
                    _databaseContext.RoleMaster.Remove(getRole);
                else
                    getRole.Isdelete = true;
            }
            await _databaseContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<RoleMaster>> GetAllRoleAsync()
        {
            return await _databaseContext.RoleMaster.Where(s => s.Isdelete == false).ToListAsync();
        }

        public async Task<RoleMaster> UpdateRoleAsync(RoleMaster roleMaster)
        {
            var getRole = await _databaseContext.RoleMaster.Where(s => s.Id == roleMaster.Id).FirstOrDefaultAsync();
            if (getRole != null)
            {
                getRole.Name = roleMaster.Name;
                getRole.Description = roleMaster.Description;
                getRole.UpdatedDate = roleMaster.UpdatedDate;
                getRole.UpdatedBy = roleMaster.UpdatedBy;
            }
            await _databaseContext.SaveChangesAsync();
            return roleMaster;
        }
    }
}
