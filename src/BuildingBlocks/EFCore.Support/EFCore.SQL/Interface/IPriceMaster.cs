using Repository.Entities;
using Repository.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface IPriceMaster
    {
        Task<List<PriceMaster>> GetAllPricesAsync(string companyId);
        Task<PriceMaster> AddPriceAsync(PriceMaster priceMaster);
        Task<PriceMaster> UpdatePriceAsync(PriceMaster priceMaster);
        Task<bool> DeletePriceAsync(string companyId);
        Task<List<PriceSPModel>> GetDefaultPriceList();
    }
}
