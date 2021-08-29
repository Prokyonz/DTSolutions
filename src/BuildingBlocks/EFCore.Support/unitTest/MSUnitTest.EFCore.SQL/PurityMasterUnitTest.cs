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
        public async Task AddPurityRecord()
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
            Assert.IsTrue(true);
        }

        [TestMethod]
        public async Task GetPurityRecord()
        {
            var data = await _purityMasterRepository.GetAllPurityAsync();
            Assert.IsFalse(data.Count == 0);
            foreach (var item in data)
            {
                if (item.Name == "Purity1")
                {                    
                    Assert.IsTrue(true);
                }
            }
        }


        [TestMethod]
        public async Task UpdatePurityRecord()
        {
            //await _purityMasterRepository.UpdatePurityAsync(new Repository.Entities.PurityMaster
            //{
            //    Id = 1,
            //    Name = "Purity2",
            //    CreatedDate = DateTime.Now,
            //    UpdatedDate = DateTime.Now,
            //    CreatedBy = 1,
            //    UpdatedBy = 1,
            //    IsDelete = false
            //});
        }

        [TestMethod]
        public async Task DeletePurityRecord()
        {            
            var data = await _purityMasterRepository.GetAllPurityAsync();
            foreach (var item in data)
            {
                if (item.Name == "Purity1")
                {                    
                    await _purityMasterRepository.DeletePurityAsync(item.Id);
                }
            }

            var data1 = await _purityMasterRepository.GetAllPurityAsync();
            foreach (var item in data)
            {
                if (item.Name == "Purity1")
                {
                    Assert.IsTrue(item.IsDelete);
                }
            }
        }

        [TestMethod]
        public async Task PermanantDeletePurityRecord()
        {
            var data = await _purityMasterRepository.GetAllPurityAsync();
            foreach (var item in data)
            {
                if (item.Name == "Purity1")
                {
                    Assert.IsTrue(await _purityMasterRepository.DeletePurityAsync(item.Id, true));
                }
            }
        }
    }
}
