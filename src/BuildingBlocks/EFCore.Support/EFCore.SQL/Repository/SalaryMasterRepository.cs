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
    public class SalaryMasterRepository : ISalaryMaster
    {
        private DatabaseContext _databaseContext;

        public SalaryMasterRepository()
        {
        }
        public async Task<SalaryMaster> AddSalary(SalaryMaster salaryMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                if (salaryMaster.Id == null)
                    salaryMaster.Id = Guid.NewGuid().ToString();

                await _databaseContext.SalaryMaster.AddAsync(salaryMaster);
                await _databaseContext.SaveChangesAsync();
                return salaryMaster;
            }
        }

        public async Task<bool> DeleteSalary(string salaryMasterId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var salaryRecord = await _databaseContext.SalaryMaster.Where(w => w.Id == salaryMasterId).FirstOrDefaultAsync();
                if (salaryRecord != null)
                {
                    var salaryDetailRecord = await _databaseContext.SalaryDetails.Where(w => w.SalaryMasterId == salaryMasterId).ToListAsync();
                    if (salaryDetailRecord != null)
                        _databaseContext.SalaryDetails.RemoveRange(salaryDetailRecord);

                    _databaseContext.SalaryMaster.Remove(salaryRecord);

                    await _databaseContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
        }

        public async Task<long> GetMaxSrNoAsync(string companyId, string finanialYearId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getCountRecord = await _databaseContext.SalaryMaster.Where(w => w.CompanyId == companyId && w.FinancialYearId == finanialYearId).OrderByDescending(o => o.Sr).FirstOrDefaultAsync();
                if (getCountRecord != null)
                    return getCountRecord.SrNo + 1;
                return 1;
            }
        }

        public async Task<List<SalaryMaster>> GetSalaries(string companyId, string branchId, string financialYear)
        {
            using (_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.SalaryMaster.Where(w => w.CompanyId == companyId && w.FinancialYearId == financialYear).Include("SalaryDetails").ToListAsync();
            }
        }

        public async Task<List<SalaryReportSPModel>> GetSalaries(string companyId, string financialYear)
        {
            using (_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.SPSalaryReport.FromSqlRaw($"GetSalaryReport '" + companyId + "','" + financialYear + "'").ToListAsync(); 
            }
        }

        public async Task<SalaryMaster> GetSalaries(int month, string companyId, string branchId, string financialYear)
        {
            using (_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.SalaryMaster.Where(w => w.SalaryMonthDateTime.Month == month && w.CompanyId == companyId && w.FinancialYearId == financialYear).Include("SalaryDetails").FirstOrDefaultAsync();
            }
        }

        public async Task<bool> UpdateSalary(SalaryMaster salaryMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var salaryRecord = await _databaseContext.SalaryMaster.Where(w => w.Id == salaryMaster.Id).FirstOrDefaultAsync();
                if (salaryRecord != null)
                {
                    salaryRecord.CompanyId = salaryMaster.CompanyId;
                    salaryRecord.BranchId = salaryMaster.BranchId;
                    salaryRecord.FinancialYearId = salaryMaster.FinancialYearId;
                    salaryRecord.SalaryMonth = salaryMaster.SalaryMonth;
                    salaryRecord.SalaryMonthDateTime = salaryMaster.SalaryMonthDateTime;
                    salaryMaster.MonthDays = salaryMaster.MonthDays;
                    salaryMaster.Holidays = salaryMaster.Holidays;
                    salaryMaster.Remarks = salaryMaster.Remarks;
                    salaryMaster.UpdatedBy = salaryMaster.UpdatedBy;
                    salaryMaster.UpdatedDate = salaryMaster.UpdatedDate;

                    var salaryDetails = await _databaseContext.SalaryDetails.Where(w => w.SalaryMasterId == salaryMaster.Id).ToListAsync();

                    _databaseContext.SalaryDetails.RemoveRange(salaryDetails);

                    await _databaseContext.SalaryDetails.AddRangeAsync(salaryMaster.SalaryDetails);
                    await _databaseContext.SaveChangesAsync();

                    return true;
                }

                return false;
            }
        }
    }
}