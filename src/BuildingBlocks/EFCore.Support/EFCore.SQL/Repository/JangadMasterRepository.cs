using EFCore.SQL.DBContext;
using EFCore.SQL.Interface;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.SQL.Repository
{
    public class JangadMasterRepository : IJangadMaster
    {
        private DatabaseContext _databaseContext;

        public JangadMasterRepository()
        {

        }
        public async Task<JangadMaster> AddJangadAsync(JangadMaster jangadMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                if (jangadMaster.Id == null)
                    jangadMaster.Id = Guid.NewGuid().ToString();

                await _databaseContext.JangadMaster.AddAsync(jangadMaster);
                await _databaseContext.SaveChangesAsync();
                return jangadMaster;
            }
        }

        public async Task<bool> DeleteJangadAsync(string jangadId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getJangad = await _databaseContext.JangadMaster.Where(w => w.Id == jangadId).FirstOrDefaultAsync();
                if (getJangad != null)
                {
                    _databaseContext.JangadMaster.Remove(getJangad);

                    await _databaseContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
        }

        public async Task<List<JangadMaster>> GetAllJangadAsync(string companyId, string financialYearId, int entryType)
        {
            using (_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.JangadMaster.Where(w => w.IsDelete == false && w.CompanyId == companyId && w.FinancialYearId == financialYearId && w.EntryType == entryType).ToListAsync();
            }
        }

        public async Task<int> GetMaxSrNoAsync(string companyId, string financialYearId, int entryType)
        {
            using (_databaseContext = new DatabaseContext())
            {
                try
                {
                    var getCount = await _databaseContext.JangadMaster.Where(w => w.CompanyId == companyId && w.FinancialYearId == financialYearId && w.EntryType == entryType).MaxAsync(m => m.SrNo);
                    return getCount + 1;
                }
                catch (Exception ex)
                {
                    return 1;
                }
            }
        }

        public async Task<JangadMaster[]> UpdateJangadAsync(JangadMaster[] jangadMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                try
                {
                    var records = await _databaseContext.JangadMaster.Where(w => w.SrNo == jangadMaster[0].SrNo).ToListAsync();

                    //foreach (var item in records)
                    //{
                    //    item.PartyId = jangadMaster
                    //    await _databaseContext.SaveChangesAsync();
                    //}
                    
                    return jangadMaster;
                }
                catch
                {
                    return jangadMaster;
                }
            }
        }

        public async Task<List<JangadSPReceiveModel>> GetJangadReceiveDetails(string CompanyId, string FinancialYearId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var defaultPriceList = await _databaseContext.JangadSPReceiveModel.FromSqlRaw($"GetJangadReceiveDetail '"+CompanyId+"','"+FinancialYearId+"'").ToListAsync();
                return defaultPriceList;
            }
        }

        public async Task<List<JangadPrintDetailModel>> GetJangadPrintDetails(string CompanyId, string FinancialYearId, string SrNo, int JangadType)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var defaultPriceList = await _databaseContext.JangadPrintDetailModel.FromSqlRaw($"GetJangadPrintDetails '" + SrNo + "','" + CompanyId + "','" + FinancialYearId + "','"+JangadType+"'").ToListAsync();
                return defaultPriceList;
            }
        }

        public async Task<List<JangadSPReportModel>> GetJangadReport(string CompanyId, string FinancialYearId, int jangadType)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var JangadReports = await _databaseContext.SPJangadSendReceiveReportModel.FromSqlRaw($"GetJangadReport '" + CompanyId + "','" + FinancialYearId + "', " + jangadType + "").ToListAsync();
                return JangadReports;
            }
        }
    }
}
