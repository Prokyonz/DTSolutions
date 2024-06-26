﻿using DevExpress.XtraEditors;
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
    public partial class FrmExpenseEntry : DevExpress.XtraEditors.XtraForm
    {
        private readonly CompanyMasterRepository _companyMasterRepository;
        private readonly BranchMasterRepository _branchMasterRepository;
        private readonly PartyMasterRepository _partyMasterRepository;
        private ExpenseMasterRepository _expenseMaterRepository;

        public FrmExpenseEntry()
        {
            InitializeComponent();

            _companyMasterRepository = new CompanyMasterRepository();
            _branchMasterRepository = new BranchMasterRepository();
            _partyMasterRepository = new PartyMasterRepository();
            _expenseMaterRepository = new ExpenseMasterRepository();
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
            string lastselectedDate = RegistryHelper.GetSettings(RegistryHelper.MainSection, RegistryHelper.TranscationDateSelection, "");

            if (string.IsNullOrEmpty(lastselectedDate))
                dtDate.EditValue = DateTime.Now;
            else
                dtDate.EditValue = Convert.ToDateTime(lastselectedDate);
            timer1.Start();

            _ = GetMaxSrNo();
            _ = LoadCompany();
            await LoadLedgers(Common.LoginCompany);
            _ = LoadParties();
        }

        private static DataTable GetDTColumnsForPaymentDetails()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Branch");
            dt.Columns.Add("Party");
            dt.Columns.Add("Amount");
            return dt;
        }

        private async Task GetMaxSrNo()
        {
            var SrNo = await _expenseMaterRepository.GetMaxSrNoAsync(Common.LoginCompany.ToString(), Common.LoginFinancialYear);
            txtSerialNo.Text = SrNo.ToString();
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

        private async Task LoadParties()
        {
            var result = await _partyMasterRepository.GetAllPartyAsync(Common.LoginCompany, new int[] { 4, 5 });
            lueAccounts.Properties.DataSource = result;
            lueAccounts.Properties.DisplayMember = "Name";
            lueAccounts.Properties.ValueMember = "Id";
        }

        private async Task LoadCompany()
        {
            var result = await _companyMasterRepository.GetUserCompanyMappingAsync(Common.LoginUserID);
            lueCompany.Properties.DataSource = result;
            lueCompany.Properties.DisplayMember = "Name";
            lueCompany.Properties.ValueMember = "Id";
            lueCompany.EditValue = Common.LoginCompany;

            _ = LoadBranch(Common.LoginCompany);
        }

        private async Task LoadBranch(string CompanyId)
        {
            var result = await _branchMasterRepository.GetAllBranchAsync(CompanyId);
            lueBranch.Properties.DataSource = result;
            lueBranch.Properties.DisplayMember = "Name";
            lueBranch.Properties.ValueMember = "Id";
            lueBranch.EditValue = Common.LoginBranch;

            repoBranchList.DataSource = result;
            repoBranchList.DisplayMember = "Name";
            repoBranchList.ValueMember = "Id";
        }

        private async Task LoadLedgers(string companyId)
        {
            grdPaymentDetails.DataSource = GetDTColumnsForPaymentDetails();
            var result = await _partyMasterRepository.GetAllPartyAsync(companyId, PartyTypeMaster.Expense);

            repoParty.DataSource = result;
            repoParty.DisplayMember = "Name";
            repoParty.ValueMember = "Id";
        }

        private void grvPurchaseDetails_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            //string ControlName = ((DevExpress.XtraEditors.LookUpEdit)sender).Name;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                RegistryHelper.SaveSettings(RegistryHelper.MainSection, RegistryHelper.TranscationDateSelection, dtDate.DateTime.ToString());

                this.Cursor = Cursors.WaitCursor;
                bool IsSucess = false;
                try
                {
                    for (int i = 0; i < grvPaymentDetails.RowCount; i++)
                    {
                        ExpenseDetails expenseDetails = new ExpenseDetails
                        {
                            Id = Guid.NewGuid().ToString(),
                            SrNo = Convert.ToInt32(txtSerialNo.Text),
                            BranchId = grvPaymentDetails.GetRowCellValue(i,colBranch).ToString(), //Common.LoginBranch,
                            CompanyId = lueCompany.EditValue.ToString(),
                            FinancialYearId = Common.LoginFinancialYear,
                            PartyId = grvPaymentDetails.GetRowCellValue(i, colParty).ToString(),
                            fromPartyId = lueAccounts.EditValue.ToString(),
                            Amount = float.Parse(grvPaymentDetails.GetRowCellValue(i, colAmount).ToString()),
                            IsDelete = false,
                            Remarks = txtRemark.Text,
                            CreatedBy = Common.LoginUserID,
                            CreatedDate = DateTime.Now,
                            UpdatedBy = Common.LoginUserID,
                            UpdatedDate = DateTime.Now,
                        };

                        string partyId = grvPaymentDetails.GetRowCellValue(i, colParty).ToString();
                        string fromparty = lueAccounts.EditValue.ToString();
                        decimal amt = decimal.Parse(grvPaymentDetails.GetRowCellValue(i, colAmount).ToString());                        

                        var result = await _expenseMaterRepository.AddExpenseAsync(expenseDetails);

                        //await _expenseMaterRepository.UpdateBalanceAsync(partyId, fromparty, amt);

                        IsSucess = true;
                    }
                }
                catch(Exception Ex)
                {
                    IsSucess = false;
                }

                if (IsSucess)
                {
                    Reset();
                    MessageBox.Show(AppMessages.GetString(AppMessageID.SaveSuccessfully), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private async void Reset()
        {
            dtTime.EditValue = DateTime.Now;
            grdPaymentDetails.DataSource = null;
            txtRemark.Text = "";
            lueCompany.EditValue = null;
            lueBranch.EditValue = null;
            _= GetMaxSrNo();
            _= LoadCompany();
            await LoadLedgers(Common.LoginCompany);
            lueCompany.Focus();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private async void lueCompany_EditValueChanged(object sender, EventArgs e)
        {
            if (lueCompany.EditValue != null)
                await LoadLedgers(lueCompany.EditValue.ToString());
        }

        private void FrmPaymentEntry_KeyDown(object sender, KeyEventArgs e)
        {
            Common.MoveToNextControl(sender, e, this);
        }

        private async void lueAccounts_EditValueChanged(object sender, EventArgs e)
        {
            if (lueAccounts.EditValue != null)
            {
                var result = await _partyMasterRepository.GetPartyBalance(lueAccounts.EditValue.ToString(), Common.LoginCompany, Common.LoginFinancialYear);
                txtLedgerBalance.Text = result.ToString();
            }
        }

        private async void NewEntry(object sender, KeyEventArgs e)
        {
            string ControlName = ((DevExpress.XtraEditors.LookUpEdit)sender).Name;
            if (e.Control && e.KeyCode == Keys.N)
            {
                if (ControlName == lueAccounts.Name)
                {
                    Master.FrmPartyMaster frmPartyMaster = new Master.FrmPartyMaster();
                    frmPartyMaster.IsSilentEntry = true;
                    frmPartyMaster.IsCashBankAccount = true;
                    //frmPartyMaster.LedgerType = PartyTypeMaster.Buyer;
                    if (frmPartyMaster.ShowDialog() == DialogResult.OK)
                    {
                        await LoadParties();
                        lueAccounts.EditValue = frmPartyMaster.CreatedLedgerID;
                    }
                }
            }
        }

        private async void repoParty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                Master.FrmPartyMaster frmPartyMaster = new Master.FrmPartyMaster();
                frmPartyMaster.IsSilentEntry = true;
                frmPartyMaster.LedgerType = PartyTypeMaster.Expense;
                if (frmPartyMaster.ShowDialog() == DialogResult.OK)
                {
                    await LoadLedgers(lueCompany.EditValue.ToString());
                    grvPaymentDetails.SetFocusedRowCellValue(colParty, frmPartyMaster.CreatedLedgerID.ToString());
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dtTime.EditValue = DateTime.Now;
        }
    }
}