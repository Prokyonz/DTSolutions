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

namespace DiamondTrading.Reports
{
    public partial class FrmWeeklyPurchaseDetailReport : DevExpress.XtraEditors.XtraForm
    {
        private string _currentWeek = string.Empty;
        public FrmWeeklyPurchaseDetailReport(string CurrentWeek)
        {
            InitializeComponent();
            _currentWeek = CurrentWeek;
        }

        private async void FrmWeeklyPurchaseDetailReport_Load(object sender, EventArgs e)
        {
            PurchaseMasterRepository purchaseMasterRepository = new PurchaseMasterRepository();
            var purchaseData = await purchaseMasterRepository.GetPurchaseReport(Common.LoginCompany, Common.LoginFinancialYear, _currentWeek);
            grdWeeklyPurchaseDetails.DataSource = purchaseData.OrderBy(o => o.SlipNo);
        }

        private void FrmWeeklyPurchaseDetailReport_KeyDown(object sender, KeyEventArgs e)
        {
            Common.MoveToNextControl(sender, e, this);
        }
    }
}