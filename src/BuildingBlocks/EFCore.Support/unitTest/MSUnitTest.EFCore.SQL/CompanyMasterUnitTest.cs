using EFCore.SQL.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSUnitTest.EFCore.SQL
{
    [TestClass]
    public class CompanyMasterUnitTest
    {
        private readonly CompanyMasterRepository _companyMasterRepository;

        public CompanyMasterUnitTest()
        {
            _companyMasterRepository = new CompanyMasterRepository();
        }

        [TestMethod]
        public void AddCompanyRecord()
        {
            string tempId = Guid.NewGuid().ToString();
            _ = _companyMasterRepository.AddCompanyAsync(new CompanyMaster
            {
                Id = tempId,
                Address = "Surat",
                Address2 = "Surat",
                Details = "",
                GSTNo = "123456",
                PanCardNo = "46546",
                IsDelete = false,
                Name = "infologs",
                MobileNo = "123456",
                OfficeNo = "8954646",
                RegistrationNo = "4564897",
                TermsCondition = "5464",
                Type = null,
                UpdatedBy = tempId,
                CreatedBy = tempId,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            }).Result;

            List<CompanyMaster> result = _companyMasterRepository.GetAllCompanyAsync().Result;
            bool tempResult = false;

            foreach (var item in result)
            {
                if (item.Id == tempId)
                {
                    tempResult = true;
                }
            }
            Assert.IsTrue(tempResult);
        }

        [TestMethod]
        public void GetAllBranchUsingSP()
        {
            var data = _companyMasterRepository.GetAllCompanyAsync().Result;
            if (data != null)
                Assert.IsTrue(true);
            Assert.IsTrue(false);
        }
    }
}
