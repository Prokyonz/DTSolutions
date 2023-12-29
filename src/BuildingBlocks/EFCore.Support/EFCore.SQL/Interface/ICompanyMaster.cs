using Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface ICompanyMaster
    {        
        Task<List<CompanyMaster>> GetAllCompanyAsync();
        Task<CompanyMaster> AddCompanyAsync(CompanyMaster companyMaster);
        Task<CompanyMaster> UpdateCompanyAsync(CompanyMaster companyMaster);
        Task<int> DeleteCompanyAsync(string CompanyId);
        Task<List<CompanyMaster>> GetUserCompanyMappingAsync(string userId);
    }  
}
