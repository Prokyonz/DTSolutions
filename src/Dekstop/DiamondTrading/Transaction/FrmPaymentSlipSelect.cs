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
            grdPaymentDetails.DataSource = dtSlipDetail.Clone();

            repoSlipNo.DataSource = dtSlipDetail;
            repoSlipNo.DisplayMember = "SlipNo";
            repoSlipNo.ValueMember = "SlipNo";

            var tempTbl = dtSlipDetail.Select("Amount<>0");
            if (tempTbl != null && tempTbl.Count() > 0)
            {
                DataTable tempTbl1 = tempTbl.CopyToDataTable();
                if (tempTbl1.Rows.Count > 0)
                {
                    grdPaymentDetails.DataSource = tempTbl1;
                }
            }

            grdPaymentDetails.Focus();

            GetBalance();
        }

        public DataTable dtSlipDetail
        {
            get;
            private set;
        }

        public decimal TotalAmount
        {
            get;
            set;
        }

        private decimal RemainAmount
        {
            get;
            set;
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

        private void grvPaymentDetails_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == colSlipNo)
                {
                    var selectedSlipDetails = (DataTable)grdPaymentDetails.DataSource;
                    if (selectedSlipDetails != null && selectedSlipDetails.Rows.Count > 0)
                    {
                        string SlipNo = grvPaymentDetails.GetRowCellValue(grvPaymentDetails.FocusedRowHandle, colSlipNo).ToString();
                        var isSlipAdded = selectedSlipDetails.Select("SlipNo = '" + SlipNo + "'");
                        if (isSlipAdded != null && isSlipAdded.Count() > 0)
                        {
                            MessageBox.Show("Slip already added on list, you can not add same slip again.");
                            this.grvPaymentDetails.CellValueChanged -= new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvPaymentDetails_CellValueChanged);
                            grvPaymentDetails.SetRowCellValue(e.RowHandle, colSlipNo, null);
                            this.grvPaymentDetails.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvPaymentDetails_CellValueChanged);
                            return;
                        }
                    }

                    decimal TotalAdjustedAmount = Convert.ToDecimal(colAmount.SummaryItem.SummaryValue);
                    if (TotalAmount <= TotalAdjustedAmount)
                    {
                        MessageBox.Show("You can not adjust more amount as max limit fullfiled.");
                        this.grvPaymentDetails.CellValueChanged -= new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvPaymentDetails_CellValueChanged);
                        grvPaymentDetails.SetRowCellValue(e.RowHandle, colSlipNo, null);
                        this.grvPaymentDetails.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvPaymentDetails_CellValueChanged);
                        return;
                    }

                    decimal Amount = Convert.ToDecimal(((System.Data.DataRowView)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).Row.ItemArray[10]);
                    decimal AdjustAmount = 0;

                    if (TotalAdjustedAmount == 0)
                        RemainAmount = TotalAmount;
                    else
                        RemainAmount = TotalAmount - TotalAdjustedAmount;

                    if (RemainAmount <= Amount)
                    {
                        AdjustAmount = RemainAmount;
                    }
                    else
                    {
                        AdjustAmount = Amount;
                    }

                    this.grvPaymentDetails.CellValueChanged -= new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvPaymentDetails_CellValueChanged);
                    grvPaymentDetails.SetRowCellValue(e.RowHandle, colAmount, AdjustAmount);
                    grvPaymentDetails.SetRowCellValue(e.RowHandle, colAAmount, Amount);

                    grvPaymentDetails.SetRowCellValue(e.RowHandle, colDate, ((System.Data.DataRowView)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).Row.ItemArray[1]);
                    //grvPaymentDetails.SetRowCellValue(e.RowHandle, colSlipNo, ((System.Data.DataRowView)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).Row.ItemArray[4]);
                    grvPaymentDetails.SetRowCellValue(e.RowHandle, colPartyId, ((System.Data.DataRowView)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).Row.ItemArray[2]);
                    grvPaymentDetails.SetRowCellValue(e.RowHandle, colParty, ((System.Data.DataRowView)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).Row.ItemArray[3]);
                    grvPaymentDetails.SetRowCellValue(e.RowHandle, colCompanyId, ((System.Data.DataRowView)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).Row.ItemArray[5]);
                    grvPaymentDetails.SetRowCellValue(e.RowHandle, colBranchId, ((System.Data.DataRowView)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).Row.ItemArray[6]);
                    grvPaymentDetails.SetRowCellValue(e.RowHandle, colFinancialYearId, ((System.Data.DataRowView)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).Row.ItemArray[7]);
                    grvPaymentDetails.SetRowCellValue(e.RowHandle, colYear, ((System.Data.DataRowView)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).Row.ItemArray[8]);
                    grvPaymentDetails.SetRowCellValue(e.RowHandle, colTAmount, ((System.Data.DataRowView)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).Row.ItemArray[9]);
                    this.grvPaymentDetails.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvPaymentDetails_CellValueChanged);

                    RemainAmount = RemainAmount - AdjustAmount;
                    lblTotalAmount.Text = TotalAmount.ToString();
                    lblRemainAmount.Text = RemainAmount.ToString();
                }
                else if (e.Column == colAmount)
                {
                    grvPaymentDetails.UpdateCurrentRow();
                    decimal TotalAdjustedAmount = Convert.ToDecimal(colAmount.SummaryItem.SummaryValue);
                    if (TotalAmount < TotalAdjustedAmount)
                    {
                        MessageBox.Show("You can not adjust more amount as max limit fullfiled.");
                        this.grvPaymentDetails.CellValueChanged -= new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvPaymentDetails_CellValueChanged);
                        grvPaymentDetails.SetRowCellValue(e.RowHandle, colAmount, 0);
                        this.grvPaymentDetails.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvPaymentDetails_CellValueChanged);
                        return;
                    }
                }
            }
            catch
            {

            }
        }

        private void FrmPaymentSlipSelect_Load(object sender, EventArgs e)
        {
            GetBalance();
        }

        private void GetBalance()
        {
            decimal TotalAdjustedAmount = Convert.ToDecimal(colAmount.SummaryItem.SummaryValue);
            if (TotalAdjustedAmount == 0)
                RemainAmount = TotalAmount;
            else
                RemainAmount = TotalAmount - TotalAdjustedAmount;

            lblTotalAmount.Text = TotalAmount.ToString();
            lblRemainAmount.Text = RemainAmount.ToString();
        }
    }
}