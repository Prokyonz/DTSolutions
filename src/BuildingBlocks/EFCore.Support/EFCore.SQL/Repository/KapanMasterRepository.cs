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
    public class KapanMasterRepository : IKapanMaster
    {
        private DatabaseContext _databaseContext;
        public KapanMasterRepository()
        {
            
        }

        public async Task<KapanMaster> AddKapanAsync(KapanMaster kapanMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                if (kapanMaster.Id == null)
                    kapanMaster.Id = Guid.NewGuid().ToString();
                await _databaseContext.KapanMaster.AddAsync(kapanMaster);
                await _databaseContext.SaveChangesAsync();
                return kapanMaster;
            }
        }

        public async Task<int> DeleteKapanAsync(string kapanId, bool isPermanantDetele = false)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var resultCount = await _databaseContext.SPValidationModel.FromSqlRaw($"Validate_Records '" + kapanId + "',14").ToListAsync();
                return resultCount[0].Status;
                //var count = await _databaseContext.KapanMappingMaster.Where(w => w.KapanId == kapanId).CountAsync();
                //var openingCount = await _databaseContext.OpeningStockMaster.Where(w => w.KapanId == kapanId).CountAsync();
                //if ((count + openingCount) == 0)
                //{
                //    var getKapan = await _databaseContext.KapanMaster.Where(s => s.Id == kapanId).FirstOrDefaultAsync();
                //    if (getKapan != null)
                //    {
                //        if (isPermanantDetele)
                //            _databaseContext.KapanMaster.Remove(getKapan);
                //        else
                //            getKapan.IsDelete = true;

                //        await _databaseContext.SaveChangesAsync();
                //        return true;
                //    }
                //}
                //return false;
            }
        }

        public async Task<List<KapanMaster>> GetAllKapanAsync(string CompanyId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.KapanMaster.Where(s => s.IsDelete == false && s.CompanyId == CompanyId).ToListAsync();
            }
        }

        public async Task<List<KapanMaster>> GetAllKapanAsync()
        {
            using (_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.KapanMaster.Where(s => s.IsDelete == false).ToListAsync();
            }
        }

        public async Task<List<KapanMaster>> GetAssortProcessKapanDetails(string companyId, string branchId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                try
                {
                    using (_databaseContext = new DatabaseContext())
                    {
                        var data = await _databaseContext.KapanMaster.FromSqlRaw($"GetAssortProcessKapanDetails '" + companyId + "', '" + branchId + "'").ToListAsync();

                        return data;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public async Task<KapanMaster> UpdateKapanAsync(KapanMaster kapanMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getKapan = await _databaseContext.KapanMaster.Where(s => s.Id == kapanMaster.Id).FirstOrDefaultAsync();
                if (getKapan != null)
                {
                    getKapan.Name = kapanMaster.Name;
                    getKapan.Details = kapanMaster.Details;
                    getKapan.CaratLimit = kapanMaster.CaratLimit;
                    getKapan.IsStatus = kapanMaster.IsStatus;
                    getKapan.StartDate = kapanMaster.StartDate;
                    getKapan.EndDate = kapanMaster.EndDate;
                    getKapan.CompanyId = kapanMaster.CompanyId;
                }
                await _databaseContext.SaveChangesAsync();
                return kapanMaster;
            }
        }

        public async Task<List<KapanLagadReportSPModel>> GetKapanLagadReport(string KapanId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var KapanLagadDetails = await _databaseContext.SPKapanLagadReportModel.FromSqlRaw($"GetKapanLagadReportDetails '" + KapanId + "'").ToListAsync();
                return KapanLagadDetails;
            }
        }
    }
}
