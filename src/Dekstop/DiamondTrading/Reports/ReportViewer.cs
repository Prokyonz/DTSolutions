using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiamondTrading.Reports
{
    public partial class ReportViewer : Form
    {
        CrystalReportViewer crystalReportViewer;
        public ReportViewer()
        {
            InitializeComponent();
            crystalReportViewer = new CrystalReportViewer();
            crystalReportViewer.Dock = DockStyle.Fill;
            crystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            crystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            crystalReportViewer.Location = new System.Drawing.Point(0, 35);
            crystalReportViewer.Name = "crystalReportViewer1";
            crystalReportViewer.ShowCloseButton = true;
            crystalReportViewer.ShowCopyButton = false;
            crystalReportViewer.ShowGotoPageButton = false;
            crystalReportViewer.ShowGroupTreeButton = false;
            crystalReportViewer.ShowLogo = false;
            crystalReportViewer.ShowParameterPanelButton = false;
            crystalReportViewer.ShowRefreshButton = false;
            crystalReportViewer.ShowTextSearchButton = false;
            crystalReportViewer.ShowZoomButton = false;
            crystalReportViewer.Size = new System.Drawing.Size(1512, 749);
            crystalReportViewer.TabIndex = 0;
            crystalReportViewer.ShowPrintButton = true;
            crystalReportViewer.ShowExportButton = true;
            crystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.Controls.Add(crystalReportViewer);

        }

        public void LoadReport(ReportDocument reportDocument)
        {
            crystalReportViewer.ReportSource = reportDocument;
            crystalReportViewer.Refresh();
            crystalReportViewer.Show();
        }
    }
}
