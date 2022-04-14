using Repository.Entities;
using Repository.Entities.Model;
using Repository.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface ICharniProcessMaster
    {
        Task<List<CharniProcessMaster>> GetCharniProcessAsync(string companyId, string branchId, string financialYearId, int charniType);
        Task<int> GetMaxSrNoAsync(string companyId, string branchId, string financialYearId, int charniType);
        Task<CharniProcessMaster> AddCharniProcessAsync(CharniProcessMaster charniProcessMaster);
        Task<CharniProcessMaster> UpdateCharniProcessAsync(CharniProcessMaster charniProcessMaster);
        Task<bool> DeleteCharniProcessAsync(string charniProcessMasterId);
        Task<List<CharniProcessSend>> GetCharniSendToDetails(string companyId, string branchId, string financialYearId);
        Task<List<CharniProcessReceive>> GetCharniReceiveDetails(string ReceiveFrom, string companyId, string branchId, string financialYearId);
        Task<List<CharniSendReceiveReportModel>> GetCharniSendReceiveReports(string companyId, string branchId, string financialYearId, int charniType);



    }
}
