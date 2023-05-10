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
    public partial class FrmAssortProcessSend : DevExpress.XtraEditors.XtraForm
    {
        AccountToAssortMasterRepository _accountToAssortMasterRepository;
        PartyMasterRepository _partyMasterRepository;
        List<AssortmentProcessSend> ListAssortmentProcessSend;

        public FrmAssortProcessSend()
        {
            InitializeComponent();
            _accountToAssortMasterRepository = new AccountToAssortMasterRepository();
            _partyMasterRepository = new PartyMasterRepository();
        }

        private void SetThemeColors(Color color)
        {
            if (!color.ToArgb().ToString().Equals(Color.FromArgb(0).Name))
            {
                grpGroup1.AppearanceCaption.BorderColor = color;
                grpGroup2.AppearanceCaption.BorderColor = color;
            }
        }

        private async void FrmAssortProcessSend_Load(object sender, EventArgs e)
        {
            dtDate.EditValue = DateTime.Now;
            dtTime.EditValue = DateTime.Now;

            SetThemeColors(Color.FromArgb(250, 243, 197));

            await GetMaxSrNo();
            GetDepartmentList();
            await GetEmployeeList();
            await GetKapanDetail();
            //await GetAssortProcessSendDetail();
        }

        private void GetDepartmentList()
        {
            var Department = DepartmentMaster1.GetAllDepartment();
            List<DepartmentMaster> departmentMaster = new List<DepartmentMaster>
            {
                new DepartmentMaster {Id = 1, Name = "Boil" },
            };
            Department = departmentMaster;            

            if (Department != null)
            {
                lueDepartment.Properties.DataSource = Department;
                lueDepartment.Properties.DisplayMember = "Name";
                lueDepartment.Properties.ValueMember = "Id";
            }

            lueDepartment.EditValue = DepartmentMaster1.Boil;
        }

        private async Task GetMaxSrNo()
        {
            var SrNo = await _accountToAssortMasterRepository.GetMaxSrNoAsync(Common.LoginCompany.ToString(), Common.LoginBranch.ToString(), Common.LoginFinancialYear);
            txtSerialNo.Text = SrNo.ToString();
        }

        private async Task GetEmployeeList()
        {
            var EmployeeDetailList = await _partyMasterRepository.GetAllPartyAsync(Common.LoginCompany.ToString(), PartyTypeMaster.Employee, new int[] { PartyTypeMaster.Other, PartyTypeMaster.Process });
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

        private async Task GetAssortProcessSendDetail()
        {
            grdParticularsDetails.DataSource = GetDTColumnsforParticularDetails();

            if (Convert.ToInt32(lueDepartment.EditValue) == DepartmentMaster1.Boil)
            {
                ListAssortmentProcessSend = await _accountToAssortMasterRepository.GetAssortmentSendToDetails(Common.LoginCompany.ToString(), Common.LoginBranch.ToString(), Common.LoginFinancialYear.ToString());

                if (lueKapan.EditValue != null && ListAssortmentProcessSend != null)
                {
                    repoSlipNo.DataSource = ListAssortmentProcessSend.Where(x => x.KapanId == lueKapan.EditValue.ToString()).ToList();
                    repoSlipNo.DisplayMember = "SlipNo";
                    repoSlipNo.ValueMember = "Id";

                    repoSlipNo.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                    repoSlipNo.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private static DataTable GetDTColumnsforParticularDetails()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("SlipNo");
            dt.Columns.Add("Size");
            dt.Columns.Add("AvailableWeight");
            dt.Columns.Add("AssignCarat");
            dt.Columns.Add("SizeId");
            dt.Columns.Add("ShapeId");
            dt.Columns.Add("PurityId");
            dt.Columns.Add("PurchaseDetailsId");
            dt.Columns.Add("SlipNo1");
            dt.Columns.Add("StockId");
            return dt;
        }

        private void grvParticularsDetails_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == colSlipNo)
                {
                    grvParticularsDetails.SetRowCellValue(e.RowHandle, colSize, ((Repository.Entities.Models.AssortmentProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).Size);
                    grvParticularsDetails.SetRowCellValue(e.RowHandle, colACarat, ((Repository.Entities.Models.AssortmentProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).AvailableWeight);
                    grvParticularsDetails.SetRowCellValue(e.RowHandle, colSizeId, ((Repository.Entities.Models.AssortmentProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).SizeId);
                    grvParticularsDetails.SetRowCellValue(e.RowHandle, colShapeId, ((Repository.Entities.Models.AssortmentProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).ShapeId);
                    grvParticularsDetails.SetRowCellValue(e.RowHandle, colPurityId, ((Repository.Entities.Models.AssortmentProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).PurityId);
                    grvParticularsDetails.SetRowCellValue(e.RowHandle, colSlipNo1, ((Repository.Entities.Models.AssortmentProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).SlipNo);
                    grvParticularsDetails.SetRowCellValue(e.RowHandle, colPurchaseDetailsId, ((Repository.Entities.Models.AssortmentProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).PurchaseDetailsId);
                    grvParticularsDetails.SetRowCellValue(e.RowHandle, colStockId, ((Repository.Entities.Models.AssortmentProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).StockId);
                    //grvPurchaseItems.FocusedRowHandle = e.RowHandle;
                    //grvPurchaseItems.FocusedColumn = colBoilCarat;
                }
            }
            catch
            {

            }
        }

        private void grvParticularsDetails_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (grvParticularsDetails.FocusedColumn == colAssignCarat)
            {
                if (grvParticularsDetails.GetRowCellValue(e.RowHandle, colAssignCarat) == DBNull.Value)
                    return;
                if (Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(e.RowHandle, colAssignCarat)) == 0)
                {
                    e.ErrorText = "0 caret is not allowed to process";
                    grvParticularsDetails.FocusedRowHandle = e.RowHandle;
                    grvParticularsDetails.FocusedColumn = colAssignCarat;
                    e.Valid = false;
                }
                else if ((Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(e.RowHandle, colACarat)) - Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(e.RowHandle, colAssignCarat))) < 0)
                {
                    e.ErrorText = "Max " + Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(e.RowHandle, colACarat)) + " carets availble to process";
                    grvParticularsDetails.FocusedRowHandle = e.RowHandle;
                    grvParticularsDetails.FocusedColumn = colAssignCarat;
                    e.Valid = false;
                }
            }
        }

        private void FrmAssortProcessSend_KeyDown(object sender, KeyEventArgs e)
        {
            Common.MoveToNextControl(sender, e, this);
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
            else if (lueDepartment.EditValue == null)
            {
                MessageBox.Show("Please select Department", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                lueDepartment.Focus();
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

                string AccountToAssortMasterId = Guid.NewGuid().ToString();

                List<AccountToAssortDetails> accountToAssortDetailsList = new List<AccountToAssortDetails>();
                AccountToAssortDetails accountToAssortDetails = new AccountToAssortDetails();
                for (int i = 0; i < grvParticularsDetails.RowCount; i++)
                {
                    accountToAssortDetails = new AccountToAssortDetails();
                    accountToAssortDetails.Id = Guid.NewGuid().ToString();
                    accountToAssortDetails.AccountToAssortMasterId = AccountToAssortMasterId;
                    accountToAssortDetails.SlipNo = grvParticularsDetails.GetRowCellValue(i, colSlipNo1).ToString();
                    accountToAssortDetails.ShapeId = grvParticularsDetails.GetRowCellValue(i, colShapeId).ToString();
                    accountToAssortDetails.SizeId = grvParticularsDetails.GetRowCellValue(i, colSizeId).ToString();
                    accountToAssortDetails.PurityId = grvParticularsDetails.GetRowCellValue(i, colPurityId).ToString();
                    accountToAssortDetails.PurchaseDetailsId = grvParticularsDetails.GetRowCellValue(i, colPurchaseDetailsId).ToString();
                    //accountToAssortDetails.CharniProcessId = null;
                    //accountToAssortDetails.GalaProcessId = null;
                    //accountToAssortDetails.NumberProcessId = null;
                    accountToAssortDetails.Weight = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(i, colACarat).ToString());
                    accountToAssortDetails.AssignWeight = Convert.ToDecimal(grvParticularsDetails.GetRowCellValue(i, colAssignCarat).ToString());
                    accountToAssortDetails.StockId = grvParticularsDetails.GetRowCellValue(i, colStockId).ToString();

                    accountToAssortDetailsList.Insert(i, accountToAssortDetails);
                }

                AccountToAssortMaster accountToAssortMaster = new AccountToAssortMaster();
                accountToAssortMaster.Id = AccountToAssortMasterId;
                accountToAssortMaster.CompanyId = Common.LoginCompany.ToString();
                accountToAssortMaster.BranchId = Common.LoginBranch.ToString();
                accountToAssortMaster.FinancialYearId = Common.LoginFinancialYear.ToString();
                accountToAssortMaster.EntryDate = Convert.ToDateTime(dtDate.Text).ToString("yyyyMMdd");
                accountToAssortMaster.EntryTime = Convert.ToDateTime(dtTime.Text).ToString("hh:mm:ss ttt");
                accountToAssortMaster.AccountToAssortType = Convert.ToInt32(ProcessType.Send);
                accountToAssortMaster.FromParyId = lueReceiveFrom.EditValue.ToString();
                accountToAssortMaster.ToPartyId = lueSendto.EditValue.ToString();
                accountToAssortMaster.KapanId = lueKapan.EditValue.ToString();
                accountToAssortMaster.Department = Convert.ToInt32(lueDepartment.EditValue);
                accountToAssortMaster.Remarks = txtRemark.Text;
                accountToAssortMaster.AccountToAssortDetails = accountToAssortDetailsList;
                accountToAssortMaster.IsDelete = false;
                accountToAssortMaster.CreatedDate = DateTime.Now;
                accountToAssortMaster.CreatedBy = Common.LoginUserID;
                accountToAssortMaster.UpdatedDate = DateTime.Now;
                accountToAssortMaster.UpdatedBy = Common.LoginUserID;

                var Result = await _accountToAssortMasterRepository.AddAccountToAssortAsync(accountToAssortMaster);

                if (Result != null)
                {
                    Reset();
                    MessageBox.Show(AppMessages.GetString(AppMessageID.SaveSuccessfully), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception Ex)
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
            lueKapan.EditValue = null;

            await GetMaxSrNo();
            GetDepartmentList();
            await GetEmployeeList();
            await GetKapanDetail();
            await GetAssortProcessSendDetail();
            lueReceiveFrom.Focus();
        }

        private async void lueDepartment_EditValueChanged(object sender, EventArgs e)
        {
            await GetAssortProcessSendDetail();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void lueKapan_EditValueChanged(object sender, EventArgs e)
        {
            if (lueKapan.EditValue != null && ListAssortmentProcessSend != null)
            {
                repoSlipNo.DataSource = ListAssortmentProcessSend.Where(x => x.KapanId == lueKapan.EditValue.ToString()).ToList();
                repoSlipNo.DisplayMember = "SlipNo";
                repoSlipNo.ValueMember = "Id";

                repoSlipNo.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                repoSlipNo.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
            }
        }
    }
}