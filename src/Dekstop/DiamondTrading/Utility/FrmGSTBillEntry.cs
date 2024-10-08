﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using CrystalDecisions.CrystalReports.Engine;
using DevExpress.Printing.Core.PdfExport.Metafile;
using DiamondTrading.Reports;
using EFCore.SQL.Repository;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Identity.Client;
using Repository.Entities;
using static DevExpress.XtraPrinting.Native.ExportOptionsPropertiesNames;

namespace DiamondTrading.Utility
{
    public partial class FrmGSTBillEntry : DevExpress.XtraEditors.XtraForm
    {
        PartyMasterRepository _partyMasterRepository;
        LoanMasterRepository _loanMasterRepository;
        CompanyMasterRepository _companyMasterRepository;
        private readonly BillPrintRepository _gstBillPrintRepository;

        public FrmGSTBillEntry()
        {
            InitializeComponent();
            _partyMasterRepository = new PartyMasterRepository();
            _loanMasterRepository = new LoanMasterRepository();
            _companyMasterRepository = new CompanyMasterRepository();
            _gstBillPrintRepository = new BillPrintRepository();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmLoanEntry_Load(object sender, EventArgs e)
        {
            dtInvoiceDate.EditValue = DateTime.Now;
            dtTime.EditValue = DateTime.Now;

            _ = LoadLastRecord();
            //_ = LoadParty();

            //_ = LoadCompany();

            //_ = GetMaxSrNo();

            //_ = LoadCashank();

            //lueReceiveFrom.Properties.DataSource = Common.GetLoanType();
            //lueReceiveFrom.Properties.DisplayMember = "Name";
            //lueReceiveFrom.Properties.ValueMember = "Id";

            //lueReverseCharges.Properties.DataSource = Common.GetLoanDuration();
            //lueReverseCharges.Properties.DisplayMember = "Name";
            //lueReverseCharges.Properties.ValueMember = "Id";
        }

        private async Task LoadLastRecord()
        {
            var lastRecord = await _gstBillPrintRepository.GetLastRecord(Common.LoginCompany, Common.LoginBranch, Common.LoginFinancialYear);
            if (lastRecord.Any())
            {
                txtTitle.Text = lastRecord.FirstOrDefault().Title;
                txtGSTNo.Text = lastRecord.FirstOrDefault().GSTN;
                txtPanNo.Text = lastRecord.FirstOrDefault().PAN;
                txtInvoiceNo.Text = lastRecord.FirstOrDefault().InvoiceNo;
                dtInvoiceDate.DateTime = lastRecord.FirstOrDefault().InvoiceDate;
                dtSupplyDate.DateTime = lastRecord.FirstOrDefault().DateOfSupply;
                txtSupplyPlace.Text = lastRecord.FirstOrDefault().PlaceOfSupply;
                txtTerms.Text = lastRecord.FirstOrDefault().Terms;
                txtState.Text = lastRecord.FirstOrDefault().State;
                txtCode.Text = lastRecord.FirstOrDefault().Code;
                txtReverseCharges.Text = lastRecord.FirstOrDefault().ReverseCharge;
                txtTCSApplicable.Text = lastRecord.FirstOrDefault().TCSApplicable;


                txtBillParty.Text = lastRecord.FirstOrDefault().BillPartyName;
                txtBillAddress.Text = lastRecord.FirstOrDefault().BillPartyAddress;
                txtBillGST.Text = lastRecord.FirstOrDefault().BillPartyGSTIN;
                txtBillPan.Text = lastRecord.FirstOrDefault().BillPartyPAN;
                txtBillState.Text = lastRecord.FirstOrDefault().BillPartyState;
                txtBillCode.Text = lastRecord.FirstOrDefault().BillPartyCode;


                txtShipName.Text = lastRecord.FirstOrDefault().ShipPartyName;
                txtShipAddress.Text = lastRecord.FirstOrDefault().ShipPartyAddress;
                txtShipGST.Text = lastRecord.FirstOrDefault().ShipPartyGSTIN;
                txtShipPAN.Text = lastRecord.FirstOrDefault().ShipPartyPAN;
                txtShipState.Text = lastRecord.FirstOrDefault().ShipPartyState;
                txtShipCode.Text = lastRecord.FirstOrDefault().ShipPartyCode;


                txtDeclaration.Text = lastRecord.FirstOrDefault().Declaration;
                txtAmountBeforeTax.Text = lastRecord.FirstOrDefault().AmountBeforeTax.ToString();
                txtSGST.Text = lastRecord.FirstOrDefault().SGST.ToString();
                txtCGST.Text = lastRecord.FirstOrDefault().CGST.ToString();
                txtIGST.Text = lastRecord.FirstOrDefault().IGST.ToString();
                txtTCS.Text = lastRecord.FirstOrDefault().TCS.ToString();
                txtAmount.Text = lastRecord.FirstOrDefault().TotalAmount.ToString();

                txtGSTReverseCharge.Text = lastRecord.FirstOrDefault().GstOnReverseCharge.ToString();


                txtBankName.Text = lastRecord.FirstOrDefault().BankName;
                txtAccountNo.Text = lastRecord.FirstOrDefault().AccountNo;
                txtIFSC.Text = lastRecord.FirstOrDefault().IFSC;

                txtAmountInWord.Text = lastRecord.FirstOrDefault().AmountInWords;

                DataTable dt = CreateDataTable(lastRecord.FirstOrDefault());
                grdPaymentDetails.DataSource = dt;
            }
        }

        private async Task GetMaxSrNo()
        {
            var SrNo = await _loanMasterRepository.GetMaxSrNo(Common.LoginCompany.ToString());
            //txtSerialNo.Text = SrNo.ToString();
        }

        private async Task LoadCompany()
        {
            var result = await _companyMasterRepository.GetUserCompanyMappingAsync(Common.LoginUserID);
            //lueCompany.Properties.DataSource = result;
            //lueCompany.Properties.DisplayMember = "Name";
            //lueCompany.Properties.ValueMember = "Id";

            //lueCompany.EditValue = Common.LoginCompany;
        }

        private async Task LoadCashank()
        {
            var result = await _partyMasterRepository.GetAllPartyAsync(Common.LoginCompany, new int[] { 4, 5 });
            //lueCashBank.Properties.DataSource = result;
            //lueCashBank.Properties.DisplayMember = "Name";
            //lueCashBank.Properties.ValueMember = "Id";

            //lueCashBank.EditValue = Common.LoginCompany;
        }

        private async Task LoadParty()
        {
            var result = await _partyMasterRepository.GetAllPartyAsync(Common.LoginCompany, 13);
            //lueParty.Properties.DataSource = result;
            //lueParty.Properties.DisplayMember = "Name";
            //lueParty.Properties.ValueMember = "Id";
        }

        private DataTable CreateDataTable(BillPrintModel billPrintModel)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ProductDescription", typeof(string));
            dt.Columns.Add("HSNCode", typeof(string));
            dt.Columns.Add("UOM", typeof(string));
            dt.Columns.Add("Qty", typeof(int));
            dt.Columns.Add("Rate", typeof(int));
            dt.Columns.Add("Amount", typeof(int));
            dt.Columns.Add("Discount", typeof(int));
            dt.Columns.Add("TaxableValue", typeof(int));
            dt.Columns.Add("Total", typeof(int));
            
            dt.Rows.Add(billPrintModel.ProductDescription, billPrintModel.HSNCode, billPrintModel.UOM, billPrintModel.Qty, billPrintModel.Rate,
                billPrintModel.Amount, billPrintModel.Discount, billPrintModel.TaxableValue, billPrintModel.TotalAmount);
            return dt;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int groupId = await _gstBillPrintRepository.GetMaxGroupNo(Common.LoginCompany, Common.LoginBranch, Common.LoginFinancialYear);
                for (int i = 0; i < grvPaymentDetails.RowCount; i++)
                {
                    var billModel = new BillPrintModel
                    {
                        Title = txtTitle.Text,
                        GSTN = txtGSTNo.Text,
                        PAN = txtPanNo.Text,
                        InvoiceNo = txtInvoiceNo.Text,
                        InvoiceDate = dtInvoiceDate.DateTime,
                        DateOfSupply = dtSupplyDate.DateTime,
                        PlaceOfSupply = txtSupplyPlace.Text,
                        Terms = txtTerms.Text,
                        State = txtState.Text,
                        Code = txtCode.Text,
                        ReverseCharge = txtReverseCharges.Text,
                        TCSApplicable = txtTCSApplicable.Text,

                        BillPartyName = txtBillParty.Text,
                        BillPartyAddress = txtBillAddress.Text,
                        BillPartyGSTIN = txtBillGST.Text,
                        BillPartyPAN = txtBillPan.Text,
                        BillPartyState = txtBillState.Text,
                        BillPartyCode = txtBillCode.Text,

                        ShipPartyName = txtShipName.Text,
                        ShipPartyAddress = txtShipAddress.Text,
                        ShipPartyGSTIN = txtShipGST.Text,
                        ShipPartyPAN = txtShipPAN.Text,
                        ShipPartyState = txtShipState.Text,
                        ShipPartyCode = txtShipCode.Text,

                        Declaration = txtDeclaration.Text,
                        AmountBeforeTax = Convert.ToDecimal(txtAmountBeforeTax.Text),
                        SGST = Convert.ToDecimal(txtSGST.Text),
                        CGST = Convert.ToDecimal(txtCGST.Text),
                        IGST = Convert.ToDecimal(txtIGST.Text),
                        TCS = Convert.ToDecimal(txtTCS.Text),
                        TotalAmount = Convert.ToDecimal(txtAmount.Text),
                        AmountInWords = txtAmountInWord.Text,

                        GstOnReverseCharge = Convert.ToDecimal(txtGSTReverseCharge.Text),

                        BankName = txtBankName.Text,
                        AccountNo = txtAccountNo.Text,
                        IFSC = txtIFSC.Text,
                        CompanyId = Common.LoginCompany,
                        BranchId = Common.LoginBranch,
                        FinancialYearId = Common.LoginFinancialYear,
                        GroupId = groupId,
                        FinalTotal = Convert.ToDecimal(txtAmount.Text),
                        TaxableValue = 5000,
                        TotalTaxValue = 5000,
                        TotalGridAmount = 25000,
                        SrNo = (i + 1).ToString()
                    };

                    billModel.ProductDescription = grvPaymentDetails.GetRowCellDisplayText(i, colDesc);
                    billModel.HSNCode = grvPaymentDetails.GetRowCellDisplayText(i, colHSNCode);
                    billModel.UOM = grvPaymentDetails.GetRowCellDisplayText(i, colUOM);
                    billModel.Qty = grvPaymentDetails.GetRowCellValue(i, colQty) == DBNull.Value ? 0 : Convert.ToDecimal(grvPaymentDetails.GetRowCellValue(i, colQty));
                    billModel.Rate = grvPaymentDetails.GetRowCellValue(i, colRate) == DBNull.Value ? 0 : Convert.ToDecimal(grvPaymentDetails.GetRowCellValue(i, colRate));
                    billModel.Amount = grvPaymentDetails.GetRowCellValue(i, colAmount) == DBNull.Value ? 0 : Convert.ToDecimal(grvPaymentDetails.GetRowCellValue(i, colAmount));
                    billModel.TaxableValue = grvPaymentDetails.GetRowCellValue(i, colTaxableValue) == DBNull.Value ? 0 : Convert.ToDecimal(grvPaymentDetails.GetRowCellValue(i, colTaxableValue));
                    billModel.Discount = grvPaymentDetails.GetRowCellValue(i, colDiscount) == DBNull.Value ? 0 : Convert.ToDecimal(grvPaymentDetails.GetRowCellValue(i, colDiscount));
                    billModel.TotalRow = grvPaymentDetails.GetRowCellValue(i, colTotal) == DBNull.Value ? 0 : Convert.ToDecimal(grvPaymentDetails.GetRowCellValue(i, colTotal));
                    await _gstBillPrintRepository.SaveBill(billModel);
                }

                MessageBox.Show(AppMessages.GetString(AppMessageID.SaveSuccessfully), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error : " + Ex.Message.ToString(), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                try
                {
                    // Create a BillPrintModel instance and populate it with data from your SQL table.
                    List<BillPrintModel> billData = await _gstBillPrintRepository.GetLastRecord(Common.LoginCompany, Common.LoginBranch, Common.LoginFinancialYear);

                    this.Cursor = Cursors.Default;

                    // Create a ReportDocument instance for your Crystal Report.
                    ReportDocument report = new ReportDocument();

                    // Set the path to your GSTInvoice.rpt file.
                    report.Load(Path.Combine(Application.StartupPath, "Reports", "GSTInvoice.rpt"));

                    // Set the report's data source to your BillPrintModel.
                    report.SetDataSource(billData);

                    ReportViewer viewer = new ReportViewer();
                    viewer.LoadReport(report);
                    viewer.ShowDialog();
                }
                catch (Exception iEX)
                {
                    MessageBox.Show(iEX.Message + " | " + iEX.StackTrace, "Error", MessageBoxButtons.OK);
                }
            }


            //bool IsSucess = false;
            //try
            //{
            //    LoanMaster loanMaster = new LoanMaster()
            //    {
            //        Id = Guid.NewGuid().ToString(),
            //        PartyId = lueParty.EditValue.ToString(),
            //        CashBankPartyId = lueCashBank.EditValue.ToString(),
            //        Amount = decimal.Parse(txtAmount.Text),
            //        CompanyId = lueCompany.EditValue.ToString(),
            //        CreatedBy = Common.LoginCompany.ToString(),
            //        CreatedDate = DateTime.Now,
            //        DuratonType = (int)lueReverseCharges.EditValue,
            //        EndDate = dateEnd.DateTime,
            //        StartDate  = dateStart.DateTime,
            //        InterestRate = decimal.Parse(txtInterestRate.Text),
            //        IsDelete = false,
            //        LoanType = int.Parse(lueReceiveFrom.EditValue.ToString()),
            //        NetAmount = decimal.Parse(txtNetAmount.Text),
            //        Remarks = txtRemark.Text,
            //        TotalInterest = decimal.Parse(txtTotalInterest.Text),
            //        UpdatedBy = Common.LoginUserID,
            //        UpdatedDate = DateTime.Now
            //    };

            //    await _loanMasterRepository.AddLoanAsync(loanMaster);
            //    IsSucess = true;
            //}
            //catch (Exception Ex)
            //{
            //    IsSucess = false;
            //    MessageBox.Show("Error : " + Ex.Message.ToString(), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //finally
            //{
            //    this.Cursor = Cursors.Default;
            //}
            //if (IsSucess)
            //{
            //    MessageBox.Show(AppMessages.GetString(AppMessageID.SaveSuccessfully), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    ResetForm();
            //}
        }

