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
    public class ShapeMasterRepository : IShapeMaster
    {
        private DatabaseContext _databaseContext;

        public ShapeMasterRepository()
        {
            
        }

        public async Task<List<ShapeMaster>> GetAllShapeAsync()
        {
            using (_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.ShapeMaster.Where(s => s.IsDelete == false).ToListAsync();
            }
        }

        public async Task<ShapeMaster> AddShapeAsync(ShapeMaster shapeMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                if (shapeMaster.Id == null)
                    shapeMaster.Id = Guid.NewGuid().ToString();
                await _databaseContext.ShapeMaster.AddAsync(shapeMaster);
                await _databaseContext.SaveChangesAsync();
                return shapeMaster;
            }
        }

        public async Task<bool> DeleteShapeAsync(string purityId, bool isPermanantDetele = false)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getShape = await _databaseContext.ShapeMaster.Where(s => s.Id == purityId).FirstOrDefaultAsync();
                if (getShape != null)
                {
                    if (isPermanantDetele)
                        _databaseContext.ShapeMaster.Remove(getShape);
                    else
                        getShape.IsDelete = true;
                    await _databaseContext.SaveChangesAsync();

                    return true;
                }

                return false;
            }
        }

        public async Task<ShapeMaster> UpdateShapeAsync(ShapeMaster shapeMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getShape = await _databaseContext.ShapeMaster.Where(s => s.Id == shapeMaster.Id).FirstOrDefaultAsync();
                if (getShape != null)
                {
                    getShape.Name = shapeMaster.Name;
                    getShape.UpdatedDate = shapeMaster.UpdatedDate;
                    getShape.UpdatedBy = shapeMaster.UpdatedBy;
                }
                await _databaseContext.SaveChangesAsync();
                return shapeMaster;
            }
        }
    }
}
