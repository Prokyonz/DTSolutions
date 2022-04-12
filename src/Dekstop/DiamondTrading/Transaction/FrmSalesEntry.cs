using DevExpress.Utils;
using DevExpress.XtraEditors;
using EFCore.SQL.Repository;
using Repository.Entities;
using Repository.Entities.Model;
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

namespace DiamondTrading.Transaction
{
    public partial class FrmSalesEntry : DevExpress.XtraEditors.XtraForm
    {
        SalesMasterRepository _salesMasterRepository;
        PartyMasterRepository _partyMasterRepository;
        private readonly BrokerageMasterRepository _brokerageMasterRepository;
        SalesItemObj _salesItemObj;
        decimal ItemRunningWeight = 0;
        decimal ItemFinalAmount = 0;

        public FrmSalesEntry()
        {
            InitializeComponent();
            _salesMasterRepository = new SalesMasterRepository();
            _partyMasterRepository = new PartyMasterRepository();
            _brokerageMasterRepository = new BrokerageMasterRepository();
            _salesItemObj = new SalesItemObj();

            this.Text = "SALES - " + Common.LoginCompanyName + " - [" + Common.LoginFinancialYearName + "]";
        }

        private void FrmSaleEntry_Load(object sender, EventArgs e)
        {
            lblFormTitle.Text = Common.FormTitle;
            SetSelectionBackColor();
            tglSlip.IsOn = Common.PrintPurchaseSlip;
            tglPF.IsOn = Common.PrintPurchasePF;
            dtPayDate.Enabled = Common.AllowToSelectPurchaseDueDate;

            SetThemeColors(Color.FromArgb(215, 246, 214));

            FillCombos();

            LoadCompany();

            FillCurrency();
        }

        private void SetThemeColors(Color color)
        {
            if (!color.ToArgb().ToString().Equals(Color.FromArgb(0).Name))
            {
                grpGroup1.AppearanceCaption.BorderColor = color;
                grpGroup2.AppearanceCaption.BorderColor = color;
                grpGroup3.AppearanceCaption.BorderColor = color;
                grpGroup4.AppearanceCaption.BorderColor = color;
                grpGroup5.AppearanceCaption.BorderColor = color;
                grpGroup6.AppearanceCaption.BorderColor = color;
                grpGroup7.AppearanceCaption.BorderColor = color;
                grpGroup8.AppearanceCaption.BorderColor = color;
                grpGroup9.AppearanceCaption.BorderColor = color;

                txtCurrencyType.BackColor = color;
                txtSalerCommisionPercentage.BackColor = color;
                txtPartyBalance.BackColor = color;
                txtBrokerPercentage.BackColor = color;
            }
        }
        private async void FillCombos()
        {
            dtDate.EditValue = DateTime.Now;
            dtTime.EditValue = DateTime.Now;
            dtPayDate.EditValue = DateTime.Now;

            //GetPurchaseNo(); //Serial No/Slip No

            LoadPurchaseItemDetails();

            //Payment Mode
            luePaymentMode.Properties.DataSource = Common.GetPaymentType;
            luePaymentMode.Properties.DisplayMember = "PTypeName";
            luePaymentMode.Properties.ValueMember = "PTypeID";

            GetSalerList();

            //Commision
            //partyMaster = await partyMasterRepository.GetAllPartyAsync();
            //lueCompany.Properties.DataSource = partyMaster;
            //lueCompany.Properties.DisplayMember = "Name";
            //lueCompany.Properties.ValueMember = "Id";

            GetPartyList();

            GetBrokerList();
        }


        #region Private Methods

        private async Task GetBrokerList()
        {
            string companyId = Common.LoginCompany;
            if (lueCompany.EditValue != null)
            {
                if (lueCompany.EditValue.ToString() != Common.LoginCompany)
                    companyId = lueCompany.EditValue.ToString();
            }
            var BrokerDetailList = await _partyMasterRepository.GetAllPartyAsync(companyId, PartyTypeMaster.Employee, PartyTypeMaster.Broker);
            lueBroker.Properties.DataSource = BrokerDetailList;
            lueBroker.Properties.DisplayMember = "Name";
            lueBroker.Properties.ValueMember = "Id";
        }

        private async Task GetPartyList()
        {
            string companyId = Common.LoginCompany;
            if (lueCompany.EditValue != null)
            {
                if (lueCompany.EditValue.ToString() != Common.LoginCompany)
                    companyId = lueCompany.EditValue.ToString();
            }
            var PartyDetailList = await _partyMasterRepository.GetAllPartyAsync(companyId, PartyTypeMaster.Party);
            lueParty.Properties.DataSource = PartyDetailList;
            lueParty.Properties.DisplayMember = "Name";
            lueParty.Properties.ValueMember = "Id";
        }

        private async Task GetSalerList()
        {
            string companyId = Common.LoginCompany;
            if (lueCompany.EditValue != null)
            {
                if (lueCompany.EditValue.ToString() != Common.LoginCompany)
                    companyId = lueCompany.EditValue.ToString();
            }
            var SalerDetailList = await _partyMasterRepository.GetAllPartyAsync(companyId, PartyTypeMaster.Employee, PartyTypeMaster.Seller);
            lueSaler.Properties.DataSource = SalerDetailList;
            lueSaler.Properties.DisplayMember = "Name";
            lueSaler.Properties.ValueMember = "Id";
        }

        private async void LoadCompany()
        {
            CompanyMasterRepository companyMasterRepository = new CompanyMasterRepository();
            var companies = await companyMasterRepository.GetAllCompanyAsync();
            lueCompany.Properties.DataSource = companies;
            lueCompany.Properties.DisplayMember = "Name";
            lueCompany.Properties.ValueMember = "Id";

            lueCompany.EditValue = Common.LoginCompany;

            LoadBranch(Common.LoginCompany);
        }

        private async void LoadBranch(string companyId)
        {
            BranchMasterRepository branchMasterRepository = new BranchMasterRepository();
            var branches = await branchMasterRepository.GetAllBranchAsync(companyId); //_branchMasterRepository.GetAllBranchAsync();
            lueBranch.Properties.DataSource = branches;
            lueBranch.Properties.DisplayMember = "Name";
            lueBranch.Properties.ValueMember = "Id";
            lueBranch.EditValue = Common.LoginBranch;

            GetSalesNo(); //Serial No/Slip No
        }

        private async void FillCurrency()
        {
            //Currency
            CurrencyMasterRepository currencyMasterRepository = new CurrencyMasterRepository();
            var currencyMaster = await currencyMasterRepository.GetAllCurrencyAsync();
            lueCurrencyType.Properties.DataSource = currencyMaster;
            lueCurrencyType.Properties.DisplayMember = "Name";
            lueCurrencyType.Properties.ValueMember = "Id";
        }

        #endregion

