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
                
                var partyLedger = await _databaseContext.PartyMaster.Where(w => w.Id == loanMaster.PartyId).FirstOrDefaultAsync();
                if(partyLedger != null)
                {
                    partyLedger.OpeningBalance += loanMaster.Amount;
                }

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

        public LoanMaster GetLoanAsync(string loanId, string companyId, string financialYearId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var result = _databaseContext.LoanMaster.Where(w => w.CompanyId == companyId && w.FinancialYearId == financialYearId && w.Id == loanId).FirstOrDefault();
                return result;
            }
        }

        public async Task<List<LoanSPModel>> GetLoanReportAsync(string CompanyId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getLoanReport = await _databaseContext.SPLoanReportModel.FromSqlRaw($"GetLoanReport '" + CompanyId + "'").ToListAsync();
                return getLoanReport;
            }
        }

        public async Task<long> GetMaxSrNo(string companyId)
        {
            try
            {
                using (_databaseContext = new DatabaseContext())
                {
                    var result = await _databaseContext.LoanMaster.Where(w=> w.CompanyId == companyId).MaxAsync(m => m.Sr);
                    return result + 1;
                }
            }
            catch (Exception ex)
            {
                return 1;
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
                    getLoan.FinancialYearId = loanMaster.FinancialYearId;
                    getLoan.CashBankPartyId = loanMaster.CashBankPartyId;
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
                    getLoan.EntryDate = loanMaster.EntryDate;
                    getLoan.EntryTime = loanMaster.EntryTime;
                    getLoan.UpdatedBy = loanMaster.UpdatedBy;
                    getLoan.UpdatedDate = loanMaster.UpdatedDate;                    
                }
                await _databaseContext.SaveChangesAsync();

                return loanMaster;
            }
        }
    }
}
