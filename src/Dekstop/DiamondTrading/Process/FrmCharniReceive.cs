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
    public partial class FrmCharniReceive : DevExpress.XtraEditors.XtraForm
    {
        CharniProcessMasterRepository _charniProcessMasterRepository;
        PartyMasterRepository _partyMasterRepository;
        List<CharniProcessReceive> ListCharniProcessReceive;
        public FrmCharniReceive()
        {
            InitializeComponent();
            _charniProcessMasterRepository = new CharniProcessMasterRepository();
            _partyMasterRepository = new PartyMasterRepository();
        }

        private async void FrmCharniReceive_Load(object sender, EventArgs e)
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
            var SrNo = await _charniProcessMasterRepository.GetMaxSrNoAsync(Common.LoginCompany.ToString(), Common.LoginBranch.ToString(), Common.LoginFinancialYear, 1);
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

        private async Task GetKapanDetail()
        {
            KapanMasterRepository kapanMasterRepository = new KapanMasterRepository();
            var kapanMaster = await kapanMasterRepository.GetAllKapanAsync();
            lueKapan.Properties.DataSource = kapanMaster;
            lueKapan.Properties.DisplayMember = "Name";
            lueKapan.Properties.ValueMember = "Id";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async Task GetCharniProcessReceiveDetail()
        {
            if (lueReceiveFrom.EditValue != null)
            {
                grdParticularsDetails.DataSource = GetDTColumnsforParticularDetails();
                ListCharniProcessReceive = await _charniProcessMasterRepository.GetCharniReceiveDetails(lueReceiveFrom.EditValue.ToString(), Common.LoginCompany.ToString(), Common.LoginBranch.ToString(), Common.LoginFinancialYear.ToString());

                lueKapan.Properties.DataSource = ListCharniProcessReceive;
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
            dt.Columns.Add("CharniCarat");
            return dt;
        }

        private async void lueReceiveFrom_EditValueChanged(object sender, EventArgs e)
        {
            await GetCharniProcessReceiveDetail();
        }

        private void lueKapan_EditValueChanged(object sender, EventArgs e)
        {
            if(lueKapan.EditValue!=null)
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
            SizeMasterRepository sizeMasterRepository = new SizeMasterRepository();
            repoSize.DataSource = await sizeMasterRepository.GetAllSizeAsync();
            repoSize.DisplayMember = "Name";
            repoSize.ValueMember = "Id";

            repoSize.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            repoSize.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
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
            if (grvParticularsDetails.FocusedColumn == colCharniCarat)
            {
                if (grvParticularsDetails.GetRowCellValue(e.RowHandle, colCharniCarat) == DBNull.Value)
                    return;
                if (Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(e.RowHandle, colCharniCarat)) == 0)
                {
                    e.ErrorText = "0 caret is not allowed to process";
                    grvParticularsDetails.FocusedRowHandle = e.RowHandle;
                    grvParticularsDetails.FocusedColumn = colCharniCarat;
                    e.Valid = false;
                }
                else if (Convert.ToDecimal(txtACarat.Text) - (Convert.ToDecimal(colCharniCarat.SummaryItem.SummaryValue) + Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(e.RowHandle, colCharniCarat))) < 0)
                {
                    e.ErrorText = "Max " + Convert.ToDecimal(txtACarat.Text) + " carets availble to process";
                    grvParticularsDetails.FocusedRowHandle = e.RowHandle;
                    grvParticularsDetails.FocusedColumn = colCharniCarat;
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

                CharniProcessMaster charniProcessMaster = new CharniProcessMaster();
                bool IsSuccess = false;
                try
                {
                    for (int i = 0; i < grvParticularsDetails.RowCount; i++)
                    {
                        Cts = "0";
                        LossCts = "0";
                        RejCts = "0";
                        if (Convert.ToInt32(grvParticularsDetails.GetRowCellValue(i, colCategory)) == ReceiveCategoryMaster.ReceivedCts)
                            Cts = grvParticularsDetails.GetRowCellValue(i, colCharniCarat).ToString();
                        else if (Convert.ToInt32(grvParticularsDetails.GetRowCellValue(i, colCategory)) == ReceiveCategoryMaster.LossCts)
                            LossCts = grvParticularsDetails.GetRowCellValue(i, colCharniCarat).ToString();
                        else
                            RejCts = grvParticularsDetails.GetRowCellValue(i, colCharniCarat).ToString();
                        charniProcessMaster = new CharniProcessMaster();
                        charniProcessMaster.Id = Guid.NewGuid().ToString();
                        charniProcessMaster.CharniNo = Convert.ToInt32(lueKapan.GetColumnValue("CharniNo").ToString());
                        charniProcessMaster.JangadNo = Convert.ToInt32(txtSerialNo.Text);
                        charniProcessMaster.BoilJangadNo = Convert.ToInt32(lueKapan.GetColumnValue("BoilJangadNo").ToString());
                        charniProcessMaster.CompanyId = Common.LoginCompany;
                        charniProcessMaster.BranchId = Common.LoginBranch;
                        charniProcessMaster.EntryDate = Convert.ToDateTime(dtDate.Text).ToString("yyyyMMdd");
                        charniProcessMaster.EntryTime = Convert.ToDateTime(dtTime.Text).ToString("hh:mm:ss ttt");
                        charniProcessMaster.FinancialYearId = Common.LoginFinancialYear;
                        charniProcessMaster.CharniType = Convert.ToInt32(ProcessType.Receive);
                        charniProcessMaster.KapanId = lueKapan.GetColumnValue("KapanId").ToString();
                        charniProcessMaster.ShapeId = lueKapan.GetColumnValue("ShapeId").ToString();
                        charniProcessMaster.SizeId = lueKapan.GetColumnValue("SizeId").ToString();
                        charniProcessMaster.PurityId = lueKapan.GetColumnValue("PurityId").ToString();
                        charniProcessMaster.Weight = Convert.ToDecimal(txtACarat.Text);
                        charniProcessMaster.CharniSizeId = grvParticularsDetails.GetRowCellValue(i, colSize).ToString();
                        charniProcessMaster.CharniWeight = Convert.ToDecimal(Cts);
                        charniProcessMaster.LossWeight = Convert.ToDecimal(LossCts);
                        charniProcessMaster.RejectionWeight = Convert.ToDecimal(RejCts);
                        charniProcessMaster.HandOverById = lueReceiveFrom.EditValue.ToString();
                        charniProcessMaster.HandOverToId = lueSendto.EditValue.ToString();
                        charniProcessMaster.SlipNo = lueKapan.GetColumnValue("SlipNo").ToString();
                        charniProcessMaster.CharniCategoy = Convert.ToInt32(grvParticularsDetails.GetRowCellValue(i, colCategory));
                        charniProcessMaster.Remarks = txtRemark.Text;
                        charniProcessMaster.IsDelete = false;
                        charniProcessMaster.CreatedDate = DateTime.Now;
                        charniProcessMaster.CreatedBy = Common.LoginUserID;
                        charniProcessMaster.UpdatedDate = DateTime.Now;
                        charniProcessMaster.UpdatedBy = Common.LoginUserID;

                        var Result = await _charniProcessMasterRepository.AddCharniProcessAsync(charniProcessMaster);
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
    }
}