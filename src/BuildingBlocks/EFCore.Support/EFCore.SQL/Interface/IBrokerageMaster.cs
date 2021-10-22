using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface IBrokerageMaster
    {
        Task<List<BrokerageMaster>> GetAllBrokerageAsync();
        Task<BrokerageMaster> AddBrokerageAsync(BrokerageMaster brokerageMaster);
        Task<BrokerageMaster> UpdateBrokerageAsync(BrokerageMaster brokerageMaster);
        Task<bool> DeleteBrokerageAsync(string brokerageId, bool isPermanantDetele = false);
    }
}