        private void ResetForm()
        {
            //txtAmount.Text = "";
            //txtInterestRate.Text = "";
            //txtNetAmount.Text = "";
            //txtTotalInterest.Text = "";
            //txtRemark.Text = "";
            //lueReceiveFrom.Focus();
        }

        private void txtInterestRate_EditValueChanged(object sender, EventArgs e)
        {
            CalculateInterest();
        }

        private void CalculateInterest()
        {
            //string amount = txtAmount.Text == "" ? "0" : txtAmount.Text;
            //string interestRate = txtInterestRate.Text == "" ? "0" : txtInterestRate.Text;

            //DateTime startDate = dateStart.DateTime;
            //DateTime endDate = dateEnd.DateTime;

            //TimeSpan difference = endDate - startDate;

            //decimal interestAmount = (Convert.ToDecimal(amount) * Convert.ToDecimal(interestRate)) / 100;

            //if (Convert.ToInt32(lueReverseCharges.EditValue) == 1)
            //{
            //    txtTotalInterest.Text = (Convert.ToDouble(interestAmount) * difference.TotalDays).ToString();
            //    txtNetAmount.Text = Math.Round(Convert.ToDecimal(amount) + Convert.ToDecimal(txtTotalInterest.Text)).ToString();
            //}
            //else if (Convert.ToInt32(lueReverseCharges.EditValue) == 2 || Convert.ToInt32(lueReverseCharges.EditValue) == 3 || Convert.ToInt32(lueReverseCharges.EditValue) == 4 || Convert.ToInt32(lueReverseCharges.EditValue) == 5)
            //{
            //    txtTotalInterest.Text = (Convert.ToDouble(interestAmount) * (Math.Abs((startDate.Month - endDate.Month) + 12 * (startDate.Year - endDate.Year)))).ToString();
            //    txtNetAmount.Text = Math.Round(Convert.ToDecimal(amount) + Convert.ToDecimal(txtTotalInterest.Text)).ToString();
            //}
        }

