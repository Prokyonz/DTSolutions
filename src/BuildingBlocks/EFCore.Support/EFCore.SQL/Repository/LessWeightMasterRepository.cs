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
    public class LessWeightMasterRepository : ILessWeightMaster
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

        public async Task<List<LessWeightMaster>> GetLessWeightMasters()
        {
            return await _databaseContext.LessWeightMasters.ToListAsync();
        }

        public async Task<LessWeightMaster> UpdateLessWeightMaster(LessWeightMaster lessWeightMaster)
        {
            var getLessWeightRecord = await _databaseContext.LessWeightMasters.Where(w => w.Id == lessWeightMaster.Id).FirstOrDefaultAsync();
            if (getLessWeightRecord != null)
            {
                getLessWeightRecord.Name = lessWeightMaster.Name;
                //getLessWeightRecord.LessWeight = lessWeightMaster.LessWeight;
                //getLessWeightRecord.MaxWeight = lessWeightMaster.MaxWeight;
                //getLessWeightRecord.MinWeight = lessWeightMaster.MinWeight;
                getLessWeightRecord.BranchId = lessWeightMaster.BranchId;

                await _databaseContext.SaveChangesAsync();
            }
            return lessWeightMaster;
        }
    }
}
