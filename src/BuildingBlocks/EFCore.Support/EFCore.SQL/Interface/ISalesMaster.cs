using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface ISalesMaster
    {
        Task<List<SalesMaster>> GetAllSalesAsync(Guid companyId, Guid financialYearId);
        Task<List<SalesMaster>> GetAllSalesAsync(Guid companyId, DateTime startDate, DateTime endDate);
        Task<List<SalesMaster>> GetAllSalesAsync(Guid companyId, Guid branchId, Guid financialYearId);
        Task<List<SalesMaster>> GetAllSalesAsync(Guid companyId, Guid branchId, DateTime startDate, DateTime endDate);
        Task<SalesMaster> AddSalesAsync(SalesMaster salesMaster);
        Task<SalesMaster> UpdateSalesAsync(SalesMaster salesMaster);
        Task<bool> DeleteSalesAsync(Guid salesId, bool isPermanantDetele = false);
    }
}
