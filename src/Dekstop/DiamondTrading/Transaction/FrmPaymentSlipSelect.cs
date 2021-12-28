using DevExpress.XtraEditors;
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
    public partial class FrmPaymentSlipSelect : DevExpress.XtraEditors.XtraForm
    {
        public FrmPaymentSlipSelect(DataTable dtSlipDetails)
        {
            InitializeComponent();

            dtSlipDetail = dtSlipDetails;
            if (!dtSlipDetail.Columns.Contains("Amount"))
                dtSlipDetail.Columns.Add("Amount", typeof(decimal));
            grdPaymentDetails.DataSource = dtSlipDetail;
        }

        public DataTable dtSlipDetail
        {
            get;
            private set;
        }

        public bool IsAutoAdjustBillAmount
        {
            get
            {
                return tglIsAutoMap.IsOn;
                colAmount.OptionsColumn.ReadOnly = true;
            }
            set
            {
                tglIsAutoMap.IsOn = value;
                colAmount.OptionsColumn.ReadOnly = value;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            dtSlipDetail = (DataTable)grdPaymentDetails.DataSource;
        }

        private void tglIsAutoMap_Toggled(object sender, EventArgs e)
        {
            IsAutoAdjustBillAmount = tglIsAutoMap.IsOn;
        }
    }
}