﻿using EFCore.SQL.DBContext;
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
        private DatabaseContext _databaseContext;

        public LessWeightMasterRepository()
        {            
        }

        public async Task<LessWeightMaster> AddLessWeightMaster(LessWeightMaster lessWeightMaster)
        {
            using(_databaseContext = new DatabaseContext()) {
                if (lessWeightMaster.Id == null)
                    lessWeightMaster.Id = Guid.NewGuid().ToString();
                await _databaseContext.LessWeightMasters.AddAsync(lessWeightMaster);
                await _databaseContext.SaveChangesAsync();
                return lessWeightMaster;
            }
        }

        public async Task<int> DeleteLessWeightMaster(string lessWeightMasterId, bool isPermanantDelete = false)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var resultCount = await _databaseContext.SPValidationModel.FromSqlRaw($"Validate_Records '" + lessWeightMasterId + "',12").ToListAsync();
                return resultCount[0].Status;
                //var getLessWeightRecord = await _databaseContext.LessWeightMasters.Where(w => w.Id == lessWeightMasterId).FirstOrDefaultAsync();
                //if (getLessWeightRecord != null)
                //{
                //    _databaseContext.LessWeightMasters.Remove(getLessWeightRecord);
                //    await _databaseContext.SaveChangesAsync();
                //    return true;
                //}
                //return false;
            }
        }

        public async Task<List<LessWeightMaster>> GetLessWeightMasters()
        {
            using (_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.LessWeightMasters.Where(w => w.IsDelete == false).Include("LessWeightDetails").ToListAsync();
            }
        }

        public async Task<LessWeightDetails> GetLessWeightDetailsMasters(string Id, decimal Weight)
        {
            using (_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.LessWeightDetails.Where(w => w.LessWeightId == Id && w.MinWeight <= Weight && w.MaxWeight >= Weight).FirstOrDefaultAsync();
            }
        }

        public async Task<LessWeightMaster> UpdateLessWeightMaster(LessWeightMaster lessWeightMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                try
                {
                    var getLessWeightRecord = await _databaseContext.LessWeightMasters.Where(w => w.Id == lessWeightMaster.Id).Include("LessWeightDetails").FirstOrDefaultAsync();
                    if (getLessWeightRecord != null)
                    {
                        getLessWeightRecord.Name = lessWeightMaster.Name;
                        getLessWeightRecord.IsDelete = lessWeightMaster.IsDelete;
                        getLessWeightRecord.CreatedDate = lessWeightMaster.CreatedDate;
                        getLessWeightRecord.UpdatedDate = lessWeightMaster.UpdatedDate;

                        _databaseContext.LessWeightDetails.RemoveRange(getLessWeightRecord.LessWeightDetails);

                        await _databaseContext.LessWeightDetails.AddRangeAsync(lessWeightMaster.LessWeightDetails);

                        await _databaseContext.SaveChangesAsync();
                    }
                    return lessWeightMaster;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
}
