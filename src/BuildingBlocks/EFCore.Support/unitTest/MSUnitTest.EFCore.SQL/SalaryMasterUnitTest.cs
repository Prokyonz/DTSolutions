using EFCore.SQL.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSUnitTest.EFCore.SQL
{
    [TestClass]
    public class SalaryMasterUnitTest
    {
        private readonly SalaryMasterRepository _salaryMasterRepository;

        public SalaryMasterUnitTest()
        {
            _salaryMasterRepository = new SalaryMasterRepository();
        }

    }
}
