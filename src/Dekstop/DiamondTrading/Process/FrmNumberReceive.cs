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
    public partial class FrmNumberReceive : DevExpress.XtraEditors.XtraForm
    {
        NumberProcessMasterRepository _numberProcessMasterRepository;
        PartyMasterRepository _partyMasterRepository;
        List<NumberProcessReceive> ListNumberProcessReceive;
        public FrmNumberReceive()
        {
            InitializeComponent();
            _numberProcessMasterRepository = new NumberProcessMasterRepository();
            _partyMasterRepository = new PartyMasterRepository();
        }

        private async void FrmNumberReceive_Load(object sender, EventArgs e)
        {
            dtDate.EditValue = DateTime.Now;
            dtTime.EditValue = DateTime.Now;

            SetThemeColors(Color.FromArgb(215, 246, 214));

            await GetMaxSrNo();
            await GetEmployeeList();
            GetCategoryList();
            await GetSizeList();
        }

        private void SetThemeColors(Color color)
        {
            if (!color.ToArgb().ToString().Equals(Color.FromArgb(0).Name))
            {
                grpGroup1.AppearanceCaption.BorderColor = color;
                grpGroup2.AppearanceCaption.BorderColor = color;

                txtSlipNo.BackColor = color;
                txtSize.BackColor = color;
                txtACarat.BackColor = color;
            }
        }

        private async Task GetMaxSrNo()
        {
            var SrNo = await _numberProcessMasterRepository.GetMaxSrNoAsync(Common.LoginCompany.ToString(), Common.LoginBranch.ToString(), Common.LoginFinancialYear, 1);
            txtSerialNo.Text = SrNo.ToString();
        }

        private async Task GetEmployeeList()
        {
            var EmployeeDetailList = await _partyMasterRepository.GetAllPartyAsync(Common.LoginCompany.ToString(), PartyTypeMaster.Employee, PartyTypeMaster.Other);
            lueReceiveFrom.Properties.DataSource = EmployeeDetailList;
            lueReceiveFrom.Properties.DisplayMember = "Name";
            lueReceiveFrom.Properties.ValueMember = "Id";

            lueSendto.Properties.DataSource = EmployeeDetailList;
            lueSendto.Properties.DisplayMember = "Name";
            lueSendto.Properties.ValueMember = "Id";
        }

        private void GetCategoryList()
        {
            var Category = ReceiveCategoryMaster.GetAllCategory();

            if (Category != null)
            {
                repoCategory.DataSource = Category;
                repoCategory.DisplayMember = "Name";
                repoCategory.ValueMember = "Id";

                repoCategory.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                repoCategory.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
            }
        }

        private async Task GetSizeList()
        {
            NumberMasterRepository numberMasterRepository = new NumberMasterRepository();
            repoSize.DataSource = await numberMasterRepository.GetAllNumberAsync();
            repoSize.DisplayMember = "Name";
            repoSize.ValueMember = "Id";

            repoSize.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            repoSize.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async Task GetNumberProcessReceiveDetail()
        {
            if (lueReceiveFrom.EditValue != null)
            {
                grdParticularsDetails.DataSource = GetDTColumnsforParticularDetails();
                ListNumberProcessReceive = await _numberProcessMasterRepository.GetNumberReceiveDetails(lueReceiveFrom.EditValue.ToString(), Common.LoginCompany.ToString(), Common.LoginBranch.ToString(), Common.LoginFinancialYear.ToString());

                lueKapan.Properties.DataSource = ListNumberProcessReceive;
                lueKapan.Properties.DisplayMember = "Kapan";
                lueKapan.Properties.ValueMember = "Id";

                lueKapan.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                lueKapan.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
            }
        }

        private static DataTable GetDTColumnsforParticularDetails()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Size");
            dt.Columns.Add("Category");
            dt.Columns.Add("NumberCarat");
            return dt;
        }

        private async void lueReceiveFrom_EditValueChanged(object sender, EventArgs e)
        {
            await GetNumberProcessReceiveDetail();
        }

        private void lueKapan_EditValueChanged(object sender, EventArgs e)
        {
            if (lueKapan.EditValue != null)
            {
                txtSlipNo.Text = lueKapan.GetColumnValue("SlipNo").ToString();
                txtSize.Text = lueKapan.GetColumnValue("Size").ToString();
                txtACarat.Text = lueKapan.GetColumnValue("AvailableWeight").ToString();
            }
            else
            {
                txtSlipNo.Text = "";
                txtSize.Text = "";
                txtACarat.Text = "";
            }
        }

        private void grvParticularsDetails_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (grvParticularsDetails.FocusedColumn == colSize)
            {
                if (grvParticularsDetails.GetRowCellValue(e.RowHandle, colSize) == DBNull.Value)
                {
                    e.ErrorText = "Please select Size";
                    grvParticularsDetails.FocusedRowHandle = e.RowHandle;
                    grvParticularsDetails.FocusedColumn = colSize;
                    e.Valid = false;
                }
            }
            if (grvParticularsDetails.FocusedColumn == colNumberCarat)
            {
                if (grvParticularsDetails.GetRowCellValue(e.RowHandle, colNumberCarat) == DBNull.Value)
                    return;
                if (Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(e.RowHandle, colNumberCarat)) == 0)
                {
                    e.ErrorText = "0 caret is not allowed to process";
                    grvParticularsDetails.FocusedRowHandle = e.RowHandle;
                    grvParticularsDetails.FocusedColumn = colNumberCarat;
                    e.Valid = false;
                }
                else if (Convert.ToDecimal(txtACarat.Text) - (Convert.ToDecimal(colNumberCarat.SummaryItem.SummaryValue) + Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(e.RowHandle, colNumberCarat))) < 0)
                {
                    e.ErrorText = "Max " + Convert.ToDecimal(txtACarat.Text) + " carets availble to process";
                    grvParticularsDetails.FocusedRowHandle = e.RowHandle;
                    grvParticularsDetails.FocusedColumn = colNumberCarat;
                    e.Valid = false;
                }
            }
        }

        private void grvParticularsDetails_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            grvParticularsDetails.SetRowCellValue(e.RowHandle, colCategory, 0);
        }

        private bool CheckValidation()
        {
            if (lueReceiveFrom.EditValue == null)
            {
                MessageBox.Show("Please select Receive from name", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                lueReceiveFrom.Focus();
                return false;
            }
            else if (lueSendto.EditValue == null)
            {
                MessageBox.Show("Please select Send to name", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                lueSendto.Focus();
                return false;
            }
            if (lueKapan.EditValue == null)
            {
                MessageBox.Show("Please select Kapan", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                lueKapan.Focus();
                return false;
            }
            else if (grvParticularsDetails.RowCount == 0)
            {
                MessageBox.Show("Please select Particulars Details", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                grvParticularsDetails.Focus();
                return false;
            }
            return true;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (!CheckValidation())
                    return;

                string Cts = "0";
                string LossCts = "0";
                string RejCts = "0";

                NumberProcessMaster numberProcessMaster = new NumberProcessMaster();
                bool IsSuccess = false;
                try
                {
                    for (int i = 0; i < grvParticularsDetails.RowCount; i++)
                    {
                        Cts = "0";
                        LossCts = "0";
                        RejCts = "0";
                        if (Convert.ToInt32(grvParticularsDetails.GetRowCellValue(i, colCategory)) == ReceiveCategoryMaster.ReceivedCts)
                            Cts = grvParticularsDetails.GetRowCellValue(i, colNumberCarat).ToString();
                        else if (Convert.ToInt32(grvParticularsDetails.GetRowCellValue(i, colCategory)) == ReceiveCategoryMaster.LossCts)
                            LossCts = grvParticularsDetails.GetRowCellValue(i, colNumberCarat).ToString();
                        else
                            RejCts = grvParticularsDetails.GetRowCellValue(i, colNumberCarat).ToString();
                        numberProcessMaster = new NumberProcessMaster();
                        numberProcessMaster.Id = Guid.NewGuid().ToString();
                        numberProcessMaster.NumberNo = Convert.ToInt32(lueKapan.GetColumnValue("NumberNo").ToString());
                        numberProcessMaster.JangadNo = Convert.ToInt32(txtSerialNo.Text);
                        //galaProcessMaster.BoilJangadNo = Convert.ToInt32(lueKapan.GetColumnValue("BoilJangadNo").ToString());
                        numberProcessMaster.CompanyId = Common.LoginCompany;
                        numberProcessMaster.BranchId = Common.LoginBranch;
                        numberProcessMaster.EntryDate = Convert.ToDateTime(dtDate.Text).ToString("yyyyMMdd");
                        numberProcessMaster.EntryTime = Convert.ToDateTime(dtTime.Text).ToString("hh:mm:ss ttt");
                        numberProcessMaster.FinancialYearId = Common.LoginFinancialYear;
                        numberProcessMaster.NumberProcessType = Convert.ToInt32(ProcessType.Receive);
                        numberProcessMaster.KapanId = lueKapan.GetColumnValue("KapanId").ToString();
                        numberProcessMaster.ShapeId = lueKapan.GetColumnValue("ShapeId").ToString();
                        numberProcessMaster.SizeId = lueKapan.GetColumnValue("SizeId").ToString();
                        numberProcessMaster.PurityId = lueKapan.GetColumnValue("PurityId").ToString();
                        numberProcessMaster.Weight = Convert.ToDecimal(txtACarat.Text);
                        numberProcessMaster.GalaNumberId = lueKapan.GetColumnValue("GalaNumberId").ToString(); //grvParticularsDetails.GetRowCellValue(i, colSize).ToString();
                        numberProcessMaster.NumberId = grvParticularsDetails.GetRowCellValue(i, colSize).ToString();
                        numberProcessMaster.NumberWeight = Convert.ToDecimal(Cts);
                        numberProcessMaster.LossWeight = Convert.ToDecimal(LossCts);
                        numberProcessMaster.RejectionWeight = Convert.ToDecimal(RejCts);
                        numberProcessMaster.HandOverById = lueReceiveFrom.EditValue.ToString();
                        numberProcessMaster.HandOverToId = lueSendto.EditValue.ToString();
                        numberProcessMaster.SlipNo = lueKapan.GetColumnValue("SlipNo").ToString();
                        numberProcessMaster.NumberCategoy = Convert.ToInt32(grvParticularsDetails.GetRowCellValue(i, colCategory));
                        numberProcessMaster.Remarks = txtRemark.Text;
                        numberProcessMaster.IsDelete = false;
                        numberProcessMaster.CreatedDate = DateTime.Now;
                        numberProcessMaster.CreatedBy = Common.LoginUserID;
                        numberProcessMaster.UpdatedDate = DateTime.Now;
                        numberProcessMaster.UpdatedBy = Common.LoginUserID;

                        var Result = await _numberProcessMasterRepository.AddNumberProcessAsync(numberProcessMaster);
                        IsSuccess = true;
                    }
                }
                catch
                {
                    IsSuccess = false;
                }

                if (IsSuccess)
                {
                    Reset();
                    MessageBox.Show(AppMessages.GetString(AppMessageID.SaveSuccessfully), "[" + this.Text + "}", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            grdParticularsDetails.DataSource = null;
            dtDate.EditValue = DateTime.Now;
            dtTime.EditValue = DateTime.Now;
            txtRemark.Text = "";
            lueReceiveFrom.EditValue = null;
            lueSendto.EditValue = null;
            lueKapan.EditValue = null;
            repoSize.DataSource = null;
            repoCategory.DataSource = null;

            await GetMaxSrNo();
            await GetEmployeeList();
            GetCategoryList();
            await GetSizeList();
            lueReceiveFrom.Select();
            lueReceiveFrom.Focus();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void FrmNumberReceive_KeyDown(object sender, KeyEventArgs e)
        {
            Common.MoveToNextControl(sender, e, this);
        }
    }
}