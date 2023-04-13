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
        public FrmSlipTransfer()
        {
            InitializeComponent();
        }

        public FrmSlipTransfer(string CompanyId, int SlipType, string SlipNo, decimal TotalAmount, string SrNo, List<SlipTransferEntry> slipTransferEntry)
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
            var companies = await companyMasterRepository.GetAllCompanyAsync();
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
                slipTransfer.Message = txtRemark.Text;
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
    }
}