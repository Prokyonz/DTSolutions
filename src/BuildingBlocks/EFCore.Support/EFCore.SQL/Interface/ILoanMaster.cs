using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface ILoanMaster
    {
        Task<List<LoanMaster>> GetAllLoanAsync(string CompanyId);
        Task<List<LoanMaster>> GetAllLoanAsync(int loanType, string CompanyId);
        Task<LoanMaster> AddLoanAsync(LoanMaster loanMaster);
        Task<LoanMaster> UpdateLoanAsync(LoanMaster loanMaster);
        Task<bool> DeleteLoanAsync(string loanId);
    }
}