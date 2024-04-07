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
    public class RejectionInOutMasterRepository : IRejectionInOutMaster
    {
        public DatabaseContext _databaseContext;
        public RejectionInOutMasterRepository()
        {

        }

        public async Task<RejectionInOutMaster> AddRejectionAsync(RejectionInOutMaster rejectionInOutMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                if (rejectionInOutMaster.Id == null)
                    rejectionInOutMaster.Id = Guid.NewGuid().ToString();

                await _databaseContext.RejectionInOutMaster.AddAsync(rejectionInOutMaster);
                await _databaseContext.SaveChangesAsync();
            }
            return rejectionInOutMaster;
        }

        public async Task<bool> DeleteRejectionAsync(string rejectionId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var record = await _databaseContext.RejectionInOutMaster.Where(s => s.Id == rejectionId).FirstOrDefaultAsync();
                if(record != null)
                     _databaseContext.RejectionInOutMaster.Remove(record);
                await _databaseContext.SaveChangesAsync();
                return true;
            }
        }

        public async Task<List<RejectionInOutMaster>> GetAllRejectionInAsync(string companyId, string financialYearId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var record = await _databaseContext.RejectionInOutMaster.Where(s => s.CompanyId == companyId && s.FinancialYearId == financialYearId && s.TransType == 1).ToListAsync();
                return record;
            }
        }

        public async Task<List<RejectionInOutMaster>> GetAllRejectionOutAsync(string companyId, string financialYearId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var record = await _databaseContext.RejectionInOutMaster.Where(s => s.CompanyId == companyId && s.FinancialYearId == financialYearId && s.TransType == 2).ToListAsync();
                return record;
            }
        }

        public async Task<int> GetMaxSrNoAsync(string companyId, string financialYearId, int transType)
        {
            try
            {
                using (_databaseContext = new DatabaseContext())
                {
                    var getCount = await _databaseContext.RejectionInOutMaster.Where(m => m.CompanyId == companyId && m.FinancialYearId == financialYearId && m.TransType == transType).MaxAsync(m => m.SrNo);
                    return getCount + 1;
                }
            }
            catch (Exception ex)
            {
                return 1;
            }
        }

        public async Task<RejectionInOutMaster> UpdateRejectionAsync(RejectionInOutMaster rejectionInOutMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var record = await _databaseContext.RejectionInOutMaster.Where(s => s.Id == rejectionInOutMaster.Id).FirstOrDefaultAsync();
                if(record != null)
                {
                    record.PartyId = rejectionInOutMaster.PartyId;
                    record.BrokerageId = rejectionInOutMaster.BrokerageId;
                    record.SizeId = rejectionInOutMaster.SizeId;
                    record.Rate = rejectionInOutMaster.Rate;
                    record.TotalCarat = rejectionInOutMaster.TotalCarat;
                    record.Amount = rejectionInOutMaster.Amount;
                    record.Image1 = rejectionInOutMaster.Image1;
                    record.Image2 = rejectionInOutMaster.Image2;
                    record.Image3 = rejectionInOutMaster.Image3;
                    record.Remarks = rejectionInOutMaster.Remarks;
                    record.EntryDate = rejectionInOutMaster.EntryDate;
                    record.UpdatedBy = rejectionInOutMaster.UpdatedBy;
                    record.UpdatedDate = rejectionInOutMaster.UpdatedDate;
                    record.LessWeight = rejectionInOutMaster.LessWeight;

                    await _databaseContext.SaveChangesAsync();
                }
                return rejectionInOutMaster;
            }
        }

        public async Task<List<RejectionSendReceiveSPModel>> GetRejectionSendReceiveDetail(string companyId, string financialYearId, string partyId = null, int TransType = 0)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var purchaseReport = await _databaseContext.SPRejectionSendReceiveModel.FromSqlRaw($"GetRejectionSendReceiveDetail '" + companyId + "','" + financialYearId + "','" + partyId + "', '" + TransType + "'").ToListAsync();
                return purchaseReport;
            }
        }

        public async Task<List<RejectionInOutSPModel>> GetRejectionSendReceiveReport(string companyId, string financialYearId, int TransType)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var rejectionReport = await _databaseContext.SPRejectionSendReceiveReport.FromSqlRaw($"GetRejectInOutReport '" + companyId + "','" + financialYearId + "','" + TransType + "'").ToListAsync();
                return rejectionReport;
            }
        }
    }
}
