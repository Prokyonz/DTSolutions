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
        private readonly DatabaseContext _databaseContext;

        public FinancialYearMasterRepository()
        {
            _databaseContext = new DatabaseContext();
        }
        public async Task<FinancialYearMaster> AddFinancialYearAsync(FinancialYearMaster financialYearMaster)
        {
            if (financialYearMaster.Id == null)
                financialYearMaster.Id = Guid.NewGuid();
            await _databaseContext.FinancialYearMaster.AddAsync(financialYearMaster);
            await _databaseContext.SaveChangesAsync();
            return financialYearMaster;
        }

        public async Task<bool> DeleteFinancialYearAsync(Guid financialYearId, bool isPermanantDetele = false)
        {
            var getFinancialYear = await _databaseContext.FinancialYearMaster.Where(s =>s.IsDelete == false &&  s.Id == financialYearId).FirstOrDefaultAsync();
            if(getFinancialYear != null)
            {
                if (isPermanantDetele)
                    _databaseContext.FinancialYearMaster.Remove(getFinancialYear);
                else
                    getFinancialYear.IsDelete = true;

                await _databaseContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<FinancialYearMaster>> GetAllFinancialYear()
        {
            return await _databaseContext.FinancialYearMaster.Where(w => w.IsDelete == false).ToListAsync();
        }
    }
}
