using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface IPaymentMaster
    {
        Task<List<GroupPaymentMaster>> GetAllPaymentAsync(string companyId, string financialYearId);
        Task<int> GetMaxSrNoAsync(string companyId, string financialYearId);
        Task<GroupPaymentMaster> AddPaymentAsync(GroupPaymentMaster groupPaymentMaster);
        Task<GroupPaymentMaster> UpdatePaymentAsync(GroupPaymentMaster groupPaymentMaster);
        Task<bool> DeletePaymentAsync(string groupId);

    }
}
