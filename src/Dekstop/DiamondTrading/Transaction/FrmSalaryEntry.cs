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
    public partial class FrmSalaryEntry : DevExpress.XtraEditors.XtraForm
    {
        private readonly CompanyMasterRepository _companyMasterRepository;
        private readonly SalaryMasterRepository _SalaryMasterRepository;
        private readonly PartyMasterRepository _partyMasterRepository;

        public FrmSalaryEntry()
        {
            InitializeComponent();
            _companyMasterRepository = new CompanyMasterRepository();
            _SalaryMasterRepository = new SalaryMasterRepository();
            _partyMasterRepository = new PartyMasterRepository();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmSalaryEntry_KeyDown(object sender, KeyEventArgs e)
        {
            Common.MoveToNextControl(sender, e, this);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        private async void FrmSalaryEntry_Load(object sender, EventArgs e)
        {
            dtDate.EditValue = DateTime.Now;
            dtTime.EditValue = DateTime.Now;
            await LoadCompany();
            LoadSeries();
            await LoadLedgers(lueCompany.EditValue.ToString());

            DataTable dtMonth = new DataTable();
            dtMonth.Columns.Add("Month");
            dtMonth.Columns.Add("Id");

            dtMonth.Rows.Add("January",1);
            dtMonth.Rows.Add("February",2);
            dtMonth.Rows.Add("March",3);
            dtMonth.Rows.Add("April",4);
            dtMonth.Rows.Add("May",5);
            dtMonth.Rows.Add("June",6);
            dtMonth.Rows.Add("July",7);
            dtMonth.Rows.Add("August",8);
            dtMonth.Rows.Add("September",9);
            dtMonth.Rows.Add("October",10);
            dtMonth.Rows.Add("November",11);
            dtMonth.Rows.Add("December",12);

            lueMonth.Properties.DataSource = dtMonth;
            lueMonth.Properties.DisplayMember = "Month";
            lueMonth.Properties.ValueMember = "Id";

            lueMonth.EditValue = DateTime.Now.ToString("MM");
        }

        private async Task LoadCompany()
        {
            var result = await _companyMasterRepository.GetAllCompanyAsync();
            lueCompany.Properties.DataSource = result;
            lueCompany.Properties.DisplayMember = "Name";
            lueCompany.Properties.ValueMember = "Id";
            lueCompany.EditValue = Common.LoginCompany;
        }

        private async void LoadSeries()
        {
            grdParticularsDetails.DataSource = GetDTColumnsForSalaryDetails();
            var result = await _SalaryMasterRepository.GetMaxSrNoAsync(lueCompany.EditValue.ToString(), Common.LoginFinancialYear);
            txtSerialNo.Text = result.ToString();
        }

        private async Task LoadLedgers(string companyId)
        {
            var result = await _partyMasterRepository.GetAllPartyAsync(companyId);
            lueLeadger.Properties.DataSource = result.Where(x => x.Type == PartyTypeMaster.Cash || x.Type == PartyTypeMaster.Bank);
            lueLeadger.Properties.DisplayMember = "Name";
            lueLeadger.Properties.ValueMember = "Id";

            repoEmployee.DataSource = result.Where(x => x.Type != PartyTypeMaster.Employee);
            repoEmployee.DisplayMember = "Name";
            repoEmployee.ValueMember = "Id";
        }

        private static DataTable GetDTColumnsForSalaryDetails()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("SalaryAmount");
            dt.Columns.Add("WorkingDays");
            dt.Columns.Add("WorkedDays");
            dt.Columns.Add("OTHours");
            dt.Columns.Add("OTRateHr");
            dt.Columns.Add("AdvanceAmount");
            dt.Columns.Add("Bonus");
            dt.Columns.Add("Round");            
            dt.Columns.Add("Total");
            return dt;
        }

        private void lueMonth_EditValueChanged(object sender, EventArgs e)
        {
            if (lueMonth.EditValue != null)
            {
                txtWorkingDays.Text = DateTime.DaysInMonth(Convert.ToDateTime(dtDate.EditValue).Year, Convert.ToInt32(lueMonth.EditValue)).ToString();
            }
        }

        private void grvParticularsDetails_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colOTHours || e.Column == colOTRate || e.Column == colBonus || e.Column == gridColumnAdvanceAmount)
            {
                decimal SalaryAmount = 0;
                if(!string.IsNullOrWhiteSpace(grvParticularsDetails.GetRowCellValue(e.RowHandle, colSalaryAmount).ToString()))
                    SalaryAmount = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(e.RowHandle, colSalaryAmount).ToString());
                decimal OTHours = 0;
                if (!string.IsNullOrWhiteSpace(grvParticularsDetails.GetRowCellValue(e.RowHandle, colOTHours).ToString()))
                    OTHours = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(e.RowHandle, colOTHours).ToString());
                decimal OTRate = 0;
                if (!string.IsNullOrWhiteSpace(grvParticularsDetails.GetRowCellValue(e.RowHandle, colOTRate).ToString()))
                    OTRate = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(e.RowHandle, colOTRate).ToString());
                decimal Bonus = 0;
                if (!string.IsNullOrWhiteSpace(grvParticularsDetails.GetRowCellValue(e.RowHandle, colBonus).ToString()))
                    Bonus = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(e.RowHandle, colBonus).ToString());

                decimal workingDays = 0, workedDays = 0, advanceAmount = 0;

                if (!string.IsNullOrWhiteSpace(grvParticularsDetails.GetRowCellValue(e.RowHandle, gridColumnWorkingDays).ToString()))
                    workingDays = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(e.RowHandle, gridColumnWorkingDays).ToString());

                if (!string.IsNullOrWhiteSpace(grvParticularsDetails.GetRowCellValue(e.RowHandle, gridColumnWorkedDays).ToString()))
                    workedDays = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(e.RowHandle, gridColumnWorkedDays).ToString());

                if (!string.IsNullOrWhiteSpace(grvParticularsDetails.GetRowCellValue(e.RowHandle, gridColumnAdvanceAmount).ToString()))
                    advanceAmount = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(e.RowHandle, gridColumnAdvanceAmount).ToString());

                CalculateTotal(SalaryAmount, OTHours,OTRate,Bonus, e.RowHandle, workingDays, workedDays, advanceAmount);    
            }
        }

        private void CalculateTotal(decimal SalaryAmount, decimal OTHours, decimal OTRate, decimal Bonus, int GridRowIndex, decimal workingdays, decimal workeddays, decimal advanceAmount)
        {
            decimal perdaySal = (SalaryAmount / workingdays);

            decimal Total = (perdaySal * workeddays) + (OTHours * OTRate) + Bonus + advanceAmount;
            decimal RoundUp = Total - Math.Round(Total);
            grvParticularsDetails.SetRowCellValue(GridRowIndex, colRound, RoundUp.ToString());
            grvParticularsDetails.SetRowCellValue(GridRowIndex, colTotal, Total.ToString());
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (!CheckValidation())
                    return;

                bool IsSucess = false;

                string SalaryId = Guid.NewGuid().ToString();

                SalaryMaster salaryMaster = new SalaryMaster();
                List<SalaryDetail> salaryDetailList = new List<SalaryDetail>();
                SalaryDetail salaryDetail;
                for (int i = 0; i < grvParticularsDetails.RowCount; i++)
                {
                    salaryDetail = new SalaryDetail();
                    salaryDetail.Id = Guid.NewGuid().ToString();
                    salaryDetail.SalaryMasterId = SalaryId;
                    salaryDetail.ToPartyId = grvParticularsDetails.GetRowCellValue(i, colName).ToString();
                    salaryDetail.WorkingDays = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(i, gridColumnWorkingDays).ToString());
                    salaryDetail.WorkedDays = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(i, gridColumnWorkedDays).ToString());

                    salaryDetail.OverTimeHrs = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(i, colOTHours).ToString());
                    salaryDetail.OverTimeRateHrs = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(i, colOTRate).ToString());
                    salaryDetail.AdvanceAmount = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(i, gridColumnAdvanceAmount).ToString());
                    salaryDetail.BonusAmount = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(i, colBonus).ToString());
                    salaryDetail.RoundOfAmount = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(i, colRound).ToString());

                    salaryDetail.TotalAmount = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(i, colTotal).ToString());

                    salaryDetailList.Insert(i, salaryDetail);
                }

                salaryMaster.CompanyId = lueCompany.EditValue.ToString();
                salaryMaster.BranchId = Common.LoginBranch;
                salaryMaster.FinancialYearId = Common.LoginFinancialYear;
                salaryMaster.FromPartyId = lueLeadger.EditValue.ToString();
                salaryMaster.SalaryMonth = Convert.ToInt32(lueMonth.EditValue.ToString());
                salaryMaster.SalaryMonthDateTime = Convert.ToDateTime(dtDate.Text);
                salaryMaster.MonthDays = Convert.ToInt32(txtWorkingDays.Text);
                salaryMaster.Holidays = 0;
                salaryMaster.Remarks = txtRemark.Text;                
                salaryMaster.CreatedDate = DateTime.Now;
                salaryMaster.UpdatedDate = DateTime.Now;
                salaryMaster.CreatedBy = Common.LoginUserID;
                salaryMaster.UpdatedBy = Common.LoginUserID;
                salaryMaster.SalaryDetails = salaryDetailList;

                var Result = await _SalaryMasterRepository.AddSalary(salaryMaster);
                if (Result != null)
                {
                    IsSucess = true;
                }

                if (IsSucess)
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

        public async void Reset()
        {
            dtTime.EditValue = DateTime.Now;
            await LoadCompany();
            LoadSeries();
            await LoadLedgers(lueCompany.EditValue.ToString());

            lueMonth.EditValue = DateTime.Now.ToString("MM");
            txtRemark.Text = "";
        }

        private bool CheckValidation()
        {
            if (lueCompany.EditValue == null)
            {
                MessageBox.Show("Please select Company", "Salary Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lueCompany.Focus();
                return false;
            }
            else if (lueLeadger.EditValue == null)
            {
                MessageBox.Show("Please select ledger", "Salary Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lueLeadger.Focus();
                return false;
            }
            else if (lueMonth.EditValue == null)
            {
                MessageBox.Show("Please select salary month", "Salary Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lueMonth.Focus();
                return false;
            }
            else if (txtWorkingDays.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please enter working days", "Salary Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtWorkingDays.Focus();
                return false;
            }
            else if (grvParticularsDetails.RowCount == 0)
            {
                MessageBox.Show("Please enter employee salary details", "Salary Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                grvParticularsDetails.Focus();
                return false;
            }

            return true;
        }
    }
}