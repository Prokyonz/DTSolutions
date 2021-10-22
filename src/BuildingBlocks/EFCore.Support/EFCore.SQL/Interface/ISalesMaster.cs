using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface ISalesMaster
    {
        Task<List<SalesMaster>> GetAllSalesAsync(string companyId, string financialYearId);
        Task<List<SalesMaster>> GetAllSalesAsync(string companyId, DateTime startDate, DateTime endDate);
        Task<List<SalesMaster>> GetAllSalesAsync(string companyId, string branchId, string financialYearId);
        Task<List<SalesMaster>> GetAllSalesAsync(string companyId, string branchId, DateTime startDate, DateTime endDate);
        Task<SalesMaster> AddSalesAsync(SalesMaster salesMaster);
        Task<SalesMaster> UpdateSalesAsync(SalesMaster salesMaster);
        Task<bool> DeleteSalesAsync(string salesId, bool isPermanantDetele = false);
    }
}
