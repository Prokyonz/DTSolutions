using EFCore.SQL.DBContext;
using EFCore.SQL.Interface;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.SQL.Repository
{
    public class SizeMasterRepository : ISizeMaster
    {
        private readonly DatabaseContext _databaseContext;

        public SizeMasterRepository()
        {
            _databaseContext = new DatabaseContext();
        }

        public async Task<List<SizeMaster>> GetAllSizeAsync()
        {
            return await _databaseContext.SizeMaster.Where(s => s.IsDelete == false).ToListAsync();
        }

        public async Task<SizeMaster> AddSizeAsync(SizeMaster sizeMaster)
        {
            await _databaseContext.SizeMaster.AddAsync(sizeMaster);
            await _databaseContext.SaveChangesAsync();
            return sizeMaster;
        }

        public async Task<bool> DeleteSizeAsync(int purityId, bool isPermanantDetele = false)
        {
            var getSize = await _databaseContext.SizeMaster.Where(s => s.Id == purityId).FirstOrDefaultAsync();
            if (getSize != null)
            {
                if (isPermanantDetele)
                    _databaseContext.SizeMaster.Remove(getSize);
                else
                    getSize.IsDelete = true;
                await _databaseContext.SaveChangesAsync();

                return true;
            }
            
            return false;
        }

        public async Task<SizeMaster> UpdateSizeAsync(SizeMaster sizeMaster)
        {
            var getSize = await _databaseContext.SizeMaster.Where(s => s.Id == sizeMaster.Id).FirstOrDefaultAsync();
            if (getSize  != null)
            {
                getSize.Name = sizeMaster.Name;
                getSize.UpdatedDate = sizeMaster.UpdatedDate;
                getSize.UpdatedBy = sizeMaster.UpdatedBy;
            }
            await _databaseContext.SaveChangesAsync();
            return sizeMaster;
        }
    }
}
