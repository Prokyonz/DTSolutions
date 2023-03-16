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

namespace DiamondTrading.Utility
{
    public partial class FrmOpeningStock : DevExpress.XtraEditors.XtraForm
    {
        private OpeningStockMasterRepositody _openingStockMasterRepositody;
        public FrmOpeningStock()
        {
            InitializeComponent();
            _openingStockMasterRepositody = new OpeningStockMasterRepositody();
        }

        private async void FrmOpeningStock_Load(object sender, EventArgs e)
        {
            dtDate.EditValue = DateTime.Now;
            dtTime.EditValue = DateTime.Now;

            await LoadOpeningStockItemDetails();
        }

        private async Task LoadOpeningStockItemDetails()
        {
            grdTransferItemDetails.DataSource = GetDTColumnsforGridDetails();

            await GetMaxSrNo();

            //Company
            await LoadCompany();

            //Branch
            await GetBrancheDetail();

            //Employee
            await GetEmployeeList();

            //Category
            GetCategoryDetail();

            await GetShapeDetail();

            //Size
            await GetSizeDetail();

            await GetPurityDetail();

            //Kapan
            await GetKapanDetail();

            //NumberSize
            await GetNumberSizeDetail();

            grvTransferItemDetails.BestFitColumns();
        }

        private async Task GetMaxSrNo()
        {
            var SrNo = await _openingStockMasterRepositody.GetMaxAsync(Common.LoginCompany.ToString(), Common.LoginFinancialYear);
            txtSerialNo.Text = SrNo.ToString();
        }

        private async Task LoadCompany()
        {
            CompanyMasterRepository companyMasterRepository = new CompanyMasterRepository();
            var result = await companyMasterRepository.GetAllCompanyAsync();
            lueCompany.Properties.DataSource = result;
            lueCompany.Properties.DisplayMember = "Name";
            lueCompany.Properties.ValueMember = "Id";
            lueCompany.EditValue = Common.LoginCompany;
        }

        private async Task GetBrancheDetail()
        {
            if (lueCompany.EditValue != null)
            {
                BranchMasterRepository branchMasterRepository = new BranchMasterRepository();
                var branchMaster = await branchMasterRepository.GetAllBranchAsync(lueCompany.EditValue.ToString());
                repoBranch.DataSource = branchMaster;
                repoBranch.DisplayMember = "Name";
                repoBranch.ValueMember = "Id";
            }
            else
            {
                repoBranch.DataSource = null;
            }
        }

        private async Task GetEmployeeList()
        {
            PartyMasterRepository partyMasterRepository = new PartyMasterRepository();
            var EmployeeDetailList = await partyMasterRepository.GetAllPartyAsync(Common.LoginCompany.ToString(), PartyTypeMaster.Employee, new int[] { PartyTypeMaster.Other });
            lueTransferBy.Properties.DataSource = EmployeeDetailList;
            lueTransferBy.Properties.DisplayMember = "Name";
            lueTransferBy.Properties.ValueMember = "Id";
        }

        private void GetCategoryDetail()
        {
            var Category = OpeningStockCategoryMaster.GetAllCategory();

            if (Category != null)
            {
                repoCategory.DataSource = Category;
                repoCategory.DisplayMember = "Name";
                repoCategory.ValueMember = "Id";
            }
        }

        private async Task GetSizeDetail()
        {
            SizeMasterRepository sizeMasterRepository = new SizeMasterRepository();
            var sizeMaster = await sizeMasterRepository.GetAllSizeAsync();

            repoSize.DataSource = sizeMaster;
            repoSize.DisplayMember = "Name";
            repoSize.ValueMember = "Id";
        }

        private async Task GetShapeDetail()
        {
            ShapeMasterRepository shapeMasterRepository = new ShapeMasterRepository();
            var shapeMaster = await shapeMasterRepository.GetAllShapeAsync();

            repoShape.DataSource = shapeMaster;
            repoShape.DisplayMember = "Name";
            repoShape.ValueMember = "Id";
        }

        private async Task GetPurityDetail()
        {
            PurityMasterRepository purityMasterRepository = new PurityMasterRepository();
            var purityMaster = await purityMasterRepository.GetAllPurityAsync();

            repoPuity.DataSource = purityMaster;
            repoPuity.DisplayMember = "Name";
            repoPuity.ValueMember = "Id";
        }

        private async Task GetKapanDetail()
        {
            KapanMasterRepository kapanMasterRepository = new KapanMasterRepository();
            var kapanMaster = await kapanMasterRepository.GetAllKapanAsync();

            repoKapan.DataSource = kapanMaster;
            repoKapan.DisplayMember = "Name";
            repoKapan.ValueMember = "Id";
        }

        private async Task GetNumberSizeDetail()
        {
            NumberMasterRepository numberMasterRepository = new NumberMasterRepository();
            var numberSizeMaster = await numberMasterRepository.GetAllNumberAsync();

            repoNumber.DataSource = numberSizeMaster;
            repoNumber.DisplayMember = "Name";
            repoNumber.ValueMember = "Id";
        }

