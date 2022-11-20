using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
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

namespace DiamondTrading.Transaction
{
    public partial class FromChildLedgerReport : DevExpress.XtraEditors.XtraForm
    {
        public string LedgerId { get; set; }
        private PartyMasterRepository _partyMasterRepository { get; set; }
        public FromChildLedgerReport()
        {
            InitializeComponent();
        }

        public FromChildLedgerReport(string ledgerId)
        {
            InitializeComponent();
            LedgerId = ledgerId;
        }

        private async void FromChildLedgerReport_Load(object sender, EventArgs e)
        {
            _partyMasterRepository = new PartyMasterRepository();
            gridControlChildLedgerReport.DataSource = await _partyMasterRepository.GetLedgerChildReport(Common.LoginCompany, Common.LoginFinancialYear, LedgerId);
        }

        private void grvChildLedgerReport_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                GridColumnSummaryItem item = e.Item as GridColumnSummaryItem;
                double Total = double.Parse(view.Columns["Credit"].SummaryText);
                double saleRate = double.Parse(view.Columns["Debit"].SummaryText);
                e.TotalValue = Total  - saleRate;
            }
            catch (Exception)
            {
                e.TotalValue = 0;
            }
        }
    }
}
