using DevExpress.XtraEditors;
using EFCore.SQL.Repository;
using Repository.Entities;
using Repository.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiamondTrading.Process
{
    public partial class FrmKapanMap : DevExpress.XtraEditors.XtraForm
    {
        KapanMappingMasterRepository _kapanMappingMasterRepository;
        List<KapanMapping> _listKapanMapping;
        string _SelectedSrNo = "";
        public FrmKapanMap()
        {
            InitializeComponent();
            _kapanMappingMasterRepository = new KapanMappingMasterRepository();
        }

        public FrmKapanMap(string SrNo)
        {
            InitializeComponent();
            _kapanMappingMasterRepository = new KapanMappingMasterRepository();
            _SelectedSrNo = SrNo;
        }

        private void FrmKapanMap_Load(object sender, EventArgs e)
        {
            dtDate.EditValue = DateTime.Now;
            dtTime.EditValue = DateTime.Now;

            _ = LoadCompany();
            _ = GetKapanDetail();

            if (string.IsNullOrEmpty(_SelectedSrNo))
            {
                _ = GetMaxSrNo(Common.LoginCompany);
                _ = GetPendingKapanDetails(Common.LoginCompany, Common.LoginBranch, null, 0);
            }
            else
            {
                txtSerialNo.Text = _SelectedSrNo;
                _ = GetPendingKapanDetails(Common.LoginCompany, Common.LoginBranch, _SelectedSrNo, 1);
                btnSave.Text = AppMessages.GetString(AppMessageID.Update);
            }
        }

        private async Task LoadCompany()
        {
            CompanyMasterRepository companyMasterRepository = new CompanyMasterRepository();
            var companies = await companyMasterRepository.GetUserCompanyMappingAsync(Common.LoginUserID);
            lueCompany.Properties.DataSource = companies;
            lueCompany.Properties.DisplayMember = "Name";
            lueCompany.Properties.ValueMember = "Id";

            lueCompany.EditValue = Common.LoginCompany;
            _ = LoadBranch(Common.LoginCompany);
        }

        private async Task LoadBranch(string companyId)
        {
            BranchMasterRepository branchMasterRepository = new BranchMasterRepository();
            var branches = await branchMasterRepository.GetAllBranchAsync(companyId); //_branchMasterRepository.GetAllBranchAsync();
            lueBranch.Properties.DataSource = branches;
            lueBranch.Properties.DisplayMember = "Name";
            lueBranch.Properties.ValueMember = "Id";
            lueBranch.EditValue = Common.LoginBranch;
        }

        private async Task GetKapanDetail()
        {
            KapanMasterRepository kapanMasterRepository = new KapanMasterRepository();
            var kapanMaster = await kapanMasterRepository.GetAllKapanAsync(Common.LoginCompany);
            lueKapan.Properties.DataSource = kapanMaster;
            lueKapan.Properties.DisplayMember = "Name";
            lueKapan.Properties.ValueMember = "Id";
        }

        private async Task GetMaxSrNo(string companyId)
        {
            var SrNo = await _kapanMappingMasterRepository.GetMaxSrNo(companyId, Common.LoginFinancialYear);
            txtSerialNo.Text = SrNo.ToString();
        }

        private async Task GetPendingKapanDetails(string companyId, string branchId, string SrNo, int ActionType)
        {
            _listKapanMapping = await _kapanMappingMasterRepository.GetPendingKapanMapping(companyId, branchId, Common.LoginFinancialYear.ToString(), SrNo, ActionType);
            grdPendingKapanDetails.DataSource = _listKapanMapping;
            if (!string.IsNullOrEmpty(_SelectedSrNo) && _listKapanMapping.Any())
            {
                lueKapan.EditValue = _listKapanMapping.FirstOrDefault().KapanId;
                txtRemark.Text = _listKapanMapping.FirstOrDefault().Remarks;
                grvPendingKapanDetails.SelectAll();
            }
            
        }

        private void btnMap_Click(object sender, EventArgs e)
        {
            if (tglIsAutoAdjust.IsOn && _listKapanMapping != null && txtCarat.Text.Length > 0)
            {
                DataTable dt = Common.ToDataTable(_listKapanMapping);
                DataView dtView = new DataView(dt);
                decimal a = Convert.ToDecimal(dtView.ToTable().Compute("SUM(AvailableCts)", string.Empty));
                decimal Value = Convert.ToDecimal(txtCarat.Text);
                if (Value > a)
                {
                    MessageBox.Show("Max Amount allowed for available slip is '" + a.ToString("0.000") + "'.");
                    return;
                }
                decimal TotalValue = 0;
                decimal RemainValue = Value;
                decimal AvailableValue = 0;
                foreach (DataRowView row in dtView)
                {
                    if (TotalValue != Value)
                    {
                        AvailableValue = Convert.ToDecimal(row["AvailableCts"]);
                        decimal TempValue = AvailableValue - RemainValue;
                        if (TempValue <= 0)
                        {
                            row["Cts"] = AvailableValue;
                            TotalValue += AvailableValue;
                            RemainValue = TempValue * -1;
                        }
                        else
                        {
                            row["Cts"] = RemainValue;
                            TotalValue += RemainValue;
                            RemainValue = 0;
                        }
                    }
                }

                grdPendingKapanDetails.DataSource = dt;
            }
        }

        private void tglIsAutoAdjust_Toggled(object sender, EventArgs e)
        {
            colCts.OptionsColumn.ReadOnly = !tglIsAutoAdjust.IsOn;
            colCts.OptionsColumn.AllowEdit = !tglIsAutoAdjust.IsOn;

            btnMap.Enabled = tglIsAutoAdjust.IsOn;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckValidation())
                    return;

                KapanMappingMaster kapanMappingMaster = null;
                bool IsSuccess = false;
                if (btnSave.Text == AppMessages.GetString(AppMessageID.Save))
                {
                    try
                    {
                        Int32[] selectedRowHandles = grvPendingKapanDetails.GetSelectedRows();
                        for (int i = 0; i < selectedRowHandles.Length; i++)
                        {
                            kapanMappingMaster = new KapanMappingMaster();
                            kapanMappingMaster.Id = Guid.NewGuid().ToString();
                            kapanMappingMaster.CompanyId = lueCompany.EditValue.ToString();
                            kapanMappingMaster.BranchId = lueBranch.EditValue.ToString();
                            kapanMappingMaster.FinancialYearId = Common.LoginFinancialYear.ToString();
                            kapanMappingMaster.PurchaseMasterId = grvPendingKapanDetails.GetRowCellValue(selectedRowHandles[i], colPurchaseID).ToString();
                            kapanMappingMaster.PurchaseDetailsId = grvPendingKapanDetails.GetRowCellValue(selectedRowHandles[i], colPurchaseDetailId).ToString();
                            kapanMappingMaster.PurityId = null;
                            kapanMappingMaster.KapanId = lueKapan.EditValue.ToString();
                            kapanMappingMaster.SlipNo = grvPendingKapanDetails.GetRowCellValue(selectedRowHandles[i], colSlipNo).ToString();
                            kapanMappingMaster.Weight = Convert.ToDecimal(grvPendingKapanDetails.GetRowCellValue(selectedRowHandles[i], colTotalCts));
                            kapanMappingMaster.Remarks = txtRemark.Text;
                            kapanMappingMaster.CreatedDate = DateTime.Now;
                            kapanMappingMaster.CreatedBy = Common.LoginUserID;
                            kapanMappingMaster.UpdatedDate = DateTime.Now;
                            kapanMappingMaster.UpdatedBy = Common.LoginUserID;

                            var Result = await _kapanMappingMasterRepository.AddKapanMappingAsync(kapanMappingMaster);
                            IsSuccess = true;
                            //if (Convert.ToDecimal(grvPendingKapanDetails.GetRowCellValue(i, colCts)) > 0)
                            //{

                            //}
                        }
                    }
                    catch
                    {
                        IsSuccess = false;
                    }

                    if (IsSuccess)
                    {
                        Reset();
                        MessageBox.Show(AppMessages.GetString(AppMessageID.SaveSuccessfully), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    try
                    {
                        Int32[] selectedRowHandles = grvPendingKapanDetails.GetSelectedRows();
                        for (int i = 0; i < selectedRowHandles.Length; i++)
                        {
                            kapanMappingMaster = await _kapanMappingMasterRepository.GetKapanMapDetailAsync(_SelectedSrNo);
                            if (kapanMappingMaster != null)
                            {
                                kapanMappingMaster.PurchaseMasterId = grvPendingKapanDetails.GetRowCellValue(selectedRowHandles[i], colPurchaseID).ToString();
                                kapanMappingMaster.PurchaseDetailsId = grvPendingKapanDetails.GetRowCellValue(selectedRowHandles[i], colPurchaseDetailId).ToString();
                                kapanMappingMaster.KapanId = lueKapan.EditValue.ToString();
                                kapanMappingMaster.SlipNo = grvPendingKapanDetails.GetRowCellValue(selectedRowHandles[i], colSlipNo).ToString();
                                kapanMappingMaster.Weight = Convert.ToDecimal(grvPendingKapanDetails.GetRowCellValue(selectedRowHandles[i], colTotalCts));
                                kapanMappingMaster.Remarks = txtRemark.Text;
                                kapanMappingMaster.CreatedDate = DateTime.Now;
                                kapanMappingMaster.CreatedBy = Common.LoginUserID;
                                kapanMappingMaster.UpdatedDate = DateTime.Now;
                                kapanMappingMaster.UpdatedBy = Common.LoginUserID;

                                var Result = await _kapanMappingMasterRepository.UpdateKapanMappingMasterAsync(kapanMappingMaster);
                                IsSuccess = true;
                            }
                        }
                    }
                    catch
                    {
                        IsSuccess = false;
                    }

                    if (IsSuccess)
                    {
                        Reset();
                        MessageBox.Show(AppMessages.GetString(AppMessageID.SaveSuccessfully), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
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

        private bool CheckValidation()
        {
            if (lueCompany.EditValue == null)
            {
                MessageBox.Show("Please select Company", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                lueCompany.Focus();
                return false;
            }
            else if (lueBranch.EditValue == null)
            {
                MessageBox.Show("Please select Branch", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                lueBranch.Focus();
                return false;
            }
            else if (lueKapan.EditValue == null)
            {
                MessageBox.Show("Please select Kapan", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                lueKapan.Focus();
                return false;
            }
            //else if (txtCarat.Text.Trim().Length == 0)
            //{
            //    MessageBox.Show("Please enter Carat to Map", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtCarat.Focus();
            //    return false;
            //}
            //else if (!tglIsAutoAdjust.IsOn)
            //{
            //    var summaryValue = colCts.SummaryItem.SummaryValue;
            //    if (Convert.ToDecimal(summaryValue) == 0)
            //    {
            //        MessageBox.Show("Please enter Carat details to Map", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        grdPendingKapanDetails.Focus();
            //        return false;
            //    }
            //}

            //var summaryValue1 = colCts.SummaryItem.SummaryValue;
            //if (Convert.ToDecimal(summaryValue1) != Convert.ToDecimal(txtCarat.Text))
            //{
            //    MessageBox.Show("Summary Carat details '"+ Convert.ToDecimal(summaryValue1) + "' not equal with Total Carats '"+ Convert.ToDecimal(txtCarat.Text) + "'", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtCarat.Focus();
            //    return false;
            //}

            if (grvPendingKapanDetails.GetSelectedRows().Count() == 0)
            {
                MessageBox.Show("Please select any record to map with kapan.", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void FrmKapanMap_KeyDown(object sender, KeyEventArgs e)
        {
            Common.MoveToNextControl(sender, e, this);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            dtDate.EditValue = DateTime.Now;
            dtTime.EditValue = DateTime.Now;

            grdPendingKapanDetails.DataSource = null;
            txtCarat.Text = "";
            tglIsAutoAdjust.IsOn = true;

            _ = LoadCompany();
            _ = GetKapanDetail();
            _ = GetMaxSrNo(Common.LoginCompany);
            _ = GetPendingKapanDetails(Common.LoginCompany, Common.LoginBranch, null, 0);
            btnSave.Text = AppMessages.GetString(AppMessageID.Save);
        }

        private void grvPendingKapanDetails_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            decimal TotalCts = 0;
            Int32[] selectedRowHandles = grvPendingKapanDetails.GetSelectedRows();
            for (int i = 0; i < selectedRowHandles.Length; i++)
            {
                int selectedRowHandle = selectedRowHandles[i];
                if (selectedRowHandle >= 0)
                {
                    TotalCts += Convert.ToDecimal(grvPendingKapanDetails.GetRowCellValue(selectedRowHandle, colTotalCts).ToString());
                }
            }
            txtCarat.Text = TotalCts.ToString();
        }

        private async void NewEntry(object sender, KeyEventArgs e)
        {
            string ControlName = ((DevExpress.XtraEditors.LookUpEdit)sender).Name;
            if (e.Control && e.KeyCode == Keys.N)
            {
                if (ControlName == lueKapan.Name)
                {
                    Master.FrmKapanMaster frmKapanMaster = new Master.FrmKapanMaster();
                    frmKapanMaster.IsSilentEntry = true;
                    if (frmKapanMaster.ShowDialog() == DialogResult.OK)
                    {
                        await GetKapanDetail();
                        lueKapan.EditValue = frmKapanMaster.CreatedLedgerID;
                    }
                }
            }
        }
    }
}