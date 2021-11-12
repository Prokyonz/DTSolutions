using DevExpress.Utils;
using DevExpress.XtraEditors;
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

namespace DiamondTrading.Transaction
{
    public partial class FrmSalesEntry : DevExpress.XtraEditors.XtraForm
    {
        SalesMasterRepository _salesMasterRepository;
        PartyMasterRepository _partyMasterRepository;
        private readonly BrokerageMasterRepository _brokerageMasterRepository;

        public FrmSalesEntry()
        {
            InitializeComponent();
            _salesMasterRepository = new SalesMasterRepository();
            _partyMasterRepository = new PartyMasterRepository();
            _brokerageMasterRepository = new BrokerageMasterRepository();

            this.Text = "SALES - " + Common.LoginCompanyName + " - [" + Common.LoginFinancialYearName + "]";
        }

        private void FrmSaleEntry_Load(object sender, EventArgs e)
        {
            
            lblFormTitle.Text = Common.FormTitle;
            SetSelectionBackColor();
            tglSlip.IsOn = Common.PrintPurchaseSlip;
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

            lueCompany.Enabled = false;
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

        public async void GetSalesNo()
        {
            try
            {
                var SrNo = await _salesMasterRepository.GetMaxSrNo(lueBranch.EditValue.ToString(), Common.LoginFinancialYear);
                txtSerialNo.Text = SrNo.ToString();

                var SlipNo = await _salesMasterRepository.GetMaxSlipNo(lueCompany.EditValue.ToString(), Common.LoginFinancialYear);
                txtSlipNo.Text = SlipNo.ToString();
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
        private async void lueSaler_EditValueChanged(object sender, EventArgs e)
        {
            var selectedSaler = (PartyMaster)lueSaler.GetSelectedDataRow();
            var brokerageDetail = await _brokerageMasterRepository.GetBrokerageAsync(selectedSaler.BrokerageId);
            txtSalerCommisionPercentage.Text = brokerageDetail != null ? brokerageDetail.Percentage.ToString() : "0";
        }

        
        private void lueParty_EditValueChanged(object sender, EventArgs e)
        {
            var selectedParty = (PartyMaster)lueParty.GetSelectedDataRow();
            txtPartyBalance.Text = selectedParty.OpeningBalance.ToString();
        }        

        private async void lueBroker_EditValueChanged(object sender, EventArgs e)
        {
            var selectedBoker = (PartyMaster)lueBroker.GetSelectedDataRow();
            var brokerageDetail = await _brokerageMasterRepository.GetBrokerageAsync(selectedBoker.BrokerageId);
            txtBrokerPercentage.Text = brokerageDetail != null ? brokerageDetail.Percentage.ToString() : "0";
        }

        private void lueBranch_EditValueChanged(object sender, EventArgs e)
        {
            GetSalesNo();
        }

        #endregion

        private void lueCompany_EditValueChanged(object sender, EventArgs e)
        {
            this.Text = "SALES - " + lueCompany.Text + " - [" + Common.LoginFinancialYearName + "]";

            LoadBranch(lueCompany.EditValue.ToString());

            FillCombos();


        }
    }
}