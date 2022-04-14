using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using EFCore.SQL.Repository;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiamondTrading
{
    public partial class FrmProcessDetails : DevExpress.XtraEditors.XtraForm
    {
        private KapanMappingMasterRepository _kapanMappingMasterRepository ;
        private AccountToAssortMasterRepository _accountToAssortMasterRepository ;
        private PaymentMasterRepository _paymentMasterRepository;
        private ContraEntryMasterRespository  _contraEntryMasterRespository;
        private ExpenseMasterRepository _expenseMasterRepository;
        private LoanMasterRepository _loanMasterRepository;

        private List<PurchaseMaster> _purchaseMaster;
        private List<SalesMaster> _salesMaster;

        public FrmProcessDetails()
        {
            InitializeComponent();            
        }

        public void ActiveTab()
        {
            HideAllTabs();
            switch (SelectedTabPage)
            {
                case "Kapan":
                    xtabKapanMapping.PageVisible = true;
                    xtabManager.SelectedTabPage = xtabKapanMapping;
                    this.Text = "Kapan Details";
                    break;
                case "AssortSend":
                    xtabAssortSend.PageVisible = true;
                    xtabManager.SelectedTabPage = xtabAssortSend;
                    this.Text = "Assort Send";
                    break;
                case "AssortReceive":
                    xtabAssortReceive.PageVisible = true;
                    xtabManager.SelectedTabPage = xtabAssortReceive;
                    this.Text = "Assort Receive";
                    break;
                case "Boil":
                    xtabBoilSendReceive.PageVisible = true;
                    xtabManager.SelectedTabPage = xtabBoilSendReceive;
                    this.Text = "Boil Details";
                    break;
                case "Charni":
                    xtabCjharniSendReceive.PageVisible = true;
                    xtabManager.SelectedTabPage = xtabCjharniSendReceive;
                    this.Text = "Charni Details";
                    break;
                case "Gala":
                    xtabGalaSendReceive.PageVisible = true;
                    xtabManager.SelectedTabPage = xtabGalaSendReceive;
                    this.Text = "Gala Details";
                    break;
                case "Number":
                    xtabNumberSendReceive.PageVisible = true;
                    xtabManager.SelectedTabPage = xtabNumberSendReceive;
                    this.Text = "Number Details";
                    break;
                default:
                    xtabKapanMapping.PageVisible = true;
                    xtabManager.SelectedTabPage = xtabKapanMapping;
                    this.Text = "Kapan Mapping";
                    break;
            }
        }

        public string SelectedTabPage { get; set; }
        private void HideAllTabs()
        {
            xtabKapanMapping.PageVisible = false;
            xtabAssortSend.PageVisible = false;
            xtabAssortReceive.PageVisible = false;
            xtabBoilSendReceive.PageVisible = false;
            xtabCjharniSendReceive.PageVisible = false;
            xtabGalaSendReceive.PageVisible = false;
            xtabNumberSendReceive.PageVisible = false;
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private async void accordianAddBtn_Click(object sender, EventArgs e)
        {
            if (xtabManager.SelectedTabPage == xtabKapanMapping)
            {
                Transaction.FrmPurchaseEntry frmPurchaseEntry = new Transaction.FrmPurchaseEntry();
                if (frmPurchaseEntry.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
            }
            else if (xtabManager.SelectedTabPage == xtabAssortSend)
            {
                Transaction.FrmSalesEntry frmSalesEntry= new Transaction.FrmSalesEntry();
                if (frmSalesEntry.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
            }
        }

        private async void FrmMasterDetails_Load(object sender, EventArgs e)
        {
            ActiveTab();
            await LoadGridData(true);
        }

        private async Task LoadGridData(bool IsForceLoad=false)
        {            
            if (xtabManager.SelectedTabPage == xtabKapanMapping)
            {
                if (IsForceLoad || _kapanMappingMasterRepository == null)
                {
                    _kapanMappingMasterRepository = new KapanMappingMasterRepository();
                    var kapanData = await _kapanMappingMasterRepository.GetKapanMappingReport(Common.LoginCompany,Common.LoginBranch, Common.LoginFinancialYear);
                    grdProcessMaster.DataSource = kapanData.OrderBy(o=>o.SlipNo);
                }
            }
            else if (xtabManager.SelectedTabPage == xtabAssortSend)
            {
                if (IsForceLoad || _accountToAssortMasterRepository == null)
                {
                    _accountToAssortMasterRepository = new AccountToAssortMasterRepository();
                    var salesData = await _accountToAssortMasterRepository.GetAccountToAssortSendReportAsync(Common.LoginCompany, Common.LoginBranch, Common.LoginFinancialYear, SelectedTabPage == "AssortSend" ? 0 : 1);
                    grdAssortSendReceiveMaster.DataSource = salesData.OrderBy(o => o.SlipNo);
                }
            }
            else if (xtabManager.SelectedTabPage == xtabAssortReceive)
            {
                if (IsForceLoad || _accountToAssortMasterRepository == null)
                {
                    _accountToAssortMasterRepository = new AccountToAssortMasterRepository();
                    var assortReceiveData = await _accountToAssortMasterRepository.GetAccountToAssortReceiveReportAsync(Common.LoginCompany, Common.LoginBranch, Common.LoginFinancialYear);
                    gridControlAssortReceiveMaster.DataSource = assortReceiveData.OrderBy(o => o.SlipNo);
                }
            }
            else if(xtabManager.SelectedTabPage == xtabBoilSendReceive)
            {
                if(IsForceLoad || _paymentMasterRepository == null)
                {
                    _paymentMasterRepository = new PaymentMasterRepository();
                    var data = await _paymentMasterRepository.GetPaymentReport(Common.LoginCompany, Common.LoginFinancialYear, 0);
                    grdPaymentDetails.DataSource = data;
                }
            }
            else if (xtabManager.SelectedTabPage == xtabCjharniSendReceive)
            {
                if (IsForceLoad || _paymentMasterRepository == null)
                {
                    _paymentMasterRepository = new PaymentMasterRepository();
                    var data = await _paymentMasterRepository.GetPaymentReport(Common.LoginCompany, Common.LoginFinancialYear, 1);
                    grdReceiptDetails.DataSource = data;
                }
            }
            else if (xtabManager.SelectedTabPage == xtabGalaSendReceive)
            {
                if (IsForceLoad || _paymentMasterRepository == null)
                {
                    _contraEntryMasterRespository = new ContraEntryMasterRespository();
                    var data = await _contraEntryMasterRespository.GetContraReport(Common.LoginCompany, Common.LoginFinancialYear);
                    grdContraDetails.DataSource = data;
                }
            }
            else if (xtabManager.SelectedTabPage == xtabNumberSendReceive)
            {
                if (IsForceLoad || _expenseMasterRepository == null)
                {
                    _expenseMasterRepository = new ExpenseMasterRepository();
                    var data = await _expenseMasterRepository.GetExpenseReport(Common.LoginCompany, Common.LoginFinancialYear);
                    grdExpenseControl.DataSource = data;
                }
            }
        }

        private async void accordionEditBtn_Click(object sender, EventArgs e)
        {
            if (xtabManager.SelectedTabPage == xtabKapanMapping)
            {
                ////Guid SelectedGuid = Guid.Parse(tlCompanyMaster.GetFocusedRowCellValue(Id).ToString());

                //string SelectedGuid;

                //if (grdCompanyMaster.FocusedView.DetailLevel > 0)
                //{
                //    GridView tempChild = ((GridView)grdCompanyMaster.FocusedView);
                //    SelectedGuid = tempChild.GetFocusedRowCellValue("Id").ToString();
                //} 
                //else                 
                //    SelectedGuid = grvCompanyMaster.GetFocusedRowCellValue("Id").ToString();                


                //Master.FrmCompanyMaster frmcompanymaster = new Master.FrmCompanyMaster(_companyMaster, SelectedGuid);

                //if (frmcompanymaster.ShowDialog() == DialogResult.OK)
                //{
                //    await LoadGridData(true);
                //}
            }
            else if (xtabManager.SelectedTabPage == xtabAssortSend)
            {
                //string SelectedGuid = grvBranchMaster.GetFocusedRowCellValue(colBranchId).ToString();
                //Master.FrmBranchMaster frmBranchMaster = new Master.FrmBranchMaster(_branchMaster, SelectedGuid);
                //if (frmBranchMaster.ShowDialog() == DialogResult.OK)
                //{
                //    await LoadGridData(true);
                //}
            }
        }

        private void xtabMasterDetails_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            //_ = LoadGridData();
        } 

        private void accordionRefreshBtn_Click(object sender, EventArgs e)
        {
            //_ = LoadGridData(true);
        }

        private async void accordionDeleteBtn_Click(object sender, EventArgs e)
        {
            if (xtabManager.SelectedTabPage == xtabKapanMapping)
            {
                ////Guid SelectedGuid = Guid.Parse(tlCompanyMaster.GetFocusedRowCellValue(Id).ToString());

                //string SelectedGuid;
                //string tempCompanyName = "";

                //if (grdCompanyMaster.FocusedView.DetailLevel > 0)
                //{
                //    GridView tempChild = ((GridView)grdCompanyMaster.FocusedView);
                //    SelectedGuid = tempChild.GetFocusedRowCellValue("Id").ToString();
                //    tempCompanyName = tempChild.GetFocusedRowCellValue("Name").ToString();
                //}
                //else
                //{
                //    SelectedGuid = grvCompanyMaster.GetFocusedRowCellValue("Id").ToString();
                //    tempCompanyName = grvCompanyMaster.GetFocusedRowCellValue("Name").ToString();
                //}
                //if (MessageBox.Show(string.Format(AppMessages.GetString(AppMessageID.DeleteCompanyCofirmation), tempCompanyName), "[" + this.Text + "]", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                //{
                //    var Result = await _companyMasterRepository.DeleteCompanyAsync(SelectedGuid);

                //    MessageBox.Show(AppMessages.GetString(AppMessageID.DeleteSuccessfully));
                //    await LoadGridData(true);
                //}
            }
            else if (xtabManager.SelectedTabPage == xtabAssortSend)
            {
                //string SelectedGuid = grvBranchMaster.GetFocusedRowCellValue(colBranchId).ToString();
                //if (MessageBox.Show(string.Format(AppMessages.GetString(AppMessageID.DeleteBranchCofirmation), grvBranchMaster.GetFocusedRowCellValue(colBranchName).ToString()), "[" + this.Text + "]", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                //{
                //    var Result = await _branchMasterRepository.DeleteBranchAsync(SelectedGuid);

                //    MessageBox.Show(AppMessages.GetString(AppMessageID.DeleteSuccessfully));
                //    await LoadGridData(true);
                //}
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void accordionCancelButton_Click(object sender, EventArgs e)
        {
            btnCancel_Click(sender,e);
        }

        private void gridViewCompanyMaster_MasterRowEmpty(object sender, MasterRowEmptyEventArgs e)
        {
            //GridView gridView = sender as GridView;
            //CompanyMaster companyMaster = gridView.GetRow(e.RowHandle) as CompanyMaster;
            //if (companyMaster != null)
            //{
            //    e.IsEmpty = _companyMaster.Where(w => w.Type == companyMaster.Id).Count() > 0 ? false : true;
            //}
        }

        private void gridViewCompanyMaster_MasterRowGetChildList(object sender, MasterRowGetChildListEventArgs e)
        {
            //GridView gridView = sender as GridView;
            //CompanyMaster companyMaster = gridView.GetRow(e.RowHandle) as CompanyMaster;
            //if (companyMaster != null)
            //{
            //    e.ChildList = _companyMaster.Where(w => w.Type == companyMaster.Id).ToList();
            //}
        }

        private void gridViewCompanyMaster_MasterRowGetRelationCount(object sender, MasterRowGetRelationCountEventArgs e)
        {
            //e.RelationCount = 1;
        }

        private void gridViewCompanyMaster_MasterRowGetRelationName(object sender, MasterRowGetRelationNameEventArgs e)
        {
            //e.RelationName = "Child";
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void grdTransactionMaster_Click(object sender, EventArgs e)
        {

        }

        private void repoPurchaseSlipPrintBtn_Click(object sender, EventArgs e)
        {
            //int ActionType = 1;
            //if (SelectedTabPage.Equals("SalesSlipPrint"))
            //    ActionType = 2;

            //string SlipNo = grvPurchaseSlipDetails.GetRowCellValue(grvPurchaseSlipDetails.FocusedRowHandle, "SlipNo").ToString();
            //string FinancialYear = grvPurchaseSlipDetails.GetRowCellValue(grvPurchaseSlipDetails.FocusedRowHandle, "FinancialYearId").ToString();
            //Transaction.FrmViewSlip fvs = new Transaction.FrmViewSlip(ActionType, SlipNo, FinancialYear);
            //fvs.ShowDialog();

        }

        private async void grvTransMaster_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            string ApprovalType = grvKapanMapping.GetRowCellValue(grvKapanMapping.FocusedRowHandle, "ApprovalType").ToString();
            if (ApprovalType.Equals("Pending"))
            {
                //var IsHavingApprovalPermission = Common.UserPermissionChildren.Where(x => x.KeyName.Equals("approval_master"));
                ApprovalPermissionMasterRepository approvalPermissionMasterRepository = new ApprovalPermissionMasterRepository();

                var result = await approvalPermissionMasterRepository.GetPermission();
                var IsHavingApprovalPermission = result.Where(w => w.KeyName == "purchase_approval").FirstOrDefault() ;                
                
                if (IsHavingApprovalPermission.UserId.Contains(Common.LoginUserID.ToString()))
                {
                    DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
                    DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hitInfo = view.CalcHitInfo(e.Point);
                    if (e.HitInfo.InRow)
                    {
                        view.FocusedRowHandle = e.HitInfo.RowHandle;
                        popupMenu1.ShowPopup(Control.MousePosition);
                    }
                }
            }
        }

        private void grvTransMaster_GridMenuItemClick(object sender, GridMenuItemClickEventArgs e)
        {

        }

        private async void btnApprove_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Transaction.FrmApproveReject frmApproveReject = new Transaction.FrmApproveReject(1);
            //if(frmApproveReject.ShowDialog()==DialogResult.OK)
            //{
            //    if (xtabManager.SelectedTabPage == xtabKapanMapping)
            //    {
            //        string Id = grvKapanMapping.GetRowCellValue(grvKapanMapping.FocusedRowHandle, "Id").ToString();
            //        var result = await _purchaseMasterRepository.UpdateApprovalStatus(Id, frmApproveReject.Comment, 1);
            //    }
            //    else if(xtabManager.SelectedTabPage == xtabAssortSendReceive)
            //    {
            //        string Id = grvSalesTransactonMaster.GetRowCellValue(grvSalesTransactonMaster.FocusedRowHandle, "Id").ToString();
            //        var result = await _salesMasterRepository.UpdateApprovalStatus(Id, frmApproveReject.Comment, 1);
            //    }
            //    _ = LoadGridData(true);
            //}
        }

        private async void btnReject_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Transaction.FrmApproveReject frmApproveReject = new Transaction.FrmApproveReject(2);
            //if (frmApproveReject.ShowDialog() == DialogResult.OK)
            //{
            //    if (xtabManager.SelectedTabPage == xtabKapanMapping)
            //    {
            //        string Id = grvKapanMapping.GetRowCellValue(grvKapanMapping.FocusedRowHandle, "Id").ToString();
            //        var result = await _purchaseMasterRepository.UpdateApprovalStatus(Id, frmApproveReject.Comment, 2);
            //    }
            //    else if (xtabManager.SelectedTabPage == xtabAssortSendReceive)
            //    {
            //        string Id = grvSalesTransactonMaster.GetRowCellValue(grvSalesTransactonMaster.FocusedRowHandle, "Id").ToString();
            //        var result = await _salesMasterRepository.UpdateApprovalStatus(Id, frmApproveReject.Comment, 2);
            //    }

            //    _ = LoadGridData(true);
            //}
        }

        private void grvTransMaster_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            //if (e.Column == gridColumnPurApprovalType)
            //{
            //    if (e.CellValue.ToString().Equals("0"))
            //    {
            //        e.Appearance.ForeColor = Color.FromArgb(169, 169, 169);
            //        grvKapanMapping.SetRowCellValue(e.RowHandle, "ApprovalType", "Pending");
            //    }
            //    else if (e.CellValue.ToString().Equals("1"))
            //    {
            //        e.Appearance.ForeColor = Color.Black;
            //        grvKapanMapping.SetRowCellValue(e.RowHandle, "ApprovalType", "Approved");
            //    }
            //    else if (e.CellValue.ToString().Equals("2"))
            //    {
            //        e.Appearance.ForeColor = Color.FromArgb(217, 83, 79);
            //        grvKapanMapping.SetRowCellValue(e.RowHandle, "ApprovalType", "Reject");
            //    }
            //}
            //if (e.RowHandle < 0)
            //    return;
            //string ApprovalType = grvTransMaster.GetRowCellValue(grvTransMaster.FocusedRowHandle, "ApprovalType").ToString();
            //if (Convert.ToInt32(ApprovalType) == 0)
            //    e.Appearance.ForeColor = Color.FromArgb(169, 169, 169);
            //else if (Convert.ToInt32(ApprovalType) == 2)
            //    e.Appearance.ForeColor = Color.FromArgb(217, 83, 79);
        }

        private void grvTransMaster_RowStyle(object sender, RowStyleEventArgs e)
        {
            //if (e.RowHandle < 0)
            //    return;
            //string ApprovalType = grvTransMaster.GetRowCellValue(grvTransMaster.FocusedRowHandle, "ApprovalType").ToString();
            //if (Convert.ToInt32(ApprovalType) == 0)
            //    e.Appearance.ForeColor = Color.FromArgb(169, 169, 169);
            //else if (Convert.ToInt32(ApprovalType) == 2)
            //    e.Appearance.ForeColor = Color.FromArgb(217, 83, 79);
        }

        private async void grvSalesTransactonMaster_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            //string ApprovalType = grvSalesTransactonMaster.GetRowCellValue(grvSalesTransactonMaster.FocusedRowHandle, "ApprovalType").ToString();
            //if (ApprovalType.Equals("Pending"))
            //{
            //    //var IsHavingApprovalPermission = Common.UserPermissionChildren.Where(x => x.KeyName.Equals("approval_master"));

            //    ApprovalPermissionMasterRepository approvalPermissionMasterRepository = new ApprovalPermissionMasterRepository();

            //    var result = await approvalPermissionMasterRepository.GetPermission();
            //    var IsHavingApprovalPermission = result.Where(w => w.KeyName == "sales_approval").FirstOrDefault();

            //    if (IsHavingApprovalPermission.UserId.Contains(Common.LoginUserID.ToString()))
            //    {
            //        DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            //        DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hitInfo = view.CalcHitInfo(e.Point);
            //        if (e.HitInfo.InRow)
            //        {
            //            view.FocusedRowHandle = e.HitInfo.RowHandle;
            //            popupMenu1.ShowPopup(Control.MousePosition);
            //        }
            //    }
            //}
        }

        private void grvSalesTransactonMaster_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            //if (e.Column == colSalesApprovalType)
            //{
            //    if (e.CellValue.ToString().Equals("0"))
            //    {
            //        e.Appearance.ForeColor = Color.FromArgb(169, 169, 169);
            //        grvSalesTransactonMaster.SetRowCellValue(e.RowHandle, "ApprovalType", "Pending");
            //    }
            //    else if (e.CellValue.ToString().Equals("1"))
            //    {
            //        e.Appearance.ForeColor = Color.Black;
            //        grvSalesTransactonMaster.SetRowCellValue(e.RowHandle, "ApprovalType", "Approved");
            //    }
            //    else if (e.CellValue.ToString().Equals("2"))
            //    {
            //        e.Appearance.ForeColor = Color.FromArgb(217, 83, 79);
            //        grvSalesTransactonMaster.SetRowCellValue(e.RowHandle, "ApprovalType", "Reject");
            //    }
            //}
        }
    }
}