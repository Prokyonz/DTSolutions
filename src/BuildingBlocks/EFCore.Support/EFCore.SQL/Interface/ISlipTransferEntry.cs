using EFCore.SQL.DBContext;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface ISlipTransferEntry
    {
        Task<List<SlipTransferEntry>> GetSlipTransferEntriesAsync(int Id, int SlipType, string FinancialYearId);
        Task<List<SlipTransferEntry>> AddSlipTransferEntryAsync(List<SlipTransferEntry> slipTransferEntries);
        Task<bool> UpdateSlipTransferEntryAsync(List<SlipTransferEntry> slipTransferEntries, DatabaseContext databaseContext=null);
        Task<bool> DeleteSlipTransferEntryAsync(int Id, int SlipType, string financialYearId);
        Task<long> GetMaxSrNo(int slipType, string financialYearId);
    }
}

