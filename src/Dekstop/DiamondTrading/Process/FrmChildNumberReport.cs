using EFCore.SQL.Repository;
using Repository.Entities.Model;
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
        private List<NumberReportModelReport> _numberReportModelReports;

        public FrmChildNumberReport()
        {
            InitializeComponent();
        }
        public FrmChildNumberReport(List<NumberReportModelReport> numberReportModelReports)
        {
            InitializeComponent();
            _numberReportModelReports = numberReportModelReports;
        }

        public async Task LoadDataNumber()
        {
            //_accountToAssortMasterRepository = new AccountToAssortMasterRepository();
            //var salesData = await _accountToAssortMasterRepository.GetNumberReportAsync(Common.LoginCompany, Common.LoginFinancialYear);
            grdNumberReportMaster.DataSource = _numberReportModelReports;
            gvNumberReport.RestoreLayoutFromRegistry(RegistryHelper.ReportLayouts("NumberChildReport"));
        }

        private void FrmChildNumberReport_Load(object sender, EventArgs e)
        {
            _ = LoadDataNumber();
        }

        private void FrmChildNumberReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            gvNumberReport.SaveLayoutToRegistry(RegistryHelper.ReportLayouts("NumberChildReport"));
        }
    }
}
