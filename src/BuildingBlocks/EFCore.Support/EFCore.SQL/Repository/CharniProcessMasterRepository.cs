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
    public class CharniProcessMasterRepository : ICharniProcessMaster
    {
        private DatabaseContext _databaseContext;

        public CharniProcessMasterRepository()
        {
            
        }

        public async Task<CharniProcessMaster> AddCharniProcessAsync(CharniProcessMaster charniProcessMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                if (charniProcessMaster.Id == null)
                    charniProcessMaster.Id = Guid.NewGuid().ToString();
                await _databaseContext.CharniProcessMaster.AddAsync(charniProcessMaster);
                await _databaseContext.SaveChangesAsync();
                return charniProcessMaster;
            }
        }

        public async Task<bool> DeleteCharniProcessAsync(string charniProcessMasterId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getReccord = await _databaseContext.CharniProcessMaster.Where(w => w.Id == charniProcessMasterId).FirstOrDefaultAsync();
                if (getReccord == null)
                {
                    _databaseContext.CharniProcessMaster.Remove(getReccord);
                    await _databaseContext.SaveChangesAsync();

                    return true;
                }

                return false;
            }
        }

        public async Task<List<CharniProcessMaster>> GetCharniProcessAsync(string companyId, string branchId, string financialYearId, int charniType)
        {
            using (_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.CharniProcessMaster.Where(w => w.CompanyId == companyId && w.BranchId == branchId && w.FinancialId == financialYearId && w.CharniType == charniType).ToListAsync();
            }
        }

        public async Task<int> GetMaxSrNoAsync(string companyId, string branchId, string financialYearId, int charniType)
        {
            try
            {
                using (_databaseContext = new DatabaseContext())
                {
                    var getCount = await _databaseContext.CharniProcessMaster.Where(m => m.CompanyId == companyId && m.BranchId == branchId && m.FinancialId == financialYearId && m.CharniType == charniType).MaxAsync(m => m.Sr);
                    return getCount + 1;
                }
            }
            catch (Exception ex)
            {
                return 1;
            }
        }

        public async Task<CharniProcessMaster> UpdateCharniProcessAsync(CharniProcessMaster charniProcessMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getRecord = await _databaseContext.CharniProcessMaster.Where(w => w.Id == charniProcessMaster.Id).FirstOrDefaultAsync();

                if (getRecord != null)
                {
                    getRecord.CharniCategoy = charniProcessMaster.CharniCategoy;
                    getRecord.CharniType = charniProcessMaster.CharniType;
                    getRecord.BranchId = charniProcessMaster.BranchId;
                    getRecord.CompanyId = charniProcessMaster.CompanyId;
                    getRecord.EntryDate = charniProcessMaster.EntryDate;
                    getRecord.FinancialId = charniProcessMaster.FinancialId;
                    getRecord.HandOverById = charniProcessMaster.HandOverById;
                    getRecord.HandOverToId = charniProcessMaster.HandOverToId;
                    getRecord.IsDelete = false;
                    getRecord.JangadNo = charniProcessMaster.JangadNo;
                    getRecord.KapanId = charniProcessMaster.KapanId;
                    getRecord.LossWeight = charniProcessMaster.LossWeight;
                    getRecord.RejectionWeight = charniProcessMaster.RejectionWeight;
                    getRecord.Remarks = charniProcessMaster.Remarks;
                    getRecord.ShapeId = charniProcessMaster.ShapeId;
                    getRecord.SizeId = charniProcessMaster.SizeId;
                    getRecord.SlipNo = charniProcessMaster.SlipNo;
                    getRecord.UpdatedBy = charniProcessMaster.UpdatedBy;
                    getRecord.UpdatedDate = charniProcessMaster.UpdatedDate;
                    getRecord.Weight = charniProcessMaster.Weight;

                    await _databaseContext.SaveChangesAsync();
                }

                return charniProcessMaster;
            }
        }
    }
}
