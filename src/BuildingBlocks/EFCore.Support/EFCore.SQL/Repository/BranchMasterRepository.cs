using EFCore.SQL.DBContext;
using EFCore.SQL.Interface;
using Repository.Entities;
using System;
using System.Linq;


namespace EFCore.SQL.Repository
{
    public class BranchMasterRepository : IBranchMaster
    {
        private readonly DatabaseContext _databaseContext;

        public BranchMasterRepository()
        {
            _databaseContext = new DatabaseContext();
        }

        public BranchMaster AddCompany(BranchMaster companyMaster)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCompany(int CompanyId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<BranchMaster> GetAllCompany()
        {
            return _databaseContext.BranchMaster;
        }

        public BranchMaster UpdateCompany(BranchMaster companyMaster)
        {
            throw new NotImplementedException();
        }
    }
}
