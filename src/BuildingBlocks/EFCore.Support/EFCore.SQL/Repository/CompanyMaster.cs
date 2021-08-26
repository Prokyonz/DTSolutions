using EFCore.SQL.DBContext;
using EFCore.SQL.Interface;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCore.SQL.Repository
{
    public class CompanyMasterRepository : ICompanyMaster
    {
        private readonly DatabaseContext _databaseContext;
        public CompanyMasterRepository()
        {
            _databaseContext = new DatabaseContext();
        }
        public CompanyMaster AddCompany(CompanyMaster companyMaster)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCompany(int CompanyId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<CompanyMaster> GetAllCompany()
        {
            return _databaseContext.CompanyMaster;
        }

        public CompanyMaster UpdateCompany(CompanyMaster companyMaster)
        {
            throw new NotImplementedException();
        }
    }
}
