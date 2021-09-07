using EFCore.SQL.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSUnitTest.EFCore.SQL
{
    [TestClass]
    public class UserMasterUnitTest
    {
        private readonly UserMasterRepository _userMasterRepository;

        public UserMasterUnitTest()
        {
            _userMasterRepository = new UserMasterRepository();
        }

        [TestMethod]
        public void AddUserRecord()
        {
            Guid tempId = Guid.NewGuid();
            _ = _userMasterRepository.AddUserAsync(new Repository.Entities.UserMaster
            {
                Id = tempId,
                Name = "abedre",
                BranchId = tempId,
                AadharCardNo = "2346",
                Address = "Suat",
                Address2 = "Suat",
                EmailId = "abedre@gmail.com",
                HomeNo = "123465",
                IsDetele = false,
                MobileNo = "132456",
                Password="abedre",
                ReferenceBy= "",
                Type = 0,
                CreatedBy = tempId,
                CreatedDate = DateTime.Now,
                UpdatedBy = tempId,
                UpdateDate = DateTime.Now
            }).Result;

            //PurityMaster purityMaster = _purityMasterRepository.GetPurityById(tempId).Result;
            //_ = _purityMasterRepository.DeletePurityAsync(tempId, true).Result;

            //Assert.IsTrue(purityMaster.Id == tempId);
        }
    }
}
