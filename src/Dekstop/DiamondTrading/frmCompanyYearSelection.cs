using DevExpress.XtraEditors;
using EFCore.SQL.Repository;
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
    public partial class FrmCompanyYearSelection : DevExpress.XtraEditors.XtraForm
    {
        private readonly CompanyMasterRepository _companyMasterRepository;
        private BranchMasterRepository _branchMasterRepository;
        private readonly FinancialYearMasterRepository _financialYearRepository;

        public FrmCompanyYearSelection()
        {
            InitializeComponent();

            _companyMasterRepository = new CompanyMasterRepository();
            _branchMasterRepository = new BranchMasterRepository();
            _financialYearRepository = new FinancialYearMasterRepository();
        }

        private async void FrmCompanyYearSelection_Load(object sender, EventArgs e)
        {
            await LoadCompany();
            await LoadFinancialYear();

            LoadRegistrySettings();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!CheckValidation())
                return;

            SaveRegistrySettings();
            Common.LoginCompany = lueCompany.EditValue.ToString();
            Common.LoginCompanyName = lueCompany.Text;

            Common.LoginBranch = lueBranch.EditValue.ToString();
            Common.LoginBranchName = lueBranch.Text;

            Common.LoginFinancialYear = lueFinancialYear.EditValue.ToString();
            Common.LoginFinancialYearName = lueFinancialYear.Text;

            this.DialogResult = DialogResult.OK;
        }

        #region "Private Metods"
        private void LoadRegistrySettings()
        {
            chkRememberMe.Checked = Common.RememberComapnyYearSelection;
            if (chkRememberMe.Checked)
            {
                if (Common.LoginCompany != Common.DefaultGuid)
                    lueCompany.EditValue = Common.LoginCompany;
                if (Common.LoginBranch != Common.DefaultGuid)
                    lueBranch.EditValue = Common.LoginBranch;
                if (Common.LoginFinancialYear != Common.DefaultGuid)
                    lueFinancialYear.EditValue = Common.LoginFinancialYear;
                btnOk.Focus();
                btnOk.Select();
            }
            else
            {
                lueCompany.Focus();
                lueCompany.Select();
            }
        }

        private void SaveRegistrySettings()
        {
            RegistryHelper.SaveSettings(RegistryHelper.MainSection, RegistryHelper.RememberCompanyYearSelection, chkRememberMe.Checked.ToString());
            if (chkRememberMe.Checked)
            {
                RegistryHelper.SaveSettings(RegistryHelper.MainSection, RegistryHelper.LoginCompany, lueCompany.EditValue.ToString());
                RegistryHelper.SaveSettings(RegistryHelper.MainSection, RegistryHelper.LoginCompanyName, lueCompany.Text);

                RegistryHelper.SaveSettings(RegistryHelper.MainSection, RegistryHelper.LoginBranch, lueBranch.EditValue.ToString());
                RegistryHelper.SaveSettings(RegistryHelper.MainSection, RegistryHelper.LoginBranchName, lueBranch.Text);

                RegistryHelper.SaveSettings(RegistryHelper.MainSection, RegistryHelper.LoginFinancialYear, lueFinancialYear.EditValue.ToString());
                RegistryHelper.SaveSettings(RegistryHelper.MainSection, RegistryHelper.LoginFinancialYearName, lueFinancialYear.Text);
            }
        }

        private bool CheckValidation()
        {
            if (lueCompany.EditValue == null || string.IsNullOrEmpty(lueCompany.EditValue.ToString()))
            {
                MessageBox.Show(AppMessages.GetString(AppMessageID.CompanyNotSelected), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lueCompany.Focus();
                return false;
            }
            else if (lueBranch.EditValue == null || string.IsNullOrEmpty(lueBranch.EditValue.ToString()))
            {
                MessageBox.Show(AppMessages.GetString(AppMessageID.BranchNotSelected), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lueBranch.Focus();
                return false;
            }
            else if (lueFinancialYear.EditValue == null || string.IsNullOrEmpty(lueFinancialYear.EditValue.ToString()))
            {
                MessageBox.Show(AppMessages.GetString(AppMessageID.FinancialYearNotSelected), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lueFinancialYear.Focus();
                return false;
            }
            return true;
        }

        private async Task LoadCompany()
        {
            var companies = await _companyMasterRepository.GetAllCompanyAsync();
            lueCompany.Properties.DataSource = companies;
            lueCompany.Properties.DisplayMember = "Name";
            lueCompany.Properties.ValueMember = "Id";
        }

        private async Task LoadBranch(string companyId)
        {
            lueBranch.EditValue = null;
            var branches = await _branchMasterRepository.GetAllBranchAsync(companyId); //_branchMasterRepository.GetAllBranchAsync();
            lueBranch.Properties.DataSource = branches;
            lueBranch.Properties.DisplayMember = "Name";
            lueBranch.Properties.ValueMember = "Id";
        }

        private async Task LoadFinancialYear()
        {
            var financialYear = await _financialYearRepository.GetAllFinancialYear();
            lueFinancialYear.Properties.DataSource = financialYear;
            lueFinancialYear.Properties.DisplayMember = "Name";
            lueFinancialYear.Properties.ValueMember = "Id";            
        }

        #endregion

        private void FrmCompanyYearSelection_KeyDown(object sender, KeyEventArgs e)
        {
            Common.MoveToNextControl(sender, e, this);
        }

        private async void lookUpCompany_EditValueChanged(object sender, EventArgs e)
        {
            if (lueCompany.EditValue != null)
                await LoadBranch(lueCompany.EditValue.ToString());
        }
    }
}