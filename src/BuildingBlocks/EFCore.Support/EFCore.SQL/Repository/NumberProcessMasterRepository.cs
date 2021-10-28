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
                    var getCount = await _databaseContext.NumberProcessMaster.Where(m => m.CompanyId == companyId && m.BranchId == branchId && m.FinancialId == financialYearId && m.NumberProcessType == numberProcessType).MaxAsync(m => m.Sr);
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
                return await _databaseContext.NumberProcessMaster.Where(w => w.CompanyId == companyId && w.BranchId == branchId && w.FinancialId == financialYearId && w.NumberProcessType == numberProcessType).ToListAsync();
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
                    getRecord.FinancialId = numberProcessMaste.FinancialId;
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
                    getRecord.SlipNo = numberProcessMaste.SlipNo;
                    getRecord.UpdatedBy = numberProcessMaste.UpdatedBy;
                    getRecord.UpdatedDate = numberProcessMaste.UpdatedDate;
                    getRecord.Weight = numberProcessMaste.Weight;

                    await _databaseContext.SaveChangesAsync();
                }

                return numberProcessMaste;
            }
        }
    }
}
