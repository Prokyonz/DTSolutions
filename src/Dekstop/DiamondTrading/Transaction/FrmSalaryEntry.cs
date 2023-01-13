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
            Reset();
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
            //lueLeadger.Properties.DataSource = result.Where(x => x.Type == PartyTypeMaster.Cash || x.Type == PartyTypeMaster.Bank);
            //lueLeadger.Properties.DisplayMember = "Name";
            //lueLeadger.Properties.ValueMember = "Id";

            repoEmployee.DataSource = result.Where(x => x.Type == PartyTypeMaster.Employee && x.SubType == PartyTypeMaster.Salaried);
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
            dt.Columns.Add("OTMinusHours");
            dt.Columns.Add("OTMinusRate");
            dt.Columns.Add("OTMinusAmount");
            dt.Columns.Add("OTPlusHours");
            dt.Columns.Add("OTPlusRate");
            dt.Columns.Add("OTPlusAmount");
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
            if(e.Column == colName)
            {
                grvParticularsDetails.CellValueChanged -= new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvParticularsDetails_CellValueChanged);
                grvParticularsDetails.SetRowCellValue(e.RowHandle, colSalaryAmount, ((PartyMaster)repoEmployee.GetDataSourceRowByKeyValue(e.Value)).Salary);
                grvParticularsDetails.SetRowCellValue(e.RowHandle, colOTMinusHours, 0);
                grvParticularsDetails.SetRowCellValue(e.RowHandle, colOTPlusHours, 0);

                grvParticularsDetails.SetRowCellValue(e.RowHandle, colOTMinusRate, Common.SalaryMinusOTRatePerHour);
                grvParticularsDetails.SetRowCellValue(e.RowHandle, colOTPlusRate, Common.SalaryPlusOTRatePerHour);

                grvParticularsDetails.SetRowCellValue(e.RowHandle, colRound, 0);
                grvParticularsDetails.SetRowCellValue(e.RowHandle, colTotal, 0);
                grvParticularsDetails.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvParticularsDetails_CellValueChanged);
            }
            else if (e.Column == gridColumnWorkedDays || e.Column == colOTMinusHours || e.Column == colOTMinusRate || e.Column == colOTPlusHours || e.Column == colOTPlusRate || e.Column == colBonus || e.Column == gridColumnAdvanceAmount)
            {
                decimal workingDays = 0, workedDays = 0, advanceAmount = 0;

                if (!string.IsNullOrWhiteSpace(txtWorkingDays.Text))
                    workingDays = Convert.ToDecimal(txtWorkingDays.Text);

                if (Common.SalaryTotalDayHours < 0)
                    Common.SalaryTotalDayHours = 10.5m;

                decimal SalaryAmount = 0;
                if(!string.IsNullOrWhiteSpace(grvParticularsDetails.GetRowCellValue(e.RowHandle, colSalaryAmount).ToString()))
                    SalaryAmount = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(e.RowHandle, colSalaryAmount).ToString());
                decimal OTMinusHours = 0;
                if (!string.IsNullOrWhiteSpace(grvParticularsDetails.GetRowCellValue(e.RowHandle, colOTMinusHours).ToString()))
                    OTMinusHours = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(e.RowHandle, colOTMinusHours).ToString());
                decimal OTMinusRate = 0;
                if (!string.IsNullOrWhiteSpace(grvParticularsDetails.GetRowCellValue(e.RowHandle, colOTMinusRate).ToString())
                    && Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(e.RowHandle, colOTMinusRate).ToString())>0)
                    OTMinusRate = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(e.RowHandle, colOTMinusRate).ToString());
                else
                {
                    if (Common.SalaryMinusOTRatePerHour == 0)
                    {
                        decimal perHoursSal = (SalaryAmount / workingDays) / Common.SalaryTotalDayHours;
                        OTMinusRate = perHoursSal;
                    }
                    else
                        OTMinusRate = Common.SalaryMinusOTRatePerHour;

                    grvParticularsDetails.SetRowCellValue(e.RowHandle, colOTMinusRate, OTMinusRate);
                }

                decimal OTPlusHours = 0;
                if (!string.IsNullOrWhiteSpace(grvParticularsDetails.GetRowCellValue(e.RowHandle, colOTPlusHours).ToString()))
                    OTPlusHours = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(e.RowHandle, colOTPlusHours).ToString());
                decimal OTPlusRate = 0;
                if (!string.IsNullOrWhiteSpace(grvParticularsDetails.GetRowCellValue(e.RowHandle, colOTPlusRate).ToString())
                    && Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(e.RowHandle, colOTPlusRate).ToString()) > 0)
                    OTPlusRate = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(e.RowHandle, colOTPlusRate).ToString());
                else
                {
                    if (Common.SalaryMinusOTRatePerHour == 0)
                    {
                        decimal perHoursSal = (SalaryAmount / workingDays) / Common.SalaryTotalDayHours;
                        OTPlusRate = perHoursSal;
                    }
                    else
                        OTPlusRate = Common.SalaryPlusOTRatePerHour;

                    grvParticularsDetails.SetRowCellValue(e.RowHandle, colOTPlusRate, OTPlusRate);
                }
                decimal Bonus = 0;
                if (!string.IsNullOrWhiteSpace(grvParticularsDetails.GetRowCellValue(e.RowHandle, colBonus).ToString()))
                    Bonus = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(e.RowHandle, colBonus).ToString());

                if (!string.IsNullOrWhiteSpace(grvParticularsDetails.GetRowCellValue(e.RowHandle, gridColumnWorkedDays).ToString()))
                    workedDays = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(e.RowHandle, gridColumnWorkedDays).ToString());

                if (!string.IsNullOrWhiteSpace(grvParticularsDetails.GetRowCellValue(e.RowHandle, gridColumnAdvanceAmount).ToString()))
                    advanceAmount = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(e.RowHandle, gridColumnAdvanceAmount).ToString());

                CalculateTotal(SalaryAmount, OTMinusHours, OTMinusRate, OTPlusHours,OTPlusRate,Bonus, e.RowHandle, workingDays, workedDays, advanceAmount);    
            }
        }

        private void CalculateTotal(decimal SalaryAmount, decimal OTMinusHours, decimal OTMinusRate, decimal OTPlusHours, decimal OTPlusRate, decimal Bonus, int GridRowIndex, decimal workingdays, decimal workeddays, decimal advanceAmount)
        {
            grvParticularsDetails.CellValueChanged -= new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvParticularsDetails_CellValueChanged);

            decimal perHoursSal = (SalaryAmount / workingdays) / Common.SalaryTotalDayHours;
            decimal totalWorkedHours = workeddays * Common.SalaryTotalDayHours;

            decimal OTPlusHoursAmount = OTPlusHours * OTPlusRate;

            decimal OTMinusHoursAmount = (OTMinusHours * OTMinusRate)*-1;

            decimal Total = (perHoursSal * totalWorkedHours) + OTMinusHoursAmount + OTPlusHoursAmount + Bonus + advanceAmount;
            Total = Convert.ToDecimal(Total.ToString("0.00"));

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
            grvParticularsDetails.SetRowCellValue(GridRowIndex, colOTMinusAmount, OTMinusHoursAmount.ToString());
            grvParticularsDetails.SetRowCellValue(GridRowIndex, colOTPlusAmount, OTPlusHoursAmount.ToString());

            grvParticularsDetails.SetRowCellValue(GridRowIndex, colRound, RoundUpAmt.ToString("0.00"));
            grvParticularsDetails.SetRowCellValue(GridRowIndex, colTotal, Total.ToString("0.00"));
            grvParticularsDetails.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvParticularsDetails_CellValueChanged);
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
                    salaryDetail.WorkingDays = Convert.ToDecimal(txtWorkingDays.Text);
                    salaryDetail.WorkedDays = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(i, gridColumnWorkedDays).ToString());

                    decimal otMinusHours = 0;
                    decimal otMinusRate = 0;
                    if (grvParticularsDetails.GetRowCellValue(i, colOTMinusHours).ToString() != "")
                    {
                        otMinusHours = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(i, colOTMinusHours).ToString());
                    }

                    if (grvParticularsDetails.GetRowCellValue(i, colOTMinusRate).ToString() != "")
                    {
                        otMinusRate = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(i, colOTMinusRate).ToString());
                    }

                    salaryDetail.OTMinusHrs = otMinusHours;
                    salaryDetail.OTMinusRate = otMinusRate;
                    salaryDetail.OTMinusAmount = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(i, colOTMinusAmount).ToString());

                    decimal otPlusHours = 0;
                    decimal otPlusRate = 0;
                    if (grvParticularsDetails.GetRowCellValue(i, colOTPlusHours).ToString() != "")
                    {
                        otPlusHours = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(i, colOTPlusHours).ToString());
                    }
                    
                    if (grvParticularsDetails.GetRowCellValue(i, colOTPlusRate).ToString() != "")
                    {
                        otPlusRate = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(i, colOTPlusRate).ToString());
                    }

                    salaryDetail.OTPlusHrs = otPlusHours;
                    salaryDetail.OTPlusRate = otPlusRate;
                    salaryDetail.OTPlusAmount = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(i, colOTPlusAmount).ToString());
                    
                    decimal advAmt = 0;

                    if (grvParticularsDetails.GetRowCellValue(i, gridColumnAdvanceAmount).ToString() != "")
                        advAmt = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(i, gridColumnAdvanceAmount).ToString());

                    salaryDetail.AdvanceAmount = advAmt;

                    decimal colBon = 0;
                    if(grvParticularsDetails.GetRowCellValue(i, colBonus).ToString() != "")
                    {
                        colBon = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(i, colBonus).ToString());
                    }

                    salaryDetail.BonusAmount = colBon;


                    decimal rond = 0;

                    if(grvParticularsDetails.GetRowCellValue(i, colRound).ToString() != "")
                    {
                        rond = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(i, colRound).ToString());
                    }

                    salaryDetail.RoundOfAmount = rond;

                    salaryDetail.SalaryAmount = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(i, colSalaryAmount).ToString());

                    salaryDetail.TotalAmount = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(i, colTotal).ToString());

                    salaryDetailList.Insert(i, salaryDetail);
                }

                salaryMaster.SrNo = Convert.ToInt32(txtSerialNo.Text);
                salaryMaster.CompanyId = lueCompany.EditValue.ToString();
                salaryMaster.BranchId = Common.LoginBranch;
                salaryMaster.FinancialYearId = Common.LoginFinancialYear;
                //salaryMaster.FromPartyId = lueLeadger.EditValue.ToString();
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
            //else if (lueLeadger.EditValue == null)
            //{
            //    MessageBox.Show("Please select ledger", "Salary Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    lueLeadger.Focus();
            //    return false;
            //}
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