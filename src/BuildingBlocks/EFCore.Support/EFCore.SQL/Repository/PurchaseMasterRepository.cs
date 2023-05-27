using EFCore.SQL.DBContext;
using EFCore.SQL.Interface;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.SQL.Repository
{
    public class PurchaseMasterRepository : IPurchaseMaster
    {
        private DatabaseContext _databaseContext;

        public PurchaseMasterRepository()
        {

        }
        public async Task<PurchaseMaster> AddPurchaseAsync(PurchaseMaster purchaseMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                if (purchaseMaster.Id == null)
                    purchaseMaster.Id = Guid.NewGuid().ToString();

                //var ledgerRecord = await _databaseContext.PartyMaster.Where(w => w.Id == purchaseMaster.PartyId).FirstOrDefaultAsync();

                //ledgerRecord.OpeningBalance = ledgerRecord.OpeningBalance + (decimal)purchaseMaster.Total;

                await _databaseContext.PurchaseMaster.AddAsync(purchaseMaster);
                await _databaseContext.SaveChangesAsync();
                return purchaseMaster;
            }
        }

        public async Task<bool> DeletePurchaseAsync(string purchaseId, bool isPermanantDetele = false)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getPurchase = await _databaseContext.PurchaseMaster.Where(s => s.Id == purchaseId && s.IsDelete == false).FirstOrDefaultAsync();
                if (getPurchase != null)
                {
                    //check for the child record of purchase in kapanmapping master
                    var record = await _databaseContext.KapanMappingMaster.Where(w => w.PurchaseMasterId == purchaseId).ToListAsync();

                    if (record.Any())
                    {
                        return false;
                    } else { 
                        if (isPermanantDetele)
                            _databaseContext.PurchaseMaster.Remove(getPurchase);
                        else
                            getPurchase.IsDelete = true;

                        await _databaseContext.SaveChangesAsync();
                    }
                    return true;
                }
                return false;
            }
        }

        public async Task<List<PurchaseMaster>> GetAllPurchaseAsync(string companyId, string financialYearId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.PurchaseMaster.Where(s => s.IsDelete == false && s.CompanyId == companyId && s.FinancialYearId == financialYearId).ToListAsync();
            }
        }

        public async Task<List<PurchaseMaster>> GetAllPurchaseAsync(string companyId, string branchId, string financialYearId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.PurchaseMaster.Where(s => s.IsDelete == false && s.CompanyId == companyId && s.BranchId == branchId && s.FinancialYearId == financialYearId).ToListAsync();
            }
        }

        public async Task<List<PurchaseMaster>> GetAllPurchaseAsync(string companyId, DateTime startDate, DateTime endDate)
        {
            using (_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.PurchaseMaster.Where(w => w.IsDelete == false && w.CompanyId == companyId && w.CreatedDate >= startDate && w.CreatedDate <= endDate).ToListAsync();
            }
        }

        public async Task<List<PurchaseMaster>> GetAllPurchaseAsync(string companyId, string branchId, DateTime startDate, DateTime endDate)
        {
            using (_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.PurchaseMaster.Where(w => w.IsDelete == false && w.CompanyId == companyId && w.BranchId == branchId && w.CreatedDate >= startDate && w.CreatedDate <= endDate).ToListAsync();
            }
        }

        public async Task<PurchaseMaster> GetPurchaseAsync(string purchaseId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.PurchaseMaster.Where(s => s.IsDelete == false && s.Id == purchaseId).FirstOrDefaultAsync();
            }
        }

        public async Task<List<PurchaseDetails>> GetPurchaseDetailAsync(string purchaseId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.PurchaseDetails.Where(s => s.PurchaseId == purchaseId).ToListAsync();
            }
        }

        public async Task<long> GetMaxSlipNo(string companyId, string financialYearId)
        {
            try
            {
                using (_databaseContext = new DatabaseContext())
                {
                    var result = await _databaseContext.PurchaseMaster.Where(w => w.CompanyId == companyId && w.FinancialYearId == financialYearId).MaxAsync(m => m.SlipNo);
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
                    var result = await _databaseContext.PurchaseMaster.Where(w => w.BranchId == branchId && w.FinancialYearId == financialYearId).MaxAsync(m => m.PurchaseBillNo);
                    return result + 1;
                }
            }
            catch (Exception ex)
            {
                return 1;
            }
        }

        public async Task<List<PurchaseSPModel>> GetPurchaseReport(string companyId, string financialYearId, string currentWeek=null, string fromDate = null, string toDate = null)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var purchaseReport = await _databaseContext.SPPurchaseModel.FromSqlRaw($"GetPurchaseReport '" + companyId + "','" + financialYearId + "','" + currentWeek + "', '"+ fromDate +"', '"+ toDate +"'").ToListAsync();
                return purchaseReport;
            }
        }

        public async Task<DashboardSPModel> GetPurchaseTotal(string companyId, string financialYearId, string currentWeek = null, string fromDate = null, string toDate = null)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var totalAmount = await _databaseContext.SPDashboardModel.FromSqlRaw($"GetPurchaseReport '" + companyId + "','" + financialYearId + "','" + currentWeek + "', '" + fromDate + "', '" + toDate + "',1").ToListAsync();
                return totalAmount.Count > 0 ? totalAmount[0]: new DashboardSPModel() { TotalAmount = 0 } ;
            }
        }

        public async Task<List<PurchaseSlipDetailsSPModel>> GetAvailableSlipDetailsReport(int ActionType, string companyId, string financialYearId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var purchaseSlipDetailsReport = await _databaseContext.SPPurchaseSlipDetailsModel.FromSqlRaw($"GetAvailableSlipsDetail '" + ActionType + "','" + companyId + "','" + financialYearId + "'").ToListAsync();
                return purchaseSlipDetailsReport;
            }
        }

        public async Task<List<SlipDetailPrintSPModel>> GetSlipDetails(int ActionType, string companyId, string SlipNo, string financialYearId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var slipDetails = await _databaseContext.SPSlipDetailPrintModel.FromSqlRaw($"GetSlipDetail '" + ActionType + "','" + companyId + "','" + SlipNo + "','" + financialYearId + "'").ToListAsync();
                return slipDetails;
            }
        }

        public async Task<PurchaseMaster> UpdatePurchaseAsync(PurchaseMaster purchaseMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getPurchase = await _databaseContext.PurchaseMaster.Where(s => s.Id == purchaseMaster.Id && s.IsDelete == false).Include("PurchaseDetails").FirstOrDefaultAsync();

                if (getPurchase != null)
                {
                    getPurchase.CompanyId = purchaseMaster.CompanyId;
                    getPurchase.BranchId = purchaseMaster.BranchId;
                    getPurchase.PartyId = purchaseMaster.PartyId;
                    getPurchase.ByuerId = purchaseMaster.ByuerId;
                    getPurchase.CurrencyId = purchaseMaster.CurrencyId;
                    //getPurchase.FinancialYearId = purchaseMaster.FinancialYearId;
                    getPurchase.BrokerageId = purchaseMaster.BrokerageId;

                    getPurchase.CurrencyRate = purchaseMaster.CurrencyRate;
                    getPurchase.PurchaseBillNo = purchaseMaster.PurchaseBillNo;
                    getPurchase.SlipNo = purchaseMaster.SlipNo;
                    getPurchase.TransactionType = purchaseMaster.TransactionType;
                    getPurchase.Date = purchaseMaster.Date;
                    getPurchase.Time = purchaseMaster.Time;
                    getPurchase.DayName = purchaseMaster.DayName;
                    //getPurchase.PartyLastBalanceWhilePurchase = purchaseMaster.PartyLastBalanceWhilePurchase;
                    getPurchase.BrokerPercentage = purchaseMaster.BrokerPercentage;

                    getPurchase.BrokerAmount = purchaseMaster.BrokerAmount;
                    getPurchase.RoundUpAmount = purchaseMaster.RoundUpAmount;
                    getPurchase.Total = purchaseMaster.Total;
                    getPurchase.GrossTotal = purchaseMaster.GrossTotal;
                    getPurchase.DueDays = purchaseMaster.DueDays;
                    getPurchase.DueDate = purchaseMaster.DueDate;
                    getPurchase.PaymentDays = purchaseMaster.PaymentDays;
                    getPurchase.PaymentDueDate = purchaseMaster.PaymentDueDate;
                    getPurchase.IsSlip = purchaseMaster.IsSlip;
                    getPurchase.IsPF = purchaseMaster.IsPF;
                    getPurchase.TransferParentId = purchaseMaster.TransferParentId;

                    getPurchase.CommissionPercentage = purchaseMaster.CommissionPercentage;
                    getPurchase.CommissionAmount = purchaseMaster.CommissionAmount;
                    getPurchase.Image1 = purchaseMaster.Image1;
                    getPurchase.Image2 = purchaseMaster.Image2;
                    getPurchase.Image3 = purchaseMaster.Image3;
                    getPurchase.AllowSlipPrint = purchaseMaster.AllowSlipPrint;
                    getPurchase.IsTransfer = purchaseMaster.IsTransfer;
                    getPurchase.TransferParentId = purchaseMaster.TransferParentId;
                    getPurchase.IsDelete = purchaseMaster.IsDelete;
                    getPurchase.Remarks = purchaseMaster.Remarks;
                    getPurchase.UpdatedDate = purchaseMaster.UpdatedDate;
                    getPurchase.UpdatedBy = purchaseMaster.UpdatedBy;
                    getPurchase.ApprovalType = purchaseMaster.ApprovalType;
                    getPurchase.Message = purchaseMaster.Message;

                    if (getPurchase.PurchaseDetails != null)
                    {
                        _databaseContext.PurchaseDetails.RemoveRange(getPurchase.PurchaseDetails);

                        await _databaseContext.PurchaseDetails.AddRangeAsync(purchaseMaster.PurchaseDetails);
                    }

                    await _databaseContext.SaveChangesAsync();
                }
                return purchaseMaster;
            }
        }

        public async Task<bool> UpdateApprovalStatus(string purchaseId, string message, int status)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getPurchase = await _databaseContext.PurchaseMaster.Where(s => s.Id == purchaseId).FirstOrDefaultAsync();

                if (getPurchase != null)
                {
                    getPurchase.ApprovalType = status;
                    getPurchase.Message = message;

                    await _databaseContext.SaveChangesAsync();

                    return true;
                }
                return false;
            }
        }

        public async Task<List<PFReportSPModel>> GetPFReportAsync(string companyId, string financialYearId, int PFType)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getPFRecord = await _databaseContext.SPPFReportModels.FromSqlRaw($"GetPFReport '" + companyId + "', '" + financialYearId + "', '"+ PFType +"'").ToListAsync();
                return getPFRecord;
            }
        }

        public async Task<List<WeeklyPurchaseReport>> GetWeeklyPurchaseReportAsync(string companyId, string financialYearId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getWeeklyPurchaseRecord = await _databaseContext.SPWeeklyPurchaseReport.FromSqlRaw($"GetWeeklyPurchaseReport 0,'" + companyId + "', '" + financialYearId + "'").ToListAsync();
                return getWeeklyPurchaseRecord;
            }
        }

        public List<PurchaseChildSPModel> GetPurchaseDetailsAsync(string purchaseId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getPurchaseChild = _databaseContext.SPPurchaseChildReport.FromSqlRaw($"GetChildPurchaseReport '" + purchaseId + "'").ToList();
                ;
                return getPurchaseChild;
            }
        }
    }
}
