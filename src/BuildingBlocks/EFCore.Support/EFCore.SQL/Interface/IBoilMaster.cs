using Repository.Entities;
using Repository.Entities.Model;
using Repository.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface IBoilMaster
    {
        Task<List<BoilProcessMaster>> GetBoilAsync(string companyId, string branchId, string financialYearId, int boilType);
        Task<int> GetMaxSrNoAsync(string companyId, string branchId, string financialYearId, int boilTpe);
        Task<BoilProcessMaster> AddBoilAsync(BoilProcessMaster boilMaster);
        Task<BoilProcessMaster> UpdateBoilAsync(BoilProcessMaster boilMaster);
        Task<bool> DeleteBoilAsync(string boilMasterId);

        Task<List<BoilProcessSend>> GetBoilSendToDetails(string companyId, string branchId, string financialYearId);
        Task<List<BoilProcessReceive>> GetBoilReceiveToDetails(string ReceivedFromId, string companyId, string branchId, string financialYearId);
        Task<List<BoilSendReceiveReportModel>> GetBoilSendReceiveReports(string companyId, string branchId, string financialYearId, int boilType);

    }
}
