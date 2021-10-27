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

        public async Task<bool> DeleteAccountToAssortAsync(string accountToAssortId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getMasterRecord = await _databaseContext.AccountToAssortMaster.Where(w => w.Id == accountToAssortId).Include("AccountToAssortDetails").FirstOrDefaultAsync();

                if(getMasterRecord != null)
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
                return await _databaseContext.AccountToAssortMaster.Where(w=>w.CompanyId == companyId && w.BranchId == branchId && w.FinancialId == financialYearId).ToListAsync();
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
                    getMasterRecord.FinancialId = accountToAssortMaster.FinancialId;
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
    }
}
