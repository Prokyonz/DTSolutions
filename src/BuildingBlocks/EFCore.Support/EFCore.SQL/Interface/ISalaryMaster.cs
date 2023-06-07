using Repository.Entities;
using Repository.Entities.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface ISalaryMaster
    {
        Task<List<SalaryMaster>> GetSalaries(string companyId, string branchId, string financialYear);
        Task<long> GetMaxSrNoAsync(string companyId, string finanialYearId);
        Task<SalaryMaster> GetSalaries(int month, string companyId, string branchId, string financialYear);
        Task<List<SalaryReportSPModel>> GetSalaries(string companyId, string financialYear);
        Task<SalaryMaster> AddSalary(SalaryMaster salaryMaster);
        Task<bool> UpdateSalary(SalaryMaster salaryMaster);
        Task<bool> DeleteSalary(string salaryMasterId, string salaryDetailsId, bool deleteThread);
    }
}
