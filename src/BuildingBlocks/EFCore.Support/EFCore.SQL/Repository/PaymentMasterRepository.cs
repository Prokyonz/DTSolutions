using EFCore.SQL.DBContext;
using EFCore.SQL.Interface;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.SQL.Repository
{
    public class PaymentMasterRepository : IPaymentMaster, IDisposable
    {
        private readonly DatabaseContext _databaseContext;

        public PaymentMasterRepository()
        {
            _databaseContext = new DatabaseContext();
        }
        public async Task<GroupPaymentMaster> AddPaymentAsync(GroupPaymentMaster groupPaymentMaster)
        {
            if (groupPaymentMaster.Id == null)
                groupPaymentMaster.Id = Guid.NewGuid();

            await _databaseContext.GroupPaymentMaster.AddAsync(groupPaymentMaster);
            await _databaseContext.SaveChangesAsync();

            return groupPaymentMaster;
        }

        public async Task<bool> DeletePaymentAsync(Guid groupId)
        {
            var paymentRecord = await _databaseContext.GroupPaymentMaster.Where(w => w.Id == groupId).FirstOrDefaultAsync();
            if(paymentRecord != null)
            {
                paymentRecord.IsDelete = true;
                await _databaseContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        
        public void Dispose()
        {
            _databaseContext.DisposeAsync();
        }

        public async Task<List<GroupPaymentMaster>> GetAllPaymentAsync(Guid companyId, Guid financialYearId)
        {
            return await _databaseContext.GroupPaymentMaster.Where(w => w.CompanyId == companyId && w.FinancialYearId == financialYearId).Include("PaymentMaster").Include("PaymentDetails").ToListAsync();
        }

        public async Task<GroupPaymentMaster> UpdatePaymentAsync(GroupPaymentMaster groupPaymentMaster)
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
