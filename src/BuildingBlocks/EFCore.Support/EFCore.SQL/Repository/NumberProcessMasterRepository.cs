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
    public class NumberProcessMasterRepository : INumberProcessMaster
    {
        private DatabaseContext _databaseContext;

        public NumberProcessMasterRepository()
        {

        }
        public async Task<NumberProcessMaster> AddNumberProcessAsync(NumberProcessMaster numberProcessMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                if (numberProcessMaster.Id == null)
                    numberProcessMaster.Id = Guid.NewGuid().ToString();

                await _databaseContext.NumberProcessMaster.AddAsync(numberProcessMaster);
                await _databaseContext.SaveChangesAsync();

                return numberProcessMaster;
            }
        }

        public async Task<bool> DeleteNumberProcessAsync(string numberProcessMasterId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getReccord = await _databaseContext.NumberProcessMaster.Where(w => w.Id == numberProcessMasterId).FirstOrDefaultAsync();
                if (getReccord == null)
                {
                    _databaseContext.NumberProcessMaster.Remove(getReccord);
                    await _databaseContext.SaveChangesAsync();

                    return true;
                }

                return false;
            }
        }

        public async Task<int> GetMaxSrNoAsync(string companyId, string branchId, string financialYearId, int numberProcessType)
        {
            try
            {
                using (_databaseContext = new DatabaseContext())
                {
                    var getCount = await _databaseContext.NumberProcessMaster.Where(m => m.CompanyId == companyId && m.BranchId == branchId && m.FinancialYearId == financialYearId && m.NumberProcessType == numberProcessType).MaxAsync(m => m.JangadNo);
                    return getCount + 1;
                }
            }
            catch (Exception ex)
            {
                return 1;
            }
        }

        public async Task<List<NumberProcessMaster>> GetNumberProcessAsync(string companyId, string branchId, string financialYearId, int numberProcessType)
        {
            using (_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.NumberProcessMaster.Where(w => w.CompanyId == companyId && w.BranchId == branchId && w.FinancialYearId == financialYearId && w.NumberProcessType == numberProcessType).ToListAsync();
            }
        }

        public async Task<NumberProcessMaster> UpdateNumberProcessAsync(NumberProcessMaster numberProcessMaste)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getRecord = await _databaseContext.NumberProcessMaster.Where(w => w.Id == numberProcessMaste.Id).FirstOrDefaultAsync();

                if (getRecord != null)
                {
                    getRecord.NumberCategoy = numberProcessMaste.NumberCategoy;
                    getRecord.NumberProcessType = numberProcessMaste.NumberProcessType;
                    getRecord.BranchId = numberProcessMaste.BranchId;
                    getRecord.CompanyId = numberProcessMaste.CompanyId;
                    getRecord.EntryDate = numberProcessMaste.EntryDate;
                    getRecord.FinancialYearId = numberProcessMaste.FinancialYearId;
                    getRecord.HandOverById = numberProcessMaste.HandOverById;
                    getRecord.HandOverToId = numberProcessMaste.HandOverToId;
                    getRecord.IsDelete = false;
                    getRecord.JangadNo = numberProcessMaste.JangadNo;
                    getRecord.KapanId = numberProcessMaste.KapanId;
                    getRecord.LossWeight = numberProcessMaste.LossWeight;
                    getRecord.RejectionWeight = numberProcessMaste.RejectionWeight;
                    getRecord.Remarks = numberProcessMaste.Remarks;
                    getRecord.ShapeId = numberProcessMaste.ShapeId;
                    getRecord.SizeId = numberProcessMaste.SizeId;
                    getRecord.PurityId = numberProcessMaste.PurityId;
                    getRecord.SlipNo = numberProcessMaste.SlipNo;
                    getRecord.UpdatedBy = numberProcessMaste.UpdatedBy;
                    getRecord.UpdatedDate = numberProcessMaste.UpdatedDate;
                    getRecord.Weight = numberProcessMaste.Weight;

                    await _databaseContext.SaveChangesAsync();
                }

                return numberProcessMaste;
            }
        }

        public async Task<List<NumberProcessSend>> GetNumberSendToDetails(string companyId, string branchId, string financialYearId)
        {
            try
            {
                using (_databaseContext = new DatabaseContext())
                {
                    var data = await _databaseContext.SPNumberProcessSend.FromSqlRaw($"GetNumberProcessSendToDetail '" + companyId + "', '" + branchId + "','" + financialYearId + "'").ToListAsync();

                    return data;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<NumberProcessReturn>> GetNumberReturnDetails(string companyId, string branchId, string financialYearId)
        {
            try
            {
                using (_databaseContext = new DatabaseContext())
                {
                    var data = await _databaseContext.SPNumberProcessReturn.FromSqlRaw($"GetNumberProcessReturnDetail '" + companyId + "', '" + branchId + "','" + financialYearId + "'").ToListAsync();

                    return data;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<NumberProcessReceive>> GetNumberReceiveDetails(string ReceiveFrom, string companyId, string branchId, string financialYearId)
        {
            try
            {
                using (_databaseContext = new DatabaseContext())
                {
                    var data = await _databaseContext.SPNumberProcessReceive.FromSqlRaw($"GetNumberProcessReceiveDetail '" + ReceiveFrom + "','" + companyId + "', '" + branchId + "','" + financialYearId + "'").ToListAsync();

                    return data;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<NumberProcessSendReceiveReportModel>> GetNumberSendReceiveReports(string companyId, string branchId, string financialYearId, int numberProcessType)
        {
            try
            {
                using (_databaseContext = new DatabaseContext())
                {
                    var data = await _databaseContext.SPNumberProcessSendReceiveReportModels.FromSqlRaw($"GetNumberSendReceiveReport '" + companyId + "', '" + branchId + "','" + financialYearId + "'," + numberProcessType).ToListAsync();

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
