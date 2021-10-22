using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface ILessWeightMaster
    {
        Task<List<LessWeightMaster>> GetLessWeightMasters();
        Task<LessWeightMaster> AddLessWeightMaster(LessWeightMaster lessWeightMaster);
        Task<LessWeightMaster> UpdateLessWeightMaster(LessWeightMaster lessWeightMaster);
        Task<bool> DeleteLessWeightMaster(string lessWeightMasterId, bool isPermanantDelete = false);
    }
}
