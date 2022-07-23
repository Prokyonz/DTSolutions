using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using EFCore.SQL.Repository;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        private ContraEntryMasterRespository _contraEntryMasterRespository;
        private ExpenseMasterRepository _expenseMasterRepository;
        private LoanMasterRepository _loanMasterRepository;
        private JangadMasterRepository _JangadMasterRepository;
        private PartyMasterRepository _partyMasterRepository;

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
                    accordionDeleteBtn.Visible = false;
                    accordionEditBtn.Visible = false;
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
                case "JangadSend":
                    xtabJangadSendReceive.PageVisible = true;
                    xtabManager.SelectedTabPage = xtabJangadSendReceive;
                    xtabJangadSendReceive.Text = "Jangad Send";
                    this.Text = "Jangad Send";
                    break;
                case "JangadReceive":
                    xtabJangadSendReceive.PageVisible = true;
                    xtabManager.SelectedTabPage = xtabJangadSendReceive;
                    xtabJangadSendReceive.Text = "Jangad Receive";
                    this.Text = "Jangad Receive";
                    break;
                case "PFReport":
                    xtraTabPFReport.PageVisible = true;
                    xtabManager.SelectedTabPage = xtraTabPFReport;
                    xtraTabPFReport.Text = "PF Report";
                    this.Text = "PF Report";
                    break;
                case "LedgerReport":
                    xtraTabLedgerBalance.PageVisible = true;
                    xtabManager.SelectedTabPage = xtraTabLedgerBalance;
                    xtraTabLedgerBalance.Text = "Ledger Report";
                    this.Text = "Ledger Report";
                    break;
                case "WeeklyPurchaseReport":
                    xtabWeeklyPurchaseReport.PageVisible = true;
                    xtabManager.SelectedTabPage = xtabWeeklyPurchaseReport;
                    xtabWeeklyPurchaseReport.Text = "Weekly Purchase Report";
                    this.Text = "Weekly Purchase Report";
                    break;
                case "Payable":
                    xtraTabPayableReceivable.PageVisible = true;
                    xtabManager.SelectedTabPage = xtraTabPayableReceivable;
                    xtraTabPayableReceivable.Text = "Payable Report";
                    this.Text = "Payable Report";
                    break;
                case "Receivable":
                    xtraTabPayableReceivable.PageVisible = true;
                    xtabManager.SelectedTabPage = xtraTabPayableReceivable;
                    xtraTabPayableReceivable.Text = "Receivable Report";
                    this.Text = "Receivable Report";
                    break;
                case "BalanceSheet":
                    xtraTabBalanceSheet.PageVisible = true;
                    xtabManager.SelectedTabPage = xtraTabBalanceSheet;
                    xtraTabBalanceSheet.Text = "Balance Sheet";
                    this.Text = "Balance Sheet";
                    break;
                case "ProfitLoss":
                    xtraTabProfitLoss.PageVisible = true;
                    xtabManager.SelectedTabPage = xtraTabProfitLoss;
                    xtraTabProfitLoss.Text = "Profit & Loss";
                    this.Text = "Balance Sheet";
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
            xtabJangadSendReceive.PageVisible = false;
            xtraTabPFReport.PageVisible = false;
            xtraTabLedgerBalance.PageVisible = false;
            xtabWeeklyPurchaseReport.PageVisible = false;
            xtraTabPayableReceivable.PageVisible = false;
            xtraTabBalanceSheet.PageVisible = false;
            xtraTabProfitLoss.PageVisible = false;
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
                Transaction.FrmSalesEntry frmSalesEntry = new Transaction.FrmSalesEntry();
                if (frmSalesEntry.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
            }
        }

        private async void FrmMasterDetails_Load(object sender, EventArgs e)
        {
            lueProfitLossType.Properties.DataSource = Common.GetBalanceSheetType;
            lueProfitLossType.Properties.DisplayMember = "Name";
            lueProfitLossType.Properties.ValueMember = "Id";
            lueProfitLossType.EditValue = 2;

            lueBalanceSheetType.Properties.DataSource = Common.GetBalanceSheetType;
            lueBalanceSheetType.Properties.DisplayMember = "Name";
            lueBalanceSheetType.Properties.ValueMember = "Id";
            lueBalanceSheetType.EditValue = 2;


            ActiveTab();
            await LoadGridData(true);
        }

        private async Task LoadGridData(bool IsForceLoad = false)
        {
            if (xtabManager.SelectedTabPage == xtabPurchase)
            {
                if (IsForceLoad || _purchaseMasterRepository == null)
                {
                    _purchaseMasterRepository = new PurchaseMasterRepository();
                    var purchaseData = await _purchaseMasterRepository.GetPurchaseReport(Common.LoginCompany, Common.LoginFinancialYear);
                    grdTransactionMaster.DataSource = purchaseData.OrderBy(o => o.SlipNo);
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
            }
            else if (xtabManager.SelectedTabPage == xtabPayment)
            {
                if (IsForceLoad || _paymentMasterRepository == null)
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
            else if (xtabManager.SelectedTabPage == xtabLoan)
            {
                if (IsForceLoad || _expenseMasterRepository == null)
                {
                    _loanMasterRepository = new LoanMasterRepository();
                    var data = await _loanMasterRepository.GetLoanReportAsync(Common.LoginCompany);
                    gridControlLoan.DataSource = data;
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
                    var purchaseSlipDetails = await _purchaseMasterRepository.GetAvailableSlipDetailsReport(ActionType, Common.LoginCompany, Common.LoginFinancialYear);
                    grdPurchaseSlipDetails.DataSource = purchaseSlipDetails;
                }
            }
            else if (xtabManager.SelectedTabPage == xtabJangadSendReceive)
            {
                if (IsForceLoad || _JangadMasterRepository == null)
                {
                    int ActionType = 1;
                    if (SelectedTabPage.Equals("JangadSend"))
                        ActionType = 2;

                    _JangadMasterRepository = new JangadMasterRepository();
                    var data = await _JangadMasterRepository.GetJangadReport(Common.LoginCompany, Common.LoginFinancialYear, ActionType);
                    gridControlJangadSendReceive.DataSource = data;
                }
            }
            else if (xtabManager.SelectedTabPage == xtraTabPFReport)
            {
                if (IsForceLoad || _purchaseMasterRepository == null)
                {
                    _purchaseMasterRepository = new PurchaseMasterRepository();
                    var data = await _purchaseMasterRepository.GetPFReportAsync(Common.LoginCompany, Common.LoginFinancialYear, 1);
                    gridControlPFReport.DataSource = data;
                }
            }
            else if (xtabManager.SelectedTabPage == xtraTabLedgerBalance)
            {
                if (IsForceLoad || _partyMasterRepository == null)
                {
                    _partyMasterRepository = new PartyMasterRepository();
                    var data = await _partyMasterRepository.GetLedgerReport(Common.LoginCompany, Common.LoginFinancialYear);
                    gridControlLedgerReport.DataSource = data;
                }
            }
            else if (xtabManager.SelectedTabPage == xtabWeeklyPurchaseReport)
            {
                if (IsForceLoad || _purchaseMasterRepository == null)
                {
                    _purchaseMasterRepository = new PurchaseMasterRepository();
                    var data = await _purchaseMasterRepository.GetWeeklyPurchaseReportAsync(Common.LoginCompany, Common.LoginFinancialYear);
                    grdWeeklyPurchaseReport.DataSource = data;

                    System.Globalization.CultureInfo CI = new System.Globalization.CultureInfo("en-US");
                    System.Globalization.Calendar Cal = CI.Calendar;
                    // first week of year
                    System.Globalization.CalendarWeekRule CWR = CI.DateTimeFormat.CalendarWeekRule;
                    // first day of week
                    DayOfWeek FirstDOW = CI.DateTimeFormat.FirstDayOfWeek;
                    // to get the current week number
                    int week = Cal.GetWeekOfYear(DateTime.Now, CWR, FirstDOW);

                    int rowHandle = grvWeeklyPurchaseReport.LocateByValue("WeekNo", week.ToString());
                    if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                    {
                        grvWeeklyPurchaseReport.FocusedRowHandle = rowHandle;
                        grvWeeklyPurchaseReport.SelectRow(rowHandle);
                    }

                    string SelectedWeek = "Week: " + grvWeeklyPurchaseReport.GetRowCellValue(grvWeeklyPurchaseReport.FocusedRowHandle, colPeriod).ToString();

                    await DisplayCurrentWeekPurchaseData(week.ToString(), SelectedWeek);

                }
            }
            else if (xtabManager.SelectedTabPage == xtraTabPayableReceivable)
            {
                if (IsForceLoad || _paymentMasterRepository == null)
                {
                    _paymentMasterRepository = new PaymentMasterRepository();
                    var data = await _paymentMasterRepository.GetPayableReceivalbeReport(Common.LoginCompany, Common.LoginFinancialYear, SelectedTabPage == "Payable" ? 0 : 1);
                    gridControlPayableReceivable.DataSource = data;
                }
            }
            else if (xtabManager.SelectedTabPage == xtraTabBalanceSheet)
            {
                if (IsForceLoad || _paymentMasterRepository == null)
                {
                    _paymentMasterRepository = new PaymentMasterRepository();
                    var data = await _paymentMasterRepository.GetBalanceSheetReportAsync(Common.LoginCompany, Common.LoginFinancialYear, Convert.ToInt32(lueBalanceSheetType.EditValue));
                    gridControlBalanceSheet.DataSource = data;
                }
            }
            else if (xtabManager.SelectedTabPage == xtraTabProfitLoss)
            {
                if (IsForceLoad || _paymentMasterRepository == null)
                {
                    _paymentMasterRepository = new PaymentMasterRepository();
                    var data = await _paymentMasterRepository.GetProfitLossReportAsync(Common.LoginCompany, Common.LoginFinancialYear, Convert.ToInt32(lueProfitLossType.EditValue));
                    gridControlProfitLoss.DataSource = data;
                }
            }
        }

        private async void accordionEditBtn_Click(object sender, EventArgs e)
        {
            if (xtabManager.SelectedTabPage == xtabPurchase)
            {

                string SelectedGuid = grvTransMaster.GetFocusedRowCellValue("PurId").ToString();

                Transaction.FrmPurchaseEntry frmPurchaseEntry = new Transaction.FrmPurchaseEntry(SelectedGuid);

                if (frmPurchaseEntry.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
            }
            else if (xtabManager.SelectedTabPage == xtabSales)
            {
                string SelectedGuid = grvSalesTransactonMaster.GetFocusedRowCellValue("Id").ToString();

                Transaction.FrmSalesEntry frmSalesEntry = new Transaction.FrmSalesEntry(SelectedGuid);

                if (frmSalesEntry.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
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
                if (MessageBox.Show(string.Format(AppMessages.GetString(AppMessageID.DleteExpenseConfirmation), "Do you want to delete this record?"), "[" + this.Text + "]", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    string id = grvTransMaster.GetFocusedRowCellValue(gridColumnPurId).ToString();
                    string kapanId = grvTransMaster.GetFocusedRowCellValue(gridColumnPurKapanId).ToString();

                    if (string.IsNullOrEmpty(kapanId))
                    {
                        bool result = await _purchaseMasterRepository.DeletePurchaseAsync(id, false);

                        MessageBox.Show(AppMessages.GetString(AppMessageID.DeleteSuccessfully));
                    }
                    else
                    {
                        MessageBox.Show("You can not delete this record because it is mapped with kapan.");
                    }
                }
            }
            else if (xtabManager.SelectedTabPage == xtabSales)
            {
                if (MessageBox.Show(string.Format(AppMessages.GetString(AppMessageID.DleteExpenseConfirmation), "Do you want to delete this record?"), "[" + this.Text + "]", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    string id = grvSalesTransactonMaster.GetFocusedRowCellValue(gridColumnSalesId).ToString();

                    bool result = await _salesMasterRepository.DeleteSalesAsync(id, false);

                    MessageBox.Show(AppMessages.GetString(AppMessageID.DeleteSuccessfully));
                }
            }
            else if (xtabManager.SelectedTabPage == xtabExpense)
            {
                if (MessageBox.Show(string.Format(AppMessages.GetString(AppMessageID.DleteExpenseConfirmation), "Do you want to delete this record?"), "[" + this.Text + "]", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    string id = grvExpenseMaster.GetFocusedRowCellValue(gridColumnExpenseIdCol).ToString();

                    bool result = await _expenseMasterRepository.DeleteExpenseAsync(id, true);

                    MessageBox.Show(AppMessages.GetString(AppMessageID.DeleteSuccessfully));
                }
            }
            else if (xtabManager.SelectedTabPage == xtabContra)
            {
                if (MessageBox.Show(string.Format(AppMessages.GetString(AppMessageID.DleteExpenseConfirmation), "Do you want to delete this record?"), "[" + this.Text + "]", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    string id = gridView5.GetFocusedRowCellValue(gridColumnContraId).ToString();

                    bool result = await _contraEntryMasterRespository.DeleteContraEntryAsync(id);

                    MessageBox.Show(AppMessages.GetString(AppMessageID.DeleteSuccessfully));
                }
            }
            else if (xtabManager.SelectedTabPage == xtabReceipt)
            {
                if (MessageBox.Show(string.Format(AppMessages.GetString(AppMessageID.DleteExpenseConfirmation), "Do you want to delete this record?"), "[" + this.Text + "]", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    string id = gridView7.GetFocusedRowCellValue(gridColumnReceiptGroupId).ToString();

                    bool result = await _paymentMasterRepository.DeletePaymentAsync(id);

                    MessageBox.Show(AppMessages.GetString(AppMessageID.DeleteSuccessfully));
                }
            }
            else if (xtabManager.SelectedTabPage == xtabPayment)
            {
                if (MessageBox.Show(string.Format(AppMessages.GetString(AppMessageID.DleteExpenseConfirmation), "Do you want to delete this record?"), "[" + this.Text + "]", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    string id = gridView4.GetFocusedRowCellValue(gridColumnGroupId).ToString();

                    bool result = await _paymentMasterRepository.DeletePaymentAsync(id);

                    MessageBox.Show(AppMessages.GetString(AppMessageID.DeleteSuccessfully));
                }
            }
            else if (xtabManager.SelectedTabPage == xtabLoan)
            {
                if (MessageBox.Show(string.Format(AppMessages.GetString(AppMessageID.DleteExpenseConfirmation), "Do you want to delete this record?"), "[" + this.Text + "]", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    string id = gridView9.GetFocusedRowCellValue(gridColumnLoanId).ToString();

                    bool result = await _loanMasterRepository.DeleteLoanAsync(id);

                    MessageBox.Show(AppMessages.GetString(AppMessageID.DeleteSuccessfully));
                }
            }
            await LoadGridData(true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void accordionCancelButton_Click(object sender, EventArgs e)
        {
            btnCancel_Click(sender, e);
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

        private async void grvTransMaster_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            string ApprovalType = grvTransMaster.GetRowCellValue(grvTransMaster.FocusedRowHandle, "ApprovalType").ToString();
            if (ApprovalType.Equals("Pending"))
            {
                //var IsHavingApprovalPermission = Common.UserPermissionChildren.Where(x => x.KeyName.Equals("approval_master"));
                ApprovalPermissionMasterRepository approvalPermissionMasterRepository = new ApprovalPermissionMasterRepository();

                var result = await approvalPermissionMasterRepository.GetPermission();
                var IsHavingApprovalPermission = result.Where(w => w.KeyName == "purchase_approval").FirstOrDefault();

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
            Transaction.FrmApproveReject frmApproveReject = new Transaction.FrmApproveReject(1);
            if (frmApproveReject.ShowDialog() == DialogResult.OK)
            {
                if (xtabManager.SelectedTabPage == xtabPurchase)
                {
                    string Id = grvTransMaster.GetRowCellValue(grvTransMaster.FocusedRowHandle, "PurId").ToString();
                    var result = await _purchaseMasterRepository.UpdateApprovalStatus(Id, frmApproveReject.Comment, 1);
                }
                else if (xtabManager.SelectedTabPage == xtabSales)
                {
                    string Id = grvSalesTransactonMaster.GetRowCellValue(grvSalesTransactonMaster.FocusedRowHandle, "Id").ToString();
                    var result = await _salesMasterRepository.UpdateApprovalStatus(Id, frmApproveReject.Comment, 1);
                }
                _ = LoadGridData(true);
            }
        }

        private async void btnReject_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Transaction.FrmApproveReject frmApproveReject = new Transaction.FrmApproveReject(2);
            if (frmApproveReject.ShowDialog() == DialogResult.OK)
            {
                if (xtabManager.SelectedTabPage == xtabPurchase)
                {
                    string Id = grvTransMaster.GetRowCellValue(grvTransMaster.FocusedRowHandle, "PurId").ToString();
                    var result = await _purchaseMasterRepository.UpdateApprovalStatus(Id, frmApproveReject.Comment, 2);
                }
                else if (xtabManager.SelectedTabPage == xtabSales)
                {
                    string Id = grvSalesTransactonMaster.GetRowCellValue(grvSalesTransactonMaster.FocusedRowHandle, "Id").ToString();
                    var result = await _salesMasterRepository.UpdateApprovalStatus(Id, frmApproveReject.Comment, 2);
                }

                _ = LoadGridData(true);
            }
        }

        private void grvTransMaster_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.Column == gridColumnPurApprovalType)
            {
                if (e.CellValue.ToString().Equals("0"))
                {
                    e.Appearance.ForeColor = Color.FromArgb(169, 169, 169);
                    grvTransMaster.SetRowCellValue(e.RowHandle, "ApprovalType", "Pending");
                }
                else if (e.CellValue.ToString().Equals("1"))
                {
                    e.Appearance.ForeColor = Color.Black;
                    grvTransMaster.SetRowCellValue(e.RowHandle, "ApprovalType", "Approved");
                }
                else if (e.CellValue.ToString().Equals("2"))
                {
                    e.Appearance.ForeColor = Color.FromArgb(217, 83, 79);
                    grvTransMaster.SetRowCellValue(e.RowHandle, "ApprovalType", "Reject");
                }
            }
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
            string ApprovalType = grvSalesTransactonMaster.GetRowCellValue(grvSalesTransactonMaster.FocusedRowHandle, "ApprovalType").ToString();
            if (ApprovalType.Equals("Pending"))
            {
                //var IsHavingApprovalPermission = Common.UserPermissionChildren.Where(x => x.KeyName.Equals("approval_master"));

                ApprovalPermissionMasterRepository approvalPermissionMasterRepository = new ApprovalPermissionMasterRepository();

                var result = await approvalPermissionMasterRepository.GetPermission();
                var IsHavingApprovalPermission = result.Where(w => w.KeyName == "sales_approval").FirstOrDefault();

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

        private void grvSalesTransactonMaster_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.Column == colSalesApprovalType)
            {
                if (e.CellValue.ToString().Equals("0"))
                {
                    e.Appearance.ForeColor = Color.FromArgb(169, 169, 169);
                    grvSalesTransactonMaster.SetRowCellValue(e.RowHandle, "ApprovalType", "Pending");
                }
                else if (e.CellValue.ToString().Equals("1"))
                {
                    e.Appearance.ForeColor = Color.Black;
                    grvSalesTransactonMaster.SetRowCellValue(e.RowHandle, "ApprovalType", "Approved");
                }
                else if (e.CellValue.ToString().Equals("2"))
                {
                    e.Appearance.ForeColor = Color.FromArgb(217, 83, 79);
                    grvSalesTransactonMaster.SetRowCellValue(e.RowHandle, "ApprovalType", "Reject");
                }
            }
        }

        private void repositoryJangadPrintReport_Click(object sender, EventArgs e)
        {

        }

        private void repositoryJangadPrintReport_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //string sr = grvJangadSendReceive.GetRowCellValue(grvJangadSendReceive.FocusedRowHandle, "Sr").ToString();
            string srNo = grvJangadSendReceive.GetRowCellValue(grvJangadSendReceive.FocusedRowHandle, "SrNo").ToString();
            string FinancialYear = grvJangadSendReceive.GetRowCellValue(grvJangadSendReceive.FocusedRowHandle, "FinancialYearId").ToString();

            int ActionType = 1;
            if (SelectedTabPage.Equals("JangadSend"))
                ActionType = 2;

            Utility.FrmViewJangad fvj = new Utility.FrmViewJangad(srNo, FinancialYear, Common.LoginCompany, ActionType);
            fvj.ShowDialog();
        }

        private void grvJangadSendReceive_CellMerge(object sender, CellMergeEventArgs e)
        {
            GridView view = sender as GridView;
            int id1 = Convert.ToInt32(view.GetRowCellValue(e.RowHandle1, view.Columns["SrNo"]));
            int id2 = Convert.ToInt32(view.GetRowCellValue(e.RowHandle2, view.Columns["SrNo"]));
            if (id1 != id2)
            {
                e.Merge = false;
                e.Handled = true;
            }
        }

        private void grvTransMaster_CellMerge(object sender, CellMergeEventArgs e)
        {
            GridView view = sender as GridView;
            int id1 = Convert.ToInt32(view.GetRowCellValue(e.RowHandle1, view.Columns["SlipNo"]));
            int id2 = Convert.ToInt32(view.GetRowCellValue(e.RowHandle2, view.Columns["SlipNo"]));
            if (id1 != id2)
            {
                e.Merge = false;
                e.Handled = true;
            }
        }

        private void grvSalesTransactonMaster_CellMerge(object sender, CellMergeEventArgs e)
        {
            GridView view = sender as GridView;
            int id1 = Convert.ToInt32(view.GetRowCellValue(e.RowHandle1, view.Columns["SlipNo"]));
            int id2 = Convert.ToInt32(view.GetRowCellValue(e.RowHandle2, view.Columns["SlipNo"]));
            if (id1 != id2)
            {
                e.Merge = false;
                e.Handled = true;
            }
        }

        private async void grvWeeklyPurchaseReport_RowClick(object sender, RowClickEventArgs e)
        {
            if (e.Clicks == 2)
            {
                string CurrentWeek = grvWeeklyPurchaseReport.GetRowCellValue(grvWeeklyPurchaseReport.FocusedRowHandle, colWeekNo).ToString();
                //Reports.FrmWeeklyPurchaseDetailReport frmWeeklyPurchaseDetailReport = new Reports.FrmWeeklyPurchaseDetailReport(CurrentWeek);
                //frmWeeklyPurchaseDetailReport.ShowDialog();
                string SelectedWeek = "Week: " + grvWeeklyPurchaseReport.GetRowCellValue(grvWeeklyPurchaseReport.FocusedRowHandle, colPeriod).ToString();

                await DisplayCurrentWeekPurchaseData(CurrentWeek, SelectedWeek);
            }
        }

        private async Task DisplayCurrentWeekPurchaseData(string CurrentWeek, string SelectedWeek)
        {
            this.Cursor = Cursors.WaitCursor;
            grvWeeklyPurchaseDetails.ViewCaption = SelectedWeek;

            PurchaseMasterRepository purchaseMasterRepository = new PurchaseMasterRepository();
            var purchaseData = await purchaseMasterRepository.GetPurchaseReport(Common.LoginCompany, Common.LoginFinancialYear, CurrentWeek);
            grdWeeklyPurchaseDetails.DataSource = purchaseData.OrderBy(o => o.SlipNo);
            this.Cursor = Cursors.Default;
        }

        private void lueBalanceSheetType_EditValueChanged(object sender, EventArgs e)
        {
            _ = LoadGridData(true);
        }

        private void lueProfitLossType_EditValueChanged(object sender, EventArgs e)
        {
            _ = LoadGridData(true);
        }

        private async void repositoryItemButtonEdit7_Click(object sender, EventArgs e)
        {
            string PurchaseId = grvTransMaster.GetRowCellValue(grvTransMaster.FocusedRowHandle, colPurImage).ToString();

            PurchaseMaster _editedPurchaseMaster = await _purchaseMasterRepository.GetPurchaseAsync(PurchaseId);
            if (_editedPurchaseMaster != null)
            {
                PictureEdit Image1 = new PictureEdit();
                PictureEdit Image2 = new PictureEdit();
                PictureEdit Image3 = new PictureEdit();

                byte[] Logo = null;
                MemoryStream ms = null;
                try
                {
                    Logo = new byte[0];
                    if (_editedPurchaseMaster.Image1 != null)
                    {
                        Logo = (byte[])(_editedPurchaseMaster.Image1);
                        ms = new MemoryStream(Logo);
                        //ms.Write(Logo, 0, Logo.Length);
                        Image1.Image = new Bitmap(ms);
                        Image1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
                        //Image1.Size = PictureBoxSizeMode.StretchImage;

                        Logo = null;
                        ms = null;
                    }

                    if (_editedPurchaseMaster.Image2 != null)
                    {
                        Logo = (Byte[])(_editedPurchaseMaster.Image2);
                        ms = new MemoryStream(Logo);
                        ms.Write(Logo, 0, Logo.Length);
                        Image2.Image = Image.FromStream(ms);
                        Image2.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
                        //picImage2.SizeMode = PictureBoxSizeMode.StretchImage;

                        Logo = null;
                        ms = null;
                    }

                    if (_editedPurchaseMaster.Image3 != null)
                    {
                        Logo = (Byte[])(_editedPurchaseMaster.Image3);
                        ms = new MemoryStream(Logo);
                        ms.Write(Logo, 0, Logo.Length);
                        Image3.Image = Image.FromStream(ms);
                        Image3.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
                        //picImage3.SizeMode = PictureBoxSizeMode.StretchImage;

                        Logo = null;
                        ms = null;
                    }

                    Transaction.FrmTakePicture fpc = new Transaction.FrmTakePicture(true);
                    fpc.Image1.Image = Image1.Image;
                    fpc.Image2.Image = Image2.Image;
                    fpc.Image3.Image = Image3.Image;
                    fpc.SelectedImage = 0;
                    fpc.ShowDialog();
                }
                catch
                {

                }
            }
        }

        private async void repositoryItemButtonEdit8_Click(object sender, EventArgs e)
        {
            string SalesId = grvSalesTransactonMaster.GetRowCellValue(grvSalesTransactonMaster.FocusedRowHandle, colSalesImage).ToString();

            SalesMaster _editedSalesMaster = await _salesMasterRepository.GetSalesAsync(SalesId);
            if (_editedSalesMaster != null)
            {
                PictureEdit Image1 = new PictureEdit();
                PictureEdit Image2 = new PictureEdit();
                PictureEdit Image3 = new PictureEdit();

                byte[] Logo = null;
                MemoryStream ms = null;
                try
                {
                    Logo = new byte[0];
                    if (_editedSalesMaster.Image1 != null)
                    {
                        Logo = (byte[])(_editedSalesMaster.Image1);
                        ms = new MemoryStream(Logo);
                        //ms.Write(Logo, 0, Logo.Length);
                        Image1.Image = new Bitmap(ms);
                        Image1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
                        //Image1.Size = PictureBoxSizeMode.StretchImage;

                        Logo = null;
                        ms = null;
                    }

                    if (_editedSalesMaster.Image2 != null)
                    {
                        Logo = (Byte[])(_editedSalesMaster.Image2);
                        ms = new MemoryStream(Logo);
                        ms.Write(Logo, 0, Logo.Length);
                        Image2.Image = Image.FromStream(ms);
                        Image2.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
                        //picImage2.SizeMode = PictureBoxSizeMode.StretchImage;

                        Logo = null;
                        ms = null;
                    }

                    if (_editedSalesMaster.Image3 != null)
                    {
                        Logo = (Byte[])(_editedSalesMaster.Image3);
                        ms = new MemoryStream(Logo);
                        ms.Write(Logo, 0, Logo.Length);
                        Image3.Image = Image.FromStream(ms);
                        Image3.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
                        //picImage3.SizeMode = PictureBoxSizeMode.StretchImage;

                        Logo = null;
                        ms = null;
                    }

                    Transaction.FrmTakePicture fpc = new Transaction.FrmTakePicture(true);
                    fpc.Image1.Image = Image1.Image;
                    fpc.Image2.Image = Image2.Image;
                    fpc.Image3.Image = Image3.Image;
                    fpc.SelectedImage = 0;
                    fpc.ShowDialog();
                }
                catch
                {

                }
            }
        }

        private async void repositoryItemButtonEdit9_Click(object sender, EventArgs e)
        {
            string PurchaseId = grvWeeklyPurchaseDetails.GetRowCellValue(grvWeeklyPurchaseDetails.FocusedRowHandle, colWeeklyPurImage).ToString();

            PurchaseMaster _editedPurchaseMaster = await _purchaseMasterRepository.GetPurchaseAsync(PurchaseId);
            if (_editedPurchaseMaster != null)
            {
                PictureEdit Image1 = new PictureEdit();
                PictureEdit Image2 = new PictureEdit();
                PictureEdit Image3 = new PictureEdit();

                byte[] Logo = null;
                MemoryStream ms = null;
                try
                {
                    Logo = new byte[0];
                    if (_editedPurchaseMaster.Image1 != null)
                    {
                        Logo = (byte[])(_editedPurchaseMaster.Image1);
                        ms = new MemoryStream(Logo);
                        //ms.Write(Logo, 0, Logo.Length);
                        Image1.Image = new Bitmap(ms);
                        Image1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
                        //Image1.Size = PictureBoxSizeMode.StretchImage;

                        Logo = null;
                        ms = null;
                    }

                    if (_editedPurchaseMaster.Image2 != null)
                    {
                        Logo = (Byte[])(_editedPurchaseMaster.Image2);
                        ms = new MemoryStream(Logo);
                        ms.Write(Logo, 0, Logo.Length);
                        Image2.Image = Image.FromStream(ms);
                        Image2.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
                        //picImage2.SizeMode = PictureBoxSizeMode.StretchImage;

                        Logo = null;
                        ms = null;
                    }

                    if (_editedPurchaseMaster.Image3 != null)
                    {
                        Logo = (Byte[])(_editedPurchaseMaster.Image3);
                        ms = new MemoryStream(Logo);
                        ms.Write(Logo, 0, Logo.Length);
                        Image3.Image = Image.FromStream(ms);
                        Image3.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
                        //picImage3.SizeMode = PictureBoxSizeMode.StretchImage;

                        Logo = null;
                        ms = null;
                    }

                    Transaction.FrmTakePicture fpc = new Transaction.FrmTakePicture(true);
                    fpc.Image1.Image = Image1.Image;
                    fpc.Image2.Image = Image2.Image;
                    fpc.Image3.Image = Image3.Image;
                    fpc.SelectedImage = 0;
                    fpc.ShowDialog();
                }
                catch
                {

                }
            }
        }
    }
}