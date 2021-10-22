using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface IExpenseMaster
    {
        Task<List<ExpenseMaster>> GetAllExpenseAsync();
        Task<ExpenseMaster> AddExpenseAsync(ExpenseMaster expenseMaster);
        Task<ExpenseMaster> UpdateExpenseAsync(ExpenseMaster expenseMaster);
        Task<bool> DeleteExpenseAsync(string expenseId, bool isPermanantDetele = false);
    }
}
