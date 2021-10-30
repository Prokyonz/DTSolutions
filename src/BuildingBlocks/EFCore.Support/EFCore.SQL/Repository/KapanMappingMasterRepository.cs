using EFCore.SQL.DBContext;
using EFCore.SQL.Interface;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.SQL.Repository
{
    public class KapanMappingMasterRepository : IKapanMappingMaster
    {
        private DatabaseContext _databaseContext;

        public KapanMappingMasterRepository()
        {

        }

        public async Task<KapanMappingMaster> AddKapanMappingAsync(KapanMappingMaster kapanMappingMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                if (kapanMappingMaster.Id == null)
                    kapanMappingMaster.Id = Guid.NewGuid().ToString();

                await _databaseContext.KapanMappingMaster.AddAsync(kapanMappingMaster);
                await _databaseContext.SaveChangesAsync();
            }
            return kapanMappingMaster;
        }

        public async Task<bool> DeleteKapanMappingAsync(string kapanMappingId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getKapanRecord = await _databaseContext.KapanMappingMaster.Where(w => w.KapanId == kapanMappingId).FirstOrDefaultAsync();

                if (getKapanRecord != null)
                {
                    _databaseContext.KapanMappingMaster.Remove(getKapanRecord);

                    await _databaseContext.SaveChangesAsync();

                    return true;
                }

                return false;
            }
        }

        public async Task<List<KapanMappingMaster>> GetKapanMappingMaster(string companyId, string branchId, string financialYearId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.KapanMappingMaster.Where(w => w.CompanyId == companyId && w.BranchId == branchId && w.FinancialYearId == financialYearId).ToListAsync();
            }
        }

        public async Task<int> GetMaxSrNo(string companyId, string financialYearId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                try
                {
                    var getResult = await _databaseContext.KapanMappingMaster.MaxAsync(m => m.Sr);
                    return getResult + 1;
                }
                catch (Exception ex)
                {
                    return 1;
                }
            }
        }

        public async Task<List<KapanMapping>> GetPendingKapanMapping(string companyId, string branchId, string financialYearId)
        {
            try
            {
                using (_databaseContext = new DatabaseContext())
                {
                    var data = await _databaseContext.SPKapanMapping.FromSqlRaw($"GetPendingKapanMapping '" + companyId + "', '" + branchId + "','" + financialYearId + "'").ToListAsync();

                    return data;
                    //return await _databaseContext.KapanMappingMaster.Where(w => w.CompanyId == companyId && w.BranchId == branchId && w.FinancialYearId == financialYearId).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<KapanMappingMaster> UpdateKapanMappingMasterAsync(KapanMappingMaster kapanMappingMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getKapanRecord = await _databaseContext.KapanMappingMaster.Where(w => w.KapanId == kapanMappingMaster.Id).FirstOrDefaultAsync();
                if (getKapanRecord != null)
                {
                    getKapanRecord.CompanyId = kapanMappingMaster.CompanyId;
                    getKapanRecord.BranchId = kapanMappingMaster.BranchId;
                    getKapanRecord.KapanId = kapanMappingMaster.KapanId;
                    getKapanRecord.SlipId = kapanMappingMaster.SlipId;
                    getKapanRecord.PurchaseMasterId = kapanMappingMaster.PurchaseMasterId;
                    getKapanRecord.PurchaseDetailsId = kapanMappingMaster.PurchaseDetailsId;
                    getKapanRecord.Weight = kapanMappingMaster.Weight;
                    getKapanRecord.UpdatedBy = kapanMappingMaster.UpdatedBy;
                    getKapanRecord.UpdatedDate = kapanMappingMaster.UpdatedDate;

                    await _databaseContext.SaveChangesAsync();
                }

                return kapanMappingMaster;
            }
        }
    }
}
