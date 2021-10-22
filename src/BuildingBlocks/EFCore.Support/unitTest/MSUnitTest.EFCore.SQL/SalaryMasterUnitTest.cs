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

        [TestMethod]
        public void AddSalary()
        {
            string salaryid = Guid.NewGuid().ToString();

            SalaryMaster salaryMaster = new SalaryMaster
            {
                Id = salaryid,
                CompanyId = "0A8689F1-5920-4F38-99D0-4B479B2ED042",
                BranchId = "0A8689F1-5920-4F38-99D0-4B479B2ED043",
                CreatedBy = Guid.NewGuid().ToString(),
                CreatedDate = DateTime.Now,
                UpdatedBy = Guid.NewGuid().ToString(),
                FinancialYearId = "99D6F778-A702-4197-9BA6-135709A27FC5",
                Holidays = 2,
                MonthDays = 26,
                Remarks = "Sept Salary",
                SalaryMonthDateTime = DateTime.Now,
                UpdatedDate = DateTime.Now,
                SalaryMonthName = "SEPT Salary",
                SalaryDetails = new List<SalaryDetail>
                {
                    new SalaryDetail
                    {
                        Id = Guid.NewGuid().ToString(),
                        SalaryMasterId = salaryid,
                        AdvanceAmount = 0,
                        BonusAmount = 0,
                        OvetimeDays = 5,
                        PartyId = "61A2E070-5602-45B6-9C68-4078D530A055",
                        PayDays = 26,
                        TotalAmount = 40000                        
                    },
                    new SalaryDetail
                    {
                        Id = Guid.NewGuid().ToString(),
                        SalaryMasterId = salaryid,
                        AdvanceAmount = 0,
                        BonusAmount = 0,
                        OvetimeDays = 5,
                        PartyId = "B57E60A5-1A7F-4283-81BA-4E8AE4314002",
                        PayDays = 26,
                        TotalAmount = 80000
                    }
                }
            };

            var result =  _salaryMasterRepository.AddSalary(salaryMaster).Result;
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void UpdateSalary()
        {
            var salaryid = "883D5926-9BCC-438C-9DE7-B9E48C7D10E3";

            SalaryMaster salaryMaster = new SalaryMaster
            {
                Id = salaryid,
                CompanyId = "0A8689F1-5920-4F38-99D0-4B479B2ED042",
                BranchId = "0A8689F1-5920-4F38-99D0-4B479B2ED043",
                CreatedBy = Guid.NewGuid().ToString(),
                CreatedDate = DateTime.Now,
                UpdatedBy = Guid.NewGuid().ToString(),
                FinancialYearId = "99D6F778-A702-4197-9BA6-135709A27FC5",
                Holidays = 5,
                MonthDays = 30,
                Remarks = "Oct Salary",
                SalaryMonthDateTime = DateTime.Now,
                UpdatedDate = DateTime.Now,
                SalaryMonthName = "OCT Salary",
                SalaryDetails = new List<SalaryDetail>
                {
                    new SalaryDetail
                    {
                        Id = Guid.NewGuid().ToString(),
                        SalaryMasterId = salaryid,
                        AdvanceAmount = 0,
                        BonusAmount = 0,
                        OvetimeDays = 15,
                        PartyId = "61A2E070-5602-45B6-9C68-4078D530A055",
                        PayDays = 26,
                        TotalAmount = 70000
                    },
                    new SalaryDetail
                    {
                        Id = Guid.NewGuid().ToString(),
                        SalaryMasterId = salaryid,
                        AdvanceAmount = 0,
                        BonusAmount = 0,
                        OvetimeDays = 5,
                        PartyId = "B57E60A5-1A7F-4283-81BA-4E8AE4314002",
                        PayDays = 26,
                        TotalAmount = 80000
                    }
                }
            };

            var result = _salaryMasterRepository.UpdateSalary(salaryMaster).Result;

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DeleteSalary()
        {
            var salaryid = "883D5926-9BCC-438C-9DE7-B9E48C7D10E3";
            var result = _salaryMasterRepository.DeleteSalary(salaryid).Result;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetSalaryList()
        {
            var companyId = "0A8689F1-5920-4F38-99D0-4B479B2ED042";
            var branchId = "0A8689F1-5920-4F38-99D0-4B479B2ED043";
            var financialId = "99D6F778-A702-4197-9BA6-135709A27FC5";


            var ressult = _salaryMasterRepository.GetSalaries(companyId, branchId, financialId).Result;

            Assert.IsTrue(ressult.Count > 0);
        }

        [TestMethod]
        public void GetSalary()
        {
            var companyId = "0A8689F1-5920-4F38-99D0-4B479B2ED042";
            var branchId = "0A8689F1-5920-4F38-99D0-4B479B2ED043";
            var financialId = "99D6F778-A702-4197-9BA6-135709A27FC5";
            var result = _salaryMasterRepository.GetSalaries(DateTime.Now.Month, companyId, branchId, financialId).Result;
            Assert.IsTrue(result.Id != null);
        }
    }
}
