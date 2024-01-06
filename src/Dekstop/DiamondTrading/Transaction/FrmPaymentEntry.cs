using Bogus.DataSets;
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
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiamondTrading.Transaction
{
    public partial class FrmPaymentEntry : DevExpress.XtraEditors.XtraForm
    {
        private readonly CompanyMasterRepository _companyMasterRepository;
        private readonly PartyMasterRepository _partyMasterRepository;
        private PaymentMasterRepository _paymentMaterRepository;
        private readonly ContraEntryMasterRespository _contraEntryRepository;
        int _paymentType = 0;
        DataTable dtSlipDetail;
        string PartyId = string.Empty;
        int _selectedSrNo = 0;
        string _selectedCompany = string.Empty;
        string _selectedFinancialYear = string.Empty;
        int _ExpenseCrDrType = 0;
        List<ExpenseDetails> _editedExpenseDetails = new List<ExpenseDetails>();
        ContraEntryMaster _contraEntryMaster = new ContraEntryMaster();
        List<PartyMaster> PartyList = new List<PartyMaster>();

        public FrmPaymentEntry(string PaymentType)
        {
            InitializeComponent();

            _companyMasterRepository = new CompanyMasterRepository();
            _partyMasterRepository = new PartyMasterRepository();
            _paymentMaterRepository = new PaymentMasterRepository();
            _contraEntryRepository = new ContraEntryMasterRespository();

            if (PaymentType == "Payment" || PaymentType == "Expense")
            {
                _paymentType = 0;
                SetThemeColors(Color.FromArgb(250, 243, 197));
                this.Text = "PAYMENT";
            }
            else if (PaymentType == "Receipt")
            {
                _paymentType = 1;
                SetThemeColors(Color.FromArgb(215, 246, 214));
                this.Text = "RECEIPT";
            }
            else
            {
                _paymentType = -1;
                SetThemeColors(Color.FromArgb(217, 217, 217));
                this.Text = "CONTRA";
                colAdjustAmt.Visible = false;
            }
        }

        public FrmPaymentEntry(string PaymentType, string Company, string FinancialYear, int SrNo, int CrDrType)
        {
            InitializeComponent();

            _companyMasterRepository = new CompanyMasterRepository();
            _partyMasterRepository = new PartyMasterRepository();
            _paymentMaterRepository = new PaymentMasterRepository();
            _contraEntryRepository = new ContraEntryMasterRespository();

            if (PaymentType == "Payment")
            {
                _paymentType = 0;
                SetThemeColors(Color.FromArgb(250, 243, 197));
                this.Text = "PAYMENT";
            }
            else if (PaymentType == "Receipt")
            {
                _paymentType = 1;
                SetThemeColors(Color.FromArgb(215, 246, 214));
                this.Text = "RECEIPT";
            }
            else if (PaymentType == "Expense")
            {
                _paymentType = 2;
                _ExpenseCrDrType = CrDrType;
                if (_ExpenseCrDrType == 0)
                    SetThemeColors(Color.FromArgb(250, 243, 197));
                else
                    SetThemeColors(Color.FromArgb(215, 246, 214));
                this.Text = "Expense";
            }
            else
            {
                _paymentType = -1;
                SetThemeColors(Color.FromArgb(217, 217, 217));
                this.Text = "CONTRA";
                colAdjustAmt.Visible = false;
            }
            _selectedSrNo = SrNo;
            _selectedCompany = Company;
            _selectedFinancialYear = FinancialYear;
        }

        private async void LoadSeries(int paymentType)
        {
            grdPaymentDetails.DataSource = GetDTColumnsForPaymentDetails();
            if (paymentType == -1)
            {
                var result = await _contraEntryRepository.GetMaxNo(lueCompany.EditValue.ToString(), Common.LoginFinancialYear);
                txtSerialNo.Text = result.ToString();
            }
            else
            {
                ExpenseMasterRepository expenseMasterRepository = new ExpenseMasterRepository();
                var PaymentSrNo = await _paymentMaterRepository.GetMaxSrNoAsync(paymentType, lueCompany.EditValue.ToString(), Common.LoginFinancialYear);

                var ExpenseSrNo = await expenseMasterRepository.GetMaxSrNoAsync(Common.LoginCompany.ToString(), Common.LoginFinancialYear);
                int SrNo = 0;
                if (PaymentSrNo >= ExpenseSrNo)
                    SrNo = PaymentSrNo;
                else
                    SrNo = ExpenseSrNo;

                txtSerialNo.Text = SrNo.ToString();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblFormTitle_Click(object sender, EventArgs e)
        {

        }

        private async void FrmPaymentEntry_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string lastselectedDate = RegistryHelper.GetSettings(RegistryHelper.MainSection, RegistryHelper.TranscationDateSelection, "");

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

                timer1.Start();
                colBranch.Visible = false;
                await LoadCompany();
                LoadSeries(_paymentType);
                await LoadLedgers(lueCompany.EditValue.ToString());

                if (_paymentType == 0 || _paymentType == 1 || _paymentType == 2)
                    await LoadBranch(lueCompany.EditValue.ToString());

                if (_selectedSrNo != 0)
                {
                    if (_paymentType == -1)
                    {
                        ContraEntryMasterRespository contraEntryMasterRespository = new ContraEntryMasterRespository();
                        _contraEntryMaster = await contraEntryMasterRespository.GetContraEntryAsync(Common.LoginCompany, Common.LoginFinancialYear, _selectedSrNo);

                        if (_contraEntryMaster != null)
                        {
                            btnSave.Text = AppMessages.GetString(AppMessageID.Update);
                            txtSerialNo.Text = _selectedSrNo.ToString();
                            lueCompany.EditValue = _selectedCompany;
                            lueLeadger.EditValue = _contraEntryMaster.ToPartyId.ToString();
                            txtRemark.Text = _contraEntryMaster.Remarks;
                            grvPaymentDetails.CellValueChanged -= grvPaymentDetails_CellValueChanged;
                            colBranch.Visible = false;
                            dtDate.EditValue = DateTime.ParseExact(_contraEntryMaster.EntryDate, "yyyyMMdd", CultureInfo.InvariantCulture); ;

                            for (int i = 0; i < _contraEntryMaster.ContraEntryDetails.Count; i++)
                            {
                                grvPaymentDetails.AddNewRow();

                                //grvPaymentDetails.SetFocusedRowCellValue(colBranch, _contraEntryMaster.ContraEntryDetails[i].BranchId);
                                grvPaymentDetails.SetFocusedRowCellValue(colParty, _contraEntryMaster.ContraEntryDetails[i].FromParty);
                                grvPaymentDetails.SetFocusedRowCellValue(colAmount, _contraEntryMaster.ContraEntryDetails[i].Amount);
                                grvPaymentDetails.SetFocusedRowCellValue(colPartyType, PartyTypeMaster.None);
                                grvPaymentDetails.UpdateCurrentRow();
                            }
                            grvPaymentDetails.CellValueChanged += grvPaymentDetails_CellValueChanged;
                        }
                    }
                    else if (_paymentType == 2) //Excepnse
                    {
                        ExpenseMasterRepository expenseMasterRepository = new ExpenseMasterRepository();
                        _editedExpenseDetails = await expenseMasterRepository.GetExpenseAsync(_selectedCompany, _selectedFinancialYear, _selectedSrNo);

                        if (_editedExpenseDetails != null)
                        {
                            btnSave.Text = AppMessages.GetString(AppMessageID.Update);
                            txtSerialNo.Text = _selectedSrNo.ToString();
                            lueCompany.EditValue = _selectedCompany;
                            lueLeadger.EditValue = _editedExpenseDetails[0].fromPartyId.ToString();
                            txtRemark.Text = _editedExpenseDetails[0].Remarks;
                            grvPaymentDetails.CellValueChanged -= grvPaymentDetails_CellValueChanged;
                            dtDate.EditValue = DateTime.ParseExact(_editedExpenseDetails[0].EntryDate, "yyyyMMdd", CultureInfo.InvariantCulture); ;
                            colBranch.Visible = true;
                            for (int i = 0; i < _editedExpenseDetails.Count; i++)
                            {
                                grvPaymentDetails.AddNewRow();

                                grvPaymentDetails.SetFocusedRowCellValue(colBranch, _editedExpenseDetails[i].BranchId);
                                grvPaymentDetails.SetFocusedRowCellValue(colParty, _editedExpenseDetails[i].PartyId);
                                grvPaymentDetails.SetFocusedRowCellValue(colAmount, _editedExpenseDetails[i].Amount);
                                grvPaymentDetails.SetFocusedRowCellValue(colPartyType, PartyTypeMaster.Expense);
                                grvPaymentDetails.UpdateCurrentRow();
                            }
                            grvPaymentDetails.CellValueChanged += grvPaymentDetails_CellValueChanged;
                        }
                    }
                    else if (_paymentType == 0 || _paymentType == 1) //Payment / receipt
                    {
                        var _editedPaymentDetails = await _paymentMaterRepository.GetPaymentAsync(_selectedCompany, _selectedFinancialYear, _selectedSrNo, _paymentType);
                        if (_editedPaymentDetails != null)
                        {
                            btnSave.Text = AppMessages.GetString(AppMessageID.Update);
                            txtSerialNo.Text = _selectedSrNo.ToString();
                            lueCompany.EditValue = _selectedCompany;
                            lueLeadger.EditValue = _editedPaymentDetails.ToPartyId.ToString();
                            txtRemark.Text = _editedPaymentDetails.Remarks;
                            dtDate.EditValue = DateTime.ParseExact(_editedPaymentDetails.EntryDate, "yyyyMMdd", CultureInfo.InvariantCulture); ;
                            grvPaymentDetails.CellValueChanged -= grvPaymentDetails_CellValueChanged;
                            colBranch.Visible = false;
                            for (int i = 0; i < _editedPaymentDetails?.PaymentMasters.Count; i++)
                            {
                                grvPaymentDetails.AddNewRow();
                                string RowId = Guid.NewGuid().ToString();
                                string PartyId = _editedPaymentDetails?.PaymentMasters[i].FromPartyId;
                                int PartyType = PartyList.FirstOrDefault(x => x.Id == PartyId).Type;
                                //grvPaymentDetails.SetFocusedRowCellValue(colBranch, _contraEntryMaster.ContraEntryDetails[i].BranchId);
                                grvPaymentDetails.SetFocusedRowCellValue(colParty, PartyId);
                                grvPaymentDetails.SetFocusedRowCellValue(colAmount, _editedPaymentDetails.PaymentMasters[i].Amount);
                                grvPaymentDetails.SetFocusedRowCellValue(colPartyType, PartyType);
                                grvPaymentDetails.SetFocusedRowCellValue(colRowId, RowId);

                                for (int j = 0; j < _editedPaymentDetails?.PaymentMasters[i]?.PaymentDetails?.Count; j++)
                                {
                                    if (!dtSlipDetail.Columns.Contains("Amount"))
                                        dtSlipDetail.Columns.Add("Amount", typeof(decimal));

                                    if (!dtSlipDetail.Columns.Contains("RowId"))
                                        dtSlipDetail.Columns.Add("RowId", typeof(string));

                                    DataView dtView = new DataView(dtSlipDetail);
                                    dtView.RowFilter = "PartyId='" + PartyId + "'";
                                    if (_editedPaymentDetails?.PaymentMasters[i]?.PaymentDetails[j]?.SlipNo == "-1")
                                    {
                                        DataRow[] dataRow = dtSlipDetail.Select("SlipNo=-1 and PartyId='" + grvPaymentDetails.GetRowCellValue(grvPaymentDetails.FocusedRowHandle, colParty) + "'" +
                                            " and (RowId='" + RowId + "' OR ISNULL(RowId,'') = '' OR RowId = '')");
                                        if (dataRow.Length == 0)
                                        {
                                            var PartyOpeningBalance = await _partyMasterRepository.GetPartyBalance(grvPaymentDetails.GetRowCellValue(grvPaymentDetails.FocusedRowHandle, colParty).ToString(), Common.LoginCompany, Common.LoginFinancialYear);

                                            decimal allSlipRemainingBalance = 0;

                                            if (dtView.Count > 0)
                                            {
                                                allSlipRemainingBalance = Convert.ToDecimal(dtView.ToTable().Compute("SUM(RemainAmount)", string.Empty));

                                                PartyOpeningBalance = PartyOpeningBalance - allSlipRemainingBalance;
                                            }

                                            dtSlipDetail.Rows.Add(0, DateTime.Now, grvPaymentDetails.GetRowCellValue(grvPaymentDetails.FocusedRowHandle, colParty),
                                                "Opening Balance", "-1", lueCompany.EditValue, grvPaymentDetails.GetRowCellValue(grvPaymentDetails.FocusedRowHandle, colBranch),
                                                Common.LoginFinancialYear, Common.LoginFinancialYearName,
                                                PartyOpeningBalance, 0, 0, RowId);
                                        }
                                    }
                                    else if (_editedPaymentDetails.PaymentMasters[i].PaymentDetails[j].SlipNo == "-2")
                                    {
                                        DataRow[] dataRow1 = dtSlipDetail.Select("SlipNo=-2 and PartyId='" + grvPaymentDetails.GetRowCellValue(grvPaymentDetails.FocusedRowHandle, colParty) + "'" +
                                            " and (RowId='" + RowId + "' OR ISNULL(RowId,'') = '' OR RowId = '')");
                                        if (dataRow1.Length == 0)
                                        {
                                            dtSlipDetail.Rows.Add(0, DateTime.Now, grvPaymentDetails.GetRowCellValue(grvPaymentDetails.FocusedRowHandle, colParty),
                                                "New Refrence", "-2", lueCompany.EditValue, grvPaymentDetails.GetRowCellValue(grvPaymentDetails.FocusedRowHandle, colBranch),
                                                Common.LoginFinancialYear, Common.LoginFinancialYearName,
                                                0, 0, 0, RowId);
                                        }
                                    }

                                    dtView.RowFilter = "PartyId='" + PartyId + "' and SlipNo='" + _editedPaymentDetails.PaymentMasters[i].PaymentDetails[j].SlipNo + "'" +
                                        " and (RowId='" + RowId + "' OR ISNULL(RowId,'') = '' OR RowId = '')";
                                    if (dtView.Count > 0)
                                    {
                                        foreach (DataRowView subRow in dtView)
                                        {
                                            if (subRow["RowId"].ToString() == RowId)
                                            {
                                                subRow["Amount"] = 0;
                                            }
                                        }
                                        dtView[0].Row["Amount"] = _editedPaymentDetails.PaymentMasters[i].PaymentDetails[j].Amount;
                                        dtView[0].Row["RowId"] = RowId;
                                    }
                                }
                                grvPaymentDetails.UpdateCurrentRow();
                            }
                            grvPaymentDetails.CellValueChanged += grvPaymentDetails_CellValueChanged;
                        }
                    }
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message, "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private static DataTable GetDTColumnsForPaymentDetails()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Branch");
            dt.Columns.Add("Party");
            dt.Columns.Add("Amount");
            dt.Columns.Add("AutoAdjustBillAmount");
            dt.Columns.Add("PartyType");
            dt.Columns.Add("AdjustBtn");
            dt.Columns.Add("PartyId");
            dt.Columns.Add("RowId");
            return dt;
        }

        private void SetThemeColors(Color color)
        {
            if (!color.ToArgb().ToString().Equals(Color.FromArgb(0).Name))
            {
                grpGroup1.AppearanceCaption.BorderColor = color;
                grpGroup2.AppearanceCaption.BorderColor = color;

                //txtLedgerBalance.BackColor = color;
            }
        }

        private async Task LoadCompany()
        {
            var result = await _companyMasterRepository.GetUserCompanyMappingAsync(Common.LoginUserID);
            lueCompany.Properties.DataSource = result;
            lueCompany.Properties.DisplayMember = "Name";
            lueCompany.Properties.ValueMember = "Id";
            lueCompany.EditValue = Common.LoginCompany;
        }

        private async Task LoadLedgers(string companyId)
        {
            if (_paymentType == -1)
            {
                var result = await _partyMasterRepository.GetAllPartyAsync(companyId, new int[] { 4, 5 });
                lueLeadger.Properties.DataSource = result;
                lueLeadger.Properties.DisplayMember = "Name";
                lueLeadger.Properties.ValueMember = "Id";

                repoParty.DataSource = result;
                repoParty.DisplayMember = "Name";
                repoParty.ValueMember = "Id";
            }
            else
            {
                var result = await _partyMasterRepository.GetAllPartyAsync(companyId);
                lueLeadger.Properties.DataSource = result.Where(x => x.Type == PartyTypeMaster.Cash || x.Type == PartyTypeMaster.Bank);
                lueLeadger.Properties.DisplayMember = "Name";
                lueLeadger.Properties.ValueMember = "Id";

                PartyList = result.Where(x => x.Type != PartyTypeMaster.Cash && x.Type != PartyTypeMaster.Bank).ToList();
                repoParty.DataSource = PartyList;
                repoParty.DisplayMember = "Name";
                repoParty.ValueMember = "Id";

                List<PaymentPSSlipDetails> PaymentSlipDetails = await _paymentMaterRepository.GetPaymentPSSlipDetails(lueCompany.EditValue.ToString(), _paymentType.ToString(), _selectedSrNo);
                dtSlipDetail = Common.ToDataTable<PaymentPSSlipDetails>(PaymentSlipDetails);
            }
        }

        private async Task LoadBranch(string CompanyId)
        {
            BranchMasterRepository branchMasterRepository = new BranchMasterRepository();
            var result = await branchMasterRepository.GetAllBranchAsync(CompanyId);

            repoBranch.DataSource = result;
            repoBranch.DisplayMember = "Name";
            repoBranch.ValueMember = "Id";
        }

        private async void lueLeadger_EditValueChanged(object sender, EventArgs e)
        {
            if (lueLeadger.EditValue != null)
            {
                var result = await _partyMasterRepository.GetPartyBalance(lueLeadger.EditValue.ToString(), Common.LoginCompany, Common.LoginFinancialYear);
                string CrDr = "Cr";
                if (Convert.ToInt32(result) < 0)
                {
                    CrDr = "Dr";
                }
                txtLedgerBalance.Text = result.ToString("0.00") + " " + CrDr;
            }
        }

        private void grvPurchaseDetails_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            //string ControlName = ((DevExpress.XtraEditors.LookUpEdit)sender).Name;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                RegistryHelper.SaveSettings(RegistryHelper.MainSection, RegistryHelper.TranscationDateSelection, dtDate.DateTime.ToString());

                this.Cursor = Cursors.WaitCursor;

                if (btnSave.Text == AppMessages.GetString(AppMessageID.Save))
                {
                    //Contra Entry
                    if (_paymentType == -1)
                    {
                        string contraMasterId = Guid.NewGuid().ToString();
                        List<ContraEntryDetails> contraEntryDetails = new List<ContraEntryDetails>();

                        for (int i = 0; i < grvPaymentDetails.RowCount; i++)
                        {
                            ContraEntryDetails contraDetail = new ContraEntryDetails();
                            string fromPartyId = grvPaymentDetails.GetRowCellValue(i, colParty).ToString();
                            string amount = grvPaymentDetails.GetRowCellValue(i, colAmount).ToString();

                            contraDetail.Id = Guid.NewGuid().ToString();
                            contraDetail.ContraEntryMasterId = contraMasterId;
                            contraDetail.Amount = Convert.ToDecimal(amount);
                            contraDetail.FromParty = fromPartyId;
                            contraDetail.CreatedDate = DateTime.Now;
                            contraDetail.UpdatedDate = DateTime.Now;
                            contraDetail.CreatedBy = Common.LoginUserID;
                            contraDetail.UpdatedBy = Common.LoginUserID;
                            contraEntryDetails.Add(contraDetail);
                        }

                        ContraEntryMaster contraEntryMaster = new ContraEntryMaster
                        {
                            Id = contraMasterId,
                            SrNo = Convert.ToInt32(txtSerialNo.Text),
                            BranchId = Common.LoginBranch,
                            CompanyId = lueCompany.EditValue.ToString(),
                            FinancialYearId = Common.LoginFinancialYear,
                            IsDelete = false,
                            Remarks = txtRemark.Text,
                            ToPartyId = lueLeadger.EditValue.ToString(),
                            ContraEntryDetails = contraEntryDetails,
                            CreatedBy = Common.LoginUserID,
                            CreatedDate = DateTime.Now,
                            UpdatedBy = Common.LoginUserID,
                            UpdatedDate = DateTime.Now,
                            EntryDate = Convert.ToDateTime(dtDate.Text).ToString("yyyyMMdd")
                        };

                        var result = await _contraEntryRepository.AddContraEntryAsync(contraEntryMaster);

                        if (result != null)
                        {
                            Reset();
                            MessageBox.Show(AppMessages.GetString(AppMessageID.SaveSuccessfully), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        await SavePaymentReceipt();
                    }
                }
                else
                {
                    //Contra Entry
                    if (_paymentType == -1)
                    {
                        _= await _contraEntryRepository.DeleteContraEntryAsync(_selectedSrNo);
                        string contraMasterId = Guid.NewGuid().ToString();
                        List<ContraEntryDetails> contraEntryDetails = new List<ContraEntryDetails>();

                        for (int i = 0; i < grvPaymentDetails.RowCount; i++)
                        {
                            ContraEntryDetails contraDetail = new ContraEntryDetails();
                            string fromPartyId = grvPaymentDetails.GetRowCellValue(i, colParty).ToString();
                            string amount = grvPaymentDetails.GetRowCellValue(i, colAmount).ToString();

                            contraDetail.Id = Guid.NewGuid().ToString();
                            contraDetail.ContraEntryMasterId = contraMasterId;
                            contraDetail.Amount = Convert.ToDecimal(amount);
                            contraDetail.FromParty = fromPartyId;
                            contraDetail.CreatedDate = DateTime.Now;
                            contraDetail.UpdatedDate = DateTime.Now;
                            contraDetail.CreatedBy = Common.LoginUserID;
                            contraDetail.UpdatedBy = Common.LoginUserID;
                            contraEntryDetails.Add(contraDetail);
                        }

                        ContraEntryMaster contraEntryMaster = new ContraEntryMaster
                        {
                            Id = contraMasterId,
                            SrNo = Convert.ToInt32(txtSerialNo.Text),
                            BranchId = Common.LoginBranch,
                            CompanyId = lueCompany.EditValue.ToString(),
                            FinancialYearId = Common.LoginFinancialYear,
                            IsDelete = false,
                            Remarks = txtRemark.Text,
                            ToPartyId = lueLeadger.EditValue.ToString(),
                            ContraEntryDetails = contraEntryDetails,
                            CreatedBy = Common.LoginUserID,
                            CreatedDate = DateTime.Now,
                            UpdatedBy = Common.LoginUserID,
                            UpdatedDate = DateTime.Now,
                            EntryDate = Convert.ToDateTime(dtDate.Text).ToString("yyyyMMdd")
                        };

                        var result = await _contraEntryRepository.AddContraEntryAsync(contraEntryMaster);

                        if (result != null)
                        {
                            Reset();
                            MessageBox.Show(AppMessages.GetString(AppMessageID.SaveSuccessfully), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        this.DialogResult = DialogResult.OK;
                    }
                    else if (_paymentType == 2)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        bool IsSucess = false;
                        try
                        {
                            ExpenseMasterRepository expenseMasterRepository = new ExpenseMasterRepository();
                            await expenseMasterRepository.DeleteExpenseAsync(_editedExpenseDetails[0].Id, true);

                            for (int i = 0; i < grvPaymentDetails.RowCount; i++)
                            {
                                ExpenseDetails expenseDetails = new ExpenseDetails
                                {
                                    Id = Guid.NewGuid().ToString(),
                                    SrNo = Convert.ToInt32(txtSerialNo.Text),
                                    BranchId = grvPaymentDetails.GetRowCellValue(i, colBranch).ToString(), //Common.LoginBranch,
                                    CompanyId = lueCompany.EditValue.ToString(),
                                    FinancialYearId = Common.LoginFinancialYear,
                                    PartyId = grvPaymentDetails.GetRowCellValue(i, colParty).ToString(),
                                    fromPartyId = lueLeadger.EditValue.ToString(),
                                    CrDrType = _ExpenseCrDrType,
                                    Amount = float.Parse(grvPaymentDetails.GetRowCellValue(i, colAmount).ToString()),
                                    IsDelete = false,
                                    Remarks = txtRemark.Text,
                                    CreatedBy = Common.LoginUserID,
                                    CreatedDate = DateTime.Now,
                                    UpdatedBy = Common.LoginUserID,
                                    UpdatedDate = DateTime.Now,
                                    EntryDate = Convert.ToDateTime(dtDate.Text).ToString("yyyyMMdd")
                                };

                                string partyId = grvPaymentDetails.GetRowCellValue(i, colParty).ToString();
                                string fromparty = lueLeadger.EditValue.ToString();
                                decimal amt = decimal.Parse(grvPaymentDetails.GetRowCellValue(i, colAmount).ToString());

                                var result = await expenseMasterRepository.AddExpenseAsync(expenseDetails);

                                IsSucess = true;
                            }
                        }
                        catch (Exception Ex)
                        {
                            IsSucess = false;
                        }

                        if (IsSucess)
                        {
                            Reset();
                            MessageBox.Show(AppMessages.GetString(AppMessageID.SaveSuccessfully), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        this.DialogResult = DialogResult.OK;
                    }
                    else if(_paymentType == 0 || _paymentType == 1)
                    {
                        bool isDelete = await _paymentMaterRepository.DeleteGroupPaymentAsync(_selectedSrNo, _paymentType);
                        if (isDelete)
                        {
                            await SavePaymentReceipt();
                        }
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

        private async Task SavePaymentReceipt()
        {
            string groupId = Guid.NewGuid().ToString();
            List<PaymentMaster> paymentMasters = new List<PaymentMaster>();
            List<PaymentDetails> listPaymentDetails = new List<PaymentDetails>();
            PaymentDetails paymentDetails;
            bool IsSucess = false;
            for (int i = 0; i < grvPaymentDetails.RowCount; i++)
            {
                if (Convert.ToInt32(grvPaymentDetails.GetRowCellValue(i, colPartyType)) != PartyTypeMaster.Expense)
                {
                    string paymentMasterId = Guid.NewGuid().ToString();
                    listPaymentDetails = new List<PaymentDetails>();
                    if (dtSlipDetail.Columns.Contains("Amount"))
                    {
                        DataView dbView = new DataView(dtSlipDetail);
                        dbView.RowFilter = "isnull(Amount,0)<>0 and PartyId='" + grvPaymentDetails.GetRowCellValue(i, colParty) + "'" +
                            " and RowId='" + grvPaymentDetails.GetRowCellValue(i, colRowId) + "'";
                        if (dbView.Count > 0)
                        {
                            foreach (DataRowView row in dbView)
                            {
                                paymentDetails = new PaymentDetails
                                {
                                    Id = Guid.NewGuid().ToString(),
                                    GroupId = groupId.ToString(),
                                    PaymentId = paymentMasterId,
                                    PurchaseId = row["PurchaseId"].ToString(),
                                    SlipNo = row["SlipNo"].ToString(),
                                    Amount = Convert.ToDecimal(row["Amount"]),
                                    CreatedBy = Guid.NewGuid().ToString(),
                                    CreatedDate = DateTime.Now,
                                    UpdatedBy = Common.LoginUserID.ToString(),
                                    UpdatedDate = DateTime.Now,
                                };
                                listPaymentDetails.Add(paymentDetails);
                            }
                        }
                    }

                    PaymentMaster paymentMaster = new PaymentMaster();
                    string fromPartyId = grvPaymentDetails.GetRowCellValue(i, colParty).ToString();
                    string amount = grvPaymentDetails.GetRowCellValue(i, colAmount).ToString();

                    paymentMaster.GroupId = groupId;
                    paymentMaster.Id = paymentMasterId;
                    paymentMaster.Amount = Convert.ToDecimal(amount);
                    paymentMaster.FromPartyId = fromPartyId;
                    paymentMaster.CreatedDate = DateTime.Now;
                    paymentMaster.UpdatedDate = DateTime.Now;
                    paymentMaster.PaymentDetails = listPaymentDetails;
                    paymentMasters.Add(paymentMaster);
                }
                else
                {
                    this.Cursor = Cursors.WaitCursor;
                    try
                    {
                        ExpenseDetails expenseDetails = new ExpenseDetails
                        {
                            Id = Guid.NewGuid().ToString(),
                            SrNo = Convert.ToInt32(txtSerialNo.Text),
                            BranchId = grvPaymentDetails.GetRowCellValue(i, colBranch).ToString(), //Common.LoginBranch,
                            CompanyId = lueCompany.EditValue.ToString(),
                            FinancialYearId = Common.LoginFinancialYear,
                            PartyId = grvPaymentDetails.GetRowCellValue(i, colParty).ToString(),
                            fromPartyId = lueLeadger.EditValue.ToString(),
                            Amount = float.Parse(grvPaymentDetails.GetRowCellValue(i, colAmount).ToString()),
                            IsDelete = false,
                            CrDrType = _paymentType,
                            Remarks = txtRemark.Text,
                            CreatedBy = Common.LoginUserID,
                            CreatedDate = DateTime.Now,
                            UpdatedBy = Common.LoginUserID,
                            UpdatedDate = DateTime.Now,
                            EntryDate = Convert.ToDateTime(dtDate.Text).ToString("yyyyMMdd")
                        };

                        string partyId = grvPaymentDetails.GetRowCellValue(i, colParty).ToString();
                        string fromparty = lueLeadger.EditValue.ToString();
                        decimal amt = decimal.Parse(grvPaymentDetails.GetRowCellValue(i, colAmount).ToString());

                        ExpenseMasterRepository expenseMasterRepository = new ExpenseMasterRepository();
                        var result = await expenseMasterRepository.AddExpenseAsync(expenseDetails);

                        IsSucess = true;
                    }
                    catch (Exception Ex)
                    {
                        IsSucess = false;
                    }
                }
            }

            if (paymentMasters.Count > 0)
            {
                GroupPaymentMaster groupPaymentMaster = new GroupPaymentMaster
                {
                    Id = groupId,
                    BillNo = Convert.ToInt32(txtSerialNo.Text),
                    BranchId = Common.LoginBranch,
                    CompanyId = lueCompany.EditValue.ToString(),
                    FinancialYearId = Common.LoginFinancialYear,
                    IsDelete = false,
                    Remarks = txtRemark.Text,
                    ToPartyId = lueLeadger.EditValue.ToString(),
                    CrDrType = _paymentType,
                    PaymentMasters = paymentMasters,
                    CreatedBy = Common.LoginUserID,
                    UpdatedBy = Common.LoginUserID,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    EntryDate = Convert.ToDateTime(dtDate.Text).ToString("yyyyMMdd")
                };

                var Result = await _paymentMaterRepository.AddPaymentAsync(groupPaymentMaster);

                if (Result != null)
                {
                    IsSucess = true;
                }
            }

            if (IsSucess)
            {
                Reset();
                MessageBox.Show(AppMessages.GetString(AppMessageID.SaveSuccessfully), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void Reset()
        {
            dtTime.EditValue = DateTime.Now;
            grdPaymentDetails.DataSource = null;
            txtRemark.Text = "";
            txtLedgerBalance.Text = "0";
            lueLeadger.EditValue = null;
            _selectedSrNo = 0;
            _selectedCompany = "";
            _selectedFinancialYear = "";
            btnSave.Text = AppMessages.GetString(AppMessageID.Save);
            await LoadLedgers(lueCompany.EditValue.ToString());
            LoadSeries(_paymentType);
            lueLeadger.Focus();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private async void lueCompany_EditValueChanged(object sender, EventArgs e)
        {
            //if (lueCompany.EditValue != null)
            //    await LoadLedgers(lueCompany.EditValue.ToString());
        }

        private void FrmPaymentEntry_KeyDown(object sender, KeyEventArgs e)
        {
            Common.MoveToNextControl(sender, e, this);
        }

        private async void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            try
            {
                if (_paymentType == 2 && _selectedSrNo > 0) return;
                if (_paymentType != -1)
                {
                    string RowId = grvPaymentDetails.GetRowCellValue(grvPaymentDetails.FocusedRowHandle, colRowId).ToString();
                    DataView dtView = new DataView(dtSlipDetail);
                    dtView.RowFilter = "PartyId='" + grvPaymentDetails.GetRowCellValue(grvPaymentDetails.FocusedRowHandle, colParty) + "'" +
                        "and (RowId='"+RowId+"' OR ISNULL(RowId,'') = '' OR RowId = '')";
                    //if (dtView.Count > 0)
                    {
                        DataRow[] dataRow = dtSlipDetail.Select("SlipNo=-1 and PartyId='" + grvPaymentDetails.GetRowCellValue(grvPaymentDetails.FocusedRowHandle, colParty) + "'" +
                            "and RowId='"+RowId+"'");
                        if (dataRow.Length == 0)
                        {
                            var PartyOpeningBalance = await _partyMasterRepository.GetPartyBalance(grvPaymentDetails.GetRowCellValue(grvPaymentDetails.FocusedRowHandle, colParty).ToString(), Common.LoginCompany, Common.LoginFinancialYear);

                            //for (int i = 0; i < dtView.ToTable().Rows.Count; i++)
                            //{
                            //    allSlipTotal += Convert.ToDecimal(dtView.ToTable().Rows[i].ItemArray[9]);
                            //}

                            decimal allSlipRemainingBalance = 0;

                            if (dtView.Count > 0)
                            {
                                allSlipRemainingBalance = Convert.ToDecimal(dtView.ToTable().Compute("SUM(RemainAmount)", string.Empty));

                                PartyOpeningBalance = PartyOpeningBalance - allSlipRemainingBalance;
                            }

                            dtSlipDetail.Rows.Add(0, DateTime.Now, grvPaymentDetails.GetRowCellValue(grvPaymentDetails.FocusedRowHandle, colParty),
                                "Opening Balance", "-1", lueCompany.EditValue, grvPaymentDetails.GetRowCellValue(grvPaymentDetails.FocusedRowHandle, colBranch),
                                Common.LoginFinancialYear, Common.LoginFinancialYearName,
                                PartyOpeningBalance, 0, 0, RowId);

                        }

                        DataRow[] dataRow1 = dtSlipDetail.Select("SlipNo=-2 and PartyId='" + grvPaymentDetails.GetRowCellValue(grvPaymentDetails.FocusedRowHandle, colParty) + "'" +
                            "and RowId='" + RowId + "'");
                        if (dataRow1.Length == 0)
                        {
                            dtSlipDetail.Rows.Add(0, DateTime.Now, grvPaymentDetails.GetRowCellValue(grvPaymentDetails.FocusedRowHandle, colParty),
                                "New Refrence", "-2", lueCompany.EditValue, grvPaymentDetails.GetRowCellValue(grvPaymentDetails.FocusedRowHandle, colBranch),
                                Common.LoginFinancialYear, Common.LoginFinancialYearName,
                                0, 0, 0, RowId);
                        }

                        dtView.Sort = "SlipNo ASC";

                        FrmPaymentSlipSelect frmPaymentSlipSelect = new FrmPaymentSlipSelect(dtView.ToTable());
                        if (grvPaymentDetails.GetRowCellValue(grvPaymentDetails.FocusedRowHandle, colAmount) != null)
                         {
                            frmPaymentSlipSelect.TotalAmount = Convert.ToDecimal(grvPaymentDetails.GetRowCellValue(grvPaymentDetails.FocusedRowHandle, colAmount).ToString());
                        }
                        else
                        {
                            frmPaymentSlipSelect.TotalAmount = 0;
                        }

                        if (grvPaymentDetails.GetRowCellValue(grvPaymentDetails.FocusedRowHandle, colAutoAdjustBillAmount) == null ||
                            string.IsNullOrEmpty(grvPaymentDetails.GetRowCellValue(grvPaymentDetails.FocusedRowHandle, colAutoAdjustBillAmount).ToString()))
                            frmPaymentSlipSelect.IsAutoAdjustBillAmount = false;
                        else
                            frmPaymentSlipSelect.IsAutoAdjustBillAmount = Convert.ToBoolean(grvPaymentDetails.GetRowCellValue(grvPaymentDetails.FocusedRowHandle, colAutoAdjustBillAmount));

                        if (frmPaymentSlipSelect.ShowDialog() == DialogResult.OK)
                        {
                            frmPaymentSlipSelect.BringToFront();
                            decimal a = Convert.ToDecimal(frmPaymentSlipSelect.dtSlipDetail.Compute("SUM(Amount)", string.Empty));
                            DataView dtView1 = new DataView(frmPaymentSlipSelect.dtSlipDetail);
                            //dtView1.RowFilter = "isnull(Amount,0)<>0";
                            if (dtView1.Count > 0)
                            {
                                foreach (DataRowView row in dtView1)
                                {
                                    if (!dtSlipDetail.Columns.Contains("Amount"))
                                        dtSlipDetail.Columns.Add("Amount", typeof(decimal));

                                    if (!dtSlipDetail.Columns.Contains("RowId"))
                                        dtSlipDetail.Columns.Add("RowId", typeof(string));

                                    DataView dtView2 = new DataView(dtSlipDetail);
                                    dtView2.RowFilter = "PartyId='" + row["PartyId"] + "' and SlipNo='" + row["SlipNo"] + "'" +
                                        " and (RowId='" + RowId + "' OR ISNULL(RowId,'') = '' OR RowId = '')";
                                    if (dtView2.Count > 0)
                                    {
                                        foreach (DataRowView subRow in dtView2)
                                        {
                                            if (row["RowId"].ToString() == RowId)
                                            {
                                                subRow["Amount"] = 0;
                                            }
                                        }
                                        dtView2[0].Row["Amount"] = row["Amount"];
                                        dtView2[0].Row["RowId"] = RowId;
                                    }
                                }
                            }
                            this.grvPaymentDetails.CellValueChanged -= new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvPaymentDetails_CellValueChanged);
                            grvPaymentDetails.SetRowCellValue(grvPaymentDetails.FocusedRowHandle, colAmount, a);
                            grvPaymentDetails.SetRowCellValue(grvPaymentDetails.FocusedRowHandle, colAutoAdjustBillAmount, frmPaymentSlipSelect.IsAutoAdjustBillAmount);
                            this.grvPaymentDetails.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvPaymentDetails_CellValueChanged);
                        }
                        //}
                        //else
                        //{
                        //    MessageBox.Show("No slips found for selected party.");
                        //    //grvPaymentDetails.FocusedRowHandle = grvPaymentDetails.FocusedRowHandle;
                        //    grvPaymentDetails.FocusedColumn = colParty;
                        //    return;
                        //}
                    }
                }
            }
            catch (Exception Ex)
            {
            }
        }

        private async void grvPaymentDetails_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colAmount && _paymentType != -1)
            {
                if (_paymentType == 2)
                    return;
                if (string.IsNullOrEmpty(PartyId))
                    return;

                if (grvPaymentDetails.GetRowCellValue(e.RowHandle, colPartyId).ToString() != "")
                {
                    string RowId = grvPaymentDetails.GetRowCellValue(grvPaymentDetails.FocusedRowHandle, colRowId).ToString();
                    DataView dtView = new DataView(dtSlipDetail);
                    dtView.RowFilter = "PartyId='" + PartyId + "'";

                    //if (dtView.Count > 0)
                    {
                        decimal Value = Convert.ToDecimal(e.Value);
                        //if (Value > 0)
                        {
                            if (!dtSlipDetail.Columns.Contains("Amount"))
                            {
                                DataColumn column = new DataColumn();
                                column.ColumnName = "Amount";
                                column.DataType = System.Type.GetType("System.Decimal");
                                column.DefaultValue = 0;
                                column.ReadOnly = false;

                                dtSlipDetail.Columns.Add(column);
                            }

                            if (!dtSlipDetail.Columns.Contains("RowId"))
                                dtSlipDetail.Columns.Add("RowId", typeof(string));

                            foreach (DataRowView row in dtView)
                            {
                                if (row["RowId"].ToString() == RowId)
                                {
                                    row["Amount"] = 0;
                                }
                            }


                            //DataRow[] dataRowTemp = dtSlipDetail.Select("PartyId='" + PartyId + "' and RowId='"+RowId+"'");
                            //if (dataRowTemp.Length > 0)
                            //{
                            //    DataView dataViewTemp = new DataView(dataRowTemp.CopyToDataTable());
                            //    decimal SlipAdjustedAmount = Convert.ToDecimal(dataViewTemp.ToTable().Compute("SUM(Amount)", string.Empty));
                            //    decimal RowAmount = 0;
                            //    if (grvPaymentDetails.GetRowCellValue(grvPaymentDetails.FocusedRowHandle, colAmount) != null)
                            //    {
                            //        RowAmount = Convert.ToDecimal(grvPaymentDetails.GetRowCellValue(grvPaymentDetails.FocusedRowHandle, colAmount));
                            //    }
                            //    if (SlipAdjustedAmount > RowAmount)
                            //    {
                            //        MessageBox.Show("Amount should not be less then adjusted slip amount, please remove the adjusted Slip's if you wants to reduce amount. .");
                            //        this.grvPaymentDetails.CellValueChanged -= new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvPaymentDetails_CellValueChanged);
                            //        grvPaymentDetails.SetRowCellValue(e.RowHandle, colAmount, null);
                            //        this.grvPaymentDetails.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvPaymentDetails_CellValueChanged);
                            //        return;
                            //    }
                            //}

                            DataRow[] dataRow = dtSlipDetail.Select("SlipNo=-1 and PartyId='" + PartyId + "' and RowId='" + RowId + "'");
                            if (dataRow.Length == 0)
                            {
                                var PartyOpeningBalance = await _partyMasterRepository.GetPartyBalance(PartyId, Common.LoginCompany, Common.LoginFinancialYear);

                                //for (int i = 0; i < dtView.ToTable().Rows.Count; i++)
                                //{
                                //    allSlipTotal += Convert.ToDecimal(dtView.ToTable().Rows[i].ItemArray[9]);
                                //}

                                decimal allSlipRemainingBalance = 0;

                                if (dtView.Count > 0)
                                {
                                    allSlipRemainingBalance = Convert.ToDecimal(dtView.ToTable().Compute("SUM(RemainAmount)", string.Empty));

                                    PartyOpeningBalance = PartyOpeningBalance - allSlipRemainingBalance;
                                }

                                dtSlipDetail.Rows.Add(0, DateTime.Now, PartyId,
                                    "Opening Balance", "-1", lueCompany.EditValue, grvPaymentDetails.GetRowCellValue(e.RowHandle, colBranch),
                                    Common.LoginFinancialYear, Common.LoginFinancialYearName,
                                    PartyOpeningBalance, PartyOpeningBalance, 0, RowId);
                            }

                            DataRow[] dataRow1 = dtSlipDetail.Select("SlipNo=-2 and PartyId='" + PartyId + "' and RowId='" + RowId + "'");
                            if (dataRow1.Length == 0)
                            {
                                dtSlipDetail.Rows.Add(0, DateTime.Now, PartyId,
                                    "New Refrence", "-2", lueCompany.EditValue, grvPaymentDetails.GetRowCellValue(e.RowHandle, colBranch),
                                    Common.LoginFinancialYear, Common.LoginFinancialYearName,
                                    0, 0, 0, RowId);
                            }
                            //else
                            //{
                            //    dataRow[0]["Amount"] = Value;
                            //}
                        }
                    }
                }
            }
            else if (e.Column == colParty)
            {
                try
                {
                    string RowId = Guid.NewGuid().ToString();
                    PartyId = ((PartyMaster)repoParty.GetDataSourceRowByKeyValue(e.Value)).Id;
                    grvPaymentDetails.SetRowCellValue(e.RowHandle, colPartyId, ((PartyMaster)repoParty.GetDataSourceRowByKeyValue(e.Value)).Id);
                    grvPaymentDetails.SetRowCellValue(e.RowHandle, colPartyType, ((PartyMaster)repoParty.GetDataSourceRowByKeyValue(e.Value)).Type);
                    grvPaymentDetails.SetRowCellValue(e.RowHandle, colRowId, RowId);
                    if (((PartyMaster)repoParty.GetDataSourceRowByKeyValue(e.Value)).Type == PartyTypeMaster.Expense)
                    {
                        colBranch.Visible = true;
                    }
                    else
                    {
                        colBranch.Visible = false;
                    }
                }
                catch
                {

                }
            }
        }

        private async void NewEntry(object sender, KeyEventArgs e)
        {
            string ControlName = ((DevExpress.XtraEditors.LookUpEdit)sender).Name;
            if (e.Control && e.KeyCode == Keys.N)
            {
                if (ControlName == lueLeadger.Name)
                {
                    Master.FrmPartyMaster frmPartyMaster = new Master.FrmPartyMaster();
                    frmPartyMaster.IsSilentEntry = true;
                    frmPartyMaster.IsCashBankAccount = true;
                    //frmPartyMaster.LedgerType = PartyTypeMaster.Buyer;
                    if (frmPartyMaster.ShowDialog() == DialogResult.OK)
                    {
                        await LoadLedgers(lueCompany.EditValue.ToString());
                        lueLeadger.EditValue = frmPartyMaster.CreatedLedgerID;
                    }
                }
            }
        }

        private async void repoParty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                Master.FrmPartyMaster frmPartyMaster = new Master.FrmPartyMaster();
                frmPartyMaster.IsSilentEntry = true;
                if (_paymentType == -1)
                    frmPartyMaster.IsCashBankAccount = true;
                if (frmPartyMaster.ShowDialog() == DialogResult.OK)
                {
                    await LoadLedgers(lueCompany.EditValue.ToString());
                    grvPaymentDetails.SetFocusedRowCellValue(colParty, frmPartyMaster.CreatedLedgerID.ToString());
                }
            }
        }

        private void grvPaymentDetails_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            //if (Convert.ToInt32(grvPaymentDetails.GetRowCellValue(e.RowHandle, colPartyType)) != PartyTypeMaster.Expense)
            //{
            //    if (_paymentType != -1 && MessageBox.Show("Do you want view slip adjusted amount...???", "confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            //    {
            //        repositoryItemButtonEdit1_Click(null, null);
            //    }
            //}
        }

        private void repoAdjustAmt_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(grvPaymentDetails.GetRowCellValue(grvPaymentDetails.FocusedRowHandle, colPartyType)) != PartyTypeMaster.Expense)
            {
                if (_paymentType != -1 && MessageBox.Show("Do you want view slip adjusted amount...???", "confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    repositoryItemButtonEdit1_Click(null, null);
                }
            }
        }

        private void repoAdjustAmt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Convert.ToInt32(grvPaymentDetails.GetRowCellValue(grvPaymentDetails.FocusedRowHandle, colPartyType)) != PartyTypeMaster.Expense)
                {
                    if (_paymentType != -1 && MessageBox.Show("Do you want view slip adjusted amount...???", "confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                    {
                        repositoryItemButtonEdit1_Click(null, null);
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dtTime.EditValue = DateTime.Now;
        }
    }
}