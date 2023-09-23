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
    public class BillPrintRepository : IBillPrint
    {
        public DatabaseContext databaseContext;

        public BillPrintRepository()
        {
                
        }

        public async Task<List<BillPrintModel>> GetLastRecord(string companyId, string branchId, string financialYearId)
        {
            using (databaseContext = new DatabaseContext())
            {
                int maxGroup = await databaseContext.BillPrintModel.MaxAsync(m => m.GroupId);

                var record = await databaseContext.BillPrintModel.Where(w => w.GroupId == maxGroup).ToListAsync();
                if (record.Any())
                    return record;
                else 
                    return new List<BillPrintModel>();
            }
        }

        public async Task<int> GetMaxGroupNo(string companyId, string branchId, string financialYearId)
        {
            try
            {
                using (databaseContext = new DatabaseContext())
                {
                    int maxGroup = await databaseContext.BillPrintModel.Where(w => w.CompanyId == companyId && w.BranchId == branchId && w.FinancialYearId == financialYearId).MaxAsync(m => m.GroupId);
                    return ++maxGroup;
                }
            }
            catch
            {
                return 1;
            }
        }

        public async Task<int> GetMaxsRNo()
        {
            try
            {
                using (databaseContext = new DatabaseContext())
                {
                    int maxGroup = Convert.ToInt32(await databaseContext.BillPrintModel.MaxAsync(m => m.SrNo));
                    return ++maxGroup;
                }
            }
            catch
            {
                return 1;
            }
        }

        public async Task SaveBill(BillPrintModel billPrintModel)
        {
            using (databaseContext = new DatabaseContext())
            {
                await databaseContext.BillPrintModel.AddAsync(billPrintModel);
                databaseContext.SaveChanges();
            }
        }
    }
}
