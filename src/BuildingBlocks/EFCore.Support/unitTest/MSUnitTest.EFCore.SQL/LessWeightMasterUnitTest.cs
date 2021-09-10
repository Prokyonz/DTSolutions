using EFCore.SQL.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSUnitTest.EFCore.SQL
{
    [TestClass]
    public class LessWeightMasterUnitTest
    {
        private readonly LessWeightMasterRepository _lessWeightMasterRepositoy;

        public LessWeightMasterUnitTest()
        {
            _lessWeightMasterRepositoy = new LessWeightMasterRepository();
        }

        [TestMethod]
        public void AddMasterAndDetails()
        {
            Guid tempGid = Guid.NewGuid();
            LessWeightMaster lessWeightMaster = new LessWeightMaster
            {
                Id = tempGid,
                Name = "First Group",
                IsDelete = false,
                BranchId = Guid.Parse("0A8689F1-5920-4F38-99D0-4B479B2ED043"),
                CreatedBy = tempGid,
                CreatedDate = DateTime.Now,
                UpdatedBy = tempGid,
                UpdatedDate = DateTime.Now,
                LessWeightDetails = new List<LessWeightDetails>
                {
                   new LessWeightDetails
                   {
                       Id = Guid.NewGuid(),
                       LessWeight = 10.2f,
                       LessWeightId = tempGid,
                       MaxWeight = 15.2f,
                       MinWeight = 9.5f,
                   },
                   new LessWeightDetails
                   {
                       Id = Guid.NewGuid(),
                       LessWeight = 12.2f,
                       LessWeightId = tempGid,
                       MaxWeight = 13.2f,
                       MinWeight = 5.5f,
                   }
                }
            };

            _ = _lessWeightMasterRepositoy.AddLessWeightMaster(lessWeightMaster).Result;
        }

        [TestMethod]
        public void UpdateMasterAndDetails()
        {

            LessWeightMaster lessWeightMaster = new LessWeightMaster
            {
                Id = Guid.Parse("1F617858-1ABB-43A8-911F-A7C4DD9840EE"),
                Name = "First Group",
                IsDelete = false,
                BranchId = Guid.Parse("0A8689F1-5920-4F38-99D0-4B479B2ED043"),
                CreatedBy = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                UpdatedBy = Guid.NewGuid(),
                UpdatedDate = DateTime.Now,
                LessWeightDetails = new List<LessWeightDetails>
                {
                   new LessWeightDetails
                   {
                       Id = Guid.Parse("FCD3A1D1-B606-489D-942E-38517B27C16A"),
                       LessWeight = 11.2f,
                       LessWeightId = Guid.Parse("1F617858-1ABB-43A8-911F-A7C4DD9840EE"),
                       MaxWeight = 16.2f,
                       MinWeight = 4.5f,
                   },
                   new LessWeightDetails
                   {
                       Id = Guid.Parse("2C6D4500-64F4-4B18-AABB-5764576DE501"),
                       LessWeight = 20.2f,
                       LessWeightId = Guid.Parse("1F617858-1ABB-43A8-911F-A7C4DD9840EE"),
                       MaxWeight = 28.2f,
                       MinWeight = 1.5f,
                   }
                }
            };

            _ = _lessWeightMasterRepositoy.UpdateLessWeightMaster(lessWeightMaster).Result;
        }
    }
}
