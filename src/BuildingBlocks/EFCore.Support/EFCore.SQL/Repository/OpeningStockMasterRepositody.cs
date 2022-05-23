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
    public class OpeningStockMasterRepositody : IOpeningStockMaster
    {
        private DatabaseContext _databaseContext;

        public OpeningStockMasterRepositody()
        {

        }

        public async Task<OpeningStockMaster> AddOpeningStockAsync(OpeningStockMaster openingStockMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                if (openingStockMaster.Id == null)
                    openingStockMaster.Id = Guid.NewGuid().ToString();

                await _databaseContext.OpeningStockMaster.AddAsync(openingStockMaster);
                await _databaseContext.SaveChangesAsync();

                return openingStockMaster;
            }
        }

        public async Task<bool> DeleteBranchAsync(string stockMasterId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getReccord = await _databaseContext.OpeningStockMaster.Where(w => w.Id == stockMasterId).FirstOrDefaultAsync();
                if (getReccord == null)
                {
                    _databaseContext.OpeningStockMaster.Remove(getReccord);
                    await _databaseContext.SaveChangesAsync();

                    return true;
                }

                return false;
            }
        }

        public async Task<List<OpeningStockSPModel>> GetAllOpeningStockAsync(string companyId, string financialYearId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getReccord = await _databaseContext.SPOpeningStockSPModel.FromSqlRaw($"GetOpeningStockReport '" + companyId + "','" + financialYearId + "'").ToListAsync();

                return getReccord;
            }
        }

        public async Task<int> GetMaxAsync(string companyId, string financialYearId)
        {
            try
            {
                using (_databaseContext = new DatabaseContext())
                {
                    var getCount = await _databaseContext.OpeningStockMaster.Where(m => m.CompanyId == companyId && m.FinancialYearId == financialYearId).MaxAsync(m => m.SrNo);
                    return getCount + 1;
                }
            }
            catch (Exception ex)
            {
                return 1;
            }
        }

        public async Task<OpeningStockMaster> UpdateBranchAsync(OpeningStockMaster openingStockMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getReccord = await _databaseContext.OpeningStockMaster.Where(w => w.Id == openingStockMaster.Id).FirstOrDefaultAsync();
                if (getReccord == null)
                {
                    getReccord.TotalCts = openingStockMaster.TotalCts;
                    getReccord.Amount = openingStockMaster.Amount;
                    getReccord.NumberId = openingStockMaster.NumberId;
                    getReccord.KapanId = openingStockMaster.KapanId;
                    getReccord.ShapeId = openingStockMaster.ShapeId;
                    getReccord.SizeId = openingStockMaster.SizeId;
                    getReccord.KapanId = openingStockMaster.PurityId;
                    getReccord.BranchId = openingStockMaster.BranchId;
                    getReccord.Rate = openingStockMaster.Rate;
                    getReccord.EntryDate = openingStockMaster.EntryDate;
                    getReccord.EntryTime = openingStockMaster.EntryTime;
                    getReccord.UpdatedDate = DateTime.Now;

                    await _databaseContext.SaveChangesAsync();

                    return openingStockMaster;
                }

                return openingStockMaster;
            }
        }
    }
}
