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
    public class GalaMasterRepository : IGalaMaster
    {
        private DatabaseContext _databaseContext;

        public GalaMasterRepository()
        {
            
        }

        public async Task<List<GalaMaster>> GetAllGalaAsync()
        {
            using (_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.GalaMaster.Where(s => s.IsDelete == false).ToListAsync();
            }
        }

        public async Task<GalaMaster> AddGalaAsync(GalaMaster galaMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                if (galaMaster.Id == null)
                    galaMaster.Id = Guid.NewGuid().ToString();
                await _databaseContext.GalaMaster.AddAsync(galaMaster);
                await _databaseContext.SaveChangesAsync();
                return galaMaster;
            }
        }

        public async Task<int> DeleteGalaAsync(string galaId, bool isPermanantDetele = false)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var resultCount = await _databaseContext.SPValidationModel.FromSqlRaw($"Validate_Records '" + galaId + "',8").ToListAsync();
                return resultCount[0].Status;
                //var getGala = await _databaseContext.GalaMaster.Where(s => s.Id == galaId).FirstOrDefaultAsync();
                //if (getGala != null)
                //{
                //    if (isPermanantDetele)
                //        _databaseContext.GalaMaster.Remove(getGala);
                //    else
                //        getGala.IsDelete = true;
                //    await _databaseContext.SaveChangesAsync();

                //    return true;
                //}

                //return false;
            }
        }

        public async Task<GalaMaster> UpdateGalaAsync(GalaMaster galaMaster)
        {
            using (_databaseContext = new DatabaseContext())
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
}
