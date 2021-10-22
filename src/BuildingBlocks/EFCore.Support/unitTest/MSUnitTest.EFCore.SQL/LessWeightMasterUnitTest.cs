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
            string tempGid = Guid.NewGuid().ToString();
            LessWeightMaster lessWeightMaster = new LessWeightMaster
            {
                Id = tempGid,
                Name = "First Group",
                IsDelete = false,
                //BranchId = Guid.Parse("0A8689F1-5920-4F38-99D0-4B479B2ED043"),
                CreatedBy = tempGid,
                CreatedDate = DateTime.Now,
                UpdatedBy = tempGid,
                UpdatedDate = DateTime.Now,
                LessWeightDetails = new List<LessWeightDetails>
                {
                   new LessWeightDetails
                   {
                       Id = Guid.NewGuid().ToString(),
                       LessWeight = 10.2M,
                       LessWeightId = tempGid,
                       MaxWeight = 15.2M,
                       MinWeight = 9.5M,
                   },
                   new LessWeightDetails
                   {
                       Id = Guid.NewGuid().ToString(),
                       LessWeight = 12.2M,
                       LessWeightId = tempGid,
                       MaxWeight = 13.2M,
                       MinWeight = 5.5M,
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
                Id = "1F617858-1ABB-43A8-911F-A7C4DD9840EE",
                Name = "First Group158",
                IsDelete = false,
                //BranchId = Guid.Parse("0A8689F1-5920-4F38-99D0-4B479B2ED043"),
                CreatedBy = Guid.NewGuid().ToString(),
                CreatedDate = DateTime.Now,
                UpdatedBy = Guid.NewGuid().ToString(),
                UpdatedDate = DateTime.Now,
                LessWeightDetails = new List<LessWeightDetails>
                {
                   new LessWeightDetails
                   {
                       Id = Guid.NewGuid().ToString(),
                       LessWeight = 11.2M,
                       LessWeightId = "1F617858-1ABB-43A8-911F-A7C4DD9840EE",
                       MaxWeight = 11.2M,
                       MinWeight = 11.5M,
                   },
                   new LessWeightDetails
                   {
                       Id = Guid.NewGuid().ToString(),
                       LessWeight = 1.2M,
                       LessWeightId = "1F617858-1ABB-43A8-911F-A7C4DD9840EE",
                       MaxWeight = 1.2M,
                       MinWeight = 1.5M,
                   },
                   new LessWeightDetails
                   {
                       Id = Guid.NewGuid().ToString(),
                       LessWeight = 1.2M,
                       LessWeightId = "1F617858-1ABB-43A8-911F-A7C4DD9840EE",
                       MaxWeight = 1.2M,
                       MinWeight = 1.5M,
                   }
                   ,
                   new LessWeightDetails
                   {
                       Id = Guid.NewGuid().ToString(),
                       LessWeight = 1.2M,
                       LessWeightId = "1F617858-1ABB-43A8-911F-A7C4DD9840EE",
                       MaxWeight = 1.2M,
                       MinWeight = 1.5M,
                   }


                }
            };
            try
            {
                _ = _lessWeightMasterRepositoy.UpdateLessWeightMaster(lessWeightMaster).Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
