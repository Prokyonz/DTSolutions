using EFCore.SQL.DBContext;
using EFCore.SQL.Interface;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.SQL.Repository
{
    public class GalaProcessMasterRepository : IGalaProcessMaster
    {
        private DatabaseContext _databaseContext;

        public GalaProcessMasterRepository()
        {
            
        }
        public async Task<GalaProcessMaster> AddGalaProcessAsync(GalaProcessMaster galaProcessMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                if (galaProcessMaster.Id == null)
                    galaProcessMaster.Id = Guid.NewGuid().ToString();

                await _databaseContext.GalaProcessMaster.AddAsync(galaProcessMaster);
                await _databaseContext.SaveChangesAsync();

                return galaProcessMaster;
            }
        }

        public async Task<bool> DeleteGalaProcessAsync(string galaProcessMasterId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getReccord = await _databaseContext.GalaProcessMaster.Where(w => w.Id == galaProcessMasterId).FirstOrDefaultAsync();
                if (getReccord == null)
                {
                    _databaseContext.GalaProcessMaster.Remove(getReccord);
                    await _databaseContext.SaveChangesAsync();

                    return true;
                }

                return false;
            }
        }

        public async Task<List<GalaProcessMaster>> GetGalaProcessAsync(string companyId, string branchId, string financialYearId, int galaProcessType)
        {
            using (_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.GalaProcessMaster.Where(w => w.CompanyId == companyId && w.BranchId == branchId && w.FinancialYearId == financialYearId && w.GalaProcessType == galaProcessType).ToListAsync();
            }
        }

        public async Task<int> GetMaxSrNoAsync(string companyId, string branchId, string financialYearId, int galaProcessType)
        {
            try
            {
                using (_databaseContext = new DatabaseContext())
                {
                    var getCount = await _databaseContext.GalaProcessMaster.Where(m => m.CompanyId == companyId && m.FinancialYearId == financialYearId && m.GalaProcessType == galaProcessType).MaxAsync(m => m.JangadNo);
                    return getCount + 1;
                }
            }
            catch (Exception ex)
            {
                return 1;
            }
        }

        public async Task<GalaProcessMaster> UpdateGalaProcessAsync(GalaProcessMaster galaProcessMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getRecord = await _databaseContext.GalaProcessMaster.Where(w => w.Id == galaProcessMaster.Id).FirstOrDefaultAsync();

                if (getRecord != null)
                {
                    getRecord.GalaCategoy = galaProcessMaster.GalaCategoy;
                    getRecord.GalaProcessType = galaProcessMaster.GalaProcessType;
                    getRecord.BranchId = galaProcessMaster.BranchId;
                    getRecord.CompanyId = galaProcessMaster.CompanyId;
                    getRecord.EntryDate = galaProcessMaster.EntryDate;
                    getRecord.FinancialYearId = galaProcessMaster.FinancialYearId;
                    getRecord.HandOverById = galaProcessMaster.HandOverById;
                    getRecord.HandOverToId = galaProcessMaster.HandOverToId;
                    getRecord.IsDelete = false;
                    getRecord.JangadNo = galaProcessMaster.JangadNo;
                    getRecord.KapanId = galaProcessMaster.KapanId;
                    getRecord.LossWeight = galaProcessMaster.LossWeight;
                    getRecord.RejectionWeight = galaProcessMaster.RejectionWeight;
                    getRecord.Remarks = galaProcessMaster.Remarks;
                    getRecord.ShapeId = galaProcessMaster.ShapeId;
                    getRecord.SizeId = galaProcessMaster.SizeId;
                    getRecord.PurityId = galaProcessMaster.PurityId;
                    getRecord.SlipNo = galaProcessMaster.SlipNo;
                    getRecord.UpdatedBy = galaProcessMaster.UpdatedBy;
                    getRecord.UpdatedDate = galaProcessMaster.UpdatedDate;
                    getRecord.Weight = galaProcessMaster.Weight;

                    await _databaseContext.SaveChangesAsync();
                }

                return galaProcessMaster;
            }
        }

        public async Task<List<GalaProcessSend>> GetGalaSendToDetails(string companyId, string branchId, string financialYearId)
        {
            try
            {
                using (_databaseContext = new DatabaseContext())
                {
                    var data = await _databaseContext.SPGalaProcessSend.FromSqlRaw($"GetGalaProcessSendToDetail '" + companyId + "', '" + branchId + "','" + financialYearId + "'").ToListAsync();

                    return data;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<GalaProcessReceive>> GetGalaReceiveDetails(string ReceiveFrom, string companyId, string branchId, string financialYearId)
        {
            try
            {
                using (_databaseContext = new DatabaseContext())
                {
                    var data = await _databaseContext.SPGalaProcessReceive.FromSqlRaw($"GetGalaProcessReceiveDetail '" + ReceiveFrom + "','" + companyId + "', '" + branchId + "','" + financialYearId + "'").ToListAsync();

                    return data;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
