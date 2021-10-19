using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface ISalaryMaster
    {
        Task<List<SalaryMaster>> GetSalaries(Guid companyId, Guid branchId, Guid financialYear);
        Task<SalaryMaster> GetSalaries(int month, Guid companyId, Guid branchId, Guid financialYear);
        Task<SalaryMaster> AddSalary(SalaryMaster salaryMaster);
        Task<bool> UpdateSalary(SalaryMaster salaryMaster);
        Task<bool> DeleteSalary(Guid salaryMasterId);
    }
}