        private void lueDuration_EditValueChanged(object sender, EventArgs e)
        {
            //int lueDurations = Convert.ToInt32(lueReverseCharges.EditValue.ToString());

            //if(lueDurations == 1) //Daily
            //{
            //    dateStart.DateTime = DateTime.Now;
            //    dateEnd.DateTime = DateTime.Now;
            //}
            //else if(lueDurations == 2) //Monthly
            //{
            //    dateStart.DateTime = DateTime.Now;
            //    dateEnd.DateTime = new DateTime(DateTime.Now.Ticks).AddMonths(1);
            //} 
            //else if(lueDurations == 3) // 3 Month
            //{
            //    dateStart.DateTime = DateTime.Now;
            //    dateEnd.DateTime = new DateTime(DateTime.Now.Ticks).AddMonths(3);
            //}
            //else if(lueDurations == 4) //6 Month 
            //{
            //    dateStart.DateTime = DateTime.Now;
            //    dateEnd.DateTime = new DateTime(DateTime.Now.Ticks).AddMonths(6);
            //}
            //else if(lueDurations == 5) //12 Month
            //{
            //    dateStart.DateTime = DateTime.Now;
            //    dateEnd.DateTime = new DateTime(DateTime.Now.Ticks).AddMonths(12);
            //}
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void dateStart_EditValueChanged(object sender, EventArgs e)
        {
            CalculateInterest();
        }

        private void dateEnd_EditValueChanged(object sender, EventArgs e)
        {
            CalculateInterest();
        }

        private void txtAmount_EditValueChanged(object sender, EventArgs e)
        {
            CalculateInterest();
        }

        private void FrmLoanEntry_KeyDown(object sender, KeyEventArgs e)
        {
            Common.MoveToNextControl(sender, e, this);
        }

        private async void NewEntry(object sender, KeyEventArgs e)
        {
            //string ControlName = ((DevExpress.XtraEditors.LookUpEdit)sender).Name;
            //if (e.Control && e.KeyCode == Keys.N)
            //{
            //    if (ControlName == lueParty.Name)
            //    {
            //        Master.FrmPartyMaster frmPartyMaster = new Master.FrmPartyMaster();
            //        frmPartyMaster.IsSilentEntry = true;
            //        frmPartyMaster.LedgerType = PartyTypeMaster.Loan;
            //        if (frmPartyMaster.ShowDialog() == DialogResult.OK)
            //        {
            //            await LoadParty();
            //            lueParty.EditValue = frmPartyMaster.CreatedLedgerID;
            //        }
            //    }
            //}
        }

        private void labelControl11_Click(object sender, EventArgs e)
        {

        }
    }
}