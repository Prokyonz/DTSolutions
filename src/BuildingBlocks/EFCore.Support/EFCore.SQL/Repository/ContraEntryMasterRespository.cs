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
    public class ContraEntryMasterRespository : IContraEntryMaster, IDisposable
    {
        private readonly DatabaseContext _databaseContext;

        public ContraEntryMasterRespository()
        {
            _databaseContext = new DatabaseContext();
        }
        public async Task<ContraEntryMaster> AddContraEntryAsync(ContraEntryMaster contraEntryMaster)
        {
            if (contraEntryMaster.Id == null)
                contraEntryMaster.Id = Guid.NewGuid().ToString();
            await _databaseContext.ContraEntryMaster.AddAsync(contraEntryMaster);
            await _databaseContext.SaveChangesAsync();
            return contraEntryMaster;
        }

        public async Task<bool> DeleteContraEntryAsync(string contraEntryId)
        {
            var getContraEntry = await _databaseContext.ContraEntryMaster.Where(w => w.Id == contraEntryId).FirstOrDefaultAsync();
            if(getContraEntry != null)
            {
                var getContraEnteryDetails = await _databaseContext.ContraEntryDetails.Where(w => w.ContraEntryMasterId == contraEntryId).ToListAsync();

                if (getContraEnteryDetails != null && getContraEnteryDetails.Count > 0)
                    _databaseContext.ContraEntryDetails.RemoveRange(getContraEnteryDetails);

                _databaseContext.ContraEntryMaster.Remove(getContraEntry);

                await _databaseContext.SaveChangesAsync();

                return true;
            }
            return false;
        }

        public void Dispose()
        {
            _databaseContext.DisposeAsync();
        }

        public async Task<List<ContraEntryMaster>> GetAllContraEntryAsync(string companyId, string financialYearId)
        {
            return await _databaseContext.ContraEntryMaster.Where(w => w.CompanyId == companyId && w.FinancialYearId == financialYearId).ToListAsync();
        }

        public async Task<int> GetMaxNo(string companyId, string financialYearId)
        {
            var record = await _databaseContext.ContraEntryMaster.Where(w => w.CompanyId == companyId && w.FinancialYearId == financialYearId).ToListAsync();
            if (record != null)
                return record.Count + 1;
            return 1;
        }

        public Task<ContraEntryMaster> UpdateContraEntryAsync(ContraEntryMaster contraEntryMaster)
        {
            throw new NotImplementedException();
        }
    }
}
