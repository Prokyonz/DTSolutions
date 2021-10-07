using EFCore.SQL.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSUnitTest.EFCore.SQL
{
    [TestClass]
    public class BranchMasterUnitTest
    {
        private readonly BranchMasterRepository _branchMasterRepository;

        public BranchMasterUnitTest()
        {
            _branchMasterRepository = new BranchMasterRepository();
        }

        [TestMethod]
        public void GetAllBranchUsingSP()
        {
            var data = _branchMasterRepository.GetAllBranchAsync().Result;
            if (data != null)
                Assert.IsTrue(true);
            Assert.IsTrue(false);
        }
    }
}
