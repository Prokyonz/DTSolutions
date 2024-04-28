using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using EFCore.SQL.Repository;
using Repository.Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace DiamondTrading.Transaction
{
    public partial class FromChildLedgerReport : DevExpress.XtraEditors.XtraForm
    {
        public string LedgerId { get; set; }
        public string ledgerType { get; set; }
        public bool IsCustomLoaded { get; set; }
        public int _partyType = 0;
        private PartyMasterRepository _partyMasterRepository { get; set; }
        public FromChildLedgerReport()
        {
            InitializeComponent();
        }

        public FromChildLedgerReport(string ledgerId, string _ledgerType, int partyType = 0)
        {
            InitializeComponent();
            LedgerId = ledgerId;
            ledgerType = _ledgerType;
            _partyType = partyType;
        }

        private async void FromChildLedgerReport_Load(object sender, EventArgs e)
        {
            _partyMasterRepository = new PartyMasterRepository();
            
            gridControlChildLedgerReport.DataSource = await _partyMasterRepository.GetLedgerChildReport(Common.LoginCompany, Common.LoginFinancialYear, LedgerId, _partyType);
        }

        private void grvChildLedgerReport_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            if (!IsCustomLoaded)
            {
                try
                {
                    string v = LedgerId;
                    DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
                    GridColumnSummaryItem item = e.Item as GridColumnSummaryItem;
                    double Total = double.Parse(view.Columns["Credit"].SummaryText);
                    double saleRate = double.Parse(view.Columns["Debit"].SummaryText);
                    if (ledgerType.ToLower() == "expense" || ledgerType.ToLower() == "party-sale")
                    {
                        e.TotalValue = saleRate - Total;
                    }
                    else
                        e.TotalValue = Total - saleRate;
                }
                catch (Exception)
                {
                    e.TotalValue = 0;
                }
                IsCustomLoaded = true;
            }
        }

        private void FromChildLedgerReport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void exportExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grvChildLedgerReport.ExpandAllGroups();
            grvChildLedgerReport.BestFitColumns();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
            saveFileDialog.Title = "Save an Excel File";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
                grvChildLedgerReport.ExportToXlsx(saveFileDialog.FileName);
        }

        private void exportPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
            saveFileDialog.Title = "PDF an Excel File";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                this.Cursor = Cursors.WaitCursor;
                DevExpress.XtraPrinting.PrintingSystem printingSystem1 = new DevExpress.XtraPrinting.PrintingSystem();
                DevExpress.XtraPrinting.PrintableComponentLink printLink = new DevExpress.XtraPrinting.PrintableComponentLink();

                DevExpress.XtraPrinting.PdfExportOptions options = new DevExpress.XtraPrinting.PdfExportOptions();

                try
                {
                    printLink.Component = gridControlChildLedgerReport;
                    printLink.CreateDocument(printingSystem1);
                    printLink.Landscape = true;

                    printingSystem1.ShowPrintStatusDialog = true;
                    printingSystem1.PageSettings.Landscape = true;
                    printingSystem1.ExportToPdf(saveFileDialog.FileName, options);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    printingSystem1.Dispose();
                    printLink.Dispose();
                    this.Cursor = Cursors.Default;
                }
            }
        }
    }
}
