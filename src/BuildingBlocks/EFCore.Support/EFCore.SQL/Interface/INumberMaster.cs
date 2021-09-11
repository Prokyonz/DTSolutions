using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface INumberMaster
    {
        Task<List<NumberMaster>> GetAllNumberAsync();
        Task<NumberMaster> AddNumberAsync(NumberMaster numberMaster);
        Task<NumberMaster> UpdateNumberAsync(NumberMaster numberMaster);
        Task<bool> DeleteNumberAsync(Guid numberId, bool isPermanantDetele = false);
    }
}
