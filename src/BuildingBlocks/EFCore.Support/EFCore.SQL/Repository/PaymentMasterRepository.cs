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
    public class PaymentMasterRepository : IPaymentMaster, IDisposable
    {
        private DatabaseContext _databaseContext;

        public PaymentMasterRepository()
        {

        }
        public async Task<GroupPaymentMaster> AddPaymentAsync(GroupPaymentMaster groupPaymentMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                if (groupPaymentMaster.Id == null)
                    groupPaymentMaster.Id = Guid.NewGuid().ToString();

                await _databaseContext.GroupPaymentMaster.AddAsync(groupPaymentMaster);
                await _databaseContext.SaveChangesAsync();

                //var getToPartyRecord = await _databaseContext.PartyMaster.Where(w => w.Id == groupPaymentMaster.ToPartyId).FirstOrDefaultAsync();

                //foreach (var item in groupPaymentMaster.PaymentMasters)
                //{
                //    if (groupPaymentMaster.CrDrType == 0)      
                //        getToPartyRecord.OpeningBalance -= item.Amount;                    
                //    else
                //        getToPartyRecord.OpeningBalance += item.Amount;

                //    var getFromPartyRecord = await _databaseContext.PartyMaster.Where(w => w.Id == item.FromPartyId).FirstOrDefaultAsync();

                //    if(getFromPartyRecord != null)
                //    {
                //        if (groupPaymentMaster.CrDrType == 0)
                //            getFromPartyRecord.OpeningBalance += item.Amount;
                //        else
                //            getFromPartyRecord.OpeningBalance -= item.Amount;
                //    }

                //    await _databaseContext.SaveChangesAsync();
                //}


                return groupPaymentMaster;
            }
        }

        public async Task<bool> DeletePaymentAsync(string groupId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var paymentRecord = await _databaseContext.GroupPaymentMaster.Where(w => w.Id == groupId.ToString()).FirstOrDefaultAsync();
                if (paymentRecord != null)
                {
                    paymentRecord.IsDelete = true;
                    await _databaseContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
        }

        public void Dispose()
        {
            _databaseContext.DisposeAsync();
        }

        public async Task<List<GroupPaymentMaster>> GetAllPaymentAsync(string companyId, string financialYearId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.GroupPaymentMaster.Where(w => w.CompanyId == companyId && w.FinancialYearId == financialYearId).Include("PaymentMasters").ToListAsync();
            }
        }

        public async Task<int> GetMaxSrNoAsync(int paymentType, string companyId, string financialYearId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var countResult = await _databaseContext.GroupPaymentMaster.Where(w => w.CrDrType == paymentType && w.CompanyId == companyId && w.FinancialYearId == financialYearId).OrderByDescending(o => o.Sr).FirstOrDefaultAsync();
                if (countResult == null)
                    return 1;
                return countResult.BillNo + 1;
            }
        }

        public async Task<List<PaymentSPModel>> GetPaymentReport(string companyId, string financialYearId, int paymentType, string fromDate, string toDate)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var paymentRecords = await _databaseContext.SPPaymentModel.FromSqlRaw($"getPaymentReport '" + companyId + "','" + financialYearId + "','" + paymentType + "', '"+ fromDate +"', '"+ toDate +"'").ToListAsync();
                return paymentRecords;
            }
        }

        public async Task<List<PaymentSPModel>> GetPaymentOrReceiptTotal(string companyId, string financialYearId, int paymentType, string fromDate, string toDate)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var paymentRecords = await _databaseContext.SPPaymentModel.FromSqlRaw($"getPaymentReport '" + companyId + "','" + financialYearId + "','" + paymentType + "', '" + fromDate + "', '" + toDate + "', 1").ToListAsync();
                return paymentRecords;
            }
        }

        public async Task<List<PaymentPSSlipDetails>> GetPaymentPSSlipDetails(string companyId, string actionType)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var PaymentPSSlipDetails = await _databaseContext.SPPaymentPSSlipDetails.FromSqlRaw($"GetPSSlipDetailsForPayment '" + actionType + "','" + companyId + "'").ToListAsync();
                return PaymentPSSlipDetails;
            }
        }
        public async Task<GroupPaymentMaster> UpdatePaymentAsync(GroupPaymentMaster groupPaymentMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var groupPaymentRecord = await _databaseContext.GroupPaymentMaster.Where(w => w.Id == groupPaymentMaster.Id).Include("PaymentMasters").FirstOrDefaultAsync();
                if (groupPaymentRecord != null)
                {
                    groupPaymentRecord.CompanyId = groupPaymentMaster.CompanyId;
                    groupPaymentRecord.BranchId = groupPaymentMaster.BranchId;
                    groupPaymentRecord.FinancialYearId = groupPaymentMaster.FinancialYearId;
                    groupPaymentRecord.ToPartyId = groupPaymentMaster.ToPartyId;
                    groupPaymentRecord.Remarks = groupPaymentMaster.Remarks;
                    groupPaymentRecord.UpdatedDate = groupPaymentMaster.UpdatedDate;
                    groupPaymentRecord.UpdatedBy = groupPaymentMaster.UpdatedBy;

                    //Remove all existing paymentDetails records                
                    foreach (var paymentMaster in groupPaymentMaster.PaymentMasters)
                    {
                        var paymentDetailsRecords = await _databaseContext.PaymentDetails.Where(w => w.PaymentId == paymentMaster.Id).ToListAsync();
                        if (paymentDetailsRecords != null)
                            _databaseContext.PaymentDetails.RemoveRange(paymentDetailsRecords);
                    }

                    //now remove the existing paymentmaster record.
                    _databaseContext.PaymentMaster.RemoveRange(groupPaymentRecord.PaymentMasters);

                    //Add the new Payment Master and Payment details reocrd.
                    await _databaseContext.PaymentMaster.AddRangeAsync(groupPaymentMaster.PaymentMasters.ToList());
                    await _databaseContext.SaveChangesAsync();
                }
                return groupPaymentMaster;
            }
        }

        public async Task<List<MixedSPModel>> GetMixedReportAsync(string companyId, string financialYearId, string fromDate, string toDate)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var PaymentPSSlipDetails = await _databaseContext.SPMixedReportModel.FromSqlRaw($"GetMixedRepot '" + companyId + "','" + financialYearId + "','"+ fromDate+"','"+ toDate+"'").ToListAsync();
                return PaymentPSSlipDetails;
            }
        }

        public async Task<List<PayableReceivableSPModel>> GetPayableReceivalbeReport(string companyId, string financialYearId, int type)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var PayableReceivableDetails = await _databaseContext.SPPayableReceivableReport.FromSqlRaw($"GetReceivablePayableReport '" + companyId + "','" + financialYearId + "', " + type).ToListAsync();
                return PayableReceivableDetails;
            }
        }

        public async Task<List<BalanceSheetSPModel>> GetBalanceSheetReportAsync(string companyId, string financialYearId, int balanceSheetType)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var PayableReceivableDetails = await _databaseContext.SPBalanceSheetReport.FromSqlRaw($"GetBalanceSheet '" + companyId + "','" + financialYearId + "'," + balanceSheetType).ToListAsync();
                return PayableReceivableDetails;
            }
        }

        public async Task<List<ProfitLossSPModel>> GetProfitLossReportAsync(string companyId, string financialYearId, int PLType)
        {
            try
            {
                using (_databaseContext = new DatabaseContext())
                {
                    var profitLossReport = await _databaseContext.SPProfitLossReport.FromSqlRaw($"GetProfitAndLoss '" + companyId + "','" + financialYearId + "', " + PLType).ToListAsync();
                    return profitLossReport;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<CashBankSPReport>> GetCashBankReportAsync(string companyId, string financialYearId, string fromDate, string toDate)
        {
            try
            {
                using (_databaseContext = new DatabaseContext())
                {
                    var cashbankReport = await _databaseContext.SPCashBankReport.FromSqlRaw($"GetCashBankReport '" + companyId + "','" + financialYearId + "','"+ fromDate+"','"+ toDate +"'").ToListAsync();
                    return cashbankReport;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> UpdateApprovalStatus(string paymentGroupId, string message, int status)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getPayment = await _databaseContext.GroupPaymentMaster.Where(s => s.Id == paymentGroupId).FirstOrDefaultAsync();

                if (getPayment != null)
                {
                    getPayment.ApprovalType = status;
                    getPayment.Message = message;

                    await _databaseContext.SaveChangesAsync();

                    return true;
                }
                return false;
            }
        }

    }
}
