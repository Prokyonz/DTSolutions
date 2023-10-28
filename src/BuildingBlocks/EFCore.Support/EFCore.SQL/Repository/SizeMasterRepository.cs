using EFCore.SQL.DBContext;
using EFCore.SQL.Interface;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.SQL.Repository
{
    public class SizeMasterRepository : ISizeMaster
    {
        private DatabaseContext _databaseContext;

        public SizeMasterRepository()
        {

        }

        public async Task<List<SizeMaster>> GetAllSizeAsync()
        {
            using (_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.SizeMaster.Where(s => s.IsDelete == false).ToListAsync();
            }
        }

        public async Task<SizeMaster> AddSizeAsync(SizeMaster sizeMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                if (sizeMaster.Id == null)
                    sizeMaster.Id = Guid.NewGuid().ToString();
                await _databaseContext.SizeMaster.AddAsync(sizeMaster);
                await _databaseContext.SaveChangesAsync();
                return sizeMaster;
            }
        }

        public async Task<int> DeleteSizeAsync(string sizeId, bool isPermanantDetele = false)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var resultCount = await _databaseContext.SPValidationModel.FromSqlRaw($"Validate_Records '" + sizeId + "',5").ToListAsync();
                return resultCount[0].Status;

                //var getSize = await _databaseContext.SizeMaster.Where(s => s.Id == purityId).FirstOrDefaultAsync();
                //if (getSize != null)
                //{
                //    if (isPermanantDetele)
                //        _databaseContext.SizeMaster.Remove(getSize);
                //    else
                //        getSize.IsDelete = true;
                //    await _databaseContext.SaveChangesAsync();

                //    return true;
                //}

                //return false;
            }
        }

        public async Task<SizeMaster> UpdateSizeAsync(SizeMaster sizeMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getSize = await _databaseContext.SizeMaster.Where(s => s.Id == sizeMaster.Id).FirstOrDefaultAsync();
                if (getSize != null)
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
}
