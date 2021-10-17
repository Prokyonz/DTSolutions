using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface ISalaryManager
    {
        Task<List<SalaryManager>> GetSalaries(Guid companyId, Guid branchId, Guid financialYear);
        Task<List<SalaryManager>> GetSalaries(int month, Guid companyId, Guid branchId, Guid financialYear);
        Task<List<SalaryManager>> AddSalary(List<SalaryManager> salaryManagers);
        Task<bool> UpdateSalary(List<SalaryManager> salaryManagers);
        Task<bool> DeleteSalary(Guid salarId);
    }
}
