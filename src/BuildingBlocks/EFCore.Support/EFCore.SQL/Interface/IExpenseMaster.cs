using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface IExpenseMaster
    {
        Task<List<ExpenseDetails>> GetAllExpenseAsync(string companyId, string branchId, string financialYearId);
        Task<int> GetMaxSrNoAsync(string companyId, string branchId, string financialYearId);
        Task<ExpenseDetails> AddExpenseAsync(ExpenseDetails expenseDetails);
        Task<ExpenseDetails> UpdateExpenseAsync(ExpenseDetails expenseDetails);
        Task<bool> DeleteExpenseAsync(string expenseId, bool isPermanantDetele = false);
    }
}
