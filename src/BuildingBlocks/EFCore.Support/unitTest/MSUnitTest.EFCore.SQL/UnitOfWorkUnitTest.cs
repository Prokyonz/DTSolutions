using EFCore.SQL.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSUnitTest.EFCore.SQL
{
    [TestClass]
    public class UnitOfWorkUnitTest
    {
        private readonly UnitOfWorkMaster _unitOfWorkMaster;

        public UnitOfWorkUnitTest()
        {
            _unitOfWorkMaster = new UnitOfWorkMaster();
        }

        [TestMethod]
        public void GetCompany()
        {
            var companyMasters = _unitOfWorkMaster.CurrencyMasterRepository.GetAllCurrencyAsync("").Result;
           

            Assert.IsTrue(companyMasters.Count > 0);
        }
    }
}
