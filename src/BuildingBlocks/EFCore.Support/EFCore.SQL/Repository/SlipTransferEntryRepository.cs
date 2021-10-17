using EFCore.SQL.DBContext;
using EFCore.SQL.Interface;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.SQL.Repository
{
    public class SlipTransferEntryRepository : ISlipTransferEntry, IDisposable
    {
        private readonly DatabaseContext _databaseContext;

        public SlipTransferEntryRepository()
        {
            _databaseContext = new DatabaseContext();
        }
        public async Task<List<SlipTransferEntry>> AddSlipTransferEntryAsync(List<SlipTransferEntry> slipTransferEntries)
        {
            foreach (var item in slipTransferEntries)
            {
                if (item.Id != null)
                {
                    item.Id = Guid.NewGuid();
                }
            }

            await _databaseContext.SlipTransferEntry.AddRangeAsync(slipTransferEntries);
            await _databaseContext.SaveChangesAsync();
            return slipTransferEntries;
        }

        public async Task<bool> DeleteSlipTransferEntryAsync(Guid purchaseId)
        {
            var slipEntry = await _databaseContext.SlipTransferEntry.Where(w => w.PurchaseMasterId == purchaseId).ToListAsync();
            _databaseContext.SlipTransferEntry.RemoveRange(slipEntry);
            await _databaseContext.SaveChangesAsync();
            return true;
        }

        public void Dispose()
        {
            _databaseContext.DisposeAsync();
        }

        public async Task<List<SlipTransferEntry>> GetSlipTransferEntriesAsync(Guid purchaseId)
        {
            return await _databaseContext.SlipTransferEntry.Where(w => w.PurchaseMasterId == purchaseId).ToListAsync();
        }

        public async Task<bool> UpdateSlipTransferEntryAsync(List<SlipTransferEntry> slipTransferEntries)
        {
            if (slipTransferEntries.Count > 0)
            {
                var slipEntry = await _databaseContext.SlipTransferEntry.Where(w => w.PurchaseMasterId == slipTransferEntries[0].PurchaseMasterId).ToListAsync();
                _databaseContext.SlipTransferEntry.RemoveRange(slipEntry);

                //Add New updated records to the database

                await _databaseContext.SlipTransferEntry.AddRangeAsync(slipEntry);

                await _databaseContext.SaveChangesAsync();
                
                return true;
            }
            return false;
        }
    }
}
