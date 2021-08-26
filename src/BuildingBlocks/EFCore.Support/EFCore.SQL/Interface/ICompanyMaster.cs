using Repository.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface ICompanyMaster
    {
        IQueryable<CompanyMaster> GetAllCompany();
        Task<CompanyMaster> AddCompanyAsync(CompanyMaster companyMaster);
        Task<CompanyMaster> UpdateCompanyAsync(CompanyMaster companyMaster);
        Task<bool> DeleteCompanyAsync(int CompanyId);
    }
}
