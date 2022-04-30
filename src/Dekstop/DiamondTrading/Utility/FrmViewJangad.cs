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

namespace DiamondTrading.Utility
{
    public partial class FrmViewJangad : DevExpress.XtraEditors.XtraForm
    {
        private JangadMasterRepository _jangadMasterRepository;
        private string _SrNo = string.Empty;
        private string _CompanyId = string.Empty;
        private string _FinancialYearId = string.Empty;
        private int _JangadType = 1;
        public FrmViewJangad(string SrNo, string FinancialYearId, string CompanyId, int JangadType)
        {
            InitializeComponent();
            _jangadMasterRepository = new JangadMasterRepository();
            _SrNo = SrNo;
            _CompanyId = CompanyId;
            _FinancialYearId = FinancialYearId;
            _JangadType = JangadType;
        }

        private async void FrmViewJangad_Load(object sender, EventArgs e)
        {
            var slipDetails = await _jangadMasterRepository.GetJangadPrintDetails(_CompanyId, _FinancialYearId, _SrNo, _JangadType);
            DataTable dt = Common.ToDataTable(slipDetails);
            if (dt.Rows.Count > 0)
            {
                Reports.rptJangadPrint cls = new Reports.rptJangadPrint();
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