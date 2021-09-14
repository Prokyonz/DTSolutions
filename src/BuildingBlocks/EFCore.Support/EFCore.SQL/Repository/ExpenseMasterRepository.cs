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
        public async Task<ExpenseMaster> AddExpenseAsync(ExpenseMaster expenseMaster)
        {
            if (expenseMaster.Id == null)
                expenseMaster.Id = Guid.NewGuid();

            await _databaseContext.ExpenseMaster.AddAsync(expenseMaster);
            await _databaseContext.SaveChangesAsync();
            return expenseMaster;
        }

        public async Task<bool> DeleteExpenseAsync(Guid expenseId, bool isPermanantDetele = false)
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

        public async Task<List<ExpenseMaster>> GetAllExpenseAsync()
        {
            return await _databaseContext.ExpenseMaster.Where(w => w.IsDelete == false).ToListAsync();
        }

        public async Task<ExpenseMaster> UpdateExpenseAsync(ExpenseMaster expenseMaster)
        {
            try
            {
                var getExpense = await _databaseContext.ExpenseMaster.Where(w => w.Id == expenseMaster.Id).Include("ExpenseDetails").FirstOrDefaultAsync();

                if (getExpense != null)
                {
                    getExpense.Name = expenseMaster.Name;
                    getExpense.UpdatedBy = expenseMaster.UpdatedBy;
                    getExpense.UpdatedDate = expenseMaster.UpdatedDate;
                    getExpense.IsDelete = false;

                    _databaseContext.ExpenseDetails.RemoveRange(expenseMaster.ExpenseDetails);

                    await _databaseContext.ExpenseDetails.AddRangeAsync(expenseMaster.ExpenseDetails);

                    await _databaseContext.SaveChangesAsync();
                }

                return expenseMaster;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
