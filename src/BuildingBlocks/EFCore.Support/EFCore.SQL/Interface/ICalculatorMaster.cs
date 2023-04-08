using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface ICalculatorMaster
    {
        Task<List<CalculatorMaster>> GetAllCalculatorAsync();
        Task<CalculatorMaster> AddCalculatorAsync(CalculatorMaster calculatorMaster);
        Task<bool> UpdateCalculatorAsync(List<CalculatorMaster> calculatorMasterEntries);
        Task<bool> DeleteCalculatorAsync(int calculatorId);
    }
}
