using Repository.Entities;
using Repository.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface ICalculatorMaster
    {
        Task<List<CalculatorMaster>> GetAllCalculatorAsync(string CompanyId);
        Task<CalculatorMaster> AddCalculatorAsync(CalculatorMaster calculatorMaster);
        Task<List<CalculatorMaster>> AddCalculatorListAsync(List<CalculatorMaster> calculatorMaster);
        Task<bool> UpdateCalculatorAsync(List<CalculatorMaster> calculatorMasterEntries);
        Task<bool> DeleteCalculatorAsync(int calculatorId, string branchId);
        Task<List<CalculatorSPModel>> GetCalculatorReport(string companyId, string financialYearId, string fromDate, string toDate);
        Task<List<string>> GetCalculatorMasterParties(string companyId);
        Task<List<string>> GetCalculatorMasterBrokers(string companyId);

        Task<bool> DeleteCalculatorHistoryAsync(string branchId, string companyId, string finYearId, int srNo);
    }
}