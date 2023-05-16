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
    public partial class FrmMasterDetails : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWorkMaster _unitOfWorkMaster;
        private CompanyMasterRepository _companyMasterRepository;
        private BranchMasterRepository _branchMasterRepository;
        private LessWeightMasterRepository _lessWeightMasterRepository;
        private ShapeMasterRepository _shapeMasterRepository;
        private PurityMasterRepository _purityMasterRepository;
        private SizeMasterRepository _sizeMasterRepository;
        private GalaMasterRepository _galaMasterRepository;
        private NumberMasterRepository _numberMasterRepository;
        private FinancialYearMasterRepository _financialYearMasterRepository;
        private BrokerageMasterRepository _brokerageMasterRepository;
        private CurrencyMasterRepository _currencyMasterRepository;
        private KapanMasterRepository _kapanMasterRepository;
        private PartyMasterRepository _partyMasterRepository;
        private UserMasterRepository _userMasterRepository;

        private List<CompanyMaster> _companyMaster;
        private List<BranchMaster> _branchMaster;
        private List<LessWeightMaster> _lessWeightMaster;
        private List<ShapeMaster> _shapeMaster;
        private List<PurityMaster> _purityMaster;
        private List<SizeMaster> _sizeMaster;
        private List<GalaMaster> _galaMaster;
        private List<NumberMaster> _numberMaster;
        private List<FinancialYearMaster> _financialYearMaster;
        private List<BrokerageMaster> _brokerageMaster;
        private List<CurrencyMaster> _currencyMaster;
        private List<KapanMaster> _kapanMaster;
        private List<PartyMaster> _partyMaster;
        private List<UserMaster> _userMaster;

        public FrmMasterDetails()
        {
            InitializeComponent();
            _unitOfWorkMaster = new UnitOfWorkMaster();
        }

        public void ActiveTab()
        {
            HideAllTabs();
            switch (SelectedTabPage)
            {
                case "CompanyMaster":
                    xtabCompanyMaster.PageVisible = true;
                    xtabMasterDetails.SelectedTabPage = xtabCompanyMaster;
                    this.Text = "Company Master";
                    break;
                case "BranchMaster":
                    xtabBranchMaster.PageVisible = true;
                    xtabMasterDetails.SelectedTabPage = xtabBranchMaster;
                    this.Text = "Branch Master";
                    break;
                case "LessWeightGroupMaster":
                    xtabLessWeightGroupMaster.PageVisible = true;
                    xtabMasterDetails.SelectedTabPage = xtabLessWeightGroupMaster;
                    this.Text = "Less Weight Group Master";
                    break;
                case "ShapeMaster":
                    xtabShapeMaster.PageVisible = true;
                    xtabMasterDetails.SelectedTabPage = xtabShapeMaster;
                    this.Text = "Shape Master";
                    break;
                case "PurityMaster":
                    xtabPurityMaster.PageVisible = true;
                    xtabMasterDetails.SelectedTabPage = xtabPurityMaster;
                    this.Text = "Purity Master";
                    break;
                case "SizeMaster":
                    xtabSizeMaster.PageVisible = true;
                    xtabMasterDetails.SelectedTabPage = xtabSizeMaster;
                    this.Text = "Size Master";
                    break;
                case "GalaMaster":
                    xtabGalaMaster.PageVisible = true;
                    xtabMasterDetails.SelectedTabPage = xtabGalaMaster;
                    this.Text = "Gala Master";
                    break;
                case "NumberMaster":
                    xtabNumberMaster.PageVisible = true;
                    xtabMasterDetails.SelectedTabPage = xtabNumberMaster;
                    this.Text = "Number Master";
                    break;
                case "FinancialYearMaster":
                    xtabFinancialYearMaster.PageVisible = true;
                    xtabMasterDetails.SelectedTabPage = xtabFinancialYearMaster;
                    this.Text = "Financial Master";
                    break;
                case "BrokerageMaster":
                    xtabBrokerageMaster.PageVisible = true;
                    xtabMasterDetails.SelectedTabPage = xtabBrokerageMaster;
                    this.Text = "Brokerage Master";
                    break;
                case "CurrencyMaster":
                    xtabCurrencyMaster.PageVisible = true;
                    xtabMasterDetails.SelectedTabPage = xtabCurrencyMaster;
                    this.Text = "Currency Master";
                    break;
                case "KapanMaster":
                    xtabKapanMaster.PageVisible = true;
                    xtabMasterDetails.SelectedTabPage = xtabKapanMaster;
                    this.Text = "Kapan Master";
                    break;
                case "LedgerMaster":
                    xtabLedgerMaster.PageVisible = true;
                    xtabMasterDetails.SelectedTabPage = xtabLedgerMaster;
                    this.Text = "Party Master";
                    break;
                case "UserMaster":
                    xtabUserMaster.PageVisible = true;
                    xtabMasterDetails.SelectedTabPage = xtabUserMaster;
                    this.Text = "User Master";
                    break;
                default:
                    xtabCompanyMaster.PageVisible = true;
                    xtabMasterDetails.SelectedTabPage = xtabCompanyMaster;
                    this.Text = "Company Master";
                    break;
            }
        }

        public string SelectedTabPage { get; set; }
        private void HideAllTabs()
        {
            xtabCompanyMaster.PageVisible = false;
            xtabBranchMaster.PageVisible = false;
            xtabLessWeightGroupMaster.PageVisible = false;
            xtabShapeMaster.PageVisible = false;
            xtabPurityMaster.PageVisible = false;
            xtabSizeMaster.PageVisible = false;
            xtabGalaMaster.PageVisible = false;
            xtabNumberMaster.PageVisible = false;
            xtabFinancialYearMaster.PageVisible = false;
            xtabBrokerageMaster.PageVisible = false;
            xtabCurrencyMaster.PageVisible = false;
            xtabKapanMaster.PageVisible = false;
            xtabLedgerMaster.PageVisible = false;
            xtabUserMaster.PageVisible = false;
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private async void accordianAddBtn_Click(object sender, EventArgs e)
        {
            if (xtabMasterDetails.SelectedTabPage == xtabCompanyMaster)
            {
                Master.FrmCompanyMaster frmcompanymaster = new Master.FrmCompanyMaster(_companyMaster);
                if (frmcompanymaster.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabBranchMaster)
            {
                Master.FrmBranchMaster frmBranchMaster = new Master.FrmBranchMaster(_branchMaster);
                if (frmBranchMaster.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabLessWeightGroupMaster)
            {
                Master.FrmLessWeightGroupMaster frmLessWeightGroupMaster = new Master.FrmLessWeightGroupMaster(_lessWeightMaster);
                if (frmLessWeightGroupMaster.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabShapeMaster)
            {
                Master.FrmShapeMaster frmShapeMaster = new Master.FrmShapeMaster(_shapeMaster);
                if (frmShapeMaster.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabPurityMaster)
            {
                Master.FrmPurityMaster frmPurityMaster = new Master.FrmPurityMaster(_purityMaster);
                if (frmPurityMaster.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabSizeMaster)
            {
                Master.FrmSizeMaster frmSizeMaster = new Master.FrmSizeMaster(_sizeMaster);
                if (frmSizeMaster.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabGalaMaster)
            {
                Master.FrmGalaMaster frmGalaMaster = new Master.FrmGalaMaster(_galaMaster);
                if (frmGalaMaster.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabNumberMaster)
            {
                Master.FrmNumberMaster frmNumberMaster = new Master.FrmNumberMaster(_numberMaster);
                if (frmNumberMaster.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabFinancialYearMaster)
            {
                Master.FrmFinancialYearMaster financialYearMaster= new Master.FrmFinancialYearMaster(_financialYearMaster);
                if (financialYearMaster.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabBrokerageMaster)
            {
                Master.FrmBrokerageMaster frmBrokerageMaster= new Master.FrmBrokerageMaster(_brokerageMaster);
                if (frmBrokerageMaster.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabCurrencyMaster)
            {
                Master.FrmCurrencyMaster frmCurrencyMaster= new Master.FrmCurrencyMaster(_currencyMaster);
                if (frmCurrencyMaster.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabKapanMaster)
            {
                Master.FrmKapanMaster frmKapanMaster= new Master.FrmKapanMaster(_kapanMaster);
                if (frmKapanMaster.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabLedgerMaster)
            {
                Master.FrmPartyMaster frmPartyMaster = new Master.FrmPartyMaster(_partyMaster);
                if (frmPartyMaster.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabUserMaster)
            {
                Master.frmUserMaster frmUserMaster = new Master.frmUserMaster(_userMaster);
                if (frmUserMaster.ShowDialog() == DialogResult.OK)
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
            if (xtabMasterDetails.SelectedTabPage == xtabCompanyMaster)
            {
                if (IsForceLoad || _companyMaster == null)
                {
                    _companyMasterRepository = new CompanyMasterRepository();
                    _companyMaster = await _companyMasterRepository.GetAllCompanyAsync();
                    grdCompanyMaster.DataSource = _companyMaster.Where(w=>w.Type == null).ToList();
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabBranchMaster)
            {
                if (IsForceLoad || _branchMaster == null)
                {
                    _branchMasterRepository = new BranchMasterRepository();
                    _branchMaster = await _branchMasterRepository.GetAllBranchAsync(Common.LoginCompany);
                    grdBranchMaster.DataSource = _branchMaster;
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabLessWeightGroupMaster)
            {
                if (IsForceLoad || _lessWeightMaster == null)
                {
                    _lessWeightMasterRepository = new LessWeightMasterRepository();
                    _lessWeightMaster = await _lessWeightMasterRepository.GetLessWeightMasters();
                    grdLessGroupWeightMaster.DataSource = _lessWeightMaster;
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabShapeMaster)
            {
                if (IsForceLoad || _shapeMaster == null)
                {
                    _shapeMasterRepository = new ShapeMasterRepository();
                    _shapeMaster = await _shapeMasterRepository.GetAllShapeAsync();
                    grdShapeMaster.DataSource = _shapeMaster;
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabPurityMaster)
            {
                if (IsForceLoad || _purityMaster == null)
                {
                    _purityMasterRepository = new PurityMasterRepository();
                    _purityMaster = await _purityMasterRepository.GetAllPurityAsync();
                    grdPurityMaster.DataSource = _purityMaster;
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabSizeMaster)
            {
                if (IsForceLoad || _sizeMaster == null)
                {
                    _sizeMasterRepository = new SizeMasterRepository();
                    _sizeMaster = await _sizeMasterRepository.GetAllSizeAsync();
                    grdSizeMaster.DataSource = _sizeMaster;
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabGalaMaster)
            {
                if (IsForceLoad || _galaMaster == null)
                {
                    _galaMasterRepository = new GalaMasterRepository();
                    _galaMaster = await _galaMasterRepository.GetAllGalaAsync();
                    grdGalaMaster.DataSource = _galaMaster;
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabNumberMaster)
            {
                if (IsForceLoad || _numberMaster == null)
                {
                    _numberMasterRepository = new NumberMasterRepository();
                    _numberMaster = await _numberMasterRepository.GetAllNumberAsync();
                    grdNumberMaster.DataSource = _numberMaster;
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabFinancialYearMaster)
            {
                if (IsForceLoad || _financialYearMaster == null)
                {
                    _financialYearMasterRepository = new FinancialYearMasterRepository();
                    _financialYearMaster = await _financialYearMasterRepository.GetAllFinancialYear();
                    grdFinancialYearMaster.DataSource = _financialYearMaster;
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabBrokerageMaster)
            {
                if (IsForceLoad || _brokerageMaster == null)
                {
                    _brokerageMasterRepository = new BrokerageMasterRepository();
                    _brokerageMaster = await _brokerageMasterRepository.GetAllBrokerageAsync(Common.LoginCompany);
                    grdBrokerageMaster.DataSource = _brokerageMaster;
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabCurrencyMaster)
            {
                if (IsForceLoad || _currencyMaster == null)
                {
                    _currencyMasterRepository = new CurrencyMasterRepository();
                    _currencyMaster = await _currencyMasterRepository.GetAllCurrencyAsync(Common.LoginCompany);
                    grdCurrencyMaster.DataSource = _currencyMaster;
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabKapanMaster)
            {
                if (IsForceLoad || _kapanMaster == null)
                {
                    _kapanMasterRepository = new KapanMasterRepository();
                    //_kapanMaster = await _kapanMasterRepository.GetAllKapanAsync(Common.LoginCompany);
                    _kapanMaster = await _kapanMasterRepository.GetAllKapanAsync();
                    grdKapanMaster.DataSource = _kapanMaster;
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabLedgerMaster)
            {
                if (IsForceLoad || _partyMaster == null)
                {
                    _partyMasterRepository = new PartyMasterRepository();
                    _partyMaster = await _partyMasterRepository.GetAllPartyAsync(Common.LoginCompany);
                    grdPartyMaster.DataSource = _partyMaster;
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabUserMaster)
            {
                if (IsForceLoad || _userMaster == null)
                {
                    _userMasterRepository = new UserMasterRepository();
                    _userMaster = await _userMasterRepository.GetAllUserAsync();
                    grdUserMaster.DataSource = _userMaster;
                }
            }
        }

        private void ExportGridData(ExportDataType exportType)
        {
            if (xtabMasterDetails.SelectedTabPage == xtabCompanyMaster)
            {
                if (exportType == ExportDataType.Excel)
                {
                    ExportToExcel(grvCompanyMaster);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabBranchMaster)
            {
                if (exportType == ExportDataType.Excel)
                {
                    ExportToExcel(grvBranchMaster);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabLessWeightGroupMaster)
            {
                if (exportType == ExportDataType.Excel)
                {
                    ExportToExcel(grvLessGroupWeightMaster);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabShapeMaster)
            {
                if (exportType == ExportDataType.Excel)
                {
                    ExportToExcel(grvShapeMaster);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabPurityMaster)
            {
                if (exportType == ExportDataType.Excel)
                {
                    ExportToExcel(grvPurityMaster);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabSizeMaster)
            {
                if (exportType == ExportDataType.Excel)
                {
                    ExportToExcel(grvSizeMaster);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabGalaMaster)
            {
                if (exportType == ExportDataType.Excel)
                {
                    ExportToExcel(grvGalaMaster);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabNumberMaster)
            {
                if (exportType == ExportDataType.Excel)
                {
                    ExportToExcel(grvNumberMaster);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabFinancialYearMaster)
            {
                if (exportType == ExportDataType.Excel)
                {
                    ExportToExcel(grvFinancialYearMaster);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabBrokerageMaster)
            {
                if (exportType == ExportDataType.Excel)
                {
                    ExportToExcel(grvBrokerageMaster);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabCurrencyMaster)
            {
                if (exportType == ExportDataType.Excel)
                {
                    ExportToExcel(grvCurrencyMaster);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabKapanMaster)
            {
                if (exportType == ExportDataType.Excel)
                {
                    ExportToExcel(grvKapanMaster);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabLedgerMaster)
            {
                if (exportType == ExportDataType.Excel)
                {
                    ExportToExcel(grvPartyMaster);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabUserMaster)
            {
                if (exportType == ExportDataType.Excel)
                {
                    ExportToExcel(grvUserMaster);
                }
            }
        }

        private async void accordionEditBtn_Click(object sender, EventArgs e)
        {
            if (xtabMasterDetails.SelectedTabPage == xtabCompanyMaster)
            {
                //Guid SelectedGuid = Guid.Parse(tlCompanyMaster.GetFocusedRowCellValue(Id).ToString());

                string SelectedGuid;

                if (grdCompanyMaster.FocusedView.DetailLevel > 0)
                {
                    GridView tempChild = ((GridView)grdCompanyMaster.FocusedView);
                    SelectedGuid = tempChild.GetFocusedRowCellValue("Id").ToString();
                } 
                else                 
                    SelectedGuid = grvCompanyMaster.GetFocusedRowCellValue("Id").ToString();                


                Master.FrmCompanyMaster frmcompanymaster = new Master.FrmCompanyMaster(_companyMaster, SelectedGuid);

                if (frmcompanymaster.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabBranchMaster)
            {
                string SelectedGuid = grvBranchMaster.GetFocusedRowCellValue(colBranchId).ToString();
                Master.FrmBranchMaster frmBranchMaster = new Master.FrmBranchMaster(_branchMaster, SelectedGuid);
                if (frmBranchMaster.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabLessWeightGroupMaster)
            {
                string SelectedGuid = grvLessGroupWeightMaster.GetFocusedRowCellValue(colLessWeightGroupID).ToString();
                Master.FrmLessWeightGroupMaster frmLessWeightGroupMaster= new Master.FrmLessWeightGroupMaster(_lessWeightMaster, SelectedGuid);
                if (frmLessWeightGroupMaster.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabShapeMaster)
            {
                string SelectedGuid = grvShapeMaster.GetFocusedRowCellValue(colShapeId).ToString();
                Master.FrmShapeMaster frmShapeMaster = new Master.FrmShapeMaster(_shapeMaster, SelectedGuid);
                if (frmShapeMaster.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabPurityMaster)
            {
                string SelectedGuid = grvPurityMaster.GetFocusedRowCellValue(colPurityId).ToString();
                Master.FrmPurityMaster frmPurityMaster = new Master.FrmPurityMaster(_purityMaster, SelectedGuid);
                if (frmPurityMaster.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabSizeMaster)
            {
                string SelectedGuid = grvSizeMaster.GetFocusedRowCellValue(colSizeId).ToString();
                Master.FrmSizeMaster frmSizeMaster = new Master.FrmSizeMaster(_sizeMaster, SelectedGuid);
                if (frmSizeMaster.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabGalaMaster)
            {
                string SelectedGuid = grvGalaMaster.GetFocusedRowCellValue(colGalaId).ToString();
                Master.FrmGalaMaster frmGalaMaster = new Master.FrmGalaMaster(_galaMaster, SelectedGuid);
                if (frmGalaMaster.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabNumberMaster)
            {
                string SelectedGuid = grvNumberMaster.GetFocusedRowCellValue(colNumberId).ToString();
                Master.FrmNumberMaster frmNumberMaster = new Master.FrmNumberMaster(_numberMaster, SelectedGuid);
                if (frmNumberMaster.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabFinancialYearMaster)
            {
                string SelectedGuid = grvFinancialYearMaster.GetFocusedRowCellValue(colFinancialYearId).ToString();
                Master.FrmFinancialYearMaster financialYearMaster = new Master.FrmFinancialYearMaster(_financialYearMaster, SelectedGuid);
                if (financialYearMaster.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabBrokerageMaster)
            {
                string SelectedGuid = grvBrokerageMaster.GetFocusedRowCellValue(colBrokerageId).ToString();
                Master.FrmBrokerageMaster frmBrokerageMaster= new Master.FrmBrokerageMaster(_brokerageMaster, SelectedGuid);
                if (frmBrokerageMaster.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabCurrencyMaster)
            {
                string SelectedGuid = grvCurrencyMaster.GetFocusedRowCellValue(colCurrencyId).ToString();
                Master.FrmCurrencyMaster frmCurrencyMaster = new Master.FrmCurrencyMaster(_currencyMaster, SelectedGuid);
                if (frmCurrencyMaster.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabKapanMaster)
            {
                string SelectedGuid = grvKapanMaster.GetFocusedRowCellValue(colKapanId).ToString();
                Master.FrmKapanMaster frmKapanMaster = new Master.FrmKapanMaster(_kapanMaster, SelectedGuid);
                if (frmKapanMaster.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabLedgerMaster)
            {
                string SelectedGuid = grvPartyMaster.GetFocusedRowCellValue(colPartyId).ToString();
                Master.FrmPartyMaster frmPartyMaster= new Master.FrmPartyMaster(_partyMaster, SelectedGuid);
                if (frmPartyMaster.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabUserMaster)
            {
                string SelectedGuid = grvUserMaster.GetFocusedRowCellValue(colUserID).ToString();
                string userName = grvUserMaster.GetFocusedRowCellValue(colUserName).ToString();

                Master.frmUserMaster frmUserMaster = new Master.frmUserMaster(_userMaster, SelectedGuid);
                if (frmUserMaster.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
            }
        }

        private async void xtabMasterDetails_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            await LoadGridData();
        } 

        private async void accordionRefreshBtn_Click(object sender, EventArgs e)
        {
            await LoadGridData(true);
        }

        private async void accordionDeleteBtn_Click(object sender, EventArgs e)
        {
            if (xtabMasterDetails.SelectedTabPage == xtabCompanyMaster)
            {
                //Guid SelectedGuid = Guid.Parse(tlCompanyMaster.GetFocusedRowCellValue(Id).ToString());

                string SelectedGuid;
                string tempCompanyName = "";

                if (grdCompanyMaster.FocusedView.DetailLevel > 0)
                {
                    GridView tempChild = ((GridView)grdCompanyMaster.FocusedView);
                    SelectedGuid = tempChild.GetFocusedRowCellValue("Id").ToString();
                    tempCompanyName = tempChild.GetFocusedRowCellValue("Name").ToString();
                }
                else
                {
                    SelectedGuid = grvCompanyMaster.GetFocusedRowCellValue("Id").ToString();
                    tempCompanyName = grvCompanyMaster.GetFocusedRowCellValue("Name").ToString();
                }
                if (MessageBox.Show(string.Format(AppMessages.GetString(AppMessageID.DeleteCompanyCofirmation), tempCompanyName), "[" + this.Text + "]", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    var Result = await _companyMasterRepository.DeleteCompanyAsync(SelectedGuid);

                    MessageBox.Show(AppMessages.GetString(AppMessageID.DeleteSuccessfully));
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabBranchMaster)
            {
                string SelectedGuid = grvBranchMaster.GetFocusedRowCellValue(colBranchId).ToString();
                if (MessageBox.Show(string.Format(AppMessages.GetString(AppMessageID.DeleteBranchCofirmation), grvBranchMaster.GetFocusedRowCellValue(colBranchName).ToString()), "[" + this.Text + "]", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    var Result = await _branchMasterRepository.DeleteBranchAsync(SelectedGuid);

                    MessageBox.Show(AppMessages.GetString(AppMessageID.DeleteSuccessfully));
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabLessWeightGroupMaster)
            {
                string SelectedGuid = grvLessGroupWeightMaster.GetFocusedRowCellValue(colLessWeightGroupID).ToString();
                if (MessageBox.Show(string.Format(AppMessages.GetString(AppMessageID.DeleteCompanyCofirmation), grvLessGroupWeightMaster.GetFocusedRowCellValue(colLessWeightGroupName).ToString()), "[" + this.Text + "]", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    var Result = await _lessWeightMasterRepository.DeleteLessWeightMaster(SelectedGuid);

                    MessageBox.Show(AppMessages.GetString(AppMessageID.DeleteSuccessfully));
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabShapeMaster)
            {
                string SelectedGuid = grvShapeMaster.GetFocusedRowCellValue(colShapeId).ToString();
                if (MessageBox.Show(string.Format(AppMessages.GetString(AppMessageID.DeleteShapeConfirmation), grvShapeMaster.GetFocusedRowCellValue(colShapeName).ToString()), "[" + this.Text + "]", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    var Result = await _shapeMasterRepository.DeleteShapeAsync(SelectedGuid);

                    MessageBox.Show(AppMessages.GetString(AppMessageID.DeleteSuccessfully));
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabPurityMaster)
            {
                string SelectedGuid = grvPurityMaster.GetFocusedRowCellValue(colPurityId).ToString();
                if (MessageBox.Show(string.Format(AppMessages.GetString(AppMessageID.DeletePurityConfirmation), grvPurityMaster.GetFocusedRowCellValue(colPurityName).ToString()), "[" + this.Text + "]", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    var Result = await _purityMasterRepository.DeletePurityAsync(SelectedGuid);

                    MessageBox.Show(AppMessages.GetString(AppMessageID.DeleteSuccessfully));
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabSizeMaster)
            {
                string SelectedGuid = grvSizeMaster.GetFocusedRowCellValue(colSizeId).ToString();
                if (MessageBox.Show(string.Format(AppMessages.GetString(AppMessageID.DeleteSizeConfirmation), grvSizeMaster.GetFocusedRowCellValue(colSizeName).ToString()), "[" + this.Text + "]", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    var Result = await _sizeMasterRepository.DeleteSizeAsync(SelectedGuid);

                    MessageBox.Show(AppMessages.GetString(AppMessageID.DeleteSuccessfully));
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabGalaMaster)
            {
                string SelectedGuid = grvGalaMaster.GetFocusedRowCellValue(colGalaId).ToString();
                if (MessageBox.Show(string.Format(AppMessages.GetString(AppMessageID.DeleteGalaConfirmation), grvGalaMaster.GetFocusedRowCellValue(colGalaName).ToString()), "[" + this.Text + "]", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    var Result = await _galaMasterRepository.DeleteGalaAsync(SelectedGuid);

                    MessageBox.Show(AppMessages.GetString(AppMessageID.DeleteSuccessfully));
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabNumberMaster)
            {
                string SelectedGuid = grvNumberMaster.GetFocusedRowCellValue(colNumberId).ToString();
                if (MessageBox.Show(string.Format(AppMessages.GetString(AppMessageID.DeleteNumberConfirmation), grvNumberMaster.GetFocusedRowCellValue(colNumberName).ToString()), "[" + this.Text + "]", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    var Result = await _numberMasterRepository.DeleteNumberAsync(SelectedGuid);

                    MessageBox.Show(AppMessages.GetString(AppMessageID.DeleteSuccessfully));
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabFinancialYearMaster)
            {
                string SelectedGuid = grvFinancialYearMaster.GetFocusedRowCellValue(colFinancialYearId).ToString();
                if (MessageBox.Show(string.Format(AppMessages.GetString(AppMessageID.DeleteFinancialYearConfirmation), grvFinancialYearMaster.GetFocusedRowCellValue(colFinancialYearName).ToString()), "[" + this.Text + "]", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    var Result = await _financialYearMasterRepository.DeleteFinancialYearAsync(SelectedGuid);

                    MessageBox.Show(AppMessages.GetString(AppMessageID.DeleteSuccessfully));
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabBrokerageMaster)
            {
                string SelectedGuid = grvBrokerageMaster.GetFocusedRowCellValue(colBrokerageId).ToString();
                if (MessageBox.Show(string.Format(AppMessages.GetString(AppMessageID.DeleteBrokerageConfirmation), grvBrokerageMaster.GetFocusedRowCellValue(colBrokerageName).ToString()), "[" + this.Text + "]", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    var Result = await _brokerageMasterRepository.DeleteBrokerageAsync(SelectedGuid);

                    MessageBox.Show(AppMessages.GetString(AppMessageID.DeleteSuccessfully));
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabCurrencyMaster)
            {
                string SelectedGuid = grvCurrencyMaster.GetFocusedRowCellValue(colCurrencyId).ToString();
                if (MessageBox.Show(string.Format(AppMessages.GetString(AppMessageID.DeleteCurrencyConfirmation), grvCurrencyMaster.GetFocusedRowCellValue(colCurrencyName).ToString()), "[" + this.Text + "]", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    var Result = await _currencyMasterRepository.DeleteCurrencyAsync(SelectedGuid);

                    MessageBox.Show(AppMessages.GetString(AppMessageID.DeleteSuccessfully));
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabKapanMaster)
            {
                string SelectedGuid = grvKapanMaster.GetFocusedRowCellValue(colKapanId).ToString();
                if (MessageBox.Show(string.Format(AppMessages.GetString(AppMessageID.DeleteKapanConfirmation), grvKapanMaster.GetFocusedRowCellValue(colKapanName).ToString()), "[" + this.Text + "]", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    var Result = await _kapanMasterRepository.DeleteKapanAsync(SelectedGuid);

                    MessageBox.Show(AppMessages.GetString(AppMessageID.DeleteSuccessfully));
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabLedgerMaster)
            {
                string SelectedGuid = grvPartyMaster.GetFocusedRowCellValue(colPartyId).ToString();
                if (MessageBox.Show(string.Format(AppMessages.GetString(AppMessageID.DeletePartyCofirmation), grvPartyMaster.GetFocusedRowCellValue(colPartyName).ToString()), "[" + this.Text + "]", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    var Result = await _partyMasterRepository.DeletePartyAsync(SelectedGuid);

                    MessageBox.Show(AppMessages.GetString(AppMessageID.DeleteSuccessfully));
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabUserMaster)
            {
                string SelectedGuid = grvUserMaster.GetFocusedRowCellValue(colUserID).ToString();
                string username = grvUserMaster.GetFocusedRowCellValue(colUserName).ToString();
                if (username.ToLower() == "administrator")
                {
                    MessageBox.Show("You can not delete the administrator user.");
                    return;
                }
                if (MessageBox.Show(string.Format(AppMessages.GetString(AppMessageID.DeleteUserCofirmation), grvUserMaster.GetFocusedRowCellValue(colUserName).ToString()), "[" + this.Text + "]", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    var Result = await _userMasterRepository.DeleteUserAsync(SelectedGuid);

                    MessageBox.Show(AppMessages.GetString(AppMessageID.DeleteSuccessfully));
                    await LoadGridData(true);
                }
            }
        }

        private void grvLessGroupWeightMaster_MasterRowEmpty(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventArgs e)
        {
            GridView grdiView = sender as GridView;
            LessWeightMaster lessWeightMaster = grdiView.GetRow(e.RowHandle) as LessWeightMaster;
            if (lessWeightMaster != null)
            {
                e.IsEmpty = _lessWeightMaster.Where(w => w.Id == lessWeightMaster.Id).Count() > 0 ? false : true;
            }
        }

        private void grvLessGroupWeightMaster_MasterRowGetChildList(object sender, MasterRowGetChildListEventArgs e)
        {
            GridView grdiView = sender as GridView;
            LessWeightMaster lessWeightMaster = grdiView.GetRow(e.RowHandle) as LessWeightMaster;
            if (lessWeightMaster != null)
            {
                e.ChildList = _lessWeightMaster.Where(w => w.Id == lessWeightMaster.Id).FirstOrDefault().LessWeightDetails;
            }
        }

        private void grvLessGroupWeightMaster_MasterRowGetRelationCount(object sender, MasterRowGetRelationCountEventArgs e)
        {
            e.RelationCount = 1;
        }

        private void grvLessGroupWeightMaster_MasterRowGetRelationName(object sender, MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = "grdLessGroupWeightMaster";// grvLessWeightGroupDetailMaster.Name;
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
            GridView gridView = sender as GridView;
            CompanyMaster companyMaster = gridView.GetRow(e.RowHandle) as CompanyMaster;
            if (companyMaster != null)
            {
                e.IsEmpty = _companyMaster.Where(w => w.Type == companyMaster.Id).Count() > 0 ? false : true;
            }
        }

        private void gridViewCompanyMaster_MasterRowGetChildList(object sender, MasterRowGetChildListEventArgs e)
        {
            GridView gridView = sender as GridView;
            CompanyMaster companyMaster = gridView.GetRow(e.RowHandle) as CompanyMaster;
            if (companyMaster != null)
            {
                e.ChildList = _companyMaster.Where(w => w.Type == companyMaster.Id).ToList();
            }
        }

        private void gridViewCompanyMaster_MasterRowGetRelationCount(object sender, MasterRowGetRelationCountEventArgs e)
        {
            e.RelationCount = 1;
        }

        private void gridViewCompanyMaster_MasterRowGetRelationName(object sender, MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = "Child";
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