        private void LoadPurchaseItemDetails()
        {
            grdPurchaseDetails.DataSource = GetDTColumnsforPurchaseDetails();

            //Category
            GetCategoryDetail(false);

            //Shape
            GetShapeDetail(false);

            //Size
            GetSizeDetail(false);

            //Purity
            GetPurityDetail(false);

            //Kapan
            GetKapanDetail(false);
        }

        private async void GetCategoryDetail(bool IsNew)
        {
            var Category = CategoryMaster.GetAllCategory();

            if (Category != null)
            {
                repoCategory.DataSource = Category;
                repoCategory.DisplayMember = "Name";
                repoCategory.ValueMember = "Id";
            }
        }

        private async void GetShapeDetail(bool IsNew)
        {
            ShapeMasterRepository shapeMasterRepository = new ShapeMasterRepository();
            var shapeMaster = await shapeMasterRepository.GetAllShapeAsync();
            repoShape.DataSource = shapeMaster;
            repoShape.DisplayMember = "Name";
            repoShape.ValueMember = "Id";
        }

        private async void GetSizeDetail(bool IsNew)
        {
            SizeMasterRepository sizeMasterRepository = new SizeMasterRepository();
            var sizeMaster = await sizeMasterRepository.GetAllSizeAsync();
            repoSize.DataSource = sizeMaster;
            repoSize.DisplayMember = "Name";
            repoSize.ValueMember = "Id";
        }

        private async void GetPurityDetail(bool IsNew)
        {
            PurityMasterRepository purityMasterRepository = new PurityMasterRepository();
            var purityMaster = await purityMasterRepository.GetAllPurityAsync();
            repoPurity.DataSource = purityMaster;
            repoPurity.DisplayMember = "Name";
            repoPurity.ValueMember = "Id";
        }

        private async void GetKapanDetail(bool IsNew)
        {
            KapanMasterRepository kapanMasterRepository = new KapanMasterRepository();
            var kapanMaster = await kapanMasterRepository.GetAllKapanAsync();
            repoKapan.DataSource = kapanMaster;
            repoKapan.DisplayMember = "Name";
            repoKapan.ValueMember = "Id";
        }

