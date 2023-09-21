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
        Task<GroupPaymentMaster> GetPaymentAsync(string companyId, string financialYearId, int SrNo, int paymentType);
        Task<List<PaymentSPModel>> GetPaymentReport(string companyId, string financialYearId, int paymentType, string fromDate, string toDate);
        Task<int> GetMaxSrNoAsync(int paymentType, string companyId, string financialYearId);
        Task<GroupPaymentMaster> AddPaymentAsync(GroupPaymentMaster groupPaymentMaster);
        Task<GroupPaymentMaster> UpdatePaymentAsync(GroupPaymentMaster groupPaymentMaster);

        Task<List<MixedSPModel>> GetMixedReportAsync(string companyId, string financialYearId, string fromDate, string toDate);
        Task<bool> DeletePaymentAsync(string groupId);
        Task<bool> DeleteGroupPaymentAsync(int SrNo, int paymentType);
        Task<List<PayableReceivableSPModel>> GetPayableReceivalbeReport(string companyId, string financialYearId, int type);
        Task<List<BalanceSheetSPModel>> GetBalanceSheetReportAsync(string companyId, string financialYearId, int balanceSheetType);
        Task<List<ProfitLossSPModel>> GetProfitLossReportAsync(string companyId, string financialYearId, int PLType);
        Task<List<CashBankSPReport>> GetCashBankReportAsync(string companyId, string financialYearId, string fromDate, string toDate);
        Task<DashboardSPModel> GetPaymentOrReceiptTotal(string companyId, string financialYearId, int paymentType, string fromDate, string toDate);
        Task<List<PaymentPSSlipDetails>> GetPaymentPSSlipDetails(string companyId, string actionType, int SrNo);
        Task<bool> UpdateApprovalStatus(string paymentGroupId, string message, int status);

    }
}
