﻿using Repository.Entities;
using Repository.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface IExpenseMaster
    {
        Task<List<ExpenseDetails>> GetExpenseAsync(string companyId, string financialYearId, int srNo);
        Task<List<ExpenseDetails>> GetAllExpenseAsync(string companyId, string branchId, string financialYearId);
        Task<List<ExpenseSPModel>> GetExpenseReport(string companyId, string financialYearId, string fromDate, string toDate);
        Task<int> GetMaxSrNoAsync(string companyId, string financialYearId);
        Task<ExpenseDetails> AddExpenseAsync(ExpenseDetails expenseDetails);
        Task<ExpenseDetails> UpdateExpenseAsync(ExpenseDetails expenseDetails);
        Task<bool> DeleteExpenseAsync(string expenseId, string companyId, string financialYearId, bool isPermanantDetele = false);
        Task<bool> DeleteSrNoAllExpenseAsync(int SrNo, string companyId, string financialYearId, bool isPermanantDetele = true);
        Task<bool> UpdateBalanceAsync(string partyId, string fromParty, decimal amount);
    }
}
