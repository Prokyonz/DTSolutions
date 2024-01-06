using DevExpress.Utils;
using DevExpress.XtraEditors;
using EFCore.SQL.Repository;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
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
        SlipTransferEntryRepository _slipTransferEntryRepository;
        private readonly BrokerageMasterRepository _brokerageMasterRepository;
        decimal ItemRunningWeight = 0;
        decimal ItemFinalAmount = 0;
        private string _selectedPurchaseId;
        private PurchaseMaster _editedPurchaseMaster;
        private PurchaseDetails _editedPurchaseDetails;
        private bool isLoading = false;
        private List<SlipTransferEntry> _slipTransferEntries;

        public FrmPurchaseEntry()
        {
            InitializeComponent();
            _purchaseMasterRepository = new PurchaseMasterRepository();
            _partyMasterRepository = new PartyMasterRepository();
            _brokerageMasterRepository = new BrokerageMasterRepository();
            _slipTransferEntryRepository = new SlipTransferEntryRepository();
            this.Text = "PURCHASE - " + Common.LoginCompanyName + " - [" + Common.LoginFinancialYearName + "]";
        }

        public FrmPurchaseEntry(string SelectedPurchaseId)
        {
            InitializeComponent();
            _purchaseMasterRepository = new PurchaseMasterRepository();
            _partyMasterRepository = new PartyMasterRepository();
            _brokerageMasterRepository = new BrokerageMasterRepository();
            _slipTransferEntryRepository = new SlipTransferEntryRepository();
            this.Text = "PURCHASE - " + Common.LoginCompanyName + " - [" + Common.LoginFinancialYearName + "]";
            _selectedPurchaseId = SelectedPurchaseId;
        }

        private async void FrmPurchaseEntry_Load(object sender, EventArgs e)
        {
            isLoading = true;
            lblFormTitle.Text = Common.FormTitle;
            SetSelectionBackColor();
            tglSlip.IsOn = Common.PrintPurchaseSlip;
            tglPF.IsOn = Common.PrintPurchasePF;
            dtPayDate.Enabled = Common.AllowToSelectPurchaseDueDate;
            _slipTransferEntries = new List<SlipTransferEntry>();
            SetThemeColors(Color.FromArgb(250, 243, 197));

            //SetThemeColors(Color.FromArgb(0));

            await LoadCompany();
            await FillCombos();
            //FillBranches();
            await FillCurrency();
            //FillCurrency();

            if (string.IsNullOrEmpty(_selectedPurchaseId) == false)
            {
                Console.WriteLine("1 :"+DateTime.Now);
                _editedPurchaseMaster = await _purchaseMasterRepository.GetPurchaseAsync(_selectedPurchaseId);
                Console.WriteLine("2 :" + DateTime.Now);
                //_EditedBrokerageMasterSet = _brokerageMaster.Where(s => s.Id == _selectedBrokerageId).FirstOrDefault();
                if (_editedPurchaseMaster != null)
                {
                    try
                    {
                        this.lueCompany.EditValueChanged -= new System.EventHandler(this.lueCompany_EditValueChanged);
                        this.lueBranch.EditValueChanged -= new System.EventHandler(this.lueBranch_EditValueChanged);
                        this.lueBuyer.EditValueChanged -= new System.EventHandler(this.lueBuyer_EditValueChanged);
                        this.lueParty.EditValueChanged -= new System.EventHandler(this.lueParty_EditValueChanged);
                        this.lueBroker.EditValueChanged -= new System.EventHandler(this.lueBroker_EditValueChanged);

                        btnSave.Text = AppMessages.GetString(AppMessageID.Update);
                        //grdPurchaseDetails.Enabled = false;

                        if (_editedPurchaseMaster.ApprovalType == 1)
                        if (_editedPurchaseMaster.ApprovalType == 1)
                            pnlStatus.Appearance.BackColor = Color.FromArgb(154, 205, 50);
                        else if (_editedPurchaseMaster.ApprovalType == 2)
                            pnlStatus.Appearance.BackColor = Color.FromArgb(255, 0, 0);
                        else
                            pnlStatus.Appearance.BackColor = Color.FromArgb(128, 128, 128);

                        lueCompany.EditValue = _editedPurchaseMaster.CompanyId;
                        lueBranch.EditValue = _editedPurchaseMaster.BranchId;
                        lueParty.EditValue = _editedPurchaseMaster.PartyId;
                        lueBuyer.EditValue = _editedPurchaseMaster.ByuerId;
                        lueCurrencyType.EditValue = _editedPurchaseMaster.CurrencyId;
                        //purchaseMaster.FinancialYearId = Common.LoginFinancialYear;
                        lueBroker.EditValue = _editedPurchaseMaster.BrokerageId;
                        txtCurrencyType.Text = _editedPurchaseMaster.CurrencyRate.ToString();
                        txtSerialNo.Text = _editedPurchaseMaster.PurchaseBillNo.ToString();
                        txtSlipNo.Text = _editedPurchaseMaster.SlipNo.ToString();
                        luePaymentMode.EditValue = _editedPurchaseMaster.TransactionType;
                        dtDate.EditValue = DateTime.ParseExact(_editedPurchaseMaster.Date, "yyyyMMdd", CultureInfo.InvariantCulture);
                        
                        dtTime.EditValue = DateTime.ParseExact(_editedPurchaseMaster.Time, "hh:mm:ss ttt", CultureInfo.InvariantCulture);
                        //purchaseMaster.DayName = Convert.ToDateTime(dtDate.EditValue).DayOfWeek.ToString();
                        
                        txtPartyBalance.Text = _editedPurchaseMaster.PartyLastBalanceWhilePurchase.ToString();
                        txtBrokerPer.Text = _editedPurchaseMaster.BrokerPercentage.ToString();
                        txtBrokerageAmount.Text = _editedPurchaseMaster.BrokerAmount.ToString();
                        txtRoundAmount.Text = _editedPurchaseMaster.RoundUpAmount.ToString();
                        txtAmount.Text = _editedPurchaseMaster.Total.ToString();
                        txtNetAmount.Text = _editedPurchaseMaster.GrossTotal.ToString();
                        txtDays.Text = _editedPurchaseMaster.DueDays.ToString();
                        //purchaseMaster.DueDate = Convert.ToDateTime(dtDate.Text).AddDays(Convert.ToInt32(txtDays.Text));
                        txtPaymentDays.Text = _editedPurchaseMaster.PaymentDays.ToString();
                        //purchaseMaster.PaymentDueDate = Convert.ToDateTime(dtPayDate.Text);
                        tglSlip.IsOn = _editedPurchaseMaster.IsSlip;
                        tglPF.IsOn = _editedPurchaseMaster.IsPF;
                        txtBuyerCommisionPer.Text = _editedPurchaseMaster.CommissionPercentage.ToString();
                        txtCommisionAmount.Text = _editedPurchaseMaster.CommissionAmount.ToString();
                        //if (Image1.Image != null)
                        //    purchaseMaster.Image1 = ImageToByteArray(Image1.Image);
                        //if (Image2.Image != null)
                        //    purchaseMaster.Image2 = ImageToByteArray(Image2.Image);
                        //if (Image3.Image != null)
                        //    purchaseMaster.Image3 = ImageToByteArray(Image3.Image);
                        //purchaseMaster.AllowSlipPrint = tglSlip.IsOn ? true : false;

                        txtRemark.Text = _editedPurchaseMaster.Remarks;

                        Console.WriteLine("3 :" + DateTime.Now);
                        KapanMappingMasterRepository kapanMappingMasterRepository = new KapanMappingMasterRepository();
                        var result = await kapanMappingMasterRepository.GetKapanMappingDetailAsync(_selectedPurchaseId);
                        if (result != null)
                        {
                            grdPurchaseDetails.Enabled = false;
                            btnSave.Enabled = false;
                            MessageBox.Show("You can not edit this entry as this entry already processed", "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        Console.WriteLine("4 :" + DateTime.Now);

                        Console.WriteLine("5 :" + DateTime.Now);
                        List<PurchaseDetails> EditedPurchaseDetail = await _purchaseMasterRepository.GetPurchaseDetailAsync(_selectedPurchaseId);
                        Console.WriteLine("6 :" + DateTime.Now);

                        for (int i = 0; i < EditedPurchaseDetail.Count; i++)
                        {
                            grvPurchaseDetails.AddNewRow();

                            //grvPurchaseDetails.SetFocusedRowCellValue(colShape, Common.DefaultShape);
                            //grvPurchaseDetails.SetFocusedRowCellValue(colSize, Common.DefaultSize);
                            //grvPurchaseDetails.SetFocusedRowCellValue(colPurity, Common.DefaultPurity);

                            //grvPurchaseDetails.SetRowCellValue(e.RowHandle, colCVDWeight, "0.00");
                            //grvPurchaseDetails.SetRowCellValue(e.RowHandle, colRejPer, "0.00");
                            //grvPurchaseDetails.SetRowCellValue(e.RowHandle, colRejCts, "0.00");
                            //grvPurchaseDetails.SetRowCellValue(e.RowHandle, colDisAmount, "0.00");
                            //grvPurchaseDetails.SetRowCellValue(e.RowHandle, colDisPer, "0.00");


                            //grvPurchaseDetails.SetRowCellValue(i, colKapan, EditedPurchaseDetail[i].KapanId);
                            grvPurchaseDetails.SetFocusedRowCellValue(colPurchaseDetailId, EditedPurchaseDetail[i].Id);
                            grvPurchaseDetails.SetFocusedRowCellValue(colShape, EditedPurchaseDetail[i].ShapeId);
                            grvPurchaseDetails.SetFocusedRowCellValue(colSize, EditedPurchaseDetail[i].SizeId);
                            grvPurchaseDetails.SetFocusedRowCellValue(colPurity, EditedPurchaseDetail[i].PurityId);

                            grvPurchaseDetails.SetFocusedRowCellValue(colCarat, EditedPurchaseDetail[i].Weight);

                            grvPurchaseDetails.SetFocusedRowCellValue(colTipWeight, EditedPurchaseDetail[i].TIPWeight);
                            grvPurchaseDetails.SetFocusedRowCellValue(colCVDWeight,EditedPurchaseDetail[i].CVDWeight);
                            grvPurchaseDetails.SetFocusedRowCellValue(colRejPer, EditedPurchaseDetail[i].RejectedPercentage);
                            grvPurchaseDetails.SetFocusedRowCellValue(colRejCts, EditedPurchaseDetail[i].RejectedWeight);
                            grvPurchaseDetails.SetFocusedRowCellValue(colLessCts, EditedPurchaseDetail[i].LessWeight);
                            grvPurchaseDetails.SetFocusedRowCellValue(colDisPer, EditedPurchaseDetail[i].LessDiscountPercentage);
                            grvPurchaseDetails.SetFocusedRowCellValue(colDisAmount, EditedPurchaseDetail[i].LessWeightDiscount);
                            grvPurchaseDetails.SetFocusedRowCellValue(colNetCts, EditedPurchaseDetail[i].NetWeight);
                            grvPurchaseDetails.SetFocusedRowCellValue(colRate, EditedPurchaseDetail[i].BuyingRate);
                            grvPurchaseDetails.SetFocusedRowCellValue(colCVDCharge, EditedPurchaseDetail[i].CVDCharge);
                            grvPurchaseDetails.SetFocusedRowCellValue(colCVDAmount, EditedPurchaseDetail[i].CVDAmount);
                            grvPurchaseDetails.SetFocusedRowCellValue(colAmount, EditedPurchaseDetail[i].Amount);
                            grvPurchaseDetails.SetFocusedRowCellValue(colCurrRate, EditedPurchaseDetail[i].CurrencyRate);
                            grvPurchaseDetails.SetFocusedRowCellValue(colCurrAmount, EditedPurchaseDetail[i].CurrencyAmount);
                            grvPurchaseDetails.UpdateCurrentRow();
                        }

                        if (!string.IsNullOrEmpty(_editedPurchaseMaster.TransferParentId))
                        {
                            _slipTransferEntries = await LoadSlipTransferDetails(Convert.ToInt32(_editedPurchaseMaster.TransferParentId));
                            grdSlipParticularsDetails.DataSource = _slipTransferEntries;
                        }

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
                        }
                        catch
                        {
                            Logo = null;
                            ms = null;
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {
                        this.lueCompany.EditValueChanged += new System.EventHandler(this.lueCompany_EditValueChanged);
                        this.lueBranch.EditValueChanged += new System.EventHandler(this.lueBranch_EditValueChanged);
                        this.lueBuyer.EditValueChanged += new System.EventHandler(this.lueBuyer_EditValueChanged);
                        this.lueParty.EditValueChanged += new System.EventHandler(this.lueParty_EditValueChanged);
                        this.lueBroker.EditValueChanged += new System.EventHandler(this.lueBroker_EditValueChanged);
                    }
                }
            }
            timer1.Start();
            isLoading = false;
        }

        private async Task LoadCompany()
        {
            CompanyMasterRepository companyMasterRepository = new CompanyMasterRepository();
            var companies = await companyMasterRepository.GetUserCompanyMappingAsync(Common.LoginUserID);
            lueCompany.Properties.DataSource = companies;
            lueCompany.Properties.DisplayMember = "Name";
            lueCompany.Properties.ValueMember = "Id";

            lueCompany.EditValue = Common.LoginCompany;
            await LoadBranch(Common.LoginCompany);
        }

        private async Task<List<SlipTransferEntry>> LoadSlipTransferDetails(int SlipTransferId)
        {
            var slipTranferDetails = await _slipTransferEntryRepository.GetSlipTransferEntriesAsync(SlipTransferId, 0, Common.LoginFinancialYear);
            return slipTranferDetails;
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
                txtBuyerCommisionPer.BackColor = color;
                txtPartyBalance.BackColor = color;
                txtBrokerPer.BackColor = color;
            }
        }

        private async void FillBranches()
        {
            //Branch
            BranchMasterRepository branchMasterRepository = new BranchMasterRepository();
            var branchMaster = await branchMasterRepository.GetAllBranchAsync(Common.LoginCompany);
            lueBranch.Properties.DataSource = branchMaster;
            lueBranch.Properties.DisplayMember = "Name";
            lueBranch.Properties.ValueMember = "Id";
        }

        private async Task FillCurrency()
        {
            //Currency
            CurrencyMasterRepository currencyMasterRepository = new CurrencyMasterRepository();
            var currencyMaster = await currencyMasterRepository.GetAllCurrencyAsync(Common.LoginCompany);
            lueCurrencyType.Properties.DataSource = currencyMaster;
            lueCurrencyType.Properties.DisplayMember = "Name";
            lueCurrencyType.Properties.ValueMember = "Id";

            var defaultcurrency = currencyMaster.Where(x => x.ShortName.ToLower().Contains("inr")).FirstOrDefault();
            if (defaultcurrency != null)
            {
                //lueCurrencyType.EditValue = "8cb0a7f4-5a1b-4cd1-a03f-9ba4dd79ad90";
                lueCurrencyType.EditValue = defaultcurrency.Id;
            }
        }

        private async Task FillCombos()
        {
            dtDate.EditValue = DateTime.Now;
            dtTime.EditValue = DateTime.Now;
            dtPayDate.EditValue = DateTime.Now;

            await LoadPurchaseItemDetails();

            //Payment Mode
            luePaymentMode.Properties.DataSource = Common.GetPaymentType;
            luePaymentMode.Properties.DisplayMember = "PTypeName";
            luePaymentMode.Properties.ValueMember = "PTypeID";
            luePaymentMode.EditValue = 1;

            //Buyer
            await GetBuyerList();

            //Party
            await GetPartyList();

            //Broker
            await GetBrokerList();
        }

        private async Task LoadPurchaseItemDetails()
        {
            grdPurchaseDetails.DataSource = GetDTColumnsforPurchaseDetails();            

            //Shape
            await GetShapeDetail();

            //Size
            await GetSizeDetail();

            //Purity
            await GetPurityDetail();

            //Kapan
            await GetKapanDetail();
        }

        private async Task GetBuyerList()
        {
            string companyId = Common.LoginCompany ;
            if(lueCompany.EditValue != null)
            {
                if (lueCompany.EditValue.ToString() != Common.LoginCompany)
                    companyId = lueCompany.EditValue.ToString();
            }
            var BuyerDetailList = await _partyMasterRepository.GetAllPartyAsync(companyId, PartyTypeMaster.Employee, new int[] { PartyTypeMaster.Buyer });
            lueBuyer.Properties.DataSource = BuyerDetailList;
            lueBuyer.Properties.DisplayMember = "Name";
            lueBuyer.Properties.ValueMember = "Id";
        }

        private async Task GetPartyList()
        {
            string companyId = Common.LoginCompany;
            if (lueCompany.EditValue != null)
            {
                if (lueCompany.EditValue.ToString() != Common.LoginCompany)
                    companyId = lueCompany.EditValue.ToString();
            }
            var PartyDetailList = await _partyMasterRepository.GetAllPartyAsync(companyId, PartyTypeMaster.PartyBuy);
            lueParty.Properties.DataSource = PartyDetailList;
            lueParty.Properties.DisplayMember = "Name";
            lueParty.Properties.ValueMember = "Id";
        }

        private async Task GetBrokerList()
        {
            string companyId = Common.LoginCompany;
            if (lueCompany.EditValue != null)
            {
                if (lueCompany.EditValue.ToString() != Common.LoginCompany)
                    companyId = lueCompany.EditValue.ToString();
            }
            var BrokerDetailList = await _partyMasterRepository.GetAllPartyAsync(companyId, PartyTypeMaster.Employee, new int[] { PartyTypeMaster.Broker });
            lueBroker.Properties.DataSource = BrokerDetailList;
            lueBroker.Properties.DisplayMember = "Name";
            lueBroker.Properties.ValueMember = "Id";
        }
        
        private async Task LoadBranch(string companyId)
        {
            BranchMasterRepository branchMasterRepository = new BranchMasterRepository();
            var branches = await branchMasterRepository.GetAllBranchAsync(companyId); //_branchMasterRepository.GetAllBranchAsync();
            lueBranch.Properties.DataSource = branches;
            lueBranch.Properties.DisplayMember = "Name";
            lueBranch.Properties.ValueMember = "Id";
            lueBranch.EditValue = Common.LoginBranch;

            await GetPurchaseNo(); //Serial No/Slip No
        }

        private async Task GetShapeDetail()
        {
            ShapeMasterRepository shapeMasterRepository = new ShapeMasterRepository();
            var shapeMaster = await shapeMasterRepository.GetAllShapeAsync();
            repoShape.DataSource = shapeMaster;
            repoShape.DisplayMember = "Name";
            repoShape.ValueMember = "Id";
        }

        private async Task GetSizeDetail()
        {
            SizeMasterRepository sizeMasterRepository = new SizeMasterRepository();
            var sizeMaster = await sizeMasterRepository.GetAllSizeAsync();
            repoSize.DataSource = sizeMaster;
            repoSize.DisplayMember = "Name";
            repoSize.ValueMember = "Id";
        }

        private async Task GetPurityDetail()
        {
            PurityMasterRepository purityMasterRepository = new PurityMasterRepository();
            var purityMaster = await purityMasterRepository.GetAllPurityAsync();
            repoPurity.DataSource = purityMaster;
            repoPurity.DisplayMember = "Name";
            repoPurity.ValueMember = "Id";
        }

        private async Task GetKapanDetail()
        {
            KapanMasterRepository kapanMasterRepository = new KapanMasterRepository();
            var kapanMaster = await kapanMasterRepository.GetAllKapanAsync(Common.LoginCompany);
            repoKapan.DataSource = kapanMaster;
            repoKapan.DisplayMember = "Name";
            repoKapan.ValueMember = "Id";
        }

        public async Task GetPurchaseNo(bool updateSlip = true)
        {
            try
            {
                var SrNo = await _purchaseMasterRepository.GetMaxSrNo(lueBranch.EditValue.ToString(), Common.LoginFinancialYear);
                txtSerialNo.Text = SrNo.ToString();

                if (updateSlip)
                {
                    var SlipNo = await _purchaseMasterRepository.GetMaxSlipNo(lueCompany.EditValue.ToString(), Common.LoginFinancialYear);
                    txtSlipNo.Text = SlipNo.ToString();
                }
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
                        lueBuyer.BackColor = default;
                        lueBuyer.Tag = lueBuyer.BackColor;
                        lueBuyer.Focus();
                    }
                }
                else if (ControlName == lueParty.Name)
                {
                    Master.FrmPartyMaster frmPartyMaster = new Master.FrmPartyMaster();
                    frmPartyMaster.IsSilentEntry = true;
                    frmPartyMaster.LedgerType = PartyTypeMaster.PartyBuy;
                    if (frmPartyMaster.ShowDialog() == DialogResult.OK)
                    {
                        await GetPartyList();
                        lueParty.EditValue = frmPartyMaster.CreatedLedgerID;
                        lueParty.BackColor = default;
                        lueParty.Tag = lueParty.BackColor;
                        lueParty.Focus();
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
                        lueBroker.BackColor = default;
                        lueBroker.Tag = lueBroker.BackColor;
                        lueBroker.Focus();
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
            dt.Columns.Add("DisAmount");
            dt.Columns.Add("CVDAmount");
            dt.Columns.Add("PurchaseDetailId");
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

        private async void repoSize_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                Master.FrmSizeMaster frmSizeMaster = new Master.FrmSizeMaster();
                frmSizeMaster.IsSilentEntry = true;
                if (frmSizeMaster.ShowDialog() == DialogResult.OK)
                {
                    await GetSizeDetail();
                    grvPurchaseDetails.SetFocusedRowCellValue(colSize, frmSizeMaster.CreatedLedgerID.ToString());
                }
            }
        }

        private async void repoPurity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                Master.FrmPurityMaster frmPurityMaster = new Master.FrmPurityMaster();
                frmPurityMaster.IsSilentEntry = true;
                if (frmPurityMaster.ShowDialog() == DialogResult.OK)
                {
                    await GetPurityDetail();
                    grvPurchaseDetails.SetFocusedRowCellValue(colPurity, frmPurityMaster.CreatedLedgerID.ToString());
                }
            }
        }

        private async void repoKapan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                Master.FrmKapanMaster frmKapanMaster = new Master.FrmKapanMaster();
                frmKapanMaster.IsSilentEntry = true;
                if (frmKapanMaster.ShowDialog() == DialogResult.OK)
                {
                    await GetKapanDetail();
                    grvPurchaseDetails.SetFocusedRowCellValue(colKapan, frmKapanMaster.CreatedLedgerID.ToString());
                }
            }
        }

        private async void grvPurchaseDetails_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == colCarat || e.Column == colCVDWeight)
                {
                    decimal TipWeight = Convert.ToDecimal(lueBranch.GetColumnValue("TipWeight"));
                    decimal CVDWeight = Convert.ToDecimal(lueBranch.GetColumnValue("CVDWeight"));
                    await GetLessWeightDetailBasedOnCity(lueBranch.GetColumnValue("LessWeightId").ToString(), Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(e.RowHandle, colCarat)), e.RowHandle, TipWeight, CVDWeight);
                }
                else if (e.Column == colRejPer)
                {
                    CalculateRejectionValue(true, e.RowHandle);
                }
                else if (e.Column == colRejCts)
                {
                    CalculateRejectionValue(false, e.RowHandle);
                }

                FinalCalculation(e.RowHandle, false);
            }
            catch
            {
            }
        }

        private void grvPurchaseDetails_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //GetTotal();
        }

        private void grvPurchaseDetails_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            //BeginInvoke(new Action(() =>
            //{
                //    grvPurchaseDetails.SetRowCellValue(e.RowHandle, colShape, Common.DefaultShape);
                //    grvPurchaseDetails.SetRowCellValue(e.RowHandle, colSize, Common.DefaultSize);
                //    grvPurchaseDetails.SetRowCellValue(e.RowHandle, colPurity, Common.DefaultPurity);

                grvPurchaseDetails.SetRowCellValue(e.RowHandle, colCVDWeight, "0");
                grvPurchaseDetails.SetRowCellValue(e.RowHandle, colRejPer, "0");
                grvPurchaseDetails.SetRowCellValue(e.RowHandle, colRejCts, "0");
                grvPurchaseDetails.SetRowCellValue(e.RowHandle, colDisAmount, "0");
                grvPurchaseDetails.SetRowCellValue(e.RowHandle, colDisPer, "0");
            //}));
        }

        private void grvPurchaseDetails_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (!isLoading)
            {
                BeginInvoke(new Action(() =>
                {
                    GetTotal();
                    if (MessageBox.Show("Do you want add more Items...???", "confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
                    {
                    //grvPurchaseDetails.CloseEditor();
                    grvPurchaseDetails.HideEditor();
                        grvPurchaseDetails.CancelUpdateCurrentRow();
                        txtRemark.Select();
                        txtRemark.Focus();
                    //IsFocusMoveToOutsideGrid = true;
                    //this.SelectNextControl(txtRemark, true, true, true, true);
                }
                }));
            }
        }

        private void grvPurchaseDetails_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (grvPurchaseDetails.GetRowCellValue(e.RowHandle, colShape) == null || (grvPurchaseDetails.GetRowCellValue(e.RowHandle, colShape) != null && grvPurchaseDetails.GetRowCellValue(e.RowHandle, colShape).ToString().Trim().Length == 0))
            {
                e.ErrorText = "Please enter Shape detail.";
                grvPurchaseDetails.FocusedRowHandle = e.RowHandle;
                grvPurchaseDetails.FocusedColumn = colShape;
                e.Valid = false;
            }
            else if (grvPurchaseDetails.GetRowCellValue(e.RowHandle, colSize) == null || (grvPurchaseDetails.GetRowCellValue(e.RowHandle, colSize) != null && grvPurchaseDetails.GetRowCellValue(e.RowHandle, colSize).ToString().Trim().Length == 0))
            {
                e.ErrorText = "Please enter Size detail.";
                grvPurchaseDetails.FocusedRowHandle = e.RowHandle;
                grvPurchaseDetails.FocusedColumn = colSize;
                e.Valid = false;
            }
            else if (grvPurchaseDetails.GetRowCellValue(e.RowHandle, colPurity) == null || (grvPurchaseDetails.GetRowCellValue(e.RowHandle, colPurity) != null && grvPurchaseDetails.GetRowCellValue(e.RowHandle, colPurity).ToString().Trim().Length == 0))
            {
                e.ErrorText = "Please enter Purity detail.";
                grvPurchaseDetails.FocusedRowHandle = e.RowHandle;
                grvPurchaseDetails.FocusedColumn = colPurity;
                e.Valid = false;
            }
            //else if (grvPurchaseDetails.GetRowCellValue(e.RowHandle, colKapan) == null || (grvPurchaseDetails.GetRowCellValue(e.RowHandle, colKapan) != null && grvPurchaseDetails.GetRowCellValue(e.RowHandle, colKapan).ToString().Trim().Length == 0))
            //{
            //    e.ErrorText = "Please enter Kapan detail.";
            //    grvPurchaseDetails.FocusedRowHandle = e.RowHandle;
            //    grvPurchaseDetails.FocusedColumn = colKapan;
            //    e.Valid = false;
            //}         
            else if (grvPurchaseDetails.GetRowCellValue(e.RowHandle, colCarat) == null || (grvPurchaseDetails.GetRowCellValue(e.RowHandle, colCarat) != null && grvPurchaseDetails.GetRowCellValue(e.RowHandle, colCarat).ToString().Trim().Length == 0))
            {
                e.ErrorText = "Please enter Carat detail.";
                grvPurchaseDetails.FocusedRowHandle = e.RowHandle;
                grvPurchaseDetails.FocusedColumn = colCarat;
                e.Valid = false;
            }
            else if (grvPurchaseDetails.GetRowCellValue(e.RowHandle, colTipWeight) == null || (grvPurchaseDetails.GetRowCellValue(e.RowHandle, colTipWeight) != null && grvPurchaseDetails.GetRowCellValue(e.RowHandle, colTipWeight).ToString().Trim().Length == 0))
            {
                e.ErrorText = "Please enter Tip Weight detail.";
                grvPurchaseDetails.FocusedRowHandle = e.RowHandle;
                grvPurchaseDetails.FocusedColumn = colTipWeight;
                e.Valid = false;
            }
            else if (grvPurchaseDetails.GetRowCellValue(e.RowHandle, colCVDWeight) == null || (grvPurchaseDetails.GetRowCellValue(e.RowHandle, colCVDWeight) != null && grvPurchaseDetails.GetRowCellValue(e.RowHandle, colCVDWeight).ToString().Trim().Length == 0))
            {
                e.ErrorText = "Please enter CVD Weight detail.";
                grvPurchaseDetails.FocusedRowHandle = e.RowHandle;
                grvPurchaseDetails.FocusedColumn = colCVDWeight;
                e.Valid = false;
            }
            else if (grvPurchaseDetails.GetRowCellValue(e.RowHandle, colRejPer) == null || (grvPurchaseDetails.GetRowCellValue(e.RowHandle, colRejPer) != null && grvPurchaseDetails.GetRowCellValue(e.RowHandle, colRejPer).ToString().Trim().Length == 0))
            {
                e.ErrorText = "Please enter Rejection (%) detail.";
                grvPurchaseDetails.FocusedRowHandle = e.RowHandle;
                grvPurchaseDetails.FocusedColumn = colRejPer;
                e.Valid = false;
            }
            else if (grvPurchaseDetails.GetRowCellValue(e.RowHandle, colRejCts) == null || (grvPurchaseDetails.GetRowCellValue(e.RowHandle, colRejCts) != null && grvPurchaseDetails.GetRowCellValue(e.RowHandle, colRejCts).ToString().Trim().Length == 0))
            {
                e.ErrorText = "Please enter Rejection Weight detail.";
                grvPurchaseDetails.FocusedRowHandle = e.RowHandle;
                grvPurchaseDetails.FocusedColumn = colRejCts;
                e.Valid = false;
            }
            else if (grvPurchaseDetails.GetRowCellValue(e.RowHandle, colLessCts) == null || (grvPurchaseDetails.GetRowCellValue(e.RowHandle, colLessCts) != null && grvPurchaseDetails.GetRowCellValue(e.RowHandle, colLessCts).ToString().Trim().Length == 0))
            {
                e.ErrorText = "Please enter Less Weight detail.";
                grvPurchaseDetails.FocusedRowHandle = e.RowHandle;
                grvPurchaseDetails.FocusedColumn = colLessCts;
                e.Valid = false;
            }
            else if (grvPurchaseDetails.GetRowCellValue(e.RowHandle, colNetCts) == null || (grvPurchaseDetails.GetRowCellValue(e.RowHandle, colNetCts) != null && grvPurchaseDetails.GetRowCellValue(e.RowHandle, colNetCts).ToString().Trim().Length == 0))
            {
                e.ErrorText = "Please enter Final Carat detail.";
                grvPurchaseDetails.FocusedRowHandle = e.RowHandle;
                grvPurchaseDetails.FocusedColumn = colNetCts;
                e.Valid = false;
            }
            else if (grvPurchaseDetails.GetRowCellValue(e.RowHandle, colRate) == null || (grvPurchaseDetails.GetRowCellValue(e.RowHandle, colRate) != null && grvPurchaseDetails.GetRowCellValue(e.RowHandle, colRate).ToString().Trim().Length == 0))
            {
                e.ErrorText = "Please enter packet Rate detail.";
                grvPurchaseDetails.FocusedRowHandle = e.RowHandle;
                grvPurchaseDetails.FocusedColumn = colRate;
                e.Valid = false;
            }
            else if (grvPurchaseDetails.GetRowCellValue(e.RowHandle, colDisPer) == null || (grvPurchaseDetails.GetRowCellValue(e.RowHandle, colDisPer) != null && grvPurchaseDetails.GetRowCellValue(e.RowHandle, colDisPer).ToString().Trim().Length == 0))
            {
                e.ErrorText = "Please enter Disc (%) detail.";
                grvPurchaseDetails.FocusedRowHandle = e.RowHandle;
                grvPurchaseDetails.FocusedColumn = colDisPer;
                e.Valid = false;
            }
            else if (grvPurchaseDetails.GetRowCellValue(e.RowHandle, colCVDCharge) == null || (grvPurchaseDetails.GetRowCellValue(e.RowHandle, colCVDCharge) != null && grvPurchaseDetails.GetRowCellValue(e.RowHandle, colCVDCharge).ToString().Trim().Length == 0))
            {
                e.ErrorText = "Please enter CVD charge detail.";
                grvPurchaseDetails.FocusedRowHandle = e.RowHandle;
                grvPurchaseDetails.FocusedColumn = colCVDCharge;
                e.Valid = false;
            }
            else
            {
                //if (MessageBox.Show("Do you want add more Items...???", "confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
                //{
                //    if (grvPurchaseItems.ValidateEditor())
                //        grvPurchaseItems.UpdateCurrentRow();
                //    //grvPurchaseItems.ValidateEditor();
                //    grvPurchaseItems.Focus();
                //    txtDueDays.Select();
                //    txtDueDays.Focus();
                //}                    
            }
        }

        private async Task GetLessWeightDetailBasedOnCity(string GroupName, decimal Weight, int GridRowIndex, decimal TipWeight, decimal CVDWeight)
        {
            try
            {
                if (!string.IsNullOrEmpty(GroupName) && Weight > 0)
                {
                    LessWeightMasterRepository lessWeightMasterRepository = new LessWeightMasterRepository();
                    LessWeightDetails lessWeightDetails = await lessWeightMasterRepository.GetLessWeightDetailsMasters(GroupName,Weight);
                    
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

        private async void FinalCalculation(int GridRowIndex, bool isBranchChange = false)
        {
            try
            {
                this.grvPurchaseDetails.CellValueChanged -= new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvPurchaseDetails_CellValueChanged);
                if(isBranchChange)
                {
                    decimal TipWeight = Convert.ToDecimal(lueBranch.GetColumnValue("TipWeight"));
                    decimal CVDWeight = Convert.ToDecimal(lueBranch.GetColumnValue("CVDWeight"));
                    await GetLessWeightDetailBasedOnCity(lueBranch.GetColumnValue("LessWeightId").ToString(), Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(GridRowIndex, colCarat)), GridRowIndex, TipWeight, CVDWeight);
                }

                decimal Carat = 0;
                if (grvPurchaseDetails.GetRowCellValue(GridRowIndex, colCarat) != null && grvPurchaseDetails.GetRowCellValue(GridRowIndex, colCarat).ToString().Length != 0)
                    Carat = Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(GridRowIndex, colCarat));

                decimal TipCts = 0;
                if (grvPurchaseDetails.GetRowCellValue(GridRowIndex, colTipWeight) != null && grvPurchaseDetails.GetRowCellValue(GridRowIndex, colTipWeight).ToString().Length != 0)
                    TipCts = Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(GridRowIndex, colTipWeight));

                decimal CVDCts = 0;
                if (grvPurchaseDetails.GetRowCellValue(GridRowIndex, colCVDWeight) != null && grvPurchaseDetails.GetRowCellValue(GridRowIndex, colCVDWeight).ToString().Length != 0)
                {
                    CVDCts = Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(GridRowIndex, colCVDWeight));
                    if (CVDCts <= 0)
                    {
                        grvPurchaseDetails.SetRowCellValue(GridRowIndex, colCVDCharge, 0);
                        grvPurchaseDetails.SetRowCellValue(GridRowIndex, colCVDAmount, 0);
                    }
                }

                decimal RejCts = 0;
                if (grvPurchaseDetails.GetRowCellValue(GridRowIndex, colRejCts) != null && grvPurchaseDetails.GetRowCellValue(GridRowIndex, colRejCts).ToString().Length != 0)
                    RejCts = Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(GridRowIndex, colRejCts));

                decimal LessCts = 0;
                if (grvPurchaseDetails.GetRowCellValue(GridRowIndex, colLessCts) != null && grvPurchaseDetails.GetRowCellValue(GridRowIndex, colLessCts).ToString().Length != 0)
                    LessCts = Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(GridRowIndex, colLessCts));

                ItemRunningWeight = Carat - TipCts - CVDCts - RejCts - LessCts;

                grvPurchaseDetails.SetRowCellValue(GridRowIndex, colNetCts, ItemRunningWeight);
                //txtNetWeight.Text = ItemRunningWeight.ToString();

                decimal Amount = 0;
                decimal FinalAmount = 0;
                if (grvPurchaseDetails.GetRowCellValue(GridRowIndex, colRate) != null && grvPurchaseDetails.GetRowCellValue(GridRowIndex, colRate).ToString().Trim().Length > 0)
                {
                    Amount = Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(GridRowIndex, colRate));
                    FinalAmount = ItemRunningWeight * Amount;
                }
                if (grvPurchaseDetails.GetRowCellValue(GridRowIndex, colDisPer) != null && grvPurchaseDetails.GetRowCellValue(GridRowIndex, colDisPer).ToString().Trim().Length > 0)
                {
                    decimal LessPer = Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(GridRowIndex, colDisPer));
                    if (LessPer < 0)
                        LessPer *= -1;
                    decimal LessAmt = (FinalAmount * LessPer) / 100;
                    FinalAmount -= LessAmt;

                    grvPurchaseDetails.SetRowCellValue(GridRowIndex, colDisAmount, LessAmt);
                }
                if (grvPurchaseDetails.GetRowCellValue(GridRowIndex, colCVDCharge) != null && grvPurchaseDetails.GetRowCellValue(GridRowIndex, colCVDCharge).ToString().Trim().Length > 0)
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
                if (!isLoading)
                {
                    if (txtBrokerPer.Text.ToString().Trim().Length == 0)
                        txtBrokerPer.Text = "0";
                    if (IsCalculateRate)
                    {
                        try
                        {
                            if (Convert.ToDecimal(txtNetAmount.Text) != 0 && txtBrokerPer.Text.Trim().Length != 0)
                            {
                                decimal BrokerageAmount = Convert.ToDecimal(txtNetAmount.Text) + ((Convert.ToDecimal(txtNetAmount.Text) * Convert.ToDecimal(txtBrokerPer.Text)) / 100);
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
                                txtBrokerPer.Text = (100 - (BrokeragePer > 0 ? BrokeragePer : (BrokeragePer * -1))).ToString("0.00");
                            }
                        }
                        catch
                        {
                            txtBrokerPer.Text = "";
                        }
                    }

                    SetGridViewFocus();
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
                if (!isLoading)
                {
                    if (txtBuyerCommisionPer.Text.ToString().Trim().Length == 0)
                        txtBuyerCommisionPer.Text = "0";
                    if (IsCalculateRate)
                    {
                        try
                        {
                            if (Convert.ToDecimal(txtNetAmount.Text) != 0 && txtBuyerCommisionPer.Text.Trim().Length != 0)
                            {
                                decimal CommisionAmount = Convert.ToDecimal(txtNetAmount.Text) + ((Convert.ToDecimal(txtNetAmount.Text) * Convert.ToDecimal(txtBuyerCommisionPer.Text)) / 100);
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
                                txtBuyerCommisionPer.Text = (100 - (CommisionPer > 0 ? CommisionPer : (CommisionPer * -1))).ToString("0.00");
                            }
                        }
                        catch
                        {
                            txtBuyerCommisionPer.Text = "";
                        }
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

        private void txtBuyerCommisionPer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CalculateCommisionRate(true);
            }
        }

        private void txtBuyerCommisionPer_Leave(object sender, EventArgs e)
        {
            CalculateCommisionRate(true);
        }

        private void txtCommisionAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //CalculateCommisionRate(false);
            }
        }

        private void txtCommisionAmount_Leave(object sender, EventArgs e)
        {
            //CalculateCommisionRate(false);
        }

        private void txtBrokerPer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CalculateBrokerageRate(true);
            }
        }

        private void txtBrokerPer_Leave(object sender, EventArgs e)
        {
            CalculateBrokerageRate(true);
        }

        private void txtBrokerageAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //CalculateBrokerageRate(false);
            }
        }

        private void txtBrokerageAmount_Leave(object sender, EventArgs e)
        {
            //CalculateBrokerageRate(false);
        }

        private Image LoadImage()
        {
            Image newimage=null;
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

                if (btnSave.Text == AppMessages.GetString(AppMessageID.Save))
                {
                    string PurchaseId = Guid.NewGuid().ToString();
                    //string PurchaseDetailsId = Guid.NewGuid().ToString();

                    List<PurchaseDetails> purchaseDetailsList = new List<PurchaseDetails>();
                    PurchaseDetails purchaseDetails = new PurchaseDetails();
                    for (int i = 0; i < grvPurchaseDetails.RowCount; i++)
                    {
                        purchaseDetails = new PurchaseDetails();
                        purchaseDetails.Id = Guid.NewGuid().ToString();
                        purchaseDetails.PurchaseId = PurchaseId;
                        purchaseDetails.KapanId = grvPurchaseDetails.GetRowCellValue(i, colKapan).ToString();
                        purchaseDetails.ShapeId = grvPurchaseDetails.GetRowCellValue(i, colShape).ToString();
                        purchaseDetails.SizeId = grvPurchaseDetails.GetRowCellValue(i, colSize).ToString();
                        purchaseDetails.PurityId = grvPurchaseDetails.GetRowCellValue(i, colPurity).ToString();

                        purchaseDetails.Weight = Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(i, colCarat).ToString());
                        purchaseDetails.TIPWeight = Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(i, colTipWeight).ToString());
                        purchaseDetails.CVDWeight = Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(i, colCVDWeight).ToString());
                        purchaseDetails.RejectedPercentage = Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(i, colRejPer).ToString());
                        purchaseDetails.RejectedWeight = Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(i, colRejCts).ToString());
                        purchaseDetails.LessWeight = Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(i, colLessCts).ToString());
                        purchaseDetails.LessDiscountPercentage = Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(i, colDisPer).ToString());
                        purchaseDetails.LessWeightDiscount = Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(i, colDisAmount).ToString());
                        purchaseDetails.NetWeight = Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(i, colNetCts).ToString());
                        purchaseDetails.BuyingRate = float.Parse(grvPurchaseDetails.GetRowCellValue(i, colRate).ToString());
                        purchaseDetails.CVDCharge = float.Parse(grvPurchaseDetails.GetRowCellValue(i, colCVDCharge).ToString());
                        purchaseDetails.CVDAmount = float.Parse(grvPurchaseDetails.GetRowCellValue(i, colCVDAmount).ToString());
                        purchaseDetails.Amount = float.Parse(grvPurchaseDetails.GetRowCellValue(i, colAmount).ToString());
                        purchaseDetails.CurrencyRate = float.Parse(grvPurchaseDetails.GetRowCellValue(i, colCurrRate).ToString());
                        purchaseDetails.CurrencyAmount = float.Parse(grvPurchaseDetails.GetRowCellValue(i, colCurrAmount).ToString());
                        purchaseDetails.IsTransfer = false;
                        purchaseDetails.TransferParentId = null;
                        purchaseDetails.CreatedDate = DateTime.Now;
                        purchaseDetails.CreatedBy = Common.LoginUserID;
                        purchaseDetails.UpdatedDate = DateTime.Now;
                        purchaseDetails.UpdatedBy = Common.LoginUserID;

                        purchaseDetailsList.Insert(i, purchaseDetails);
                    }

                    PurchaseMaster purchaseMaster = new PurchaseMaster();
                    purchaseMaster.Id = PurchaseId;
                    purchaseMaster.CompanyId = lueCompany.GetColumnValue("Id").ToString();
                    purchaseMaster.BranchId = lueBranch.GetColumnValue("Id").ToString();
                    purchaseMaster.PartyId = lueParty.GetColumnValue("Id").ToString();
                    purchaseMaster.ByuerId = lueBuyer.GetColumnValue("Id").ToString();
                    purchaseMaster.CurrencyId = lueCurrencyType.GetColumnValue("Id").ToString();
                    purchaseMaster.FinancialYearId = Common.LoginFinancialYear;
                    purchaseMaster.BrokerageId = lueBroker.GetColumnValue("Id").ToString();
                    purchaseMaster.CurrencyRate = Convert.ToDecimal(txtCurrencyType.Text);
                    purchaseMaster.PurchaseBillNo = Convert.ToInt32(txtSerialNo.Text);
                    purchaseMaster.SlipNo = Convert.ToInt32(txtSlipNo.Text);
                    purchaseMaster.TransactionType = Convert.ToInt32(luePaymentMode.GetColumnValue("PTypeID"));
                    purchaseMaster.Date = Convert.ToDateTime(dtDate.Text).ToString("yyyyMMdd");
                    purchaseMaster.Time = Convert.ToDateTime(dtTime.Text).ToString("hh:mm:ss ttt");
                    purchaseMaster.DayName = Convert.ToDateTime(dtDate.EditValue).DayOfWeek.ToString();
                    purchaseMaster.PartyLastBalanceWhilePurchase = float.Parse(txtPartyBalance.Text);
                    purchaseMaster.BrokerPercentage = Convert.ToDecimal(txtBrokerPer.Text);
                    purchaseMaster.BrokerAmount = float.Parse(txtBrokerageAmount.Text);
                    purchaseMaster.RoundUpAmount = float.Parse(txtRoundAmount.Text);
                    purchaseMaster.Total = float.Parse(txtAmount.Text);
                    purchaseMaster.GrossTotal = float.Parse(txtNetAmount.Text);
                    purchaseMaster.DueDays = Convert.ToInt32(txtDays.Text);
                    purchaseMaster.DueDate = Convert.ToDateTime(dtDate.Text).AddDays(Convert.ToInt32(txtDays.Text));
                    purchaseMaster.PaymentDays = Convert.ToInt32(txtPaymentDays.Text);
                    purchaseMaster.PaymentDueDate = Convert.ToDateTime(dtPayDate.Text);
                    purchaseMaster.IsSlip = tglSlip.IsOn;
                    purchaseMaster.IsPF = tglPF.IsOn;
                    purchaseMaster.CommissionPercentage = Convert.ToDecimal(txtBuyerCommisionPer.Text);
                    purchaseMaster.CommissionAmount = float.Parse(txtCommisionAmount.Text);
                    if (Image1.Image != null)
                        purchaseMaster.Image1 = ImageToByteArray(Image1.Image);
                    if (Image2.Image != null)
                        purchaseMaster.Image2 = ImageToByteArray(Image2.Image);
                    if (Image3.Image != null)
                        purchaseMaster.Image3 = ImageToByteArray(Image3.Image);
                    purchaseMaster.AllowSlipPrint = tglSlip.IsOn ? true : false;
                    purchaseMaster.IsTransfer = false;
                    purchaseMaster.TransferParentId = null;
                    purchaseMaster.IsDelete = false;
                    purchaseMaster.Remarks = txtRemark.Text;
                    purchaseMaster.CreatedDate = DateTime.Now;
                    purchaseMaster.CreatedBy = Common.LoginUserID;
                    purchaseMaster.UpdatedDate = DateTime.Now;
                    purchaseMaster.UpdatedBy = Common.LoginUserID;
                    purchaseMaster.PurchaseDetails = purchaseDetailsList;

                    var SlipTransferEntity = await _slipTransferEntryRepository.AddSlipTransferEntryAsync(_slipTransferEntries);

                    if (SlipTransferEntity.Count > 0)
                    {
                        purchaseMaster.TransferParentId = SlipTransferEntity[0].SrNo.ToString();
                    }

                    PurchaseMasterRepository purchaseMasterRepository = new PurchaseMasterRepository();
                    var Result = await purchaseMasterRepository.AddPurchaseAsync(purchaseMaster);

                    if (Result != null)
                    {
                        try
                        {
                            foreach (var item in _slipTransferEntries)
                            {
                                item.PurchaseSaleId = Result.Id;
                                //item.BranchId = Result.BranchId;
                                //item.FinancialYearId = Result.FinancialYearId;
                            }
                            _ = await _slipTransferEntryRepository.UpdateSlipTransferEntryAsync(SlipTransferEntity);
                        }
                        catch
                        {

                        }

                        MessageBox.Show(AppMessages.GetString(AppMessageID.SaveSuccessfully), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await Reset();
                    }
                }
                else
                {
                    List<PurchaseDetails> purchaseDetailsList = new List<PurchaseDetails>();
                    PurchaseDetails purchaseDetails = new PurchaseDetails();
                    for (int i = 0; i < grvPurchaseDetails.RowCount; i++)
                    {
                        purchaseDetails = new PurchaseDetails();
                        if (string.IsNullOrWhiteSpace(grvPurchaseDetails.GetRowCellValue(i, colPurchaseDetailId).ToString()))
                            purchaseDetails.Id = Guid.NewGuid().ToString();
                        else
                            purchaseDetails.Id = grvPurchaseDetails.GetRowCellValue(i, colPurchaseDetailId).ToString();
                        purchaseDetails.PurchaseId = _editedPurchaseMaster.Id;
                        purchaseDetails.KapanId = grvPurchaseDetails.GetRowCellValue(i, colKapan).ToString();
                        purchaseDetails.ShapeId = grvPurchaseDetails.GetRowCellValue(i, colShape).ToString();
                        purchaseDetails.SizeId = grvPurchaseDetails.GetRowCellValue(i, colSize).ToString();
                        purchaseDetails.PurityId = grvPurchaseDetails.GetRowCellValue(i, colPurity).ToString();

                        purchaseDetails.Weight = Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(i, colCarat).ToString());
                        purchaseDetails.TIPWeight = Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(i, colTipWeight).ToString());
                        purchaseDetails.CVDWeight = Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(i, colCVDWeight).ToString());
                        purchaseDetails.RejectedPercentage = Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(i, colRejPer).ToString());
                        purchaseDetails.RejectedWeight = Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(i, colRejCts).ToString());
                        purchaseDetails.LessWeight = Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(i, colLessCts).ToString());
                        purchaseDetails.LessDiscountPercentage = Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(i, colDisPer).ToString());
                        purchaseDetails.LessWeightDiscount = Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(i, colDisAmount).ToString());
                        purchaseDetails.NetWeight = Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(i, colNetCts).ToString());
                        purchaseDetails.BuyingRate = float.Parse(grvPurchaseDetails.GetRowCellValue(i, colRate).ToString());
                        purchaseDetails.CVDCharge = float.Parse(grvPurchaseDetails.GetRowCellValue(i, colCVDCharge).ToString());
                        purchaseDetails.CVDAmount = float.Parse(grvPurchaseDetails.GetRowCellValue(i, colCVDAmount).ToString());
                        purchaseDetails.Amount = float.Parse(grvPurchaseDetails.GetRowCellValue(i, colAmount).ToString());
                        purchaseDetails.CurrencyRate = float.Parse(grvPurchaseDetails.GetRowCellValue(i, colCurrRate).ToString());
                        purchaseDetails.CurrencyAmount = float.Parse(grvPurchaseDetails.GetRowCellValue(i, colCurrAmount).ToString());
                        purchaseDetails.IsTransfer = false;
                        purchaseDetails.TransferParentId = null;
                        purchaseDetails.CreatedDate = DateTime.Now;
                        purchaseDetails.CreatedBy = Common.LoginUserID;
                        purchaseDetails.UpdatedDate = DateTime.Now;
                        purchaseDetails.UpdatedBy = Common.LoginUserID;

                        purchaseDetailsList.Insert(i, purchaseDetails);
                    }

                    PurchaseMaster purchaseMaster = new PurchaseMaster();
                    purchaseMaster.Id = _editedPurchaseMaster.Id;
                    purchaseMaster.CompanyId = lueCompany.GetColumnValue("Id").ToString();
                    purchaseMaster.BranchId = lueBranch.GetColumnValue("Id").ToString();
                    purchaseMaster.PartyId = lueParty.GetColumnValue("Id").ToString();
                    purchaseMaster.ByuerId = lueBuyer.GetColumnValue("Id").ToString();
                    purchaseMaster.CurrencyId = lueCurrencyType.GetColumnValue("Id").ToString();
                    //purchaseMaster.FinancialYearId = Common.LoginFinancialYear;
                    purchaseMaster.BrokerageId = lueBroker.GetColumnValue("Id").ToString();
                    purchaseMaster.CurrencyRate = Convert.ToDecimal(txtCurrencyType.Text);
                    purchaseMaster.PurchaseBillNo = Convert.ToInt32(txtSerialNo.Text);
                    purchaseMaster.SlipNo = Convert.ToInt32(txtSlipNo.Text);
                    purchaseMaster.TransactionType = Convert.ToInt32(luePaymentMode.GetColumnValue("PTypeID"));
                    purchaseMaster.Date = Convert.ToDateTime(dtDate.Text).ToString("yyyyMMdd");
                    purchaseMaster.Time = Convert.ToDateTime(dtTime.Text).ToString("hh:mm:ss ttt");
                    purchaseMaster.DayName = Convert.ToDateTime(dtDate.EditValue).DayOfWeek.ToString();
                    //purchaseMaster.PartyLastBalanceWhilePurchase = float.Parse(txtPartyBalance.Text);
                    purchaseMaster.BrokerPercentage = Convert.ToDecimal(txtBrokerPer.Text);
                    purchaseMaster.BrokerAmount = float.Parse(txtBrokerageAmount.Text);
                    purchaseMaster.RoundUpAmount = float.Parse(txtRoundAmount.Text);
                    purchaseMaster.Total = float.Parse(txtAmount.Text);
                    purchaseMaster.GrossTotal = float.Parse(txtNetAmount.Text);
                    purchaseMaster.DueDays = Convert.ToInt32(txtDays.Text);
                    purchaseMaster.DueDate = Convert.ToDateTime(dtDate.Text).AddDays(Convert.ToInt32(txtDays.Text));
                    purchaseMaster.PaymentDays = Convert.ToInt32(txtPaymentDays.Text);
                    purchaseMaster.PaymentDueDate = Convert.ToDateTime(dtPayDate.Text);
                    purchaseMaster.IsSlip = tglSlip.IsOn;
                    purchaseMaster.IsPF = tglPF.IsOn;
                    purchaseMaster.CommissionPercentage = Convert.ToDecimal(txtBuyerCommisionPer.Text);
                    purchaseMaster.CommissionAmount = float.Parse(txtCommisionAmount.Text);
                    if (Image1.Image != null)
                        purchaseMaster.Image1 = ImageToByteArray(Image1.Image);
                    if (Image2.Image != null)
                        purchaseMaster.Image2 = ImageToByteArray(Image2.Image);
                    if (Image3.Image != null)
                        purchaseMaster.Image3 = ImageToByteArray(Image3.Image);
                    purchaseMaster.AllowSlipPrint = tglSlip.IsOn ? true : false;
                    purchaseMaster.IsTransfer = false;
                    purchaseMaster.TransferParentId = null;
                    purchaseMaster.IsDelete = false;
                    purchaseMaster.Remarks = txtRemark.Text;
                    //purchaseMaster.CreatedDate = DateTime.Now;
                    //purchaseMaster.CreatedBy = Common.LoginUserID;
                    purchaseMaster.UpdatedDate = DateTime.Now;
                    purchaseMaster.UpdatedBy = Common.LoginUserID;
                    purchaseMaster.PurchaseDetails = purchaseDetailsList;
                    purchaseMaster.ApprovalType = 0;
                    purchaseMaster.Message = "";

                    if (_slipTransferEntries.Count > 0)
                    {
                        purchaseMaster.TransferParentId = _slipTransferEntries[0].SrNo.ToString();
                    }

                    PurchaseMasterRepository purchaseMasterRepository = new PurchaseMasterRepository();
                    var Result = await purchaseMasterRepository.UpdatePurchaseAsync(purchaseMaster);

                    if (Result != null)
                    {
                        try
                        {
                            foreach (var item in _slipTransferEntries)
                            {
                                item.PurchaseSaleId = Result.Id;
                                //item.BranchId = Result.BranchId;
                                //item.FinancialYearId = Result.FinancialYearId;
                            }
                            _ = await _slipTransferEntryRepository.UpdateSlipTransferEntryAsync(_slipTransferEntries);
                        }
                        catch
                        {

                        }

                        this.DialogResult = DialogResult.OK;
                        //MessageBox.Show(this, AppMessages.GetString(AppMessageID.SaveSuccessfully), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
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
            else if (lueBuyer.EditValue == null)
            {
                MessageBox.Show("Please select buyer name", "Purchase Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lueBuyer.Focus();
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

        private async Task Reset()
        {
            grdPurchaseDetails.DataSource = null;
            grdSlipParticularsDetails.DataSource = null;
            _slipTransferEntries = new List<SlipTransferEntry>();
            lueBuyer.EditValue = "";
            lueParty.EditValue = "";
            lueBroker.EditValue = "";
            await FillCombos();
            //FillBranches();
            await FillCurrency();
            txtRemark.Text = "";
            txtDays.Text = "";
            txtPaymentDays.Text = "";
            dtPayDate.EditValue = DateTime.Today;
            Image1.Image = null;
            Image2.Image = null;
            Image3.Image = null;
            txtBuyerCommisionPer.Text = "0";
            txtPartyBalance.Text = "0";
            txtBrokerPer.Text = "0";
            txtBrokerageAmount.Text = "0";
            txtCommisionAmount.Text = "0";
            txtAmount.Text = "0";
            txtRoundAmount.Text = "0";
            txtNetAmount.Text = "0";
            txtCurrencyAmount.Text = "0";
            tglSlip.IsOn = Common.PrintPurchaseSlip;
            tglPF.IsOn = Common.PrintPurchasePF;
            btnSave.Text = AppMessages.GetString(AppMessageID.Save);
            grdPurchaseDetails.Enabled = true;
            _editedPurchaseMaster = null;
            pnlStatus.Appearance.BackColor = Color.FromArgb(128, 128, 128);
            await GetPurchaseNo();
            txtSlipNo.Select();
            txtSlipNo.Focus();
        }

        private async void lueBroker_EditValueChanged(object sender, EventArgs e)
        {
            if (lueBroker.EditValue == null || lueBroker.EditValue == "")
                return;

            var selectedBoker = (PartyMaster)lueBroker.GetSelectedDataRow();
            var brokerageDetail  = await _brokerageMasterRepository.GetBrokerageAsync(selectedBoker.BrokerageId);
            txtBrokerPer.Text = brokerageDetail != null ? brokerageDetail.Percentage.ToString() : "0";
        }

        private async void lueBuyer_EditValueChanged(object sender, EventArgs e)
        {
            if (lueBuyer.EditValue == null || lueBuyer.EditValue == "")
                return;

            var selectedBuyer = (PartyMaster)lueBuyer.GetSelectedDataRow();
            var brokerageDetail = await _brokerageMasterRepository.GetBrokerageAsync(selectedBuyer.BrokerageId);
            txtBuyerCommisionPer.Text =brokerageDetail != null ?  brokerageDetail.Percentage.ToString() : "0";
        }

        private void lueParty_EditValueChanged(object sender, EventArgs e)
        {
            if (lueParty.EditValue == null || lueParty.EditValue == "")
                return;

            var selectedParty = (PartyMaster)lueParty.GetSelectedDataRow();
            txtPartyBalance.Text = selectedParty.OpeningBalance.ToString();
        }

        private async void lueBranch_EditValueChanged(object sender, EventArgs e)
        {
            await GetPurchaseNo(false);

            if (grvPurchaseDetails.RowCount != 0)
            {
                for (int i = 0; i < grvPurchaseDetails.RowCount; i++)
                {
                    FinalCalculation(i, true);
                }
            }
        }

        private async void lueCompany_EditValueChanged(object sender, EventArgs e)
        {
            this.Text = "PURCHASE - " + lueCompany.Text + " - [" + Common.LoginFinancialYearName + "]";

            await LoadBranch(lueCompany.EditValue.ToString());

            //await FillCombos();
        }

        private void grpGroup9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtRemark_EditValueChanged(object sender, EventArgs e)
        {

        }

        private async void btnReset_Click(object sender, EventArgs e)
        {
            await Reset();
        }

        private async void btnSlipAdd_Click(object sender, EventArgs e)
        {
            string SrNo = string.Empty;
            if (_slipTransferEntries.Count > 0)
            {
                SrNo = _slipTransferEntries[0].SrNo.ToString();
            }
            else
            {
                var SrNo1 = await _slipTransferEntryRepository.GetMaxSrNo(0, Common.LoginFinancialYear);
                SrNo = SrNo1.ToString();
            }

            Transaction.FrmSlipTransfer frmSlipTransfer = new FrmSlipTransfer(lueCompany.EditValue.ToString(), 0, txtSlipNo.Text, Convert.ToDecimal(colAmount.SummaryItem.SummaryValue), SrNo, _slipTransferEntries, lueBranch.EditValue.ToString(), Common.LoginFinancialYear);
            if(frmSlipTransfer.ShowDialog() == DialogResult.OK)
            {
                _slipTransferEntries = frmSlipTransfer.SlipTransferDetails;
                grdSlipParticularsDetails.DataSource = _slipTransferEntries;
            }
        }

        private void SetGridViewFocus() 
        {
            if (grvPurchaseDetails.VisibleColumns.Count > 0)
            {
                if (this.ActiveControl.GetType() != typeof(DevExpress.XtraGrid.GridControl))
                {
                    grvPurchaseDetails.Focus();
                    SendKeys.Send("{TAB}");
                    grvPurchaseDetails.FocusedColumn = colShape;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dtTime.EditValue = DateTime.Now;
        }
    }
}