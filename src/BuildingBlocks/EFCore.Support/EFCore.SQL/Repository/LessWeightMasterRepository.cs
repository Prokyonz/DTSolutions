using EFCore.SQL.DBContext;
using EFCore.SQL.Interface;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCore.SQL.Repository
{
    public class LessWeightMasterRepository : ILessWeightMaster
    {
        private readonly DatabaseContext _databaseContext;

        public LessWeightMasterRepository()
        {
            _databaseContext = new DatabaseContext();
        }

        public Task<LessWeightMaster> AddLessWeightMaster(LessWeightMaster lessWeightMaster)
        {
            throw new NotImplementedException();
        }

        public Task<LessWeightMaster> DeleteLessWeightMaster(Guid lessWeightMasterId, bool isPermanantDelete = false)
        {
            throw new NotImplementedException();
        }

        public Task<List<LessWeightMaster>> GetLessWeightMasters()
        {
            throw new NotImplementedException();
        }

        public Task<LessWeightMaster> UpdateLessWeightMaster(LessWeightMaster lessWeightMaster)
        {
            throw new NotImplementedException();
        }
    }
}
