using EFCore.SQL.Repository;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace DiamondTrading.Master
{
    public partial class frmApprovalMaster : DevExpress.XtraEditors.XtraForm
    {
        ApprovalPermissionMasterRepository approvalPermissionMasterRepository = new ApprovalPermissionMasterRepository();

        List<ApprovalPermissionList> permissionlist = new List<ApprovalPermissionList>();

        UserMasterRepository userMasterRepository = new UserMasterRepository();

        public frmApprovalMaster()
        {
            InitializeComponent();
        }

        private async void frmUserMaster_Load(object sender, EventArgs e)
        {

            grdPermissionDetails.DataSource = LoadTempData();

            //repoUserName.DataSource = await userMasterRepository.GetAllUserAsync();
            //repoUserName.DisplayMember = "Name";
            //repoUserName.ValueMember = "Id";

            repoCheckedUseBox.DataSource = await userMasterRepository.GetAllUserAsync();
            repoCheckedUseBox.DisplayMember = "Name";
            repoCheckedUseBox.ValueMember = "Id";

            //permissionlist.Add(new ApprovalPermissionList { Id=1, DisplayName = "Purchase Approval", Name ="purchase_approval" });
            //permissionlist.Add(new ApprovalPermissionList { Id=2,DisplayName = "Sales Approval", Name ="sales_approval" });
            //permissionlist.Add(new ApprovalPermissionList { Id=3,DisplayName = "Payment Approval", Name = "payment_approval" });
            //permissionlist.Add(new ApprovalPermissionList { Id=4,DisplayName = "Receipt Approval", Name = "receipt_approval" });
            //permissionlist.Add(new ApprovalPermissionList { Id=5,DisplayName = "Expense Approval", Name = "expense_approval" });
            //permissionlist.Add(new ApprovalPermissionList { Id=6,DisplayName = "Rejection In/Out Approval", Name = "rejection_approval" });
            //permissionlist.Add(new ApprovalPermissionList { Id=7,DisplayName = "Stock Transfer Approval", Name = "stock_transfer_approval" });
            //permissionlist.Add(new ApprovalPermissionList { Id=8,DisplayName = "Slip Transfer Approval", Name = "slip_transfer_approval" });

            //grdPermissionDetails.DataSource = permissionlist;            

            LoadGridData();
        }

        private DataTable LoadTempData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("DisplayName");
            dt.Columns.Add("UserId");
            return dt;
        }

        private async void LoadGridData()
        {
            var result = await approvalPermissionMasterRepository.GetPermission();
            grdPermissionDetails.DataSource = result;
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
                    approvalPermissionMaster.Id = grvPermissionDetails.GetRowCellValue(i, colId).ToString();
                    //approvalPermissionMaster.KeyName = grvPermissionDetails.GetRowCellValue(i, colKeyName).ToString();
                    //approvalPermissionMaster.DisplayName = grvPermissionDetails.GetRowCellValue(i, colApproverType).ToString();
                    approvalPermissionMaster.UserId = grvPermissionDetails.GetRowCellValue(i, colApproverName).ToString();
                    approvalPermissionMaster.UpdatedBy = Common.LoginUserID.ToString();
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
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string Name { get; set; }
    }
}