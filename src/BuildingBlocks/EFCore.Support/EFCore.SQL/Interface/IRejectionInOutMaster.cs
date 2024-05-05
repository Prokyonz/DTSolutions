using Repository.Entities;
using Repository.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface IRejectionInOutMaster
    {
        Task<int> GetMaxSrNoAsync(string companyId, string financialYearId, int transType);

        Task<List<RejectionInOutMaster>> GetAllRejectionInAsync(string companyId, string financialYearId);
        Task<List<RejectionInOutMaster>> GetAllRejectionOutAsync(string companyId, string financialYearId);
        Task<RejectionInOutMaster> AddRejectionAsync(RejectionInOutMaster priceMaster);
        Task<RejectionInOutMaster> UpdateRejectionAsync(RejectionInOutMaster priceMaster);
        Task<bool> DeleteRejectionAsync(string priceId);
        Task<List<RejectionSendReceiveSPModel>> GetRejectionSendReceiveDetail(string companyId, string financialYearId, int TransType = 0);
        Task<List<RejectionInOutSPModel>> GetRejectionSendReceiveReport(string companyId, string financialYearId, int TransType);
    }
}
