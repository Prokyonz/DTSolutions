using Repository.Entities;
using Repository.Entities.Model;
using Repository.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface INumberProcessMaster
    {
        Task<List<NumberProcessMaster>> GetNumberProcessAsync(string companyId, string branchId, string financialYearId, int numberProcessType);
        Task<int> GetMaxSrNoAsync(string companyId, string branchId, string financialYearId, int numberProcessType);
        Task<NumberProcessMaster> AddNumberProcessAsync(NumberProcessMaster numberProcessMaster);
        Task<NumberProcessMaster> UpdateNumberProcessAsync(NumberProcessMaster numberProcessMaste);
        Task<bool> DeleteNumberProcessAsync(int numberNo);
        Task<List<NumberProcessSend>> GetNumberSendToDetails(string companyId, string branchId, string financialYearId);
        Task<List<NumberProcessReceive>> GetNumberReceiveDetails(string ReceiveFrom, string companyId, string branchId, string financialYearId);
        Task<List<NumberProcessSendReceiveReportModel>> GetNumberSendReceiveReports(string companyId, string branchId, string financialYearId, int numberProcessType);

    }
}