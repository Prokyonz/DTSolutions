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
    public partial class FrmNumberSend : DevExpress.XtraEditors.XtraForm
    {
        NumberProcessMasterRepository _numberProcessMasterRepository;
        PartyMasterRepository _partyMasterRepository;
        List<NumberProcessSend> ListNumberProcessSend;
        public FrmNumberSend()
        {
            InitializeComponent();
            _numberProcessMasterRepository = new NumberProcessMasterRepository();
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

        private async void FrmNumberSend_Load(object sender, EventArgs e)
        {
            dtDate.EditValue = DateTime.Now;
            timer1.Start();

            SetThemeColors(Color.FromArgb(250, 243, 197));

            await GetMaxSrNo();
            await GetEmployeeList();
            await GetNumberProcessSendDetail();
        }

        private async Task GetMaxSrNo()
        {
            var SrNo = await _numberProcessMasterRepository.GetMaxSrNoAsync(Common.LoginCompany.ToString(), Common.LoginBranch.ToString(), Common.LoginFinancialYear, 0);
            txtSerialNo.Text = SrNo.ToString();
        }

        private async Task GetEmployeeList()
        {
            var EmployeeDetailList = await _partyMasterRepository.GetAllPartyAsync(Common.LoginCompany.ToString(), PartyTypeMaster.Employee, new int[] { PartyTypeMaster.Other });
            lueReceiveFrom.Properties.DataSource = EmployeeDetailList;
            lueReceiveFrom.Properties.DisplayMember = "Name";
            lueReceiveFrom.Properties.ValueMember = "Id";

            lueSendto.Properties.DataSource = EmployeeDetailList;
            lueSendto.Properties.DisplayMember = "Name";
            lueSendto.Properties.ValueMember = "Id";
        }

        private async Task GetNumberProcessSendDetail()
        {
            grdParticularsDetails.DataSource = GetDTColumnsforParticularDetails();
            ListNumberProcessSend = await _numberProcessMasterRepository.GetNumberSendToDetails(Common.LoginCompany.ToString(), Common.LoginBranch.ToString(), Common.LoginFinancialYear.ToString());

            lueKapan.Properties.DataSource = ListNumberProcessSend.Select(x => new { x.KapanId, x.Kapan }).Distinct().ToList();
            lueKapan.Properties.DisplayMember = "Kapan";
            lueKapan.Properties.ValueMember = "KapanId";
        }

        private static DataTable GetDTColumnsforParticularDetails()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("SlipNo");
            dt.Columns.Add("Size");
            dt.Columns.Add("AvailableWeight");
            dt.Columns.Add("NumberCarat");
            dt.Columns.Add("SizeId");
            dt.Columns.Add("ShapeId");
            dt.Columns.Add("PurityId");
            dt.Columns.Add("SlipNo1");
            dt.Columns.Add("GalaNumberId");
            dt.Columns.Add("CharniSizeId");
            dt.Columns.Add("CharniSize");
            return dt;
        }

        private void lueKapan_EditValueChanged(object sender, EventArgs e)
        {
            if (lueKapan.EditValue != null && ListNumberProcessSend != null)
            {
                repoSlipNo.DataSource = ListNumberProcessSend.Where(x => x.KapanId == lueKapan.EditValue.ToString()).ToList();
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
                    grvParticularsDetails.SetRowCellValue(e.RowHandle, colSlipNo1, ((Repository.Entities.Models.NumberProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).SlipNo);
                    grvParticularsDetails.SetRowCellValue(e.RowHandle, colSize, ((Repository.Entities.Models.NumberProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).Size);
                    grvParticularsDetails.SetRowCellValue(e.RowHandle, colACarat, ((Repository.Entities.Models.NumberProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).AvailableWeight);
                    grvParticularsDetails.SetRowCellValue(e.RowHandle, colSizeId, ((Repository.Entities.Models.NumberProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).SizeId);
                    grvParticularsDetails.SetRowCellValue(e.RowHandle, colShapeId, ((Repository.Entities.Models.NumberProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).ShapeId);
                    grvParticularsDetails.SetRowCellValue(e.RowHandle, colPurityId, ((Repository.Entities.Models.NumberProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).PurityId);
                    grvParticularsDetails.SetRowCellValue(e.RowHandle, colGalaNumberId, ((Repository.Entities.Models.NumberProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).GalaNumberId);
                    grvParticularsDetails.SetRowCellValue(e.RowHandle, colCharniSizeId, ((Repository.Entities.Models.NumberProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).CharniSizeId);
                    grvParticularsDetails.SetRowCellValue(e.RowHandle, colCharniSize, ((Repository.Entities.Models.NumberProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).CharniSize);
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

                NumberProcessMaster numberProcessMaster = new NumberProcessMaster();
                bool IsSuccess = false;
                try
                {
                    for (int i = 0; i < grvParticularsDetails.RowCount; i++)
                    {
                        numberProcessMaster = new NumberProcessMaster();
                        numberProcessMaster.Id = Guid.NewGuid().ToString();
                        numberProcessMaster.NumberNo = Convert.ToInt32(txtSerialNo.Text);
                        numberProcessMaster.JangadNo = Convert.ToInt32(txtSerialNo.Text);
                        //galaProcessMaster.BoilJangadNo = Convert.ToInt32(grvParticularsDetails.GetRowCellValue(i, colBoilNo1).ToString());
                        numberProcessMaster.CompanyId = Common.LoginCompany;
                        numberProcessMaster.BranchId = Common.LoginBranch;
                        numberProcessMaster.EntryDate = Convert.ToDateTime(dtDate.Text).ToString("yyyyMMdd");
                        numberProcessMaster.EntryTime = Convert.ToDateTime(dtTime.Text).ToString("hh:mm:ss ttt");
                        numberProcessMaster.FinancialYearId = Common.LoginFinancialYear;
                        numberProcessMaster.NumberProcessType = Convert.ToInt32(ProcessType.Send);
                        numberProcessMaster.KapanId = lueKapan.EditValue.ToString();
                        numberProcessMaster.ShapeId = grvParticularsDetails.GetRowCellValue(i, colShapeId).ToString();
                        numberProcessMaster.SizeId = grvParticularsDetails.GetRowCellValue(i, colSizeId).ToString();
                        numberProcessMaster.PurityId = grvParticularsDetails.GetRowCellValue(i, colPurityId).ToString();
                        numberProcessMaster.GalaNumberId = grvParticularsDetails.GetRowCellValue(i, colGalaNumberId).ToString();
                        numberProcessMaster.CharniSizeId = grvParticularsDetails.GetRowCellValue(i, colCharniSizeId).ToString();
                        numberProcessMaster.Weight = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(i, colNumberCarat).ToString());
                        numberProcessMaster.LossWeight = 0;
                        numberProcessMaster.RejectionWeight = 0;
                        numberProcessMaster.HandOverById = lueReceiveFrom.EditValue.ToString();
                        numberProcessMaster.HandOverToId = lueSendto.EditValue.ToString();
                        numberProcessMaster.SlipNo = grvParticularsDetails.GetRowCellValue(i, colSlipNo1).ToString();
                        numberProcessMaster.NumberCategoy = 0;
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
            await GetNumberProcessSendDetail();
            lueReceiveFrom.Select();
            lueReceiveFrom.Focus();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void FrmNumberSend_KeyDown(object sender, KeyEventArgs e)
        {
            Common.MoveToNextControl(sender, e, this);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dtTime.EditValue = DateTime.Now;
        }
    }
}