using EFCore.SQL.DBContext;
using EFCore.SQL.Interface;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.SQL.Repository
{
    public class CalculatorMasterRepository : ICalculatorMaster
    {
        private DatabaseContext _databaseContext;
        public CalculatorMasterRepository()
        {

        }

        public async Task<CalculatorMaster> AddCalculatorAsync(CalculatorMaster calculatorMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                if (calculatorMaster.Id == null)
                    calculatorMaster.Id = Guid.NewGuid().ToString();
                await _databaseContext.CalculatorMaster.AddAsync(calculatorMaster);
                await _databaseContext.SaveChangesAsync();
                return calculatorMaster;
            }
        }

        public async Task<List<CalculatorMaster>> AddCalculatorListAsync(List<CalculatorMaster> calculatorMasterList)
        {
            var Sr = GetMaxSrNo(calculatorMasterList.First().BranchId);
            using (_databaseContext = new DatabaseContext())
            {
                calculatorMasterList.ForEach(x =>
                {
                    x.SrNo = Sr;
                    if (x.Id == null)
                        x.Id = Guid.NewGuid().ToString();
                    _databaseContext.CalculatorMaster.AddRangeAsync(x);
                });
                await _databaseContext.SaveChangesAsync();
            }

            return calculatorMasterList;
        }

        public async Task<bool> DeleteCalculatorAsync(int calculatorId, string branchId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getCalculator = await _databaseContext.CalculatorMaster.Where(s => s.SrNo == calculatorId && s.BranchId == branchId && !s.IsDelete).ToListAsync();
                if (getCalculator != null)
                {
                    _databaseContext.CalculatorMaster.RemoveRange(getCalculator);
                    await _databaseContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
        }

        public async Task<bool> DeleteCalculatorHistoryAsync( string branchId, string companyId, string finYearId, int srNo)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getCalculator = await _databaseContext.CalculatorMaster.Where(s => s.SrNo == srNo &&
                s.BranchId == branchId
                && s.CompanyId == companyId
                && s.FinancialYearId == finYearId 
                && !s.IsDelete).ToListAsync();
                if (getCalculator != null)
                {
                    _databaseContext.CalculatorMaster.RemoveRange(getCalculator);
                    await _databaseContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
        }

        public async Task<List<CalculatorMaster>> GetAllCalculatorAsync(string CompanyId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var list = await _databaseContext.CalculatorMaster.Where(s => s.IsDelete == false && s.CompanyId == CompanyId).ToListAsync();

                return list;
            }
        }

        public async Task<bool> UpdateCalculatorAsync(List<CalculatorMaster> calculatorMasterEntries)
        {
            using (_databaseContext = new DatabaseContext())
            {
                if (calculatorMasterEntries.Count > 0)
                {
                    var CalculatorEntry = await _databaseContext.CalculatorMaster.Where(w => w.SrNo == calculatorMasterEntries[0].SrNo).ToListAsync();
                    _databaseContext.CalculatorMaster.RemoveRange(CalculatorEntry);

                    //Create an Id for each Record
                    var result = calculatorMasterEntries.Where(x => x.Id == null).ToList();
                    if (result.Any())
                    {
                        calculatorMasterEntries.ForEach(calculatorMaster =>
                        {
                            if (calculatorMaster.Id == null)
                                calculatorMaster.Id = Guid.NewGuid().ToString();
                        });
                    }


                    //Add New updated records to the database
                    await _databaseContext.CalculatorMaster.AddRangeAsync(calculatorMasterEntries);

                    await _databaseContext.SaveChangesAsync();

                    return true;
                }
                return false;
            }
        }

        private int GetMaxSrNo(string branchId)
        {
            try
            {
                using (_databaseContext = new DatabaseContext())
                {
                    var getCount = _databaseContext.CalculatorMaster.Where(m => m.BranchId == branchId).Max(m => m.SrNo);
                    return getCount + 1;
                }
            }
            catch
            {
                return 1;
            }
        }

        public async Task<List<CalculatorSPModel>> GetCalculatorReport(string companyId, string financialYearId, string fromDate, string toDate)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var calsulatorReport = await _databaseContext.SPCalculatorModel.FromSqlRaw($"GetCalulatorDetails '" + companyId + "','" + financialYearId + "', '" + fromDate + "', '" + toDate + "'").ToListAsync();
                return calsulatorReport;
            }
        }

        public async Task<List<string>> GetCalculatorMasterParties(string companyId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var result = await _databaseContext.CalculatorMaster.Where(w => w.CompanyId == companyId).Select(s => s.PartyId.ToUpper()).Distinct().ToListAsync();
                return result;
            }
        }

        public async Task<List<string>> GetCalculatorMasterBrokers(string companyId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var result = await _databaseContext.CalculatorMaster.Where(w => w.CompanyId == companyId).Select(s => s.DealerId.ToUpper()).Distinct().ToListAsync();
                return result;
            }
        }
    }
}