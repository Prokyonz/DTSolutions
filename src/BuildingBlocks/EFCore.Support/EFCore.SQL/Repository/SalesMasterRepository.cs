using EFCore.SQL.DBContext;
using EFCore.SQL.Interface;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.SQL.Repository
{
    public class SalesMasterRepository : ISalesMaster
    {
        private DatabaseContext _databaseContext;

        public SalesMasterRepository()
        {
            
        }
        public async Task<SalesMaster> AddSalesAsync(SalesMaster salesMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                if (salesMaster.Id == null)
                    salesMaster.Id = Guid.NewGuid().ToString();

                var ledgerRecord = await _databaseContext.PartyMaster.Where(w => w.Id == salesMaster.PartyId).FirstOrDefaultAsync();

                ledgerRecord.OpeningBalance = ledgerRecord.OpeningBalance + (decimal)salesMaster.Total;

                await _databaseContext.SalesMaster.AddAsync(salesMaster);
                await _databaseContext.SaveChangesAsync();
                return salesMaster;
            }
        }

        public async Task<bool> DeleteSalesAsync(string salesId, bool isPermanantDetele = false)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var salesRecord = await _databaseContext.SalesMaster.Where(w => w.Id == salesId).FirstOrDefaultAsync();
                if (salesRecord != null)
                {
                    if (isPermanantDetele)
                        _databaseContext.SalesMaster.Remove(salesRecord);
                    else
                        salesRecord.IsDelete = true;
                    await _databaseContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            
        }

        public async Task<List<SalesMaster>> GetAllSalesAsync(string companyId, string financialYearId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.SalesMaster.Where(w => w.IsDelete == false && w.FinancialYearId == financialYearId).ToListAsync();
            }
        }

        public async Task<List<SalesMaster>> GetAllSalesAsync(string companyId, DateTime startDate, DateTime endDate)
        {
            using (_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.SalesMaster.Where(w => w.IsDelete == false && w.CreatedDate >= startDate && w.CreatedDate <= endDate).ToListAsync();
            }
        }

        public async Task<List<SalesMaster>> GetAllSalesAsync(string companyId, string branchId, string financialYearId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.SalesMaster.Where(w => w.IsDelete == false && w.BranchId == branchId && w.FinancialYearId == financialYearId).ToListAsync();
            }
        }

        public async Task<List<SalesMaster>> GetAllSalesAsync(string companyId, string branchId, DateTime startDate, DateTime endDate)
        {
            return await _databaseContext.SalesMaster.Where(w => w.IsDelete == false && w.BranchId == branchId && w.CreatedDate >= startDate && w.CreatedDate <= endDate).ToListAsync();
        }

        public async Task<long> GetMaxSlipNo(string companyId, string financialYearId)
        {
            try
            {
                using (_databaseContext = new DatabaseContext())
                {
                    var result = await _databaseContext.SalesMaster.Where(w => w.CompanyId == companyId && w.FinancialYearId == financialYearId).MaxAsync(m => m.SlipNo);
                    return result + 1;
                }
            }
            catch (Exception ex)
            {
                return 1;
            }
        }

        public async Task<long> GetMaxSrNo(string branchId, string financialYearId)
        {
            try
            {
                using (_databaseContext = new DatabaseContext())
                {
                    var result = await _databaseContext.SalesMaster.Where(w => w.BranchId == branchId && w.FinancialYearId == financialYearId).MaxAsync(m => m.SaleBillNo);
                    return result + 1;
                }
            }
            catch (Exception ex)
            {
                return 1;
            }
        }

        public async Task<List<SalesSPModel>> GetSalesReport(string companyId, string financialYearId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var salesReport = await _databaseContext.SPSalesModel.FromSqlRaw($"GetSalesReport '" + companyId + "','" + financialYearId + "'").ToListAsync();
                return salesReport;
            }
        }

        public async Task<SalesMaster> UpdateSalesAsync(SalesMaster salesMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var salesRecord = await _databaseContext.SalesMaster.Where(w => w.Id == salesMaster.Id).FirstOrDefaultAsync();
                if (salesRecord != null)
                {
                    salesRecord.BranchId = salesRecord.BranchId;
                    salesRecord.PartyId = salesRecord.PartyId;
                    salesRecord.SalerId = salesRecord.SalerId;
                    salesRecord.CurrencyId = salesRecord.CurrencyId;
                    salesRecord.FinancialYearId = salesRecord.FinancialYearId;
                    salesRecord.BrokerageId = salesRecord.BrokerageId;

                    salesRecord.CurrencyRate = salesRecord.CurrencyRate;
                    salesRecord.SaleBillNo = salesRecord.SaleBillNo;
                    salesRecord.SlipNo = salesRecord.SlipNo;
                    salesRecord.TransactionType = salesRecord.TransactionType;
                    salesRecord.Date = salesRecord.Date;
                    salesRecord.Time = salesRecord.Time;
                    salesRecord.DayName = salesRecord.DayName;
                    salesRecord.PartyLastBalanceWhileSale = salesRecord.PartyLastBalanceWhileSale;
                    salesRecord.BrokerPercentage = salesRecord.BrokerPercentage;

                    salesRecord.BrokerAmount = salesRecord.BrokerAmount;
                    salesRecord.RoundUpAmount = salesRecord.RoundUpAmount;
                    salesRecord.Total = salesRecord.Total;
                    salesRecord.GrossTotal = salesRecord.GrossTotal;
                    salesRecord.DueDays = salesRecord.DueDays;
                    salesRecord.DueDate = salesRecord.DueDate;
                    salesRecord.PaymentDays = salesRecord.PaymentDays;
                    salesRecord.PaymentDueDate = salesRecord.PaymentDueDate;
                    salesRecord.IsSlip = salesRecord.IsSlip;
                    salesRecord.IsPF = salesRecord.IsPF;

                    salesRecord.CommissionToPartyId = salesRecord.CommissionToPartyId;
                    salesRecord.CommissionPercentage = salesRecord.CommissionPercentage;
                    salesRecord.CommissionAmount = salesRecord.CommissionAmount;
                    salesRecord.Image1 = salesRecord.Image1;
                    salesRecord.Image2 = salesRecord.Image2;
                    salesRecord.Image3 = salesRecord.Image3;
                    salesRecord.AllowSlipPrint = salesRecord.AllowSlipPrint;
                    salesRecord.IsDelete = salesRecord.IsDelete;
                    salesRecord.Remarks = salesRecord.Remarks;
                    salesRecord.UpdatedDate = salesRecord.UpdatedDate;
                    salesRecord.UpdatedBy = salesRecord.UpdatedBy;

                    _databaseContext.SalesDetails.RemoveRange(salesMaster.SalesDetails);

                    await _databaseContext.SalesDetails.AddRangeAsync(salesRecord.SalesDetails);

                    await _databaseContext.SaveChangesAsync();
                }
            }
           
            return salesMaster;
        }

        public async Task<List<SalesItemDetails>> GetSalesItemDetails(int ActionType, string companyId, string branchId, string financialYearId)
        {
            try
            {
                using (_databaseContext = new DatabaseContext())
                {
                    var data = await _databaseContext.SalesItemDetails.FromSqlRaw($"GetSalesItemDetails '" + ActionType + "','" + companyId + "', '" + branchId + "','" + financialYearId + "'").ToListAsync();

                    return data;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<CaratCategoryType>> GetCaratCategoryDetails()
        {
            try
            {
                using (_databaseContext = new DatabaseContext())
                {
                    var data = await _databaseContext.CaratCategoryType.FromSqlRaw($"GetTypeDetails").ToListAsync();

                    return data;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> UpdateApprovalStatus(string salesId, string message, int status)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getSale = await _databaseContext.SalesMaster.Where(s => s.Id == salesId).FirstOrDefaultAsync();

                if (getSale != null)
                {
                    getSale.ApprovalType = status;
                    getSale.Message = message;

                    await _databaseContext.SaveChangesAsync();

                    return true;
                }
                return false;
            }
        }
    }
}
