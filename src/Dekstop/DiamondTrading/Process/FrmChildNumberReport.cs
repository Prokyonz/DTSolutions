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
            List<StockReportMasterGrid> groupedStockReports = new List<StockReportMasterGrid>();

            if (_numberReportModelReports != null && _numberReportModelReports.Count > 0)
            {
                groupedStockReports = _numberReportModelReports
                    .GroupBy(x => new { x.Number})
                    .Select(g => new StockReportMasterGrid
                    {
                        Id = g.Key.Number, // Assuming KapanId is unique and can be used as Id
                        Name = g.Key.Number,
                        Rate = Math.Round(g.Average(a => a.InwardRate) - g.Average(a => a.OutwardRate), 2),
                        TotalWeight = g.Sum(s => s.InwardNetWeight) - g.Sum(s => s.OutwardNetWeight),
                        TotalAmount = g.Sum(s => s.InwardAmount) - g.Sum(s => s.OutwardAmount)
                    })
                    .ToList();
            }

            grdGroupedStockReports.BringToFront();
            grdGroupedStockReports.DataSource = groupedStockReports;

            //grdNumberReportMaster.DataSource = _numberReportModelReports;
            grvGroupedStockReports.RestoreLayoutFromRegistry(RegistryHelper.ReportLayouts("GroupNumberChildReport"));
            gvNumberReport.RestoreLayoutFromRegistry(RegistryHelper.ReportLayouts("NumberChildReport"));
        }

        private void FrmChildNumberReport_Load(object sender, EventArgs e)
        {
            _ = LoadDataNumber();
        }

        private void FrmChildNumberReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            grvGroupedStockReports.SaveLayoutToRegistry(RegistryHelper.ReportLayouts("GroupNumberChildReport"));
            gvNumberReport.SaveLayoutToRegistry(RegistryHelper.ReportLayouts("NumberChildReport"));
        }

        private void grdGroupedStockReports_DoubleClick(object sender, EventArgs e)
        {
            string NumberId = grvGroupedStockReports.GetFocusedRowCellValue(grdColId).ToString();
            grdNumberReportMaster.DataSource = _numberReportModelReports.Where(x => x.Number == NumberId).ToList();
            grdNumberReportMaster.BringToFront();
        }
    }
}
