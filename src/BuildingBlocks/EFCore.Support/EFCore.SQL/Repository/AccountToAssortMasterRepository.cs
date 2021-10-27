using EFCore.SQL.DBContext;
using EFCore.SQL.Interface;
using Repository.Entities;
using System;
using System.Collections.Generic;
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
        public Task<AccountToAssortMaster> AddAccountToAssortAsync(AccountToAssortMaster accountToAssortMaster)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAccountToAssortAsync(string expenseId, bool isPermanantDetele = false)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AccountToAssortMaster>> GetAccountToAssortAsync(string companyId, string branchId, string financialYearId)
        {
            using(_databaseContext = new DatabaseContext())
            {
                return null;
            }            
        }

        public Task<int> GetMaxSrNoAsync(string companyId, string branchId, string financialYearId)
        {
            throw new NotImplementedException();
        }

        public Task<AccountToAssortMaster> UpdateAccountToAssortAsync(AccountToAssortMaster accountToAssortMaster)
        {
            throw new NotImplementedException();
        }
    }
}
