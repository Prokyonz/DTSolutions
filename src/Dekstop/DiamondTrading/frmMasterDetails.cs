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
    public partial class frmMasterDetails : DevExpress.XtraEditors.XtraForm
    {
        private readonly CompanyMasterRepository _companyMasterRepository;

        public frmMasterDetails()
        {
            InitializeComponent();
            _companyMasterRepository = new CompanyMasterRepository();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void accordianAddBtn_Click(object sender, EventArgs e)
        {
            if (xtabMasterDetails.SelectedTabPage == xtabCompanyMaster)
            {
                Master.frmCompanyMaster frmcompanymaster = new Master.frmCompanyMaster();
                frmcompanymaster.ShowDialog();
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabBranchMaster)
            {
                //frmLogin frmLogin = new frmLogin();
                //frmLogin.ShowDialog();
            }

        }

        private async void frmMasterDetails_Load(object sender, EventArgs e)
        {
            var result = await _companyMasterRepository.GetAllCompanyAsync();
            if(result != null)
            {
                gridControl1.DataSource= result;
            }
        }
    }
}