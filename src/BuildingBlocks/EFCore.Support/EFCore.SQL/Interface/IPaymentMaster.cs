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
        Task<bool> DeletePaymentAsync(string groupId);

    }
}
