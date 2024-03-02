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
using System.Globalization;
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
        SlipTransferEntryRepository _slipTransferEntryRepository;
        private readonly BrokerageMasterRepository _brokerageMasterRepository;
        SalesItemObj _salesItemObj;
        decimal ItemRunningWeight = 0;
        decimal ItemFinalAmount = 0;
        private string _selectedSalesId;
        private SalesMaster _editedSalesMaster;
        private SalesDetails _editedSalesDetails;
        private bool isLoading = false;
        private List<SlipTransferEntry> _slipTransferEntries;

        public FrmSalesEntry()
        {
            InitializeComponent();
            _salesMasterRepository = new SalesMasterRepository();
            _partyMasterRepository = new PartyMasterRepository();
            _slipTransferEntryRepository = new SlipTransferEntryRepository();
            _brokerageMasterRepository = new BrokerageMasterRepository();
            _salesItemObj = new SalesItemObj();

            this.Text = "SALES - " + Common.LoginCompanyName + " - [" + Common.LoginFinancialYearName + "]";
        }

        public FrmSalesEntry(string SelectedSalesId)
        {
            InitializeComponent();
            _salesMasterRepository = new SalesMasterRepository();
            _partyMasterRepository = new PartyMasterRepository();
            _slipTransferEntryRepository = new SlipTransferEntryRepository();
            _brokerageMasterRepository = new BrokerageMasterRepository();
            this.Text = "SALES - " + Common.LoginCompanyName + " - [" + Common.LoginFinancialYearName + "]";
            _selectedSalesId = SelectedSalesId;
        }

        private async void FrmSaleEntry_Load(object sender, EventArgs e)
        {
            string lastselectedDate = RegistryHelper.GetSettings(RegistryHelper.MainSection, RegistryHelper.SalesDateSelection, "");

            if (string.IsNullOrEmpty(lastselectedDate))
                dtDate.EditValue = DateTime.Now;
            else
            {
                try
                {
                    dtDate.EditValue = Convert.ToDateTime(lastselectedDate);
                }
                catch (Exception)
                {
                    dtDate.EditValue = DateTime.Now;
                }
            }

            isLoading = true;
            lblFormTitle.Text = Common.FormTitle;
            SetSelectionBackColor();
            tglSlip.IsOn = Common.PrintPurchaseSlip;
            tglPF.IsOn = Common.PrintPurchasePF;
            dtPayDate.Enabled = Common.AllowToSelectPurchaseDueDate;
            _slipTransferEntries = new List<SlipTransferEntry>();
            SetThemeColors(Color.FromArgb(215, 246, 214));

            FillCombos();

            await LoadCompany();

            await FillCurrency();

            if (string.IsNullOrEmpty(_selectedSalesId) == false)
            {
                this.Cursor = Cursors.WaitCursor;
                _editedSalesMaster = await _salesMasterRepository.GetSalesAsync(_selectedSalesId);
                //_EditedBrokerageMasterSet = _brokerageMaster.Where(s => s.Id == _selectedBrokerageId).FirstOrDefault();
                if (_editedSalesMaster != null)
                {
                    List<SalesDetails> EditedSalesDetails=new List<SalesDetails>();
                    SalesMasterRepository salesMasterRepository = new SalesMasterRepository();
                    try
                    {
                        this.lueCompany.EditValueChanged -= new System.EventHandler(this.lueCompany_EditValueChanged);
                        this.lueBranch.EditValueChanged -= new System.EventHandler(this.lueBranch_EditValueChanged);
                        this.lueSaler.EditValueChanged -= new System.EventHandler(this.lueSaler_EditValueChanged);
                        this.lueParty.EditValueChanged -= new System.EventHandler(this.lueParty_EditValueChanged);
                        this.lueBroker.EditValueChanged -= new System.EventHandler(this.lueBroker_EditValueChanged);

                        btnSave.Text = AppMessages.GetString(AppMessageID.Update);
                        //grdPurchaseDetails.Enabled = false;

                        if(_editedSalesMaster.ApprovalType == 1)
                            pnlStatus.Appearance.BackColor = Color.FromArgb(154, 205, 50);
                        else if (_editedSalesMaster.ApprovalType == 2)
                            pnlStatus.Appearance.BackColor = Color.FromArgb(255, 0, 0);
                        else
                            pnlStatus.Appearance.BackColor = Color.FromArgb(128, 128, 128);

                        lueCompany.EditValue = _editedSalesMaster.CompanyId;
                        lueBranch.EditValue = _editedSalesMaster.BranchId;
                        lueParty.EditValue = _editedSalesMaster.PartyId;
                        lueSaler.EditValue = _editedSalesMaster.SalerId;
                        lueCurrencyType.EditValue = _editedSalesMaster.CurrencyId;
                        //purchaseMaster.FinancialYearId = Common.LoginFinancialYear;
                        lueBroker.EditValue = _editedSalesMaster.BrokerageId;
                        txtCurrencyType.Text = _editedSalesMaster.CurrencyRate.ToString();
                        txtSerialNo.Text = _editedSalesMaster.SaleBillNo.ToString();
                        txtSlipNo.Text = _editedSalesMaster.SlipNo.ToString();
                        luePaymentMode.EditValue = _editedSalesMaster.TransactionType;
                        dtDate.EditValue = DateTime.ParseExact(_editedSalesMaster.Date, "yyyyMMdd", CultureInfo.InvariantCulture);
                        dtTime.EditValue = DateTime.ParseExact(_editedSalesMaster.Time, "hh:mm:ss ttt", CultureInfo.InvariantCulture);
                        //purchaseMaster.DayName = Convert.ToDateTime(dtDate.EditValue).DayOfWeek.ToString();
                        txtPartyBalance.Text = _editedSalesMaster.PartyLastBalanceWhileSale.ToString();
                        txtBrokerPercentage.Text = _editedSalesMaster.BrokerPercentage.ToString();
                        txtBrokerageAmount.Text = _editedSalesMaster.BrokerAmount.ToString();
                        txtRoundAmount.Text = _editedSalesMaster.RoundUpAmount.ToString();
                        txtAmount.Text = _editedSalesMaster.Total.ToString();
                        txtNetAmount.Text = _editedSalesMaster.GrossTotal.ToString();
                        txtDays.Text = _editedSalesMaster.DueDays.ToString();
                        //purchaseMaster.DueDate = Convert.ToDateTime(dtDate.Text).AddDays(Convert.ToInt32(txtDays.Text));
                        txtPaymentDays.Text = _editedSalesMaster.PaymentDays.ToString();
                        //purchaseMaster.PaymentDueDate = Convert.ToDateTime(dtPayDate.Text);
                        tglSlip.IsOn = _editedSalesMaster.IsSlip;
                        tglPF.IsOn = _editedSalesMaster.IsPF;
                        txtSalerCommisionPercentage.Text = _editedSalesMaster.CommissionPercentage.ToString();
                        txtCommisionAmount.Text = _editedSalesMaster.CommissionAmount.ToString();
                        //if (Image1.Image != null)
                        //    purchaseMaster.Image1 = ImageToByteArray(Image1.Image);
                        //if (Image2.Image != null)
                        //    purchaseMaster.Image2 = ImageToByteArray(Image2.Image);
                        //if (Image3.Image != null)
                        //    purchaseMaster.Image3 = ImageToByteArray(Image3.Image);
                        //purchaseMaster.AllowSlipPrint = tglSlip.IsOn ? true : false;

                        txtRemark.Text = _editedSalesMaster.Remarks;

                        var tempEditedSalesDetails = new SalesDetails[_editedSalesMaster.SalesDetails.Count];
                        _editedSalesMaster.SalesDetails.CopyTo(tempEditedSalesDetails); //await _purchaseMasterRepository.GetPurchaseDetailAsync(_selectedPurchaseId);
                        if (tempEditedSalesDetails != null)
                        {
                            ///await salesMasterRepository.DeleteSalesDetailSummaryRangeAsync(_editedSalesMaster.SalesDetails.SalesDetailsSummary);
                            await salesMasterRepository.DeleteSalesDetailRangeAsync(_editedSalesMaster.SalesDetails);
                        }

                        EditedSalesDetails = tempEditedSalesDetails.ToList();

                        for (int i = 0; i < EditedSalesDetails.Count; i++)
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

                            grvPurchaseDetails.SetFocusedRowCellValue(colSalesDetailId, EditedSalesDetails[i].Id);
                            grvPurchaseDetails.SetFocusedRowCellValue(colCategory, EditedSalesDetails[i].Category);
                            grvPurchaseDetails.SetFocusedRowCellValue(colKapan, EditedSalesDetails[i].KapanId);
                            try
                            {
                                var Shape = ((List<SalesItemDetails>)repoShape.DataSource).Where(x => x.ShapeId == EditedSalesDetails[i].ShapeId).FirstOrDefault();
                                if (Shape != null)
                                {
                                    grvPurchaseDetails.SetFocusedRowCellValue(colShape, Shape.Id);
                                }
                            }
                            catch
                            {
                                var Shape = ((List<ShapeMaster>)repoShape.DataSource).Where(x => x.Id == EditedSalesDetails[i].ShapeId).FirstOrDefault();
                                if (Shape != null)
                                {
                                    grvPurchaseDetails.SetFocusedRowCellValue(colShape, Shape.Id);
                                }
                            }

                            grvPurchaseDetails.SetFocusedRowCellValue(colKapan, EditedSalesDetails[i].KapanId);

                            grvPurchaseDetails.SetFocusedRowCellValue(colShapeId, EditedSalesDetails[i].ShapeId);
                            grvPurchaseDetails.SetFocusedRowCellValue(colSize, EditedSalesDetails[i].SizeId);
                            grvPurchaseDetails.SetFocusedRowCellValue(colPurity, EditedSalesDetails[i].PurityId);

                            if (EditedSalesDetails[i].CharniSizeId != null && EditedSalesDetails[i].CharniSizeId != Common.DefaultGuid)
                                grvPurchaseDetails.SetFocusedRowCellValue(colCharniSize, EditedSalesDetails[i].CharniSizeId);
                            if (EditedSalesDetails[i].GalaSizeId != null && EditedSalesDetails[i].GalaSizeId != Common.DefaultGuid)
                                grvPurchaseDetails.SetFocusedRowCellValue(colGalaSize, EditedSalesDetails[i].GalaSizeId);
                            if (EditedSalesDetails[i].NumberSizeId != null && EditedSalesDetails[i].NumberSizeId != Common.DefaultGuid)
                                grvPurchaseDetails.SetFocusedRowCellValue(colNumberSize, EditedSalesDetails[i].NumberSizeId);

                            grvPurchaseDetails.SetFocusedRowCellValue(colCarat, EditedSalesDetails[i].Weight);

                            grvPurchaseDetails.SetFocusedRowCellValue(colTipWeight, EditedSalesDetails[i].TIPWeight);
                            grvPurchaseDetails.SetFocusedRowCellValue(colCVDWeight, EditedSalesDetails[i].CVDWeight);
                            grvPurchaseDetails.SetFocusedRowCellValue(colRejPer, EditedSalesDetails[i].RejectedPercentage);
                            grvPurchaseDetails.SetFocusedRowCellValue(colRejCts, EditedSalesDetails[i].RejectedWeight);
                            grvPurchaseDetails.SetFocusedRowCellValue(colLessCts, EditedSalesDetails[i].LessWeight);
                            grvPurchaseDetails.SetFocusedRowCellValue(colDisPer, EditedSalesDetails[i].LessDiscountPercentage);
                            grvPurchaseDetails.SetFocusedRowCellValue(colDisAmount, EditedSalesDetails[i].LessWeightDiscount);
                            grvPurchaseDetails.SetFocusedRowCellValue(colNetCts, EditedSalesDetails[i].NetWeight);
                            grvPurchaseDetails.SetFocusedRowCellValue(colRate, EditedSalesDetails[i].SaleRate);
                            grvPurchaseDetails.SetFocusedRowCellValue(colCVDCharge, EditedSalesDetails[i].CVDCharge);
                            grvPurchaseDetails.SetFocusedRowCellValue(colCVDAmount, EditedSalesDetails[i].CVDAmount);
                            grvPurchaseDetails.SetFocusedRowCellValue(colAmount, EditedSalesDetails[i].Amount);
                            grvPurchaseDetails.SetFocusedRowCellValue(colCurrRate, EditedSalesDetails[i].CurrencyRate);
                            grvPurchaseDetails.SetFocusedRowCellValue(colCurrAmount, EditedSalesDetails[i].CurrencyAmount);
                            grvPurchaseDetails.UpdateCurrentRow();
                        }

                        if (!string.IsNullOrEmpty(_editedSalesMaster.TransferParentId))
                        {
                            _slipTransferEntries = await LoadSlipTransferDetails(Convert.ToInt32(_editedSalesMaster.TransferParentId));
                            grdSlipParticularsDetails.DataSource = _slipTransferEntries;
                        }

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
                        if (EditedSalesDetails.Count > 0)
                        {
                            await salesMasterRepository.AddSalesDetailRangeAsync(EditedSalesDetails);
                        }
                        this.lueCompany.EditValueChanged += new System.EventHandler(this.lueCompany_EditValueChanged);
                        this.lueBranch.EditValueChanged += new System.EventHandler(this.lueBranch_EditValueChanged);
                        this.lueSaler.EditValueChanged += new System.EventHandler(this.lueSaler_EditValueChanged);
                        this.lueParty.EditValueChanged += new System.EventHandler(this.lueParty_EditValueChanged);
                        this.lueBroker.EditValueChanged += new System.EventHandler(this.lueBroker_EditValueChanged);
                        this.Cursor = Cursors.Default;
                    }
                }
                else
                {
                    this.Cursor = Cursors.Default;
                }
            }
            timer1.Start();
            isLoading = false;
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
            //dtDate.EditValue = DateTime.Now;
            dtTime.EditValue = DateTime.Now;
            dtPayDate.EditValue = DateTime.Now;

            //GetPurchaseNo(); //Serial No/Slip No

            await LoadPurchaseItemDetails();

            //Payment Mode
            luePaymentMode.Properties.DataSource = Common.GetPaymentType;
            luePaymentMode.Properties.DisplayMember = "PTypeName";
            luePaymentMode.Properties.ValueMember = "PTypeID";
            luePaymentMode.EditValue = 1;

            await GetSalerList ();

            //Commision
            //partyMaster = await partyMasterRepository.GetAllPartyAsync();
            //lueCompany.Properties.DataSource = partyMaster;
            //lueCompany.Properties.DisplayMember = "Name";
            //lueCompany.Properties.ValueMember = "Id";

            await GetPartyList();

            await GetBrokerList();
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
            var BrokerDetailList = await _partyMasterRepository.GetAllPartyAsync(companyId, PartyTypeMaster.Employee, new int[] { PartyTypeMaster.Broker });
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
            var PartyDetailList = await _partyMasterRepository.GetAllPartyAsync(companyId, PartyTypeMaster.PartySale);
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
            var SalerDetailList = await _partyMasterRepository.GetAllPartyAsync(companyId, PartyTypeMaster.Employee, new int[] { PartyTypeMaster.Seller });
            lueSaler.Properties.DataSource = SalerDetailList;
            lueSaler.Properties.DisplayMember = "Name";
            lueSaler.Properties.ValueMember = "Id";
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
            var slipTranferDetails = await _slipTransferEntryRepository.GetSlipTransferEntriesAsync(SlipTransferId, 1, Common.LoginFinancialYear);
            return slipTranferDetails;
        }

        private async Task LoadBranch(string companyId)
        {
            BranchMasterRepository branchMasterRepository = new BranchMasterRepository();
            var branches = await branchMasterRepository.GetAllBranchAsync(companyId); //_branchMasterRepository.GetAllBranchAsync();
            lueBranch.Properties.DataSource = branches;
            lueBranch.Properties.DisplayMember = "Name";
            lueBranch.Properties.ValueMember = "Id";
            lueBranch.EditValue = Common.LoginBranch;

            await GetSalesNo(); //Serial No/Slip No
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

        #endregion

        private async Task LoadPurchaseItemDetails()
        {
            grdPurchaseDetails.DataSource = GetDTColumnsforPurchaseDetails();

            //Category
            await GetCategoryDetail(false);

            //Shape
            await GetShapeDetail(false);

            //Size
            await GetSizeDetail(false);

            //Purity
            await GetPurityDetail(false);

            //Kapan
            await  GetKapanDetail(false);
        }

        private async Task GetCategoryDetail(bool IsNew)
        {
            var Category = CategoryMaster.GetAllCategory();

            if (Category != null)
            {
                repoCategory.DataSource = Category;
                repoCategory.DisplayMember = "Name";
                repoCategory.ValueMember = "Id";
            }
        }

        private async Task GetShapeDetail(bool IsNew)
        {
            ShapeMasterRepository shapeMasterRepository = new ShapeMasterRepository();
            var shapeMaster = await shapeMasterRepository.GetAllShapeAsync();
            repoShape.DataSource = shapeMaster;
            repoShape.DisplayMember = "Name";
            repoShape.ValueMember = "Id";
        }

        private async Task GetSizeDetail(bool IsNew)
        {
            SizeMasterRepository sizeMasterRepository = new SizeMasterRepository();
            var sizeMaster = await sizeMasterRepository.GetAllSizeAsync();
            repoSize.DataSource = sizeMaster;
            repoSize.DisplayMember = "Name";
            repoSize.ValueMember = "Id";
        }

        private async Task GetPurityDetail(bool IsNew)
        {
            PurityMasterRepository purityMasterRepository = new PurityMasterRepository();
            var purityMaster = await purityMasterRepository.GetAllPurityAsync();
            repoPurity.DataSource = purityMaster;
            repoPurity.DisplayMember = "Name";
            repoPurity.ValueMember = "Id";
        }

        private async Task GetKapanDetail(bool IsNew)
        {
            KapanMasterRepository kapanMasterRepository = new KapanMasterRepository();
            var kapanMaster = await kapanMasterRepository.GetAllKapanAsync(Common.LoginCompany);
            repoKapan.DataSource = kapanMaster;
            repoKapan.DisplayMember = "Name";
            repoKapan.ValueMember = "Id";
        }

        public async Task GetSalesNo(bool updateSlipNo = true)
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
            dt.Columns.Add("SalesDetailId");
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
                        lueSaler.BackColor = default;
                        lueSaler.Tag = lueSaler.BackColor;
                        lueSaler.Focus();
                    }
                }
                else if (ControlName == lueParty.Name)
                {
                    Master.FrmPartyMaster frmPartyMaster = new Master.FrmPartyMaster();
                    frmPartyMaster.IsSilentEntry = true;
                    frmPartyMaster.LedgerType = PartyTypeMaster.PartySale;
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

        private async void lueBranch_EditValueChanged(object sender, EventArgs e)
        {
            await GetSalesNo(false);
            await ClearGridAsBranchChanged();
        }

        private async Task ClearGridAsBranchChanged()
        {
            _salesItemObj = new SalesItemObj();
            for (int i = 0; i < grvPurchaseDetails.RowCount;)
                grvPurchaseDetails.DeleteRow(i);

            txtAmount.Text = "0";
            txtRoundAmount.Text = "0";
            txtNetAmount.Text = "0";
            txtCurrencyAmount.Text = "0";
        }

        #endregion

        private async void lueCompany_EditValueChanged(object sender, EventArgs e)
        {
            this.Text = "SALES - " + lueCompany.Text + " - [" + Common.LoginFinancialYearName + "]";

            await LoadBranch(lueCompany.EditValue.ToString());

            //await FillCombos();
        }

        private async void grvPurchaseDetails_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == colCategory)
                {
                    this.grvPurchaseDetails.CellValueChanged -= new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvPurchaseDetails_CellValueChanged);
                    if (grvPurchaseDetails.GetRowCellValue(e.RowHandle, colCategory).ToString() == CategoryMaster.Kapan.ToString())
                    {
                        repoShape.Columns["CharniSize"].Visible = false;
                        repoShape.Columns["GalaSize"].Visible = false;
                        repoShape.Columns["NumberSize"].Visible = false;
                        repoShape.Columns["Kapan"].Visible = true;
                        repoShape.Columns["Size"].Visible = true;
                        repoShape.Columns["Purity"].Visible = true;

                        colSize.Visible = true;
                        colKapan.Visible = true;
                        colNumberSize.Visible = false;
                        colCharniSize.Visible = false;
                        colGalaSize.Visible = false;

                        //if (_salesItemObj.KapanItemList == null)
                        //    _salesItemObj.KapanItemList = await _salesMasterRepository.GetSalesItemDetails(CategoryMaster.Kapan, lueCompany.EditValue.ToString(), lueBranch.EditValue.ToString(), Common.LoginFinancialYear);

                        //repoShape.DataSource = _salesItemObj.KapanItemList;//.Select(x => new { x.ShapeId, x.Shape }).Distinct().ToList();
                        //repoShape.DisplayMember = "Shape";
                        //repoShape.ValueMember = "Id";

                        AccountToAssortMasterRepository accountToAssortMasterRepository = new AccountToAssortMasterRepository();
                        var ListKapanProcessSend = await accountToAssortMasterRepository.GetAssortmentSendToDetails(lueCompany.EditValue.ToString(), lueBranch.EditValue.ToString(), Common.LoginFinancialYear.ToString());
                        //var listKapanProcess = ListKapanProcessSend.Where(x => x.KapanId == grvTransferItemDetails.GetRowCellValue(e.RowHandle, colCategory).ToString()).ToList();

                        var listKapanProcess1 = ListKapanProcessSend.Select(g => new Repository.Entities.Models.AssortmentProcessSend()
                        {
                            Kapan = g.Kapan,
                            KapanId = g.KapanId,
                            Size = g.Size,
                            SizeId = g.SizeId,
                            Purity = g.Purity,
                            PurityId = g.PurityId,
                            Shape = g.Shape,
                            ShapeId = g.ShapeId,
                            AvailableWeight = g.AvailableWeight,
                            LessWeight = g.LessWeight,
                            NetWeight = g.NetWeight,
                            Weight = g.Weight,
                            Id = g.KapanId + g.SizeId + g.ShapeId + g.PurityId,
                            SlipNo = g.SlipNo
                        }).GroupBy(r => new
                        {
                            r.Kapan,
                            r.KapanId,
                            r.Purity,
                            r.PurityId,
                            r.Shape,
                            r.ShapeId,
                            r.Size,
                            r.SizeId
                        }).OrderBy(g => g.Key.Kapan).Select(g => new Repository.Entities.Models.AssortmentProcessSend()
                        {
                            Kapan = g.Key.Kapan,
                            KapanId = g.Key.KapanId,
                            Size = g.Key.Size,
                            SizeId = g.Key.SizeId,
                            Purity = g.Key.Purity,
                            PurityId = g.Key.PurityId,
                            Shape = g.Key.Shape,
                            ShapeId = g.Key.ShapeId,
                            Id = g.Key.KapanId + g.Key.ShapeId + g.Key.PurityId + g.Key.SizeId,
                            SlipNo = string.Join(",", g.Select(kvp => kvp.SlipNo)),
                            AvailableWeight = g.Sum(x => x.AvailableWeight),
                            NetWeight = g.Sum(x => x.NetWeight),
                            Weight = g.Sum(x => x.Weight),
                            LessWeight = g.Sum(x => x.LessWeight)
                        });

                        if (_salesItemObj.KapanItemList == null)
                            _salesItemObj.KapanItemList = listKapanProcess1.Where(x => x.AvailableWeight > 0).ToList();

                        listKapanProcess1 = listKapanProcess1.Where(x => x.AvailableWeight > 0);
                        repoShape.DataSource = listKapanProcess1.ToList();
                        repoShape.DisplayMember = "Shape";
                        repoShape.ValueMember = "Id";

                        repoShape.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                        repoShape.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;

                        repoSize.DataSource = ListKapanProcessSend.Select(x => new { x.SizeId, x.Size }).Distinct().ToList();
                        repoSize.DisplayMember = "Size";
                        repoSize.ValueMember = "SizeId";

                        repoPurity.DataSource = ListKapanProcessSend.Select(x => new { x.PurityId, x.Purity }).Distinct().ToList();
                        repoPurity.DisplayMember = "Purity";
                        repoPurity.ValueMember = "PurityId";

                        repoKapan.DataSource = ListKapanProcessSend.Select(x => new { x.KapanId, x.Kapan }).Distinct().ToList();
                        repoKapan.DisplayMember = "Kapan";
                        repoKapan.ValueMember = "KapanId";
                    }
                    else if (grvPurchaseDetails.GetRowCellValue(e.RowHandle, colCategory).ToString() == CategoryMaster.Charni.ToString())
                    {
                        repoShape.Columns["CharniSize"].Visible = true;
                        repoShape.Columns["GalaSize"].Visible = false;
                        repoShape.Columns["NumberSize"].Visible = false;
                        repoShape.Columns["Kapan"].Visible = true;
                        repoShape.Columns["Size"].Visible = true;
                        repoShape.Columns["Purity"].Visible = true;

                        colSize.Visible = false;
                        colKapan.Visible = false;
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
                        repoShape.Columns["Kapan"].Visible = false;
                        repoShape.Columns["Size"].Visible = false;
                        repoShape.Columns["Purity"].Visible = false;

                        colSize.Visible = false;
                        colKapan.Visible = false;
                        colNumberSize.Visible = true;
                        colCharniSize.Visible = true;
                        colGalaSize.Visible = false;

                        if (_salesItemObj.NumberItemList == null)
                            _salesItemObj.NumberItemList = await _salesMasterRepository.GetSalesItemDetails(CategoryMaster.Number, lueCompany.EditValue.ToString(), lueBranch.EditValue.ToString(), Common.LoginFinancialYear);

                        var listNumberProcess1 = _salesItemObj.NumberItemList.Select(g => new Repository.Entities.Model.SalesItemDetails()
                        {
                            Kapan = g.Kapan,
                            KapanId = g.KapanId,
                            Size = g.Size,
                            SizeId = g.SizeId,
                            Purity = g.Purity,
                            PurityId = g.PurityId,
                            Shape = g.Shape,
                            ShapeId = g.ShapeId,
                            CharniSizeId = g.CharniSizeId,
                            CharniSize = g.CharniSize,
                            GalaNumberId = g.GalaNumberId,
                            GalaSize = g.GalaSize,
                            NumberSizeId = g.NumberSizeId,
                            NumberSize = g.NumberSize,
                            AvailableWeight = g.AvailableWeight,
                            Id = g.KapanId + g.SizeId + g.ShapeId + g.PurityId,
                        }).GroupBy(r => new
                        {
                            r.Kapan,
                            r.KapanId,
                            r.Purity,
                            r.PurityId,
                            r.Shape,
                            r.ShapeId,
                            r.Size,
                            r.SizeId,
                            r.CharniSizeId,
                            r.CharniSize,
                            r.GalaNumberId,
                            r.GalaSize,
                            r.NumberSizeId,
                            r.NumberSize
                        }).OrderBy(g => g.Key.CharniSizeId).Select(g => new Repository.Entities.Model.SalesItemDetails()
                        {
                            Kapan = g.Key.Kapan,
                            KapanId = g.Key.KapanId,
                            Size = g.Key.Size,
                            SizeId = g.Key.SizeId,
                            Purity = g.Key.Purity,
                            PurityId = g.Key.PurityId,
                            Shape = g.Key.Shape,
                            ShapeId = g.Key.ShapeId,
                            CharniSizeId = g.Key.CharniSizeId,
                            CharniSize = g.Key.CharniSize,
                            GalaNumberId = g.Key.GalaNumberId,
                            GalaSize = g.Key.GalaSize,
                            NumberSizeId = g.Key.NumberSizeId,
                            NumberSize = g.Key.NumberSize,
                            Id = g.Key.KapanId + g.Key.ShapeId + g.Key.PurityId + g.Key.SizeId + g.Key.CharniSizeId + g.Key.GalaNumberId + g.Key.NumberSizeId,
                            AvailableWeight = g.Sum(x => x.AvailableWeight),
                        });

                        repoShape.DataSource = listNumberProcess1;//.Select(x => new { x.ShapeId, x.Shape }).Distinct().ToList();
                        repoShape.DisplayMember = "Shape";
                        repoShape.ValueMember = "Id";

                        repoShape.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                        repoShape.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;

                        repoSize.DataSource = listNumberProcess1.Select(x => new { x.SizeId, x.Size }).Distinct().ToList();
                        repoSize.DisplayMember = "Size";
                        repoSize.ValueMember = "SizeId";

                        repoPurity.DataSource = listNumberProcess1.Select(x => new { x.PurityId, x.Purity }).Distinct().ToList();
                        repoPurity.DisplayMember = "Purity";
                        repoPurity.ValueMember = "PurityId";

                        repoKapan.DataSource = listNumberProcess1.Select(x => new { x.KapanId, x.Kapan }).Distinct().ToList();
                        repoKapan.DisplayMember = "Kapan";
                        repoKapan.ValueMember = "KapanId";

                        repoCharniSize.DataSource = listNumberProcess1.Where(x => x.CharniSizeId != null).Select(x => new { x.CharniSizeId, x.CharniSize }).Distinct().ToList();
                        repoCharniSize.DisplayMember = "CharniSize";
                        repoCharniSize.ValueMember = "CharniSizeId";

                        repoNumberSize.DataSource = listNumberProcess1.Select(x => new { x.NumberSizeId, x.NumberSize }).Distinct().ToList();
                        repoNumberSize.DisplayMember = "NumberSize";
                        repoNumberSize.ValueMember = "NumberSizeId";
                    }
                    else if (grvPurchaseDetails.GetRowCellValue(e.RowHandle, colCategory).ToString() == CategoryMaster.Gala.ToString())
                    {
                        repoShape.Columns["CharniSize"].Visible = true;
                        repoShape.Columns["GalaSize"].Visible = true;
                        repoShape.Columns["NumberSize"].Visible = false;
                        repoShape.Columns["Kapan"].Visible = true;
                        repoShape.Columns["Size"].Visible = true;
                        repoShape.Columns["Purity"].Visible = true;

                        colSize.Visible = false;
                        colKapan.Visible = false;
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
                        repoShape.Columns["Kapan"].Visible = true;
                        repoShape.Columns["Size"].Visible = true;
                        repoShape.Columns["Purity"].Visible = true;

                        colSize.Visible = false;
                        colKapan.Visible = false;
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
                    this.grvPurchaseDetails.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvPurchaseDetails_CellValueChanged);
                }
                else if (e.Column == colCharniSize)
                {
                    string CharniSizeId = grvPurchaseDetails.GetRowCellValue(e.RowHandle, colCharniSize).ToString();
                    if (grvPurchaseDetails.GetRowCellValue(e.RowHandle, colCategory).ToString() == CategoryMaster.Number.ToString())
                    {
                        repoNumberSize.DataSource = _salesItemObj.NumberItemList.Where(x => x.CharniSizeId != null && x.CharniSizeId == CharniSizeId).Select(x => new { x.NumberSizeId, x.NumberSize }).Distinct().ToList();
                        repoNumberSize.DisplayMember = "NumberSize";
                        repoNumberSize.ValueMember = "NumberSizeId";

                        grvPurchaseDetails.SetRowCellValue(e.RowHandle, colNumberSize, null);
                    }
                    else if (grvPurchaseDetails.GetRowCellValue(e.RowHandle, colCategory).ToString() == CategoryMaster.Gala.ToString())
                    {
                        repoGalaSize.DataSource = _salesItemObj.GalaItemList.Where(x => x.CharniSizeId != null && x.CharniSizeId == CharniSizeId).Select(x => new { x.GalaNumberId, x.GalaSize }).Distinct().ToList();
                        repoGalaSize.DisplayMember = "GalaSize";
                        repoGalaSize.ValueMember = "GalaNumberId";

                        grvPurchaseDetails.SetRowCellValue(e.RowHandle, colGalaSize, null);
                    }
                }
                else if (e.Column == colSize)
                {
                    string SizeId = grvPurchaseDetails.GetRowCellValue(e.RowHandle, colSize).ToString();
                    if (grvPurchaseDetails.GetRowCellValue(e.RowHandle, colCategory).ToString() == CategoryMaster.Kapan.ToString())
                    {
                        repoKapan.DataSource = _salesItemObj.KapanItemList.Where(x => x.SizeId != null && x.SizeId == SizeId).Select(x => new { x.KapanId, x.Kapan }).Distinct().ToList();
                        repoKapan.DisplayMember = "Kapan";
                        repoKapan.ValueMember = "KapanId";

                        grvPurchaseDetails.SetRowCellValue(e.RowHandle, colKapan, null);
                    }
                }
                else if (e.Column == colCarat || e.Column == colCVDWeight)
                {
                    decimal TipWeight = Convert.ToDecimal(lueBranch.GetColumnValue("TipWeight"));
                    decimal CVDWeight = Convert.ToDecimal(lueBranch.GetColumnValue("CVDWeight"));
                    await GetLessWeightDetailBasedOnCity(lueBranch.GetColumnValue("LessWeightId").ToString(), Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(e.RowHandle, colCarat)), e.RowHandle, TipWeight, CVDWeight);
                }
                else if (e.Column == colShape)
                {
                    if (e.Value != Common.DefaultGuid)
                    {
                        if (grvPurchaseDetails.GetRowCellValue(e.RowHandle, colCategory).ToString() == CategoryMaster.Kapan.ToString())
                        {
                            grvPurchaseDetails.SetRowCellValue(e.RowHandle, colShapeId, ((Repository.Entities.Models.AssortmentProcessSend)repoShape.GetDataSourceRowByKeyValue(e.Value)).ShapeId);
                            grvPurchaseDetails.SetRowCellValue(e.RowHandle, colSize, ((Repository.Entities.Models.AssortmentProcessSend)repoShape.GetDataSourceRowByKeyValue(e.Value)).SizeId);
                            grvPurchaseDetails.SetRowCellValue(e.RowHandle, colPurity, ((Repository.Entities.Models.AssortmentProcessSend)repoShape.GetDataSourceRowByKeyValue(e.Value)).PurityId);
                            grvPurchaseDetails.SetRowCellValue(e.RowHandle, colKapan, ((Repository.Entities.Models.AssortmentProcessSend)repoShape.GetDataSourceRowByKeyValue(e.Value)).KapanId);
                        }
                        else
                        {
                            grvPurchaseDetails.SetRowCellValue(e.RowHandle, colShapeId, ((Repository.Entities.Model.SalesItemDetails)repoShape.GetDataSourceRowByKeyValue(e.Value)).ShapeId);
                            grvPurchaseDetails.SetRowCellValue(e.RowHandle, colSize, ((Repository.Entities.Model.SalesItemDetails)repoShape.GetDataSourceRowByKeyValue(e.Value)).SizeId);
                            grvPurchaseDetails.SetRowCellValue(e.RowHandle, colPurity, ((Repository.Entities.Model.SalesItemDetails)repoShape.GetDataSourceRowByKeyValue(e.Value)).PurityId);
                            grvPurchaseDetails.SetRowCellValue(e.RowHandle, colKapan, ((Repository.Entities.Model.SalesItemDetails)repoShape.GetDataSourceRowByKeyValue(e.Value)).KapanId);
                        }

                        if (grvPurchaseDetails.GetRowCellValue(e.RowHandle, colCategory).ToString() != CategoryMaster.Kapan.ToString()
                            && grvPurchaseDetails.GetRowCellValue(e.RowHandle, colCategory).ToString() != CategoryMaster.Boil.ToString())
                        {
                            grvPurchaseDetails.SetRowCellValue(e.RowHandle, colCharniSize, ((Repository.Entities.Model.SalesItemDetails)repoShape.GetDataSourceRowByKeyValue(e.Value)).CharniSizeId);
                        }
                        if (grvPurchaseDetails.GetRowCellValue(e.RowHandle, colCategory).ToString() != CategoryMaster.Kapan.ToString()
                            && grvPurchaseDetails.GetRowCellValue(e.RowHandle, colCategory).ToString() == CategoryMaster.Number.ToString())
                        {
                            grvPurchaseDetails.SetRowCellValue(e.RowHandle, colNumberSize, ((Repository.Entities.Model.SalesItemDetails)repoShape.GetDataSourceRowByKeyValue(e.Value)).NumberSizeId);
                            //grvPurchaseDetails.SetRowCellValue(e.RowHandle, colCharniSize, ((Repository.Entities.Model.SalesItemDetails)repoShape.GetDataSourceRowByKeyValue(e.Value)).CharniSizeId);

                            PriceMasterRepository priceMasterRepository = new PriceMasterRepository();
                            PriceMaster PriceRate = await priceMasterRepository.GetPricesAsync(lueCompany.EditValue.ToString(), PriceMasterCategory.Number.ToString(),
                                ((Repository.Entities.Model.SalesItemDetails)repoShape.GetDataSourceRowByKeyValue(e.Value)).CharniSizeId,
                                ((Repository.Entities.Model.SalesItemDetails)repoShape.GetDataSourceRowByKeyValue(e.Value)).NumberSizeId);

                            if (PriceRate != null)
                            {
                                grvPurchaseDetails.SetRowCellValue(e.RowHandle, colRate, PriceRate.Price);
                            }
                        }
                        else if (grvPurchaseDetails.GetRowCellValue(e.RowHandle, colCategory).ToString() != CategoryMaster.Kapan.ToString()
                            && grvPurchaseDetails.GetRowCellValue(e.RowHandle, colCategory).ToString() == CategoryMaster.Gala.ToString())
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
            catch (Exception Ex)
            {
                this.grvPurchaseDetails.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvPurchaseDetails_CellValueChanged);
            }
        }

        private void grvPurchaseDetails_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //GetTotal();
        }

        private void grvPurchaseDetails_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            //grvPurchaseDetails.SetRowCellValue(e.RowHandle, colShape, Common.DefaultShape);
            //grvPurchaseDetails.SetRowCellValue(e.RowHandle, colSize, Common.DefaultSize);
            //grvPurchaseDetails.SetRowCellValue(e.RowHandle, colPurity, Common.DefaultPurity);
            this.grvPurchaseDetails.CellValueChanged -= new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvPurchaseDetails_CellValueChanged);
            grvPurchaseDetails.SetRowCellValue(e.RowHandle, colCVDWeight, "0");
            grvPurchaseDetails.SetRowCellValue(e.RowHandle, colRejPer, "0");
            grvPurchaseDetails.SetRowCellValue(e.RowHandle, colRejCts, "0");
            grvPurchaseDetails.SetRowCellValue(e.RowHandle, colDisAmount, "0");
            grvPurchaseDetails.SetRowCellValue(e.RowHandle, colDisPer, "0");
            this.grvPurchaseDetails.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvPurchaseDetails_CellValueChanged);
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

        private async Task GetLessWeightDetailBasedOnCity(string GroupName, decimal Weight, int GridRowIndex, decimal TipWeight, decimal CVDWeight)
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
                {
                    CVDCts = Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(GridRowIndex, colCVDWeight));
                    if (CVDCts <= 0)
                    {
                        grvPurchaseDetails.SetRowCellValue(GridRowIndex, colCVDCharge, 0);
                        grvPurchaseDetails.SetRowCellValue(GridRowIndex, colCVDAmount, 0);
                    }
                }

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
                if (!isLoading)
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
                RegistryHelper.SaveSettings(RegistryHelper.MainSection, RegistryHelper.SalesDateSelection, dtDate.DateTime.ToString());

                this.Cursor = Cursors.WaitCursor;
                if (!CheckValidation())
                    return;

                if (btnSave.Text == AppMessages.GetString(AppMessageID.Save))
                {
                    string SalesId = Guid.NewGuid().ToString();

                    List<SalesDetails> salesDetailsList = new List<SalesDetails>();
                    List<SalesDetailsSummary> salesDetailsSummaryList = new List<SalesDetailsSummary>();
                    SalesDetails salesDetails = new SalesDetails();
                    for (int i = 0; i < grvPurchaseDetails.RowCount; i++)
                    {
                        DataView dtView = new DataView();
                        string SalesDetailsId = Guid.NewGuid().ToString();

                        #region "Sales Details Summary"
                        DataTable dt = new DataTable();
                        if (grvPurchaseDetails.GetRowCellValue(i, colCategory).ToString() == CategoryMaster.Number.ToString())
                        {
                            var listNumberProcess = await _salesMasterRepository.GetSalesItemDetails(CategoryMaster.Number, lueCompany.EditValue.ToString(), lueBranch.EditValue.ToString(), Common.LoginFinancialYear);
                            dt = Common.ToDataTable(listNumberProcess);
                        }
                        else if (grvPurchaseDetails.GetRowCellValue(i, colCategory).ToString() == CategoryMaster.Kapan.ToString())
                        {
                            //var listNumberProcess = await _salesMasterRepository.GetSalesItemDetails(CategoryMaster.Number, lueCompany.EditValue.ToString(), lueBranch.EditValue.ToString(), Common.LoginFinancialYear);
                            //dt = Common.ToDataTable(listNumberProcess);

                            AccountToAssortMasterRepository accountToAssortMasterRepository = new AccountToAssortMasterRepository();
                            var ListKapanProcessSend = await accountToAssortMasterRepository.GetAssortmentSendToDetails(lueCompany.EditValue.ToString(), lueBranch.EditValue.ToString(), Common.LoginFinancialYear.ToString());
                            dt = Common.ToDataTable(ListKapanProcessSend);
                        }

                        if (dt.Rows.Count > 0)
                        {
                            dtView = new DataView(dt);
                            string rowFilter = "";
                            if (!string.IsNullOrWhiteSpace(grvPurchaseDetails.GetRowCellValue(i, colKapan).ToString()))
                                rowFilter += "KapanId='" + grvPurchaseDetails.GetRowCellValue(i, colKapan).ToString() + "'";
                            if (!string.IsNullOrWhiteSpace(grvPurchaseDetails.GetRowCellValue(i, colPurity).ToString()))
                            {
                                if (rowFilter.Length > 0)
                                    rowFilter += " and";
                                rowFilter += " PurityId ='" + grvPurchaseDetails.GetRowCellValue(i, colPurity).ToString() + "'";
                            }
                            if (!string.IsNullOrWhiteSpace(grvPurchaseDetails.GetRowCellValue(i, colShapeId).ToString()))
                            {
                                if (rowFilter.Length > 0)
                                    rowFilter += " and";
                                rowFilter += " ShapeId='" + grvPurchaseDetails.GetRowCellValue(i, colShapeId).ToString() + "'";
                            }
                            if (!string.IsNullOrWhiteSpace(grvPurchaseDetails.GetRowCellValue(i, colSize).ToString()))
                            {
                                if (rowFilter.Length > 0)
                                    rowFilter += " and";
                                rowFilter += " SizeId ='" + grvPurchaseDetails.GetRowCellValue(i, colSize).ToString() + "'";
                            }
                            if (!string.IsNullOrWhiteSpace(grvPurchaseDetails.GetRowCellValue(i, colCharniSize).ToString()))
                            {
                                if (rowFilter.Length > 0)
                                    rowFilter += " and";
                                rowFilter += " CharniSizeId='" + grvPurchaseDetails.GetRowCellValue(i, colCharniSize).ToString() + "'";
                            }
                            if (!string.IsNullOrWhiteSpace(grvPurchaseDetails.GetRowCellValue(i, colGalaSize).ToString()))
                            {
                                if (rowFilter.Length > 0)
                                    rowFilter += " and";
                                rowFilter += " GalaNumberId='" + grvPurchaseDetails.GetRowCellValue(i, colCharniSize).ToString() + "'";
                            }
                            if (!string.IsNullOrWhiteSpace(grvPurchaseDetails.GetRowCellValue(i, colNumberSize).ToString()))
                            {
                                if (rowFilter.Length > 0)
                                    rowFilter += " and";
                                rowFilter += " NumberSizeId='" + grvPurchaseDetails.GetRowCellValue(i, colNumberSize).ToString() + "'";
                            }

                            if (rowFilter.Length > 0)
                                rowFilter += " and";
                            rowFilter += " AvailableWeight > 0";

                            dtView.RowFilter = rowFilter.Trim();
                            if (dtView.Count > 0)
                            {
                                if (grvPurchaseDetails.GetRowCellValue(i, colCategory).ToString() == CategoryMaster.Kapan.ToString())
                                {
                                    dtView.Sort = "SlipNo ASC";
                                }
                                else
                                {
                                    dtView.Sort = "CharniSizeId ASC";
                                }

                                decimal Value = Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(i, colCarat).ToString());

                                if (!dt.Columns.Contains("AdjustCarat"))
                                {
                                    DataColumn column = new DataColumn();
                                    column.ColumnName = "AdjustCarat";
                                    column.DataType = System.Type.GetType("System.Decimal");
                                    column.DefaultValue = 0;
                                    column.ReadOnly = false;

                                    dt.Columns.Add(column);
                                }

                                foreach (DataRowView row in dtView)
                                {
                                    row["AdjustCarat"] = 0;
                                }

                                decimal a = Convert.ToDecimal(dtView.ToTable().Compute("SUM(AvailableWeight)", string.Empty));
                                if (Value > a)
                                {
                                    MessageBox.Show("Max Amount allowed for available Weight is '" + a.ToString("0.000") + "'.");
                                    return;
                                }
                                decimal TotalValue = 0;
                                decimal RemainValue = Value;
                                decimal AvailableValue = 0;
                                foreach (DataRowView row in dtView)
                                {
                                    if (TotalValue != Value)
                                    {
                                        AvailableValue = Convert.ToDecimal(row["AvailableWeight"]);
                                        decimal TempValue = AvailableValue - RemainValue;
                                        if (TempValue <= 0)
                                        {
                                            row["AdjustCarat"] = AvailableValue;
                                            TotalValue += AvailableValue;
                                            RemainValue = TempValue * -1;
                                        }
                                        else
                                        {
                                            row["AdjustCarat"] = RemainValue;
                                            TotalValue += RemainValue;
                                            RemainValue = 0;
                                        }
                                    }
                                }
                            }

                            dtView.RowFilter = "AdjustCarat > 0";
                            if (dtView.Count > 0)
                            {
                                SalesDetailsSummary salesDetailsSummary;
                                foreach (DataRowView row in dtView)
                                {
                                    salesDetailsSummary = new SalesDetailsSummary();
                                    salesDetailsSummary.Id = Guid.NewGuid().ToString();
                                    salesDetailsSummary.SalesId = SalesId;
                                    salesDetailsSummary.SalesDetailsId = SalesDetailsId;
                                    salesDetailsSummary.CompanyId = lueCompany.EditValue.ToString();
                                    salesDetailsSummary.BranchId = lueBranch.EditValue.ToString();
                                    salesDetailsSummary.FinancialYearId = Common.LoginFinancialYear;
                                    salesDetailsSummary.KapanId = grvPurchaseDetails.GetRowCellValue(i, colKapan).ToString();
                                    salesDetailsSummary.ShapeId = grvPurchaseDetails.GetRowCellValue(i, colShapeId).ToString();
                                    salesDetailsSummary.SizeId = grvPurchaseDetails.GetRowCellValue(i, colSize).ToString();
                                    salesDetailsSummary.PurityId = grvPurchaseDetails.GetRowCellValue(i, colPurity).ToString();
                                    if (grvPurchaseDetails.GetRowCellValue(i, colCharniSize) != null)
                                        salesDetailsSummary.CharniSizeId = grvPurchaseDetails.GetRowCellValue(i, colCharniSize).ToString();
                                    if (grvPurchaseDetails.GetRowCellValue(i, colGalaSize) != null)
                                        salesDetailsSummary.GalaSizeId = grvPurchaseDetails.GetRowCellValue(i, colGalaSize).ToString();
                                    if (grvPurchaseDetails.GetRowCellValue(i, colNumberSize) != null)
                                        salesDetailsSummary.NumberSizeId = grvPurchaseDetails.GetRowCellValue(i, colNumberSize).ToString();

                                    if(row.Row.Table.Columns.Contains("SlipNo"))
                                        salesDetailsSummary.SlipNo = row["SlipNo"].ToString();
                                    salesDetailsSummary.Weight = Convert.ToDecimal(row["AdjustCarat"]);
                                    salesDetailsSummary.Category = Convert.ToInt32(grvPurchaseDetails.GetRowCellValue(i, colCategory).ToString());
                                    if (grvPurchaseDetails.GetRowCellValue(i, colCategory).ToString() == CategoryMaster.Kapan.ToString())
                                    {
                                        salesDetailsSummary.PurchaseDetailsId = row["PurchaseDetailsId"].ToString();
                                        salesDetailsSummary.StockId = row["StockId"].ToString();
                                        salesDetailsSummary.KapanType = row["KapanType"].ToString();
                                    }
                                    salesDetailsSummary.CreatedDate = DateTime.Now;
                                    salesDetailsSummary.CreatedBy = Common.LoginUserID;
                                    salesDetailsSummary.UpdatedDate = DateTime.Now;
                                    salesDetailsSummary.UpdatedBy = Common.LoginUserID;

                                    salesDetailsSummaryList.Insert(i, salesDetailsSummary);
                                }
                            }
                        }
                        #endregion


                        salesDetails = new SalesDetails();
                        salesDetails.Id = SalesDetailsId;
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
                        salesDetails.SalesDetailsSummary = salesDetailsSummaryList;

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
                    salesMaster.TransactionType = Convert.ToInt32(luePaymentMode.GetColumnValue("PTypeID"));
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
                    salesMaster.PaymentDays = Convert.ToInt32(txtPaymentDays.Text);
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

                    var SlipTransferEntity = await _slipTransferEntryRepository.AddSlipTransferEntryAsync(_slipTransferEntries);

                    if (SlipTransferEntity.Count > 0)
                    {
                        salesMaster.TransferParentId = SlipTransferEntity[0].SrNo.ToString();
                    }

                    SalesMasterRepository salesMasterRepository = new SalesMasterRepository();
                    var Result = await salesMasterRepository.AddSalesAsync(salesMaster);

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
                    List<SalesDetails> salesDetailsList = new List<SalesDetails>();
                    List<SalesDetailsSummary> salesDetailsSummaryList = new List<SalesDetailsSummary>();
                    SalesDetails salesDetails = new SalesDetails();

                    for (int i = 0; i < grvPurchaseDetails.RowCount; i++)
                    {
                        DataView dtView = new DataView();
                        string SalesDetailsId = Guid.NewGuid().ToString();

                        if (string.IsNullOrWhiteSpace(grvPurchaseDetails.GetRowCellValue(i, colSalesDetailId).ToString()))
                            SalesDetailsId = Guid.NewGuid().ToString();
                        else
                            SalesDetailsId = grvPurchaseDetails.GetRowCellValue(i, colSalesDetailId).ToString();

                        #region "Sales Details Summary"
                        DataTable dt = new DataTable();
                        if (grvPurchaseDetails.GetRowCellValue(i, colCategory).ToString() == CategoryMaster.Number.ToString())
                        {
                            var listNumberProcess = await _salesMasterRepository.GetSalesItemDetails(CategoryMaster.Number, lueCompany.EditValue.ToString(), lueBranch.EditValue.ToString(), Common.LoginFinancialYear);
                            dt = Common.ToDataTable(listNumberProcess);
                        }
                        else if (grvPurchaseDetails.GetRowCellValue(i, colCategory).ToString() == CategoryMaster.Kapan.ToString())
                        {
                            //var listNumberProcess = await _salesMasterRepository.GetSalesItemDetails(CategoryMaster.Number, lueCompany.EditValue.ToString(), lueBranch.EditValue.ToString(), Common.LoginFinancialYear);
                            //dt = Common.ToDataTable(listNumberProcess);

                            AccountToAssortMasterRepository accountToAssortMasterRepository = new AccountToAssortMasterRepository();
                            var ListKapanProcessSend = await accountToAssortMasterRepository.GetAssortmentSendToDetails(lueCompany.EditValue.ToString(), lueBranch.EditValue.ToString(), Common.LoginFinancialYear.ToString());
                            dt = Common.ToDataTable(ListKapanProcessSend);
                        }

                        if (dt.Rows.Count > 0)
                        {
                            dtView = new DataView(dt);
                            string rowFilter = "";
                            if (!string.IsNullOrWhiteSpace(grvPurchaseDetails.GetRowCellValue(i, colKapan).ToString()))
                                rowFilter += "KapanId='" + grvPurchaseDetails.GetRowCellValue(i, colKapan).ToString() + "'";
                            if (!string.IsNullOrWhiteSpace(grvPurchaseDetails.GetRowCellValue(i, colPurity).ToString()))
                            {
                                if (rowFilter.Length > 0)
                                    rowFilter += " and";
                                rowFilter += " PurityId ='" + grvPurchaseDetails.GetRowCellValue(i, colPurity).ToString() + "'";
                            }
                            if (!string.IsNullOrWhiteSpace(grvPurchaseDetails.GetRowCellValue(i, colShapeId).ToString()))
                            {
                                if (rowFilter.Length > 0)
                                    rowFilter += " and";
                                rowFilter += " ShapeId='" + grvPurchaseDetails.GetRowCellValue(i, colShapeId).ToString() + "'";
                            }
                            if (!string.IsNullOrWhiteSpace(grvPurchaseDetails.GetRowCellValue(i, colSize).ToString()))
                            {
                                if (rowFilter.Length > 0)
                                    rowFilter += " and";
                                rowFilter += " SizeId ='" + grvPurchaseDetails.GetRowCellValue(i, colSize).ToString() + "'";
                            }
                            if (!string.IsNullOrWhiteSpace(grvPurchaseDetails.GetRowCellValue(i, colCharniSize).ToString()))
                            {
                                if (rowFilter.Length > 0)
                                    rowFilter += " and";
                                rowFilter += " CharniSizeId='" + grvPurchaseDetails.GetRowCellValue(i, colCharniSize).ToString() + "'";
                            }
                            if (!string.IsNullOrWhiteSpace(grvPurchaseDetails.GetRowCellValue(i, colGalaSize).ToString()))
                            {
                                if (rowFilter.Length > 0)
                                    rowFilter += " and";
                                rowFilter += " GalaNumberId='" + grvPurchaseDetails.GetRowCellValue(i, colCharniSize).ToString() + "'";
                            }
                            if (!string.IsNullOrWhiteSpace(grvPurchaseDetails.GetRowCellValue(i, colNumberSize).ToString()))
                            {
                                if (rowFilter.Length > 0)
                                    rowFilter += " and";
                                rowFilter += " NumberSizeId='" + grvPurchaseDetails.GetRowCellValue(i, colNumberSize).ToString() + "'";
                            }
                            dtView.RowFilter = rowFilter.Trim();
                            if (dtView.Count > 0)
                            {
                                if (grvPurchaseDetails.GetRowCellValue(i, colCategory).ToString() == CategoryMaster.Kapan.ToString())
                                {
                                    dtView.Sort = "SlipNo ASC";
                                }
                                else
                                {
                                    dtView.Sort = "CharniSizeId ASC";
                                }

                                decimal Value = Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(i, colCarat).ToString());

                                if (!dt.Columns.Contains("AdjustCarat"))
                                {
                                    DataColumn column = new DataColumn();
                                    column.ColumnName = "AdjustCarat";
                                    column.DataType = System.Type.GetType("System.Decimal");
                                    column.DefaultValue = 0;
                                    column.ReadOnly = false;

                                    dt.Columns.Add(column);
                                }

                                foreach (DataRowView row in dtView)
                                {
                                    row["AdjustCarat"] = 0;
                                }

                                decimal a = Convert.ToDecimal(dtView.ToTable().Compute("SUM(AvailableWeight)", string.Empty));
                                if (Value > a)
                                {
                                    MessageBox.Show("Max Amount allowed for available Weight is '" + a.ToString("0.000") + "'.");
                                    return;
                                }
                                decimal TotalValue = 0;
                                decimal RemainValue = Value;
                                decimal AvailableValue = 0;
                                foreach (DataRowView row in dtView)
                                {
                                    if (TotalValue != Value)
                                    {
                                        AvailableValue = Convert.ToDecimal(row["AvailableWeight"]);
                                        decimal TempValue = AvailableValue - RemainValue;
                                        if (TempValue <= 0)
                                        {
                                            row["AdjustCarat"] = AvailableValue;
                                            TotalValue += AvailableValue;
                                            RemainValue = TempValue * -1;
                                        }
                                        else
                                        {
                                            row["AdjustCarat"] = RemainValue;
                                            TotalValue += RemainValue;
                                            RemainValue = 0;
                                        }
                                    }
                                }
                            }

                            dtView.RowFilter = "AdjustCarat > 0";
                            if (dtView.Count > 0)
                            {
                                SalesDetailsSummary salesDetailsSummary;
                                foreach (DataRowView row in dtView)
                                {
                                    salesDetailsSummary = new SalesDetailsSummary();
                                    salesDetailsSummary.Id = Guid.NewGuid().ToString();
                                    salesDetailsSummary.SalesId = _editedSalesMaster.Id;
                                    salesDetailsSummary.SalesDetailsId = SalesDetailsId;
                                    salesDetailsSummary.CompanyId = lueCompany.EditValue.ToString();
                                    salesDetailsSummary.BranchId = lueBranch.EditValue.ToString();
                                    salesDetailsSummary.FinancialYearId = Common.LoginFinancialYear;
                                    salesDetailsSummary.KapanId = grvPurchaseDetails.GetRowCellValue(i, colKapan).ToString();
                                    salesDetailsSummary.ShapeId = grvPurchaseDetails.GetRowCellValue(i, colShapeId).ToString();
                                    salesDetailsSummary.SizeId = grvPurchaseDetails.GetRowCellValue(i, colSize).ToString();
                                    salesDetailsSummary.PurityId = grvPurchaseDetails.GetRowCellValue(i, colPurity).ToString();
                                    if (grvPurchaseDetails.GetRowCellValue(i, colCharniSize) != null)
                                        salesDetailsSummary.CharniSizeId = grvPurchaseDetails.GetRowCellValue(i, colCharniSize).ToString();
                                    if (grvPurchaseDetails.GetRowCellValue(i, colGalaSize) != null)
                                        salesDetailsSummary.GalaSizeId = grvPurchaseDetails.GetRowCellValue(i, colGalaSize).ToString();
                                    if (grvPurchaseDetails.GetRowCellValue(i, colNumberSize) != null)
                                        salesDetailsSummary.NumberSizeId = grvPurchaseDetails.GetRowCellValue(i, colNumberSize).ToString();

                                    if (row.Row.Table.Columns.Contains("SlipNo"))
                                        salesDetailsSummary.SlipNo = row["SlipNo"].ToString();
                                    salesDetailsSummary.Weight = Convert.ToDecimal(row["AdjustCarat"]);
                                    salesDetailsSummary.Category = Convert.ToInt32(grvPurchaseDetails.GetRowCellValue(i, colCategory).ToString());
                                    if (grvPurchaseDetails.GetRowCellValue(i, colCategory).ToString() == CategoryMaster.Kapan.ToString())
                                    {
                                        salesDetailsSummary.PurchaseDetailsId = row["PurchaseDetailsId"].ToString();
                                        salesDetailsSummary.StockId = row["StockId"].ToString();
                                        salesDetailsSummary.KapanType = row["KapanType"].ToString();
                                    }
                                    salesDetailsSummary.CreatedDate = DateTime.Now;
                                    salesDetailsSummary.CreatedBy = Common.LoginUserID;
                                    salesDetailsSummary.UpdatedDate = DateTime.Now;
                                    salesDetailsSummary.UpdatedBy = Common.LoginUserID;

                                    salesDetailsSummaryList.Insert(i, salesDetailsSummary);
                                }
                            }
                        }
                        #endregion

                        salesDetails = new SalesDetails();
                        salesDetails.Id = SalesDetailsId;
                        salesDetails.SalesId = _editedSalesMaster.Id;
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
                        salesDetails.SalesDetailsSummary = salesDetailsSummaryList;

                        salesDetailsList.Insert(i, salesDetails);
                    }

                    SalesMaster salesMaster = new SalesMaster();
                    salesMaster.Id = _editedSalesMaster.Id;
                    salesMaster.CompanyId = lueCompany.GetColumnValue("Id").ToString();
                    salesMaster.BranchId = lueBranch.GetColumnValue("Id").ToString();
                    salesMaster.PartyId = lueParty.GetColumnValue("Id").ToString();
                    salesMaster.SalerId = lueSaler.GetColumnValue("Id").ToString();
                    salesMaster.CurrencyId = lueCurrencyType.GetColumnValue("Id").ToString();
                    //purchaseMaster.FinancialYearId = Common.LoginFinancialYear;
                    salesMaster.BrokerageId = lueBroker.GetColumnValue("Id").ToString();
                    salesMaster.CurrencyRate = Convert.ToDecimal(txtCurrencyType.Text);
                    salesMaster.SaleBillNo = Convert.ToInt32(txtSerialNo.Text);
                    salesMaster.SlipNo = Convert.ToInt32(txtSlipNo.Text);
                    salesMaster.TransactionType = Convert.ToInt32(luePaymentMode.GetColumnValue("PTypeID"));
                    salesMaster.Date = Convert.ToDateTime(dtDate.Text).ToString("yyyyMMdd");
                    salesMaster.Time = Convert.ToDateTime(dtTime.Text).ToString("hh:mm:ss ttt");
                    salesMaster.DayName = Convert.ToDateTime(dtDate.EditValue).DayOfWeek.ToString();
                    //purchaseMaster.PartyLastBalanceWhilePurchase = float.Parse(txtPartyBalance.Text);
                    salesMaster.BrokerPercentage = Convert.ToDecimal(txtBrokerPercentage.Text);
                    salesMaster.BrokerAmount = float.Parse(txtBrokerageAmount.Text);
                    salesMaster.RoundUpAmount = float.Parse(txtRoundAmount.Text);
                    salesMaster.Total = float.Parse(txtAmount.Text);
                    salesMaster.GrossTotal = float.Parse(txtNetAmount.Text);
                    salesMaster.DueDays = Convert.ToInt32(txtDays.Text);
                    salesMaster.DueDate = Convert.ToDateTime(dtDate.Text).AddDays(Convert.ToInt32(txtDays.Text));
                    salesMaster.PaymentDays = Convert.ToInt32(txtPaymentDays.Text);
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
                    //purchaseMaster.CreatedDate = DateTime.Now;
                    //purchaseMaster.CreatedBy = Common.LoginUserID;
                    salesMaster.UpdatedDate = DateTime.Now;
                    salesMaster.UpdatedBy = Common.LoginUserID;
                    salesMaster.ApprovalType = 0;
                    salesMaster.Message = "";
                    salesMaster.SalesDetails = salesDetailsList;

                    if (_slipTransferEntries.Count > 0)
                    {
                        salesMaster.TransferParentId = _slipTransferEntries[0].SrNo.ToString();
                    }

                    SalesMasterRepository salesMasterRepository = new SalesMasterRepository();
                    var Result = await salesMasterRepository.UpdateSalesAsync(salesMaster);

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
                        //MessageBox.Show(AppMessages.GetString(AppMessageID.SaveSuccessfully), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await Reset();
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

        private async Task Reset()
        {
            grdPurchaseDetails.DataSource = null;
            grdSlipParticularsDetails.DataSource = null;
            _slipTransferEntries = new List<SlipTransferEntry>();
            lueSaler.EditValue = "";
            lueParty.EditValue = "";
            lueBroker.EditValue = "";
            FillCombos();
            //FillBranches();
            await FillCurrency();
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
            btnSave.Text = AppMessages.GetString(AppMessageID.Save);
            grdPurchaseDetails.Enabled = true;
            _editedSalesMaster = null;
            pnlStatus.Appearance.BackColor = Color.FromArgb(128, 128, 128);
            await GetSalesNo();
            
            txtSlipNo.Select();
            txtSlipNo.Focus();
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
                var SrNo1 = await _slipTransferEntryRepository.GetMaxSrNo(1, Common.LoginFinancialYear);
                SrNo = SrNo1.ToString();
            }

            Transaction.FrmSlipTransfer frmSlipTransfer = new FrmSlipTransfer(lueCompany.EditValue.ToString(), 1, txtSlipNo.Text, Convert.ToDecimal(colAmount.SummaryItem.SummaryValue), SrNo, _slipTransferEntries, lueBranch.EditValue.ToString(), Common.LoginFinancialYear);
            if (frmSlipTransfer.ShowDialog() == DialogResult.OK)
            {
                _slipTransferEntries = frmSlipTransfer.SlipTransferDetails;
                grdSlipParticularsDetails.DataSource = _slipTransferEntries;
            }
        }

        private void txtSalerCommisionPercentage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CalculateCommisionRate(true);
            }
        }

        private void txtSalerCommisionPercentage_Leave(object sender, EventArgs e)
        {
            CalculateCommisionRate(true);
        }

        private void txtBrokerPercentage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CalculateBrokerageRate(true);
            }
        }

        private void txtBrokerPercentage_Leave(object sender, EventArgs e)
        {
            CalculateBrokerageRate(true);
        }

        private void SetGridViewFocus()
        {
            if (grvPurchaseDetails.VisibleColumns.Count > 0)
            {
                if (this.ActiveControl.GetType() != typeof(DevExpress.XtraGrid.GridControl))
                {
                    grvPurchaseDetails.Focus();
                    SendKeys.Send("{TAB}");
                    grvPurchaseDetails.FocusedColumn = colCategory;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dtTime.EditValue = DateTime.Now;
        }
    }
}