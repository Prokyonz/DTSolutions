using EFCore.SQL.DBContext;
using EFCore.SQL.Interface;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
                foreach (var item in approvalPermissionMasters)
                {
                    var getRecord = await databaseContext.ApprovalPermissionMaster.Where(w => w.Id == item.Id).FirstOrDefaultAsync();
                    if(getRecord != null)
                    {
                        getRecord.UserId = item.UserId;
                        getRecord.UpdatedDate = DateTime.Now;
                        getRecord.UpdatedBy = item.UpdatedBy;
                    }

                    await databaseContext.SaveChangesAsync();
                }

                

                return approvalPermissionMasters;
            }
        }
    }
}
