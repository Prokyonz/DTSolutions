using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface ISalaryManager
    {
        Task<List<SalaryMaster>> GetSalaries(Guid companyId, Guid branchId, Guid financialYear);
        Task<List<SalaryMaster>> GetSalaries(int month, Guid companyId, Guid branchId, Guid financialYear);
        Task<List<SalaryMaster>> AddSalary(List<SalaryMaster> salaryManagers);
        Task<bool> UpdateSalary(List<SalaryMaster> salaryManagers);
        Task<bool> DeleteSalary(Guid salarId);
    }
}
