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

            //CompanyMaster companyMaster = new CompanyMaster();
            //companyMaster.Id = 1;
            //companyMaster.Name = "Updated Company";


            //companyMaster.Address = "Surat";
            //companyMaster.Address2 = "Surat";
            //companyMaster.MobileNo = "8530209649";
            //companyMaster.Details = "8530209649";
            //companyMaster.TermsCondition = "8530209649";
            //companyMaster.GSTNo = "8530209649";
            //companyMaster.PanCardNo = "8530209649";
            //companyMaster.AadharCardNo = "8530209649";
            //companyMaster.Type = 0;
            //companyMaster.IsDelete = false;
            //companyMaster.CreatedDate = DateTime.Now;
            //companyMaster.UpdatedDate = DateTime.Now;
            //companyMaster.CreatedBy = 1;
            //companyMaster.UpdatedBy = 1;

            //var data = companyMasterRepository.UpdateCompanyAsync(companyMaster);

            Data();
            Console.WriteLine("Didn't wait here");
            Console.ReadKey();
        }

        public async static void Data()
        {
            CompanyMasterRepository companyMasterRepository = new CompanyMasterRepository();
            var companyMasters = await companyMasterRepository.GetAllCompanyAsync();
            int i = companyMasters.Count();
            Console.WriteLine(i);            

        }
    }
}
