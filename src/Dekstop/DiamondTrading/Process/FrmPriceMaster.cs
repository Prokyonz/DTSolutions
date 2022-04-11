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
    public partial class FrmPriceMaster : DevExpress.XtraEditors.XtraForm
    {
        CompanyMasterRepository _companyMasterRepository;
        SizeMasterRepository _sizeMasterRepository;
        NumberMasterRepository _numberMasterRepository;
        PartyMasterRepository _partyMasterRepository;
        List<BoilProcessSend> ListAssortmentProcessSend;

        public FrmPriceMaster()
        {
            InitializeComponent();
            _companyMasterRepository = new CompanyMasterRepository();
            _partyMasterRepository = new PartyMasterRepository();

            LoadCompany();

            //if (RejectionType == 1)
            //{
            //    SetThemeColors(Color.FromArgb(250, 243, 197));
            //    this.Text = "REJECTION RECEIVE";
            //}
            //else if (RejectionType == 2)
            //{
            //    SetThemeColors(Color.FromArgb(215, 246, 214));
            //    this.Text = "REJECTION SEND";
            //}
        }

        private async void LoadCompany()
        {
            var data = await _companyMasterRepository.GetAllCompanyAsync();

            lueCompany.Properties.DataSource = data;
            lueCompany.Properties.DisplayMember = "Name";
            lueCompany.Properties.ValueMember = "Id";
        }

        private async void LoadSize()
        {
            var data = await _sizeMasterRepository.GetAllSizeAsync();

            lueCompany.Properties.DataSource = data;
            lueCompany.Properties.DisplayMember = "Name";
            lueCompany.Properties.ValueMember = "Id";
        }

        private async void LoadNumber()
        {
            var data = await _numberMasterRepository.GetAllNumberAsync();

            lueCompany.Properties.DataSource = data;
            lueCompany.Properties.DisplayMember = "Name";
            lueCompany.Properties.ValueMember = "Id";
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
            }
        }

        private async void FrmBoilSend_Load(object sender, EventArgs e)
        {
            dtDate.EditValue = DateTime.Now;
            dtTime.EditValue = DateTime.Now;

            //SetThemeColors(Color.FromArgb(250, 243, 197));
        }

        private async Task GetEmployeeList()
        {
            var EmployeeDetailList = await _partyMasterRepository.GetAllPartyAsync(Common.LoginCompany.ToString(), PartyTypeMaster.Employee, PartyTypeMaster.Other);
            lueCompany.Properties.DataSource = EmployeeDetailList;
            lueCompany.Properties.DisplayMember = "Name";
            lueCompany.Properties.ValueMember = "Id";

            lueSendto.Properties.DataSource = EmployeeDetailList;
            lueSendto.Properties.DisplayMember = "Name";
            lueSendto.Properties.ValueMember = "Id";
        }

        private async Task GetBoilProcessSendDetail()
        {
            //grdParticularsDetails.DataSource = GetDTColumnsforParticularDetails();
            //ListAssortmentProcessSend = await _boilMasterRepository.GetBoilSendToDetails(Common.LoginCompany.ToString(), Common.LoginBranch.ToString(), Common.LoginFinancialYear.ToString());

            //lueKapan.Properties.DataSource = ListAssortmentProcessSend.Select(x => new { x.KapanId, x.Kapan }).Distinct().ToList();
            //lueKapan.Properties.DisplayMember = "Kapan";
            //lueKapan.Properties.ValueMember = "KapanId";
        }

        private static DataTable GetDTColumnsforParticularDetails()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("SlipNo");
            dt.Columns.Add("Size");
            dt.Columns.Add("AvailableWeight");
            dt.Columns.Add("BoilCarat");
            dt.Columns.Add("SizeId");
            dt.Columns.Add("ShapeId");
            dt.Columns.Add("PurityId");
            dt.Columns.Add("PurchaseDetailsId");
            dt.Columns.Add("SlipNo1");
            return dt;
        }

        private void grvParticularsDetails_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == colNumber)
                {
                    //grvParticularsDetails.SetRowCellValue(e.RowHandle, colACarat, ((Repository.Entities.Models.BoilProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).AvailableWeight);
                    //grvParticularsDetails.SetRowCellValue(e.RowHandle, colSizeId, ((Repository.Entities.Models.BoilProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).SizeId);
                    //grvParticularsDetails.SetRowCellValue(e.RowHandle, colShapeId, ((Repository.Entities.Models.BoilProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).ShapeId);
                    //grvParticularsDetails.SetRowCellValue(e.RowHandle, colPurityId, ((Repository.Entities.Models.BoilProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).PurityId);
                    //grvParticularsDetails.SetRowCellValue(e.RowHandle, colSlipNo1, ((Repository.Entities.Models.BoilProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).SlipNo);
                    //grvParticularsDetails.SetRowCellValue(e.RowHandle, colPurchaseDetailsId, ((Repository.Entities.Models.BoilProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).PurchaseDetailsId);
                    //grvPurchaseItems.FocusedRowHandle = e.RowHandle;
                    //grvPurchaseItems.FocusedColumn = colBoilCarat;
                }
            }
            catch
            {

            }
        }

        private void FrmBoilSend_KeyDown(object sender, KeyEventArgs e)
        {
            Common.MoveToNextControl(sender, e, this);
        }

        private bool CheckValidation()
        {
            if (lueCompany.EditValue == null)
            {
                MessageBox.Show("Please select Receive from name", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                lueCompany.Focus();
                return false;
            }
            else if (lueSendto.EditValue == null)
            {
                MessageBox.Show("Please select Send to name", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                lueSendto.Focus();
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

                bool IsSuccess = false;
                try
                {
                    for (int i = 0; i < grvParticularsDetails.RowCount; i++)
                    {
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
            ListAssortmentProcessSend = null;
            dtDate.EditValue = DateTime.Now;
            dtTime.EditValue = DateTime.Now;
            //txtRemark.Text = "";
            lueCompany.EditValue = null;
            lueSendto.EditValue = null;
            //lueKapan.EditValue = null;
            repoSlipNo.DataSource = null;

            //await GetMaxSrNo();
            await GetEmployeeList();
            await GetBoilProcessSendDetail();

            lueCompany.Select();
            lueCompany.Focus();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}