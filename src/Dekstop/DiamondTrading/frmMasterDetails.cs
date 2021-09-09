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
    public partial class FrmMasterDetails : DevExpress.XtraEditors.XtraForm
    {
        private CompanyMasterRepository _companyMasterRepository;
        private List<CompanyMaster> _companyMaster;
        public FrmMasterDetails()
        {
            InitializeComponent();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void accordianAddBtn_Click(object sender, EventArgs e)
        {
            if (xtabMasterDetails.SelectedTabPage == xtabCompanyMaster)
            {
                Master.FrmCompanyMaster frmcompanymaster = new Master.FrmCompanyMaster(_companyMaster);
                frmcompanymaster.ShowDialog();
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabBranchMaster)
            {
                //frmLogin frmLogin = new frmLogin();
                //frmLogin.ShowDialog();
            }

        }

        private async void FrmMasterDetails_Load(object sender, EventArgs e)
        {
            await LoadGridData(true);
        }

        private async Task LoadGridData(bool IsForceLoad=false)
        {
            if (xtabMasterDetails.SelectedTabPage == xtabCompanyMaster)
            {
                if (IsForceLoad || _companyMaster == null)
                {
                    _companyMasterRepository = new CompanyMasterRepository();
                    _companyMaster = await _companyMasterRepository.GetAllCompanyAsync();
                    tlCompanyMaster.DataSource = _companyMaster;
                    tlCompanyMaster.ExpandAll();
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabBranchMaster)
            {
                //frmLogin frmLogin = new frmLogin();
                //frmLogin.ShowDialog();
            }
        }

        private void accordionEditBtn_Click(object sender, EventArgs e)
        {
            if (xtabMasterDetails.SelectedTabPage == xtabCompanyMaster)
            {
                Guid SelectedGuid = Guid.Parse(tlCompanyMaster.GetFocusedRowCellValue(Id).ToString());
                Master.FrmCompanyMaster frmcompanymaster = new Master.FrmCompanyMaster(_companyMaster, SelectedGuid);
                frmcompanymaster.ShowDialog();
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabBranchMaster)
            {
                //frmLogin frmLogin = new frmLogin();
                //frmLogin.ShowDialog();
            }
        }

        private async void xtabMasterDetails_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            await LoadGridData();
        }

        private async void accordionRefreshBtn_Click(object sender, EventArgs e)
        {
            await LoadGridData();
        }
    }
}