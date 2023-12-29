using DevExpress.XtraEditors;
using EFCore.SQL.Repository;
using Repository.Entities;
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
    public partial class FrmSlipTransfer : DevExpress.XtraEditors.XtraForm
    {
        private string BranchId { get; set; }
        private string FinancialYearId { get; set; }

        public FrmSlipTransfer()
        {
            InitializeComponent();
        }

        public FrmSlipTransfer(string CompanyId, int SlipType, string SlipNo, decimal TotalAmount, string SrNo, List<SlipTransferEntry> slipTransferEntry, string branchId, string financialYearId)
        {
            InitializeComponent();

            dtDate.EditValue = DateTime.Now;
            dtTime.EditValue = DateTime.Now;

            _ = LoadCompany();
            GetSlipTypes();
            grdParticularsDetails.DataSource = GetDTColumnsforParticularDetails();

            lueCompany.EditValue = CompanyId;
            lueSlipType.EditValue = SlipType;
            txtSlipNo.Text = SlipNo.ToString();
            txtTotalAmount.Text = TotalAmount.ToString("0.00");
            SlipTransferDetails = slipTransferEntry;
            BranchId = branchId;
            FinancialYearId = financialYearId;


            txtSerialNo.Text = SrNo;
            if (SlipTransferDetails.Count > 0)
            {
                for (int i = 0; i < SlipTransferDetails.Count; i++)
                {
                    grvParticularsDetails.AddNewRow();
                    grvParticularsDetails.SetFocusedRowCellValue(colParty, SlipTransferDetails[i].Party);
                    grvParticularsDetails.SetFocusedRowCellValue(colAmount, SlipTransferDetails[i].Amount);
                    grvParticularsDetails.SetFocusedRowCellValue(colPercentage, SlipTransferDetails[i].Percentage);
                    grvParticularsDetails.SetFocusedRowCellValue(colDays, SlipTransferDetails[i].Days);
                    grvParticularsDetails.SetFocusedRowCellValue(colTotal, SlipTransferDetails[i].Total);
                    grvParticularsDetails.UpdateCurrentRow();
                }
            }
        }

        public List<SlipTransferEntry> SlipTransferDetails { get; set; }

        private void FrmSlipTransfer_Load(object sender, EventArgs e)
        {
            
        }

        private async Task LoadCompany()
        {
            CompanyMasterRepository companyMasterRepository = new CompanyMasterRepository();
            var companies = await companyMasterRepository.GetUserCompanyMappingAsync(Common.LoginUserID);
            lueCompany.Properties.DataSource = companies;
            lueCompany.Properties.DisplayMember = "Name";
            lueCompany.Properties.ValueMember = "Id";

            lueCompany.EditValue = Common.LoginCompany;
        }

        private void GetSlipTypes()
        {
            var slipTypes = SlipType.GetSlipTypes();

            if (slipTypes != null)
            {
                lueSlipType.Properties.DataSource = slipTypes;
                lueSlipType.Properties.DisplayMember = "Name";
                lueSlipType.Properties.ValueMember = "Id";
            }
        }

        private static DataTable GetDTColumnsforParticularDetails()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Party");
            dt.Columns.Add("Amount");
            dt.Columns.Add("Percentage");
            dt.Columns.Add("Days");
            dt.Columns.Add("Total");
            return dt;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<SlipTransferEntry> slipTransferEntryList = new List<SlipTransferEntry>();
            SlipTransferEntry slipTransfer;
            for (int i = 0; i < grvParticularsDetails.RowCount; i++)
            {
                slipTransfer = new SlipTransferEntry();
                slipTransfer.Id = Guid.NewGuid().ToString();
                slipTransfer.SrNo = Convert.ToInt32(txtSerialNo.Text);
                slipTransfer.Party = grvParticularsDetails.GetRowCellValue(i, colParty).ToString();
                slipTransfer.PurchaseSaleId = "";
                slipTransfer.SlipType = Convert.ToInt32(lueSlipType.EditValue);
                slipTransfer.SlipTransferEntryDate = Convert.ToDateTime(dtDate.Text);
                slipTransfer.Amount = decimal.Parse(grvParticularsDetails.GetRowCellValue(i, colAmount).ToString());
                slipTransfer.Percentage = decimal.Parse(grvParticularsDetails.GetRowCellValue(i, colPercentage).ToString());
                slipTransfer.Days = Convert.ToInt32(grvParticularsDetails.GetRowCellValue(i, colDays).ToString());
                slipTransfer.Total = decimal.Parse(grvParticularsDetails.GetRowCellValue(i, colTotal).ToString());
                slipTransfer.Message = txtRemark.Text;
                slipTransfer.BranchId = BranchId;
                slipTransfer.FinancialYearId = FinancialYearId;
                slipTransfer.CreatedBy = Common.LoginUserID;
                slipTransfer.CreatedDate = DateTime.Now;
                slipTransfer.UpdatedBy = Common.LoginUserID;
                slipTransfer.UpdatedDate = DateTime.Now;
                slipTransferEntryList.Insert(i, slipTransfer);
            }

            SlipTransferDetails = slipTransferEntryList;

            this.DialogResult = DialogResult.OK;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            grdParticularsDetails.DataSource = null;
            grdParticularsDetails.DataSource = GetDTColumnsforParticularDetails();
        }

        private void grvParticularsDetails_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == colAmount || e.Column == colPercentage || e.Column == colDays)
                {
                    decimal Amount = 0;
                    if (grvParticularsDetails.GetRowCellValue(e.RowHandle, colAmount) != null && grvParticularsDetails.GetRowCellValue(e.RowHandle, colAmount).ToString().Length != 0)
                        Amount = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(e.RowHandle, colAmount));

                    decimal Percentage = 0;
                    if (grvParticularsDetails.GetRowCellValue(e.RowHandle, colPercentage) != null && grvParticularsDetails.GetRowCellValue(e.RowHandle, colPercentage).ToString().Length != 0)
                        Percentage = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(e.RowHandle, colPercentage));

                    int Days = 0;
                    if (grvParticularsDetails.GetRowCellValue(e.RowHandle, colDays) != null && grvParticularsDetails.GetRowCellValue(e.RowHandle, colDays).ToString().Length != 0)
                        Days = Convert.ToInt32(grvParticularsDetails.GetRowCellValue(e.RowHandle, colDays));

                    decimal Total = Amount + (Amount * Percentage * Days);
                    grvParticularsDetails.SetRowCellValue(e.RowHandle, colTotal, Total);
                }
            }
            catch (Exception Ex)
            {
                grvParticularsDetails.SetRowCellValue(e.RowHandle, colTotal, 0);
            }
        }
    }
}