using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using EFCore.SQL.Repository;
using Newtonsoft.Json;
using Repository.Entities;
using Repository.Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiamondTrading.Process
{
    public partial class FrmTransferEntry : DevExpress.XtraEditors.XtraForm
    {
        TransferMasterRepository _transferMasterRepository;
        SalesMasterRepository _salesMasterRepository;
        SalesItemObj _salesItemObj;
        List<CaratCategoryType> _caratCategoryTypes;

        public FrmTransferEntry()
        {
            InitializeComponent();
            _transferMasterRepository = new TransferMasterRepository();
            _salesMasterRepository = new SalesMasterRepository();
            _salesItemObj = new SalesItemObj();
        }

        private void FrmTransferEntry_Load(object sender, EventArgs e)
        {
            dtDate.EditValue = DateTime.Now;
            dtTime.EditValue = DateTime.Now;

            LoadTransferItemDetails();
        }

        private static DataTable GetDTColumnsforPurchaseDetails()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Category");
            dt.Columns.Add("Branch");
            dt.Columns.Add("Shape");
            dt.Columns.Add("Size");
            dt.Columns.Add("Purity");
            dt.Columns.Add("Kapan");
            dt.Columns.Add("Carat");
            dt.Columns.Add("Rate");
            dt.Columns.Add("Amount");
            dt.Columns.Add("CaratCategory");
            dt.Columns.Add("Type");
            dt.Columns.Add("CharniSize");
            dt.Columns.Add("GalaSize");
            dt.Columns.Add("NumberSize");
            dt.Columns.Add("CategoryT");
            dt.Columns.Add("BranchT");
            dt.Columns.Add("ShapeT");
            dt.Columns.Add("SizeT");
            dt.Columns.Add("PurityT");
            dt.Columns.Add("KapanT");
            dt.Columns.Add("CaratT");
            dt.Columns.Add("CaratCategoryT");
            dt.Columns.Add("TypeT");
            dt.Columns.Add("RateT");
            dt.Columns.Add("AmountT");

            dt.Columns.Add("CharniSizeId");
            dt.Columns.Add("SlipNo");
            dt.Columns.Add("ShapeId");
            dt.Columns.Add("SizeId");
            dt.Columns.Add("PurityId");
            dt.Columns.Add("KapanId");
            dt.Columns.Add("TypeId");
            dt.Columns.Add("TypeIdT");

            dt.Columns.Add("PurchaseDetailsId");
            dt.Columns.Add("PurchaseMasterId");
            return dt;
        }

        private async Task GetMaxSrNo()
        {
            var SrNo = await _transferMasterRepository.GetMaxSrNoAsync(Common.LoginCompany.ToString(), Common.LoginFinancialYear);
            txtSerialNo.Text = SrNo.ToString();
        }

        private async void LoadTransferItemDetails()
        {
            GetMaxSrNo();

            grdTransferItemDetails.DataSource = GetDTColumnsforPurchaseDetails();

            //Company
            LoadCompany();

            //Branch
            GetBrancheDetail();
            
            //Employee
            GetEmployeeList();

            //Category
            await GetCategoryDetail();
            
            //Size
            GetSizeDetail();

            //Shape
            GetShapeDetail();

            //Purity
            GetPurityDetail();

            //Kapan
            GetKapanDetail();

            GetCaratCategoryDetail();

            grvTransferItemDetails.BestFitColumns();
        }

        private async void LoadCompany()
        {
            CompanyMasterRepository companyMasterRepository = new CompanyMasterRepository();
            var result = await companyMasterRepository.GetAllCompanyAsync();
            lueCompany.Properties.DataSource = result;
            lueCompany.Properties.DisplayMember = "Name";
            lueCompany.Properties.ValueMember = "Id";
            lueCompany.EditValue = Common.LoginCompany;
        }

        private async void GetBrancheDetail()
        {
            if (lueCompany.EditValue != null)
            {
                BranchMasterRepository branchMasterRepository = new BranchMasterRepository();
                var branchMaster = await branchMasterRepository.GetAllBranchAsync(lueCompany.EditValue.ToString());
                repoBranch.DataSource = branchMaster;
                repoBranch.DisplayMember = "Name";
                repoBranch.ValueMember = "Id";

                repoBranchT.DataSource = branchMaster;
                repoBranchT.DisplayMember = "Name";
                repoBranchT.ValueMember = "Id";
            }
            else
            {
                repoBranch.DataSource = null;
                repoBranchT.DataSource = null;
            }
        }

        private async Task GetEmployeeList()
        {
            PartyMasterRepository partyMasterRepository = new PartyMasterRepository();
            var EmployeeDetailList = await partyMasterRepository.GetAllPartyAsync(Common.LoginCompany.ToString(), PartyTypeMaster.Employee, PartyTypeMaster.Other);
            lueTransferBy.Properties.DataSource = EmployeeDetailList;
            lueTransferBy.Properties.DisplayMember = "Name";
            lueTransferBy.Properties.ValueMember = "Id";
        }
        private async Task GetCategoryDetail()
        {
            var Category = TransferCategoryMaster.GetAllTransferCategory();

            if (Category != null)
            {
                repoCategory.DataSource = Category;
                repoCategory.DisplayMember = "Name";
                repoCategory.ValueMember = "Id";

                repoCategoryT.DataSource = Category;
                repoCategoryT.DisplayMember = "Name";
                repoCategoryT.ValueMember = "Id";
            }
        }

        private async void GetCaratCategoryDetail()
        {
            var Category = CaratCategoryMaster.GetAllCaratCategory();

            if (Category != null)
            {
                repoCaratCategory.DataSource = Category;
                repoCaratCategory.DisplayMember = "Name";
                repoCaratCategory.ValueMember = "Id";

                //repoCategoryT.DataSource = Category;
                //repoCategoryT.DisplayMember = "Name";
                //repoCategoryT.ValueMember = "Id";
            }
        }

        private async void GetSizeDetail()
        {
            SizeMasterRepository sizeMasterRepository = new SizeMasterRepository();
            var sizeMaster = await sizeMasterRepository.GetAllSizeAsync();

            repoSizeT.DataSource = sizeMaster;
            repoSizeT.DisplayMember = "Name";
            repoSizeT.ValueMember = "Id";
        }

        private async void GetShapeDetail()
        {
            ShapeMasterRepository shapeMasterRepository = new ShapeMasterRepository();
            var shapeMaster = await shapeMasterRepository.GetAllShapeAsync();

            repoShapeT.DataSource = shapeMaster;
            repoShapeT.DisplayMember = "Name";
            repoShapeT.ValueMember = "Id";
        }

        private async void GetPurityDetail()
        {
            PurityMasterRepository purityMasterRepository = new PurityMasterRepository();
            var purityMaster = await purityMasterRepository.GetAllPurityAsync();

            repoPurityT.DataSource = purityMaster;
            repoPurityT.DisplayMember = "Name";
            repoPurityT.ValueMember = "Id";
        }

        private async void GetKapanDetail()
        {
            KapanMasterRepository kapanMasterRepository = new KapanMasterRepository();
            var kapanMaster = await kapanMasterRepository.GetAllKapanAsync();

            repoKapanT.DataSource = kapanMaster;
            repoKapanT.DisplayMember = "Name";
            repoKapanT.ValueMember = "Id";
        }

        private void lueCompany_EditValueChanged(object sender, EventArgs e)
        {
            GetBrancheDetail();
        }

        private async void grvTransferItemDetails_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == colCategory || e.Column == colBranch)
                {
                    if (grvTransferItemDetails.GetRowCellValue(e.RowHandle, colCategory).ToString() == TransferCategoryMaster.Kapan.ToString())
                    {
                        grvTransferItemDetails.SetRowCellValue(e.RowHandle, colCaratCategory, TransferCategoryMaster.Kapan);
                        grvTransferItemDetails.SetRowCellValue(e.RowHandle, colCaratCategoryT, TransferCategoryMaster.Kapan);

                        if (!string.IsNullOrEmpty(grvTransferItemDetails.GetRowCellValue(e.RowHandle, colBranch).ToString()))
                        {
                            AccountToAssortMasterRepository accountToAssortMasterRepository = new AccountToAssortMasterRepository();
                            var ListKapanProcessSend = await accountToAssortMasterRepository.GetAssortmentSendToDetails(lueCompany.EditValue.ToString(), grvTransferItemDetails.GetRowCellValue(e.RowHandle, colBranch).ToString(), Common.LoginFinancialYear.ToString());

                            repoShape.DataSource = ListKapanProcessSend;
                            repoShape.DisplayMember = "Shape";
                            repoShape.ValueMember = "Id";

                            repoShape.Columns["SlipNo"].Visible = true;
                            repoShape.Columns["Size"].Visible = true;
                            repoShape.Columns["Kapan"].Visible = true;

                            repoShape.Columns["Purity"].Visible = false;
                            repoShape.Columns["CharniSize"].Visible = false;
                            repoShape.Columns["GalaNumber"].Visible = false;
                            repoShape.Columns["NumberSize"].Visible = false;

                            repoShape.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                            repoShape.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
                        }
                    }
                    else if (grvTransferItemDetails.GetRowCellValue(e.RowHandle, colCategory).ToString() == TransferCategoryMaster.Number.ToString())
                    {
                        grvTransferItemDetails.SetRowCellValue(e.RowHandle, colCaratCategory, TransferCategoryMaster.Number);
                        grvTransferItemDetails.SetRowCellValue(e.RowHandle, colCaratCategoryT, TransferCategoryMaster.Number);

                        if (!string.IsNullOrEmpty(grvTransferItemDetails.GetRowCellValue(e.RowHandle, colBranch).ToString()))
                        {
                            var ListNumberProcessReturn = await _salesMasterRepository.GetSalesItemDetails(CategoryMaster.Number, lueCompany.EditValue.ToString(), grvTransferItemDetails.GetRowCellValue(e.RowHandle, colBranch).ToString(), Common.LoginFinancialYear);

                            repoShape.DataSource = ListNumberProcessReturn;
                            repoShape.DisplayMember = "Shape";
                            repoShape.ValueMember = "Id";

                            repoShape.Columns["SlipNo"].Visible = false;
                            repoShape.Columns["Size"].Visible = false;
                            repoShape.Columns["Purity"].Visible = false;
                            repoShape.Columns["Kapan"].Visible = false;

                            repoShape.Columns["CharniSize"].Visible = true;
                            repoShape.Columns["GalaNumber"].Visible = false;
                            repoShape.Columns["NumberSize"].Visible = true;

                            repoShape.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                            repoShape.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
                        }
                    }
                }
                else if (e.Column == colTypeT)
                {
                    try
                    {
                        this.grvTransferItemDetails.CellValueChanged -= new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvTransferItemDetails_CellValueChanged);
                        string Id = e.Value.ToString();
                        grvTransferItemDetails.SetRowCellValue(e.RowHandle, colTypeIdT, Id);
                        var result = _caratCategoryTypes.Where(x => x.Id.Equals(Id));
                        grvTransferItemDetails.SetRowCellValue(e.RowHandle, colTypeT, result.FirstOrDefault().Name);
                        this.grvTransferItemDetails.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvTransferItemDetails_CellValueChanged);
                    }
                    catch
                    {

                    }
                    //if (!string.IsNullOrEmpty(grvTransferItemDetails.GetRowCellValue(e.RowHandle, colCaratCategoryT).ToString()))
                    //{
                    //    if (Convert.ToInt32(grvTransferItemDetails.GetRowCellValue(e.RowHandle, colCaratCategoryT)) == CaratCategoryMaster.None)
                    //    {

                    //    }
                    //    else if (Convert.ToInt32(grvTransferItemDetails.GetRowCellValue(e.RowHandle, colCaratCategoryT)) == CaratCategoryMaster.CharniCarat)
                    //    {
                    //        if (_caratCategoryTypes == null)
                    //            _caratCategoryTypes = await _salesMasterRepository.GetCaratCategoryDetails();

                    //        repoTypeT.DataSource = _caratCategoryTypes;
                    //        repoTypeT.DisplayMember = "Name";
                    //        repoTypeT.ValueMember = "Id";
                    //    }
                    //    else if (Convert.ToInt32(grvTransferItemDetails.GetRowCellValue(e.RowHandle, colCaratCategoryT)) == CaratCategoryMaster.GalaCarat)
                    //    {
                    //        if (_caratCategoryTypes == null)
                    //            _caratCategoryTypes = await _salesMasterRepository.GetCaratCategoryDetails();

                    //        repoTypeT.DataSource = _caratCategoryTypes;
                    //        repoTypeT.DisplayMember = "Name";
                    //        repoTypeT.ValueMember = "Id";
                    //    }
                    //    else if (Convert.ToInt32(grvTransferItemDetails.GetRowCellValue(e.RowHandle, colCaratCategoryT)) == CaratCategoryMaster.NumberCarat)
                    //    {
                    //        if (_caratCategoryTypes == null)
                    //            _caratCategoryTypes = await _salesMasterRepository.GetCaratCategoryDetails();

                    //        repoTypeT.DataSource = _caratCategoryTypes;
                    //        repoTypeT.DisplayMember = "Name";
                    //        repoTypeT.ValueMember = "Id";
                    //    }                        
                    //}
                }
                else if (e.Column == colShape)
                {
                    try
                    {
                        if (grvTransferItemDetails.GetRowCellValue(e.RowHandle, colCategory).ToString() == TransferCategoryMaster.Kapan.ToString())
                        {
                            //grvTransferItemDetails.SetRowCellValue(e.RowHandle, colSize, ((Repository.Entities.Models.NumberProcessSend)repoShape.GetDataSourceRowByKeyValue(e.Value)).Size);
                            //grvTransferItemDetails.SetRowCellValue(e.RowHandle, colPurity, ((Repository.Entities.Models.NumberProcessSend)repoShape.GetDataSourceRowByKeyValue(e.Value)).Purity);
                            ////grvTransferItemDetails.SetRowCellValue(e.RowHandle, colCaratCategory, ((Repository.Entities.Models.CharniProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).SizeId);
                            //grvTransferItemDetails.SetRowCellValue(e.RowHandle, colType, ((Repository.Entities.Models.NumberProcessSend)repoShape.GetDataSourceRowByKeyValue(e.Value)).GalaNumber);
                            //grvTransferItemDetails.SetRowCellValue(e.RowHandle, colKapan, ((Repository.Entities.Models.NumberProcessSend)repoShape.GetDataSourceRowByKeyValue(e.Value)).Kapan);
                            //grvTransferItemDetails.SetRowCellValue(e.RowHandle, colCarat, ((Repository.Entities.Models.NumberProcessSend)repoShape.GetDataSourceRowByKeyValue(e.Value)).AvailableWeight);

                            //grvTransferItemDetails.SetRowCellValue(e.RowHandle, colSlipNo, ((Repository.Entities.Models.NumberProcessSend)repoShape.GetDataSourceRowByKeyValue(e.Value)).SlipNo);
                            //grvTransferItemDetails.SetRowCellValue(e.RowHandle, colShapeId, ((Repository.Entities.Models.NumberProcessSend)repoShape.GetDataSourceRowByKeyValue(e.Value)).ShapeId);
                            //grvTransferItemDetails.SetRowCellValue(e.RowHandle, colSizeId, ((Repository.Entities.Models.NumberProcessSend)repoShape.GetDataSourceRowByKeyValue(e.Value)).SizeId);
                            //grvTransferItemDetails.SetRowCellValue(e.RowHandle, colPurityId, ((Repository.Entities.Models.NumberProcessSend)repoShape.GetDataSourceRowByKeyValue(e.Value)).PurityId);
                            //grvTransferItemDetails.SetRowCellValue(e.RowHandle, colKapanId, ((Repository.Entities.Models.NumberProcessSend)repoShape.GetDataSourceRowByKeyValue(e.Value)).KapanId);
                            //grvTransferItemDetails.SetRowCellValue(e.RowHandle, colTypeId, ((Repository.Entities.Models.NumberProcessSend)repoShape.GetDataSourceRowByKeyValue(e.Value)).GalaNumberId);

                            //grvTransferItemDetails.SetRowCellValue(e.RowHandle, colShapeT, ((Repository.Entities.Models.NumberProcessSend)repoShape.GetDataSourceRowByKeyValue(e.Value)).ShapeId);
                            //grvTransferItemDetails.SetRowCellValue(e.RowHandle, colSizeT, ((Repository.Entities.Models.NumberProcessSend)repoShape.GetDataSourceRowByKeyValue(e.Value)).SizeId);
                            //grvTransferItemDetails.SetRowCellValue(e.RowHandle, colPurityT, ((Repository.Entities.Models.NumberProcessSend)repoShape.GetDataSourceRowByKeyValue(e.Value)).PurityId);
                            ////grvPurchaseItems.FocusedRowHandle = e.RowHandle;
                            ////grvPurchaseItems.FocusedColumn = colBoilCarat;
                            ///
                            grvTransferItemDetails.SetRowCellValue(e.RowHandle, colSize, ((Repository.Entities.Models.AssortmentProcessSend)repoShape.GetDataSourceRowByKeyValue(e.Value)).Size);
                            grvTransferItemDetails.SetRowCellValue(e.RowHandle, colPurity, ((Repository.Entities.Models.AssortmentProcessSend)repoShape.GetDataSourceRowByKeyValue(e.Value)).Purity);
                            grvTransferItemDetails.SetRowCellValue(e.RowHandle, colKapan, ((Repository.Entities.Models.AssortmentProcessSend)repoShape.GetDataSourceRowByKeyValue(e.Value)).Kapan);
                            grvTransferItemDetails.SetRowCellValue(e.RowHandle, colCarat, ((Repository.Entities.Models.AssortmentProcessSend)repoShape.GetDataSourceRowByKeyValue(e.Value)).Weight);

                            grvTransferItemDetails.SetRowCellValue(e.RowHandle, colSlipNo, ((Repository.Entities.Models.AssortmentProcessSend)repoShape.GetDataSourceRowByKeyValue(e.Value)).SlipNo);
                            grvTransferItemDetails.SetRowCellValue(e.RowHandle, colShapeId, ((Repository.Entities.Models.AssortmentProcessSend)repoShape.GetDataSourceRowByKeyValue(e.Value)).ShapeId);
                            grvTransferItemDetails.SetRowCellValue(e.RowHandle, colSizeId, ((Repository.Entities.Models.AssortmentProcessSend)repoShape.GetDataSourceRowByKeyValue(e.Value)).SizeId);
                            grvTransferItemDetails.SetRowCellValue(e.RowHandle, colPurityId, ((Repository.Entities.Models.AssortmentProcessSend)repoShape.GetDataSourceRowByKeyValue(e.Value)).PurityId);
                            grvTransferItemDetails.SetRowCellValue(e.RowHandle, colKapanId, ((Repository.Entities.Models.AssortmentProcessSend)repoShape.GetDataSourceRowByKeyValue(e.Value)).KapanId);
                            
                            grvTransferItemDetails.SetRowCellValue(e.RowHandle, colShapeT, ((Repository.Entities.Models.AssortmentProcessSend)repoShape.GetDataSourceRowByKeyValue(e.Value)).ShapeId);
                            grvTransferItemDetails.SetRowCellValue(e.RowHandle, colSizeT, ((Repository.Entities.Models.AssortmentProcessSend)repoShape.GetDataSourceRowByKeyValue(e.Value)).SizeId);
                            grvTransferItemDetails.SetRowCellValue(e.RowHandle, colPurityT, ((Repository.Entities.Models.AssortmentProcessSend)repoShape.GetDataSourceRowByKeyValue(e.Value)).PurityId);
                            grvTransferItemDetails.SetRowCellValue(e.RowHandle, colPurchaseDetailsId, ((Repository.Entities.Models.AssortmentProcessSend)repoShape.GetDataSourceRowByKeyValue(e.Value)).PurchaseDetailsId);
                            grvTransferItemDetails.SetRowCellValue(e.RowHandle, colPurchaseMasterId, ((Repository.Entities.Models.AssortmentProcessSend)repoShape.GetDataSourceRowByKeyValue(e.Value)).PurchaseMasterId);
                        }
                        else if (grvTransferItemDetails.GetRowCellValue(e.RowHandle, colCategory).ToString() == TransferCategoryMaster.Number.ToString())
                        {
                            grvTransferItemDetails.SetRowCellValue(e.RowHandle, colSize, ((Repository.Entities.Model.SalesItemDetails)repoShape.GetDataSourceRowByKeyValue(e.Value)).Size);
                            grvTransferItemDetails.SetRowCellValue(e.RowHandle, colPurity, ((Repository.Entities.Model.SalesItemDetails)repoShape.GetDataSourceRowByKeyValue(e.Value)).Purity);
                            //grvTransferItemDetails.SetRowCellValue(e.RowHandle, colCaratCategory, ((Repository.Entities.Models.CharniProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).SizeId);
                            grvTransferItemDetails.SetRowCellValue(e.RowHandle, colType, ((Repository.Entities.Model.SalesItemDetails)repoShape.GetDataSourceRowByKeyValue(e.Value)).NumberSize);
                            grvTransferItemDetails.SetRowCellValue(e.RowHandle, colKapan, ((Repository.Entities.Model.SalesItemDetails)repoShape.GetDataSourceRowByKeyValue(e.Value)).Kapan);
                            grvTransferItemDetails.SetRowCellValue(e.RowHandle, colCarat, ((Repository.Entities.Model.SalesItemDetails)repoShape.GetDataSourceRowByKeyValue(e.Value)).Weight);

                            grvTransferItemDetails.SetRowCellValue(e.RowHandle, colSlipNo, 0);
                            grvTransferItemDetails.SetRowCellValue(e.RowHandle, colShapeId, ((Repository.Entities.Model.SalesItemDetails)repoShape.GetDataSourceRowByKeyValue(e.Value)).ShapeId);
                            grvTransferItemDetails.SetRowCellValue(e.RowHandle, colSizeId, ((Repository.Entities.Model.SalesItemDetails)repoShape.GetDataSourceRowByKeyValue(e.Value)).SizeId);
                            grvTransferItemDetails.SetRowCellValue(e.RowHandle, colPurityId, ((Repository.Entities.Model.SalesItemDetails)repoShape.GetDataSourceRowByKeyValue(e.Value)).PurityId);
                            grvTransferItemDetails.SetRowCellValue(e.RowHandle, colKapanId, ((Repository.Entities.Model.SalesItemDetails)repoShape.GetDataSourceRowByKeyValue(e.Value)).KapanId);
                            grvTransferItemDetails.SetRowCellValue(e.RowHandle, colCharniSizeId, ((Repository.Entities.Model.SalesItemDetails)repoShape.GetDataSourceRowByKeyValue(e.Value)).CharniSizeId);
                            grvTransferItemDetails.SetRowCellValue(e.RowHandle, colTypeId, ((Repository.Entities.Model.SalesItemDetails)repoShape.GetDataSourceRowByKeyValue(e.Value)).NumberSizeId);

                            grvTransferItemDetails.SetRowCellValue(e.RowHandle, colShapeT, ((Repository.Entities.Model.SalesItemDetails)repoShape.GetDataSourceRowByKeyValue(e.Value)).ShapeId);
                            grvTransferItemDetails.SetRowCellValue(e.RowHandle, colSizeT, ((Repository.Entities.Model.SalesItemDetails)repoShape.GetDataSourceRowByKeyValue(e.Value)).SizeId);
                            grvTransferItemDetails.SetRowCellValue(e.RowHandle, colPurityT, ((Repository.Entities.Model.SalesItemDetails)repoShape.GetDataSourceRowByKeyValue(e.Value)).PurityId);

                            //grvPurchaseItems.FocusedRowHandle = e.RowHandle;
                            //grvPurchaseItems.FocusedColumn = colBoilCarat;
                        }
                    }
                    catch
                    {

                    }
                }
                else if (e.Column == colCarat)
                {
                    //decimal TipWeight = Convert.ToDecimal(lueBranch.GetColumnValue("TipWeight"));
                    //decimal CVDWeight = Convert.ToDecimal(lueBranch.GetColumnValue("CVDWeight"));
                    //GetLessWeightDetailBasedOnCity(lueBranch.GetColumnValue("LessWeightId").ToString(), Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(e.RowHandle, colCarat)), e.RowHandle, TipWeight, CVDWeight);
                }
                else if (e.Column == colRate)
                {
                    decimal Carat = Convert.ToDecimal(grvTransferItemDetails.GetRowCellValue(e.RowHandle, colCarat).ToString());
                    decimal Rate = Convert.ToDecimal(grvTransferItemDetails.GetRowCellValue(e.RowHandle, colRate).ToString());

                    grvTransferItemDetails.SetRowCellValue(e.RowHandle, colAmount, (Carat * Rate).ToString());
                }
                else if (e.Column == colRateT)
                {
                    decimal Carat = Convert.ToDecimal(grvTransferItemDetails.GetRowCellValue(e.RowHandle, colCaratT).ToString());
                    decimal Rate = Convert.ToDecimal(grvTransferItemDetails.GetRowCellValue(e.RowHandle, colRateT).ToString());

                    grvTransferItemDetails.SetRowCellValue(e.RowHandle, colAmountT, (Carat * Rate).ToString());
                }
                else if (e.Column == colCaratT)
                {
                    //decimal Carat = Convert.ToDecimal(grvTransferItemDetails.GetRowCellValue(e.RowHandle, colCarat).ToString());
                    //decimal CaratT = Convert.ToDecimal(grvTransferItemDetails.GetRowCellValue(e.RowHandle, colCaratT).ToString());
                }
                else if (e.Column == colCategoryT)
                {
                    this.grvTransferItemDetails.CellValueChanged -= new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvTransferItemDetails_CellValueChanged);
                    if (grvTransferItemDetails.GetRowCellValue(e.RowHandle, colCategoryT).ToString() == TransferCategoryMaster.Kapan.ToString())
                        grvTransferItemDetails.SetRowCellValue(e.RowHandle, colCaratCategoryT, 1);
                    else if (grvTransferItemDetails.GetRowCellValue(e.RowHandle, colCategoryT).ToString() == TransferCategoryMaster.Number.ToString())
                        grvTransferItemDetails.SetRowCellValue(e.RowHandle, colCaratCategoryT, 0);
                    grvTransferItemDetails.SetRowCellValue(e.RowHandle, colTypeT, "");
                    this.grvTransferItemDetails.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvTransferItemDetails_CellValueChanged);
                }
            }
            catch (Exception Ex)
            {
            }
        }

        private async void grvTransferItemDetails_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            
        }

        private async void grvTransferItemDetails_ShowingEditor(object sender, CancelEventArgs e)
        {
            ColumnView view = (ColumnView)sender;
            //if (view.FocusedColumn == colTypeT && !string.IsNullOrEmpty(grvTransferItemDetails.GetRowCellValue(view.FocusedRowHandle, colCaratCategoryT).ToString()))
            {
                //grvTransferItemDetails_CustomRowCellEdit(null,null);
            }
            
        }

        private async void grvTransferItemDetails_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            try
            {
                if (e.Column == colTypeT)
                {
                    if (Convert.ToInt32(grvTransferItemDetails.GetRowCellValue(e.RowHandle, colCaratCategoryT)) == TransferCategoryMaster.Kapan)
                    {
                        if (_caratCategoryTypes == null)
                            _caratCategoryTypes = await _salesMasterRepository.GetCaratCategoryDetails();

                        repoTypeT.DataSource = _caratCategoryTypes.Where(x => x.Type.Equals(TransferCategoryMaster.Kapan));
                        repoTypeT.DisplayMember = "Name";
                        repoTypeT.ValueMember = "Id";

                        e.RepositoryItem = repoTypeT;
                    }
                    else if (Convert.ToInt32(grvTransferItemDetails.GetRowCellValue(e.RowHandle, colCaratCategoryT)) == TransferCategoryMaster.Number)
                    {
                        if (_caratCategoryTypes == null)
                            _caratCategoryTypes = await _salesMasterRepository.GetCaratCategoryDetails();

                        repoTypeT.DataSource = _caratCategoryTypes.Where(x => x.Type.Equals(TransferCategoryMaster.Number));
                        repoTypeT.DisplayMember = "Name";
                        repoTypeT.ValueMember = "Id";

                        e.RepositoryItem = repoTypeT;
                    }
                }
            }
            catch
            {

            }
        }

        private void Image1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Image1.Image = LoadImage();
            Image1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
        }

        private void Image2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Image2.Image = LoadImage();
            Image2.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
        }

        private void Image3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Image3.Image = LoadImage();
            Image3.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
        }

        private Image LoadImage()
        {
            Image newimage = null;
            openFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.JPEG;*.PNG)|*.BMP;*.JPG;*.JPEG;*.PNG";
            openFileDialog1.FileName = string.Empty;
            if (DialogResult.OK == openFileDialog1.ShowDialog())
            {
                if (openFileDialog1.FileName != string.Empty)
                {
                    try
                    {
                        Byte[] logo = null;
                        logo = File.ReadAllBytes(openFileDialog1.FileName);
                        MemoryStream ms = new MemoryStream(logo);
                        newimage = Image.FromStream(ms);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("CM01:" + ex.Message, "AD InfoTech", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            return newimage;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (!CheckValidation())
                    return;

                string TransferId = Guid.NewGuid().ToString();

                KapanMappingMasterRepository kapanMappingMasterRepository;
                CharniProcessMasterRepository charniProcessMasterRepository;
                GalaProcessMasterRepository galaProcessMasterRepository;
                NumberProcessMasterRepository numberProcessMasterRepository;
                BoilProcessMaster boilProcessMaster;
                CharniProcessMaster charniProcessMaster;
                KapanMappingMaster kapanMappingMaster;
                NumberProcessMaster numberProcessMaster;

                for (int i = 0; i < grvTransferItemDetails.RowCount; i++)
                {
                    string TransferEntryId = Guid.NewGuid().ToString();
                    string TransferType = grvTransferItemDetails.GetRowCellValue(i, colCategory).ToString() + "-" + grvTransferItemDetails.GetRowCellValue(i, colCategoryT).ToString();
                    //Transfer From
                    if (grvTransferItemDetails.GetRowCellValue(i, colCategory).ToString() == TransferCategoryMaster.Kapan.ToString())
                    {
                        kapanMappingMaster = new KapanMappingMaster();
                        kapanMappingMaster.Id = Guid.NewGuid().ToString();
                        kapanMappingMaster.CompanyId = lueCompany.EditValue.ToString();
                        kapanMappingMaster.BranchId = grvTransferItemDetails.GetRowCellValue(i, colBranch).ToString();
                        kapanMappingMaster.FinancialYearId = Common.LoginFinancialYear.ToString();
                        kapanMappingMaster.PurchaseMasterId = grvTransferItemDetails.GetRowCellValue(i, colPurchaseMasterId).ToString();
                        kapanMappingMaster.PurchaseDetailsId = grvTransferItemDetails.GetRowCellValue(i, colPurchaseDetailsId).ToString();
                        kapanMappingMaster.PurityId = grvTransferItemDetails.GetRowCellValue(i, colPurityId).ToString();
                        kapanMappingMaster.KapanId = grvTransferItemDetails.GetRowCellValue(i, colKapanId).ToString();
                        kapanMappingMaster.SlipNo = grvTransferItemDetails.GetRowCellValue(i, colSlipNo).ToString();
                        kapanMappingMaster.Weight = Convert.ToDecimal(grvTransferItemDetails.GetRowCellValue(i, colCaratT).ToString()) * -1;
                        kapanMappingMaster.CreatedDate = DateTime.Now;
                        kapanMappingMaster.CreatedBy = Common.LoginUserID;
                        kapanMappingMaster.UpdatedDate = DateTime.Now;
                        kapanMappingMaster.UpdatedBy = Common.LoginUserID;

                        kapanMappingMasterRepository = new KapanMappingMasterRepository();
                        var Result1 = await kapanMappingMasterRepository.AddKapanMappingAsync(kapanMappingMaster);
                        kapanMappingMasterRepository = null;
                    }
                    else if (grvTransferItemDetails.GetRowCellValue(i, colCategory).ToString() == TransferCategoryMaster.Number.ToString())
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
                        numberProcessMaster.NumberProcessType = Convert.ToInt32(ProcessType.Transfer);
                        numberProcessMaster.KapanId = grvTransferItemDetails.GetRowCellValue(i, colKapanId).ToString();
                        numberProcessMaster.ShapeId = grvTransferItemDetails.GetRowCellValue(i, colShapeId).ToString();
                        numberProcessMaster.SizeId = grvTransferItemDetails.GetRowCellValue(i, colSizeId).ToString();
                        numberProcessMaster.PurityId = grvTransferItemDetails.GetRowCellValue(i, colPurityId).ToString();
                        numberProcessMaster.CharniSizeId = grvTransferItemDetails.GetRowCellValue(i, colCharniSizeId).ToString();
                        numberProcessMaster.Weight = 0;
                        //numberProcessMaster.GalaNumberId = grvTransferItemDetails.GetRowCellValue(i, colTypeId).ToString();
                        numberProcessMaster.NumberId = grvTransferItemDetails.GetRowCellValue(i, colTypeId).ToString();
                        numberProcessMaster.NumberWeight = Convert.ToDecimal(grvTransferItemDetails.GetRowCellValue(i, colCaratT).ToString()) * -1;
                        numberProcessMaster.LossWeight = 0;
                        numberProcessMaster.RejectionWeight = 0;
                        numberProcessMaster.HandOverById = lueTransferBy.EditValue.ToString();
                        numberProcessMaster.HandOverToId = lueTransferBy.EditValue.ToString();
                        numberProcessMaster.SlipNo = grvTransferItemDetails.GetRowCellValue(i, colSlipNo).ToString();
                        numberProcessMaster.NumberCategoy = 0;
                        numberProcessMaster.Remarks = txtRemark.Text;

                        numberProcessMaster.TransferId = TransferId;
                        numberProcessMaster.TransferType = TransferType;
                        numberProcessMaster.TransferEntryId = TransferEntryId;
                        numberProcessMaster.TransferCaratRate = Convert.ToDouble(grvTransferItemDetails.GetRowCellValue(i, colRate).ToString());

                        numberProcessMaster.IsDelete = false;
                        numberProcessMaster.CreatedDate = DateTime.Now;
                        numberProcessMaster.CreatedBy = Common.LoginUserID;
                        numberProcessMaster.UpdatedDate = DateTime.Now;
                        numberProcessMaster.UpdatedBy = Common.LoginUserID;

                        numberProcessMasterRepository = new NumberProcessMasterRepository();
                        var Result1 = await numberProcessMasterRepository.AddNumberProcessAsync(numberProcessMaster);
                        numberProcessMasterRepository = null;
                    }

                    //Transfer To
                    if (grvTransferItemDetails.GetRowCellValue(i, colCategory).ToString() == TransferCategoryMaster.Kapan.ToString())
                    {
                        kapanMappingMaster = new KapanMappingMaster();
                        kapanMappingMaster.Id = Guid.NewGuid().ToString();
                        kapanMappingMaster.CompanyId = lueCompany.EditValue.ToString();
                        kapanMappingMaster.BranchId = grvTransferItemDetails.GetRowCellValue(i, colBranch).ToString();
                        kapanMappingMaster.FinancialYearId = Common.LoginFinancialYear.ToString();
                        kapanMappingMaster.PurchaseMasterId = grvTransferItemDetails.GetRowCellValue(i, colPurchaseMasterId).ToString();
                        kapanMappingMaster.PurchaseDetailsId = grvTransferItemDetails.GetRowCellValue(i, colPurchaseDetailsId).ToString();
                        kapanMappingMaster.PurityId = grvTransferItemDetails.GetRowCellValue(i, colPurityId).ToString();
                        kapanMappingMaster.KapanId = grvTransferItemDetails.GetRowCellValue(i, colTypeIdT).ToString();
                        kapanMappingMaster.SlipNo = grvTransferItemDetails.GetRowCellValue(i, colSlipNo).ToString();
                        kapanMappingMaster.Weight = Convert.ToDecimal(grvTransferItemDetails.GetRowCellValue(i, colCaratT).ToString());
                        kapanMappingMaster.CreatedDate = DateTime.Now;
                        kapanMappingMaster.CreatedBy = Common.LoginUserID;
                        kapanMappingMaster.UpdatedDate = DateTime.Now;
                        kapanMappingMaster.UpdatedBy = Common.LoginUserID;

                        kapanMappingMasterRepository = new KapanMappingMasterRepository();
                        var Result1 = await kapanMappingMasterRepository.AddKapanMappingAsync(kapanMappingMaster);
                        kapanMappingMasterRepository = null;
                    }
                    else if (grvTransferItemDetails.GetRowCellValue(i, colCategoryT).ToString() == TransferCategoryMaster.Number.ToString())
                    {
                        numberProcessMaster = new NumberProcessMaster();
                        numberProcessMaster.Id = Guid.NewGuid().ToString();
                        numberProcessMaster.NumberNo = 0;
                        numberProcessMaster.JangadNo = 0;
                        //galaProcessMaster.BoilJangadNo = Convert.ToInt32(lueKapan.GetColumnValue("BoilJangadNo").ToString());
                        numberProcessMaster.CompanyId = lueCompany.EditValue.ToString();
                        numberProcessMaster.BranchId = grvTransferItemDetails.GetRowCellValue(i, colBranchT).ToString();
                        numberProcessMaster.EntryDate = Convert.ToDateTime(dtDate.Text).ToString("yyyyMMdd");
                        numberProcessMaster.EntryTime = Convert.ToDateTime(dtTime.Text).ToString("hh:mm:ss ttt");
                        numberProcessMaster.FinancialYearId = Common.LoginFinancialYear;
                        numberProcessMaster.NumberProcessType = Convert.ToInt32(ProcessType.Transfer);
                        numberProcessMaster.KapanId = grvTransferItemDetails.GetRowCellValue(i, colKapanT).ToString();
                        numberProcessMaster.ShapeId = grvTransferItemDetails.GetRowCellValue(i, colShapeT).ToString();
                        numberProcessMaster.SizeId = grvTransferItemDetails.GetRowCellValue(i, colSizeT).ToString();
                        numberProcessMaster.PurityId = grvTransferItemDetails.GetRowCellValue(i, colPurityT).ToString();
                        numberProcessMaster.CharniSizeId = grvTransferItemDetails.GetRowCellValue(i, colCharniSizeId).ToString();
                        numberProcessMaster.Weight = 0;
                        //numberProcessMaster.GalaNumberId = grvTransferItemDetails.GetRowCellValue(i, colTypeId).ToString();
                        numberProcessMaster.NumberId = grvTransferItemDetails.GetRowCellValue(i, colTypeIdT).ToString();
                        numberProcessMaster.NumberWeight = Convert.ToDecimal(grvTransferItemDetails.GetRowCellValue(i, colCaratT).ToString());
                        numberProcessMaster.LossWeight = 0;
                        numberProcessMaster.RejectionWeight = 0;
                        numberProcessMaster.HandOverById = lueTransferBy.EditValue.ToString();
                        numberProcessMaster.HandOverToId = lueTransferBy.EditValue.ToString();
                        numberProcessMaster.SlipNo = grvTransferItemDetails.GetRowCellValue(i, colSlipNo).ToString();
                        numberProcessMaster.NumberCategoy = 0;
                        numberProcessMaster.Remarks = txtRemark.Text;

                        numberProcessMaster.TransferId = TransferId;
                        numberProcessMaster.TransferType = TransferType;
                        numberProcessMaster.TransferEntryId = TransferEntryId;
                        numberProcessMaster.TransferCaratRate = Convert.ToDouble(grvTransferItemDetails.GetRowCellValue(i, colRateT).ToString());

                        numberProcessMaster.IsDelete = false;
                        numberProcessMaster.CreatedDate = DateTime.Now;
                        numberProcessMaster.CreatedBy = Common.LoginUserID;
                        numberProcessMaster.UpdatedDate = DateTime.Now;
                        numberProcessMaster.UpdatedBy = Common.LoginUserID;

                        numberProcessMasterRepository = new NumberProcessMasterRepository();
                        var Result1 = await numberProcessMasterRepository.AddNumberProcessAsync(numberProcessMaster);
                        numberProcessMasterRepository = null;
                    }
                }

                TransferMaster transferMaster = new TransferMaster();
                transferMaster.Id = TransferId;
                transferMaster.JangadNo = Convert.ToInt32(txtSerialNo.Text);
                transferMaster.Date = Convert.ToDateTime(dtDate.Text).ToString("yyyyMMdd");
                transferMaster.Time = Convert.ToDateTime(dtTime.Text).ToString("hh:mm:ss ttt");
                transferMaster.TRansferById = lueTransferBy.EditValue.ToString();
                transferMaster.Remark = txtRemark.Text;
                if (Image1.Image != null)
                    transferMaster.Image1 = ImageToByteArray(Image1.Image);
                if (Image2.Image != null)
                    transferMaster.Image2 = ImageToByteArray(Image2.Image);
                if (Image3.Image != null)
                    transferMaster.Image3 = ImageToByteArray(Image3.Image);

                transferMaster.CompanyId = lueCompany.EditValue.ToString();
                transferMaster.FinancialYearId = Common.LoginFinancialYear;
                transferMaster.IsDelete = false;
                transferMaster.CreatedDate = DateTime.Now;
                transferMaster.CreatedBy = Common.LoginUserID;
                transferMaster.UpdatedDate = DateTime.Now;
                transferMaster.UpdatedBy = Common.LoginUserID;

                var Result = await _transferMasterRepository.AddTransferAsync(transferMaster);

                if (Result != null)
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

        private bool CheckValidation()
        {
            if (lueTransferBy.EditValue == null)
            {
                MessageBox.Show("Please select Transfer By name", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }

        private void Reset()
        {
            grdTransferItemDetails.DataSource = null;
            dtDate.EditValue = DateTime.Now;
            dtTime.EditValue = DateTime.Now;

            LoadTransferItemDetails();

            txtRemark.Text = "";
            Image1.Image = null;
            Image2.Image = null;
            Image3.Image = null;
            _caratCategoryTypes = null;

            lueTransferBy.Focus();
            lueTransferBy.Select();
        }
    }
}