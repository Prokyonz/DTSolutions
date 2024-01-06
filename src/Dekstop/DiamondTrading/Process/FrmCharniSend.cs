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
    public partial class FrmCharniSend : DevExpress.XtraEditors.XtraForm
    {
        CharniProcessMasterRepository _charniProcessMasterRepository;
        PartyMasterRepository _partyMasterRepository;
        List<CharniProcessSend> ListCharniProcessSend;
        public FrmCharniSend()
        {
            InitializeComponent();
            _charniProcessMasterRepository = new CharniProcessMasterRepository();
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

        private async void FrmCharniSend_Load(object sender, EventArgs e)
        {
            dtDate.EditValue = DateTime.Now;
            timer1.Start();

            SetThemeColors(Color.FromArgb(250, 243, 197));

            await GetMaxSrNo();
            await GetEmployeeList();
            await GetCharniProcessSendDetail();
        }

        private async Task GetMaxSrNo()
        {
            var SrNo = await _charniProcessMasterRepository.GetMaxSrNoAsync(Common.LoginCompany.ToString(), Common.LoginBranch.ToString(), Common.LoginFinancialYear, 0);
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

        private async Task GetKapanDetail()
        {
            KapanMasterRepository kapanMasterRepository = new KapanMasterRepository();
            var kapanMaster = await kapanMasterRepository.GetAllKapanAsync(Common.LoginCompany);
            lueKapan.Properties.DataSource = kapanMaster;
            lueKapan.Properties.DisplayMember = "Name";
            lueKapan.Properties.ValueMember = "Id";
        }

        private async Task GetCharniProcessSendDetail()
        {
            grdParticularsDetails.DataSource = GetDTColumnsforParticularDetails();
            ListCharniProcessSend = await _charniProcessMasterRepository.GetCharniSendToDetails(Common.LoginCompany.ToString(), Common.LoginBranch.ToString(), Common.LoginFinancialYear.ToString());

            lueKapan.Properties.DataSource = ListCharniProcessSend.Select(x => new { x.KapanId, x.Kapan }).Distinct().ToList();
            lueKapan.Properties.DisplayMember = "Kapan";
            lueKapan.Properties.ValueMember = "KapanId";
        }

        private static DataTable GetDTColumnsforParticularDetails()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("BoilNo");
            dt.Columns.Add("SlipNo");
            dt.Columns.Add("Size");
            dt.Columns.Add("AvailableWeight");
            dt.Columns.Add("CharniCarat");
            dt.Columns.Add("SizeId");
            dt.Columns.Add("ShapeId");
            dt.Columns.Add("PurityId");
            dt.Columns.Add("BoilNo1");
            return dt;
        }

        private void lueKapan_EditValueChanged(object sender, EventArgs e)
        {
            if (lueKapan.EditValue != null && ListCharniProcessSend != null)
            {
                repoSlipNo.DataSource = ListCharniProcessSend.Where(x => x.KapanId==lueKapan.EditValue.ToString()).ToList();
                repoSlipNo.DisplayMember = "BoilNo";
                repoSlipNo.ValueMember = "Id";

                repoSlipNo.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                repoSlipNo.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
            }
        }

        private void grvParticularsDetails_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == colSrNo)
                {
                    grvParticularsDetails.SetRowCellValue(e.RowHandle, colSlipNo, ((Repository.Entities.Models.CharniProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).SlipNo);
                    grvParticularsDetails.SetRowCellValue(e.RowHandle, colSize, ((Repository.Entities.Models.CharniProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).Size);
                    grvParticularsDetails.SetRowCellValue(e.RowHandle, colACarat, ((Repository.Entities.Models.CharniProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).AvailableWeight);
                    grvParticularsDetails.SetRowCellValue(e.RowHandle, colSizeId, ((Repository.Entities.Models.CharniProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).SizeId);
                    grvParticularsDetails.SetRowCellValue(e.RowHandle, colShapeId, ((Repository.Entities.Models.CharniProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).ShapeId);
                    grvParticularsDetails.SetRowCellValue(e.RowHandle, colPurityId, ((Repository.Entities.Models.CharniProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).PurityId);
                    grvParticularsDetails.SetRowCellValue(e.RowHandle, colBoilNo1, ((Repository.Entities.Models.CharniProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).BoilNo);

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

                CharniProcessMaster charniProcessMaster = new CharniProcessMaster();
                bool IsSuccess = false;
                try
                {
                    for (int i = 0; i < grvParticularsDetails.RowCount; i++)
                    {
                        charniProcessMaster = new CharniProcessMaster();
                        charniProcessMaster.Id = Guid.NewGuid().ToString();
                        charniProcessMaster.CharniNo = Convert.ToInt32(txtSerialNo.Text);
                        charniProcessMaster.JangadNo = Convert.ToInt32(txtSerialNo.Text);
                        charniProcessMaster.BoilJangadNo = Convert.ToInt32(grvParticularsDetails.GetRowCellValue(i, colBoilNo1).ToString());
                        charniProcessMaster.CompanyId = Common.LoginCompany;
                        charniProcessMaster.BranchId = Common.LoginBranch;
                        charniProcessMaster.EntryDate = Convert.ToDateTime(dtDate.Text).ToString("yyyyMMdd");
                        charniProcessMaster.EntryTime = Convert.ToDateTime(dtTime.Text).ToString("hh:mm:ss ttt");
                        charniProcessMaster.FinancialYearId = Common.LoginFinancialYear;
                        charniProcessMaster.CharniType = Convert.ToInt32(ProcessType.Send);
                        charniProcessMaster.KapanId = lueKapan.EditValue.ToString();
                        charniProcessMaster.ShapeId = grvParticularsDetails.GetRowCellValue(i, colShapeId).ToString();
                        charniProcessMaster.SizeId = grvParticularsDetails.GetRowCellValue(i, colSizeId).ToString();
                        charniProcessMaster.PurityId = grvParticularsDetails.GetRowCellValue(i, colPurityId).ToString();
                        charniProcessMaster.Weight = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(i, colCharniCarat).ToString());
                        charniProcessMaster.LossWeight = 0;
                        charniProcessMaster.RejectionWeight = 0;
                        charniProcessMaster.HandOverById = lueReceiveFrom.EditValue.ToString();
                        charniProcessMaster.HandOverToId = lueSendto.EditValue.ToString();
                        charniProcessMaster.SlipNo = grvParticularsDetails.GetRowCellValue(i, colSlipNo).ToString();
                        charniProcessMaster.CharniCategoy = 0;
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
            await GetCharniProcessSendDetail();
            lueReceiveFrom.Select();
            lueReceiveFrom.Focus();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void FrmCharniSend_KeyDown(object sender, KeyEventArgs e)
        {
            Common.MoveToNextControl(sender, e, this);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dtTime.EditValue = DateTime.Now;
        }
    }
}