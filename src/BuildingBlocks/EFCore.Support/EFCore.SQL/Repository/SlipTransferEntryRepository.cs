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
    public class SlipTransferEntryRepository : ISlipTransferEntry
    {
        private DatabaseContext _databaseContext;

        public SlipTransferEntryRepository()
        {

        }
        public async Task<List<SlipTransferEntry>> AddSlipTransferEntryAsync(List<SlipTransferEntry> slipTransferEntries)
        {
            using (_databaseContext = new DatabaseContext())
            {
                foreach (var item in slipTransferEntries)
                {
                    if (item.Id != null)
                    {
                        item.Id = Guid.NewGuid().ToString();
                    }
                }

                await _databaseContext.SlipTransferEntry.AddRangeAsync(slipTransferEntries);
                await _databaseContext.SaveChangesAsync();
                return slipTransferEntries;
            }
        }

        public async Task<bool> DeleteSlipTransferEntryAsync(int Id)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var slipEntry = await _databaseContext.SlipTransferEntry.Where(w => w.Sr == Id).ToListAsync();
                _databaseContext.SlipTransferEntry.RemoveRange(slipEntry);
                await _databaseContext.SaveChangesAsync();
                return true;
            }
        }

        public async Task<List<SlipTransferEntry>> GetSlipTransferEntriesAsync(int Id)
        {
            using (_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.SlipTransferEntry.Where(w => w.Sr == Id).ToListAsync();
            }
        }

        public async Task<bool> UpdateSlipTransferEntryAsync(List<SlipTransferEntry> slipTransferEntries)
        {
            using (_databaseContext = new DatabaseContext())
            {
                if (slipTransferEntries.Count > 0)
                {
                    var slipEntry = await _databaseContext.SlipTransferEntry.Where(w => w.Sr == slipTransferEntries[0].Sr).ToListAsync();
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
}
