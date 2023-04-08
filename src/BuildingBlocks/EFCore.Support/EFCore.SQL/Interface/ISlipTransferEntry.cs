using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface ISlipTransferEntry
    {
        Task<List<SlipTransferEntry>> GetSlipTransferEntriesAsync(int Id);
        Task<List<SlipTransferEntry>> AddSlipTransferEntryAsync(List<SlipTransferEntry> slipTransferEntries);
        Task<bool> UpdateSlipTransferEntryAsync(List<SlipTransferEntry> slipTransferEntries);
        Task<bool> DeleteSlipTransferEntryAsync(int Id, int SlipType, string financialYearId);
        Task<long> GetMaxSrNo(int slipType, string financialYearId);
    }
}

