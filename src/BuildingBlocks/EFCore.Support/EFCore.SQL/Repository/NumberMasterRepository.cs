using EFCore.SQL.DBContext;
using EFCore.SQL.Interface;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.SQL.Repository
{
    public class NumberMasterRepository : INumberMaster
    {
        private readonly DatabaseContext _databaseContext;

        public NumberMasterRepository()
        {
            _databaseContext = new DatabaseContext();
        }

        public async Task<List<NumberMaster>> GetAllGalaAsync()
        {
            return await _databaseContext.NumberMaster.Where(s => s.IsDelete == false).ToListAsync();
        }

        public async Task<NumberMaster> AddNumberAsync(NumberMaster numberMaster)
        {
            await _databaseContext.NumberMaster.AddAsync(numberMaster);
            await _databaseContext.SaveChangesAsync();
            return numberMaster;
        }

        public async Task<bool> DeleteNumberAsync(int numberId, bool isPermanantDetele = false)
        {
            var getNumber = await _databaseContext.NumberMaster.Where(s => s.Id == numberId).FirstOrDefaultAsync();
            if (getNumber != null)
            {
                if (isPermanantDetele)
                    _databaseContext.NumberMaster.Remove(getNumber);
                else
                    getNumber.IsDelete = true;
                await _databaseContext.SaveChangesAsync();

                return true;
            }
            
            return false;
        }

        public async Task<NumberMaster> UpdateNumberAsync(NumberMaster numberMaster)
        {
            var getNumber = await _databaseContext.NumberMaster.Where(s => s.Id == numberMaster.Id).FirstOrDefaultAsync();
            if (getNumber != null)
            {
                getNumber.Name = numberMaster.Name;
                getNumber.UpdatedDate = numberMaster.UpdatedDate;
                getNumber.UpdatedBy = numberMaster.UpdatedBy;
            }
            await _databaseContext.SaveChangesAsync();
            return numberMaster;
        }
    }
}