        public async void GetSalesNo(bool updateSlipNo = true)
        {
            try
            {
                var SrNo = await _salesMasterRepository.GetMaxSrNo(lueBranch.EditValue.ToString(), Common.LoginFinancialYear);
                txtSerialNo.Text = SrNo.ToString();

                if (updateSlipNo)
                {
                    var SlipNo = await _salesMasterRepository.GetMaxSlipNo(lueCompany.EditValue.ToString(), Common.LoginFinancialYear);
                    txtSlipNo.Text = SlipNo.ToString();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error : " + Ex.Message.ToString(), "[" + this.Name + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetSelectionBackColor()
        {
            foreach (Control ctrl in this.Controls)
            {
                ctrl.GotFocus += ctrl_GotFocus;
                ctrl.LostFocus += ctrl_LostFocus;

                for (int i = 0; i < ctrl.Controls.Count; i++)
                {
                    ctrl.Controls[i].GotFocus += ctrl_GotFocus;
                    ctrl.Controls[i].LostFocus += ctrl_LostFocus;
                }
            }
            grvPurchaseDetails.Appearance.FocusedCell.BackColor = Color.LightSteelBlue;
        }

        private void ctrl_LostFocus(object sender, EventArgs e)
        {
            var ctrl = sender as Control;
            if (ctrl.Tag is Color)
                ctrl.BackColor = (Color)ctrl.Tag;
        }

        private void ctrl_GotFocus(object sender, EventArgs e)
        {
            var ctrl = sender as Control;
            ctrl.Tag = ctrl.BackColor;
            ctrl.BackColor = Color.LightSteelBlue;
        }

        private void lueCurrencyType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                GetCurrencyTypeRate();
        }

        private void lueCurrencyType_Leave(object sender, EventArgs e)
        {
            GetCurrencyTypeRate();
        }

        private void GetCurrencyTypeRate()
        {
            try
            {
                if (lueCurrencyType.EditValue != null)
                {
                    txtCurrencyType.Text = lueCurrencyType.GetColumnValue("Value").ToString();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error : " + Ex.Message.ToString(), "[" + this.Name + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPaymentDays_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtPaymentDays.Text.Length > 0)
            {
                dtPayDate.EditValue = CalculateDate(Convert.ToInt32(txtPaymentDays.Text));
            }
        }

        private void txtPaymentDays_Leave(object sender, EventArgs e)
        {
            if(txtPaymentDays.Text.Length > 0)
            {
                dtPayDate.EditValue = CalculateDate(Convert.ToInt32(txtPaymentDays.Text));
            }
        }

        private DateTime CalculateDate(int Days)
        {
            if (Convert.ToDateTime(dtPayDate.EditValue).Date != Convert.ToDateTime(dtDate.EditValue).Date)
                dtPayDate.EditValue = dtDate.EditValue;
            return Convert.ToDateTime(dtPayDate.EditValue).AddDays(Days);
        }

        private void dtPayDate_Validated(object sender, EventArgs e)
        {
            txtPaymentDays.Text = CalculateDays(Convert.ToDateTime(dtPayDate.EditValue)).ToString();
        }

        private int CalculateDays(DateTime Date)
        {
            TimeSpan ts = Date.Subtract(Convert.ToDateTime(dtDate.EditValue));
            return ts.Days;
        }

        private static DataTable GetDTColumnsforPurchaseDetails()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Category");
            dt.Columns.Add("Shape");
            dt.Columns.Add("ShapeId");
            dt.Columns.Add("Size");
            dt.Columns.Add("Purity");
            dt.Columns.Add("Kapan");
            dt.Columns.Add("Carat");
            dt.Columns.Add("Tip");
            dt.Columns.Add("CVD");
            dt.Columns.Add("RejPer");
            dt.Columns.Add("RejCts");
            dt.Columns.Add("LessCts");
            dt.Columns.Add("NetCts");
            dt.Columns.Add("Rate");
            dt.Columns.Add("DiscPer");
            dt.Columns.Add("CVDCharge");
            dt.Columns.Add("Amount");
            dt.Columns.Add("CRate");
            dt.Columns.Add("CAmount");
            dt.Columns.Add("DisAmount");
            dt.Columns.Add("CVDAmount");
            dt.Columns.Add("CharniSize");
            dt.Columns.Add("GalaSize");
            dt.Columns.Add("NumberSize");
            return dt;
        }

        private void labelControl9_Click(object sender, EventArgs e)
        {

        }

        private void FrmSaleEntry_KeyDown(object sender, KeyEventArgs e)
        {
            Common.MoveToNextControl(sender, e, this);
        }

        #region Control Events

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void NewEntry(object sender, KeyEventArgs e)
        {
            string ControlName = ((DevExpress.XtraEditors.LookUpEdit)sender).Name;
            if (e.Control && e.KeyCode == Keys.N)
            {
                if (ControlName == lueSaler.Name)
                {
                    Master.FrmPartyMaster frmPartyMaster = new Master.FrmPartyMaster();
                    frmPartyMaster.IsSilentEntry = true;
                    frmPartyMaster.LedgerType = PartyTypeMaster.Seller;
                    if (frmPartyMaster.ShowDialog() == DialogResult.OK)
                    {
                        await GetSalerList();
                        lueSaler.EditValue = frmPartyMaster.CreatedLedgerID;
                    }
                }
                else if (ControlName == lueParty.Name)
                {
                    Master.FrmPartyMaster frmPartyMaster = new Master.FrmPartyMaster();
                    frmPartyMaster.IsSilentEntry = true;
                    frmPartyMaster.LedgerType = PartyTypeMaster.Party;
                    if (frmPartyMaster.ShowDialog() == DialogResult.OK)
                    {
                        await GetPartyList();
                        lueParty.EditValue = frmPartyMaster.CreatedLedgerID;
                    }
                }
                else if (ControlName == lueBroker.Name)
                {
                    Master.FrmPartyMaster frmPartyMaster = new Master.FrmPartyMaster();
                    frmPartyMaster.IsSilentEntry = true;
                    frmPartyMaster.LedgerType = PartyTypeMaster.Broker;
                    if (frmPartyMaster.ShowDialog() == DialogResult.OK)
                    {
                        await GetBrokerList();
                        lueBroker.EditValue = frmPartyMaster.CreatedLedgerID;
                    }
                }
            }
        }

        private async void lueSaler_EditValueChanged(object sender, EventArgs e)
        {
            if (lueSaler.EditValue == null || lueSaler.EditValue == "")
                return;

            var selectedSaler = (PartyMaster)lueSaler.GetSelectedDataRow();
            var brokerageDetail = await _brokerageMasterRepository.GetBrokerageAsync(selectedSaler.BrokerageId);
            txtSalerCommisionPercentage.Text = brokerageDetail != null ? brokerageDetail.Percentage.ToString() : "0";
        }

        private void lueParty_EditValueChanged(object sender, EventArgs e)
        {
            if (lueParty.EditValue == null || lueParty.EditValue == "")
                return;

            var selectedParty = (PartyMaster)lueParty.GetSelectedDataRow();
            txtPartyBalance.Text = selectedParty.OpeningBalance.ToString();
        }        

        private async void lueBroker_EditValueChanged(object sender, EventArgs e)
        {
            if (lueBroker.EditValue == null || lueBroker.EditValue == "")
                return;

            var selectedBoker = (PartyMaster)lueBroker.GetSelectedDataRow();
            var brokerageDetail = await _brokerageMasterRepository.GetBrokerageAsync(selectedBoker.BrokerageId);
            txtBrokerPercentage.Text = brokerageDetail != null ? brokerageDetail.Percentage.ToString() : "0";
        }

        private void lueBranch_EditValueChanged(object sender, EventArgs e)
        {
            GetSalesNo(false);
        }

        #endregion

        private void lueCompany_EditValueChanged(object sender, EventArgs e)
        {
            this.Text = "SALES - " + lueCompany.Text + " - [" + Common.LoginFinancialYearName + "]";

            LoadBranch(lueCompany.EditValue.ToString());

            FillCombos();


        }

        private async void grvPurchaseDetails_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == colCategory)
                {
                    if (grvPurchaseDetails.GetRowCellValue(e.RowHandle, colCategory).ToString() == CategoryMaster.Charni.ToString())
                    {
                        repoShape.Columns["CharniSize"].Visible = true;
                        repoShape.Columns["GalaSize"].Visible = false;
                        repoShape.Columns["NumberSize"].Visible = false;

                        colNumberSize.Visible = false;
                        colCharniSize.Visible = true;
                        colGalaSize.Visible = false;

                        if (_salesItemObj.CharniItemList == null)
                            _salesItemObj.CharniItemList = await _salesMasterRepository.GetSalesItemDetails(CategoryMaster.Charni, lueCompany.EditValue.ToString(), lueBranch.EditValue.ToString(), Common.LoginFinancialYear);

                        repoShape.DataSource = _salesItemObj.CharniItemList;//.Select(x => new { x.ShapeId, x.Shape }).Distinct().ToList();
                        repoShape.DisplayMember = "Shape";
                        repoShape.ValueMember = "Id";

                        repoShape.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                        repoShape.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;

                        repoSize.DataSource = _salesItemObj.CharniItemList.Select(x => new { x.SizeId, x.Size }).Distinct().ToList();
                        repoSize.DisplayMember = "Size";
                        repoSize.ValueMember = "SizeId";

                        repoPurity.DataSource = _salesItemObj.CharniItemList.Select(x => new { x.PurityId, x.Purity }).Distinct().ToList();
                        repoPurity.DisplayMember = "Purity";
                        repoPurity.ValueMember = "PurityId";

                        repoKapan.DataSource = _salesItemObj.CharniItemList.Select(x => new { x.KapanId, x.Kapan }).Distinct().ToList();
                        repoKapan.DisplayMember = "Kapan";
                        repoKapan.ValueMember = "KapanId";

                        repoCharniSize.DataSource = _salesItemObj.CharniItemList.Select(x => new { x.CharniSizeId, x.CharniSize }).Distinct().ToList();
                        repoCharniSize.DisplayMember = "CharniSize";
                        repoCharniSize.ValueMember = "CharniSizeId";
                    }
                    else if (grvPurchaseDetails.GetRowCellValue(e.RowHandle, colCategory).ToString() == CategoryMaster.Number.ToString())
                    {
                        repoShape.Columns["CharniSize"].Visible = true;
                        repoShape.Columns["GalaSize"].Visible = false;
                        repoShape.Columns["NumberSize"].Visible = true;

                        colNumberSize.Visible = true;
                        colCharniSize.Visible = true;
                        colGalaSize.Visible = false;

                        if (_salesItemObj.NumberItemList == null)
                            _salesItemObj.NumberItemList = await _salesMasterRepository.GetSalesItemDetails(CategoryMaster.Number, lueCompany.EditValue.ToString(), lueBranch.EditValue.ToString(), Common.LoginFinancialYear);

                        repoShape.DataSource = _salesItemObj.NumberItemList;//.Select(x => new { x.ShapeId, x.Shape }).Distinct().ToList();
                        repoShape.DisplayMember = "Shape";
                        repoShape.ValueMember = "Id";

                        repoShape.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                        repoShape.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;

                        repoSize.DataSource = _salesItemObj.NumberItemList.Select(x => new { x.SizeId, x.Size }).Distinct().ToList();
                        repoSize.DisplayMember = "Size";
                        repoSize.ValueMember = "SizeId";

                        repoPurity.DataSource = _salesItemObj.NumberItemList.Select(x => new { x.PurityId, x.Purity }).Distinct().ToList();
                        repoPurity.DisplayMember = "Purity";
                        repoPurity.ValueMember = "PurityId";

                        repoKapan.DataSource = _salesItemObj.NumberItemList.Select(x => new { x.KapanId, x.Kapan }).Distinct().ToList();
                        repoKapan.DisplayMember = "Kapan";
                        repoKapan.ValueMember = "KapanId";

                        repoCharniSize.DataSource = _salesItemObj.NumberItemList.Where(x=>x.CharniSizeId!=null).Select(x => new { x.CharniSizeId, x.CharniSize }).Distinct().ToList();
                        repoCharniSize.DisplayMember = "CharniSize";
                        repoCharniSize.ValueMember = "CharniSizeId";

                        repoNumberSize.DataSource = _salesItemObj.NumberItemList.Select(x => new { x.NumberSizeId, x.NumberSize }).Distinct().ToList();
                        repoNumberSize.DisplayMember = "NumberSize";
                        repoNumberSize.ValueMember = "NumberSizeId";
                    }
                    else if (grvPurchaseDetails.GetRowCellValue(e.RowHandle, colCategory).ToString() == CategoryMaster.Gala.ToString())
                    {
                        repoShape.Columns["CharniSize"].Visible = true;
                        repoShape.Columns["GalaSize"].Visible = true;
                        repoShape.Columns["NumberSize"].Visible = false;
                        colNumberSize.Visible = false;
                        colCharniSize.Visible = true;
                        colGalaSize.Visible = true;

                        if (_salesItemObj.GalaItemList == null)
                            _salesItemObj.GalaItemList = await _salesMasterRepository.GetSalesItemDetails(CategoryMaster.Gala, lueCompany.EditValue.ToString(), lueBranch.EditValue.ToString(), Common.LoginFinancialYear);

                        repoShape.DataSource = _salesItemObj.GalaItemList;//.Select(x => new { x.ShapeId, x.Shape }).Distinct().ToList();
                        repoShape.DisplayMember = "Shape";
                        repoShape.ValueMember = "Id";

                        repoShape.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                        repoShape.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;

                        repoSize.DataSource = _salesItemObj.GalaItemList.Select(x => new { x.SizeId, x.Size }).Distinct().ToList();
                        repoSize.DisplayMember = "Size";
                        repoSize.ValueMember = "SizeId";

                        repoPurity.DataSource = _salesItemObj.GalaItemList.Select(x => new { x.PurityId, x.Purity }).Distinct().ToList();
                        repoPurity.DisplayMember = "Purity";
                        repoPurity.ValueMember = "PurityId";

                        repoKapan.DataSource = _salesItemObj.GalaItemList.Select(x => new { x.KapanId, x.Kapan }).Distinct().ToList();
                        repoKapan.DisplayMember = "Kapan";
                        repoKapan.ValueMember = "KapanId";

                        repoCharniSize.DataSource = _salesItemObj.GalaItemList.Where(x => x.CharniSizeId != null).Select(x => new { x.CharniSizeId, x.CharniSize }).Distinct().ToList();
                        repoCharniSize.DisplayMember = "CharniSize";
                        repoCharniSize.ValueMember = "CharniSizeId";

                        repoGalaSize.DataSource = _salesItemObj.GalaItemList.Select(x => new { x.GalaNumberId, x.GalaSize }).Distinct().ToList();
                        repoGalaSize.DisplayMember = "GalaSize";
                        repoGalaSize.ValueMember = "GalaNumberId";
                    }
                    else if (grvPurchaseDetails.GetRowCellValue(e.RowHandle, colCategory).ToString() == CategoryMaster.Boil.ToString())
                    {
                        repoShape.Columns["CharniSize"].Visible = false;
                        repoShape.Columns["GalaSize"].Visible = false;
                        repoShape.Columns["NumberSize"].Visible = false;

                        colNumberSize.Visible = false;
                        colCharniSize.Visible = false;
                        colGalaSize.Visible = false;

                        if (_salesItemObj.BoilItemList == null)
                            _salesItemObj.BoilItemList = await _salesMasterRepository.GetSalesItemDetails(CategoryMaster.Boil, lueCompany.EditValue.ToString(), lueBranch.EditValue.ToString(), Common.LoginFinancialYear);

                        repoShape.DataSource = _salesItemObj.BoilItemList;//.Select(x => new { x.ShapeId, x.Shape }).Distinct().ToList();
                        repoShape.DisplayMember = "Shape";
                        repoShape.ValueMember = "Id";

                        repoShape.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                        repoShape.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;

                        repoSize.DataSource = _salesItemObj.BoilItemList.Select(x => new { x.SizeId, x.Size }).Distinct().ToList();
                        repoSize.DisplayMember = "Size";
                        repoSize.ValueMember = "SizeId";

                        repoPurity.DataSource = _salesItemObj.BoilItemList.Select(x => new { x.PurityId, x.Purity }).Distinct().ToList();
                        repoPurity.DisplayMember = "Purity";
                        repoPurity.ValueMember = "PurityId";

                        repoKapan.DataSource = _salesItemObj.BoilItemList.Select(x => new { x.KapanId, x.Kapan }).Distinct().ToList();
                        repoKapan.DisplayMember = "Kapan";
                        repoKapan.ValueMember = "KapanId";
                    }
                }
                else if (e.Column == colCarat)
                {
                    decimal TipWeight = Convert.ToDecimal(lueBranch.GetColumnValue("TipWeight"));
                    decimal CVDWeight = Convert.ToDecimal(lueBranch.GetColumnValue("CVDWeight"));
                    GetLessWeightDetailBasedOnCity(lueBranch.GetColumnValue("LessWeightId").ToString(), Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(e.RowHandle, colCarat)), e.RowHandle, TipWeight, CVDWeight);
                }
                else if (e.Column == colShape)
                {
                    if (e.Value != Common.DefaultGuid)
                    {
                        grvPurchaseDetails.SetRowCellValue(e.RowHandle, colShapeId, ((Repository.Entities.Model.SalesItemDetails)repoShape.GetDataSourceRowByKeyValue(e.Value)).ShapeId);
                        grvPurchaseDetails.SetRowCellValue(e.RowHandle, colSize, ((Repository.Entities.Model.SalesItemDetails)repoShape.GetDataSourceRowByKeyValue(e.Value)).SizeId);
                        grvPurchaseDetails.SetRowCellValue(e.RowHandle, colPurity, ((Repository.Entities.Model.SalesItemDetails)repoShape.GetDataSourceRowByKeyValue(e.Value)).PurityId);
                        grvPurchaseDetails.SetRowCellValue(e.RowHandle, colKapan, ((Repository.Entities.Model.SalesItemDetails)repoShape.GetDataSourceRowByKeyValue(e.Value)).KapanId);

                        if (grvPurchaseDetails.GetRowCellValue(e.RowHandle, colCategory).ToString() != CategoryMaster.Boil.ToString())
                        {
                            grvPurchaseDetails.SetRowCellValue(e.RowHandle, colCharniSize, ((Repository.Entities.Model.SalesItemDetails)repoShape.GetDataSourceRowByKeyValue(e.Value)).CharniSizeId);
                        }
                        if (grvPurchaseDetails.GetRowCellValue(e.RowHandle, colCategory).ToString() == CategoryMaster.Number.ToString())
                        {
                            grvPurchaseDetails.SetRowCellValue(e.RowHandle, colNumberSize, ((Repository.Entities.Model.SalesItemDetails)repoShape.GetDataSourceRowByKeyValue(e.Value)).NumberSizeId);
                            //grvPurchaseDetails.SetRowCellValue(e.RowHandle, colCharniSize, ((Repository.Entities.Model.SalesItemDetails)repoShape.GetDataSourceRowByKeyValue(e.Value)).CharniSizeId);
                        }
                        else if (grvPurchaseDetails.GetRowCellValue(e.RowHandle, colCategory).ToString() == CategoryMaster.Gala.ToString())
                        {
                            grvPurchaseDetails.SetRowCellValue(e.RowHandle, colGalaSize, ((Repository.Entities.Model.SalesItemDetails)repoShape.GetDataSourceRowByKeyValue(e.Value)).GalaNumberId);
                        }
                    }
                }
                else if (e.Column == colRejPer)
                {
                    CalculateRejectionValue(true, e.RowHandle);
                }
                else if (e.Column == colRejCts)
                {
                    CalculateRejectionValue(false, e.RowHandle);
                }
                 
                FinalCalculation(e.RowHandle);
            }
            catch(Exception Ex)
            {
            }
        }

        private void grvPurchaseDetails_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GetTotal();
        }

