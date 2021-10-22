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
    public class SalaryMasterRepository : ISalaryMaster, IDisposable
    {
        private readonly DatabaseContext _databaseContext;

        public SalaryMasterRepository()
        {
            _databaseContext = new DatabaseContext();
        }
        public async Task<SalaryMaster> AddSalary(SalaryMaster salaryMaster)
        {
            if (salaryMaster.Id == null)
                salaryMaster.Id = Guid.NewGuid().ToString();

            await _databaseContext.SalaryMaster.AddAsync(salaryMaster);
            await _databaseContext.SaveChangesAsync();
            return salaryMaster;
        }

        public async Task<bool> DeleteSalary(string salaryMasterId)
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

        public void Dispose()
        {
            _databaseContext.DisposeAsync();
        }

        public async Task<List<SalaryMaster>> GetSalaries(string companyId, string branchId, string financialYear)
        {
            return await _databaseContext.SalaryMaster.Where(w => w.CompanyId == companyId && w.BranchId == branchId && w.FinancialYearId == financialYear).Include("SalaryDetails").ToListAsync();
        }

        public async Task<SalaryMaster> GetSalaries(int month, string companyId, string branchId, string financialYear)
        {
            return await _databaseContext.SalaryMaster.Where(w => w.SalaryMonthDateTime.Month == month && w.CompanyId == companyId && w.BranchId == branchId && w.FinancialYearId == financialYear).Include("SalaryDetails").FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateSalary(SalaryMaster salaryMaster)
        {
            var salaryRecord = await _databaseContext.SalaryMaster.Where(w => w.Id == salaryMaster.Id).FirstOrDefaultAsync();
            if (salaryRecord != null)
            {
                salaryRecord.CompanyId = salaryMaster.CompanyId;
                salaryRecord.BranchId = salaryMaster.BranchId;
                salaryRecord.FinancialYearId = salaryMaster.FinancialYearId;
                salaryRecord.SalaryMonthName = salaryMaster.SalaryMonthName;
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