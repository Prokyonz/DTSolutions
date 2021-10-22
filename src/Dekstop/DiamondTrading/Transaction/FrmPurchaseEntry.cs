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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiamondTrading.Transaction
{
    public partial class FrmPurchaseEntry : DevExpress.XtraEditors.XtraForm
    {
        PurchaseMasterRepository _purchaseMasterRepository;
        PartyMasterRepository _partyMasterRepository;

        public FrmPurchaseEntry()
        {
            InitializeComponent();
            _purchaseMasterRepository = new PurchaseMasterRepository();
            _partyMasterRepository = new PartyMasterRepository();
        }

        private void FrmPurchaseEntry_Load(object sender, EventArgs e)
        {
            lblFormTitle.Text = Common.FormTitle;
            SetSelectionBackColor();
            tglSlip.IsOn = Common.PrintPurchaseSlip;
            dtPayDate.Enabled = Common.AllowToSelectPurchaseDueDate;

            SetThemeColors(Color.FromArgb(250, 243, 197));
            //SetThemeColors(Color.FromArgb(0));
            FillCombos();
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
                txtBuyerCommisionBalance.BackColor = color;
                txtPartyBalance.BackColor = color;
                txtBrokerBalance.BackColor = color;
            }
        }
        private async void FillCombos()
        {
            dtDate.EditValue = DateTime.Now;
            dtTime.EditValue = DateTime.Now;
            dtPayDate.EditValue = DateTime.Now;

            LoadPurchaseItemDetails();

            //Payment Mode
            luePaymentMode.Properties.DataSource = Common.GetPaymentType;
            luePaymentMode.Properties.DisplayMember = "PTypeName";
            luePaymentMode.Properties.ValueMember = "PTypeID";

            //Branch
            BranchMasterRepository branchMasterRepository = new BranchMasterRepository();
            var branchMaster = await branchMasterRepository.GetAllBranchAsync();
            lueBranch.Properties.DataSource = branchMaster;
            lueBranch.Properties.DisplayMember = "Name";
            lueBranch.Properties.ValueMember = "Id";

            //Currency
            CurrencyMasterRepository currencyMasterRepository = new CurrencyMasterRepository();
            var currencyMaster = await currencyMasterRepository.GetAllCurrencyAsync();
            lueCurrencyType.Properties.DataSource = currencyMaster;
            lueCurrencyType.Properties.DisplayMember = "Name";
            lueCurrencyType.Properties.ValueMember = "Id";

            //Buyer
            await GetBuyerList();

            //Party
            await GetPartyList();

            //Broker
            await GetBrokerList();
        }

        private async void LoadPurchaseItemDetails()
        {
            grdPurchaseDetails.DataSource = GetDTColumnsforPurchaseDetails();
            //Company
            LoadCompany();

            //Shape
            await GetShapeDetail();

            //Size
            GetSizeDetail(false);

            //Purity
            GetPurityDetail(false);

            //Kapan
            GetKapanDetail(false);
        }

        private async Task GetBuyerList()
        {
            var BuyerDetailList = await _partyMasterRepository.GetEmployeeAsync(PartyTypeMaster.Buyer);
            lueBuyer.Properties.DataSource = BuyerDetailList;
            lueBuyer.Properties.DisplayMember = "Name";
            lueBuyer.Properties.ValueMember = "Id";
        }

        private async Task GetPartyList()
        {
            var PartyDetailList = await _partyMasterRepository.GetPartyAsync();
            lueParty.Properties.DataSource = PartyDetailList;
            lueParty.Properties.DisplayMember = "Name";
            lueParty.Properties.ValueMember = "Id";
        }

        private async Task GetBrokerList()
        {
            var BrokerDetailList = await _partyMasterRepository.GetEmployeeAsync(PartyTypeMaster.Broker);
            lueBroker.Properties.DataSource = BrokerDetailList;
            lueBroker.Properties.DisplayMember = "Name";
            lueBroker.Properties.ValueMember = "Id";
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

        private async void LoadBranch(Guid companyId)
        {
            BranchMasterRepository branchMasterRepository = new BranchMasterRepository();
            var branches = await branchMasterRepository.GetCompanyBranchAsync(companyId); //_branchMasterRepository.GetAllBranchAsync();
            lueBranch.Properties.DataSource = branches;
            lueBranch.Properties.DisplayMember = "Name";
            lueBranch.Properties.ValueMember = "Id";
            lueBranch.EditValue = Common.LoginBranch;

            GetPurchaseNo(); //Serial No/Slip No
        }

        private async Task GetShapeDetail()
        {
            ShapeMasterRepository shapeMasterRepository = new ShapeMasterRepository();
            var shapeMaster = await shapeMasterRepository.GetAllShapeAsync();

            DataTable dt = ToDataTable(shapeMaster);

            repoShape.DataSource = dt;
            repoShape.DisplayMember = "Name";
            repoShape.ValueMember = "Id";
        }

        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties by using reflection   
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names  
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {

                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
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

        public async void GetPurchaseNo()
        {
            try
            {
                var SrNo = await _purchaseMasterRepository.GetMaxSrNo(Guid.Parse(lueCompany.EditValue.ToString()), Common.LoginFinancialYear);
                txtSerialNo.Text = SrNo.ToString();

                var SlipNo = await _purchaseMasterRepository.GetMaxSlipNo(Guid.Parse(lueBranch.EditValue.ToString()), Common.LoginFinancialYear);
                txtSlipNo.Text = SlipNo.ToString();
            }
            catch(Exception Ex)
            {
                MessageBox.Show("Error : " + Ex.Message.ToString(), "["+this.Name+"]", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private async void NewEntry(object sender, KeyEventArgs e)
        {
            string ControlName = ((DevExpress.XtraEditors.LookUpEdit)sender).Name;
            if (e.Control && e.KeyCode == Keys.N)
            {
                if (ControlName == lueBuyer.Name)
                {
                    Master.FrmPartyMaster frmPartyMaster = new Master.FrmPartyMaster();
                    frmPartyMaster.IsSilentEntry = true;
                    frmPartyMaster.LedgerType = PartyTypeMaster.Buyer;
                    if (frmPartyMaster.ShowDialog() == DialogResult.OK)
                    {
                        await GetBuyerList();
                        lueBuyer.EditValue = frmPartyMaster.CreatedLedgerID;
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

        private void FrmPurchaseEntry_KeyDown(object sender, KeyEventArgs e)
        {
            Common.MoveToNextControl(sender, e, this);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void repoShape_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                Master.FrmShapeMaster frmShapeMaster = new Master.FrmShapeMaster();
                frmShapeMaster.IsSilentEntry = true;
                if (frmShapeMaster.ShowDialog() == DialogResult.OK)
                {
                    await GetShapeDetail();
                    grvPurchaseDetails.SetFocusedRowCellValue(colShape, frmShapeMaster.CreatedLedgerID.ToString());
                }
            }
        }
    }
}