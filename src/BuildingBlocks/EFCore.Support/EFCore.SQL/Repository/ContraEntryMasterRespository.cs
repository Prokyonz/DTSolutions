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
    public class ContraEntryMasterRespository : IContraEntryMaster
    {
        private DatabaseContext _databaseContext;

        public ContraEntryMasterRespository()
        {
            
        }
        public async Task<ContraEntryMaster> AddContraEntryAsync(ContraEntryMaster contraEntryMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                if (contraEntryMaster.Id == null)
                    contraEntryMaster.Id = Guid.NewGuid().ToString();
                await _databaseContext.ContraEntryMaster.AddAsync(contraEntryMaster);
                await _databaseContext.SaveChangesAsync();

                //var getToPartyRecord = await _databaseContext.PartyMaster.Where(w => w.Id == contraEntryMaster.ToPartyId).FirstOrDefaultAsync();

                //foreach (var item in contraEntryMaster.ContraEntryDetails)
                //{
                //    getToPartyRecord.OpeningBalance += item.Amount;
                //    var getFromPartyRecord = await _databaseContext.PartyMaster.Where(w => w.Id == item.FromParty).FirstOrDefaultAsync();
                //    getFromPartyRecord.OpeningBalance -= item.Amount;

                //    await _databaseContext.SaveChangesAsync();
                //}


                return contraEntryMaster;
            }
        }

        public async Task<bool> DeleteContraEntryAsync(int SrNo, string companyId, string financialYearId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getContraEntry = await _databaseContext.ContraEntryMaster.Where(w => w.SrNo == SrNo && w.CompanyId == companyId && w.FinancialYearId == financialYearId).FirstOrDefaultAsync();
                if (getContraEntry != null)
                {
                    var getContraEnteryDetails = await _databaseContext.ContraEntryDetails.Where(w => w.ContraEntryMasterId == getContraEntry.Id).ToListAsync();

                    if (getContraEnteryDetails != null && getContraEnteryDetails.Count > 0)
                        _databaseContext.ContraEntryDetails.RemoveRange(getContraEnteryDetails);

                    _databaseContext.ContraEntryMaster.Remove(getContraEntry);

                    await _databaseContext.SaveChangesAsync();

                    return true;
                }
                return false;
            }
        }

        public async Task<List<ContraEntryMaster>> GetAllContraEntryAsync(string companyId, string financialYearId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.ContraEntryMaster.Where(w => w.CompanyId == companyId && w.FinancialYearId == financialYearId).ToListAsync();
            }
        }

        public async Task<List<ContraSPModel>> GetContraReport(string companyId, string financialYearId, string fromDate, string toDate)
        {

            using (_databaseContext = new DatabaseContext())
            {
                var paymentRecords = await _databaseContext.SPContraModel.FromSqlRaw($"GetContraReport '" + companyId + "','" + financialYearId + "', '"+ fromDate+"', '"+ toDate+"'").ToListAsync();
                return paymentRecords;
            }
        }

        public async Task<ContraEntryMaster> GetContraEntryAsync(string companyId, string financialYearId, int SrNo)
        {
            using (_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.ContraEntryMaster.Where(w => w.IsDelete == false && w.CompanyId == companyId && w.FinancialYearId == financialYearId && w.SrNo == SrNo).Include("ContraEntryDetails").FirstOrDefaultAsync();
            }
        }

        public async Task<int> GetMaxNo(string companyId, string financialYearId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var countResult = await _databaseContext.ContraEntryMaster.Where(w => w.CompanyId == companyId && w.FinancialYearId == financialYearId).OrderByDescending(o => o.SrNo).FirstOrDefaultAsync();
                if (countResult == null)
                    return 1;
                return countResult.SrNo + 1;
            }
        }

        public async Task<ContraEntryMaster> UpdateContraEntryAsync(ContraEntryMaster contraEntryMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getContra = await _databaseContext.ContraEntryMaster.Where(w => w.Id == contraEntryMaster.Id).FirstOrDefaultAsync();
                if (getContra != null)
                {
                    getContra.BranchId = contraEntryMaster.BranchId;
                    getContra.ToPartyId = contraEntryMaster.ToPartyId;
                    getContra.CompanyId = contraEntryMaster.CompanyId;
                    getContra.CreatedBy = contraEntryMaster.CreatedBy;
                    getContra.CreatedDate = contraEntryMaster.CreatedDate;
                    getContra.FinancialYearId = contraEntryMaster.FinancialYearId;
                    getContra.IsDelete = contraEntryMaster.IsDelete;
                    getContra.Remarks = contraEntryMaster.Remarks;
                    getContra.UpdatedBy = contraEntryMaster.UpdatedBy;
                    getContra.UpdatedDate = contraEntryMaster.UpdatedDate;

                    var getContraChild = await _databaseContext.ContraEntryDetails.Where(w => w.ContraEntryMasterId == contraEntryMaster.Id).ToListAsync();
                    if (getContraChild != null && getContraChild.Count > 0)
                    {
                        _databaseContext.ContraEntryDetails.RemoveRange(getContraChild);

                        await _databaseContext.ContraEntryDetails.AddRangeAsync(contraEntryMaster.ContraEntryDetails);
                    }

                    await _databaseContext.SaveChangesAsync();
                }

                return contraEntryMaster;
            }
        }
    }
}
