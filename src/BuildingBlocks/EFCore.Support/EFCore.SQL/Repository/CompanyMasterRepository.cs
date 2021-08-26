using EFCore.SQL.DBContext;
using EFCore.SQL.Interface;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.SQL.Repository
{
    public class CompanyMasterRepository : ICompanyMaster, IDisposable
    {
        private readonly DatabaseContext _databaseContext;
        public CompanyMasterRepository()
        {
            _databaseContext = new DatabaseContext();
        }
        public async Task<CompanyMaster> AddCompanyAsync(CompanyMaster companyMaster)
        {
            try
            {
                await _databaseContext.AddAsync(companyMaster);
                await _databaseContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            
            return companyMaster;
        }

        public async Task<bool> DeleteCompanyAsync(int CompanyId)
        {
            var getCompany = await _databaseContext.CompanyMaster.Where(s => s.Id == CompanyId).FirstOrDefaultAsync();
            if(getCompany != null)
            {
                getCompany.IsDelete = true;
            }
            await _databaseContext.SaveChangesAsync();
            return true;
        }

        public void Dispose()
        {
            _databaseContext.DisposeAsync();
        }

        public IQueryable<CompanyMaster> GetAllCompany()
        {
            return _databaseContext.CompanyMaster.Where(s => s.IsDelete == false);
        }

        public async Task<CompanyMaster> UpdateCompanyAsync(CompanyMaster companyMaster)
        {
            var getCompany = await _databaseContext.CompanyMaster.Where(s => s.Id == companyMaster.Id).FirstOrDefaultAsync();
            if (getCompany != null)
            {
                getCompany.Name = companyMaster.Name;
            }
            await _databaseContext.SaveChangesAsync();
            return companyMaster;
        }
    }
}
