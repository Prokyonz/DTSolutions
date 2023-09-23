using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface IBillPrint
    {
        Task<int> GetMaxGroupNo(string companyId, string branchId, string financialYearId);
        Task<int> GetMaxsRNo();
        Task SaveBill(BillPrintModel billPrintModel);
        Task<List<BillPrintModel>> GetLastRecord(string companyId, string branchId, string financialYearId);
    }
}