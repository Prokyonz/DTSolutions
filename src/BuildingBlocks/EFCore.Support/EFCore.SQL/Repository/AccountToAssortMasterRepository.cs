using EFCore.SQL.DBContext;
using EFCore.SQL.Interface;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Entities.Model;
using Repository.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.SQL.Repository
{
    public class AccountToAssortMasterRepository : IAccountToAssortMaster
    {
        private DatabaseContext _databaseContext;

        public AccountToAssortMasterRepository()
        {
            
        }
        public async Task<AccountToAssortMaster> AddAccountToAssortAsync(AccountToAssortMaster accountToAssortMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                if (accountToAssortMaster.Id == null)
                    accountToAssortMaster.Id = Guid.NewGuid().ToString();

                await _databaseContext.AccountToAssortMaster.AddAsync(accountToAssortMaster);
                await _databaseContext.SaveChangesAsync();

                return accountToAssortMaster;
            }
        }

        public async Task<bool> DeleteAccountToAssortAsync(string accountToAssortId, string accountToAssortChildId, string slipNo)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getMasterRecord = await _databaseContext.AccountToAssortMaster.Where(w => w.Id == accountToAssortId).Include("AccountToAssortDetails").FirstOrDefaultAsync();

                var AssortDetailsRec = getMasterRecord.AccountToAssortDetails.Where(w => w.SlipNo == slipNo).FirstOrDefault();

                var checkInBoil = await _databaseContext.BoilProcessMaster.Where(w => w.SlipNo == slipNo && w.AccountToAssortDetailsId == AssortDetailsRec.Id).ToListAsync();    

                if(getMasterRecord != null && checkInBoil.Count == 0)
                {
                    _databaseContext.AccountToAssortDetails.RemoveRange(getMasterRecord.AccountToAssortDetails);
                    await _databaseContext.SaveChangesAsync();

                    return true;
                }
                return false;
            }
        }

        public async Task<List<AccountToAssortMaster>> GetAccountToAssortAsync(string companyId, string branchId, string financialYearId)
        {
            using(_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.AccountToAssortMaster.Where(w=>w.CompanyId == companyId && w.BranchId == branchId && w.FinancialYearId == financialYearId).ToListAsync();
            }            
        }

        public async Task<int> GetMaxSrNoAsync(string companyId, string branchId, string financialYearId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                try
                {
                    var maxNo = await _databaseContext.AccountToAssortMaster.MaxAsync(m => m.Sr);
                    return maxNo + 1;
                }
                catch (Exception ex)
                {
                    return 1;
                }
            }
        }

        public async Task<AccountToAssortMaster> UpdateAccountToAssortAsync(AccountToAssortMaster accountToAssortMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getMasterRecord = await _databaseContext.AccountToAssortMaster.Where(w => w.Id == accountToAssortMaster.Id).Include("AccountToAssortDetails").FirstOrDefaultAsync();
                if(getMasterRecord != null)
                {
                    getMasterRecord.AccountToAssortType = accountToAssortMaster.AccountToAssortType;
                    getMasterRecord.BranchId = accountToAssortMaster.BranchId;
                    getMasterRecord.CompanyId = accountToAssortMaster.CompanyId;
                    getMasterRecord.Department = accountToAssortMaster.Department;
                    getMasterRecord.EntryDate = accountToAssortMaster.EntryDate;
                    getMasterRecord.FinancialYearId = accountToAssortMaster.FinancialYearId;
                    getMasterRecord.FromParyId = accountToAssortMaster.FromParyId;
                    getMasterRecord.ToPartyId = accountToAssortMaster.ToPartyId;
                    getMasterRecord.Remarks = accountToAssortMaster.Remarks;
                    getMasterRecord.IsDelete = false;
                    getMasterRecord.KapanId = accountToAssortMaster.KapanId;
                    getMasterRecord.UpdatedBy = accountToAssortMaster.UpdatedBy;
                    getMasterRecord.UpdatedDate = accountToAssortMaster.UpdatedDate;
                    
                    if(getMasterRecord.AccountToAssortDetails.Count > 0)
                    {
                        _databaseContext.AccountToAssortDetails.RemoveRange(getMasterRecord.AccountToAssortDetails);

                        await _databaseContext.AccountToAssortDetails.AddRangeAsync(accountToAssortMaster.AccountToAssortDetails);

                        await _databaseContext.SaveChangesAsync();
                    }
                }
                return accountToAssortMaster;
            }
        }

        public async Task<List<AssortmentProcessSend>> GetAssortmentSendToDetails(string companyId, string branchId, string financialYearId)
        {
            try
            {
                using (_databaseContext = new DatabaseContext())
                {
                    var data = await _databaseContext.SPAssortmentProcessSend.FromSqlRaw($"GetAssortProcessSendToDetail '" + companyId + "', '" + branchId + "','" + financialYearId + "'").ToListAsync();

                    return data;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<List<AccountToAssortSendReceiveReportModel>> GetAccountToAssortSendReportAsync(string companyId, string branchId, string financialYearId, int AccountToAssortType = 0)
        {
            try
            {
                using (_databaseContext = new DatabaseContext())
                {
                    var data = await _databaseContext.SPAccountToAssortSendReceiveReportModels.FromSqlRaw($"GetAssortSendReport '" + companyId + "', '" + branchId + "','" + financialYearId + "', " + AccountToAssortType).ToListAsync();

                    return data;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<AccountToAssoftReceiveReportModel>> GetAccountToAssortReceiveReportAsync(string companyId, string branchId, string financialYearId)
        {
            try
            {
                using (_databaseContext = new DatabaseContext())
                {
                    var data = await _databaseContext.SPAccountToAssoftReceiveReportModel.FromSqlRaw($"GetAssortReceiveReport '" + companyId + "', '" + branchId + "','" + financialYearId + "'").ToListAsync();

                    return data;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<StockReportModelReport>> GetStockReportAsync(string companyId, string financialYearId)
        {
            try
            {
                using (_databaseContext = new DatabaseContext())
                {
                    //var data = await _databaseContext.SPStockReportModelReport.FromSqlRaw($"GetAssortProcessSendToDetail '" + companyId + "','', '" + financialYearId + "'").ToListAsync();
                    var data = await _databaseContext.SPStockReportModelReport.FromSqlRaw($"GetAllKapanLagadDetails").ToListAsync();

                    return data;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<NumberReportModelReport>> GetNumberReportAsync(string companyId, string financialYearId)
        {
            try
            {
                using (_databaseContext = new DatabaseContext())
                {
                    var data = await _databaseContext.SPNumberkReportModelReport.FromSqlRaw($"GetAllNumberStockDetails").ToListAsync();

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
