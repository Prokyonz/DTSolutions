using EFCore.SQL.Repository;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DBTest
{
    class Program
    {
        static void Main(string[] args)
        {
            CompanyMasterRepository companyMasterRepository = new CompanyMasterRepository();
            IQueryable<CompanyMaster> companyMasters  = companyMasterRepository.GetAllCompany();                        
        }
    }
}
