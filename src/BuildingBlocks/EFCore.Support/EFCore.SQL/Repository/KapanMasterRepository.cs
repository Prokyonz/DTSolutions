using EFCore.SQL.DBContext;
using EFCore.SQL.Interface;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.SQL.Repository
{
    public class KapanMasterRepository : IKapanMaster
    {
        private readonly DatabaseContext _databaseContext;
        public KapanMasterRepository()
        {
            _databaseContext = new DatabaseContext();
        }

        public async Task<KapanMaster> AddKapanAsync(KapanMaster kapanMaster)
        {
            await _databaseContext.KapanMaster.AddAsync(kapanMaster);
            return kapanMaster;
        }

        public async Task<bool> DeleteKapanAsync(int kapanId, bool isPermanantDetele = false)
        {
            var getKapan = await _databaseContext.KapanMaster.Where(s => s.Id == kapanId).FirstOrDefaultAsync();
            if (getKapan != null)
            {
                if (isPermanantDetele)
                    _databaseContext.KapanMaster.Remove(getKapan);
                else
                    getKapan.IsDelete = true;
            }
            await _databaseContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<KapanMaster>> GetAllKapanAsync()
        {
            return await _databaseContext.KapanMaster.Where(s => s.IsDelete == false).ToListAsync();
        }

        public async Task<KapanMaster> UpdateKapanAsync(KapanMaster kapanMaster)
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
            }
            return kapanMaster;
        }
    }
}
