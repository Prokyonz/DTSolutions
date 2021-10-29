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

namespace DiamondTrading.Process
{
    public partial class FrmKapanMap : DevExpress.XtraEditors.XtraForm
    {
        KapanMappingMasterRepository kapanMappingMasterRepository;
        public FrmKapanMap()
        {
            InitializeComponent();
            kapanMappingMasterRepository = new KapanMappingMasterRepository();
        }

        private async void FrmKapanMap_Load(object sender, EventArgs e)
        {
            dtDate.EditValue = DateTime.Now;
            dtTime.EditValue = DateTime.Now;

            await LoadCompany();
            await GetKapanDetail();
            await GetMaxSrNo();
            await GetPendingKapanDetails();
        }

        private async Task LoadCompany()
        {
            CompanyMasterRepository companyMasterRepository = new CompanyMasterRepository();
            var companies = await companyMasterRepository.GetAllCompanyAsync();
            lueCompany.Properties.DataSource = companies;
            lueCompany.Properties.DisplayMember = "Name";
            lueCompany.Properties.ValueMember = "Id";

            lueCompany.EditValue = Common.LoginCompany;
            await LoadBranch(Common.LoginCompany);
        }  

        private async Task LoadBranch(string companyId)
        {
            BranchMasterRepository branchMasterRepository = new BranchMasterRepository();
            var branches = await branchMasterRepository.GetAllBranchAsync(companyId); //_branchMasterRepository.GetAllBranchAsync();
            lueBranch.Properties.DataSource = branches;
            lueBranch.Properties.DisplayMember = "Name";
            lueBranch.Properties.ValueMember = "Id";
            lueBranch.EditValue = Common.LoginBranch;
        }

        private async Task GetKapanDetail()
        {
            KapanMasterRepository kapanMasterRepository = new KapanMasterRepository();
            var kapanMaster = await kapanMasterRepository.GetAllKapanAsync();
            lueKapan.Properties.DataSource = kapanMaster;
            lueKapan.Properties.DisplayMember = "Name";
            lueKapan.Properties.ValueMember = "Id";
        }

        private async Task GetMaxSrNo()
        {
            var SrNo = await kapanMappingMasterRepository.GetMaxSrNo(lueCompany.EditValue.ToString(), Common.LoginFinancialYear);
            txtSerialNo.Text = SrNo.ToString();
        }

        private async Task GetPendingKapanDetails()
        {
            var PendingKapanDetails = kapanMappingMasterRepository.GetPendingKapanMapping(lueCompany.EditValue.ToString(),lueBranch.EditValue.ToString(),Common.LoginFinancialYear);
            grdPendingKapanDetails.DataSource = PendingKapanDetails;
        }
    }
}