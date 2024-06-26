﻿using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface ISizeMaster
    {
        Task<List<SizeMaster>> GetAllSizeAsync();
        Task<SizeMaster> AddSizeAsync(SizeMaster sizeMaster);
        Task<SizeMaster> UpdateSizeAsync(SizeMaster sizeMaster);
        Task<int> DeleteSizeAsync(string shapeId, bool isPermanantDetele = false);
    }
}
