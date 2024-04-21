using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EFCore.SQL.Interface;
using EFCore.SQL.Repository;
using Repository.Entities;

namespace DiamondTrading.Utility
{
    public partial class FrmLoanEntry : DevExpress.XtraEditors.XtraForm
    {
        PartyMasterRepository _partyMasterRepository;
        LoanMasterRepository _loanMasterRepository;
        CompanyMasterRepository _companyMasterRepository;
        private string _selectedLoanId;
        private readonly List<LoanMaster> _loanMasters;
        private LoanMaster _selectedLoanToEdit;


        public FrmLoanEntry()
        {
            InitializeComponent();
            _partyMasterRepository = new PartyMasterRepository();
            _loanMasterRepository = new LoanMasterRepository();
            _companyMasterRepository = new CompanyMasterRepository();
        }
        public FrmLoanEntry(string selectedLoanId)
        {
            InitializeComponent();
            _partyMasterRepository = new PartyMasterRepository();
            _loanMasterRepository = new LoanMasterRepository();
            _companyMasterRepository = new CompanyMasterRepository();
            _selectedLoanId = selectedLoanId;
            _selectedLoanToEdit = _loanMasterRepository.GetLoanAsync(selectedLoanId, Common.LoginCompany, Common.LoginFinancialYear);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void FrmLoanEntry_Load(object sender, EventArgs e)
        {
            dtDate.EditValue = DateTime.Now;
            dtTime.EditValue = DateTime.Now;

            await LoadParty();

            await LoadCompany();

            await GetMaxSrNo();

            await LoadCashank();

            lueReceiveFrom.Properties.DataSource = Common.GetLoanType();
            lueReceiveFrom.Properties.DisplayMember = "Name";
            lueReceiveFrom.Properties.ValueMember = "Id";

            lueDuration.Properties.DataSource = Common.GetLoanDuration();
            lueDuration.Properties.DisplayMember = "Name";
            lueDuration.Properties.ValueMember = "Id";

            if (string.IsNullOrEmpty(_selectedLoanId) == false)
            {
                if(_selectedLoanToEdit != null)
                {
                    btnSave.Text = AppMessages.GetString(AppMessageID.Update);
                    lueParty.EditValue = _selectedLoanToEdit.PartyId;                    
                    txtAmount.Text = _selectedLoanToEdit.Amount.ToString();
                    lueCompany.EditValue = _selectedLoanToEdit.CompanyId;
                    lueDuration.EditValue = _selectedLoanToEdit.DuratonType;
                    dateEnd.DateTime = Convert.ToDateTime(_selectedLoanToEdit.EndDate);
                    dateStart.DateTime = Convert.ToDateTime(_selectedLoanToEdit.StartDate);
                    txtInterestRate.Text = _selectedLoanToEdit.InterestRate.ToString();
                    lueReceiveFrom.EditValue = _selectedLoanToEdit.LoanType;
                    txtNetAmount.Text = _selectedLoanToEdit.NetAmount.ToString();
                    txtRemark.Text = _selectedLoanToEdit.Remarks;
                    lueCashBank.EditValue = _selectedLoanToEdit.CashBankPartyId.ToString();
                    txtTotalInterest.Text = _selectedLoanToEdit.TotalInterest.ToString();
                    dtDate.EditValue = DateTime.ParseExact(_selectedLoanToEdit.EntryDate, "yyyyMMdd", CultureInfo.InvariantCulture);
                    dtTime.EditValue = DateTime.ParseExact(_selectedLoanToEdit.EntryTime, "hh:mm:ss ttt", CultureInfo.InvariantCulture);
                    txtSerialNo.Text = _selectedLoanToEdit.Sr.ToString();
                } else
                {
                    MessageBox.Show("You can not edit this loan entry due to some database issue. Please contact software developers.", "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async Task GetMaxSrNo()
        {
            var SrNo = await _loanMasterRepository.GetMaxSrNo(Common.LoginCompany.ToString());
            txtSerialNo.Text = SrNo.ToString();
        }

        private async Task LoadCompany()
        {
            var result = await _companyMasterRepository.GetUserCompanyMappingAsync(Common.LoginUserID);
            lueCompany.Properties.DataSource = result;
            lueCompany.Properties.DisplayMember = "Name";
            lueCompany.Properties.ValueMember = "Id";

            lueCompany.EditValue = Common.LoginCompany;
        }

        private async Task LoadCashank()
        {
            var result = await _partyMasterRepository.GetAllPartyAsync(Common.LoginCompany, new int[] { 4, 5 });
            lueCashBank.Properties.DataSource = result;
            lueCashBank.Properties.DisplayMember = "Name";
            lueCashBank.Properties.ValueMember = "Id";

            lueCashBank.EditValue = Common.LoginCompany;
        }

        private async Task LoadParty()
        {
            var result = await _partyMasterRepository.GetAllPartyAsync(Common.LoginCompany, 13);
            lueParty.Properties.DataSource = result;
            lueParty.Properties.DisplayMember = "Name";
            lueParty.Properties.ValueMember = "Id";
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            bool IsSucess = false;
            try
            {
                if (btnSave.Text == AppMessages.GetString(AppMessageID.Save))
                {
                    LoanMaster loanMaster = new LoanMaster()
                    {
                        Id = Guid.NewGuid().ToString(),
                        PartyId = lueParty.EditValue.ToString(),
                        CashBankPartyId = lueCashBank.EditValue.ToString(),
                        Amount = decimal.Parse(txtAmount.Text),
                        CompanyId = lueCompany.EditValue.ToString(),
                        CreatedBy = Common.LoginCompany.ToString(),
                        CreatedDate = DateTime.Now,
                        DuratonType = (int)lueDuration.EditValue,
                        EndDate = dateEnd.DateTime,
                        StartDate = dateStart.DateTime,
                        InterestRate = decimal.Parse(txtInterestRate.Text),
                        IsDelete = false,
                        LoanType = int.Parse(lueReceiveFrom.EditValue.ToString()),
                        NetAmount = decimal.Parse(txtNetAmount.Text),
                        Remarks = txtRemark.Text,
                        TotalInterest = decimal.Parse(txtTotalInterest.Text),
                        UpdatedBy = Common.LoginUserID,
                        UpdatedDate = DateTime.Now,
                        EntryDate = Convert.ToDateTime(dtDate.Text).ToString("yyyyMMdd"),
                        EntryTime = Convert.ToDateTime(dtTime.Text).ToString("hh:mm:ss ttt"),
                        FinancialYearId = Common.LoginFinancialYear
                    };

                    await _loanMasterRepository.AddLoanAsync(loanMaster);
                    IsSucess = true;
                }
                else
                {                    
                    _selectedLoanToEdit.PartyId = lueParty.EditValue.ToString();
                    _selectedLoanToEdit.CashBankPartyId = lueCashBank.EditValue.ToString();
                    _selectedLoanToEdit.Amount = Convert.ToDecimal(txtAmount.Text);
                    _selectedLoanToEdit.CompanyId = lueCompany.EditValue.ToString();
                    _selectedLoanToEdit.DuratonType = (int)lueDuration.EditValue;
                    _selectedLoanToEdit.EndDate = dateEnd.DateTime;
                    _selectedLoanToEdit.StartDate = Convert.ToDateTime(dateStart.EditValue);
                    _selectedLoanToEdit.InterestRate = Convert.ToDecimal(txtInterestRate.Text);
                    _selectedLoanToEdit.LoanType = (int)lueReceiveFrom.EditValue;
                    _selectedLoanToEdit.NetAmount = Convert.ToDecimal(txtNetAmount.Text);
                    _selectedLoanToEdit.Remarks  = txtRemark.Text;
                    _selectedLoanToEdit.TotalInterest = Convert.ToDecimal(txtTotalInterest.Text);
                    _selectedLoanToEdit.EntryDate = Convert.ToDateTime(dtDate.EditValue).ToString("yyyyMMdd");
                    _selectedLoanToEdit.EntryTime = Convert.ToDateTime(dtTime.EditValue).ToString("hh:mm:ss ttt");
                    _selectedLoanToEdit.FinancialYearId = Common.LoginFinancialYear;
                    _selectedLoanToEdit.UpdatedBy = Common.LoginUserID;
                    _selectedLoanToEdit.UpdatedDate = DateTime.Now;

                    await _loanMasterRepository.UpdateLoanAsync(_selectedLoanToEdit);
                    IsSucess = true;
                    btnSave.Text = AppMessages.GetString(AppMessageID.Save);
                }
            }
            catch (Exception Ex)
            {
                IsSucess = false;
                MessageBox.Show("Error : " + Ex.Message.ToString(), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            if (IsSucess)
            {
                MessageBox.Show(AppMessages.GetString(AppMessageID.SaveSuccessfully), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetForm();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void ResetForm()
        {
            txtAmount.Text = "";
            txtInterestRate.Text = "";
            txtNetAmount.Text = "";
            txtTotalInterest.Text = "";
            txtRemark.Text = "";
            lueReceiveFrom.EditValue = null;
            lueParty.EditValue = null;
            lueCashBank.EditValue = null;
            lueDuration.EditValue = null;
            dateStart.EditValue = null;
            dateEnd.EditValue = null;
            lueReceiveFrom.Focus();
        }

        private void txtInterestRate_EditValueChanged(object sender, EventArgs e)
        {
            CalculateInterest();
        }

        private void CalculateInterest()
        {
            string amount = txtAmount.Text == "" ? "0" : txtAmount.Text;
            string interestRate = txtInterestRate.Text == "" ? "0" : txtInterestRate.Text;

            DateTime startDate = dateStart.DateTime;
            DateTime endDate = dateEnd.DateTime;

            TimeSpan difference = endDate - startDate;

            decimal interestAmount = (Convert.ToDecimal(amount) * Convert.ToDecimal(interestRate)) / 100;

            if (Convert.ToInt32(lueDuration.EditValue) == 1)
            {
                txtTotalInterest.Text = (Convert.ToDouble(interestAmount) * difference.TotalDays).ToString();
                txtNetAmount.Text = Math.Round(Convert.ToDecimal(amount) + Convert.ToDecimal(txtTotalInterest.Text)).ToString();
            }
            else if (Convert.ToInt32(lueDuration.EditValue) == 2 || Convert.ToInt32(lueDuration.EditValue) == 3 || Convert.ToInt32(lueDuration.EditValue) == 4 || Convert.ToInt32(lueDuration.EditValue) == 5)
            {
                txtTotalInterest.Text = (Convert.ToDouble(interestAmount) * (Math.Abs((startDate.Month - endDate.Month) + 12 * (startDate.Year - endDate.Year)))).ToString();
                txtNetAmount.Text = Math.Round(Convert.ToDecimal(amount) + Convert.ToDecimal(txtTotalInterest.Text)).ToString();
            }
        }

        private void lueDuration_EditValueChanged(object sender, EventArgs e)
        {
            int lueDurations = Convert.ToInt32(lueDuration.EditValue);

            if (lueDurations == 1) //Daily
            {
                dateStart.DateTime = DateTime.Now;
                dateEnd.DateTime = DateTime.Now;
            }
            else if (lueDurations == 2) //Monthly
            {
                dateStart.DateTime = DateTime.Now;
                dateEnd.DateTime = new DateTime(DateTime.Now.Ticks).AddMonths(1);
            }
            else if (lueDurations == 3) // 3 Month
            {
                dateStart.DateTime = DateTime.Now;
                dateEnd.DateTime = new DateTime(DateTime.Now.Ticks).AddMonths(3);
            }
            else if (lueDurations == 4) //6 Month 
            {
                dateStart.DateTime = DateTime.Now;
                dateEnd.DateTime = new DateTime(DateTime.Now.Ticks).AddMonths(6);
            }
            else if (lueDurations == 5) //12 Month
            {
                dateStart.DateTime = DateTime.Now;
                dateEnd.DateTime = new DateTime(DateTime.Now.Ticks).AddMonths(12);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void dateStart_EditValueChanged(object sender, EventArgs e)
        {
            CalculateInterest();
        }

        private void dateEnd_EditValueChanged(object sender, EventArgs e)
        {
            CalculateInterest();
        }

        private void txtAmount_EditValueChanged(object sender, EventArgs e)
        {
            CalculateInterest();
        }

        private void FrmLoanEntry_KeyDown(object sender, KeyEventArgs e)
        {
            Common.MoveToNextControl(sender, e, this);
        }

        private async void NewEntry(object sender, KeyEventArgs e)
        {
            string ControlName = ((DevExpress.XtraEditors.LookUpEdit)sender).Name;
            if (e.Control && e.KeyCode == Keys.N)
            {
                if (ControlName == lueParty.Name)
                {
                    Master.FrmPartyMaster frmPartyMaster = new Master.FrmPartyMaster();
                    frmPartyMaster.IsSilentEntry = true;
                    frmPartyMaster.LedgerType = PartyTypeMaster.Loan;
                    if (frmPartyMaster.ShowDialog() == DialogResult.OK)
                    {
                        await LoadParty();
                        lueParty.EditValue = frmPartyMaster.CreatedLedgerID;
                    }
                }
            }
        }
    }
}