using EFCore.SQL.DBContext;
using EFCore.SQL.Interface;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.SQL.Repository
{
    public class PurityMasterRepository : IPurityMaster
    {
        private readonly DatabaseContext _databaseContext;

        public PurityMasterRepository()
        {
            _databaseContext = new DatabaseContext();
        }

        public async Task<List<PurityMaster>> GetAllPurityAsync()
        {
            return await _databaseContext.PurityMaster.Where(s => s.IsDelete == false).ToListAsync();
        }

        public async Task<PurityMaster> AddPurityAsync(PurityMaster purityMaster)
        {
            await _databaseContext.PurityMaster.AddAsync(purityMaster);
            return purityMaster;
        }

        public async Task<bool> DeletePurityAsync(int purityId, bool isPermanantDetele = false)
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

        public async Task<PurityMaster> UpdatePurityAsync(PurityMaster purityMaster)
        {
            var getPurity = await _databaseContext.PurityMaster.Where(s => s.Id == purityMaster.Id).FirstOrDefaultAsync();
            if (getPurity != null)
            {
                getPurity.Name = purityMaster.Name;
                getPurity.UpdatedDate = purityMaster.UpdatedDate;
                getPurity.UpdatedBy = purityMaster.UpdatedBy;
            }

            return purityMaster;
        }
    }
}
