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
    public class LessWeightMasterRepository : ILessWeightMaster, IDisposable
    {
        private readonly DatabaseContext _databaseContext;

        public LessWeightMasterRepository()
        {
            _databaseContext = new DatabaseContext();
        }

        public async Task<LessWeightMaster> AddLessWeightMaster(LessWeightMaster lessWeightMaster)
        {
            if (lessWeightMaster.Id == null)
                lessWeightMaster.Id = Guid.NewGuid();
            await _databaseContext.LessWeightMasters.AddAsync(lessWeightMaster);
            await _databaseContext.SaveChangesAsync();
            return lessWeightMaster;
        }

        public async Task<bool> DeleteLessWeightMaster(Guid lessWeightMasterId, bool isPermanantDelete = false)
        {
            var getLessWeightRecord = await _databaseContext.LessWeightMasters.Where(w => w.Id == lessWeightMasterId).FirstOrDefaultAsync();
            if (getLessWeightRecord != null)
            {
                _databaseContext.LessWeightMasters.Remove(getLessWeightRecord);
                await _databaseContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public void Dispose()
        {
            _databaseContext.DisposeAsync();
        }

        public async Task<List<LessWeightMaster>> GetLessWeightMasters()
        {
            return await _databaseContext.LessWeightMasters.Where(w=>w.IsDelete == false).Include("LessWeightDetails").ToListAsync();
        }

        public async Task<LessWeightMaster> UpdateLessWeightMaster(LessWeightMaster lessWeightMaster)
        {
            var getLessWeightRecord = await _databaseContext.LessWeightMasters.Where(w => w.Id == lessWeightMaster.Id).Include("LessWeightDetails").FirstOrDefaultAsync();
            if (getLessWeightRecord != null)
            {
                getLessWeightRecord.Name = lessWeightMaster.Name;
                getLessWeightRecord.IsDelete = lessWeightMaster.IsDelete;
                getLessWeightRecord.CreatedBy = lessWeightMaster.CreatedBy;
                getLessWeightRecord.UpdatedBy = lessWeightMaster.UpdatedBy;
                getLessWeightRecord.CreatedDate = lessWeightMaster.CreatedDate;
                getLessWeightRecord.UpdatedDate = lessWeightMaster.UpdatedDate;                
                getLessWeightRecord.BranchId = lessWeightMaster.BranchId;

                _databaseContext.LessWeightDetails.RemoveRange(getLessWeightRecord.LessWeightDetails.ToArray());

                await _databaseContext.LessWeightDetails.AddRangeAsync(lessWeightMaster.LessWeightDetails);
                
                await _databaseContext.SaveChangesAsync();
            }
            return lessWeightMaster;
        }
    }
}
