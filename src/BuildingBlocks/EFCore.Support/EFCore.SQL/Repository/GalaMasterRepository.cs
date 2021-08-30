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
    public class GalaRepository : IGalaMaster
    {
        private readonly DatabaseContext _databaseContext;

        public GalaRepository()
        {
            _databaseContext = new DatabaseContext();
        }

        public async Task<List<GalaMaster>> GetAllGalaAsync()
        {
            return await _databaseContext.GalaMaster.Where(s => s.IsDelete == false).ToListAsync();
        }

        public async Task<GalaMaster> AddGalaAsync(GalaMaster galaMaster)
        {
            await _databaseContext.GalaMaster.AddAsync(galaMaster);
            await _databaseContext.SaveChangesAsync();
            return galaMaster;
        }

        public async Task<bool> DeleteGalaAsync(Guid galaId, bool isPermanantDetele = false)
        {
            var getGala = await _databaseContext.GalaMaster.Where(s => s.Id == galaId).FirstOrDefaultAsync();
            if (getGala != null)
            {
                if (isPermanantDetele)
                    _databaseContext.GalaMaster.Remove(getGala);
                else
                    getGala.IsDelete = true;
                await _databaseContext.SaveChangesAsync();

                return true;
            }
            
            return false;
        }

        public async Task<GalaMaster> UpdateGalaAsync(GalaMaster galaMaster)
        {
            var getGala = await _databaseContext.GalaMaster.Where(s => s.Id == galaMaster.Id).FirstOrDefaultAsync();
            if (getGala != null)
            {
                getGala.Name = galaMaster.Name;
                getGala.UpdatedDate = galaMaster.UpdatedDate;
                getGala.UpdatedBy = galaMaster.UpdatedBy;
            }
            await _databaseContext.SaveChangesAsync();
            return galaMaster;
        }
    }
}
