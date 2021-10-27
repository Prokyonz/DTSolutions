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
    public class BoilMasterRepository : IBoilMaster
    {
        private DatabaseContext _databaseContext;

        public BoilMasterRepository()
        {
            
        }
        public async Task<BoilMaster> AddBoilAsync(BoilMaster boilMaster)
        {
            using(_databaseContext = new DatabaseContext())
            {
                if (boilMaster.Id == null)
                    boilMaster.Id = Guid.NewGuid().ToString();

                await _databaseContext.BoilMaster.AddAsync(boilMaster);
                await _databaseContext.SaveChangesAsync();

                return boilMaster;
            }
        }

        public async Task<bool> DeleteBoilAsync(string boilMasterId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getReccord = await _databaseContext.BoilMaster.Where(w => w.Id == boilMasterId).FirstOrDefaultAsync();
                if(getReccord == null)
                {
                    _databaseContext.BoilMaster.Remove(getReccord);
                    await _databaseContext.SaveChangesAsync();

                    return true;
                }

                return false;
            }
        }

        public async Task<List<BoilMaster>> GetBoilAsync(string companyId, string branchId, string financialYearId, int boilType)
        {
            using (_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.BoilMaster.Where(w => w.CompanyId == companyId && w.BranchId == branchId && w.FinancialId == financialYearId && w.BoilType == boilType).ToListAsync();
            }
        }

        public async Task<int> GetMaxSrNoAsync(string companyId, string branchId, string financialYearId, int boilTpe)
        {
            try
            {
                using (_databaseContext = new DatabaseContext())
                {
                    var getCount = await _databaseContext.BoilMaster.Where(m => m.CompanyId == companyId && m.BranchId == branchId && m.FinancialId == financialYearId && m.BoilType == boilTpe).MaxAsync(m => m.Sr);
                    return getCount + 1;
                }
            }
            catch (Exception ex)
            {
                return 1;
            }
        }

        public async Task<BoilMaster> UpdateBoilAsync(BoilMaster boilMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getRecord = await _databaseContext.BoilMaster.Where(w => w.Id == boilMaster.Id).FirstOrDefaultAsync();
                
                if(getRecord != null)
                {
                    getRecord.BoilCategoy = boilMaster.BoilCategoy;
                    getRecord.BoilType = boilMaster.BoilType;
                    getRecord.BranchId = boilMaster.BranchId;
                    getRecord.CompanyId = boilMaster.CompanyId;
                    getRecord.EntryDate = boilMaster.EntryDate;
                    getRecord.FinancialId = boilMaster.FinancialId;
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
                    getRecord.SlipNo = boilMaster.SlipNo;
                    getRecord.UpdatedBy = boilMaster.UpdatedBy;
                    getRecord.UpdatedDate = boilMaster.UpdatedDate;
                    getRecord.Weight = boilMaster.Weight;

                    await _databaseContext.SaveChangesAsync();
                }

                return boilMaster;
            }
        }
    }
}
