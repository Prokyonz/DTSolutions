using EFCore.SQL.Repository;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DiamondTrading.Master
{
    public partial class frmApprovalMaster : DevExpress.XtraEditors.XtraForm
    {
        ApprovalPermissionMasterRepository approvalPermissionMasterRepository = new ApprovalPermissionMasterRepository();

        List<ApprovalPermissionList> permissionlist = new List<ApprovalPermissionList>();

        PartyMasterRepository partyMasterRepository = new PartyMasterRepository();

        public frmApprovalMaster()
        {
            InitializeComponent();
        }

        private async void frmUserMaster_Load(object sender, EventArgs e)
        {
            repoUserName.DataSource = await partyMasterRepository.GetAllPartyAsync(Common.LoginCompany);
            repoUserName.DisplayMember = "Name";
            repoUserName.ValueMember = "Id";

            permissionlist.Add(new ApprovalPermissionList { DisplayName = "Purchase Approval", Name ="" });
            permissionlist.Add(new ApprovalPermissionList { DisplayName = "Sales Approval", Name ="" });
            permissionlist.Add(new ApprovalPermissionList { DisplayName = "Payment Approval", Name = "" });
            permissionlist.Add(new ApprovalPermissionList { DisplayName = "Receipt Approval", Name = "" });
            permissionlist.Add(new ApprovalPermissionList { DisplayName = "Expense Approval", Name = "" });
            permissionlist.Add(new ApprovalPermissionList { DisplayName = "Rejection In/Out Approval", Name = "" });
            permissionlist.Add(new ApprovalPermissionList { DisplayName = "Stock Transfer Approval", Name = "" });
            permissionlist.Add(new ApprovalPermissionList { DisplayName = "Slip Transfer Approval", Name = "" });

            grdPermissionDetails.DataSource = permissionlist;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            
        }

        private void frmUserMaster_KeyDown(object sender, KeyEventArgs e)
        {
            Common.MoveToNextControl(sender, e, this);
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            List<ApprovalPermissionMaster> listApprovalPermissionMasters = new List<ApprovalPermissionMaster>();
            ApprovalPermissionMaster approvalPermissionMaster;
            string TempId = Guid.NewGuid().ToString();
            for (int i = 0; i < grvPermissionDetails.RowCount; i++)
            {
                if (!string.IsNullOrWhiteSpace(grvPermissionDetails.GetRowCellValue(i, colApproverName).ToString()))
                {
                    approvalPermissionMaster = new ApprovalPermissionMaster();
                    approvalPermissionMaster.KeyName = grvPermissionDetails.GetRowCellValue(i, colApproverType).ToString();
                    approvalPermissionMaster.DisplayName = grvPermissionDetails.GetRowCellValue(i, colApproverType).ToString();
                    approvalPermissionMaster.UserId = grvPermissionDetails.GetRowCellValue(i, colApproverName).ToString();
                    listApprovalPermissionMasters.Insert(i, approvalPermissionMaster);
                }
            }

            await approvalPermissionMasterRepository.UpdatePermission(listApprovalPermissionMasters);

            MessageBox.Show("Permissions saved successfully.");
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    public class ApprovalPermissionList
    {
        public string DisplayName { get; set; }
        public string Name { get; set; }
    }
}