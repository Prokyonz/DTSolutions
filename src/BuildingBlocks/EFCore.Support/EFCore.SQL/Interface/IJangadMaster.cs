using Repository.Entities;
using Repository.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface IJangadMaster
    {
        Task<List<JangadMaster>> GetAllJangadAsync(string companyId, string financialYearId, int entryType);
        Task<int> GetMaxSrNoAsync(string companyId, string financialYearId, int entryType);
        Task<JangadMaster> AddJangadAsync(JangadMaster jangadMaster);
        Task<JangadMaster[]> UpdateJangadAsync(JangadMaster[] jangadMaster);
        Task<bool> DeleteJangadAsync(string jangadId);
        Task<List<JangadSPReceiveModel>> GetJangadReceiveDetails(string CompanyId, string FinancialYearId, string BrokerId);
        Task<List<JangadPrintDetailModel>> GetJangadPrintDetails(string CompanyId, string FinancialYearId, string SrNo);
        Task<List<JangadSPReportModel>> GetJangadReport(string CompanyId, string FinancialYearId, int jangadType);

    }
}
