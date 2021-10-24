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
    public class CompanyMasterRepository : ICompanyMaster, IDisposable
    {
        private DatabaseContext _databaseContext;
        public CompanyMasterRepository()
        {
            
        }
        public async Task<CompanyMaster> AddCompanyAsync(CompanyMaster companyMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                try
                {
                    if (companyMaster.Id == null)
                        companyMaster.Id = Guid.NewGuid().ToString();

                    await _databaseContext.CompanyMaster.AddAsync(companyMaster);
                    await _databaseContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw;
                }

                return companyMaster;
            }
        }

        public async Task<bool> DeleteCompanyAsync(string CompanyId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getCompany = await _databaseContext.CompanyMaster.Where(s => s.Id == CompanyId).FirstOrDefaultAsync();
                if (getCompany != null)
                {
                    getCompany.IsDelete = true;
                }
                await _databaseContext.SaveChangesAsync();
                return true;
            }
        }

        public void Dispose()
        {
            _databaseContext.DisposeAsync();
        }

        public async Task<List<CompanyMaster>> GetAllCompanyAsync()
        {
            using (_databaseContext = new DatabaseContext())
            {
                List<CompanyMaster> companyMasters = await _databaseContext.CompanyMaster.Where(s => s.IsDelete == false).ToListAsync();
                return companyMasters;
            }
        }

        public async Task<List<CompanyMaster>> GetParentCompanyAsync()
        {
            using (_databaseContext = new DatabaseContext())
            {
                List<CompanyMaster> companyMasters = await _databaseContext.CompanyMaster.Where(s => s.IsDelete == false && s.Type == null).ToListAsync();
                return companyMasters;
            }
        }

        public async Task<CompanyMaster> UpdateCompanyAsync(CompanyMaster companyMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getCompany = await _databaseContext.CompanyMaster.Where(s => s.Id == companyMaster.Id).FirstOrDefaultAsync();
                if (getCompany != null)
                {
                    getCompany.Name = companyMaster.Name;
                    getCompany.Address = companyMaster.Address;
                    getCompany.Address2 = companyMaster.Address2;
                    getCompany.MobileNo = companyMaster.MobileNo;
                    getCompany.Details = companyMaster.Details;
                    getCompany.TermsCondition = companyMaster.TermsCondition;
                    getCompany.GSTNo = companyMaster.GSTNo;
                    getCompany.PanCardNo = companyMaster.PanCardNo;
                    getCompany.RegistrationNo = companyMaster.RegistrationNo;
                    getCompany.Type = companyMaster.Type;
                    getCompany.IsDelete = companyMaster.IsDelete;
                    getCompany.CreatedDate = companyMaster.CreatedDate;
                    getCompany.UpdatedDate = companyMaster.UpdatedDate;
                    getCompany.CreatedBy = companyMaster.CreatedBy;
                    getCompany.UpdatedBy = companyMaster.UpdatedBy;
                }
                await _databaseContext.SaveChangesAsync();
                return companyMaster;
            }
        }
    }
}
