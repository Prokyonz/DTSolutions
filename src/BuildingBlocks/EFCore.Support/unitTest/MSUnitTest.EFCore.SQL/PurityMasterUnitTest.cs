using EFCore.SQL.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.Entities;
using System;
using System.Linq;
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
        public void AddPurityRecord()
        {
            var purityList = PurityMaster.FakeData.Generate(1).ToList();
            _ = _purityMasterRepository.AddPurityAsync(purityList[0]).Result;

            PurityMaster purityMaster = _purityMasterRepository.GetPurityById(purityList[0].Id).Result;
            _ = _purityMasterRepository.DeletePurityAsync(purityList[0].Id, true).Result;

            Assert.IsTrue(purityMaster.Id == purityList[0].Id);
        }

        [TestMethod]
        public void GetPurityRecord()
        {
            string tempId = Guid.NewGuid().ToString();
            _ = _purityMasterRepository.AddPurityAsync(new Repository.Entities.PurityMaster
            {
                Id = tempId,
                Name = "Purity1",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                CreatedBy = Guid.NewGuid().ToString(),
                UpdatedBy = Guid.NewGuid().ToString(),
                IsDelete = false
            }).Result;

            var data = _purityMasterRepository.GetAllPurityAsync().Result;
            Assert.IsFalse(data.Count == 0);
            foreach (var item in data)
            {
                if (item.Name == "Purity1")
                {
                    _ = _purityMasterRepository.DeletePurityAsync(tempId, true).Result;
                    Assert.IsTrue(true);
                }
            }
        }


        [TestMethod]
        public void UpdatePurityRecord()
        {
            string tempId = Guid.NewGuid().ToString();
            _ = _purityMasterRepository.AddPurityAsync(new Repository.Entities.PurityMaster
            {
                Id = tempId,
                Name = "Purity1",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                CreatedBy = Guid.NewGuid().ToString(),
                UpdatedBy = Guid.NewGuid().ToString(),
                IsDelete = false
            }).Result;

            var data = _purityMasterRepository.UpdatePurityAsync(new Repository.Entities.PurityMaster
            {
                Id = tempId,
                Name = "Purity2",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                CreatedBy = Guid.NewGuid().ToString(),
                UpdatedBy = Guid.NewGuid().ToString(),
                IsDelete = false
            }).Result;

            var result = _purityMasterRepository.GetPurityById(tempId).Result;
            _ = _purityMasterRepository.DeletePurityAsync(tempId, true).Result;

            Assert.IsTrue(data.Id == result.Id && data.Name == result.Name);
        }

        [TestMethod]
        public async Task DeletePurityRecord()
        {
            string tempId = Guid.NewGuid().ToString();
            _ = _purityMasterRepository.AddPurityAsync(new Repository.Entities.PurityMaster
            {
                Id = tempId,
                Name = "Purity1",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                CreatedBy = Guid.NewGuid().ToString(),
                UpdatedBy = Guid.NewGuid().ToString(),
                IsDelete = false
            }).Result;

            _ = _purityMasterRepository.DeletePurityAsync(tempId).Result;

            var data = await _purityMasterRepository.GetPurityById(tempId, true);
            _ = _purityMasterRepository.DeletePurityAsync(tempId, true).Result;
            Assert.IsTrue(data.IsDelete);
        }

        [TestMethod]
        public async Task PermanantDeletePurityRecord()
        {
            string tempId = Guid.NewGuid().ToString();
            _ = _purityMasterRepository.AddPurityAsync(new Repository.Entities.PurityMaster
            {
                Id = tempId,
                Name = "Purity1",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                CreatedBy = Guid.NewGuid().ToString(),
                UpdatedBy = Guid.NewGuid().ToString(),
                IsDelete = false
            }).Result;

            _ = _purityMasterRepository.DeletePurityAsync(tempId, true).Result;

            var data = await _purityMasterRepository.GetPurityById(tempId);
            Assert.IsNull(data);
        }
    }
}
