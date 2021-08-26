using Repository.Entities;
using System.Linq;

namespace EFCore.SQL.Interface
{
    public interface ICompanyMaster
    {
        IQueryable<CompanyMaster> GetAllCompany();
        CompanyMaster AddCompany(CompanyMaster companyMaster);
        CompanyMaster UpdateCompany(CompanyMaster companyMaster);
        bool DeleteCompany(int CompanyId);
    }
}
