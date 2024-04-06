using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiamondTrading
{
    public partial class FrmOptions : DevExpress.XtraEditors.XtraForm
    {
        public FrmOptions()
        {
            InitializeComponent();
        }

        private void EnableDisableApplyButton(bool Value)
        {
            btnApply.Enabled = Value;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            EnableDisableApplyButton(true);
            SaveSettings();
            EnableDisableApplyButton(false);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SaveSettings();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadRegistry()
        {
            txtFormTitle.Text = Common.FormTitle;
            chkPrintSlip.Checked = Common.PrintPurchaseSlip;
            chkPrintPF.Checked = Common.PrintPurchasePF;
            chkAllowToSelectPaymentDueDate.Checked = Common.AllowToSelectPurchaseDueDate;

            if (Common.SalaryPaidInDays)
                rdbDays.Checked = true;
            else
                rdbHours.Checked = true;
            txtDayHours.Text = Common.SalaryTotalDayHours.ToString();
            txtPlusOTHourRate.Text = Common.SalaryPlusOTRatePerHour.ToString();
            txtMinusOTHourRate.Text = Common.SalaryMinusOTRatePerHour.ToString();

            txtSlipPrinterName.Text = Common.SlipPrinterName.ToString();
        }

        private void SaveSettings()
        {
            if (btnApply.Enabled)
            {
                #region "General"
                Common.FormTitle = txtFormTitle.Text;
                RegistryHelper.SaveSettings(RegistryHelper.OtherSection, RegistryHelper.FormTitle, txtFormTitle.Text);
                #endregion

                #region "Advanced"
                if (checkEditClearReportLayout.Checked)
                {
                    RegistryHelper.DeleteSettings();
                }

                Common.PrintPurchaseSlip = chkPrintSlip.Checked;
                RegistryHelper.SaveSettings(RegistryHelper.OtherSection, RegistryHelper.PrintPurchaseSlip, chkPrintSlip.Checked.ToString());

                Common.PrintPurchasePF = chkPrintPF.Checked;
                RegistryHelper.SaveSettings(RegistryHelper.OtherSection, RegistryHelper.PrintPurchasePF, chkPrintPF.Checked.ToString());

                Common.AllowToSelectPurchaseDueDate = chkAllowToSelectPaymentDueDate.Checked;
                RegistryHelper.SaveSettings(RegistryHelper.OtherSection, RegistryHelper.AllowToSelectPurchaseDueDate, chkAllowToSelectPaymentDueDate.Checked.ToString());

                //Salary
                Common.SalaryPaidInDays = rdbDays.Checked;
                RegistryHelper.SaveSettings(RegistryHelper.OtherSection, RegistryHelper.SalaryPaidInDays, rdbDays.Checked.ToString());

                Common.SalaryTotalDayHours = Convert.ToDecimal(txtDayHours.Text);
                RegistryHelper.SaveSettings(RegistryHelper.OtherSection, RegistryHelper.SalaryTotalDayHours, txtDayHours.Text);

                Common.SalaryPlusOTRatePerHour = Convert.ToDecimal(txtPlusOTHourRate.Text);
                RegistryHelper.SaveSettings(RegistryHelper.OtherSection, RegistryHelper.SalaryPlusOTRatePerHour, txtPlusOTHourRate.Text);

                Common.SalaryMinusOTRatePerHour = Convert.ToDecimal(txtMinusOTHourRate.Text);
                RegistryHelper.SaveSettings(RegistryHelper.OtherSection, RegistryHelper.SalaryMinusOTRatePerHour, txtMinusOTHourRate.Text);
                #endregion

                #region "Other"
                Common.SlipPrinterName = txtSlipPrinterName.Text;
                RegistryHelper.SaveSettings(RegistryHelper.OtherSection, RegistryHelper.SlipPrinterName, txtSlipPrinterName.Text);
                #endregion
            }
        }

        private void FrmOptions_Load(object sender, EventArgs e)
        {
            LoadRegistry();
            EnableDisableApplyButton(false);
        }

        private void txtFormTitle_TextChanged(object sender, EventArgs e)
        {
            EnableDisableApplyButton(true);
        }

        private void chkPrintSlip_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableApplyButton(true);
        }

        private void chkAllowToSelectPaymentDueDate_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableApplyButton(true);
        }

        private void chkPrintPF_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableApplyButton(true);
        }

        private void checkEditClearReportLayout_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableApplyButton(true);
        }

        private void groupControl3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtSlipPrinterName_TextChanged(object sender, EventArgs e)
        {
            EnableDisableApplyButton(true);
        }

        private void txtDayHours_EditValueChanged(object sender, EventArgs e)
        {
            EnableDisableApplyButton(true);
        }

        private void txtPlusOTHourRate_EditValueChanged(object sender, EventArgs e)
        {
            EnableDisableApplyButton(true);
        }

        private void txtMinusOTHourRate_EditValueChanged(object sender, EventArgs e)
        {
            EnableDisableApplyButton(true);
        }

        private void rdbDays_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableApplyButton(true);
        }

        private void rdbHours_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableApplyButton(true);
        }

        private void txtDayHours_TextChanged(object sender, EventArgs e)
        {
            EnableDisableApplyButton(true);
        }

        private void txtPlusOTHourRate_TextChanged(object sender, EventArgs e)
        {
            EnableDisableApplyButton(true);
        }

        private void txtMinusOTHourRate_TextChanged(object sender, EventArgs e)
        {
            EnableDisableApplyButton(true);
        }
    }
}