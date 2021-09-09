using Repository.Entities;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface ICompanyMaster
    {        
        Task<List<CompanyMaster>> GetAllCompanyAsync();
        Task<CompanyMaster> AddCompanyAsync(CompanyMaster companyMaster);
        Task<CompanyMaster> UpdateCompanyAsync(CompanyMaster companyMaster);
        Task<bool> DeleteCompanyAsync(Guid CompanyId);
    }  
}
