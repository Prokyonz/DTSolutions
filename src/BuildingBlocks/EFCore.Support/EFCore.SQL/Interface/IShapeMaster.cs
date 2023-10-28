using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface IShapeMaster
    {
        Task<List<ShapeMaster>> GetAllShapeAsync();
        Task<ShapeMaster> AddShapeAsync(ShapeMaster shapeMaster);
        Task<ShapeMaster> UpdateShapeAsync(ShapeMaster shapeMaster);
        Task<int> DeleteShapeAsync(string shapeId, bool isPermanantDetele = false);
    }
}
