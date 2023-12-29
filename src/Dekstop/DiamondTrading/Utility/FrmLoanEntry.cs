using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using EFCore.SQL.Repository;
using Repository.Entities;

namespace DiamondTrading.Utility
{
    public partial class FrmLoanEntry : DevExpress.XtraEditors.XtraForm
    {
        PartyMasterRepository _partyMasterRepository;
        LoanMasterRepository _loanMasterRepository;
        CompanyMasterRepository _companyMasterRepository;


        public FrmLoanEntry()
        {
            InitializeComponent();
            _partyMasterRepository = new PartyMasterRepository();
            _loanMasterRepository = new LoanMasterRepository();
            _companyMasterRepository = new CompanyMasterRepository();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmLoanEntry_Load(object sender, EventArgs e)
        {
            dtDate.EditValue = DateTime.Now;
            dtTime.EditValue = DateTime.Now;

            _ = LoadParty();

            _ = LoadCompany();

            _ = GetMaxSrNo();

            _ = LoadCashank();

            lueReceiveFrom.Properties.DataSource = Common.GetLoanType();
            lueReceiveFrom.Properties.DisplayMember = "Name";
            lueReceiveFrom.Properties.ValueMember = "Id";

            lueDuration.Properties.DataSource = Common.GetLoanDuration();
            lueDuration.Properties.DisplayMember = "Name";
            lueDuration.Properties.ValueMember = "Id";
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
                    StartDate  = dateStart.DateTime,
                    InterestRate = decimal.Parse(txtInterestRate.Text),
                    IsDelete = false,
                    LoanType = int.Parse(lueReceiveFrom.EditValue.ToString()),
                    NetAmount = decimal.Parse(txtNetAmount.Text),
                    Remarks = txtRemark.Text,
                    TotalInterest = decimal.Parse(txtTotalInterest.Text),
                    UpdatedBy = Common.LoginUserID,
                    UpdatedDate = DateTime.Now
                };

                await _loanMasterRepository.AddLoanAsync(loanMaster);
                IsSucess = true;
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
            }
        }

        private void ResetForm()
        {
            txtAmount.Text = "";
            txtInterestRate.Text = "";
            txtNetAmount.Text = "";
            txtTotalInterest.Text = "";
            txtRemark.Text = "";
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
            int lueDurations = Convert.ToInt32(lueDuration.EditValue.ToString());

            if(lueDurations == 1) //Daily
            {
                dateStart.DateTime = DateTime.Now;
                dateEnd.DateTime = DateTime.Now;
            }
            else if(lueDurations == 2) //Monthly
            {
                dateStart.DateTime = DateTime.Now;
                dateEnd.DateTime = new DateTime(DateTime.Now.Ticks).AddMonths(1);
            } 
            else if(lueDurations == 3) // 3 Month
            {
                dateStart.DateTime = DateTime.Now;
                dateEnd.DateTime = new DateTime(DateTime.Now.Ticks).AddMonths(3);
            }
            else if(lueDurations == 4) //6 Month 
            {
                dateStart.DateTime = DateTime.Now;
                dateEnd.DateTime = new DateTime(DateTime.Now.Ticks).AddMonths(6);
            }
            else if(lueDurations == 5) //12 Month
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