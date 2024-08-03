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

namespace DiamondTrading
{
    public partial class FrmCompanyYearSelection : DevExpress.XtraEditors.XtraForm
    {
        private readonly CompanyMasterRepository _companyMasterRepository;
        private BranchMasterRepository _branchMasterRepository;
        private readonly FinancialYearMasterRepository _financialYearRepository;
        private List<CompanyMaster> _companyList;
        public delegate Task CheckPermission();

        public FrmCompanyYearSelection()
        {
            InitializeComponent();

            bool cacheAllowedOrNot = Convert.ToBoolean(RegistryHelper.GetSettings(RegistryHelper.OtherSection, RegistryHelper.CacheAllowOrNot, "false"));

            _companyMasterRepository = new CompanyMasterRepository(new CacheKeyGenerator { IsCacheEnabled = cacheAllowedOrNot, CompanyId = Common.LoginCompany, FinancialYearId = Common.LoginFinancialYear, UserId = Common.LoginUserID });
            _branchMasterRepository = new BranchMasterRepository();
            _financialYearRepository = new FinancialYearMasterRepository();
        }

        private void FrmCompanyYearSelection_Load(object sender, EventArgs e)
        {
            _=LoadCompany();
            _=LoadFinancialYear();
            FillLanguageBox();
            LoadRegistrySettings();
        }

        private async void btnOk_Click(object sender, EventArgs e)
        {
            if (!CheckValidation())
                return;
            
            int oldSelectedLanguage = Convert.ToInt32(RegistryHelper.GetSettings(RegistryHelper.MainSection, RegistryHelper.LoginLanguage, "1"));
            SaveRegistrySettings();
            if (Convert.ToInt32(lueLanguage.EditValue) != oldSelectedLanguage)
            {                                
                MessageBox.Show(LangHelper.GetString("LangChange"), LangHelper.GetString("LangChngeTitle"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Restart();
            }

            Common.LoginCompany = lueCompany.EditValue.ToString();
            Common.LoginCompanyName = lueCompany.Text;
            if (_companyList.Any())
            {
                Common.CurrentSelectedCompany = _companyList.Where(x => x.Id == Common.LoginCompany.ToString()).ToList();
            }

            Common.LoginBranch = lueBranch.EditValue.ToString();
            Common.LoginBranchName = lueBranch.Text;

            Common.LoginFinancialYear = lueFinancialYear.EditValue.ToString();
            Common.LoginFinancialYearName = lueFinancialYear.Text;

            await FrmMain.currentInstance.CheckPermission();
            this.DialogResult = DialogResult.OK;
        }

        #region "Private Metods"
        private void LoadRegistrySettings()
        {
            chkRememberMe.Checked = Common.RememberComapnyYearSelection;
            if (chkRememberMe.Checked)
            {
                //if (Common.LoginCompany != Common.DefaultGuid)
                    lueCompany.EditValue = Common.LoginCompany;
                //if (Common.LoginBranch != Common.DefaultGuid)
                    lueBranch.EditValue = Common.LoginBranch;
                //if (Common.LoginFinancialYear != Common.DefaultGuid)
                    lueFinancialYear.EditValue = Common.LoginFinancialYear;
                lueLanguage.EditValue = Convert.ToInt32(Common.LoginLanguage);

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

                RegistryHelper.SaveSettings(RegistryHelper.MainSection, RegistryHelper.LoginLanguage, lueLanguage.EditValue.ToString());
                Common.LoginLanguage = lueLanguage.EditValue.ToString();
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
            _companyList = await _companyMasterRepository.GetUserCompanyMappingAsync(Common.LoginUserID);
            lueCompany.Properties.DataSource = _companyList;
            lueCompany.Properties.DisplayMember = "Name";
            lueCompany.Properties.ValueMember = "Id";
            if (Common.RememberComapnyYearSelection == true)
                btnOk.Focus();
        }

        public void FillLanguageBox()
        {
            lueLanguage.Properties.DataSource = Common.GetLanguageType;
            lueLanguage.Properties.DisplayMember = "Name";
            lueLanguage.Properties.ValueMember = "Id";
            lueLanguage.EditValue = 1;
        }

        private async Task LoadBranch(string companyId)
        {
            lueBranch.EditValue = null;
            var branches = await _branchMasterRepository.GetAllBranchAsync(companyId); //_branchMasterRepository.GetAllBranchAsync();
            lueBranch.Properties.DataSource = branches;
            lueBranch.Properties.DisplayMember = "Name";
            lueBranch.Properties.ValueMember = "Id";
            if (Common.RememberComapnyYearSelection == true)
                btnOk.Focus();
        }

        private async Task LoadFinancialYear()
        {
            var financialYear = await _financialYearRepository.GetAllFinancialYear();
            lueFinancialYear.Properties.DataSource = financialYear;
            lueFinancialYear.Properties.DisplayMember = "Name";
            lueFinancialYear.Properties.ValueMember = "Id";
            if (Common.RememberComapnyYearSelection == true)
                btnOk.Focus();
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            btnOk_Click(sender, e);
        }
    }
}