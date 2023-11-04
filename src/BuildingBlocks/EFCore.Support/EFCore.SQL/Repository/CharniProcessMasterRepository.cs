using EFCore.SQL.DBContext;
using EFCore.SQL.Interface;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Entities.Model;
using Repository.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.SQL.Repository
{
    public class CharniProcessMasterRepository : ICharniProcessMaster
    {
        private DatabaseContext _databaseContext;

        public CharniProcessMasterRepository()
        {
            
        }

        public async Task<CharniProcessMaster> AddCharniProcessAsync(CharniProcessMaster charniProcessMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                if (charniProcessMaster.Id == null)
                    charniProcessMaster.Id = Guid.NewGuid().ToString();
                await _databaseContext.CharniProcessMaster.AddAsync(charniProcessMaster);
                await _databaseContext.SaveChangesAsync();
                return charniProcessMaster;
            }
        }

        public async Task<bool> DeleteCharniProcessAsync(int charniNo, bool isValidateOnly = false)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var findRecordInCharniReceive = await _databaseContext.CharniProcessMaster.Where(w => w.CharniNo == charniNo && w.CharniType == 1).ToListAsync(); //Check in charni receive

                if (findRecordInCharniReceive.Any())
                    return false;

                var getReccord = await _databaseContext.CharniProcessMaster.Where(w => w.CharniNo == charniNo && w.CharniType == 0).FirstOrDefaultAsync();

                if (getReccord != null)
                {
                    if (isValidateOnly)
                        return true;

                    _databaseContext.CharniProcessMaster.Remove(getReccord);
                    await _databaseContext.SaveChangesAsync();

                    return true;
                }

                return false;
            }
        }

        public async Task<bool> DeleteCharniReceiveAsync(string slipNo, int charniNo, bool isValidateOnly = false)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var findCharniSendRecord = await _databaseContext.GalaProcessMaster.Where(w => w.JangadNo == charniNo && w.GalaProcessType == 0).ToListAsync();
                if (findCharniSendRecord.Any())
                    return false;
                else
                {
                    var checkInAssortReceive = await _databaseContext.CharniProcessMaster.Where(w => w.JangadNo == charniNo && w.CharniType == 2).ToListAsync();
                    if (checkInAssortReceive.Any())
                        return false;

                    var getReccord = await _databaseContext.CharniProcessMaster.Where(w => w.JangadNo == charniNo && w.CharniType == 1).ToListAsync();

                    if (getReccord != null)
                    {
                        if (isValidateOnly)
                            return true;

                        _databaseContext.CharniProcessMaster.RemoveRange(getReccord);
                        await _databaseContext.SaveChangesAsync();

                        return true;
                    }
                }

                return false;
            }
        }

        public async Task<List<CharniProcessMaster>> GetCharniProcessAsync(string companyId, string branchId, string financialYearId, int charniType)
        {
            using (_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.CharniProcessMaster.Where(w => w.CompanyId == companyId && w.BranchId == branchId && w.FinancialYearId == financialYearId && w.CharniType == charniType).ToListAsync();
            }
        }

        public async Task<int> GetMaxSrNoAsync(string companyId, string branchId, string financialYearId, int charniType)
        {
            try
            {
                using (_databaseContext = new DatabaseContext())
                {
                    var getCount = await _databaseContext.CharniProcessMaster.Where(m => m.CompanyId == companyId && m.BranchId == branchId && m.FinancialYearId == financialYearId && m.CharniType == charniType).MaxAsync(m => m.JangadNo);
                    return getCount + 1;
                }
            }
            catch (Exception ex)
            {
                return 1;
            }
        }

        public async Task<CharniProcessMaster> UpdateCharniProcessAsync(CharniProcessMaster charniProcessMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getRecord = await _databaseContext.CharniProcessMaster.Where(w => w.Id == charniProcessMaster.Id).FirstOrDefaultAsync();

                if (getRecord != null)
                {
                    getRecord.CharniCategoy = charniProcessMaster.CharniCategoy;
                    getRecord.CharniType = charniProcessMaster.CharniType;
                    getRecord.BranchId = charniProcessMaster.BranchId;
                    getRecord.CompanyId = charniProcessMaster.CompanyId;
                    getRecord.EntryDate = charniProcessMaster.EntryDate;
                    getRecord.FinancialYearId = charniProcessMaster.FinancialYearId;
                    getRecord.HandOverById = charniProcessMaster.HandOverById;
                    getRecord.HandOverToId = charniProcessMaster.HandOverToId;
                    getRecord.IsDelete = false;
                    getRecord.JangadNo = charniProcessMaster.JangadNo;
                    getRecord.KapanId = charniProcessMaster.KapanId;
                    getRecord.LossWeight = charniProcessMaster.LossWeight;
                    getRecord.RejectionWeight = charniProcessMaster.RejectionWeight;
                    getRecord.Remarks = charniProcessMaster.Remarks;
                    getRecord.ShapeId = charniProcessMaster.ShapeId;
                    getRecord.SizeId = charniProcessMaster.SizeId;
                    getRecord.PurityId = charniProcessMaster.PurityId;
                    getRecord.SlipNo = charniProcessMaster.SlipNo;
                    getRecord.UpdatedBy = charniProcessMaster.UpdatedBy;
                    getRecord.UpdatedDate = charniProcessMaster.UpdatedDate;
                    getRecord.Weight = charniProcessMaster.Weight;

                    await _databaseContext.SaveChangesAsync();
                }

                return charniProcessMaster;
            }
        }

        public async Task<List<CharniProcessSend>> GetCharniSendToDetails(string companyId, string branchId, string financialYearId)
        {
            try
            {
                using (_databaseContext = new DatabaseContext())
                {
                    var data = await _databaseContext.SPCharniProcessSend.FromSqlRaw($"GetCharniToDetail '" + companyId + "', '" + branchId + "','" + financialYearId + "'").ToListAsync();

                    return data;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<CharniProcessReceive>> GetCharniReceiveDetails(string ReceiveFrom, string companyId, string branchId, string financialYearId)
        {
            try
            {
                using (_databaseContext = new DatabaseContext())
                {
                    var data = await _databaseContext.SPCharniProcessReceive.FromSqlRaw($"GetCharniProcessReceiveDetail '" + ReceiveFrom + "','" + companyId + "', '" + branchId + "','" + financialYearId + "'").ToListAsync();

                    return data;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<CharniSendReceiveReportModel>> GetCharniSendReceiveReports(string companyId, string branchId, string financialYearId, int charniType)
        {
            try
            {
                using (_databaseContext = new DatabaseContext())
                {
                    var data = await _databaseContext.SPCharniSendReceiveReportModels.FromSqlRaw($"GetCharniSendReceiveReport '" + companyId + "', '" + branchId + "','" + financialYearId + "'," + charniType).ToListAsync();

                    return data;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
