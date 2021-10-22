using EFCore.SQL.DBContext;
using EFCore.SQL.Interface;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.SQL.Repository
{
    public class PurchaseMasterRepository : IPurchaseMaster, IDisposable
    {
        private readonly DatabaseContext _databaseContext;

        public PurchaseMasterRepository()
        {
            _databaseContext = new DatabaseContext();
        }
        public async Task<PurchaseMaster> AddPurchaseAsync(PurchaseMaster purchaseMaster)
        {
            if (purchaseMaster.Id == null)
                purchaseMaster.Id = Guid.NewGuid().ToString();
            await _databaseContext.PurchaseMaster.AddAsync(purchaseMaster);
            await _databaseContext.SaveChangesAsync();
            return purchaseMaster;
        }

        public async Task<bool> DeletePurchaseAsync(string purchaseId, bool isPermanantDetele = false)
        {
            var getPurchase = await _databaseContext.PurchaseMaster.Where(s => s.Id == purchaseId && s.IsDelete == false).FirstOrDefaultAsync();
            if (getPurchase != null)
            {
                if (isPermanantDetele)
                    _databaseContext.PurchaseMaster.Remove(getPurchase);
                else
                    getPurchase.IsDelete = true;

                await _databaseContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public void Dispose()
        {
            _databaseContext.DisposeAsync();
        }

        public async Task<List<PurchaseMaster>> GetAllPurchaseAsync(string companyId, string financialYearId)
        {
            return await _databaseContext.PurchaseMaster.Where(s => s.IsDelete == false && s.FinancialYearId == financialYearId).ToListAsync();
        }

        public async Task<List<PurchaseMaster>> GetAllPurchaseAsync(string companyId, string branchId, string financialYearId)
        {
            return await _databaseContext.PurchaseMaster.Where(s => s.IsDelete == false && s.BranchId == branchId && s.FinancialYearId == financialYearId).ToListAsync();
        }

        public async Task<List<PurchaseMaster>> GetAllPurchaseAsync(string companyId, DateTime startDate, DateTime endDate)
        {
            return await _databaseContext.PurchaseMaster.Where(w => w.IsDelete == false && w.CreatedDate >= startDate && w.CreatedDate <= endDate).ToListAsync();
        }

        public async Task<List<PurchaseMaster>> GetAllPurchaseAsync(string companyId, string branchId, DateTime startDate, DateTime endDate)
        {
            return await _databaseContext.PurchaseMaster.Where(w => w.IsDelete == false && w.BranchId == branchId && w.CreatedDate >= startDate && w.CreatedDate <= endDate).ToListAsync();
        }

        public async Task<long> GetMaxSlipNo(string branchId, string financialYearId)
        {
            var result = await _databaseContext.PurchaseMaster.Where(w => w.BranchId == branchId && w.FinancialYearId == financialYearId).FirstOrDefaultAsync();
            if(result != null)
                return result.SlipNo + 1;
            return 1;
        }

        public async Task<long> GetMaxSrNo(string companyId, string financialYearId)
        {
            var result = await _databaseContext.PurchaseMaster.FirstOrDefaultAsync(w => w.CompanyId == companyId && w.FinancialYearId == financialYearId);
            if(result != null)
                return result.PurchaseBillNo + 1;
            return 1;
        }

        public async Task<PurchaseMaster> UpdatePurchaseAsync(PurchaseMaster purchaseMaster)
        {
            var getPurchase = await _databaseContext.PurchaseMaster.Where(s => s.Id == purchaseMaster.Id && s.IsDelete == false).FirstOrDefaultAsync();
            if (getPurchase != null)
            {
                getPurchase.BranchId = purchaseMaster.BranchId;
                getPurchase.PartyId = purchaseMaster.PartyId;
                getPurchase.ByuerId = purchaseMaster.ByuerId;
                getPurchase.CurrencyId = purchaseMaster.CurrencyId;
                getPurchase.FinancialYearId = purchaseMaster.FinancialYearId;
                getPurchase.BrokerageId = purchaseMaster.BrokerageId;

                getPurchase.CurrencyRate = purchaseMaster.CurrencyRate;
                getPurchase.PurchaseBillNo = purchaseMaster.PurchaseBillNo;
                getPurchase.SlipNo = purchaseMaster.SlipNo;
                getPurchase.TransactionType = purchaseMaster.TransactionType;
                getPurchase.Date = purchaseMaster.Date;
                getPurchase.Time = purchaseMaster.Time;
                getPurchase.DayName = purchaseMaster.DayName;
                getPurchase.PartyLastBalanceWhilePurchase = purchaseMaster.PartyLastBalanceWhilePurchase;
                getPurchase.BrokerPercentage = purchaseMaster.BrokerPercentage;

                getPurchase.BrokerAmount = purchaseMaster.BrokerAmount;
                getPurchase.RoundUpAmount = purchaseMaster.RoundUpAmount;
                getPurchase.Total = purchaseMaster.Total;
                getPurchase.GrossTotal = purchaseMaster.GrossTotal;
                getPurchase.DueDays = purchaseMaster.DueDays;
                getPurchase.DueDate = purchaseMaster.DueDate;
                getPurchase.PaymentDays = purchaseMaster.PaymentDays;
                getPurchase.PaymentDueDays = purchaseMaster.PaymentDueDays;
                getPurchase.IsSlip = purchaseMaster.IsSlip;
                getPurchase.IsPF = purchaseMaster.IsPF;

                getPurchase.CommissionToPartyId = purchaseMaster.CommissionToPartyId;
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

                _databaseContext.PurchaseDetails.RemoveRange(getPurchase.PurchaseDetails);

                await _databaseContext.PurchaseDetails.AddRangeAsync(purchaseMaster.PurchaseDetails);

                await _databaseContext.SaveChangesAsync();
            }
            return purchaseMaster;
        }
    }
}
