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
    public class PurityMasterRepository : IPurityMaster
    {
        private DatabaseContext _databaseContext;

        public PurityMasterRepository()
        {
            
        }

        public async Task<List<PurityMaster>> GetAllPurityAsync(bool isDeleteInclude = false)
        {
            using (_databaseContext = new DatabaseContext())
            {
                if (isDeleteInclude == false)
                    return await _databaseContext.PurityMaster.Where(s => s.IsDelete == false).ToListAsync();
                else
                    return await _databaseContext.PurityMaster.ToListAsync();
            }
        }

        public async Task<PurityMaster> GetPurityById(string purityId, bool isDeleteInclude = false)
        {
            using (_databaseContext = new DatabaseContext())
            {
                if (isDeleteInclude == false)
                    return await _databaseContext.PurityMaster.Where(s => s.IsDelete == false && s.Id == purityId).FirstOrDefaultAsync();
                else
                    return await _databaseContext.PurityMaster.Where(s => s.Id == purityId).FirstOrDefaultAsync();
            }
        }

        public async Task<PurityMaster> AddPurityAsync(PurityMaster purityMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                if (purityMaster.Id == null)
                    purityMaster.Id = Guid.NewGuid().ToString();
                await _databaseContext.PurityMaster.AddAsync(purityMaster);
                await _databaseContext.SaveChangesAsync();
                return purityMaster;
            }
        }

        public async Task<bool> DeletePurityAsync(string purityId, bool isPermanantDetele = false)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getPurity = await _databaseContext.PurityMaster.Where(s => s.Id == purityId).FirstOrDefaultAsync();
                if (getPurity != null)
                {
                    if (isPermanantDetele)
                        _databaseContext.PurityMaster.Remove(getPurity);
                    else
                        getPurity.IsDelete = true;
                    await _databaseContext.SaveChangesAsync();

                    return true;
                }

                return false;
            }
        }

        public async Task<PurityMaster> UpdatePurityAsync(PurityMaster purityMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getPurity = await _databaseContext.PurityMaster.Where(s => s.Id == purityMaster.Id).FirstOrDefaultAsync();
                if (getPurity != null)
                {
                    getPurity.Name = purityMaster.Name;
                    getPurity.UpdatedDate = purityMaster.UpdatedDate;
                    getPurity.UpdatedBy = purityMaster.UpdatedBy;
                }
                await _databaseContext.SaveChangesAsync();
                return purityMaster;
            }
        }
    }
}
