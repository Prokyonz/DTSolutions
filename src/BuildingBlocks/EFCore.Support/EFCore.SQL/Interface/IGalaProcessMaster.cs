﻿using Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface IGalaProcessMaster
    {
        Task<List<GalaProcessMaster>> GetGalaProcessAsync(string companyId, string branchId, string financialYearId, int galaProcessType);
        Task<int> GetMaxSrNoAsync(string companyId, string branchId, string financialYearId, int galaProcessType);
        Task<GalaProcessMaster> AddGalaProcessAsync(GalaProcessMaster galaProcessMaster);
        Task<GalaProcessMaster> UpdateGalaProcessAsync(GalaProcessMaster galaProcessMaster);
        Task<bool> DeleteGalaProcessAsync(string galaProcessMasterId);
    }
}