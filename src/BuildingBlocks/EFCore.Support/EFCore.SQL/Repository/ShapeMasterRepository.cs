using EFCore.SQL.DBContext;
using EFCore.SQL.Interface;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.SQL.Repository
{
    public class ShapeMasterRepository : IShapeMaster
    {
        private readonly DatabaseContext _databaseContext;

        public ShapeMasterRepository()
        {
            _databaseContext = new DatabaseContext();
        }

        public async Task<List<ShapeMaster>> GetAllShapeAsync()
        {
            return await _databaseContext.ShapeMaster.Where(s => s.IsDelete == false).ToListAsync();
        }

        public async Task<ShapeMaster> AddShapeAsync(ShapeMaster shapeMaster)
        {
            await _databaseContext.ShapeMaster.AddAsync(shapeMaster);
            return shapeMaster;
        }

        public async Task<bool> DeleteShapeAsync(int purityId, bool isPermanantDetele = false)
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

        public async Task<ShapeMaster> UpdateShapeAsync(ShapeMaster shapeMaster)
        {
            var getShape = await _databaseContext.ShapeMaster.Where(s => s.Id == shapeMaster.Id).FirstOrDefaultAsync();
            if (getShape != null)
            {
                getShape.Name = shapeMaster.Name;
                getShape.UpdatedDate = shapeMaster.UpdatedDate;
                getShape.UpdatedBy = shapeMaster.UpdatedBy;
            }

            return shapeMaster;
        }
    }
}
