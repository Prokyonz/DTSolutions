using Repository.Entities;
using Repository.Entities.Model;
using Repository.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface IAccountToAssortMaster
    {
        Task<List<AccountToAssortMaster>> GetAccountToAssortAsync(string companyId, string branchId, string financialYearId);
        Task<List<AccountToAssortSendReceiveReportModel>> GetAccountToAssortSendReportAsync(string companyId, string branchId, string financialYearId, int AccountToAssortType=0);
        Task<List<AccountToAssoftReceiveReportModel>> GetAccountToAssortReceiveReportAsync(string companyId, string branchId, string financialYearId);
        Task<int> GetMaxSrNoAsync(string companyId, string branchId, string financialYearId);
        Task<AccountToAssortMaster> AddAccountToAssortAsync(AccountToAssortMaster accountToAssortMaster);
        Task<AccountToAssortMaster> UpdateAccountToAssortAsync(AccountToAssortMaster accountToAssortMaster);
        Task<bool> DeleteAccountToAssortAsync(string accountToAssortId, string slipNo);

        Task<List<AssortmentProcessSend>> GetAssortmentSendToDetails(string companyId, string branchId, string financialYearId);
        Task<List<StockReportModelReport>> GetStockReportAsync(string companyId, string financialYearId);
    }
}
