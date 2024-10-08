﻿using EFCore.SQL.DBContext;
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

        public async Task<bool> DeleteSlipTransferEntryAsync(int Id, int SlipType, string financialYearId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var slipEntry = await _databaseContext.SlipTransferEntry.Where(w => w.SrNo == Id && w.SlipType == SlipType && w.FinancialYearId == financialYearId).ToListAsync();
                _databaseContext.SlipTransferEntry.RemoveRange(slipEntry);
                await _databaseContext.SaveChangesAsync();
                return true;
            }
        }

        public async Task<List<SlipTransferEntry>> GetSlipTransferEntriesAsync(int Id, int SlipType, string FinancialYearId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.SlipTransferEntry.Where(w => w.SrNo == Id && w.SlipType == SlipType && w.FinancialYearId == FinancialYearId).ToListAsync();
            }
        }

        public async Task<bool> UpdateSlipTransferEntryAsync(List<SlipTransferEntry> slipTransferEntries, DatabaseContext _databaseContext = null)
        {
            if(_databaseContext != null)
            {
                return await UpdateSlipTransferEntry(slipTransferEntries, _databaseContext);
            }
            else
            {
                using (_databaseContext = new DatabaseContext())
                {
                    return await UpdateSlipTransferEntry(slipTransferEntries, _databaseContext);
                }
            }
        }

        private async Task<bool> UpdateSlipTransferEntry(List<SlipTransferEntry> slipTransferEntries, DatabaseContext _databaseContext)
        {
            if (slipTransferEntries.Count > 0)
            {
                var slipEntry = await _databaseContext.SlipTransferEntry.Where(w => w.SrNo == slipTransferEntries[0].SrNo && w.SlipType == slipTransferEntries[0].SlipType && w.FinancialYearId == slipTransferEntries[0].FinancialYearId).ToListAsync();
                _databaseContext.SlipTransferEntry.RemoveRange(slipEntry);

                //Add New updated records to the database

                await _databaseContext.SlipTransferEntry.AddRangeAsync(slipTransferEntries);

                await _databaseContext.SaveChangesAsync();

                return true;
            }
            return false;
        }

        public async Task<long> GetMaxSrNo(int slipType, string financialYearId)
        {
            try
            {
                using (_databaseContext = new DatabaseContext())
                {
                    var result = await _databaseContext.SlipTransferEntry.Where(w => w.SlipType == slipType && w.FinancialYearId == financialYearId).MaxAsync(m => m.SrNo);
                    return result + 1;
                }
            }
            catch (Exception ex)
            {
                return 1;
            }
        }
    }
}
