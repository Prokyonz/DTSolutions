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

namespace DiamondTrading.Transaction
{
    public partial class FrmViewSlip : DevExpress.XtraEditors.XtraForm
    {
        private PurchaseMasterRepository _purchaseMasterRepository;
        private string _SlipNo = string.Empty;
        private string _FinancialYearId = string.Empty;
        private int _ActionType = 0;
        public FrmViewSlip(int ActionType,string SlipNo, string FinancialYearId)
        {
            InitializeComponent();
            _purchaseMasterRepository = new PurchaseMasterRepository();
            _SlipNo = SlipNo;
            _FinancialYearId = FinancialYearId;
            _ActionType = ActionType;
        }

        private async void FrmViewSlip_Load(object sender, EventArgs e)
        {
            var slipDetails = await _purchaseMasterRepository.GetSlipDetails(_ActionType,Common.LoginCompany, _SlipNo, _FinancialYearId);
            DataTable dt = Common.ToDataTable(slipDetails);
            if (dt.Rows.Count > 0)
            {
                Reports.rptSlipPrint cls = new Reports.rptSlipPrint();
                cls.SetDataSource(dt);
                cls.SetDatabaseLogon("sa", "123");
                //cls.PrintOptions.PrinterName = "Canon LBP2900";
                //cls.PrintOptions.PrinterName = Common.BarcodePrinter;
                //cls.PrintToPrinter(1, false, 0, 0);
                crystalReportViewer1.ReportSource = cls;
                crystalReportViewer1.Show();
            }
        }
    }
}