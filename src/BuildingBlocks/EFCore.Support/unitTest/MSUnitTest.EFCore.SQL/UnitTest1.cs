using EFCore.SQL.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace MSUnitTest.EFCore.SQL
{
    [TestClass]
    public class PurityMasterTest
    {
        private readonly PurityMasterRepository _purityMasterRepository;

        public PurityMasterTest()
        {
            _purityMasterRepository = new PurityMasterRepository();
        }

        [TestMethod]
        public async Task GetPurityMasterRecordAsync()
        {
            await _purityMasterRepository.AddPurityAsync(new Repository.Entities.PurityMaster
            {
                Name = "Purity1",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                CreatedBy = 1,
                UpdatedBy = 1,
                IsDelete = false
            });

            var data = await _purityMasterRepository.GetAllPurityAsync();
            Assert.IsFalse(data.Count == 0);
            foreach (var item in data)
            {
                if (item.Name == "Purity1")
                    Assert.IsTrue(true);
            }
        }
    }
}
