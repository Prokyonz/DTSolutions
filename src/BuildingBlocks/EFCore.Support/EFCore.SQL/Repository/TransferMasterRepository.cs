using EFCore.SQL.DBContext;
using EFCore.SQL.Interface;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.SQL.Repository
{
    public class TransferMasterRepository : ITransferMaster
    {
        private DatabaseContext _databaseContext;

        public TransferMasterRepository()
        {

        }

        public async Task<List<TransferMaster>> GetAllTransferAsync()
        {
            using (_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.TransferMaster.Where(s => s.IsDelete == false).ToListAsync();
            }
        }

        public async Task<TransferMaster> AddTransferAsync(TransferMaster transferMaster)
        {
            try
            {


                using (_databaseContext = new DatabaseContext())
                {
                    //_databaseContext.Database.BeginTransaction();

                    if (transferMaster.Id == null)
                        transferMaster.Id = Guid.NewGuid().ToString();

                    await _databaseContext.TransferMaster.AddAsync(transferMaster);
                    await _databaseContext.SaveChangesAsync();

                    //_databaseContext.Database.CommitTransaction();

                    return transferMaster;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> DeleteTransferAsync(string transferId, bool isPermanantDetele = false)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var gettransfer = await _databaseContext.TransferMaster.Where(s => s.Id == transferId).FirstOrDefaultAsync();
                if (gettransfer != null)
                {
                    if (isPermanantDetele)
                        _databaseContext.TransferMaster.Remove(gettransfer);
                    else
                        gettransfer.IsDelete = true;
                    await _databaseContext.SaveChangesAsync();

                    return true;
                }

                return false;
            }
        }

        public async Task<TransferMaster> UpdateTransferAsync(TransferMaster transferMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                await _databaseContext.Database.BeginTransactionAsync();
                try
                {
                    var gettransfer = await _databaseContext.TransferMaster.Where(s => s.Id == transferMaster.Id).FirstOrDefaultAsync();
                    if (gettransfer != null)
                    {
                        //gettransfer.Name = transferMaster.Name;                    
                        gettransfer.UpdatedDate = transferMaster.UpdatedDate;
                        gettransfer.UpdatedBy = transferMaster.UpdatedBy;

                        _databaseContext.TransferDetails.RemoveRange(gettransfer.TransferDetails);

                        await _databaseContext.TransferDetails.AddRangeAsync(transferMaster.TransferDetails);
                    }

                    await _databaseContext.SaveChangesAsync();

                    _databaseContext.Database.CommitTransaction();

                    return transferMaster;
                }
                catch (Exception)
                {
                    _databaseContext.Database.RollbackTransaction();
                    throw;
                }
            }
        }

        public async Task<int> GetMaxSrNoAsync(string companyId, string financialYearId)
        {
            try
            {
                using (_databaseContext = new DatabaseContext())
                {
                    var getCount = await _databaseContext.TransferMaster.Where(m => m.CompanyId == companyId && m.FinancialYearId == financialYearId).MaxAsync(m => m.JangadNo);
                    return getCount + 1;
                }
            }
            catch (Exception ex)
            {
                return 1;
            }
        }

        public async Task<List<TransferCategoryList>> GetTransferCategoryList(string companyId, string financialYearId)
        {
            try
            {
                using (_databaseContext = new DatabaseContext())
                {
                    var data = await _databaseContext.SPTransferCategoryList.FromSqlRaw($"GetTransferCategoryList '" + companyId + "', '" + financialYearId + "'").ToListAsync();

                    return data;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