        private async void lueCompany_EditValueChanged(object sender, EventArgs e)
        {
            await GetBrancheDetail();
        }

        private static DataTable GetDTColumnsforGridDetails()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Category");
            dt.Columns.Add("Branch");
            dt.Columns.Add("Kapan");
            dt.Columns.Add("Size");
            dt.Columns.Add("Shape");
            dt.Columns.Add("Purity");
            dt.Columns.Add("Carat");
            dt.Columns.Add("Number");
            dt.Columns.Add("Rate");
            dt.Columns.Add("Amount");
            return dt;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grvTransferItemDetails_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == colCategory)
                {
                    if (grvTransferItemDetails.GetRowCellValue(e.RowHandle, colCategory).ToString() == OpeningStockCategoryMaster.Kapan.ToString())
                    {
                        colNumber.Visible = false;
                    }
                    else
                    {
                        colNumber.Visible = true;
                    }
                }
                else if (e.Column == colCarat || e.Column == colRate)
                {
                    decimal Receivedcts = 0;
                    decimal Rate = 0;
                    if (grvTransferItemDetails.GetRowCellValue(e.RowHandle, colCarat).ToString().Trim().Length > 0)
                    {
                        Receivedcts = Convert.ToDecimal(grvTransferItemDetails.GetRowCellValue(e.RowHandle, colCarat).ToString());
                    }

                    if (grvTransferItemDetails.GetRowCellValue(e.RowHandle, colRate).ToString().Trim().Length > 0)
                    {
                        Rate = Convert.ToDecimal(grvTransferItemDetails.GetRowCellValue(e.RowHandle, colRate).ToString());
                    }

                    grvTransferItemDetails.SetRowCellValue(e.RowHandle, colAmount, Receivedcts * Rate);
                }
            }
            catch
            {

            }
        }

        private async void btnReset_Click(object sender, EventArgs e)
        {
            await Reset();
        }

        private async Task Reset()
        {
            grdTransferItemDetails.DataSource = null;
            dtDate.EditValue = DateTime.Now;
            dtTime.EditValue = DateTime.Now;
            txtRemark.Text = "";
            await LoadOpeningStockItemDetails();

            lueTransferBy.Focus();
            lueTransferBy.Select();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                
                this.Cursor = Cursors.WaitCursor;

                if (!CheckValidation())
                    return;

                string AccountToAssortMasterId = Guid.NewGuid().ToString();

                List<OpeningStockMaster> accountToAssortDetailsList = new List<OpeningStockMaster>();
                OpeningStockMaster openingStockMaster;
                NumberProcessMaster numberProcessMaster;
                bool IsStatus = false;
                string TempGuid = Guid.NewGuid().ToString();
                for (int i = 0; i < grvTransferItemDetails.RowCount; i++)
                {
                    string guid = Guid.NewGuid().ToString();
                    if (grvTransferItemDetails.GetRowCellValue(i, colCategory).ToString() == OpeningStockCategoryMaster.Number.ToString())
                    {
                        numberProcessMaster = new NumberProcessMaster();
                        numberProcessMaster.Id = Guid.NewGuid().ToString();
                        numberProcessMaster.NumberNo = 0;
                        numberProcessMaster.JangadNo = 0;
                        //galaProcessMaster.BoilJangadNo = Convert.ToInt32(lueKapan.GetColumnValue("BoilJangadNo").ToString());
                        numberProcessMaster.CompanyId = lueCompany.EditValue.ToString();
                        numberProcessMaster.BranchId = grvTransferItemDetails.GetRowCellValue(i, colBranch).ToString();
                        numberProcessMaster.EntryDate = Convert.ToDateTime(dtDate.Text).ToString("yyyyMMdd");
                        numberProcessMaster.EntryTime = Convert.ToDateTime(dtTime.Text).ToString("hh:mm:ss ttt");
                        numberProcessMaster.FinancialYearId = Common.LoginFinancialYear;
                        numberProcessMaster.NumberProcessType = Convert.ToInt32(ProcessType.OpeningStock);
                        numberProcessMaster.KapanId = grvTransferItemDetails.GetRowCellValue(i, colKapan).ToString();
                        numberProcessMaster.ShapeId = grvTransferItemDetails.GetRowCellValue(i, colShape).ToString();
                        numberProcessMaster.SizeId = grvTransferItemDetails.GetRowCellValue(i, colSize).ToString();
                        numberProcessMaster.PurityId = grvTransferItemDetails.GetRowCellValue(i, colPurity).ToString();
                        numberProcessMaster.CharniSizeId = grvTransferItemDetails.GetRowCellValue(i, colSize).ToString();
                        numberProcessMaster.Weight = 0;
                        //numberProcessMaster.GalaNumberId = grvTransferItemDetails.GetRowCellValue(i, colTypeId).ToString();
                        numberProcessMaster.NumberId = grvTransferItemDetails.GetRowCellValue(i, colNumber).ToString();
                        numberProcessMaster.NumberWeight = Convert.ToDecimal(grvTransferItemDetails.GetRowCellValue(i, colCarat).ToString());
                        numberProcessMaster.LossWeight = 0;
                        numberProcessMaster.RejectionWeight = 0;
                        numberProcessMaster.HandOverById = lueTransferBy.EditValue.ToString();
                        numberProcessMaster.HandOverToId = lueTransferBy.EditValue.ToString();
                        numberProcessMaster.SlipNo = "0";
                        numberProcessMaster.NumberCategoy = 0;
                        numberProcessMaster.Remarks = txtRemark.Text;

                        numberProcessMaster.TransferId = TempGuid;
                        numberProcessMaster.TransferType = "0";
                        numberProcessMaster.TransferEntryId = TempGuid;
                        numberProcessMaster.TransferCaratRate = Convert.ToDouble(grvTransferItemDetails.GetRowCellValue(i, colRate).ToString());

                        numberProcessMaster.IsDelete = false;
                        numberProcessMaster.CreatedDate = DateTime.Now;
                        numberProcessMaster.CreatedBy = Common.LoginUserID;
                        numberProcessMaster.UpdatedDate = DateTime.Now;
                        numberProcessMaster.UpdatedBy = Common.LoginUserID;

                        NumberProcessMasterRepository numberProcessMasterRepository = new NumberProcessMasterRepository();
                        var Result1 = await numberProcessMasterRepository.AddNumberProcessAsync(numberProcessMaster);
                        IsStatus = true;
                    }

                    openingStockMaster = new OpeningStockMaster();
                    openingStockMaster.Id = guid;
                    openingStockMaster.StockId = guid;
                    openingStockMaster.TransferId = TempGuid;
                    openingStockMaster.SrNo = Convert.ToInt32(txtSerialNo.Text);
                    openingStockMaster.EntryDate = Convert.ToDateTime(dtDate.Text).ToString("yyyyMMdd");
                    openingStockMaster.EntryTime = Convert.ToDateTime(dtTime.Text).ToString("hh:mm:ss ttt");
                    openingStockMaster.Category = Convert.ToInt32(grvTransferItemDetails.GetRowCellValue(i, colCategory));
                    openingStockMaster.CompanyId = lueCompany.EditValue.ToString();
                    openingStockMaster.BranchId = grvTransferItemDetails.GetRowCellValue(i, colBranch).ToString();
                    openingStockMaster.FinancialYearId = Common.LoginFinancialYear.ToString();

                    openingStockMaster.KapanId = grvTransferItemDetails.GetRowCellValue(i, colKapan).ToString();
                    openingStockMaster.SizeId = grvTransferItemDetails.GetRowCellValue(i, colSize).ToString();
                    if (grvTransferItemDetails.GetRowCellValue(i, colCategory).ToString() == OpeningStockCategoryMaster.Number.ToString())
                        openingStockMaster.NumberId = grvTransferItemDetails.GetRowCellValue(i, colNumber).ToString();

                    openingStockMaster.ShapeId = grvTransferItemDetails.GetRowCellValue(i, colShape).ToString();
                    openingStockMaster.PurityId = grvTransferItemDetails.GetRowCellValue(i, colPurity).ToString();

                    openingStockMaster.TotalCts = Convert.ToDecimal(grvTransferItemDetails.GetRowCellValue(i, colCarat).ToString());
                    openingStockMaster.Rate = Convert.ToDecimal(grvTransferItemDetails.GetRowCellValue(i, colRate).ToString());
                    openingStockMaster.Amount = Convert.ToDecimal(grvTransferItemDetails.GetRowCellValue(i, colAmount).ToString());

                    openingStockMaster.Remarks = txtRemark.Text;
                    openingStockMaster.CreatedDate = DateTime.Now;
                    openingStockMaster.CreatedBy = Common.LoginUserID;
                    openingStockMaster.UpdatedDate = DateTime.Now;
                    openingStockMaster.UpdatedBy = Common.LoginUserID;

                    var Result = await _openingStockMasterRepositody.AddOpeningStockAsync(openingStockMaster);
                    IsStatus = true;
                }

                if (IsStatus)
                {
                    await Reset();
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

        private bool CheckValidation()
        {
            if (lueCompany.EditValue == null)
            {
                MessageBox.Show("Please select Company name", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                lueCompany.Focus();
                return false;
            }
            else if (lueTransferBy.EditValue == null)
            {
                MessageBox.Show("Please select Transfer by name", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                lueTransferBy.Focus();
                return false;
            }
            else if (grvTransferItemDetails.RowCount == 0)
            {
                MessageBox.Show("Please select Particulars Details", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                grvTransferItemDetails.Focus();
                return false;
            }
            return true;
        }
    }
}