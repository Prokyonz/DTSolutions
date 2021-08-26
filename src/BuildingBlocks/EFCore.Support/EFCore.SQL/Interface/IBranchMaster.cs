using Repository.Entities;
using System.Linq;

namespace EFCore.SQL.Interface
{
    public interface IBranchMaster
    {
        IQueryable<BranchMaster> GetAllCompany();
        BranchMaster AddCompany(BranchMaster companyMaster);
        BranchMaster UpdateCompany(BranchMaster companyMaster);
        bool DeleteCompany(int CompanyId);
    }
}
