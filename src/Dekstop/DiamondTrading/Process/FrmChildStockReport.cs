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
        bool _IsStockDetailDisplay = false;
        public FrmChildStockReport()
        {
            InitializeComponent();

        }

        public FrmChildStockReport(List<StockReportModelReport> stockReportModelReports)
        {
            InitializeComponent();
            _stockReportModelReports = stockReportModelReports;
        }

        public FrmChildStockReport(List<StockReportModelReport> stockReportModelReports, bool IsStockDetailDisplay)
        {
            InitializeComponent();
            _stockReportModelReports = stockReportModelReports;
            _IsStockDetailDisplay = IsStockDetailDisplay;
        }

        public async Task LoadDataStock()
        {
            if (!_IsStockDetailDisplay)
            {
                List<StockReportMasterGrid> groupedStockReports = new List<StockReportMasterGrid>();

                if (_stockReportModelReports != null && _stockReportModelReports.Count > 0)
                {
                    groupedStockReports = _stockReportModelReports
                        .GroupBy(x => new { x.KapanId, x.Name })
                        .Select(g => new StockReportMasterGrid
                        {
                            Id = g.Key.KapanId, // Assuming KapanId is unique and can be used as Id
                            Name = g.Key.Name,
                            Rate = Math.Round(g.Average(a => a.InwardRate) - g.Average(a => a.OutwardRate), 2),
                            TotalWeight = g.Sum(s => s.InwardNetWeight) - g.Sum(s => s.OutwardNetWeight),
                            TotalAmount = g.Sum(s => s.InwardAmount) - g.Sum(s => s.OutwardAmount)
                        })
                        .ToList();
                }

                grdGroupedStockReports.BringToFront();
                grdGroupedStockReports.DataSource = groupedStockReports;

                //grdStockReportMaster.DataSource = _stockReportModelReports;
                grvGroupedStockReports.RestoreLayoutFromRegistry(RegistryHelper.ReportLayouts("GroupStockChildReport"));
            }
            else
            {
                grdStockReportMaster.DataSource = _stockReportModelReports;
                grdStockReportMaster.BringToFront();
                gvStockReport.RestoreLayoutFromRegistry(RegistryHelper.ReportLayouts("StockChildReport"));
            }
        }

        private void FrmChildStockReport_Load(object sender, EventArgs e)
        {
            _ = LoadDataStock();
        }

        private void FrmChildStockReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            grvGroupedStockReports.SaveLayoutToRegistry(RegistryHelper.ReportLayouts("GroupStockChildReport"));
            gvStockReport.SaveLayoutToRegistry(RegistryHelper.ReportLayouts("StockChildReport"));
        }

        private void grdGroupedStockReports_DoubleClick(object sender, EventArgs e)
        {
            string KapanId = grvGroupedStockReports.GetFocusedRowCellValue(grdColId).ToString();
            string KapanName = grvGroupedStockReports.GetFocusedRowCellValue(grdColName).ToString();
            var StockData = _stockReportModelReports.Where(x => x.KapanId == KapanId).ToList();

            FrmChildStockReport frmChildStockReport = new FrmChildStockReport(StockData, true);
            frmChildStockReport.Text = KapanName + " Kapan detail Report";
            frmChildStockReport.StartPosition = FormStartPosition.CenterScreen;
            frmChildStockReport.WindowState = FormWindowState.Maximized;
            frmChildStockReport.ShowDialog();
        }
    }
}
