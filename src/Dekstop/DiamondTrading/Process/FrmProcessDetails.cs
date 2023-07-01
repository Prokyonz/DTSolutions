using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DiamondTrading.Process;
using EFCore.SQL.Repository;
using Repository.Entities;
using Repository.Entities.Model;
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
        private KapanMappingMasterRepository _kapanMappingMasterRepository;
        private AccountToAssortMasterRepository _accountToAssortMasterRepository;
        private BoilMasterRepository _boilMasterRepository;
        private CharniProcessMasterRepository _charniProcessMasterRepository;
        private GalaProcessMasterRepository _galaProcessMasterRepository;
        private NumberProcessMasterRepository _numberProcessMasterRepository;
        private OpeningStockMasterRepositody _openingStockMasterRepositody;

        private List<PurchaseMaster> _purchaseMaster;
        private List<SalesMaster> _salesMaster;
        private List<StockReportModelReport> stockReportModelReports;
        private List<NumberReportModelReport> numberReportModelReports;

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
                    xtabKapanMapping.Text = this.Text = "Kapan Details";
                    break;
                case "AssortSend":
                    xtabAssortSend.PageVisible = true;
                    xtabManager.SelectedTabPage = xtabAssortSend;
                    xtabAssortSend.Text = this.Text = "Assort Send";
                    break;
                case "AssortReceive":
                    xtabAssortReceive.PageVisible = true;
                    xtabManager.SelectedTabPage = xtabAssortReceive;
                    xtabAssortReceive.Text = this.Text = "Assort Receive";
                    break;
                case "BoilSend":
                    xtabBoilSendReceive.PageVisible = true;
                    xtabManager.SelectedTabPage = xtabBoilSendReceive;
                    xtabBoilSendReceive.Text = this.Text = "Boil Send";
                    break;
                case "BoilReceive":
                    xtabBoilSendReceive.PageVisible = true;
                    xtabManager.SelectedTabPage = xtabBoilSendReceive;
                    xtabBoilSendReceive.Text = this.Text = "Boil Receive";
                    break;
                case "CharniSend":
                    xtabCjharniSendReceive.PageVisible = true;
                    xtabManager.SelectedTabPage = xtabCjharniSendReceive;
                    xtabCjharniSendReceive.Text = this.Text = "Charni Send";
                    break;
                case "CharniReceive":
                    xtabCjharniSendReceive.PageVisible = true;
                    xtabManager.SelectedTabPage = xtabCjharniSendReceive;
                    xtabCjharniSendReceive.Text = this.Text = "Charni Receive";
                    break;

                case "GalaSend":
                    xtabGalaSendReceive.PageVisible = true;
                    xtabManager.SelectedTabPage = xtabGalaSendReceive;
                    xtabGalaSendReceive.Text = this.Text = "Gala Send";
                    break;
                case "GalaReceive":
                    xtabGalaSendReceive.PageVisible = true;
                    xtabManager.SelectedTabPage = xtabGalaSendReceive;
                    xtabGalaSendReceive.Text = this.Text = "Gala Receive";
                    break;

                case "NumberSend":
                    xtabNumberSendReceive.PageVisible = true;
                    xtabManager.SelectedTabPage = xtabNumberSendReceive;
                    xtabNumberSendReceive.Text = this.Text = "Number Send";
                    break;
                case "NumberReceive":
                    xtabNumberSendReceive.PageVisible = true;
                    xtabManager.SelectedTabPage = xtabNumberSendReceive;
                    xtabNumberSendReceive.Text = this.Text = "Number Receive";
                    break;

                case "StockReport":
                    xtraTabStockReport.PageVisible = true;
                    xtabManager.SelectedTabPage = xtraTabStockReport;
                    xtraTabStockReport.Text = this.Text = "Stock Report";
                    break;
                case "OpeningStockReport":
                    xtraOpeningStock.PageVisible = true;
                    xtabManager.SelectedTabPage = xtraOpeningStock;
                    xtraOpeningStock.Text = this.Text = "Opening Stock Report";
                    break;

                default:
                    xtabKapanMapping.PageVisible = true;
                    xtabManager.SelectedTabPage = xtabKapanMapping;
                    xtabKapanMapping.Text = this.Text = "Kapan Mapping";
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
            xtraTabStockReport.PageVisible = false;
            xtraOpeningStock.PageVisible = false;
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
                Transaction.FrmSalesEntry frmSalesEntry = new Transaction.FrmSalesEntry();
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

        private async Task LoadGridData(bool IsForceLoad = false)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (xtabManager.SelectedTabPage == xtabKapanMapping)
                {
                    if (IsForceLoad || _kapanMappingMasterRepository == null)
                    {
                        _kapanMappingMasterRepository = new KapanMappingMasterRepository();
                        var kapanData = await _kapanMappingMasterRepository.GetKapanMappingReport(Common.LoginCompany, Common.LoginBranch, Common.LoginFinancialYear);
                        grdProcessMaster.DataSource = kapanData.OrderBy(o => o.SlipNo);
                        accordionEditBtn.Visible = true;
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
                else if (xtabManager.SelectedTabPage == xtabBoilSendReceive)
                {
                    if (IsForceLoad || _boilMasterRepository == null)
                    {
                        _boilMasterRepository = new BoilMasterRepository();
                        var data = await _boilMasterRepository.GetBoilSendReceiveReports(Common.LoginCompany, Common.LoginBranch, Common.LoginFinancialYear, SelectedTabPage == "BoilSend" ? 0 : 1);
                        gridControlBoilSendReceiveMaster.DataSource = data;
                    }
                }
                else if (xtabManager.SelectedTabPage == xtabCjharniSendReceive)
                {
                    if (IsForceLoad || _charniProcessMasterRepository == null)
                    {
                        int type = SelectedTabPage == "CharniSend" ? 0 : 1;
                        _charniProcessMasterRepository = new CharniProcessMasterRepository();
                        var data = await _charniProcessMasterRepository.GetCharniSendReceiveReports(Common.LoginCompany, Common.LoginBranch, Common.LoginFinancialYear, type);
                        gridControlCharniReportMaster.DataSource = data;
                        if (type == 0)
                            gridColumn80.Visible = false;
                        else
                            gridColumn80.Visible = true;
                    }
                }
                else if (xtabManager.SelectedTabPage == xtabGalaSendReceive)
                {
                    if (IsForceLoad || _galaProcessMasterRepository == null)
                    {
                        _galaProcessMasterRepository = new GalaProcessMasterRepository();
                        int type = SelectedTabPage == "GalaSend" ? 0 : 1;
                        var data = await _galaProcessMasterRepository.GetGalaSendReceiveReports(Common.LoginCompany, Common.LoginBranch, Common.LoginFinancialYear, type);
                        gridControlGalaReportMaster.DataSource = data;
                        if (type == 0)
                            gridColumn108.Visible = false;
                        else
                            gridColumn108.Visible = true;
                    }
                }
                else if (xtabManager.SelectedTabPage == xtabNumberSendReceive)
                {
                    if (IsForceLoad || _numberProcessMasterRepository == null)
                    {
                        int type = SelectedTabPage == "NumberSend" ? 0 : 1;
                        _numberProcessMasterRepository = new NumberProcessMasterRepository();
                        var data = await _numberProcessMasterRepository.GetNumberSendReceiveReports(Common.LoginCompany, Common.LoginBranch, Common.LoginFinancialYear, type);
                        gridControlNumerReportMaster.DataSource = data;
                        if (type == 0)
                        {
                            gridColumn135.Visible = false;
                            gridColumn137.Visible = false;
                        }
                        else
                        {
                            gridColumn135.Visible = true;
                            gridColumn137.Visible = true;
                        }
                    }
                }
                else if (xtabManager.SelectedTabPage == xtraTabStockReport)
                {
                    if (IsForceLoad || _accountToAssortMasterRepository == null)
                    {
                        stockReportModelReports = await LoadDataStock();
                        numberReportModelReports = await LoadDataNumber();

                        decimal inwardAmount = 0;
                        decimal inwardWeight = 0;
                        decimal inwardRate = 0;

                        decimal outwardAmount = 0;
                        decimal outwardWeight = 0;
                        decimal outwardRate = 0;

                        if (stockReportModelReports.Count > 0)
                        {
                            inwardAmount = stockReportModelReports.Sum(s => s.InwardAmount);
                            inwardWeight = stockReportModelReports.Sum(s => s.InwardNetWeight);
                            inwardRate = stockReportModelReports.Average(a => a.InwardRate);

                            outwardAmount = stockReportModelReports.Sum(s => s.OutwardAmount);
                            outwardWeight = stockReportModelReports.Sum(s => s.OutwardNetWeight);
                            outwardRate = stockReportModelReports.Sum(s => s.OutwardRate);
                        }

                        decimal inwardAmountN = 0;
                        decimal inwardWeightN = 0;
                        decimal inwardRateN = 0;

                        decimal outwardAmountN = 0;
                        decimal outwardWeightN = 0;
                        decimal outwardRateN = 0;
                        if (numberReportModelReports.Count > 0)
                        {
                            inwardAmountN = numberReportModelReports.Sum(s => s.InwardAmount);
                            inwardWeightN = numberReportModelReports.Sum(s => s.InwardNetWeight);
                            inwardRateN = numberReportModelReports.Average(a => a.InwardRate);

                            outwardAmountN = numberReportModelReports.Sum(s => s.OutwardAmount);
                            outwardWeightN = numberReportModelReports.Sum(s => s.OutwardNetWeight);
                            outwardRateN = numberReportModelReports.Sum(s => s.OutwardRate);
                        }
                        //_accountToAssortMasterRepository = new AccountToAssortMasterRepository();
                        //var salesData = await _accountToAssortMasterRepository.GetStockReportAsync(Common.LoginCompany, Common.LoginFinancialYear);


                        List<StockReportMasterGrid> stockReportMasterGrids = new List<StockReportMasterGrid>()
                    {
                        new StockReportMasterGrid()
                        {
                            Id = 1,
                            Name = "Kapan",
                            Rate = Math.Round((inwardRate - outwardRate),2),
                            TotalWeight = inwardWeight - outwardWeight,
                            TotalAmount = inwardAmount - outwardAmount
                        },
                        new StockReportMasterGrid()
                        {
                            Id = 2,
                            Name = "Number",
                            Rate = Math.Round(inwardRateN - outwardRateN,2),
                            TotalWeight = inwardWeightN - outwardWeightN,
                            TotalAmount = inwardAmountN - outwardAmountN
                        },
                    };

                        grdStockReportMaster.DataSource = stockReportMasterGrids;//.OrderBy(o => o.Kapan);

                        gvStockReport.RestoreLayoutFromRegistry(RegistryHelper.ReportLayouts("MasterStockReport"));
                    }
                }
                else if (xtabManager.SelectedTabPage == xtraOpeningStock)
                {
                    if (IsForceLoad || _openingStockMasterRepositody == null)
                    {
                        _openingStockMasterRepositody = new OpeningStockMasterRepositody();
                        var Data = await _openingStockMasterRepositody.GetAllOpeningStockAsync(Common.LoginCompany, Common.LoginFinancialYear);
                        gridControlOpeningStock.DataSource = Data.OrderBy(o => o.SrNo);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(AppMessages.GetString(AppMessageID.Error), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void ExportGridData(ExportDataType exportType)
        {
            if (xtabManager.SelectedTabPage == xtabKapanMapping)
            {
                if (exportType == ExportDataType.Excel)
                {
                    ExportToExcel(grvKapanMapping);
                }
            }
            else if (xtabManager.SelectedTabPage == xtabAssortSend)
            {
                if (exportType == ExportDataType.Excel)
                {
                    ExportToExcel(grvAssortSendReceiveMaster);
                }
            }
            else if (xtabManager.SelectedTabPage == xtabAssortReceive)
            {
                if (exportType == ExportDataType.Excel)
                {
                    ExportToExcel(grvAssortReceiveMaster);
                }
            }
            else if (xtabManager.SelectedTabPage == xtabBoilSendReceive)
            {
                if (exportType == ExportDataType.Excel)
                {
                    ExportToExcel(gridViewBoilSendReceiveMaster);
                }
            }
            else if (xtabManager.SelectedTabPage == xtabCjharniSendReceive)
            {
                if (exportType == ExportDataType.Excel)
                {
                    ExportToExcel(gridViewCharniReportMaster);
                }
            }
            else if (xtabManager.SelectedTabPage == xtabGalaSendReceive)
            {
                if (exportType == ExportDataType.Excel)
                {
                    ExportToExcel(gridViewGalaReportMaster);
                }
            }
            else if (xtabManager.SelectedTabPage == xtabNumberSendReceive)
            {
                if (exportType == ExportDataType.Excel)
                {
                    ExportToExcel(gridViewNumberReportMaster);
                }
            }
            else if (xtabManager.SelectedTabPage == xtraTabStockReport)
            {
                if (exportType == ExportDataType.Excel)
                {
                    ExportToExcel(gvStockReport);
                }
            }
            else if (xtabManager.SelectedTabPage == xtraOpeningStock)
            {
                if (exportType == ExportDataType.Excel)
                {
                    ExportToExcel(grvOpeningStock);
                }
            }
        }

        private async void accordionEditBtn_Click(object sender, EventArgs e)
        {
            if (xtabManager.SelectedTabPage == xtabKapanMapping)
            {
                string SelectedSrNo = grvKapanMapping.GetFocusedRowCellValue("Sr").ToString();
                string PurchaseDetailsId = grvKapanMapping.GetFocusedRowCellValue("PurchaseDetailsId").ToString();
                string SlipNo = grvKapanMapping.GetFocusedRowCellValue("SlipNo").ToString();
                _accountToAssortMasterRepository = new AccountToAssortMasterRepository();
                var result = await _accountToAssortMasterRepository.CheckIsKapanMapEntryProcessed(Common.LoginCompany, Common.LoginFinancialYear, PurchaseDetailsId, SlipNo);

                if(result)
                {
                    MessageBox.Show("You can't edit this Slip as it's already processed.", "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Process.FrmKapanMap frmKapanMap = new Process.FrmKapanMap(SelectedSrNo);

                if (frmKapanMap.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
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
                if (MessageBox.Show(string.Format(AppMessages.GetString(AppMessageID.DleteExpenseConfirmation), "Do you want to delete this record?"), "[" + this.Text + "]", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Cursor = Cursors.WaitCursor;
                    string message = "";
                    string SelectedGuid = grvKapanMapping.GetFocusedRowCellValue(gridColumnKapanMapingId).ToString();

                    if (SelectedGuid != null)
                    {
                        var result = await _kapanMappingMasterRepository.DeleteKapanMappingAsync(SelectedGuid.ToString());

                        if (result)
                        {
                            await LoadGridData(true);
                            message = AppMessages.GetString(AppMessageID.DeleteSuccessfully);
                        }
                        else
                        {
                            message = "You can not delete this record because some quantity is transfered.";
                        }
                    }
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(message);
                }

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
                if (MessageBox.Show(string.Format(AppMessages.GetString(AppMessageID.DleteExpenseConfirmation), "Do you want to delete this record?"), "[" + this.Text + "]", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Cursor = Cursors.WaitCursor;
                    string message = "";
                    string SelectedGuid = grvAssortSendReceiveMaster.GetFocusedRowCellValue(gridColumnAssortSendId).ToString();
                    string AccountToAssortChildId = grvAssortSendReceiveMaster.GetFocusedRowCellValue(gridColumnChildId).ToString();
                    string slipNo = grvAssortSendReceiveMaster.GetFocusedRowCellValue(gridColumnAssortSendSlipNo).ToString();
                    if (SelectedGuid != null && AccountToAssortChildId != null)
                    {
                        var result = await _accountToAssortMasterRepository.DeleteAccountToAssortAsync(SelectedGuid.ToString(), AccountToAssortChildId, slipNo);

                        if (result)
                        {
                            await LoadGridData(true);
                            message = AppMessages.GetString(AppMessageID.DeleteSuccessfully);
                        }
                        else
                        {
                            message = "You can not delete this record because child record is available in boil send.";
                        }
                    }
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(message);
                }
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

        private void gridViewCharniReportMaster_CellMerge(object sender, CellMergeEventArgs e)
        {
            GridView view = sender as GridView;
            int id1 = Convert.ToInt32(view.GetRowCellValue(e.RowHandle1, view.Columns["CharniNo"]));
            int id2 = Convert.ToInt32(view.GetRowCellValue(e.RowHandle2, view.Columns["CharniNo"]));
            if (id1 != id2)
            {
                e.Merge = false;
                e.Handled = true;
            }
        }

        private void gridViewNumberReportMaster_CellMerge(object sender, CellMergeEventArgs e)
        {
            GridView view = sender as GridView;
            int id1 = Convert.ToInt32(view.GetRowCellValue(e.RowHandle1, view.Columns["NumberNo"]));
            int id2 = Convert.ToInt32(view.GetRowCellValue(e.RowHandle2, view.Columns["NumberNo"]));
            if (id1 != id2)
            {
                e.Merge = false;
                e.Handled = true;
            }
        }

        private void gridViewGalaReportMaster_CellMerge(object sender, CellMergeEventArgs e)
        {
            GridView view = sender as GridView;
            int id1 = Convert.ToInt32(view.GetRowCellValue(e.RowHandle1, view.Columns["GalaNo"]));
            int id2 = Convert.ToInt32(view.GetRowCellValue(e.RowHandle2, view.Columns["GalaNo"]));
            if (id1 != id2)
            {
                e.Merge = false;
                e.Handled = true;
            }
        }

        private void gridViewBoilSendReceiveMaster_CellMerge(object sender, CellMergeEventArgs e)
        {
            GridView view = sender as GridView;
            int id1 = Convert.ToInt32(view.GetRowCellValue(e.RowHandle1, view.Columns["BoilNo"]));
            int id2 = Convert.ToInt32(view.GetRowCellValue(e.RowHandle2, view.Columns["BoilNo"]));
            if (id1 != id2)
            {
                e.Merge = false;
                e.Handled = true;
            }
        }

        private void grvAssortReceiveMaster_CellMerge(object sender, CellMergeEventArgs e)
        {
            GridView view = sender as GridView;
            int id1 = Convert.ToInt32(view.GetRowCellValue(e.RowHandle1, view.Columns["JangadNo"]));
            int id2 = Convert.ToInt32(view.GetRowCellValue(e.RowHandle2, view.Columns["JangadNo"]));
            if (id1 != id2)
            {
                e.Merge = false;
                e.Handled = true;
            }
        }

        private void gvStockReport_CellMerge(object sender, CellMergeEventArgs e)
        {
            GridView view = sender as GridView;
            string id1 = Convert.ToString(view.GetRowCellValue(e.RowHandle1, view.Columns["KapanId"]));
            string id2 = Convert.ToString(view.GetRowCellValue(e.RowHandle2, view.Columns["KapanId"]));
            if (id1 != id2)
            {
                e.Merge = false;
                e.Handled = true;
            }
        }

        private void grvOpeningStock_CellMerge(object sender, CellMergeEventArgs e)
        {
            GridView view = sender as GridView;
            string id1 = Convert.ToString(view.GetRowCellValue(e.RowHandle1, view.Columns["SrNo"]));
            string id2 = Convert.ToString(view.GetRowCellValue(e.RowHandle2, view.Columns["SrNo"]));
            if (id1 != id2)
            {
                e.Merge = false;
                e.Handled = true;
            }
        }

        private async void grdStockReportMaster_DoubleClick(object sender, EventArgs e)
        {
            string id = gvStockReport.GetFocusedRowCellValue(grdColId).ToString();
            
            if(id == "1")
            {
                FrmChildStockReport frmChildStockReport = new FrmChildStockReport(stockReportModelReports);
                frmChildStockReport.Text = "Kapan Child Report";
                frmChildStockReport.StartPosition = FormStartPosition.CenterScreen;
                frmChildStockReport.ShowDialog();

            } else if(id == "2") {

                FrmChildNumberReport frmChildNumberReport = new FrmChildNumberReport(numberReportModelReports);
                frmChildNumberReport.Text = "Number Child Report";
                frmChildNumberReport.StartPosition = FormStartPosition.CenterScreen;
                frmChildNumberReport.ShowDialog();
            }            
        }

        public async Task<List<StockReportModelReport>> LoadDataStock()
        {
            _accountToAssortMasterRepository = new AccountToAssortMasterRepository();
            return await _accountToAssortMasterRepository.GetStockReportAsync(Common.LoginCompany, Common.LoginFinancialYear);            
        }

        public async Task<List<NumberReportModelReport>> LoadDataNumber()
        {
            _accountToAssortMasterRepository = new AccountToAssortMasterRepository();
            return await _accountToAssortMasterRepository.GetNumberReportAsync(Common.LoginCompany, Common.LoginFinancialYear);
        }

        private void FrmProcessDetails_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (xtabManager.SelectedTabPage == xtraTabStockReport)
            {
                gvStockReport.SaveLayoutToRegistry(RegistryHelper.ReportLayouts("MasterStockReport"));
            }
        }

        private void accordionExportToExcel_Click(object sender, EventArgs e)
        {
            ExportGridData(ExportDataType.Excel);
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
    }
}