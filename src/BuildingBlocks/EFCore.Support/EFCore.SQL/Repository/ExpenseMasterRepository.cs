using EFCore.SQL.DBContext;
using EFCore.SQL.Interface;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.SQL.Repository
{
    internal class ExpenseMasterRepository : IExpenseMaster, IDisposable
    {
        private readonly DatabaseContext _databaseContext;

        public ExpenseMasterRepository()
        {
            _databaseContext = new DatabaseContext();
        }
        public async Task<ExpenseDetails> AddExpenseAsync(ExpenseDetails expenseDetails)
        {
            if (expenseDetails.Id == null)
                expenseDetails.Id = Guid.NewGuid().ToString();

            await _databaseContext.ExpenseDetails.AddAsync(expenseDetails);
            await _databaseContext.SaveChangesAsync();
            return expenseDetails;
        }

        public async Task<bool> DeleteExpenseAsync(string expenseId, bool isPermanantDetele = false)
        {
            var getExpense = await _databaseContext.ExpenseMaster.Where(w => w.Id == expenseId).FirstOrDefaultAsync();
            if (getExpense != null)
            {
                if (isPermanantDetele)
                    _databaseContext.ExpenseMaster.Remove(getExpense);
                else
                    getExpense.IsDelete = true;

                await _databaseContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public void Dispose()
        {
            _databaseContext.DisposeAsync();
        }

        public async Task<List<ExpenseDetails>> GetAllExpenseAsync(string companyId, string branchId, string financialYearId)
        {
            return await _databaseContext.ExpenseDetails.Where(w => w.IsDelete == false && w.CompanyId == companyId && w.BranchId == branchId && w.FinancialYearId == financialYearId).ToListAsync();
        }

        public async Task<int> GetMaxSrNoAsync(string companyId, string branchId, string financialYearId)
        {
            var countResult = await _databaseContext.ExpenseDetails.CountAsync(w => w.CompanyId == companyId && w.BranchId == branchId && w.FinancialYearId == financialYearId);
            return countResult + 1;
        }

        public async Task<ExpenseDetails> UpdateExpenseAsync(ExpenseDetails expenseDetails)
        {
            try
            {
                var getExpense = await _databaseContext.ExpenseDetails.Where(w => w.Id == expenseDetails.Id).FirstOrDefaultAsync();

                if (getExpense != null)
                {
                    getExpense.PartyId = expenseDetails.PartyId;
                    getExpense.CompanyId = expenseDetails.CompanyId;
                    getExpense.BranchId = expenseDetails.BranchId;
                    getExpense.FinancialYearId = expenseDetails.FinancialYearId;
                    getExpense.Amount= expenseDetails.Amount;
                    getExpense.Remarks = expenseDetails.Remarks;
                    getExpense.UpdatedBy = expenseDetails.UpdatedBy;
                    getExpense.UpdatedDate = expenseDetails.UpdatedDate;
                    getExpense.IsDelete = false;

                    await _databaseContext.SaveChangesAsync();
                }

                return expenseDetails;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
