using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface IGalaMaster
    {
        Task<List<GalaMaster>> GetAllGalaAsync();
        Task<GalaMaster> AddGalaAsync(GalaMaster shapeMaster);
        Task<GalaMaster> UpdateGalaAsync(GalaMaster shapeMaster);
        Task<bool> DeleteGalaAsync(Guid galaId, bool isPermanantDetele = false);
    }
}
