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
    public partial class FrmGalaSend : DevExpress.XtraEditors.XtraForm
    {
        GalaProcessMasterRepository _galaProcessMasterRepository;
        PartyMasterRepository _partyMasterRepository;
        List<GalaProcessSend> ListGalaProcessSend;
        public FrmGalaSend()
        {
            InitializeComponent();
            _galaProcessMasterRepository = new GalaProcessMasterRepository();
            _partyMasterRepository = new PartyMasterRepository();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetThemeColors(Color color)
        {
            if (!color.ToArgb().ToString().Equals(Color.FromArgb(0).Name))
            {
                grpGroup1.AppearanceCaption.BorderColor = color;
                grpGroup2.AppearanceCaption.BorderColor = color;
            }
        }

        private async void FrmGalaSend_Load(object sender, EventArgs e)
        {
            dtDate.EditValue = DateTime.Now;
            dtTime.EditValue = DateTime.Now;

            SetThemeColors(Color.FromArgb(250, 243, 197));

            await GetMaxSrNo();
            await GetEmployeeList();
            await GetGalaProcessSendDetail();
        }

        private async Task GetMaxSrNo()
        {
            var SrNo = await _galaProcessMasterRepository.GetMaxSrNoAsync(Common.LoginCompany.ToString(), Common.LoginBranch.ToString(), Common.LoginFinancialYear, 0);
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

        private async Task GetGalaProcessSendDetail()
        {
            grdParticularsDetails.DataSource = GetDTColumnsforParticularDetails();
            ListGalaProcessSend = await _galaProcessMasterRepository.GetGalaSendToDetails(Common.LoginCompany.ToString(), Common.LoginBranch.ToString(), Common.LoginFinancialYear.ToString());

            lueKapan.Properties.DataSource = ListGalaProcessSend.Select(x => new { x.KapanId, x.Kapan }).Distinct().ToList();
            lueKapan.Properties.DisplayMember = "Kapan";
            lueKapan.Properties.ValueMember = "KapanId";
        }

        private static DataTable GetDTColumnsforParticularDetails()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("SlipNo");
            dt.Columns.Add("Size");
            dt.Columns.Add("AvailableWeight");
            dt.Columns.Add("GalaCarat");
            dt.Columns.Add("SizeId");
            dt.Columns.Add("ShapeId");
            dt.Columns.Add("PurityId");
            dt.Columns.Add("SlipNo1");
            dt.Columns.Add("CharniSize");
            dt.Columns.Add("CharniSizeId");
            return dt;
        }

        private void lueKapan_EditValueChanged(object sender, EventArgs e)
        {
             if (lueKapan.EditValue != null && ListGalaProcessSend != null)
            {
                repoSlipNo.DataSource = ListGalaProcessSend.Where(x => x.KapanId == lueKapan.EditValue.ToString()).ToList();
                repoSlipNo.DisplayMember = "SlipNo";
                repoSlipNo.ValueMember = "Id";

                repoSlipNo.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                repoSlipNo.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
            }
        }

        private void grvParticularsDetails_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == colSlipNo)
                {
                    grvParticularsDetails.SetRowCellValue(e.RowHandle, colSlipNo1, ((Repository.Entities.Models.GalaProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).SlipNo);
                    grvParticularsDetails.SetRowCellValue(e.RowHandle, colSize, ((Repository.Entities.Models.GalaProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).Size);
                    grvParticularsDetails.SetRowCellValue(e.RowHandle, colACarat, ((Repository.Entities.Models.GalaProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).AvailableWeight);
                    grvParticularsDetails.SetRowCellValue(e.RowHandle, colSizeId, ((Repository.Entities.Models.GalaProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).SizeId);
                    grvParticularsDetails.SetRowCellValue(e.RowHandle, colShapeId, ((Repository.Entities.Models.GalaProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).ShapeId);
                    grvParticularsDetails.SetRowCellValue(e.RowHandle, colPurityId, ((Repository.Entities.Models.GalaProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).PurityId);
                    grvParticularsDetails.SetRowCellValue(e.RowHandle, colCharniSize, ((Repository.Entities.Models.GalaProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).CharniSize);
                    grvParticularsDetails.SetRowCellValue(e.RowHandle, colCharniSizeId, ((Repository.Entities.Models.GalaProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).CharniSizeId);

                    //grvPurchaseItems.FocusedRowHandle = e.RowHandle;
                    //grvPurchaseItems.FocusedColumn = colBoilCarat;
                }
            }
            catch
            {

            }
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

                GalaProcessMaster galaProcessMaster = new GalaProcessMaster();
                bool IsSuccess = false;
                try
                {
                    for (int i = 0; i < grvParticularsDetails.RowCount; i++)
                    {
                        galaProcessMaster = new GalaProcessMaster();
                        galaProcessMaster.Id = Guid.NewGuid().ToString();
                        galaProcessMaster.GalaNo = Convert.ToInt32(txtSerialNo.Text);
                        galaProcessMaster.JangadNo = Convert.ToInt32(txtSerialNo.Text);
                        //galaProcessMaster.BoilJangadNo = Convert.ToInt32(grvParticularsDetails.GetRowCellValue(i, colBoilNo1).ToString());
                        galaProcessMaster.CompanyId = Common.LoginCompany;
                        galaProcessMaster.BranchId = Common.LoginBranch;
                        galaProcessMaster.EntryDate = Convert.ToDateTime(dtDate.Text).ToString("yyyyMMdd");
                        galaProcessMaster.EntryTime = Convert.ToDateTime(dtTime.Text).ToString("hh:mm:ss ttt");
                        galaProcessMaster.FinancialYearId = Common.LoginFinancialYear;
                        galaProcessMaster.GalaProcessType = Convert.ToInt32(ProcessType.Send);
                        galaProcessMaster.KapanId = lueKapan.EditValue.ToString();
                        galaProcessMaster.ShapeId = grvParticularsDetails.GetRowCellValue(i, colShapeId).ToString();
                        galaProcessMaster.SizeId = grvParticularsDetails.GetRowCellValue(i, colSizeId).ToString();
                        galaProcessMaster.PurityId = grvParticularsDetails.GetRowCellValue(i, colPurityId).ToString();
                        galaProcessMaster.CharniSizeId = grvParticularsDetails.GetRowCellValue(i, colCharniSizeId).ToString();
                        galaProcessMaster.Weight = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(i, colGalaCarat).ToString());
                        galaProcessMaster.LossWeight = 0;
                        galaProcessMaster.RejectionWeight = 0;
                        galaProcessMaster.HandOverById = lueReceiveFrom.EditValue.ToString();
                        galaProcessMaster.HandOverToId = lueSendto.EditValue.ToString();
                        galaProcessMaster.SlipNo = grvParticularsDetails.GetRowCellValue(i, colSlipNo1).ToString();
                        galaProcessMaster.GalaCategoy = 0;
                        galaProcessMaster.Remarks = txtRemark.Text;
                        galaProcessMaster.IsDelete = false;
                        galaProcessMaster.CreatedDate = DateTime.Now;
                        galaProcessMaster.CreatedBy = Common.LoginUserID;
                        galaProcessMaster.UpdatedDate = DateTime.Now;
                        galaProcessMaster.UpdatedBy = Common.LoginUserID;

                        var Result = await _galaProcessMasterRepository.AddGalaProcessAsync(galaProcessMaster);
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
            grdParticularsDetails.DataSource = null;
            dtDate.EditValue = DateTime.Now;
            dtTime.EditValue = DateTime.Now;
            txtRemark.Text = "";
            lueReceiveFrom.EditValue = null;
            lueSendto.EditValue = null;
            lueKapan.EditValue = null;
            repoSlipNo.DataSource = null;

            await GetMaxSrNo();
            await GetEmployeeList();
            await GetGalaProcessSendDetail();
            lueReceiveFrom.Select();
            lueReceiveFrom.Focus();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void FrmGalaSend_KeyDown(object sender, KeyEventArgs e)
        {
            Common.MoveToNextControl(sender, e, this);
        }
    }
}