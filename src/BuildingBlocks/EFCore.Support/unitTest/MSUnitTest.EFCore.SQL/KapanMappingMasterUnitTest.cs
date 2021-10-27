using EFCore.SQL.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSUnitTest.EFCore.SQL
{
    [TestClass]
    public class KapanMappingMasterUnitTest
    {
        private readonly KapanMappingMasterRepository _kapanMappingMaster;

        public KapanMappingMasterUnitTest()
        {
            _kapanMappingMaster = new KapanMappingMasterRepository();
        }

        [TestMethod]
        public void GetAllBranchUsingSP()
        {
            var data = _kapanMappingMaster.GetPendingKapanMapping("","","");
            if (data != null)
                Assert.IsTrue(true);
            Assert.IsTrue(false);
        }
    }
}
