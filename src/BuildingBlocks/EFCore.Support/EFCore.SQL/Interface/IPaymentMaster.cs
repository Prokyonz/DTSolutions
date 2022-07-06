using Repository.Entities;
using Repository.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface IPaymentMaster
    {
        Task<List<GroupPaymentMaster>> GetAllPaymentAsync(string companyId, string financialYearId);
        Task<List<PaymentSPModel>> GetPaymentReport(string companyId, string financialYearId, int paymentType);
        Task<int> GetMaxSrNoAsync(int paymentType, string companyId, string financialYearId);
        Task<GroupPaymentMaster> AddPaymentAsync(GroupPaymentMaster groupPaymentMaster);
        Task<GroupPaymentMaster> UpdatePaymentAsync(GroupPaymentMaster groupPaymentMaster);

        Task<List<MixedSPModel>> GetMixedReportAsync(string companyId, string financialYearId);
        Task<bool> DeletePaymentAsync(string groupId);
        Task<List<PayableReceivableSPModel>> GetPayableReceivalbeReport(string companyId, string financialYearId, int type);
        Task<List<BalanceSheetSPModel>> GetBalanceSheetReportAsync(string companyId, string financialYearId, int balanceSheetType);
        Task<List<ProfitLossSPModel>> GetProfitLossReportAsync(string companyId, string financialYearId, int PLType);

    }
}
