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
        Task<List<PriceMaster>> GetAllPricesAsync(string companyId, string categoryId);
        Task<PriceMaster> GetPricesAsync(string companyId, string categoryId, string SizeId, string NumberId);
        Task<List<PriceMaster>> AddPriceAsync(List<PriceMaster> priceMaster);
        Task<PriceMaster> UpdatePriceAsync(PriceMaster priceMaster);
        Task<bool> DeletePriceAsync(string companyId, string categoryId);
        Task<List<PriceSPModel>> GetDefaultPriceList();
    }

    public interface IPriceMasterMobile
    {
        Task<List<PriceMasterMobile>> GetAllPricesAsync(string companyId, string categoryId);
        Task<PriceMasterMobile> GetPricesAsync(string companyId, string categoryId, string SizeId, string NumberId);
        Task<List<PriceMasterMobile>> AddPriceAsync(List<PriceMasterMobile> priceMaster);
        Task<PriceMasterMobile> UpdatePriceAsync(PriceMasterMobile priceMaster);
        Task<bool> DeletePriceAsync(string companyId, string categoryId);
        Task<List<PriceSPModel>> GetDefaultPriceList();
        Task<List<string>> GetAllSizesAsync();
        Task<List<string>> GetAllNumberAsync();
    }
}
