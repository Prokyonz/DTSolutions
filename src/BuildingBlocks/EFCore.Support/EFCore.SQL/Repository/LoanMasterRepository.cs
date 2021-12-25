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
    public class LoanMasterRepository : ILoanMaster
    {
        private DatabaseContext _databaseContext;

        public LoanMasterRepository()
        {

        }

        public async Task<LoanMaster> AddLoanAsync(LoanMaster loanMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                if (loanMaster.Id == null)
                    loanMaster.Id = Guid.NewGuid().ToString();
                await _databaseContext.LoanMaster.AddAsync(loanMaster);
                await _databaseContext.SaveChangesAsync();
                return loanMaster;
            }
        }

        public async Task<bool> DeleteLoanAsync(string loanId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getLoan = await _databaseContext.LoanMaster.Where(s => s.Id == loanId).FirstOrDefaultAsync();
                if (getLoan != null)
                {
                    _databaseContext.LoanMaster.Remove(getLoan);
                }

                await _databaseContext.SaveChangesAsync();
                return true;
            }
        }

        public async Task<List<LoanMaster>> GetAllLoanAsync(string CompanyId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var result = await _databaseContext.LoanMaster.Where(w => w.CompanyId == CompanyId).ToListAsync();
                return result;
            }
        }

        public async Task<List<LoanMaster>> GetAllLoanAsync(int loanType, string CompanyId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var result = await _databaseContext.LoanMaster.Where(w => w.CompanyId == CompanyId && w.LoanType == loanType).ToListAsync();
                return result;
            }
        }

        public async Task<LoanMaster> UpdateLoanAsync(LoanMaster loanMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getLoan = await _databaseContext.LoanMaster.Where(s => s.Id == loanMaster.Id).FirstOrDefaultAsync();
                if (getLoan != null)
                {
                    getLoan.CompanyId = loanMaster.CompanyId;
                    getLoan.LoanType = loanMaster.LoanType;

                    getLoan.PartyId = loanMaster.PartyId;
                    getLoan.Amount = loanMaster.Amount;
                    getLoan.DuratonType = loanMaster.DuratonType;
                    getLoan.StartDate = loanMaster.StartDate;
                    getLoan.EndDate = loanMaster.EndDate;
                    getLoan.InterestRate = loanMaster.InterestRate;
                    getLoan.TotalInterest = loanMaster.TotalInterest;
                    getLoan.NetAmount = loanMaster.NetAmount;
                    getLoan.Remarks = loanMaster.Remarks;
                    getLoan.IsDelete = false;
                    getLoan.UpdatedBy = loanMaster.UpdatedBy;
                    getLoan.UpdatedDate = loanMaster.UpdatedDate;                    
                }
                await _databaseContext.SaveChangesAsync();

                return loanMaster;
            }
        }
    }
}
