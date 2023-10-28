using EFCore.SQL.DBContext;
using EFCore.SQL.Interface;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.SQL.Repository
{
    public class FinancialYearMasterRepository : IFinancialYearMaster
    {
        private DatabaseContext _databaseContext;

        public FinancialYearMasterRepository()
        {

        }
        public async Task<FinancialYearMaster> AddFinancialYearAsync(FinancialYearMaster financialYearMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                if (financialYearMaster.Id == null)
                    financialYearMaster.Id = Guid.NewGuid().ToString();
                await _databaseContext.FinancialYearMaster.AddAsync(financialYearMaster);
                await _databaseContext.SaveChangesAsync();
                return financialYearMaster;
            }
        }

        public async Task<int> DeleteFinancialYearAsync(string financialYearId, bool isPermanantDetele = false)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var resultCount = await _databaseContext.SPValidationModel.FromSqlRaw($"Validate_Records '" + financialYearId + "',3").ToListAsync();
                return resultCount[0].Status;

                //var getFinancialYear = await _databaseContext.FinancialYearMaster.Where(s => s.IsDelete == false && s.Id == financialYearId).FirstOrDefaultAsync();
                //if (getFinancialYear != null)
                //{
                //    if (isPermanantDetele)
                //        _databaseContext.FinancialYearMaster.Remove(getFinancialYear);
                //    else
                //        getFinancialYear.IsDelete = true;

                //    await _databaseContext.SaveChangesAsync();
                //    return true;
                //}
                //return false;
            }
        }

        public async Task<List<FinancialYearMaster>> GetAllFinancialYear()
        {
            using (_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.FinancialYearMaster.Where(w => w.IsDelete == false).ToListAsync();
            }
        }

        public async Task<FinancialYearMaster> UpdateFinancialYearAsync(FinancialYearMaster financialYearMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getFinancialYear = await _databaseContext.FinancialYearMaster.Where(s => s.Id == financialYearMaster.Id).FirstOrDefaultAsync();
                if (getFinancialYear != null)
                {
                    getFinancialYear.Name = financialYearMaster.Name;
                    getFinancialYear.StartDate = financialYearMaster.StartDate;
                    getFinancialYear.EndDate = financialYearMaster.EndDate;
                    getFinancialYear.UpdatedDate = financialYearMaster.UpdatedDate;
                    getFinancialYear.UpdatedBy = financialYearMaster.UpdatedBy;
                }
                await _databaseContext.SaveChangesAsync();
                return financialYearMaster;
            }
        }
    }
}
