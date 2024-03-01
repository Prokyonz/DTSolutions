using EFCore.SQL.DBContext;
using EFCore.SQL.Interface;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.SQL.Repository
{
    public class ExpenseMasterRepository : IExpenseMaster
    {
        private DatabaseContext _databaseContext;

        public ExpenseMasterRepository()
        {
            
        }
        public async Task<ExpenseDetails> AddExpenseAsync(ExpenseDetails expenseDetails)
        {
            using (_databaseContext = new DatabaseContext())
            {
                if (expenseDetails.Id == null)
                    expenseDetails.Id = Guid.NewGuid().ToString();

                await _databaseContext.ExpenseDetails.AddAsync(expenseDetails);
                await _databaseContext.SaveChangesAsync();
                return expenseDetails;
            }
        }

        public async Task<bool> DeleteExpenseAsync(string expenseId, bool isPermanantDetele = true)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getExpense = await _databaseContext.ExpenseDetails.Where(w => w.Id == expenseId).ToListAsync();
                if (getExpense != null)
                {
                    if (isPermanantDetele)
                        _databaseContext.ExpenseDetails.RemoveRange(getExpense);
                    else
                    {
                        foreach (ExpenseDetails expenseDetails in getExpense)
                        {
                            expenseDetails.IsDelete = true;
                        }
                        _databaseContext.UpdateRange(getExpense);
                    }

                    await _databaseContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
        }

        public async Task<bool> DeleteSrNoAllExpenseAsync(int SrNo, bool isPermanantDetele = true)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getExpense = await _databaseContext.ExpenseDetails.Where(w => w.SrNo == SrNo).ToListAsync();
                if (getExpense != null)
                {
                    if (isPermanantDetele)
                        _databaseContext.ExpenseDetails.RemoveRange(getExpense);
                    else
                    {
                        foreach (ExpenseDetails expenseDetails in getExpense)
                        {
                            expenseDetails.IsDelete = true;
                        }
                        _databaseContext.UpdateRange(getExpense);
                    }

                    await _databaseContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
        }

        public async Task<List<ExpenseDetails>> GetExpenseAsync(string companyId, string financialYearId,int srNo)
        {
            using (_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.ExpenseDetails.Where(w => w.IsDelete == false && w.CompanyId == companyId && w.FinancialYearId == financialYearId && w.SrNo == srNo).ToListAsync();
            }
        }

        public async Task<List<ExpenseDetails>> GetAllExpenseAsync(string companyId, string branchId, string financialYearId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.ExpenseDetails.Where(w => w.IsDelete == false && w.CompanyId == companyId && w.FinancialYearId == financialYearId).ToListAsync();
            }
        }

        public async Task<List<ExpenseSPModel>> GetExpenseReport(string companyId, string financialYearId, string fromDate, string toDate)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getExpenseReport = await _databaseContext.SPExpenseModel.FromSqlRaw($"GetExpenseReport '" + companyId + "','" + financialYearId + "', '"+ fromDate +"','"+ toDate +"'").ToListAsync();
                return getExpenseReport;
            }
        }

        public async Task<int> GetMaxSrNoAsync(string companyId, string financialYearId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                try
                {
                    var getCount = await _databaseContext.ExpenseDetails.Where(w => w.CompanyId == companyId && w.FinancialYearId == financialYearId).MaxAsync(m => m.SrNo);
                    return getCount + 1;
                }
                catch (Exception ex)
                {
                    return 1;
                }
            }
        }

        public async Task<bool> UpdateBalanceAsync(string partyId, string fromParty, decimal amount)
        {
            using (_databaseContext = new DatabaseContext())
            {
                try
                {
                    var mainParty = await _databaseContext.PartyMaster.Where(w => w.Id == partyId).FirstOrDefaultAsync();
                    var localParty = await _databaseContext.PartyMaster.Where(w => w.Id == fromParty).FirstOrDefaultAsync();

                    mainParty.OpeningBalance += amount;
                    localParty.OpeningBalance -= amount;

                    await _databaseContext.SaveChangesAsync();
                    
                    return true;
                }
                catch
                {
                    return false;
                }
            }            
        }

        public async Task<ExpenseDetails> UpdateExpenseAsync(ExpenseDetails expenseDetails)
        {
            using (_databaseContext = new DatabaseContext())
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
                        getExpense.Amount = expenseDetails.Amount;
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
}