        private void grvPurchaseDetails_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            grvPurchaseDetails.SetRowCellValue(e.RowHandle, colShape, Common.DefaultShape);
            grvPurchaseDetails.SetRowCellValue(e.RowHandle, colSize, Common.DefaultSize);
            grvPurchaseDetails.SetRowCellValue(e.RowHandle, colPurity, Common.DefaultPurity);

            grvPurchaseDetails.SetRowCellValue(e.RowHandle, colCVDWeight, "0.00");
            grvPurchaseDetails.SetRowCellValue(e.RowHandle, colRejPer, "0.00");
            grvPurchaseDetails.SetRowCellValue(e.RowHandle, colRejCts, "0.00");
            grvPurchaseDetails.SetRowCellValue(e.RowHandle, colDisAmount, "0.00");
            grvPurchaseDetails.SetRowCellValue(e.RowHandle, colDisPer, "0.00");
        }

        private void grvPurchaseDetails_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (MessageBox.Show("Do you want add more Items...???", "confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
            {
                //IsFocusMoveToOutsideGrid = true;
                //grvPurchaseItems.CloseEditor();
                //this.SelectNextControl(grdPurchaseItems, true, true, true, true);


                //this.SelectNextControl(grdPurchaseItems, true, true, true, true);
            }
        }

        private async void GetLessWeightDetailBasedOnCity(string GroupName, decimal Weight, int GridRowIndex, decimal TipWeight, decimal CVDWeight)
        {
            try
            {
                if (!string.IsNullOrEmpty(GroupName) && Weight > 0)
                {
                    LessWeightMasterRepository lessWeightMasterRepository = new LessWeightMasterRepository();
                    LessWeightDetails lessWeightDetails = await lessWeightMasterRepository.GetLessWeightDetailsMasters(GroupName, Weight);

                    if (lessWeightDetails != null)
                    {
                        grvPurchaseDetails.SetRowCellValue(GridRowIndex, colTipWeight, TipWeight.ToString());
                        grvPurchaseDetails.SetRowCellValue(GridRowIndex, colCVDCharge, (Weight*CVDWeight).ToString("0.00"));
                        grvPurchaseDetails.SetRowCellValue(GridRowIndex, colLessCts, lessWeightDetails.LessWeight.ToString());
                    }
                    //else
                    //{
                    //    grvPurchaseDetails.SetRowCellValue(GridRowIndex, colTipWeight, "");
                    //    grvPurchaseDetails.SetRowCellValue(GridRowIndex, colCVDCharge, "");
                    //    grvPurchaseDetails.SetRowCellValue(GridRowIndex, colLessCts, "");
                    //}
                }
            }
            catch
            {
            }
        }

        public void CalculateRejectionValue(bool IsCalculateRate, int GridRowIndex)
        {
            try
            {
                this.grvPurchaseDetails.CellValueChanged -= new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvPurchaseDetails_CellValueChanged);
                if (grvPurchaseDetails.GetRowCellValue(GridRowIndex, colRejPer).ToString().Trim().Length == 0)
                    grvPurchaseDetails.SetRowCellValue(GridRowIndex, colRejPer, "0");
                decimal RunningWeightBeforeRejection = Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(GridRowIndex, colCarat)) - Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(GridRowIndex, colTipWeight)) - Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(GridRowIndex, colCVDWeight));
                if (IsCalculateRate)
                {
                    try
                    {
                        if (RunningWeightBeforeRejection != 0 && grvPurchaseDetails.GetRowCellValue(GridRowIndex, colRejPer).ToString().Trim().Length != 0)
                        {
                            decimal RejectionWeight = RunningWeightBeforeRejection + ((RunningWeightBeforeRejection * Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(GridRowIndex, colRejPer))) / 100);
                            //txtRejWeight.Text = (RejectionWeight - RunningWeight).ToString("0.000");
                            double multiplier = Math.Pow(10, 2);
                            grvPurchaseDetails.SetRowCellValue(GridRowIndex, colRejCts, (Math.Ceiling((RejectionWeight - RunningWeightBeforeRejection) * (decimal)multiplier) / (decimal)multiplier).ToString());
                            //txtRejWeight.Text = (Math.Ceiling((RejectionWeight - RunningWeightBeforeRejection) * (decimal)multiplier) / (decimal)multiplier).ToString();
                        }
                    }
                    catch
                    {
                        grvPurchaseDetails.SetRowCellValue(GridRowIndex, colRejCts, "");
                        //txtRejWeight.Text = "";
                    }
                }
                else
                {
                    try
                    {
                        if (RunningWeightBeforeRejection != 0 && grvPurchaseDetails.GetRowCellValue(GridRowIndex, colRejCts).ToString().Trim().Length != 0)
                        {
                            decimal RejectionPer = ((Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(GridRowIndex, colRejCts)) - RunningWeightBeforeRejection) / RunningWeightBeforeRejection) * 100;
                            grvPurchaseDetails.SetRowCellValue(GridRowIndex, colRejPer, (100 - (RejectionPer > 0 ? RejectionPer : (RejectionPer * -1))).ToString("0.00"));
                            //txtRejPer.Text = (100 - (RejectionPer > 0 ? RejectionPer : (RejectionPer * -1))).ToString("0.00");
                        }
                    }
                    catch
                    {
                        grvPurchaseDetails.SetRowCellValue(GridRowIndex, colRejPer, "");
                        //txtRejPer.Text = "";
                    }
                }
            }
            catch
            {
            }
            finally
            {
                this.grvPurchaseDetails.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvPurchaseDetails_CellValueChanged);
            }
        }

        private void FinalCalculation(int GridRowIndex)
        {
            try
            {
                this.grvPurchaseDetails.CellValueChanged -= new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvPurchaseDetails_CellValueChanged);
                decimal Carat = 0;
                if (grvPurchaseDetails.GetRowCellValue(GridRowIndex, colCarat).ToString().Length != 0)
                    Carat = Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(GridRowIndex, colCarat));

                decimal TipCts = 0;
                if (grvPurchaseDetails.GetRowCellValue(GridRowIndex, colTipWeight).ToString().Length != 0)
                    TipCts = Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(GridRowIndex, colTipWeight));

                decimal CVDCts = 0;
                if (grvPurchaseDetails.GetRowCellValue(GridRowIndex, colCVDWeight).ToString().Length != 0)
                    CVDCts = Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(GridRowIndex, colCVDWeight));

                decimal RejCts = 0;
                if (grvPurchaseDetails.GetRowCellValue(GridRowIndex, colRejCts).ToString().Length != 0)
                    RejCts = Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(GridRowIndex, colRejCts));

                decimal LessCts = 0;
                if (grvPurchaseDetails.GetRowCellValue(GridRowIndex, colLessCts).ToString().Length != 0)
                    LessCts = Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(GridRowIndex, colLessCts));

                ItemRunningWeight = Carat - TipCts - CVDCts - RejCts - LessCts;

                grvPurchaseDetails.SetRowCellValue(GridRowIndex, colNetCts, ItemRunningWeight);
                //txtNetWeight.Text = ItemRunningWeight.ToString();

                decimal Amount = 0;
                decimal FinalAmount = 0;
                if (grvPurchaseDetails.GetRowCellValue(GridRowIndex, colRate).ToString().Trim().Length > 0)
                {
                    Amount = Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(GridRowIndex, colRate));
                    FinalAmount = ItemRunningWeight * Amount;
                }
                if (grvPurchaseDetails.GetRowCellValue(GridRowIndex, colDisPer).ToString().Trim().Length > 0)
                {
                    decimal LessPer = Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(GridRowIndex, colDisPer));
                    if (LessPer < 0)
                        LessPer *= -1;
                    decimal LessAmt = (FinalAmount * LessPer) / 100;
                    FinalAmount -= LessAmt;

                    grvPurchaseDetails.SetRowCellValue(GridRowIndex, colDisAmount, LessAmt);
                }
                if (grvPurchaseDetails.GetRowCellValue(GridRowIndex, colCVDCharge).ToString().Trim().Length > 0)
                {
                    decimal CVDCharge = Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(GridRowIndex, colCVDCharge));
                    //CVDCharge *= Carat;
                    FinalAmount = FinalAmount - CVDCharge;

                    grvPurchaseDetails.SetRowCellValue(GridRowIndex, colCVDAmount, CVDCharge);
                }
                ItemFinalAmount = FinalAmount;
                //txtAmount.Text = ItemFinalAmount.ToString("0.00");
                grvPurchaseDetails.SetRowCellValue(GridRowIndex, colAmount, ItemFinalAmount);

                decimal currRate = 1;
                if (txtCurrencyType.Text.Trim().Length > 0 && Convert.ToDecimal(txtCurrencyType.Text) > 0)
                {
                    currRate = Convert.ToDecimal(txtCurrencyType.Text);
                }
                grvPurchaseDetails.SetRowCellValue(GridRowIndex, colCurrRate, (Amount / currRate).ToString("0.00"));
                grvPurchaseDetails.SetRowCellValue(GridRowIndex, colCurrAmount, (ItemFinalAmount / currRate).ToString("0.00"));
            }
            catch (StackOverflowException ex)
            {
                //txtAmount.Text = "";
            }
            catch (Exception ex)
            {
            }
            finally
            {
                this.grvPurchaseDetails.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvPurchaseDetails_CellValueChanged);
            }
        }

        public void GetTotal()
        {
            try
            {
                decimal Total = Convert.ToDecimal(colAmount.SummaryItem.SummaryValue);
                decimal TotalAmount = 0;
                txtAmount.Text = Total.ToString("0.00");
                decimal LastDigit = 0;
                if (Total > 0)
                {
                    int StartIndex = Total.ToString().IndexOf(".") - 1;
                    int EndIndex = Total.ToString().Length - StartIndex;
                    if (StartIndex >= 0)
                        LastDigit = Convert.ToDecimal(Total.ToString().Substring(StartIndex, EndIndex));
                }
                decimal RoundUpAmt = 0;
                if (LastDigit >= 0 && LastDigit <= 5.50m)
                {
                    LastDigit *= -1;
                    RoundUpAmt = LastDigit;
                }
                else
                {
                    RoundUpAmt = 10 - LastDigit;
                }

                Total += RoundUpAmt;
                txtNetAmount.Text = Total.ToString("0.00");
                txtCurrencyAmount.Text = GetCurrencyTotalAmount(Total).ToString("0.00");
                txtRoundAmount.Text = RoundUpAmt.ToString();

                CalculateBrokerageRate(true);
                CalculateCommisionRate(true);
            }
            catch
            {
            }
        }

        private decimal GetCurrencyTotalAmount(decimal Amt)
        {
            try
            {
                //if (Amt != 0)
                //{
                //    if (txtCurrencyType.Text.ToString().Length == 0)
                //        txtCurrencyType.Text = "0";
                //}
                //return (Amt / Convert.ToDecimal(txtCurrencyType.Text));

                return Convert.ToDecimal(colCurrAmount.SummaryItem.SummaryValue);
            }
            catch
            {
                return 0;
            }
        }

        public void CalculateBrokerageRate(bool IsCalculateRate)
        {
            try
            {
                if (txtBrokerPercentage.Text.ToString().Trim().Length == 0)
                    txtBrokerPercentage.Text = "0";
                if (IsCalculateRate)
                {
                    try
                    {
                        if (Convert.ToDecimal(txtNetAmount.Text) != 0 && txtBrokerPercentage.Text.Trim().Length != 0)
                        {
                            decimal BrokerageAmount = Convert.ToDecimal(txtNetAmount.Text) + ((Convert.ToDecimal(txtNetAmount.Text) * Convert.ToDecimal(txtBrokerPercentage.Text)) / 100);
                            double multiplier = Math.Pow(10, 2);
                            txtBrokerageAmount.Text = (Math.Ceiling((BrokerageAmount - Convert.ToDecimal(txtNetAmount.Text)) * (decimal)multiplier) / (decimal)multiplier).ToString();
                        }
                    }
                    catch
                    {
                        txtBrokerageAmount.Text = "";
                    }
                }
                else
                {
                    try
                    {
                        if (Convert.ToDecimal(txtNetAmount.Text) != 0 && txtBrokerageAmount.Text.Trim().Length != 0)
                        {
                            decimal BrokeragePer = ((Convert.ToDecimal(txtBrokerageAmount.Text) - Convert.ToDecimal(txtNetAmount.Text)) / Convert.ToDecimal(txtNetAmount.Text)) * 100;
                            txtBrokerPercentage.Text = (100 - (BrokeragePer > 0 ? BrokeragePer : (BrokeragePer * -1))).ToString("0.00");
                        }
                    }
                    catch
                    {
                        txtBrokerPercentage.Text = "";
                    }
                }
            }
            catch
            {
            }
            finally
            {
            }
        }

        public void CalculateCommisionRate(bool IsCalculateRate)
        {
            try
            {
                if (txtSalerCommisionPercentage.Text.ToString().Trim().Length == 0)
                    txtSalerCommisionPercentage.Text = "0";
                if (IsCalculateRate)
                {
                    try
                    {
                        if (Convert.ToDecimal(txtNetAmount.Text) != 0 && txtSalerCommisionPercentage.Text.Trim().Length != 0)
                        {
                            decimal CommisionAmount = Convert.ToDecimal(txtNetAmount.Text) + ((Convert.ToDecimal(txtNetAmount.Text) * Convert.ToDecimal(txtSalerCommisionPercentage.Text)) / 100);
                            double multiplier = Math.Pow(10, 2);
                            txtCommisionAmount.Text = (Math.Ceiling((CommisionAmount - Convert.ToDecimal(txtNetAmount.Text)) * (decimal)multiplier) / (decimal)multiplier).ToString();
                        }
                    }
                    catch
                    {
                        txtCommisionAmount.Text = "";
                    }
                }
                else
                {
                    try
                    {
                        if (Convert.ToDecimal(txtNetAmount.Text) != 0 && txtCommisionAmount.Text.Trim().Length != 0)
                        {
                            decimal CommisionPer = ((Convert.ToDecimal(txtCommisionAmount.Text) - Convert.ToDecimal(txtNetAmount.Text)) / Convert.ToDecimal(txtNetAmount.Text)) * 100;
                            txtSalerCommisionPercentage.Text = (100 - (CommisionPer > 0 ? CommisionPer : (CommisionPer * -1))).ToString("0.00");
                        }
                    }
                    catch
                    {
                        txtSalerCommisionPercentage.Text = "";
                    }
                }
            }
            catch
            {
            }
            finally
            {
            }
        }

        private Image LoadImage()
        {
            Image newimage = null;
            openFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.JPEG;*.PNG)|*.BMP;*.JPG;*.JPEG;*.PNG";
            openFileDialog1.FileName = string.Empty;
            if (DialogResult.OK == openFileDialog1.ShowDialog())
            {
                if (openFileDialog1.FileName != string.Empty)
                {
                    try
                    {
                        Byte[] logo = null;
                        logo = File.ReadAllBytes(openFileDialog1.FileName);
                        MemoryStream ms = new MemoryStream(logo);
                        newimage = Image.FromStream(ms);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("CM01:" + ex.Message, "AD InfoTech", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            return newimage;
        }

        private void BrowseImage(int SelectedImage)
        {
            Transaction.FrmTakePicture fpc = new Transaction.FrmTakePicture();
            fpc.Image1.Image = Image1.Image;
            fpc.Image2.Image = Image2.Image;
            fpc.Image3.Image = Image3.Image;
            fpc.SelectedImage = SelectedImage;
            if (fpc.ShowDialog() == DialogResult.OK)
            {
                Image1.Image = fpc.Image1.Image;
                Image2.Image = fpc.Image2.Image;
                Image3.Image = fpc.Image3.Image;

                Image1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
                Image2.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
                Image3.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            }
        }
        private void Image1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Image1.Image = LoadImage();
            //Image1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            BrowseImage(0);
        }

        private void Image2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Image2.Image = LoadImage();
            //Image2.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            BrowseImage(1);
        }

        private void Image3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Image3.Image = LoadImage();
            //Image3.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            BrowseImage(2);
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (!CheckValidation())
                    return;

                string SalesId = Guid.NewGuid().ToString();

                List<SalesDetails> salesDetailsList = new List<SalesDetails>();
                SalesDetails salesDetails = new SalesDetails();
                for (int i = 0; i < grvPurchaseDetails.RowCount; i++)
                {
                    salesDetails = new SalesDetails();
                    salesDetails.Id = Guid.NewGuid().ToString();
                    salesDetails.SalesId = SalesId;
                    salesDetails.Category = Convert.ToInt32(grvPurchaseDetails.GetRowCellValue(i, colCategory).ToString());
                    salesDetails.KapanId = grvPurchaseDetails.GetRowCellValue(i, colKapan).ToString();
                    salesDetails.ShapeId = grvPurchaseDetails.GetRowCellValue(i, colShapeId).ToString();
                    salesDetails.SizeId = grvPurchaseDetails.GetRowCellValue(i, colSize).ToString();
                    salesDetails.PurityId = grvPurchaseDetails.GetRowCellValue(i, colPurity).ToString();
                    if (grvPurchaseDetails.GetRowCellValue(i, colCharniSize) != null)
                        salesDetails.CharniSizeId = grvPurchaseDetails.GetRowCellValue(i, colCharniSize).ToString();
                    if (grvPurchaseDetails.GetRowCellValue(i, colGalaSize) != null)
                        salesDetails.GalaSizeId = grvPurchaseDetails.GetRowCellValue(i, colGalaSize).ToString();
                    if (grvPurchaseDetails.GetRowCellValue(i, colNumberSize) != null)
                        salesDetails.NumberSizeId = grvPurchaseDetails.GetRowCellValue(i, colNumberSize).ToString();

                    salesDetails.Weight = Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(i, colCarat).ToString());
                    salesDetails.TIPWeight = Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(i, colTipWeight).ToString());
                    salesDetails.CVDWeight = Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(i, colCVDWeight).ToString());
                    salesDetails.RejectedPercentage = Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(i, colRejPer).ToString());
                    salesDetails.RejectedWeight = Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(i, colRejCts).ToString());
                    salesDetails.LessWeight = Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(i, colLessCts).ToString());
                    salesDetails.LessDiscountPercentage = Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(i, colDisPer).ToString());
                    salesDetails.LessWeightDiscount = Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(i, colDisAmount).ToString());
                    salesDetails.NetWeight = Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(i, colNetCts).ToString());
                    salesDetails.SaleRate = float.Parse(grvPurchaseDetails.GetRowCellValue(i, colRate).ToString());
                    salesDetails.CVDCharge = float.Parse(grvPurchaseDetails.GetRowCellValue(i, colCVDCharge).ToString());
                    salesDetails.CVDAmount = float.Parse(grvPurchaseDetails.GetRowCellValue(i, colCVDAmount).ToString());
                    salesDetails.Amount = float.Parse(grvPurchaseDetails.GetRowCellValue(i, colAmount).ToString());
                    salesDetails.CurrencyRate = float.Parse(grvPurchaseDetails.GetRowCellValue(i, colCurrRate).ToString());
                    salesDetails.CurrencyAmount = float.Parse(grvPurchaseDetails.GetRowCellValue(i, colCurrAmount).ToString());
                    salesDetails.IsTransfer = false;
                    salesDetails.TransferParentId = null;
                    salesDetails.CreatedDate = DateTime.Now;
                    salesDetails.CreatedBy = Common.LoginUserID;
                    salesDetails.UpdatedDate = DateTime.Now;
                    salesDetails.UpdatedBy = Common.LoginUserID;

                    salesDetailsList.Insert(i, salesDetails);
                }

                SalesMaster salesMaster = new SalesMaster();
                salesMaster.Id = SalesId;
                salesMaster.CompanyId = lueCompany.GetColumnValue("Id").ToString();
                salesMaster.BranchId = lueBranch.GetColumnValue("Id").ToString();
                salesMaster.PartyId = lueParty.GetColumnValue("Id").ToString();
                salesMaster.SalerId = lueSaler.GetColumnValue("Id").ToString();
                salesMaster.CurrencyId = lueCurrencyType.GetColumnValue("Id").ToString();
                salesMaster.FinancialYearId = Common.LoginFinancialYear;
                salesMaster.BrokerageId = lueBroker.GetColumnValue("Id").ToString();
                salesMaster.CurrencyRate = Convert.ToDecimal(txtCurrencyType.Text);
                salesMaster.SaleBillNo = Convert.ToInt32(txtSerialNo.Text);
                salesMaster.SlipNo = Convert.ToInt32(txtSlipNo.Text);
                salesMaster.TransactionType = Convert.ToInt32(luePaymentMode.GetColumnValue("Id"));
                salesMaster.Date = Convert.ToDateTime(dtDate.Text).ToString("yyyyMMdd");
                salesMaster.Time = Convert.ToDateTime(dtTime.Text).ToString("hh:mm:ss ttt");
                salesMaster.DayName = Convert.ToDateTime(dtDate.EditValue).DayOfWeek.ToString();
                salesMaster.PartyLastBalanceWhileSale = float.Parse(txtPartyBalance.Text);
                salesMaster.BrokerPercentage = Convert.ToDecimal(txtBrokerPercentage.Text);
                salesMaster.BrokerAmount = float.Parse(txtBrokerageAmount.Text);
                salesMaster.RoundUpAmount = float.Parse(txtRoundAmount.Text);
                salesMaster.Total = float.Parse(txtAmount.Text);
                salesMaster.GrossTotal = float.Parse(txtNetAmount.Text);
                salesMaster.DueDays = Convert.ToInt32(txtDays.Text);
                salesMaster.DueDate = Convert.ToDateTime(dtDate.Text).AddDays(Convert.ToInt32(txtDays.Text));
                salesMaster.PaymentDays = Convert.ToInt32(txtDays.Text);
                salesMaster.PaymentDueDate = Convert.ToDateTime(dtPayDate.Text);
                salesMaster.IsSlip = tglSlip.IsOn;
                salesMaster.IsPF = tglPF.IsOn;
                salesMaster.CommissionPercentage = Convert.ToDecimal(txtSalerCommisionPercentage.Text);
                salesMaster.CommissionAmount = float.Parse(txtCommisionAmount.Text);
                if (Image1.Image != null)
                    salesMaster.Image1 = ImageToByteArray(Image1.Image);
                if (Image2.Image != null)
                    salesMaster.Image2 = ImageToByteArray(Image2.Image);
                if (Image3.Image != null)
                    salesMaster.Image3 = ImageToByteArray(Image3.Image);
                salesMaster.AllowSlipPrint = tglSlip.IsOn ? true : false;
                salesMaster.IsTransfer = false;
                salesMaster.TransferParentId = null;
                salesMaster.IsDelete = false;
                salesMaster.Remarks = txtRemark.Text;
                salesMaster.CreatedDate = DateTime.Now;
                salesMaster.CreatedBy = Common.LoginUserID;
                salesMaster.UpdatedDate = DateTime.Now;
                salesMaster.UpdatedBy = Common.LoginUserID;
                salesMaster.SalesDetails = salesDetailsList;

                SalesMasterRepository salesMasterRepository = new SalesMasterRepository();
                var Result = await salesMasterRepository.AddSalesAsync(salesMaster);

                if (Result != null)
                {
                    Reset();
                    MessageBox.Show(AppMessages.GetString(AppMessageID.SaveSuccessfully), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error : " + Ex.Message.ToString(), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }

        private bool CheckValidation()
        {
            if (lueCompany.EditValue == null)
            {
                MessageBox.Show("Please select Company", "Purchase Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lueCompany.Focus();
                return false;
            }
            else if (txtSlipNo.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please enter Slip No", "Purchase Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSlipNo.Focus();
                return false;
            }
            else if (luePaymentMode.EditValue == null)
            {
                MessageBox.Show("Please select Payment Mode", "Purchase Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                luePaymentMode.Focus();
                return false;
            }
            else if (lueCurrencyType.EditValue == null)
            {
                MessageBox.Show("Please select Currency Type", "Purchase Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lueCurrencyType.Focus();
                return false;
            }
            else if (lueBranch.EditValue == null)
            {
                MessageBox.Show("Please select Branch", "Purchase Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lueBranch.Focus();
                return false;
            }
            else if (lueSaler.EditValue == null)
            {
                MessageBox.Show("Please select Saler name", "Purchase Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lueSaler.Focus();
                return false;
            }
            else if (lueParty.EditValue == null)
            {
                MessageBox.Show("Please select Party name", "Purchase Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lueParty.Focus();
                return false;
            }
            else if (lueBroker.EditValue == null)
            {
                MessageBox.Show("Please select broker name", "Purchase Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lueBroker.Focus();
                return false;
            }
            else if (txtDays.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please enter bill due days", "Purchase Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDays.Focus();
                return false;
            }
            else if (txtPaymentDays.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please enter bill payment due days", "Purchase Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPaymentDays.Focus();
                return false;
            }

            if (txtCurrencyAmount.Text.ToString().Length == 0)
                txtCurrencyAmount.Text = "1";

            return true;
        }

        private void Reset()
        {
            grdPurchaseDetails.DataSource = null;
            lueSaler.EditValue = "";
            lueParty.EditValue = "";
            lueBroker.EditValue = "";
            FillCombos();
            //FillBranches();
            FillCurrency();
            txtRemark.Text = "";
            txtDays.Text = "";
            txtPaymentDays.Text = "";
            dtPayDate.EditValue = DateTime.Today;
            Image1.Image = null;
            Image2.Image = null;
            Image3.Image = null;
            txtSalerCommisionPercentage.Text = "0";
            txtPartyBalance.Text = "0";
            txtBrokerPercentage.Text = "0";
            txtBrokerageAmount.Text = "0";
            txtCommisionAmount.Text = "0";
            txtAmount.Text = "0";
            txtRoundAmount.Text = "0";
            txtNetAmount.Text = "0";
            txtCurrencyAmount.Text = "0";
            tglSlip.IsOn = Common.PrintPurchaseSlip;
            tglPF.IsOn = Common.PrintPurchasePF;
            _salesItemObj = new SalesItemObj();
            GetSalesNo();
            txtSlipNo.Focus();
        }
    }
}