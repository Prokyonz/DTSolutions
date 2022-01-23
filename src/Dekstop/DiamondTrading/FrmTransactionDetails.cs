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
    public partial class FrmTransactionDetails : DevExpress.XtraEditors.XtraForm
    {
        private PurchaseMasterRepository _purchaseMasterRepository;
        private SalesMasterRepository _salesMasterRepository;
        private PaymentMasterRepository _paymentMasterRepository;
        private ContraEntryMasterRespository  _contraEntryMasterRespository;
        private ExpenseMasterRepository _expenseMasterRepository;
        private LoanMasterRepository _loanMasterRepository;

        private List<PurchaseMaster> _purchaseMaster;
        private List<SalesMaster> _salesMaster;

        public FrmTransactionDetails()
        {
            InitializeComponent();
            //LoadGridData();
        }

        public void ActiveTab()
        {
            HideAllTabs();
            switch (SelectedTabPage)
            {
                case "Purchase":
                    xtabPurchase.PageVisible = true;
                    xtabManager.SelectedTabPage = xtabPurchase;
                    this.Text = "Purchase Details";
                    break;
                case "Sales":
                    xtabSales.PageVisible = true;
                    xtabManager.SelectedTabPage = xtabSales;
                    this.Text = "Sales Details";
                    break;
                case "Payment":
                    xtabPayment.PageVisible = true;
                    xtabManager.SelectedTabPage = xtabPayment;
                    this.Text = "Payment Details";
                    break;
                case "Receipt":
                    xtabReceipt.PageVisible = true;
                    xtabManager.SelectedTabPage = xtabReceipt;
                    this.Text = "Receipt Details";
                    break;
                case "Contra":
                    xtabContra.PageVisible = true;
                    xtabManager.SelectedTabPage = xtabContra;
                    this.Text = "Contra Details";
                    break;
                case "Expense":
                    xtabExpense.PageVisible = true;
                    xtabManager.SelectedTabPage = xtabExpense;
                    this.Text = "Expense Details";
                    break;
                case "Loan":
                    xtabLoan.PageVisible = true;
                    xtabManager.SelectedTabPage = xtabLoan;
                    this.Text = "Loan Details";
                    break;
                case "Mixed":
                    xtabMixed.PageVisible = true;
                    xtabManager.SelectedTabPage = xtabMixed;
                    this.Text = "Mixed Report";
                    break;
                case "PurchaseSlipPrint":
                    xtabPurchaseSlipPrint.PageVisible = true;
                    xtabManager.SelectedTabPage = xtabPurchaseSlipPrint;
                    xtabPurchaseSlipPrint.Text = "Purchase Slip Details";
                    this.Text = "Purchase Slips Details";
                    break;
                case "SalesSlipPrint":
                    xtabPurchaseSlipPrint.PageVisible = true;
                    xtabManager.SelectedTabPage = xtabPurchaseSlipPrint;
                    xtabPurchaseSlipPrint.Text = "Sales Slip Details";
                    this.Text = "Sales Slips Details";
                    break;
                default:
                    xtabPurchase.PageVisible = true;
                    xtabManager.SelectedTabPage = xtabPurchase;
                    this.Text = "Purchase Details";
                    break;
            }
        }

        public string SelectedTabPage { get; set; }
        private void HideAllTabs()
        {
            xtabPurchase.PageVisible = false;
            xtabSales.PageVisible = false;
            xtabPayment.PageVisible = false;
            xtabReceipt.PageVisible = false;
            xtabContra.PageVisible = false;
            xtabExpense.PageVisible = false;
            xtabLoan.PageVisible = false;
            xtabMixed.PageVisible = false;
            xtabPurchaseSlipPrint.PageVisible = false;
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private async void accordianAddBtn_Click(object sender, EventArgs e)
        {
            if (xtabManager.SelectedTabPage == xtabPurchase)
            {
                Transaction.FrmPurchaseEntry frmPurchaseEntry = new Transaction.FrmPurchaseEntry();
                if (frmPurchaseEntry.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
            }
            else if (xtabManager.SelectedTabPage == xtabSales)
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
            if (xtabManager.SelectedTabPage == xtabPurchase)
            {
                if (IsForceLoad || _purchaseMasterRepository == null)
                {
                    _purchaseMasterRepository = new PurchaseMasterRepository();
                    var purchaseData = await _purchaseMasterRepository.GetPurchaseReport(Common.LoginCompany,Common.LoginFinancialYear);
                    grdTransactionMaster.DataSource = purchaseData.OrderBy(o=>o.SlipNo);
                }
            }
            else if (xtabManager.SelectedTabPage == xtabSales)
            {
                if (IsForceLoad || _salesMasterRepository == null)
                {
                    _salesMasterRepository = new SalesMasterRepository();
                    var salesData = await _salesMasterRepository.GetSalesReport(Common.LoginCompany, Common.LoginFinancialYear);
                    grdSalesTransactonMaster.DataSource = salesData.OrderBy(o => o.SlipNo);
                }
            } else if(xtabManager.SelectedTabPage == xtabPayment)
            {
                if(IsForceLoad || _paymentMasterRepository == null)
                {
                    _paymentMasterRepository = new PaymentMasterRepository();
                    var data = await _paymentMasterRepository.GetPaymentReport(Common.LoginCompany, Common.LoginFinancialYear, 0);
                    grdPaymentDetails.DataSource = data;
                }
            }
            else if (xtabManager.SelectedTabPage == xtabReceipt)
            {
                if (IsForceLoad || _paymentMasterRepository == null)
                {
                    _paymentMasterRepository = new PaymentMasterRepository();
                    var data = await _paymentMasterRepository.GetPaymentReport(Common.LoginCompany, Common.LoginFinancialYear, 1);
                    grdReceiptDetails.DataSource = data;
                }
            }
            else if (xtabManager.SelectedTabPage == xtabContra)
            {
                if (IsForceLoad || _paymentMasterRepository == null)
                {
                    _contraEntryMasterRespository = new ContraEntryMasterRespository();
                    var data = await _contraEntryMasterRespository.GetContraReport(Common.LoginCompany, Common.LoginFinancialYear);
                    grdContraDetails.DataSource = data;
                }
            }
            else if (xtabManager.SelectedTabPage == xtabExpense)
            {
                if (IsForceLoad || _expenseMasterRepository == null)
                {
                    _expenseMasterRepository = new ExpenseMasterRepository();
                    var data = await _expenseMasterRepository.GetExpenseReport(Common.LoginCompany, Common.LoginFinancialYear);
                    grdExpenseControl.DataSource = data;
                }
            }
            else if(xtabManager.SelectedTabPage == xtabLoan)
            {
                if (IsForceLoad || _expenseMasterRepository == null)
                {
                    _loanMasterRepository = new LoanMasterRepository();
                    var data = await _loanMasterRepository.GetLoanReportAsync(Common.LoginCompany);
                    gridControlLoan .DataSource = data;
                    gridView9.ExpandAllGroups();
                }
            }
            else if (xtabManager.SelectedTabPage == xtabMixed)
            {
                if (IsForceLoad || _paymentMasterRepository == null)
                {
                    _paymentMasterRepository = new PaymentMasterRepository();
                    var data = await _paymentMasterRepository.GetMixedReportAsync(Common.LoginCompany, Common.LoginFinancialYear);
                    gridControlMixed.DataSource = data;
                    gridView15.ExpandAllGroups();
                }
            }
            else if (xtabManager.SelectedTabPage == xtabPurchaseSlipPrint)
            {
                if (IsForceLoad || _purchaseMasterRepository == null)
                {
                    int ActionType = 1;
                    if (SelectedTabPage.Equals("SalesSlipPrint"))
                        ActionType = 2;

                    _purchaseMasterRepository = new PurchaseMasterRepository();
                    var purchaseSlipDetails = await _purchaseMasterRepository.GetAvailableSlipDetailsReport(ActionType,Common.LoginCompany, Common.LoginFinancialYear);
                    grdPurchaseSlipDetails.DataSource = purchaseSlipDetails;
                }
            }
        }

        private async void accordionEditBtn_Click(object sender, EventArgs e)
        {
            if (xtabManager.SelectedTabPage == xtabPurchase)
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
            else if (xtabManager.SelectedTabPage == xtabSales)
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
            _ = LoadGridData();
        } 

        private void accordionRefreshBtn_Click(object sender, EventArgs e)
        {
            _ = LoadGridData(true);
        }

        private async void accordionDeleteBtn_Click(object sender, EventArgs e)
        {
            if (xtabManager.SelectedTabPage == xtabPurchase)
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
            else if (xtabManager.SelectedTabPage == xtabSales)
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
            e.RelationCount = 1;
        }

        private void gridViewCompanyMaster_MasterRowGetRelationName(object sender, MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = "Child";
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void grdTransactionMaster_Click(object sender, EventArgs e)
        {

        }

        private void repoPurchaseSlipPrintBtn_Click(object sender, EventArgs e)
        {
            int ActionType = 1;
            if (SelectedTabPage.Equals("SalesSlipPrint"))
                ActionType = 2;

            string SlipNo = grvPurchaseSlipDetails.GetRowCellValue(grvPurchaseSlipDetails.FocusedRowHandle, "SlipNo").ToString();
            string FinancialYear = grvPurchaseSlipDetails.GetRowCellValue(grvPurchaseSlipDetails.FocusedRowHandle, "FinancialYearId").ToString();
            Transaction.FrmViewSlip fvs = new Transaction.FrmViewSlip(ActionType, SlipNo, FinancialYear);
            fvs.ShowDialog();

        }

        private void grvTransMaster_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hitInfo = view.CalcHitInfo(e.Point);
            if (e.HitInfo.InRow)
            {
                view.FocusedRowHandle = e.HitInfo.RowHandle;
                popupMenu1.ShowPopup(Control.MousePosition);
            }
        }

        private void grvTransMaster_GridMenuItemClick(object sender, GridMenuItemClickEventArgs e)
        {

        }

        private void btnApprove_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Transaction.FrmApproveReject frmApproveReject = new Transaction.FrmApproveReject(1);
            if(frmApproveReject.ShowDialog()==DialogResult.OK)
            {
                //frmApproveReject.Comment;
                _ = LoadGridData(true);
            }
        }

        private void btnReject_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Transaction.FrmApproveReject frmApproveReject = new Transaction.FrmApproveReject(2);
            if (frmApproveReject.ShowDialog() == DialogResult.OK)
            {
                //frmApproveReject.Comment;
                _ = LoadGridData(true);
            }
        }
    }
}