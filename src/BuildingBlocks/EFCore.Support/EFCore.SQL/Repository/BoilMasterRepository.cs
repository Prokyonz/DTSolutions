using EFCore.SQL.DBContext;
using EFCore.SQL.Interface;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Entities.Model;
using Repository.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.SQL.Repository
{
    public class BoilMasterRepository : IBoilMaster
    {
        private DatabaseContext _databaseContext;

        public BoilMasterRepository()
        {
            
        }
        public async Task<BoilProcessMaster> AddBoilAsync(BoilProcessMaster boilMaster)
        {
            using(_databaseContext = new DatabaseContext())
            {
                if (boilMaster.Id == null)
                    boilMaster.Id = Guid.NewGuid().ToString();

                await _databaseContext.BoilProcessMaster.AddAsync(boilMaster);
                await _databaseContext.SaveChangesAsync();

                return boilMaster;
            }
        }

        public async Task<bool> DeleteBoilAsync(string boilMasterId, string slipNo)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var findBoilReceiveRecord = await _databaseContext.BoilProcessMaster.Where(w => w.SlipNo.Contains("," + slipNo + ",") && w.BoilType == 1).ToListAsync();
                if (findBoilReceiveRecord.Any())                
                    return false;
                 else
                {
                    var getReccord = await _databaseContext.BoilProcessMaster.Where(w => w.Id == boilMasterId).FirstOrDefaultAsync();
                    if (getReccord != null)
                    {
                        _databaseContext.BoilProcessMaster.Remove(getReccord);
                        await _databaseContext.SaveChangesAsync();

                        return true;
                    }
                }

                return false;
            }
        }

        public async Task<List<BoilProcessMaster>> GetBoilAsync(string companyId, string branchId, string financialYearId, int boilType)
        {
            using (_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.BoilProcessMaster.Where(w => w.CompanyId == companyId && w.BranchId == branchId && w.FinancialYearId == financialYearId && w.BoilType == boilType).ToListAsync();
            }
        }

        public async Task<int> GetMaxSrNoAsync(string companyId, string branchId, string financialYearId, int boilTpe)
        {
            try
            {
                using (_databaseContext = new DatabaseContext())
                {
                    var getCount = await _databaseContext.BoilProcessMaster.Where(m => m.CompanyId == companyId && m.BranchId == branchId && m.FinancialYearId == financialYearId && m.BoilType == boilTpe).MaxAsync(m => m.JangadNo);
                    return getCount + 1;
                }
            }
            catch (Exception ex)
            {
                return 1;
            }
        }

        public async Task<BoilProcessMaster> UpdateBoilAsync(BoilProcessMaster boilMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getRecord = await _databaseContext.BoilProcessMaster.Where(w => w.Id == boilMaster.Id).FirstOrDefaultAsync();
                
                if(getRecord != null)
                {
                    getRecord.BoilCategoy = boilMaster.BoilCategoy;
                    getRecord.BoilType = boilMaster.BoilType;
                    getRecord.BranchId = boilMaster.BranchId;
                    getRecord.CompanyId = boilMaster.CompanyId;
                    getRecord.EntryDate = boilMaster.EntryDate;
                    getRecord.FinancialYearId = boilMaster.FinancialYearId;
                    getRecord.HandOverById = boilMaster.HandOverById;
                    getRecord.HandOverToId = boilMaster.HandOverToId;
                    getRecord.IsDelete = false;
                    getRecord.JangadNo = boilMaster.JangadNo;
                    getRecord.KapanId = boilMaster.KapanId;
                    getRecord.LossWeight = boilMaster.LossWeight;
                    getRecord.RejectionWeight = boilMaster.RejectionWeight;
                    getRecord.Remarks = boilMaster.Remarks;
                    getRecord.ShapeId = boilMaster.ShapeId;
                    getRecord.SizeId = boilMaster.SizeId;
                    getRecord.PurityId = boilMaster.PurityId;
                    getRecord.SlipNo = boilMaster.SlipNo;
                    getRecord.UpdatedBy = boilMaster.UpdatedBy;
                    getRecord.UpdatedDate = boilMaster.UpdatedDate;
                    getRecord.Weight = boilMaster.Weight;

                    await _databaseContext.SaveChangesAsync();
                }

                return boilMaster;
            }
        }

        public async Task<List<BoilProcessSend>> GetBoilSendToDetails(string companyId, string branchId, string financialYearId)
        {
            try
            {
                using (_databaseContext = new DatabaseContext())
                {
                    var data = await _databaseContext.SPBoilProcessSend.FromSqlRaw($"GetBoilProcessSendToDetail '" + companyId + "', '" + branchId + "','" + financialYearId + "'").ToListAsync();

                    return data;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<BoilProcessReceive>> GetBoilReceiveToDetails(string ReceivedFromId, string companyId, string branchId, string financialYearId)
        {
            try
            {
                using (_databaseContext = new DatabaseContext())
                {
                    var data = await _databaseContext.SPBoilProcessReceive.FromSqlRaw($"GetBoilProcessReceiveDetail '" + ReceivedFromId + "','" + companyId + "', '" + branchId + "','" + financialYearId + "'").ToListAsync();

                    return data;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<BoilSendReceiveReportModel>> GetBoilSendReceiveReports(string companyId, string branchId, string financialYearId, int boilType)
        {
            try
            {
                using (_databaseContext = new DatabaseContext())
                {
                    var data = await _databaseContext.SPBoilSendReceiveReportModels.FromSqlRaw($"GetBoilSendReceiveReport '" + companyId + "', '" + branchId + "','" + financialYearId + "'," + boilType).ToListAsync();

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
