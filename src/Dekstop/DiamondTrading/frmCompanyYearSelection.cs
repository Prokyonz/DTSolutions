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
            
            LoadCompany();                        

        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        #region "Private Metods"

        private async void LoadCompany()
        {
            var companies = await _companyMasterRepository.GetParentCompanyAsync();
            lookUpCompany.Properties.DataSource = companies;
            lookUpCompany.Properties.DisplayMember = "Name";
            lookUpCompany.Properties.ValueMember = "Id";
            
            LoadBranch(Guid.NewGuid());
        }

        private async void LoadBranch(Guid companyId)
        {
            var branches = await _branchMasterRepository.GetAllBranchAsync(); //_branchMasterRepository.GetCompanyBranchAsync(companyId);
            lookUpBranch.Properties.DataSource = branches;
            lookUpBranch.Properties.DisplayMember = "Name";
            lookUpBranch.Properties.ValueMember = "Id";

            LoadFinancialYear();
        }

        private async void LoadFinancialYear()
        {
            var financialYear = await _financialYearRepository.GetAllFinancialYear();
            lookUpFinancialYear.Properties.DataSource = financialYear;
            lookUpFinancialYear.Properties.DisplayMember = "Name";
            lookUpFinancialYear.Properties.ValueMember = "Id";            
        }

        #endregion

        private void FrmCompanyYearSelection_KeyDown(object sender, KeyEventArgs e)
        {
            Common.MoveToNextControl(sender, e, this);
        }
    }
}