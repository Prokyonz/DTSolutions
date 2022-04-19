using Repository.Entities;
using Repository.Entities.Model;
using Repository.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface IGalaProcessMaster
    {
        Task<List<GalaProcessMaster>> GetGalaProcessAsync(string companyId, string branchId, string financialYearId, int galaProcessType);
        Task<int> GetMaxSrNoAsync(string companyId, string branchId, string financialYearId, int galaProcessType);
        Task<GalaProcessMaster> AddGalaProcessAsync(GalaProcessMaster galaProcessMaster);
        Task<GalaProcessMaster> UpdateGalaProcessAsync(GalaProcessMaster galaProcessMaster);
        Task<bool> DeleteGalaProcessAsync(string galaProcessMasterId);
        Task<List<GalaProcessSend>> GetGalaSendToDetails(string companyId, string branchId, string financialYearId);
        Task<List<GalaProcessReceive>> GetGalaReceiveDetails(string ReceiveFrom, string companyId, string branchId, string financialYearId);
        Task<List<GalaProcessSendReceiveReportModel>> GetGalaSendReceiveReports(string companyId, string branchId, string financialYearId, int galaProcessType);

    }
}
