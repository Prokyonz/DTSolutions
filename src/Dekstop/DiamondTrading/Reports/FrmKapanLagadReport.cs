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
    public partial class FrmKapanLagadReport : DevExpress.XtraEditors.XtraForm
    {
        private KapanMasterRepository _kapanMasterRepository;

        public FrmKapanLagadReport()
        {
            InitializeComponent();
        }

        private async void FrmViewSlip_Load(object sender, EventArgs e)
        {
            _kapanMasterRepository = new KapanMasterRepository();
            await GetKapanDetail();
        }

        private async Task GetKapanDetail()
        {
            KapanMasterRepository kapanMasterRepository = new KapanMasterRepository();
            var kapanMaster = await kapanMasterRepository.GetAllKapanAsync();
            lueKapan.Properties.DataSource = kapanMaster;
            lueKapan.Properties.DisplayMember = "Name";
            lueKapan.Properties.ValueMember = "Id";
        }

        private async void btnView_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (lueKapan.EditValue != null)
                {
                    var kapanLagadDetails = await _kapanMasterRepository.GetKapanLagadReport(lueKapan.EditValue.ToString());
                    DataTable dt = Common.ToDataTable(kapanLagadDetails);
                    if (dt.Rows.Count > 0)
                    {
                        Reports.rptKapanLagadReport cls = new Reports.rptKapanLagadReport();
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
            catch(Exception Ex)
            {
                MessageBox.Show("Error: "+Ex.Message, this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}