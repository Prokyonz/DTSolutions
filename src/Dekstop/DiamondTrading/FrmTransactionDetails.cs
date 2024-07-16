using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DiamondTrading.Transaction;
using EFCore.SQL.Repository;
using Repository.Entities;
using Repository.Entities.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiamondTrading.Utility;

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
        private SalaryMasterRepository _salaryMasterRepository;
        private RejectionInOutMasterRepository _rejectionInOutMasterRepository;

        private List<PurchaseMaster> _purchaseMaster;
        private List<SalesMaster> _salesMaster;
        private GridControl _gridControl = new GridControl();

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
                    accordionEditBtn.Visible = false;
                    accordionDeleteBtn.Visible = false;
                    break;
                case "SalesSlipPrint":
                    xtabPurchaseSlipPrint.PageVisible = true;
                    xtabManager.SelectedTabPage = xtabPurchaseSlipPrint;
                    xtabPurchaseSlipPrint.Text = "Sales Slip Details";
                    this.Text = "Sales Slips Details";
                    accordionEditBtn.Visible = false;
                    accordionDeleteBtn.Visible = false;
                    break;
                case "JangadSend":
                    xtabJangadSendReceive.PageVisible = true;
                    accordionEditBtn.Visible = false;
                    xtabManager.SelectedTabPage = xtabJangadSendReceive;
                    xtabJangadSendReceive.Text = "Jangad Send";
                    this.Text = "Jangad Send";
                    break;
                case "JangadReceive":
                    xtabJangadSendReceive.PageVisible = true;
                    accordionEditBtn.Visible = false;
                    xtabManager.SelectedTabPage = xtabJangadSendReceive;
                    xtabJangadSendReceive.Text = "Jangad Receive";
                    this.Text = "Jangad Receive";
                    break;
                case "PFReport":
                    xtraTabPFReport.PageVisible = true;
                    xtabManager.SelectedTabPage = xtraTabPFReport;
                    xtraTabPFReport.Text = "PF Report";
                    this.Text = "PF Report";
                    accordionEditBtn.Visible = false;
                    accordionDeleteBtn.Visible = false;
                    break;
                case "LedgerReport":
                    xtraTabLedgerBalance.PageVisible = true;
                    xtabManager.SelectedTabPage = xtraTabLedgerBalance;
                    xtraTabLedgerBalance.Text = "Ledger Report";
                    this.Text = "Ledger Report";
                    accordionEditBtn.Visible = false;
                    accordionDeleteBtn.Visible = false;
                    break;
                case "WeeklyPurchaseReport":
                    xtabWeeklyPurchaseReport.PageVisible = true;
                    xtabManager.SelectedTabPage = xtabWeeklyPurchaseReport;
                    xtabWeeklyPurchaseReport.Text = "Weekly Purchase Report";
                    this.Text = "Weekly Purchase Report";
                    accordionEditBtn.Visible = false;
                    accordionDeleteBtn.Visible = false;
                    break;
                case "Payable":
                    xtraTabPayableReceivable.PageVisible = true;
                    xtabManager.SelectedTabPage = xtraTabPayableReceivable;
                    xtraTabPayableReceivable.Text = "Payable Report";
                    this.Text = "Payable Report";
                    accordionEditBtn.Visible = false;
                    accordionDeleteBtn.Visible = false;
                    break;
                case "Receivable":
                    xtraTabPayableReceivable.PageVisible = true;
                    xtabManager.SelectedTabPage = xtraTabPayableReceivable;
                    xtraTabPayableReceivable.Text = "Receivable Report";
                    this.Text = "Receivable Report";
                    accordionEditBtn.Visible = false;
                    accordionDeleteBtn.Visible = false;
                    break;
                case "BalanceSheet":
                    xtraTabBalanceSheet.PageVisible = true;
                    xtabManager.SelectedTabPage = xtraTabBalanceSheet;
                    xtraTabBalanceSheet.Text = "Balance Sheet";
                    this.Text = "Balance Sheet";
                    accordionEditBtn.Visible = false;
                    accordionDeleteBtn.Visible = false;
                    break;
                case "ProfitLoss":
                    xtraTabProfitLoss.PageVisible = true;
                    xtabManager.SelectedTabPage = xtraTabProfitLoss;
                    xtraTabProfitLoss.Text = "Profit & Loss";
                    this.Text = "Balance Sheet";
                    accordionEditBtn.Visible = false;
                    accordionDeleteBtn.Visible = false;
                    break;
                case "CashBank":
                    xtabCashBankReport.PageVisible = true;
                    xtabManager.SelectedTabPage = xtabCashBankReport;
                    xtabCashBankReport.Text = "Cash & Bank Report";
                    this.Text = "Cash & Bank Report";
                    accordionEditBtn.Visible = false;
                    accordionDeleteBtn.Visible = false;
                    break;
                case "SalaryReport":
                    xtabSalaryReport.PageVisible = true;
                    accordionEditBtn.Visible = false;
                    xtabManager.SelectedTabPage = xtabSalaryReport;
                    xtabSalaryReport.Text = "Salary Report";
                    this.Text = "Salary Report";
                    break;
                case "RejectionIn":
                    xtraTabRejectionReport.PageVisible = true;
                    accordionEditBtn.Visible = false;
                    xtabManager.SelectedTabPage = xtraTabRejectionReport;
                    xtraTabRejectionReport.Text = "Rejection In/Receive";
                    this.Text = "Rejection In/Receive";
                    break;
                case "RejectionOut":
                    xtraTabRejectionReport.PageVisible = true;
                    accordionEditBtn.Visible = false;
                    xtabManager.SelectedTabPage = xtraTabRejectionReport;
                    xtraTabRejectionReport.Text = "Rejection Out/Send";
                    this.Text = "Rejection Out/Send";
                    break;
                case "RejectionPending":
                    xtraTabRejectionPendingReport.PageVisible = true;
                    accordionEditBtn.Visible = false;
                    xtabManager.SelectedTabPage = xtraTabRejectionPendingReport;
                    xtraTabRejectionPendingReport.Text = "Rejection Pending";
                    this.Text = "Rejection Pending";
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
            xtabCashBankReport.PageVisible = false;
            xtabSalaryReport.PageVisible = false;
            xtraTabRejectionReport.PageVisible = false;
            xtraTabRejectionPendingReport.PageVisible = false;
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
            var firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtFromDate.EditValue = firstDayOfMonth;
            dtToDate.EditValue = firstDayOfMonth.AddMonths(1).AddDays(-1);

            dtSalesFromDate.EditValue = firstDayOfMonth;
            dtSalesToDate.EditValue = firstDayOfMonth.AddMonths(1).AddDays(-1);

            dtPaymentFromDate.EditValue = firstDayOfMonth;
            dtPaymentToDate.EditValue = firstDayOfMonth.AddMonths(1).AddDays(-1);

            dtReceiptFromDate.EditValue = firstDayOfMonth;
            dtReceiptToDate.EditValue = firstDayOfMonth.AddMonths(1).AddDays(-1);

            dtContraFromDate.EditValue = firstDayOfMonth;
            dtContraToDate.EditValue = firstDayOfMonth.AddMonths(1).AddDays(-1);

            dtExpenseFromDate.EditValue = firstDayOfMonth;
            dtExpenseToDate.EditValue = firstDayOfMonth.AddMonths(1).AddDays(-1);

            dtMixedFromDate.EditValue = firstDayOfMonth;
            dtMixedToDate.EditValue = firstDayOfMonth.AddMonths(1).AddDays(-1);

            dtCashBankFromDate.EditValue = firstDayOfMonth;
            dtCashBankToDate.EditValue = firstDayOfMonth.AddMonths(1).AddDays(-1);

            lueProfitLossType.Properties.DataSource = Common.GetBalanceSheetType;
            lueProfitLossType.Properties.DisplayMember = "Name";
            lueProfitLossType.Properties.ValueMember = "Id";
            lueProfitLossType.EditValue = 2;

            lueBalanceSheetType.Properties.DataSource = Common.GetBalanceSheetType;
            lueBalanceSheetType.Properties.DisplayMember = "Name";
            lueBalanceSheetType.Properties.ValueMember = "Id";
            lueBalanceSheetType.EditValue = 2;


            ActiveTab();
            try
            {
                await LoadGridData(true);
            }
            catch (Exception ex)
            {
            }
        }

        private async Task LoadGridData(bool IsForceLoad = false)
        {
            this.Cursor = Cursors.WaitCursor;
            if (xtabManager.SelectedTabPage == xtabPurchase)
            {
                if (IsForceLoad || _purchaseMasterRepository == null)
                {
                    _purchaseMasterRepository = new PurchaseMasterRepository();
                    var purchaseData = await _purchaseMasterRepository.GetPurchaseReport(Common.LoginCompany, Common.LoginFinancialYear, null, dtFromDate.DateTime.Date.ToString("yyyy-MM-dd"), dtToDate.DateTime.Date.ToString("yyyy-MM-dd"));
                    grdTransactionMaster.DataSource = purchaseData.OrderBy(o => o.SlipNo);


                    if (Common.CurrentSelectedCompany.Any() && Common.CurrentSelectedCompany.FirstOrDefault().CompanyOptions.Any())
                    {
                        var IsShape = Common.CurrentSelectedCompany.FirstOrDefault().CompanyOptions.Where(x => x.PermissionGroupName == "PurchaseSale" && x.PermissionName == "Shape").FirstOrDefault();
                        if (IsShape != null)
                        {
                            if (IsShape.IsPurchase)
                                gridColumn180.Visible = true;
                            else
                                gridColumn180.Visible = false;
                        }

                        var IsPurity = Common.CurrentSelectedCompany.FirstOrDefault().CompanyOptions.Where(x => x.PermissionGroupName == "PurchaseSale" && x.PermissionName == "Purity").FirstOrDefault();
                        if (IsPurity != null)
                        {
                            if (IsPurity.IsPurchase)
                                gridColumn182.Visible = true;
                            else
                                gridColumn182.Visible = false;
                        }

                        var IsTip = Common.CurrentSelectedCompany.FirstOrDefault().CompanyOptions.Where(x => x.PermissionGroupName == "PurchaseSale" && x.PermissionName == "Tip").FirstOrDefault();
                        if (IsTip != null)
                        {
                            if (IsTip.IsPurchase)
                                gridColumn162.Visible = true;
                            else
                                gridColumn162.Visible = false;
                        }

                        var IsCVD = Common.CurrentSelectedCompany.FirstOrDefault().CompanyOptions.Where(x => x.PermissionGroupName == "PurchaseSale" && x.PermissionName == "CVD").FirstOrDefault();
                        if (IsCVD != null)
                        {
                            if (IsCVD.IsPurchase)
                                gridColumn163.Visible = true;
                            else
                                gridColumn163.Visible = false;
                        }

                        var IsLessCts = Common.CurrentSelectedCompany.FirstOrDefault().CompanyOptions.Where(x => x.PermissionGroupName == "PurchaseSale" && x.PermissionName == "(-) Cts").FirstOrDefault();
                        if (IsLessCts != null)
                        {
                            if (IsLessCts.IsPurchase)
                                gridColumn114.Visible = true;
                            else
                                gridColumn114.Visible = false;
                        }

                        var IsCVDCharge = Common.CurrentSelectedCompany.FirstOrDefault().CompanyOptions.Where(x => x.PermissionGroupName == "PurchaseSale" && x.PermissionName == "CVD A").FirstOrDefault();
                        if (IsCVDCharge != null)
                        {
                            if (IsCVDCharge.IsPurchase)
                            {
                                gridColumn113.Visible = true;
                                gridColumn166.Visible = true;
                            }
                            else
                            {
                                gridColumn113.Visible = false;
                                gridColumn166.Visible = false;
                            }
                        }

                        var IsNumber = Common.CurrentSelectedCompany.FirstOrDefault().CompanyOptions.Where(x => x.PermissionGroupName == "PurchaseSale" && x.PermissionName == "Number").FirstOrDefault();
                        if (IsNumber != null)
                        {
                            if (IsNumber.IsPurchase)
                                gridColumn227NumberName.Visible = true;
                            else
                                gridColumn227NumberName.Visible = false;
                        }
                    }

                    grvTransMaster.RestoreLayoutFromRegistry(RegistryHelper.ReportLayouts("PurchaseReport"));
                }
            }
            else if (xtabManager.SelectedTabPage == xtabSales)
            {
                if (IsForceLoad || _salesMasterRepository == null)
                {
                    _salesMasterRepository = new SalesMasterRepository();
                    var salesData = await _salesMasterRepository.GetSalesReport(Common.LoginCompany, Common.LoginFinancialYear, dtSalesFromDate.DateTime.Date.ToString("yyyy-MM-dd"), dtSalesToDate.DateTime.Date.ToString("yyyy-MM-dd"));
                    grdSalesTransactonMaster.DataSource = salesData.OrderBy(o => o.SlipNo);

                    if (Common.CurrentSelectedCompany.Any() && Common.CurrentSelectedCompany.FirstOrDefault().CompanyOptions.Any())
                    {
                        var IsShape = Common.CurrentSelectedCompany.FirstOrDefault().CompanyOptions.Where(x => x.PermissionGroupName == "PurchaseSale" && x.PermissionName == "Shape").FirstOrDefault();
                        if (IsShape != null)
                        {
                            if (IsShape.IsPurchase)
                                gridColumn183.Visible = true;
                            else
                                gridColumn183.Visible = false;
                        }

                        var IsPurity = Common.CurrentSelectedCompany.FirstOrDefault().CompanyOptions.Where(x => x.PermissionGroupName == "PurchaseSale" && x.PermissionName == "Purity").FirstOrDefault();
                        if (IsPurity != null)
                        {
                            if (IsPurity.IsPurchase)
                                gridColumn185.Visible = true;
                            else
                                gridColumn185.Visible = false;
                        }

                        var IsTip = Common.CurrentSelectedCompany.FirstOrDefault().CompanyOptions.Where(x => x.PermissionGroupName == "PurchaseSale" && x.PermissionName == "Tip").FirstOrDefault();
                        if (IsTip != null)
                        {
                            if (IsTip.IsPurchase)
                                gridColumn172.Visible = true;
                            else
                                gridColumn172.Visible = false;
                        }

                        var IsCVD = Common.CurrentSelectedCompany.FirstOrDefault().CompanyOptions.Where(x => x.PermissionGroupName == "PurchaseSale" && x.PermissionName == "CVD").FirstOrDefault();
                        if (IsCVD != null)
                        {
                            if (IsCVD.IsPurchase)
                                gridColumn173.Visible = true;
                            else
                                gridColumn173.Visible = false;
                        }

                        var IsLessCts = Common.CurrentSelectedCompany.FirstOrDefault().CompanyOptions.Where(x => x.PermissionGroupName == "PurchaseSale" && x.PermissionName == "(-) Cts").FirstOrDefault();
                        if (IsLessCts != null)
                        {
                            if (IsLessCts.IsPurchase)
                                gridColumn118.Visible = true;
                            else
                                gridColumn118.Visible = false;
                        }

                        var IsCVDCharge = Common.CurrentSelectedCompany.FirstOrDefault().CompanyOptions.Where(x => x.PermissionGroupName == "PurchaseSale" && x.PermissionName == "CVD A").FirstOrDefault();
                        if (IsCVDCharge != null)
                        {
                            if (IsCVDCharge.IsPurchase)
                            {
                                gridColumn119.Visible = true;
                                gridColumn176.Visible = true;
                            }
                            else
                            {
                                gridColumn119.Visible = false;
                                gridColumn176.Visible = false;
                            }
                        }

                        var IsNumber = Common.CurrentSelectedCompany.FirstOrDefault().CompanyOptions.Where(x => x.PermissionGroupName == "PurchaseSale" && x.PermissionName == "Number").FirstOrDefault();
                        if (IsNumber != null)
                        {
                            if (IsNumber.IsPurchase)
                                gridColumn187.Visible = true;
                            else
                                gridColumn187.Visible = false;
                        }
                    }

                    grvSalesTransactonMaster.RestoreLayoutFromRegistry(RegistryHelper.ReportLayouts("SalesReport"));
                }
            }
            else if (xtabManager.SelectedTabPage == xtabPayment)
            {
                if (IsForceLoad || _paymentMasterRepository == null)
                {
                    _paymentMasterRepository = new PaymentMasterRepository();
                    var data = await _paymentMasterRepository.GetPaymentReport(Common.LoginCompany, Common.LoginFinancialYear, 0, dtPaymentFromDate.DateTime.Date.ToString("yyyy-MM-dd"), dtPaymentToDate.DateTime.Date.ToString("yyyy-MM-dd"));
                    grdPaymentDetails.DataSource = data;
                    gridView4.RestoreLayoutFromRegistry(RegistryHelper.ReportLayouts("PaymentReport"));
                }
            }
            else if (xtabManager.SelectedTabPage == xtabReceipt)
            {
                if (IsForceLoad || _paymentMasterRepository == null)
                {
                    _paymentMasterRepository = new PaymentMasterRepository();
                    var data = await _paymentMasterRepository.GetPaymentReport(Common.LoginCompany, Common.LoginFinancialYear, 1, dtReceiptFromDate.DateTime.Date.ToString("yyyy-MM-dd"), dtReceiptToDate.DateTime.Date.ToString("yyyy-MM-dd"));
                    grdReceiptDetails.DataSource = data;
                    gridView7.RestoreLayoutFromRegistry(RegistryHelper.ReportLayouts("ReceiptReport"));
                }
            }
            else if (xtabManager.SelectedTabPage == xtabContra)
            {
                if (IsForceLoad || _paymentMasterRepository == null)
                {
                    _contraEntryMasterRespository = new ContraEntryMasterRespository();
                    var data = await _contraEntryMasterRespository.GetContraReport(Common.LoginCompany, Common.LoginFinancialYear, dtContraFromDate.DateTime.Date.ToString("yyyy-MM-dd"), dtContraToDate.DateTime.Date.ToString("yyyy-MM-dd"));
                    grdContraDetails.DataSource = data;
                    grvContraDetails.RestoreLayoutFromRegistry(RegistryHelper.ReportLayouts("ContraReport"));
                }
            }
            else if (xtabManager.SelectedTabPage == xtabExpense)
            {
                if (IsForceLoad || _expenseMasterRepository == null)
                {
                    _expenseMasterRepository = new ExpenseMasterRepository();
                    var data = await _expenseMasterRepository.GetExpenseReport(Common.LoginCompany, Common.LoginFinancialYear, dtExpenseFromDate.DateTime.Date.ToString("yyyy-MM-dd"), dtExpenseToDate.DateTime.Date.ToString("yyyy-MM-dd"));
                    grdExpenseControl.DataSource = data;
                    grvExpenseMaster.RestoreLayoutFromRegistry(RegistryHelper.ReportLayouts("ExpenseReport"));
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
                    gridView9.RestoreLayoutFromRegistry(RegistryHelper.ReportLayouts("LoanReport"));
                }
            }
            else if (xtabManager.SelectedTabPage == xtabMixed)
            {
                if (IsForceLoad || _paymentMasterRepository == null)
                {
                    _paymentMasterRepository = new PaymentMasterRepository();
                    var data = await _paymentMasterRepository.GetMixedReportAsync(Common.LoginCompany, Common.LoginFinancialYear, dtMixedFromDate.DateTime.Date.ToString("yyyy-MM-dd"), dtMixedToDate.DateTime.Date.ToString("yyyy-MM-dd"));
                    gridControlMixed.DataSource = data;
                    gridView15.ExpandAllGroups();
                    gridView15.RestoreLayoutFromRegistry(RegistryHelper.ReportLayouts("MixReport"));
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
                    grvPurchaseSlipDetails.RestoreLayoutFromRegistry(RegistryHelper.ReportLayouts("SlipReport"));
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
                    grvJangadSendReceive.RestoreLayoutFromRegistry(RegistryHelper.ReportLayouts("JangadReport"));
                }
            }
            else if (xtabManager.SelectedTabPage == xtraTabPFReport)
            {
                if (IsForceLoad || _purchaseMasterRepository == null)
                {
                    _purchaseMasterRepository = new PurchaseMasterRepository();
                    var data = await _purchaseMasterRepository.GetPFReportAsync(Common.LoginCompany, Common.LoginFinancialYear, 1);
                    gridControlPFReport.DataSource = data;
                    grvPFReport.RestoreLayoutFromRegistry(RegistryHelper.ReportLayouts("PFReport"));
                }
            }
            else if (xtabManager.SelectedTabPage == xtraTabLedgerBalance)
            {
                if (IsForceLoad || _partyMasterRepository == null)
                {
                    //splashScreenManager1.ShowWaitForm();
                    _partyMasterRepository = new PartyMasterRepository();
                    var data = await _partyMasterRepository.GetLedgerReport(Common.LoginCompany, Common.LoginFinancialYear);
                    gridControlLedgerReport.DataSource = data;
                    grvLedgerReport.RestoreLayoutFromRegistry(RegistryHelper.ReportLayouts("LedgerReport"));
                    //splashScreenManager1.CloseWaitForm();
                }
            }
            else if (xtabManager.SelectedTabPage == xtabWeeklyPurchaseReport)
            {
                if (IsForceLoad || _purchaseMasterRepository == null)
                {
                    _purchaseMasterRepository = new PurchaseMasterRepository();
                    var data = await _purchaseMasterRepository.GetWeeklyPurchaseReportAsync(Common.LoginCompany, Common.LoginFinancialYear);
                    grdWeeklyPurchaseReport.DataSource = data;
                    grvWeeklyPurchaseReport.RestoreLayoutFromRegistry(RegistryHelper.ReportLayouts("WeeklyReport"));

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
                    gridView1.RestoreLayoutFromRegistry(RegistryHelper.ReportLayouts("PayableReceivableReport"));
                }
            }
            else if (xtabManager.SelectedTabPage == xtraTabBalanceSheet)
            {
                if (IsForceLoad || _paymentMasterRepository == null)
                {
                    _paymentMasterRepository = new PaymentMasterRepository();
                    var data = await _paymentMasterRepository.GetBalanceSheetReportAsync(Common.LoginCompany, Common.LoginFinancialYear, Convert.ToInt32(lueBalanceSheetType.EditValue));
                    gridControlBalanceSheet.DataSource = data;
                    gridView29.RestoreLayoutFromRegistry(RegistryHelper.ReportLayouts("BalanceSheetReport"));
                }
            }
            else if (xtabManager.SelectedTabPage == xtraTabProfitLoss)
            {
                if (IsForceLoad || _paymentMasterRepository == null)
                {
                    _paymentMasterRepository = new PaymentMasterRepository();
                    var data = await _paymentMasterRepository.GetProfitLossReportAsync(Common.LoginCompany, Common.LoginFinancialYear, Convert.ToInt32(lueProfitLossType.EditValue));
                    gridControlProfitLoss.DataSource = data;
                    gridView32.RestoreLayoutFromRegistry(RegistryHelper.ReportLayouts("ProfitLossReport"));
                }
            }
            else if (xtabManager.SelectedTabPage == xtabCashBankReport)
            {
                if (IsForceLoad || _paymentMasterRepository == null)
                {
                    _paymentMasterRepository = new PaymentMasterRepository();
                    var data = await _paymentMasterRepository.GetCashBankReportAsync(Common.LoginCompany, Common.LoginFinancialYear, dtCashBankFromDate.DateTime.Date.ToString("yyyy-MM-dd"), dtCashBankToDate.DateTime.Date.ToString("yyyy-MM-dd"));
                    gridControlCashBank.DataSource = data;

                    gridView2.RestoreLayoutFromRegistry(RegistryHelper.ReportLayouts("CashBankReport"));
                }
            }
            else if (xtabManager.SelectedTabPage == xtabSalaryReport)
            {
                if (IsForceLoad || _salaryMasterRepository == null)
                {
                    _salaryMasterRepository = new SalaryMasterRepository();
                    var data = await _salaryMasterRepository.GetSalaries(Common.LoginCompany, Common.LoginFinancialYear);
                    gridControlSalaryReport.DataSource = data;

                    grdViewSalaryReport.RestoreLayoutFromRegistry(RegistryHelper.ReportLayouts("SalaryReport"));
                }
            }
            else if (xtabManager.SelectedTabPage == xtraTabRejectionReport)
            {
                if (IsForceLoad || _rejectionInOutMasterRepository == null)
                {
                    int ActionType = 1;
                    if (SelectedTabPage.Equals("RejectionOut"))
                        ActionType = 2;

                    _rejectionInOutMasterRepository = new RejectionInOutMasterRepository();
                    var data = await _rejectionInOutMasterRepository.GetRejectionSendReceiveReport(Common.LoginCompany, Common.LoginFinancialYear, ActionType);
                    gridControlRejectionReport.DataSource = data;

                    gridView13.RestoreLayoutFromRegistry(RegistryHelper.ReportLayouts(SelectedTabPage));
                }
            }
            else if (xtabManager.SelectedTabPage == xtraTabRejectionPendingReport)
            {
                if (IsForceLoad || _rejectionInOutMasterRepository == null)
                {
                    _rejectionInOutMasterRepository = new RejectionInOutMasterRepository();
                    var data = await _rejectionInOutMasterRepository.GetRejectionPendingReport(Common.LoginCompany, Common.LoginFinancialYear);
                    grdRejectionPending.DataSource = data;

                    grvRejectionPending.RestoreLayoutFromRegistry(RegistryHelper.ReportLayouts(SelectedTabPage));
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void ExportGridData(ExportDataType exportType)
        {
            this.Cursor = Cursors.WaitCursor;
            if (xtabManager.SelectedTabPage == xtabPurchase)
            {
                if (exportType == ExportDataType.Excel)
                {
                    ExportToExcel(grvTransMaster);
                }
                else if (exportType == ExportDataType.PDF)
                {
                    ExportToPDF(grdTransactionMaster);
                }
            }
            else if (xtabManager.SelectedTabPage == xtabSales)
            {
                if (exportType == ExportDataType.Excel)
                {
                    ExportToExcel(grvSalesTransactonMaster);
                }
                else if (exportType == ExportDataType.PDF)
                {
                    ExportToPDF(grdSalesTransactonMaster);
                }
            }
            else if (xtabManager.SelectedTabPage == xtabPayment)
            {
                if (exportType == ExportDataType.Excel)
                {
                    ExportToExcel(gridView4);
                }
                else if (exportType == ExportDataType.PDF)
                {
                    ExportToPDF(grdPaymentDetails);
                }
            }
            else if (xtabManager.SelectedTabPage == xtabReceipt)
            {
                if (exportType == ExportDataType.Excel)
                {
                    ExportToExcel(gridView7);
                }
                else if (exportType == ExportDataType.PDF)
                {
                    ExportToPDF(grdReceiptDetails);
                }
            }
            else if (xtabManager.SelectedTabPage == xtabContra)
            {
                if (exportType == ExportDataType.Excel)
                {
                    ExportToExcel(grvContraDetails);
                }
                else if (exportType == ExportDataType.PDF)
                {
                    ExportToPDF(grdContraDetails);
                }
            }
            else if (xtabManager.SelectedTabPage == xtabExpense)
            {
                if (exportType == ExportDataType.Excel)
                {
                    ExportToExcel(grvExpenseMaster);
                }
                else if (exportType == ExportDataType.PDF)
                {
                    ExportToPDF(grdExpenseControl);
                }
            }
            else if (xtabManager.SelectedTabPage == xtabLoan)
            {
                if (exportType == ExportDataType.Excel)
                {
                    ExportToExcel(gridView9);
                }
                else if (exportType == ExportDataType.PDF)
                {
                    ExportToPDF(gridControlLoan);
                }
            }
            else if (xtabManager.SelectedTabPage == xtabMixed)
            {
                if (exportType == ExportDataType.Excel)
                {
                    ExportToExcel(gridView15);
                }
                else if (exportType == ExportDataType.PDF)
                {
                    ExportToPDF(gridControlMixed);
                }
            }
            else if (xtabManager.SelectedTabPage == xtabPurchaseSlipPrint)
            {
                if (exportType == ExportDataType.Excel)
                {
                    ExportToExcel(grvPurchaseSlipDetails);
                }
                else if (exportType == ExportDataType.PDF)
                {
                    ExportToPDF(grdPurchaseSlipDetails);
                }
            }
            else if (xtabManager.SelectedTabPage == xtabJangadSendReceive)
            {
                if (exportType == ExportDataType.Excel)
                {
                    ExportToExcel(grvJangadSendReceive);
                }
                else if (exportType == ExportDataType.PDF)
                {
                    ExportToPDF(gridControlJangadSendReceive);
                }
            }
            else if (xtabManager.SelectedTabPage == xtraTabPFReport)
            {
                if (exportType == ExportDataType.Excel)
                {
                    ExportToExcel(grvPFReport);
                }
                else if (exportType == ExportDataType.PDF)
                {
                    ExportToPDF(gridControlPFReport);
                }
            }
            else if (xtabManager.SelectedTabPage == xtraTabLedgerBalance)
            {
                if (exportType == ExportDataType.Excel)
                {
                    ExportToExcel(grvLedgerReport);
                }
                else if (exportType == ExportDataType.PDF)
                {
                    ExportToPDF(gridControlLedgerReport);
                }
            }
            else if (xtabManager.SelectedTabPage == xtabWeeklyPurchaseReport)
            {
                if (exportType == ExportDataType.Excel)
                {
                    ExportToExcel(grvWeeklyPurchaseReport);
                }
                else if (exportType == ExportDataType.PDF)
                {
                    ExportToPDF(grdWeeklyPurchaseReport);
                }
            }
            else if (xtabManager.SelectedTabPage == xtraTabPayableReceivable)
            {
                if (exportType == ExportDataType.Excel)
                {
                    ExportToExcel(gridView1);
                }
                else if (exportType == ExportDataType.PDF)
                {
                    ExportToPDF(gridControlPayableReceivable);
                }
            }
            else if (xtabManager.SelectedTabPage == xtraTabBalanceSheet)
            {
                if (exportType == ExportDataType.Excel)
                {
                    ExportToExcel(gridView29);
                }
                else if (exportType == ExportDataType.PDF)
                {
                    ExportToPDF(gridControlBalanceSheet);
                }
            }
            else if (xtabManager.SelectedTabPage == xtraTabProfitLoss)
            {
                if (exportType == ExportDataType.Excel)
                {
                    ExportToExcel(gridView32);
                }
                else if (exportType == ExportDataType.PDF)
                {
                    ExportToPDF(gridControlProfitLoss);
                }
            }
            else if (xtabManager.SelectedTabPage == xtabCashBankReport)
            {
                if (exportType == ExportDataType.Excel)
                {
                    ExportToExcel(gridView2);
                }
                else if (exportType == ExportDataType.PDF)
                {
                    ExportToPDF(gridControlCashBank);
                }
            }
            else if (xtabManager.SelectedTabPage == xtabSalaryReport)
            {
                if (exportType == ExportDataType.Excel)
                {
                    ExportToExcel(grdViewSalaryReport);
                }
                else if (exportType == ExportDataType.PDF)
                {
                    ExportToPDF(gridControlSalaryReport);
                }
            }
            else if (xtabManager.SelectedTabPage == xtraTabRejectionReport)
            {
                if (exportType == ExportDataType.Excel)
                {
                    ExportToExcel(gridView13);
                }
                else if (exportType == ExportDataType.PDF)
                {
                    ExportToPDF(gridControlRejectionReport);
                }
            }
            else if (xtabManager.SelectedTabPage == xtraTabRejectionPendingReport)
            {
                if (exportType == ExportDataType.Excel)
                {
                    ExportToExcel(grvRejectionPending);
                }
                else if (exportType == ExportDataType.PDF)
                {
                    ExportToPDF(grdRejectionPending);
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void ExportToExcel(GridView gridView)
        {
            gridView.ExpandAllGroups();
            gridView.BestFitColumns();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
            saveFileDialog.Title = "Save an Excel File";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
                gridView.ExportToXlsx(saveFileDialog.FileName);
        }

        private void ExportToPDF(GridControl gridView)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
            saveFileDialog.Title = "PDF an Excel File";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                this.Cursor = Cursors.WaitCursor;
                DevExpress.XtraPrinting.PrintingSystem printingSystem1 = new DevExpress.XtraPrinting.PrintingSystem();
                DevExpress.XtraPrinting.PrintableComponentLink printLink = new DevExpress.XtraPrinting.PrintableComponentLink();

                DevExpress.XtraPrinting.PdfExportOptions options = new DevExpress.XtraPrinting.PdfExportOptions();

                try
                {
                    printLink.Component = gridView;
                    printLink.CreateDocument(printingSystem1);
                    printLink.Landscape = true;

                    printingSystem1.ShowPrintStatusDialog = true;
                    printingSystem1.PageSettings.Landscape = true;
                    printingSystem1.ExportToPdf(saveFileDialog.FileName, options);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    printingSystem1.Dispose();
                    printLink.Dispose();
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void FrmTransactionDetails_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (xtabManager.SelectedTabPage == xtabPurchase)
            {
                grvTransMaster.SaveLayoutToRegistry(RegistryHelper.ReportLayouts("PurchaseReport"));
            }
            else if (xtabManager.SelectedTabPage == xtabSales)
            {
                grvSalesTransactonMaster.SaveLayoutToRegistry(RegistryHelper.ReportLayouts("SalesReport"));
            }
            else if (xtabManager.SelectedTabPage == xtabPayment)
            {
                gridView4.SaveLayoutToRegistry(RegistryHelper.ReportLayouts("PaymentReport"));
            }
            else if (xtabManager.SelectedTabPage == xtabReceipt)
            {
                gridView7.SaveLayoutToRegistry(RegistryHelper.ReportLayouts("ReceiptReport"));
            }
            else if (xtabManager.SelectedTabPage == xtabContra)
            {
                grvContraDetails.SaveLayoutToRegistry(RegistryHelper.ReportLayouts("ContraReport"));
            }
            else if (xtabManager.SelectedTabPage == xtabExpense)
            {
                grvExpenseMaster.SaveLayoutToRegistry(RegistryHelper.ReportLayouts("ExpenseReport"));
            }
            else if (xtabManager.SelectedTabPage == xtabLoan)
            {
                gridView9.SaveLayoutToRegistry(RegistryHelper.ReportLayouts("LoanReport"));
            }
            else if (xtabManager.SelectedTabPage == xtabMixed)
            {
                gridView15.SaveLayoutToRegistry(RegistryHelper.ReportLayouts("MixReport"));
            }
            else if (xtabManager.SelectedTabPage == xtabPurchaseSlipPrint)
            {
                grvPurchaseSlipDetails.SaveLayoutToRegistry(RegistryHelper.ReportLayouts("SlipReport"));
            }
            else if (xtabManager.SelectedTabPage == xtabJangadSendReceive)
            {
                grvJangadSendReceive.SaveLayoutToRegistry(RegistryHelper.ReportLayouts("JangadReport"));
            }
            else if (xtabManager.SelectedTabPage == xtraTabPFReport)
            {
                grvPFReport.SaveLayoutToRegistry(RegistryHelper.ReportLayouts("PFReport"));
            }
            else if (xtabManager.SelectedTabPage == xtraTabLedgerBalance)
            {
                grvLedgerReport.SaveLayoutToRegistry(RegistryHelper.ReportLayouts("LedgerReport"));
            }
            else if (xtabManager.SelectedTabPage == xtabWeeklyPurchaseReport)
            {
                grvWeeklyPurchaseReport.SaveLayoutToRegistry(RegistryHelper.ReportLayouts("WeeklyReport"));
            }
            else if (xtabManager.SelectedTabPage == xtraTabPayableReceivable)
            {
                gridView1.SaveLayoutToRegistry(RegistryHelper.ReportLayouts("PayableReceivableReport"));
            }
            else if (xtabManager.SelectedTabPage == xtraTabBalanceSheet)
            {
                gridView29.SaveLayoutToRegistry(RegistryHelper.ReportLayouts("BalanceSheetReport"));
            }
            else if (xtabManager.SelectedTabPage == xtraTabProfitLoss)
            {
                gridView32.SaveLayoutToRegistry(RegistryHelper.ReportLayouts("ProfitLossReport"));
            }
            else if (xtabManager.SelectedTabPage == xtabCashBankReport)
            {
                gridView2.SaveLayoutToRegistry(RegistryHelper.ReportLayouts("CashBankReport"));
            }
            else if (xtabManager.SelectedTabPage == xtabSalaryReport)
            {
                grdViewSalaryReport.SaveLayoutToRegistry(RegistryHelper.ReportLayouts("SalaryReport"));
            }
            else if (xtabManager.SelectedTabPage == xtabSalaryReport)
            {
                gridView13.SaveLayoutToRegistry(RegistryHelper.ReportLayouts(SelectedTabPage));
            }
            else if (xtabManager.SelectedTabPage == xtraTabRejectionPendingReport)
            {
                grvRejectionPending.SaveLayoutToRegistry(RegistryHelper.ReportLayouts(SelectedTabPage));
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
            else if (xtabManager.SelectedTabPage == xtabExpense)
            {
                string SelectedSrNo = grvExpenseMaster.GetFocusedRowCellValue("SrNo").ToString();
                int CrDrType = Convert.ToInt32(grvExpenseMaster.GetFocusedRowCellValue("CrDrType"));

                Transaction.FrmPaymentEntry frmPaymentEntry = new Transaction.FrmPaymentEntry("Expense", Common.LoginCompany, Common.LoginFinancialYear, Convert.ToInt32(SelectedSrNo), CrDrType);

                if (frmPaymentEntry.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
            }
            else if (xtabManager.SelectedTabPage == xtabContra)
            {
                string SelectedSrNo = grvContraDetails.GetFocusedRowCellValue("SrNo").ToString();

                Transaction.FrmPaymentEntry frmPaymentEntry = new Transaction.FrmPaymentEntry("Contra", Common.LoginCompany, Common.LoginFinancialYear, Convert.ToInt32(SelectedSrNo), -1);

                if (frmPaymentEntry.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
            }
            else if (xtabManager.SelectedTabPage == xtabPayment)
            {
                string SelectedSrNo = gridView4.GetFocusedRowCellValue("SrNo").ToString();
                int CrDrType = Convert.ToInt32(gridView4.GetFocusedRowCellValue("CrDrType"));

                Transaction.FrmPaymentEntry frmPaymentEntry = new Transaction.FrmPaymentEntry("Payment", Common.LoginCompany, Common.LoginFinancialYear, Convert.ToInt32(SelectedSrNo), CrDrType);

                if (frmPaymentEntry.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
            }
            else if (xtabManager.SelectedTabPage == xtabReceipt)
            {
                string SelectedSrNo = gridView7.GetFocusedRowCellValue("SrNo").ToString();
                int CrDrType = Convert.ToInt32(gridView7.GetFocusedRowCellValue("CrDrType"));

                Transaction.FrmPaymentEntry frmPaymentEntry = new Transaction.FrmPaymentEntry("Receipt", Common.LoginCompany, Common.LoginFinancialYear, Convert.ToInt32(SelectedSrNo), CrDrType);

                if (frmPaymentEntry.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
            }
            else if (xtabManager.SelectedTabPage == xtabLoan)
            {
                string SelectedGuid = gridView9.GetFocusedRowCellValue("Id").ToString();
                FrmLoanEntry frmLoanEntry = new FrmLoanEntry(SelectedGuid);

                if (frmLoanEntry.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }

            }
        }

        private void xtabMasterDetails_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            //_ = LoadGridData();
        }

        private async void accordionRefreshBtn_Click(object sender, EventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            await LoadGridData(true);
            splashScreenManager1.CloseWaitForm();
        }

        private async void accordionDeleteBtn_Click(object sender, EventArgs e)
        {
            if (xtabManager.SelectedTabPage == xtabPurchase)
            {
                if (MessageBox.Show(string.Format(AppMessages.GetString(AppMessageID.DleteExpenseConfirmation), "Do you want to delete this record?"), "[" + this.Text + "]", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    string id = grvTransMaster.GetFocusedRowCellValue(gridColumnPurchaseMasterId).ToString();
                    //string kapanId = grvTransMaster.GetFocusedRowCellValue().ToString();

                    bool result = await _purchaseMasterRepository.DeletePurchaseAsync(id, false);

                    if (result)
                    {
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

                    if (result)
                    {
                        MessageBox.Show(AppMessages.GetString(AppMessageID.DeleteSuccessfully));
                    }
                    else
                    {
                        MessageBox.Show("You can not delete this record because receipt has been taken for this sales slipno.");
                    }
                }
            }
            else if (xtabManager.SelectedTabPage == xtabExpense)
            {
                if (MessageBox.Show(string.Format(AppMessages.GetString(AppMessageID.DleteExpenseConfirmation), "Do you want to delete this record?"), "[" + this.Text + "]", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    string id = grvExpenseMaster.GetFocusedRowCellValue(gridColumnExpenseSrNo).ToString();

                    bool result = await _expenseMasterRepository.DeleteSrNoAllExpenseAsync(Convert.ToInt32(id), Common.LoginCompany, Common.LoginFinancialYear, true);

                    MessageBox.Show(AppMessages.GetString(AppMessageID.DeleteSuccessfully));
                }
            }
            else if (xtabManager.SelectedTabPage == xtabContra)
            {
                if (MessageBox.Show(string.Format(AppMessages.GetString(AppMessageID.DleteExpenseConfirmation), "Do you want to delete this record?"), "[" + this.Text + "]", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    string SelectedSrNo = grvContraDetails.GetFocusedRowCellValue("SrNo").ToString();
                    bool result = await _contraEntryMasterRespository.DeleteContraEntryAsync(Convert.ToInt32(SelectedSrNo), Common.LoginCompany, Common.LoginFinancialYear);

                    MessageBox.Show(AppMessages.GetString(AppMessageID.DeleteSuccessfully));
                }
            }
            else if (xtabManager.SelectedTabPage == xtabReceipt)
            {
                if (MessageBox.Show(string.Format(AppMessages.GetString(AppMessageID.DleteExpenseConfirmation), "Do you want to delete this record?"), "[" + this.Text + "]", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    string id = gridView7.GetFocusedRowCellValue(gridColumnReceiptGroupId).ToString();

                    bool result = await _paymentMasterRepository.DeletePaymentAsync(id, Common.LoginCompany, Common.LoginFinancialYear);

                    MessageBox.Show(AppMessages.GetString(AppMessageID.DeleteSuccessfully));
                }
            }
            else if (xtabManager.SelectedTabPage == xtabPayment)
            {
                if (MessageBox.Show(string.Format(AppMessages.GetString(AppMessageID.DleteExpenseConfirmation), "Do you want to delete this record?"), "[" + this.Text + "]", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    string id = gridView4.GetFocusedRowCellValue(gridColumnGroupId).ToString();

                    bool result = await _paymentMasterRepository.DeletePaymentAsync(id, Common.LoginCompany, Common.LoginFinancialYear);

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
            else if (xtabManager.SelectedTabPage == xtabSalaryReport)
            {
                if (MessageBox.Show(string.Format("Do you want to delete complete thread?"), "[" + this.Text + "]", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    string id = grdViewSalaryReport.GetFocusedRowCellValue(gridColumnSalaryId).ToString();
                    string salaryMasterId = grdViewSalaryReport.GetFocusedRowCellValue(gridColumnSalaryMasterId).ToString();

                    bool result = await _salaryMasterRepository.DeleteSalary(salaryMasterId, id, true);

                    MessageBox.Show(AppMessages.GetString(AppMessageID.DeleteSuccessfully));
                }
                else if (MessageBox.Show(string.Format("Do you want to delete current record only?"), "[" + this.Text + "]", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    string id = grdViewSalaryReport.GetFocusedRowCellValue(gridColumnSalaryId).ToString();
                    string salaryMasterId = grdViewSalaryReport.GetFocusedRowCellValue(gridColumnSalaryMasterId).ToString();

                    bool result = await _salaryMasterRepository.DeleteSalary(salaryMasterId, id, false);

                    MessageBox.Show(AppMessages.GetString(AppMessageID.DeleteSuccessfully));
                }
            }
            else if (xtabManager.SelectedTabPage == xtraTabRejectionReport)
            {
                if (MessageBox.Show(string.Format("Do you want to delete current record only?"), "[" + this.Text + "]", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    string rejectionId = gridView13.GetFocusedRowCellValue(gridColumn115).ToString();

                    await _rejectionInOutMasterRepository.DeleteRejectionAsync(rejectionId);

                    MessageBox.Show(AppMessages.GetString(AppMessageID.DeleteSuccessfully), "Deleted Successfully");
                }
            }
            else if (xtabManager.SelectedTabPage == xtabJangadSendReceive)
            {
                if (MessageBox.Show(string.Format("Do you want to delete current record only?"), "[" + this.Text + "]", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    string jangadId = grvJangadSendReceive.GetFocusedRowCellValue(gridColumn1).ToString();

                    await _JangadMasterRepository.DeleteJangadAsync(jangadId);

                    MessageBox.Show(AppMessages.GetString(AppMessageID.DeleteSuccessfully), "Deleted Successfully");
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

            string Id = grvPurchaseSlipDetails.GetRowCellValue(grvPurchaseSlipDetails.FocusedRowHandle, "Id").ToString();
            string SlipNo = grvPurchaseSlipDetails.GetRowCellValue(grvPurchaseSlipDetails.FocusedRowHandle, "SlipNo").ToString();
            string FinancialYear = grvPurchaseSlipDetails.GetRowCellValue(grvPurchaseSlipDetails.FocusedRowHandle, "FinancialYearId").ToString();
            Transaction.FrmViewSlip fvs = new Transaction.FrmViewSlip(ActionType, SlipNo, FinancialYear, Id);
            if(fvs.ShowDialog() == DialogResult.Cancel)
            {
                _= LoadGridData(true);
            }

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
                    string approvestatus = grvTransMaster.GetRowCellValue(grvTransMaster.FocusedRowHandle, "ApprovalType").ToString();

                    if (approvestatus.ToLower() == "approved")
                    {
                        MessageBox.Show("This is already Approved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string Id = grvTransMaster.GetRowCellValue(grvTransMaster.FocusedRowHandle, "PurId").ToString();
                    var result = await _purchaseMasterRepository.UpdateApprovalStatus(Id, frmApproveReject.Comment, 1);
                }
                else if (xtabManager.SelectedTabPage == xtabSales)
                {
                    string approvestatus = grvSalesTransactonMaster.GetRowCellValue(grvSalesTransactonMaster.FocusedRowHandle, "ApprovalType").ToString();

                    if (approvestatus.ToLower() == "approved")
                    {
                        MessageBox.Show("This is already Approved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string Id = grvSalesTransactonMaster.GetRowCellValue(grvSalesTransactonMaster.FocusedRowHandle, "Id").ToString();
                    var result = await _salesMasterRepository.UpdateApprovalStatus(Id, frmApproveReject.Comment, 1);
                }
                else if (xtabManager.SelectedTabPage == xtabPayment)
                {
                    string approvestatus = gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "ApprovalType").ToString();

                    if (approvestatus.ToLower() == "approved")
                    {
                        MessageBox.Show("This is already Approved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string Id = gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "GroupId").ToString();
                    var result = await _paymentMasterRepository.UpdateApprovalStatus(Id, frmApproveReject.Comment, 1);
                }
                else if (xtabManager.SelectedTabPage == xtabReceipt)
                {
                    string approvestatus = gridView7.GetRowCellValue(gridView7.FocusedRowHandle, "ApprovalType").ToString();

                    if (approvestatus.ToLower() == "approved")
                    {
                        MessageBox.Show("This is already Approved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string Id = gridView7.GetRowCellValue(gridView7.FocusedRowHandle, "GroupId").ToString();
                    var result = await _paymentMasterRepository.UpdateApprovalStatus(Id, frmApproveReject.Comment, 1);
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
                    string approvestatus = grvTransMaster.GetRowCellValue(grvTransMaster.FocusedRowHandle, "ApprovalType").ToString();

                    if(approvestatus.ToLower() == "reject")
                    {
                        MessageBox.Show("This is already rejected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string Id = grvTransMaster.GetRowCellValue(grvTransMaster.FocusedRowHandle, "PurId").ToString();
                    var result = await _purchaseMasterRepository.UpdateApprovalStatus(Id, frmApproveReject.Comment, 2);
                }
                else if (xtabManager.SelectedTabPage == xtabSales)
                {
                    string approvestatus = grvSalesTransactonMaster.GetRowCellValue(grvSalesTransactonMaster.FocusedRowHandle, "ApprovalType").ToString();

                    if (approvestatus.ToLower() == "reject")
                    {
                        MessageBox.Show("This is already rejected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string Id = grvSalesTransactonMaster.GetRowCellValue(grvSalesTransactonMaster.FocusedRowHandle, "Id").ToString();
                    var result = await _salesMasterRepository.UpdateApprovalStatus(Id, frmApproveReject.Comment, 2);
                }
                else if (xtabManager.SelectedTabPage == xtabPayment)
                {
                    string approvestatus = gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "ApprovalType").ToString();

                    if (approvestatus.ToLower() == "reject")
                    {
                        MessageBox.Show("This is already rejected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string Id = gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "GroupId").ToString();
                    var result = await _paymentMasterRepository.UpdateApprovalStatus(Id, frmApproveReject.Comment, 2);
                }
                else if (xtabManager.SelectedTabPage == xtabReceipt)
                {
                    string approvestatus = gridView7.GetRowCellValue(gridView7.FocusedRowHandle, "ApprovalType").ToString();

                    if (approvestatus.ToLower() == "reject")
                    {
                        MessageBox.Show("This is already rejected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    string Id = gridView7.GetRowCellValue(gridView7.FocusedRowHandle, "GroupId").ToString();
                    var result = await _paymentMasterRepository.UpdateApprovalStatus(Id, frmApproveReject.Comment, 2);
                }

                _ = LoadGridData(true);
            }
        }

        private void grvTransMaster_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0 && e.Column == gridColumnPurApprovalType)
            {
                string priority = View.GetRowCellDisplayText(e.RowHandle, View.Columns["ApprovalType"]);
                if (priority.ToLower() == "pending" || priority.ToLower() == "0")
                {
                    if (e.Column == gridColumnPurApprovalType)
                    {
                        e.Appearance.ForeColor = Color.Black;
                    }
                    if (e.Column == gridColumnPurSlipNo)
                    {
                        e.Appearance.ForeColor = Color.Black;
                        e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Regular);
                    }
                    grvTransMaster.SetRowCellValue(e.RowHandle, "ApprovalType", "Pending");
                }
                if (priority.ToLower() == "approved" || priority.ToLower() == "1")
                {
                    if (e.Column == gridColumnPurApprovalType)
                    {
                        e.Appearance.ForeColor = Color.Green;
                    }
                    if (e.Column == gridColumnPurSlipNo)
                    {
                        e.Appearance.ForeColor = Color.Green;
                        e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                    }
                    grvTransMaster.SetRowCellValue(e.RowHandle, "ApprovalType", "Approved");
                }
                if (priority.ToLower() == "reject" || priority.ToLower() == "2")
                {
                    if (e.Column == gridColumnPurApprovalType)
                    {
                        e.Appearance.ForeColor = Color.Red;
                    }
                    if (e.Column == gridColumnPurSlipNo)
                    {
                        e.Appearance.ForeColor = Color.Red;
                        e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                    }
                    grvTransMaster.SetRowCellValue(e.RowHandle, "ApprovalType", "Reject");
                }
            }
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
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                string priority = View.GetRowCellDisplayText(e.RowHandle, View.Columns["ApprovalType"]);
                if (priority.ToLower() == "pending" || priority.ToLower() == "0")
                {
                    if (e.Column == colSalesApprovalType)
                    {
                        e.Appearance.ForeColor = Color.Black;
                    }
                    if (e.Column == colSalesSlispNo)
                    {
                        e.Appearance.ForeColor = Color.Black;
                        e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Regular);
                    }
                    grvSalesTransactonMaster.SetRowCellValue(e.RowHandle, "ApprovalType", "Pending");
                }
                if (priority.ToLower() == "approved" || priority.ToLower() == "1")
                {
                    if (e.Column == colSalesApprovalType)
                    {
                        e.Appearance.ForeColor = Color.Green;
                    }
                    if (e.Column == colSalesSlispNo)
                    {
                        e.Appearance.ForeColor = Color.Green;
                        e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                    }
                    grvSalesTransactonMaster.SetRowCellValue(e.RowHandle, "ApprovalType", "Approved");
                }
                if (priority.ToLower() == "reject" || priority.ToLower() == "2")
                {
                    if (e.Column == colSalesApprovalType)
                    {
                        e.Appearance.ForeColor = Color.Red;
                    }
                    if (e.Column == colSalesSlispNo)
                    {
                        e.Appearance.ForeColor = Color.Red;
                        e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                    }
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
            //GridView view = sender as GridView;
            //int id1 = Convert.ToInt32(view.GetRowCellValue(e.RowHandle1, view.Columns["SlipNo"]));
            //int id2 = Convert.ToInt32(view.GetRowCellValue(e.RowHandle2, view.Columns["SlipNo"]));
            //if (id1 != id2)
            //{
            //    e.Merge = false;
            //    e.Handled = true;
            //}
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

        private void grvTransMaster_MasterRowEmpty(object sender, MasterRowEmptyEventArgs e)
        {
            e.IsEmpty = false;
        }

        private void grvTransMaster_MasterRowGetChildList(object sender, MasterRowGetChildListEventArgs e)
        {
            GridView gridView = sender as GridView;
            PurchaseSPModel purchaseSPModel = gridView.GetRow(e.RowHandle) as PurchaseSPModel;
            if (purchaseSPModel != null)
            {
                var result = _purchaseMasterRepository.GetPurchaseDetailsAsync(purchaseSPModel.PurId);
                e.ChildList = result;
            }
        }

        private void grvTransMaster_MasterRowGetRelationCount(object sender, MasterRowGetRelationCountEventArgs e)
        {
            e.RelationCount = 1;
        }

        private void grvTransMaster_MasterRowGetRelationName(object sender, MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = "Child";
        }

        private void grvSalesTransactonMaster_MasterRowEmpty(object sender, MasterRowEmptyEventArgs e)
        {
            e.IsEmpty = false;
        }

        private void grvSalesTransactonMaster_MasterRowGetChildList(object sender, MasterRowGetChildListEventArgs e)
        {
            GridView gridView = sender as GridView;
            SalesSPModel salesDetails = gridView.GetRow(e.RowHandle) as SalesSPModel;
            if (salesDetails != null)
            {
                var result = _salesMasterRepository.GetSalesChild(salesDetails.Id);
                e.ChildList = result;
            }
        }

        private void grvSalesTransactonMaster_MasterRowGetRelationName(object sender, MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = "Child";
        }

        private void grvSalesTransactonMaster_MasterRowGetRelationCount(object sender, MasterRowGetRelationCountEventArgs e)
        {
            e.RelationCount = 1;
        }

        private void grvSalesTransactonMaster_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                GridColumnSummaryItem item = e.Item as GridColumnSummaryItem;
                double Total = double.Parse(view.Columns["GrossTotal"].SummaryText);
                double saleRate = double.Parse(view.Columns["NetWeight"].SummaryText);
                e.TotalValue = (Total / saleRate).ToString("0");
            }
            catch (Exception)
            {
                e.TotalValue = 0;
            }
        }

        private void grvTransMaster_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            try
            {
                if (e.IsTotalSummary)
                {
                    switch (e.SummaryProcess)
                    {
                        case DevExpress.Data.CustomSummaryProcess.Finalize:
                            decimal Total = Convert.ToDecimal(gridColumnGrossTotal.SummaryItem.SummaryValue);
                            decimal BuyRate = Convert.ToDecimal(NetWeight.SummaryItem.SummaryValue);
                            e.TotalValue = (Total / BuyRate).ToString("0");
                            break;
                    }
                }
            }
            catch (Exception)
            {
                e.TotalValue = 0;
            }
        }

        private void grvSalesTransactonMaster_RowStyle(object sender, RowStyleEventArgs e)
        {
            //GridView View = sender as GridView;
            //if (e.RowHandle >= 0)
            //{
            //    string priority = View.GetRowCellDisplayText(e.RowHandle, View.Columns["ApprovalType"]);
            //    if (priority.ToLower() == "approved" || priority.ToLower() == "1")
            //    {
            //        e.Appearance.BackColor = Color.Green;
            //        e.Appearance.BackColor2 = Color.Green;
            //        e.HighPriority = true;
            //    }
            //}
        }

        private void gridView2_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column == colCashBankCredit)
                if (Convert.ToDecimal(e.Value) == 0) e.DisplayText = "";
            if (e.Column == colCashBankDebit)
                if (Convert.ToDecimal(e.Value) == 0) e.DisplayText = "";
        }

        private void gridView4_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0 && e.Column == gridColumnApprovalType)
            {
                string priority = View.GetRowCellDisplayText(e.RowHandle, View.Columns["ApprovalType"]);
                if (priority.ToLower() == "pending" || priority.ToLower() == "0")
                {

                    e.Appearance.ForeColor = Color.Black;

                    gridView4.SetRowCellValue(e.RowHandle, "ApprovalType", "Pending");
                }
                if (priority.ToLower() == "approved" || priority.ToLower() == "1")
                {
                    e.Appearance.ForeColor = Color.Green;

                    gridView4.SetRowCellValue(e.RowHandle, "ApprovalType", "Approved");
                }
                if (priority.ToLower() == "reject" || priority.ToLower() == "2")
                {
                    e.Appearance.ForeColor = Color.Red;


                    gridView4.SetRowCellValue(e.RowHandle, "ApprovalType", "Reject");
                }
            }
        }

        private void gridView4_RowStyle(object sender, RowStyleEventArgs e)
        {

        }

        private async void gridView4_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            string ApprovalType = gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "ApprovalType").ToString();
            if (ApprovalType.Equals("Pending"))
            {
                //var IsHavingApprovalPermission = Common.UserPermissionChildren.Where(x => x.KeyName.Equals("approval_master"));
                ApprovalPermissionMasterRepository approvalPermissionMasterRepository = new ApprovalPermissionMasterRepository();

                var result = await approvalPermissionMasterRepository.GetPermission();
                var IsHavingApprovalPermission = result.Where(w => w.KeyName == "payment_approval").FirstOrDefault();

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

        private void gridView7_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0 && e.Column == gridColumnReceiptApprovalType)
            {
                string priority = View.GetRowCellDisplayText(e.RowHandle, View.Columns["ApprovalType"]);
                if (priority.ToLower() == "pending" || priority.ToLower() == "0")
                {
                    e.Appearance.ForeColor = Color.Black;
                    gridView7.SetRowCellValue(e.RowHandle, "ApprovalType", "Pending");
                }
                if (priority.ToLower() == "approved" || priority.ToLower() == "1")
                {
                    e.Appearance.ForeColor = Color.Green;
                    gridView7.SetRowCellValue(e.RowHandle, "ApprovalType", "Approved");
                }
                if (priority.ToLower() == "reject" || priority.ToLower() == "2")
                {
                    e.Appearance.ForeColor = Color.Red;
                    gridView7.SetRowCellValue(e.RowHandle, "ApprovalType", "Reject");
                }
            }
        }

        private async void gridView7_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            string ApprovalType = gridView7.GetRowCellValue(gridView7.FocusedRowHandle, "ApprovalType").ToString();
            if (ApprovalType.Equals("Pending"))
            {
                //var IsHavingApprovalPermission = Common.UserPermissionChildren.Where(x => x.KeyName.Equals("approval_master"));
                ApprovalPermissionMasterRepository approvalPermissionMasterRepository = new ApprovalPermissionMasterRepository();

                var result = await approvalPermissionMasterRepository.GetPermission();
                var IsHavingApprovalPermission = result.Where(w => w.KeyName == "receipt_approval").FirstOrDefault();

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

        private void button1_Click(object sender, EventArgs e)
        {
            accordionRefreshBtn_Click(sender, e);
        }

        private void btnSalesSearch_Click(object sender, EventArgs e)
        {
            accordionRefreshBtn_Click(sender, e);
        }

        private void btnPaymentGetData_Click(object sender, EventArgs e)
        {
            accordionRefreshBtn_Click(sender, e);
        }

        private void btnReceiptGetData_Click(object sender, EventArgs e)
        {
            accordionRefreshBtn_Click(sender, e);
        }

        private void btnContraGetData_Click(object sender, EventArgs e)
        {
            accordionRefreshBtn_Click(sender, e);
        }

        private void btnExpenseGetData_Click(object sender, EventArgs e)
        {
            accordionRefreshBtn_Click(sender, e);
        }

        private void btnMixedGetData_Click(object sender, EventArgs e)
        {
            accordionRefreshBtn_Click(sender, e);
        }

        private void btnCashBankGetData_Click(object sender, EventArgs e)
        {
            accordionRefreshBtn_Click(sender, e);
        }

        private void accordionExportToExcel_Click(object sender, EventArgs e)
        {
            ExportGridData(ExportDataType.Excel);
        }

        private void accordionExportToPdf_Click(object sender, EventArgs e)
        {
            ExportGridData(ExportDataType.PDF);
        }

        private void accordionPrint_Click(object sender, EventArgs e)
        {
            ExportGridData(ExportDataType.Print);
        }

        private void grvLedgerReport_DoubleClick(object sender, EventArgs e)
        {
            string LedgerType = ((LedgerBalanceSPModel)grvLedgerReport.GetFocusedRow()).Type;

            int partyType = ((LedgerBalanceSPModel)grvLedgerReport.GetFocusedRow()).PartyType;

            FromChildLedgerReport fromChildLedgerReport = new FromChildLedgerReport(((LedgerBalanceSPModel)grvLedgerReport.GetFocusedRow()).LedgerId, LedgerType, partyType);
            fromChildLedgerReport.Text = "Ledger Child Report - " + ((LedgerBalanceSPModel)grvLedgerReport.GetFocusedRow()).Name;
            fromChildLedgerReport.StartPosition = FormStartPosition.CenterScreen;
            fromChildLedgerReport.ShowDialog();

        }

        private void grvPurchaseSlipDetails_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView view = sender as GridView;

            if (e.RowHandle >= 0)
            {
                bool status = Convert.ToBoolean(view.GetRowCellValue(e.RowHandle, view.Columns[colPurchaseSlipPrint.FieldName]));

                if (status)
                {
                    e.Appearance.BackColor = Color.Green;
                    e.Appearance.ForeColor = Color.White;
                }
                else
                {
                    e.Appearance.BackColor = Color.White;
                    e.Appearance.ForeColor = Color.Black;
                }
            }
        }

        private void repoApproveButton_Click(object sender, EventArgs e)
        {
            btnApprove_ItemClick(sender, null);
        }

        private void repoRejectButton_Click(object sender, EventArgs e)
        {
            btnReject_ItemClick(sender,null);
        }

        private void repoPurRejectButton_Click(object sender, EventArgs e)
        {
            btnReject_ItemClick(sender, null);
        }

        private void repoPurApproveButton_Click(object sender, EventArgs e)
        {
            btnApprove_ItemClick(sender, null);
        }

        private void repoPayApproveButton_Click(object sender, EventArgs e)
        {
            btnApprove_ItemClick(sender, null);
        }

        private void repoPayRejectButtonCol_Click(object sender, EventArgs e)
        {
            btnReject_ItemClick(sender, null);
        }

        private void repoReceApproveButton_Click(object sender, EventArgs e)
        {
            btnApprove_ItemClick(sender, null);
        }

        private void repoReceRejectButton_Click(object sender, EventArgs e)
        {
            btnReject_ItemClick(sender, null);
        }
    }
}