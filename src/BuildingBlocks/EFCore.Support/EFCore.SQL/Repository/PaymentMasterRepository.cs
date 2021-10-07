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

        public Task<bool> DeletePaymentAsync(Guid groupId)
        {
            throw new NotImplementedException();
        }
        
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<List<GroupPaymentMaster>> GetAllPaymentAsync(Guid companyId, Guid financialYearId)
        {
            return await _databaseContext.GroupPaymentMaster.Where(w => w.CompanyId == companyId && w.FinancialYearId == financialYearId).Include("PaymentMaster").Include("PaymentDetails").ToListAsync();
        }

        public Task<GroupPaymentMaster> UpdatePaymentAsync(GroupPaymentMaster groupPaymentMaster)
        {
            throw new NotImplementedException();
        }
    }
}
