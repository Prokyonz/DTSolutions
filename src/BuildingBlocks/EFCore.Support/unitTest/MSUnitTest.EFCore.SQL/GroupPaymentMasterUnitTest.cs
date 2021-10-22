using EFCore.SQL.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSUnitTest.EFCore.SQL
{
    [TestClass]
    public class GroupPaymentMasterUnitTest
    {
        private readonly PaymentMasterRepository _paymentMasterRepository;

        public GroupPaymentMasterUnitTest()
        {
            _paymentMasterRepository = new PaymentMasterRepository();
        }

        [TestMethod]
        public void AddGroupRecord()
        {
            Guid groupId = Guid.NewGuid();
            Guid paymentid = Guid.NewGuid();

            GroupPaymentMaster groupPaymentMaster = new GroupPaymentMaster
            {
                Id = groupId.ToString(),
                CompanyId = "0A8689F1-5920-4F38-99D0-4B479B2ED042",
                BranchId = "0A8689F1-5920-4F38-99D0-4B479B2ED043",
                IsDelete = false,
                Remarks = "First Payment",
                FinancialYearId = "99D6F778-A702-4197-9BA6-135709A27FC5",
                ToPartyId = "B6EC7276-AFE9-4511-86B7-98FC5E6487CE",
                UpdatedBy = Guid.NewGuid().ToString(),
                UpdatedDate = DateTime.Now,
                CreatedBy = Guid.NewGuid().ToString(),
                CreatedDate = DateTime.Now,
                PaymentMasters = new List<PaymentMaster>
                {
                    new PaymentMaster
                    {
                        Id = paymentid.ToString(),
                        GroupId = groupId.ToString(),
                        Amount = 5000,
                        ChequeDate = DateTime.Now,
                        ChequeNo = "1231564",
                        CrDrType = 0,
                        CreatedBy = Guid.NewGuid().ToString(),
                        CreatedDate = DateTime.Now,
                        FromPartyId = Guid.NewGuid().ToString(),
                        Remarks = "Pary Entry",
                        UpdatedBy = Guid.NewGuid().ToString(),
                        UpdatedDate = DateTime.Now,
                        PaymentDetails = new List<PaymentDetails>
                        {
                            new PaymentDetails
                            {
                                Id = Guid.NewGuid().ToString(),
                                CreatedBy = Guid.NewGuid().ToString(),
                                CreatedDate = DateTime.Now,
                                GroupId = groupId.ToString(),
                                PaymentId = paymentid.ToString(),
                                PurchaseId = Guid.NewGuid().ToString(),
                                UpdatedBy = Guid.NewGuid().ToString(),
                                UpdatedDate = DateTime.Now,
                            }
                        }
                    }
                }
            };

            var data = _paymentMasterRepository.AddPaymentAsync(groupPaymentMaster).Result;
            if (data.Id != null)
                Assert.IsTrue(true);
        }

        [TestMethod]
        public void UpdateGroupRecord()
        {

            Guid groupId = Guid.Parse("0F128B01-D242-49B3-9C9E-BE3E70FF9892");
            Guid paymentid = Guid.Parse("BEEC6DD2-D49E-4CF1-8A84-A656264AE87F");

            GroupPaymentMaster groupPaymentMaster = new GroupPaymentMaster
            {
                Id = groupId.ToString(),
                CompanyId = "0A8689F1-5920-4F38-99D0-4B479B2ED042",
                BranchId = "0A8689F1-5920-4F38-99D0-4B479B2ED043",
                IsDelete = false,
                Remarks = "First Payment From Group Master",
                FinancialYearId = "99D6F778-A702-4197-9BA6-135709A27FC5",
                ToPartyId = "B6EC7276-AFE9-4511-86B7-98FC5E6487CE",
                UpdatedBy = Guid.NewGuid().ToString(),
                UpdatedDate = DateTime.Now,
                CreatedBy = Guid.NewGuid().ToString(),
                CreatedDate = DateTime.Now,
                PaymentMasters = new List<PaymentMaster>
                {
                    new PaymentMaster
                    {
                        Id = paymentid.ToString(),
                        GroupId = groupId.ToString(),
                        Amount = 5000,
                        ChequeDate = DateTime.Now,
                        ChequeNo = "123456789",
                        CrDrType = 0,
                        CreatedBy = Guid.NewGuid().ToString(),
                        CreatedDate = DateTime.Now,
                        FromPartyId = Guid.NewGuid().ToString(),
                        Remarks = "Pary Entry Update",
                        UpdatedBy = Guid.NewGuid().ToString(),
                        UpdatedDate = DateTime.Now,
                        PaymentDetails = new List<PaymentDetails>
                        {
                            new PaymentDetails
                            {
                                Id = Guid.NewGuid().ToString(),
                                CreatedBy = Guid.NewGuid().ToString(),
                                CreatedDate = DateTime.Now,
                                GroupId = groupId.ToString(),
                                PaymentId = paymentid.ToString(),
                                PurchaseId = Guid.NewGuid().ToString(),
                                UpdatedBy = Guid.NewGuid().ToString(),
                                UpdatedDate = DateTime.Now,
                            },
                            new PaymentDetails
                            {
                                Id = Guid.NewGuid().ToString(),
                                CreatedBy = Guid.NewGuid().ToString(),
                                CreatedDate = DateTime.Now,
                                GroupId = groupId.ToString(),
                                PaymentId = paymentid.ToString(),
                                PurchaseId = Guid.NewGuid().ToString(),
                                UpdatedBy = Guid.NewGuid().ToString(),
                                UpdatedDate = DateTime.Now,
                            }
                        }
                    }
                }
            };

            var data = _paymentMasterRepository.UpdatePaymentAsync(groupPaymentMaster).Result;
            if (data.Id != null)
                Assert.IsTrue(true);
        }
    }
}
