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
    public partial class FrmChildNumberReport : DevExpress.XtraEditors.XtraForm
    {
        private AccountToAssortMasterRepository _accountToAssortMasterRepository;

        public FrmChildNumberReport()
        {
            InitializeComponent();
        }

        public async Task LoadData()
        {
            _accountToAssortMasterRepository = new AccountToAssortMasterRepository();
            var salesData = await _accountToAssortMasterRepository.GetNumberReportAsync(Common.LoginCompany, Common.LoginFinancialYear);
            grdNumberReportMaster.DataSource = salesData;
        }

        private void FrmChildNumberReport_Load(object sender, EventArgs e)
        {
            _ = LoadData();
        }
    }
}
