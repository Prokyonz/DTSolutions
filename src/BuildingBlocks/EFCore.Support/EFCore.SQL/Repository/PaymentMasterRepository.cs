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
                var countResult = await _databaseContext.GroupPaymentMaster.Where(w =>w.CrDrType == paymentType && w.CompanyId == companyId && w.FinancialYearId == financialYearId).OrderByDescending(o => o.Sr).FirstOrDefaultAsync();
                if (countResult == null)
                    return 1;
                return countResult.BillNo + 1;
            }
        }

        public async Task<List<PaymentSPModel>> GetPaymentReport(string companyId, string financialYearId, int paymentType)
        {
            using(_databaseContext = new DatabaseContext())
            {
                var paymentRecords = await _databaseContext.SPPaymentModel.FromSqlRaw($"getPaymentReport '" + companyId + "','" + financialYearId + "','"+ paymentType +"'").ToListAsync();
                return paymentRecords;
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
    }
}
