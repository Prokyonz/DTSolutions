using EFCore.SQL.DBContext;
using EFCore.SQL.Interface;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.SQL.Repository
{
    public class ApprovalPermissionMasterRepository : IApprovalPermissionMaster
    {
        public DatabaseContext databaseContext;
        public ApprovalPermissionMasterRepository()
        {

        }

        public async Task<List<ApprovalPermissionMaster>> GetPermission()
        {
            using(databaseContext = new DatabaseContext())
            {
                return await databaseContext.ApprovalPermissionMaster.ToListAsync();
            }
        }

        public async Task<List<ApprovalPermissionMaster>> UpdatePermission(List<ApprovalPermissionMaster> approvalPermissionMasters)
        {
            using (databaseContext = new DatabaseContext())
            {
                var getRecords = await databaseContext.ApprovalPermissionMaster.ToListAsync();
                if(getRecords != null)
                {
                    databaseContext.ApprovalPermissionMaster.RemoveRange(getRecords);
                }

                await databaseContext.ApprovalPermissionMaster.AddRangeAsync(approvalPermissionMasters);

                await databaseContext.SaveChangesAsync();

                return approvalPermissionMasters;
            }
        }
    }
}
