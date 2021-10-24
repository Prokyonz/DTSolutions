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
    public partial class FrmPaymentEntry : DevExpress.XtraEditors.XtraForm
    {
        private readonly CompanyMasterRepository _companyMasterRepository;
        private readonly PartyMasterRepository _partyMasterRepository;
        private PaymentMasterRepository _paymentMaterRepository;
        private readonly ContraEntryMasterRespository _contraEntryRepository;
        int _paymentType = 0;

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
            } else
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
                lueLeadger.Properties.DataSource = result;
                lueLeadger.Properties.DisplayMember = "Name";
                lueLeadger.Properties.ValueMember = "Id";

                repoParty.DataSource = result;
                repoParty.DisplayMember = "Name";
                repoParty.ValueMember = "Id";
            }
        }

        private async void lueLeadger_EditValueChanged(object sender, EventArgs e)
        {
            if (lueLeadger.EditValue != null)
            {
                var result = await _partyMasterRepository.GetPartyBalance(lueLeadger.EditValue.ToString());
                txtLedgerBalance.Text = result.ToString();
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
                    ContraEntryMaster contraEntryMaster = new ContraEntryMaster
                    {
                        Id = Guid.NewGuid().ToString(),
                        BranchId = Common.LoginBranch,
                        CompanyId = lueCompany.EditValue.ToString(),
                        FinancialYearId = Common.LoginFinancialYear,
                        CreatedBy = Guid.NewGuid().ToString(),
                        CreatedDate = DateTime.Now,
                        IsDelete = false,
                        Remarks = txtRemark.Text,
                        ToPartyId = lueLeadger.EditValue.ToString(),
                        ContraEntryDetails = null
                    };

                    var result = await _contraEntryRepository.AddContraEntryAsync(contraEntryMaster);

                    if (result != null)
                    {
                        Reset();
                        MessageBox.Show(AppMessages.GetString(AppMessageID.SaveSuccessfully), "[" + this.Text + "}", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    GroupPaymentMaster groupPaymentMaster = new GroupPaymentMaster
                    {
                        Id = Guid.NewGuid().ToString(),
                        BillNo = Convert.ToInt32(txtSerialNo.Text),
                        BranchId = Common.LoginBranch,
                        CompanyId = lueCompany.EditValue.ToString(),
                        FinancialYearId = Common.LoginFinancialYear,
                        CreatedBy = Guid.NewGuid().ToString(),
                        CreatedDate = DateTime.Now,
                        IsDelete = false,
                        Remarks = txtRemark.Text,
                        ToPartyId = lueLeadger.EditValue.ToString(),
                        CrDrType = _paymentType,
                        PaymentMasters = null,
                    };

                    var Result = await _paymentMaterRepository.AddPaymentAsync(groupPaymentMaster);

                    if (Result != null)
                    {
                        Reset();
                        MessageBox.Show(AppMessages.GetString(AppMessageID.SaveSuccessfully), "[" + this.Text + "}", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error : " + Ex.Message.ToString(), "[" + this.Text + "}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}