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
    public partial class FrmChildStockReport : DevExpress.XtraEditors.XtraForm
    {
        private List<StockReportModelReport> _stockReportModelReports;

        public FrmChildStockReport()
        {
            InitializeComponent();

        }

        public FrmChildStockReport(List<StockReportModelReport> stockReportModelReports)
        {
            InitializeComponent();
            _stockReportModelReports = stockReportModelReports;
        }

        public async Task LoadDataStock()
        {
            grdStockReportMaster.DataSource = _stockReportModelReports;
            gvStockReport.RestoreLayoutFromRegistry(RegistryHelper.ReportLayouts("StockChildReport"));
        }

        private void FrmChildStockReport_Load(object sender, EventArgs e)
        {
            _ = LoadDataStock();
        }

        private void FrmChildStockReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            gvStockReport.SaveLayoutToRegistry(RegistryHelper.ReportLayouts("StockChildReport"));
        }
    }
}
