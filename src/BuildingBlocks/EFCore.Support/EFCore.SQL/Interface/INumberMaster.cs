using Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface INumberMaster
    {
        Task<List<NumberMaster>> GetAllGalaAsync();
        Task<NumberMaster> AddNumberAsync(NumberMaster numberMaster);
        Task<NumberMaster> UpdateNumberAsync(NumberMaster numberMaster);
        Task<bool> DeleteNumberAsync(int numberId, bool isPermanantDetele = false);
    }
}
