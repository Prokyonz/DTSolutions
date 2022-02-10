using DevExpress.XtraEditors;
using EFCore.SQL.Repository;
using Repository.Entities;
using Repository.Entities.Model;
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
    public partial class FrmPaymentEntry : DevExpress.XtraEditors.XtraForm
    {
        private readonly CompanyMasterRepository _companyMasterRepository;
        private readonly PartyMasterRepository _partyMasterRepository;
        private PaymentMasterRepository _paymentMaterRepository;
        private readonly ContraEntryMasterRespository _contraEntryRepository;
        int _paymentType = 0;
        DataTable dtSlipDetail;

        public FrmPaymentEntry(string PaymentType)
        {
            InitializeComponent();

            _companyMasterRepository = new CompanyMasterRepository();
            _partyMasterRepository = new PartyMasterRepository();
            _paymentMaterRepository = new PaymentMasterRepository();
            _contraEntryRepository = new ContraEntryMasterRespository();

            if (PaymentType == "Payment")
            {
                _paymentType = 0;
                SetThemeColors(Color.FromArgb(250, 243, 197));
                this.Text = "PAYMENT";
            }
            else if(PaymentType == "Receipt")
            {
                _paymentType = 1;
                SetThemeColors(Color.FromArgb(215, 246, 214));
                this.Text = "RECEIPT";
            } 
            else
            {
                _paymentType = -1;
                SetThemeColors(Color.FromArgb(217, 217, 217));
                this.Text = "CONTRA";
            }
        }

        private async void LoadSeries(int paymentType)
        {
            grdPaymentDetails.DataSource = GetDTColumnsForPaymentDetails();
            if (paymentType == -1)
            {
                var result = await _contraEntryRepository.GetMaxNo(lueCompany.EditValue.ToString(), Common.LoginFinancialYear);
                txtSerialNo.Text = result.ToString();
            }
            else
            {
                var result = await _paymentMaterRepository.GetMaxSrNoAsync(paymentType, lueCompany.EditValue.ToString(), Common.LoginFinancialYear);
                txtSerialNo.Text = result.ToString();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblFormTitle_Click(object sender, EventArgs e)
        {

        }

        private async void FrmPaymentEntry_Load(object sender, EventArgs e)
        {
            dtDate.EditValue = DateTime.Now;
            dtTime.EditValue = DateTime.Now;

            await LoadCompany();
            LoadSeries(_paymentType);
            LoadLedgers(lueCompany.EditValue.ToString());
        }

        private static DataTable GetDTColumnsForPaymentDetails()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Party");
            dt.Columns.Add("Amount");
            dt.Columns.Add("AutoAdjustBillAmount");
            return dt;
        }

        private void SetThemeColors(Color color)
        {
            if (!color.ToArgb().ToString().Equals(Color.FromArgb(0).Name))
            {
                grpGroup1.AppearanceCaption.BorderColor = color;
                grpGroup2.AppearanceCaption.BorderColor = color;

                //txtLedgerBalance.BackColor = color;
            }
        }

        private async Task LoadCompany()
        {
            var result = await _companyMasterRepository.GetAllCompanyAsync();
            lueCompany.Properties.DataSource = result;
            lueCompany.Properties.DisplayMember = "Name";
            lueCompany.Properties.ValueMember = "Id";
            lueCompany.EditValue = Common.LoginCompany;
        }

        private async void LoadLedgers(string companyId)
        {
            if (_paymentType == -1)
            {
                var result = await _partyMasterRepository.GetAllPartyAsync(companyId, new int[] { 4,5});
                lueLeadger.Properties.DataSource = result;
                lueLeadger.Properties.DisplayMember = "Name";
                lueLeadger.Properties.ValueMember = "Id";

                repoParty.DataSource = result;
                repoParty.DisplayMember = "Name";
                repoParty.ValueMember = "Id";
            }
            else
            {
                var result = await _partyMasterRepository.GetAllPartyAsync(companyId);
                lueLeadger.Properties.DataSource = result.Where(x=>x.Type==PartyTypeMaster.Cash || x.Type == PartyTypeMaster.Bank);
                lueLeadger.Properties.DisplayMember = "Name";
                lueLeadger.Properties.ValueMember = "Id";

                repoParty.DataSource = result.Where(x => x.Type != PartyTypeMaster.Cash && x.Type != PartyTypeMaster.Bank);
                repoParty.DisplayMember = "Name";
                repoParty.ValueMember = "Id";

                List<PaymentPSSlipDetails> PaymentSlipDetails = await _paymentMaterRepository.GetPaymentPSSlipDetails(lueCompany.EditValue.ToString(), _paymentType.ToString());
                dtSlipDetail = Common.ToDataTable<PaymentPSSlipDetails>(PaymentSlipDetails);
            }
        }

        private async void lueLeadger_EditValueChanged(object sender, EventArgs e)
        {
            if (lueLeadger.EditValue != null)
            {
                var result = await _partyMasterRepository.GetPartyBalance(lueLeadger.EditValue.ToString());
                string CrDr = "Cr";
                if(Convert.ToInt32(result)<0)
                {
                    CrDr = "Dr";
                }
                txtLedgerBalance.Text = result.ToString("0.00") + " " + CrDr;
            }
        }

        private void grvPurchaseDetails_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            //string ControlName = ((DevExpress.XtraEditors.LookUpEdit)sender).Name;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                
                //Contra Entry
                if (_paymentType == -1)
                {
                    string contraMasterId = Guid.NewGuid().ToString();
                    List<ContraEntryDetails> contraEntryDetails = new List<ContraEntryDetails>();

                    for (int i = 0; i < grvPaymentDetails.RowCount; i++)
                    {
                        ContraEntryDetails contraDetail = new ContraEntryDetails();
                        string fromPartyId = grvPaymentDetails.GetRowCellValue(i, colParty).ToString();
                        string amount = grvPaymentDetails.GetRowCellValue(i, colAmount).ToString();

                        contraDetail.Id = Guid.NewGuid().ToString();
                        contraDetail.ContraEntryMasterId = contraMasterId;
                        contraDetail.Amount = Convert.ToDecimal(amount);
                        contraDetail.FromParty = fromPartyId;
                        contraDetail.CreatedDate = DateTime.Now;
                        contraDetail.UpdatedDate = DateTime.Now;
                        contraDetail.CreatedBy = Common.LoginUserID;
                        contraDetail.UpdatedBy = Common.LoginUserID;
                        contraEntryDetails.Add(contraDetail);
                    }

                    ContraEntryMaster contraEntryMaster = new ContraEntryMaster
                    {
                        Id = contraMasterId,
                        BranchId = Common.LoginBranch,
                        CompanyId = lueCompany.EditValue.ToString(),
                        FinancialYearId = Common.LoginFinancialYear,                        
                        IsDelete = false,
                        Remarks = txtRemark.Text,
                        ToPartyId = lueLeadger.EditValue.ToString(),
                        ContraEntryDetails = contraEntryDetails,
                        CreatedBy = Common.LoginUserID,
                        CreatedDate = DateTime.Now,
                        UpdatedBy = Common.LoginUserID,
                        UpdatedDate = DateTime.Now,
                    };

                    var result = await _contraEntryRepository.AddContraEntryAsync(contraEntryMaster);

                    if (result != null)
                    {
                        Reset();
                        MessageBox.Show(AppMessages.GetString(AppMessageID.SaveSuccessfully), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    string groupId = Guid.NewGuid().ToString();
                    List<PaymentMaster> paymentMasters = new List<PaymentMaster>();
                    List<PaymentDetails> listPaymentDetails = new List<PaymentDetails>();
                    PaymentDetails paymentDetails;
                    for (int i = 0; i < grvPaymentDetails.RowCount; i++)
                    {
                        string paymentMasterId = Guid.NewGuid().ToString();

                        if (dtSlipDetail.Columns.Contains("Amount"))
                        {
                            DataView dbView = new DataView(dtSlipDetail);
                            dbView.RowFilter = "isnull(Amount,0)<>0 and PartyId='" + grvPaymentDetails.GetRowCellValue(i, colParty) + "'";
                            if (dbView.Count > 0)
                            {
                                foreach (DataRowView row in dbView)
                                {
                                    paymentDetails = new PaymentDetails
                                    {
                                        Id = Guid.NewGuid().ToString(),
                                        GroupId = groupId.ToString(),
                                        PaymentId = paymentMasterId,
                                        PurchaseId = row["PurchaseId"].ToString(),
                                        SlipNo = row["SlipNo"].ToString(),
                                        Amount = Convert.ToDecimal(row["Amount"]),
                                        CreatedBy = Guid.NewGuid().ToString(),
                                        CreatedDate = DateTime.Now,
                                        UpdatedBy = Common.LoginUserID.ToString(),
                                        UpdatedDate = DateTime.Now,
                                    };
                                    listPaymentDetails.Add(paymentDetails);
                                }
                            }
                        }

                        PaymentMaster paymentMaster = new PaymentMaster();
                        string fromPartyId = grvPaymentDetails.GetRowCellValue(i, colParty).ToString();
                        string amount = grvPaymentDetails.GetRowCellValue(i, colAmount).ToString();

                        paymentMaster.GroupId = groupId;
                        paymentMaster.Id = paymentMasterId;
                        paymentMaster.Amount = Convert.ToDecimal(amount);
                        paymentMaster.FromPartyId = fromPartyId;
                        paymentMaster.CreatedDate = DateTime.Now;
                        paymentMaster.UpdatedDate = DateTime.Now;
                        paymentMaster.PaymentDetails = listPaymentDetails;
                        paymentMasters.Add(paymentMaster);
                    }

                    GroupPaymentMaster groupPaymentMaster = new GroupPaymentMaster
                    {
                        Id = groupId,
                        BillNo = Convert.ToInt32(txtSerialNo.Text),
                        BranchId = Common.LoginBranch,
                        CompanyId = lueCompany.EditValue.ToString(),
                        FinancialYearId = Common.LoginFinancialYear,
                        IsDelete = false,
                        Remarks = txtRemark.Text,
                        ToPartyId = lueLeadger.EditValue.ToString(),
                        CrDrType = _paymentType,
                        PaymentMasters = paymentMasters,
                        CreatedBy = Common.LoginUserID,
                        UpdatedBy = Common.LoginUserID,
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                    };

                    var Result = await _paymentMaterRepository.AddPaymentAsync(groupPaymentMaster);

                    if (Result != null)
                    {
                        Reset();
                        MessageBox.Show(AppMessages.GetString(AppMessageID.SaveSuccessfully), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error : " + Ex.Message.ToString(), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void Reset()
        {
            dtDate.EditValue = DateTime.Now;
            dtTime.EditValue = DateTime.Now;
            grdPaymentDetails.DataSource = null;
            txtRemark.Text = "";
            txtLedgerBalance.Text = "0";
            lueLeadger.EditValue = null;
            LoadLedgers(lueCompany.EditValue.ToString());
            LoadSeries(_paymentType);
            lueLeadger.Focus();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void lueCompany_EditValueChanged(object sender, EventArgs e)
        {
            if (lueCompany.EditValue != null)
                LoadLedgers(lueCompany.EditValue.ToString());
        }

        private void FrmPaymentEntry_KeyDown(object sender, KeyEventArgs e)
        {
            Common.MoveToNextControl(sender, e, this);
        }

        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            try
            {
                if (_paymentType != -1)
                {
                    DataView dtView = new DataView(dtSlipDetail);
                    dtView.RowFilter = "PartyId='" + grvPaymentDetails.GetRowCellValue(grvPaymentDetails.FocusedRowHandle, colParty) + "'";
                    FrmPaymentSlipSelect frmPaymentSlipSelect = new FrmPaymentSlipSelect(dtView.ToTable());
                    if (string.IsNullOrEmpty(grvPaymentDetails.GetRowCellValue(grvPaymentDetails.FocusedRowHandle, colAutoAdjustBillAmount).ToString()))
                        frmPaymentSlipSelect.IsAutoAdjustBillAmount = true;
                    else
                        frmPaymentSlipSelect.IsAutoAdjustBillAmount = Convert.ToBoolean(grvPaymentDetails.GetRowCellValue(grvPaymentDetails.FocusedRowHandle, colAutoAdjustBillAmount));
                    if (frmPaymentSlipSelect.ShowDialog() == DialogResult.OK)
                    {
                        decimal a = Convert.ToDecimal(frmPaymentSlipSelect.dtSlipDetail.Compute("SUM(Amount)", string.Empty));
                        DataView dtView1 = new DataView(frmPaymentSlipSelect.dtSlipDetail);
                        //dtView1.RowFilter = "isnull(Amount,0)<>0";
                        if (dtView1.Count > 0)
                        {
                            foreach (DataRowView row in dtView1)
                            {
                                if (!dtSlipDetail.Columns.Contains("Amount"))
                                    dtSlipDetail.Columns.Add("Amount", typeof(decimal));

                                DataView dtView2 = new DataView(dtSlipDetail);
                                dtView2.RowFilter = "PartyId='" + row["PartyId"] + "' and SlipNo='" + row["SlipNo"] + "'";
                                if (dtView2.Count > 0)
                                {
                                    foreach (DataRowView subRow in dtView2)
                                    {
                                        subRow["Amount"] = 0;
                                    }
                                    dtView2[0].Row["Amount"] = row["Amount"];
                                }
                            }
                        }
                        this.grvPaymentDetails.CellValueChanged -= new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvPaymentDetails_CellValueChanged);
                        grvPaymentDetails.SetRowCellValue(grvPaymentDetails.FocusedRowHandle, colAmount, a);
                        grvPaymentDetails.SetRowCellValue(grvPaymentDetails.FocusedRowHandle, colAutoAdjustBillAmount, frmPaymentSlipSelect.IsAutoAdjustBillAmount);
                        this.grvPaymentDetails.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvPaymentDetails_CellValueChanged);
                    }
                }
            }
            catch
            {
            }
        }

        private void grvPaymentDetails_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colAmount && _paymentType != -1)
            {
                if (grvPaymentDetails.GetRowCellValue(e.RowHandle, colParty).ToString() != "")
                {
                    DataView dtView = new DataView(dtSlipDetail);
                    dtView.RowFilter = "PartyId='" + grvPaymentDetails.GetRowCellValue(grvPaymentDetails.FocusedRowHandle, colParty) + "'";
                    if (dtView.Count > 0)
                    {
                        decimal Value = Convert.ToDecimal(e.Value);
                        if (Value > 0)
                        {
                            if (!dtSlipDetail.Columns.Contains("Amount"))
                            {
                                DataColumn column = new DataColumn();
                                column.ColumnName = "Amount";
                                column.DataType = System.Type.GetType("System.Decimal");
                                column.DefaultValue = 0;
                                column.ReadOnly = false;

                                dtSlipDetail.Columns.Add(column);
                            }

                            decimal a = Convert.ToDecimal(dtView.ToTable().Compute("SUM(RemainAmount)", string.Empty));
                            if (Value > a)
                            {
                                MessageBox.Show("Max Amount allowed for available slip is '" + a.ToString("0.000") + "'.");
                                grvPaymentDetails.FocusedRowHandle = e.RowHandle;
                                grvPaymentDetails.FocusedColumn = colAmount;
                                grvPaymentDetails.SetRowCellValue(e.RowHandle, colAmount, 0);
                                return;
                            }
                            decimal TotalValue = 0;
                            decimal RemainValue = Value;
                            decimal AvailableValue = 0;
                            foreach (DataRowView row in dtView)
                            {
                                if (TotalValue != Value)
                                {
                                    AvailableValue = Convert.ToDecimal(row["RemainAmount"]);
                                    decimal TempValue = AvailableValue - RemainValue;
                                    if (TempValue <= 0)
                                    {
                                        row["Amount"] = AvailableValue;
                                        TotalValue += AvailableValue;
                                        RemainValue = TempValue * -1;
                                    }
                                    else
                                    {
                                        row["Amount"] = RemainValue;
                                        TotalValue += RemainValue;
                                        RemainValue = 0;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No slips found for selected party.");
                        grvPaymentDetails.FocusedRowHandle = e.RowHandle;
                        grvPaymentDetails.FocusedColumn = colParty;
                        return;
                    }
                }
            }
        }
    }
}