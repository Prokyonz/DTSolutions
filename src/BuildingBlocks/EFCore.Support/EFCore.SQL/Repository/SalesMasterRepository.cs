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
            try
            {
                using (_databaseContext = new DatabaseContext())
                {
                    if (salesMaster.Id == null)
                        salesMaster.Id = Guid.NewGuid().ToString();

                    //var ledgerRecord = await _databaseContext.PartyMaster.Where(w => w.Id == salesMaster.PartyId).FirstOrDefaultAsync();

                    //ledgerRecord.OpeningBalance = ledgerRecord.OpeningBalance + (decimal)salesMaster.Total;

                    await _databaseContext.SalesMaster.AddAsync(salesMaster);
                    await _databaseContext.SaveChangesAsync();
                    return salesMaster;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteSalesAsync(string salesId, bool isPermanantDetele = false)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var salesRecord = await _databaseContext.SalesMaster.Where(w => w.Id == salesId).FirstOrDefaultAsync();
                if (salesRecord != null)
                {
                    var childEntry = await _databaseContext.PaymentDetails.Where(w => w.SlipNo == salesRecord.SlipNo.ToString()).ToListAsync();

                    if (childEntry.Any())
                    {
                        return false;
                    }
                    else
                    {
                        if (isPermanantDetele)
                            _databaseContext.SalesMaster.Remove(salesRecord);
                        else
                            salesRecord.IsDelete = true;
                        await _databaseContext.SaveChangesAsync();
                    }
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

        public async Task<SalesMaster> GetSalesAsync(string salesId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.SalesMaster.Where(s => s.IsDelete == false && s.Id == salesId).Include("SalesDetails").FirstOrDefaultAsync();
            }
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

        public async Task<List<SalesSPModel>> GetSalesReport(string companyId, string financialYearId, string fromDate, string toDate)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var salesReport = await _databaseContext.SPSalesModel.FromSqlRaw($"GetSalesReport '" + companyId + "','" + financialYearId + "', '" + fromDate + "', '" + toDate + "'").ToListAsync();
                return salesReport;
            }
        }

        public async Task<SalesMaster> UpdateSalesAsync(SalesMaster salesMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var salesRecord = await _databaseContext.SalesMaster.Where(w => w.Id == salesMaster.Id && w.IsDelete == false).Include("SalesDetails").FirstOrDefaultAsync();
                if (salesRecord != null)
                {
                    salesRecord.CompanyId = salesMaster.CompanyId;
                    salesRecord.BranchId = salesMaster.BranchId;
                    salesRecord.PartyId = salesMaster.PartyId;
                    salesRecord.SalerId = salesMaster.SalerId;
                    salesRecord.CurrencyId = salesMaster.CurrencyId;
                    //salesRecord.FinancialYearId = salesRecord.FinancialYearId;
                    salesRecord.BrokerageId = salesMaster.BrokerageId;

                    salesRecord.CurrencyRate = salesMaster.CurrencyRate;
                    salesRecord.SaleBillNo = salesMaster.SaleBillNo;
                    salesRecord.SlipNo = salesMaster.SlipNo;
                    salesRecord.TransactionType = salesMaster.TransactionType;
                    salesRecord.Date = salesMaster.Date;
                    salesRecord.Time = salesMaster.Time;
                    salesRecord.DayName = salesMaster.DayName;
                    salesRecord.PartyLastBalanceWhileSale = salesMaster.PartyLastBalanceWhileSale;
                    salesRecord.BrokerPercentage = salesMaster.BrokerPercentage;

                    salesRecord.BrokerAmount = salesMaster.BrokerAmount;
                    salesRecord.RoundUpAmount = salesMaster.RoundUpAmount;
                    salesRecord.Total = salesMaster.Total;
                    salesRecord.GrossTotal = salesMaster.GrossTotal;
                    salesRecord.DueDays = salesMaster.DueDays;
                    salesRecord.DueDate = salesMaster.DueDate;
                    salesRecord.PaymentDays = salesMaster.PaymentDays;
                    salesRecord.PaymentDueDate = salesMaster.PaymentDueDate;
                    salesRecord.IsSlip = salesMaster.IsSlip;
                    salesRecord.IsPF = salesMaster.IsPF;

                    salesRecord.CommissionToPartyId = salesMaster.CommissionToPartyId;
                    salesRecord.CommissionPercentage = salesMaster.CommissionPercentage;
                    salesRecord.CommissionAmount = salesMaster.CommissionAmount;
                    salesRecord.Image1 = salesMaster.Image1;
                    salesRecord.Image2 = salesMaster.Image2;
                    salesRecord.Image3 = salesMaster.Image3;
                    salesRecord.AllowSlipPrint = salesMaster.AllowSlipPrint;
                    salesRecord.IsDelete = salesMaster.IsDelete;
                    salesRecord.Remarks = salesMaster.Remarks;
                    salesRecord.UpdatedDate = salesMaster.UpdatedDate;
                    salesRecord.UpdatedBy = salesMaster.UpdatedBy;
                    salesRecord.ApprovalType = salesMaster.ApprovalType;
                    salesRecord.Message = salesMaster.Message;

                    if (salesMaster.SalesDetails != null)
                    {
                        _databaseContext.SalesDetails.RemoveRange(salesRecord.SalesDetails);

                        await _databaseContext.SalesDetails.AddRangeAsync(salesMaster.SalesDetails);
                    }

                    await _databaseContext.SaveChangesAsync();
                }
                return salesMaster;
            }
        }

        public async Task<bool> DeleteSalesDetailRangeAsync(List<SalesDetails> salesDetails)
        {
            using (_databaseContext = new DatabaseContext())
            {
                if (salesDetails != null)
                {
                    for (int i = 0; i < salesDetails.Count; i++)
                    {
                        var getSalesDetailsSummary = await _databaseContext.SalesDetailsSummary.Where(s => s.SalesDetailsId == salesDetails[i].Id).ToListAsync();
                        _databaseContext.SalesDetailsSummary.RemoveRange(getSalesDetailsSummary);
                        await _databaseContext.SaveChangesAsync();
                    }
                    _databaseContext.SalesDetails.RemoveRange(salesDetails);
                    await _databaseContext.SaveChangesAsync();
                    return true;
                }
                else
                    return false;
            }
        }

        public async Task<bool> DeleteSalesDetailSummaryRangeAsync(List<SalesDetailsSummary> salesDetailsSummary)
        {
            using (_databaseContext = new DatabaseContext())
            {
                if (salesDetailsSummary != null)
                {
                    _databaseContext.SalesDetailsSummary.RemoveRange(salesDetailsSummary);
                    await _databaseContext.SaveChangesAsync();
                    return true;
                }
                else
                    return false;
            }
        }

        public async Task<bool> AddSalesDetailRangeAsync(List<SalesDetails> salesDetails)
        {
            using (_databaseContext = new DatabaseContext())
            {
                if (salesDetails != null)
                {
                    List<SalesDetails> salesDetailsList = new List<SalesDetails>();
                    SalesDetails objsalesDetails;
                    foreach (SalesDetails salesDetail in salesDetails)
                    {
                        objsalesDetails = new SalesDetails();
                        objsalesDetails.Id = salesDetail.Id;
                        objsalesDetails.SalesId = salesDetail.SalesId;
                        objsalesDetails.Category = salesDetail.Category;
                        objsalesDetails.KapanId = salesDetail.KapanId;
                        objsalesDetails.ShapeId = salesDetail.ShapeId;
                        objsalesDetails.SizeId = salesDetail.SizeId;
                        objsalesDetails.PurityId = salesDetail.PurityId;
                        objsalesDetails.CharniSizeId = salesDetail.CharniSizeId;
                        objsalesDetails.GalaSizeId = salesDetail.GalaSizeId;
                        objsalesDetails.NumberSizeId = salesDetail.NumberSizeId;
                        objsalesDetails.Weight = salesDetail.Weight;
                        objsalesDetails.TIPWeight = salesDetail.TIPWeight;
                        objsalesDetails.CVDWeight = salesDetail.CVDWeight;
                        objsalesDetails.RejectedPercentage = salesDetail.RejectedPercentage;
                        objsalesDetails.RejectedWeight = salesDetail.RejectedWeight;
                        objsalesDetails.LessWeight = salesDetail.LessWeight;
                        objsalesDetails.LessDiscountPercentage = salesDetail.LessDiscountPercentage;
                        objsalesDetails.LessWeightDiscount = salesDetail.LessWeightDiscount;
                        objsalesDetails.NetWeight = salesDetail.NetWeight;
                        objsalesDetails.SaleRate = salesDetail.SaleRate;
                        objsalesDetails.CVDCharge = salesDetail.CVDCharge;
                        objsalesDetails.CVDAmount = salesDetail.CVDAmount;
                        objsalesDetails.Amount = salesDetail.Amount;
                        objsalesDetails.CurrencyRate = salesDetail.CurrencyRate;
                        objsalesDetails.CurrencyAmount = salesDetail.CurrencyAmount;
                        objsalesDetails.IsTransfer = salesDetail.IsTransfer;
                        objsalesDetails.TransferParentId = salesDetail.TransferParentId;
                        objsalesDetails.CreatedDate = salesDetail.CreatedDate;
                        objsalesDetails.CreatedBy = salesDetail.CreatedBy;
                        objsalesDetails.UpdatedDate = salesDetail.UpdatedDate;
                        objsalesDetails.UpdatedBy = salesDetail.UpdatedBy;

                        salesDetailsList.Add(objsalesDetails);
                    }
                    await _databaseContext.SalesDetails.AddRangeAsync(salesDetailsList);
                    await _databaseContext.SaveChangesAsync();
                    return true;
                }
                else
                    return false;
            }
        }

        public async Task<bool> AddSalesDetailSummaryRangeAsync(List<SalesDetailsSummary> salesDetailsSummary)
        {
            using (_databaseContext = new DatabaseContext())
            {
                if (salesDetailsSummary != null)
                {
                    List<SalesDetailsSummary> salesDetailsSummaryList = new List<SalesDetailsSummary>();
                    SalesDetailsSummary objsalesDetailsSummary;
                    foreach (SalesDetailsSummary salesDetailSummary in salesDetailsSummary)
                    {
                        objsalesDetailsSummary = new SalesDetailsSummary();
                        objsalesDetailsSummary.Id = salesDetailSummary.Id;
                        objsalesDetailsSummary.SalesId = salesDetailSummary.SalesId;
                        objsalesDetailsSummary.SalesDetailsId = salesDetailSummary.SalesDetailsId;
                        objsalesDetailsSummary.CompanyId = salesDetailSummary.CompanyId;
                        objsalesDetailsSummary.BranchId = salesDetailSummary.BranchId;
                        objsalesDetailsSummary.FinancialYearId = salesDetailSummary.FinancialYearId;
                        objsalesDetailsSummary.SlipNo = salesDetailSummary.SlipNo;


                        objsalesDetailsSummary.KapanId = salesDetailSummary.KapanId;
                        objsalesDetailsSummary.ShapeId = salesDetailSummary.ShapeId;
                        objsalesDetailsSummary.SizeId = salesDetailSummary.SizeId;
                        objsalesDetailsSummary.PurityId = salesDetailSummary.PurityId;
                        objsalesDetailsSummary.CharniSizeId = salesDetailSummary.CharniSizeId;
                        objsalesDetailsSummary.GalaSizeId = salesDetailSummary.GalaSizeId;
                        objsalesDetailsSummary.NumberSizeId = salesDetailSummary.NumberSizeId;
                        objsalesDetailsSummary.Weight = salesDetailSummary.Weight;
                        objsalesDetailsSummary.Category = salesDetailSummary.Category;
                        
                        objsalesDetailsSummary.CreatedDate = salesDetailSummary.CreatedDate;
                        objsalesDetailsSummary.CreatedBy = salesDetailSummary.CreatedBy;
                        objsalesDetailsSummary.UpdatedDate = salesDetailSummary.UpdatedDate;
                        objsalesDetailsSummary.UpdatedBy = salesDetailSummary.UpdatedBy;

                        salesDetailsSummaryList.Add(objsalesDetailsSummary);
                    }
                    await _databaseContext.SalesDetailsSummary.AddRangeAsync(salesDetailsSummaryList);
                    await _databaseContext.SaveChangesAsync();
                    return true;
                }
                else
                    return false;
            }
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

        public List<SalesChildSPModel> GetSalesChild(string salesId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var data = _databaseContext.SPSalesChildReport.FromSqlRaw($"GetChildSalesReport '" + salesId + "'").ToList();

                return data;
            }
        }
    }
}
