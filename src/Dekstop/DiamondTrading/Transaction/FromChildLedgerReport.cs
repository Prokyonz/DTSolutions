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
                    GridView view = sender as GridView;
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
    }
}
