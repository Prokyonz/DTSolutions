using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface IApprovalPermissionMaster
    {
        Task<List<ApprovalPermissionMaster>> UpdatePermission(List<ApprovalPermissionMaster> approvalPermissionMasters);
        Task<List<ApprovalPermissionMaster>> GetPermission();
    }
}
