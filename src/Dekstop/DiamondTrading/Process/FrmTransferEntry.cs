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
            timer1.Start();

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
            dt.Columns.Add("CategoryType");
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
            await LoadCompany();

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

        private async Task LoadCompany()
        {
            CompanyMasterRepository companyMasterRepository = new CompanyMasterRepository();
            var result = await companyMasterRepository.GetUserCompanyMappingAsync(Common.LoginUserID);
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
            var EmployeeDetailList = await partyMasterRepository.GetAllPartyAsync(Common.LoginCompany.ToString(), PartyTypeMaster.Employee, new int[] { PartyTypeMaster.Other });
            lueTransferBy.Properties.DataSource = EmployeeDetailList;
            lueTransferBy.Properties.DisplayMember = "Name";
            lueTransferBy.Properties.ValueMember = "Id";
        }
        private async Task GetCategoryDetail()
        {
            var Category = TransferCategoryMaster.GetAllTransferCategory();

            if (Category != null)
            {
                //repoCategory.DataSource = Category;
                //repoCategory.DisplayMember = "Name";
                //repoCategory.ValueMember = "Id";

                repoCategoryT.DataSource = Category;
                repoCategoryT.DisplayMember = "Name";
                repoCategoryT.ValueMember = "Id";
            }

            if (lueCompany.EditValue == null)
                return;
            var ListTransferCategoryList = await _transferMasterRepository.GetTransferCategoryList(lueCompany.EditValue.ToString(), Common.LoginFinancialYear.ToString());

            if (ListTransferCategoryList != null)
            {
                repoCategory.DataSource = ListTransferCategoryList;
                repoCategory.DisplayMember = "Name";
                repoCategory.ValueMember = "Id";
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
            var kapanMaster = await kapanMasterRepository.GetAllKapanAsync(Common.LoginCompany);

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
                    if (e.Column == colCategory)
                    {
                        grvTransferItemDetails.SetRowCellValue(e.RowHandle, colCategoryType, ((Repository.Entities.Model.TransferCategoryList)repoCategory.GetDataSourceRowByKeyValue(e.Value)).CategoryID);
                        grvTransferItemDetails.SetRowCellValue(e.RowHandle, colCategoryT, ((Repository.Entities.Model.TransferCategoryList)repoCategory.GetDataSourceRowByKeyValue(e.Value)).CategoryID);
                    }
                    if (grvTransferItemDetails.GetRowCellValue(e.RowHandle, colCategoryType).ToString() == TransferCategoryMaster.Kapan.ToString())
                    {
                        grvTransferItemDetails.SetRowCellValue(e.RowHandle, colCaratCategory, TransferCategoryMaster.Kapan);
                        grvTransferItemDetails.SetRowCellValue(e.RowHandle, colCaratCategoryT, TransferCategoryMaster.Kapan);

                        if (!string.IsNullOrEmpty(grvTransferItemDetails.GetRowCellValue(e.RowHandle, colBranch).ToString()))
                        {
                            AccountToAssortMasterRepository accountToAssortMasterRepository = new AccountToAssortMasterRepository();
                            var ListKapanProcessSend = await accountToAssortMasterRepository.GetAssortmentSendToDetails(lueCompany.EditValue.ToString(), grvTransferItemDetails.GetRowCellValue(e.RowHandle, colBranch).ToString(), Common.LoginFinancialYear.ToString());
                            var listKapanProcess = ListKapanProcessSend.Where(x => x.KapanId == grvTransferItemDetails.GetRowCellValue(e.RowHandle, colCategory).ToString()).ToList();

                            var listKapanProcess1 = listKapanProcess.Select(g => new Repository.Entities.Models.AssortmentProcessSend()
                            {
                                Kapan = g.Kapan,
                                KapanId = g.KapanId,
                                Size = g.Size,
                                SizeId = g.SizeId,
                                Purity = g.Purity,
                                PurityId = g.PurityId,
                                Shape = g.Shape,
                                ShapeId = g.ShapeId,
                                AvailableWeight = g.AvailableWeight,
                                LessWeight = g.LessWeight,
                                NetWeight = g.NetWeight,
                                Weight = g.Weight,
                                Id = g.KapanId + g.SizeId + g.ShapeId + g.PurityId,
                                SlipNo = g.SlipNo
                            }).GroupBy(r => new {
                                r.Kapan,
                                r.KapanId,
                                r.Purity,
                                r.PurityId,
                                r.Shape,
                                r.ShapeId,
                                r.Size,
                                r.SizeId
                            }).OrderBy(g => g.Key.Kapan).Select(g => new Repository.Entities.Models.AssortmentProcessSend()
                            {
                                Kapan = g.Key.Kapan,
                                KapanId = g.Key.KapanId,
                                Size = g.Key.Size,
                                SizeId = g.Key.SizeId,
                                Purity = g.Key.Purity,
                                PurityId = g.Key.PurityId,
                                Shape = g.Key.Shape,
                                ShapeId = g.Key.ShapeId,
                                Id = g.Key.KapanId + g.Key.ShapeId + g.Key.PurityId + g.Key.SizeId,
                                SlipNo = string.Join(",", g.Select(kvp => kvp.SlipNo)),
                                AvailableWeight = g.Sum(x => x.AvailableWeight),
                                NetWeight = g.Sum(x => x.NetWeight),
                                Weight = g.Sum(x => x.Weight),
                                LessWeight = g.Sum(x => x.LessWeight)
                            });

                            listKapanProcess1 = listKapanProcess1.Where(x => x.AvailableWeight > 0);
                            repoShape.DataSource = listKapanProcess1.ToList();
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
                    else if (grvTransferItemDetails.GetRowCellValue(e.RowHandle, colCategoryType).ToString() == TransferCategoryMaster.Number.ToString())
                    {
                        grvTransferItemDetails.SetRowCellValue(e.RowHandle, colCaratCategory, TransferCategoryMaster.Number);
                        grvTransferItemDetails.SetRowCellValue(e.RowHandle, colCaratCategoryT, TransferCategoryMaster.Number);

                        if (!string.IsNullOrEmpty(grvTransferItemDetails.GetRowCellValue(e.RowHandle, colBranch).ToString()))
                        {
                            var ListNumberProcessReturn = await _salesMasterRepository.GetSalesItemDetails(CategoryMaster.Number, lueCompany.EditValue.ToString(), grvTransferItemDetails.GetRowCellValue(e.RowHandle, colBranch).ToString(), Common.LoginFinancialYear);
                            var listNumberProcess = ListNumberProcessReturn.Where(x => x.CharniSizeId == grvTransferItemDetails.GetRowCellValue(e.RowHandle, colCategory).ToString()).ToList();

                            var listNumberProcess1 = listNumberProcess.Select(g => new Repository.Entities.Model.SalesItemDetails()
                            {
                                Kapan = g.Kapan,
                                KapanId = g.KapanId,
                                Size = g.Size,
                                SizeId = g.SizeId,
                                Purity = g.Purity,
                                PurityId = g.PurityId,
                                Shape = g.Shape,
                                ShapeId = g.ShapeId,
                                CharniSizeId = g.CharniSizeId,
                                CharniSize = g.CharniSize,
                                GalaNumberId = g.GalaNumberId,
                                GalaSize = g.GalaSize,
                                NumberSizeId = g.NumberSizeId,
                                NumberSize = g.NumberSize,
                                AvailableWeight = g.AvailableWeight,
                                Id = g.KapanId + g.SizeId + g.ShapeId + g.PurityId,
                            }).GroupBy(r => new
                            {
                                r.Kapan,
                                r.KapanId,
                                r.Purity,
                                r.PurityId,
                                r.Shape,
                                r.ShapeId,
                                r.Size,
                                r.SizeId,
                                r.CharniSizeId,
                                r.CharniSize,
                                r.GalaNumberId,
                                r.GalaSize,
                                r.NumberSizeId,
                                r.NumberSize
                            }).OrderBy(g => g.Key.CharniSizeId).Select(g => new Repository.Entities.Model.SalesItemDetails()
                            {
                                Kapan = g.Key.Kapan,
                                KapanId = g.Key.KapanId,
                                Size = g.Key.Size,
                                SizeId = g.Key.SizeId,
                                Purity = g.Key.Purity,
                                PurityId = g.Key.PurityId,
                                Shape = g.Key.Shape,
                                ShapeId = g.Key.ShapeId,
                                CharniSizeId = g.Key.CharniSizeId,
                                CharniSize = g.Key.CharniSize,
                                GalaNumberId = g.Key.GalaNumberId,
                                GalaSize = g.Key.GalaSize,
                                NumberSizeId = g.Key.NumberSizeId,
                                NumberSize = g.Key.NumberSize,
                                Id = g.Key.KapanId + g.Key.ShapeId + g.Key.PurityId + g.Key.SizeId + g.Key.CharniSizeId + g.Key.GalaNumberId + g.Key.NumberSizeId,
                                AvailableWeight = g.Sum(x => x.AvailableWeight),
                            });

                            repoShape.DataSource = listNumberProcess1;
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
                        if (grvTransferItemDetails.GetRowCellValue(e.RowHandle, colCategoryType).ToString() == TransferCategoryMaster.Kapan.ToString())
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
                            grvTransferItemDetails.SetRowCellValue(e.RowHandle, colCarat, ((Repository.Entities.Models.AssortmentProcessSend)repoShape.GetDataSourceRowByKeyValue(e.Value)).AvailableWeight);

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
                        else if (grvTransferItemDetails.GetRowCellValue(e.RowHandle, colCategoryType).ToString() == TransferCategoryMaster.Number.ToString())
                        {
                            grvTransferItemDetails.SetRowCellValue(e.RowHandle, colSize, ((Repository.Entities.Model.SalesItemDetails)repoShape.GetDataSourceRowByKeyValue(e.Value)).Size);
                            grvTransferItemDetails.SetRowCellValue(e.RowHandle, colPurity, ((Repository.Entities.Model.SalesItemDetails)repoShape.GetDataSourceRowByKeyValue(e.Value)).Purity);
                            //grvTransferItemDetails.SetRowCellValue(e.RowHandle, colCaratCategory, ((Repository.Entities.Models.CharniProcessSend)repoSlipNo.GetDataSourceRowByKeyValue(e.Value)).SizeId);
                            grvTransferItemDetails.SetRowCellValue(e.RowHandle, colType, ((Repository.Entities.Model.SalesItemDetails)repoShape.GetDataSourceRowByKeyValue(e.Value)).NumberSize);
                            grvTransferItemDetails.SetRowCellValue(e.RowHandle, colKapan, ((Repository.Entities.Model.SalesItemDetails)repoShape.GetDataSourceRowByKeyValue(e.Value)).Kapan);
                            grvTransferItemDetails.SetRowCellValue(e.RowHandle, colCarat, ((Repository.Entities.Model.SalesItemDetails)repoShape.GetDataSourceRowByKeyValue(e.Value)).AvailableWeight);

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
                    {
                        //grvTransferItemDetails.Columns["ShapeT"].Visible = false;
                        //colSizeT.Visible = false;
                        grvTransferItemDetails.SetRowCellValue(e.RowHandle, colSizeT, null);
                        grvTransferItemDetails.SetRowCellValue(e.RowHandle, colCaratCategoryT, 1);
                    }
                    else if (grvTransferItemDetails.GetRowCellValue(e.RowHandle, colCategoryT).ToString() == TransferCategoryMaster.Number.ToString())
                    {
                        //grvTransferItemDetails.Columns["ShapeT"].Visible = true;
                        //colSizeT.Visible = true;
                        grvTransferItemDetails.SetRowCellValue(e.RowHandle, colSizeT, null);
                        grvTransferItemDetails.SetRowCellValue(e.RowHandle, colCaratCategoryT, 0);
                    }
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
                NumberProcessMasterRepository numberProcessMasterRepository;
                KapanMappingMaster kapanMappingMaster;
                NumberProcessMaster numberProcessMaster;
                OpeningStockMaster openingStockMaster;

                for (int i = 0; i < grvTransferItemDetails.RowCount; i++)
                {
                    string TransferEntryId = Guid.NewGuid().ToString();
                    DataView dtView = new DataView();
                    //string TransferType = grvTransferItemDetails.GetRowCellValue(i, colCategoryType).ToString() + "-" + grvTransferItemDetails.GetRowCellValue(i, colCategoryT).ToString();
                    //Transfer From
                    if (grvTransferItemDetails.GetRowCellValue(i, colCategoryType).ToString() == TransferCategoryMaster.Kapan.ToString())
                    {
                        AccountToAssortMasterRepository accountToAssortMasterRepository = new AccountToAssortMasterRepository();
                        var ListKapanProcessSend = await accountToAssortMasterRepository.GetAssortmentSendToDetails(lueCompany.EditValue.ToString(), grvTransferItemDetails.GetRowCellValue(i, colBranch).ToString(), Common.LoginFinancialYear.ToString());
                        var listKapanProcess = ListKapanProcessSend.Where(x => x.KapanId == grvTransferItemDetails.GetRowCellValue(i, colCategory).ToString()).ToList();

                        DataTable dt = Common.ToDataTable(listKapanProcess);
                        dtView = new DataView(dt);
                        dtView.RowFilter = "KapanId='" + grvTransferItemDetails.GetRowCellValue(i, colKapanId).ToString() + "' and  PurityId='" + grvTransferItemDetails.GetRowCellValue(i, colPurityId).ToString() + "'" +
                            "and ShapeId='" + grvTransferItemDetails.GetRowCellValue(i, colShapeId).ToString() + "' and SizeId='" + grvTransferItemDetails.GetRowCellValue(i, colSizeId).ToString() + "'" +
                            "and AvailableWeight > 0";

                        if (dtView.Count>0)
                        {
                            dtView.Sort="SlipNo ASC";

                            decimal Value = Convert.ToDecimal(grvTransferItemDetails.GetRowCellValue(i, colCaratT).ToString());

                            if (!dt.Columns.Contains("AdjustCarat"))
                            {
                                DataColumn column = new DataColumn();
                                column.ColumnName = "AdjustCarat";
                                column.DataType = System.Type.GetType("System.Decimal");
                                column.DefaultValue = 0;
                                column.ReadOnly = false;

                                dt.Columns.Add(column);
                            }

                            if (!dt.Columns.Contains("TransferEntryId"))
                            {
                                DataColumn column = new DataColumn();
                                column.ColumnName = "TransferEntryId";
                                column.DataType = System.Type.GetType("System.String");
                                column.DefaultValue = "";
                                column.ReadOnly = false;

                                dt.Columns.Add(column);
                            }

                            foreach (DataRowView row in dtView)
                            {
                                row["AdjustCarat"] = 0;
                                row["TransferEntryId"] = "";
                            }

                            decimal a = Convert.ToDecimal(dtView.ToTable().Compute("SUM(AvailableWeight)", string.Empty));
                            if (Value > a)
                            {
                                MessageBox.Show("Max Amount allowed for available Weight is '" + a.ToString("0.000") + "'.");
                                return;
                            }
                            decimal TotalValue = 0;
                            decimal RemainValue = Value;
                            decimal AvailableValue = 0;
                            foreach (DataRowView row in dtView)
                            {
                                if (TotalValue != Value)
                                {
                                    AvailableValue = Convert.ToDecimal(row["AvailableWeight"]);
                                    decimal TempValue = AvailableValue - RemainValue;
                                    if (TempValue <= 0)
                                    {
                                        row["AdjustCarat"] = AvailableValue;
                                        TotalValue += AvailableValue;
                                        RemainValue = TempValue * -1;
                                    }
                                    else
                                    {
                                        row["AdjustCarat"] = RemainValue;
                                        TotalValue += RemainValue;
                                        RemainValue = 0;
                                    }
                                    row["TransferEntryId"] = Guid.NewGuid().ToString();
                                }
                            }
                        }

                        dtView.RowFilter = "AdjustCarat > 0";
                        if (dtView.Count > 0)
                        {
                            foreach (DataRowView row in dtView)
                            {
                                if (row["KapanType"].ToString().Equals("KapanMapped"))
                                {
                                    kapanMappingMaster = new KapanMappingMaster();
                                    kapanMappingMaster.Id = Guid.NewGuid().ToString();
                                    kapanMappingMaster.CompanyId = lueCompany.EditValue.ToString();
                                    kapanMappingMaster.BranchId = grvTransferItemDetails.GetRowCellValue(i, colBranch).ToString();
                                    kapanMappingMaster.FinancialYearId = Common.LoginFinancialYear.ToString();
                                    kapanMappingMaster.PurchaseMasterId = row["PurchaseMasterId"].ToString();
                                    kapanMappingMaster.PurchaseDetailsId = row["PurchaseDetailsId"].ToString();
                                    kapanMappingMaster.PurityId = row["PurityId"].ToString();
                                    kapanMappingMaster.KapanId = row["KapanId"].ToString();
                                    kapanMappingMaster.SlipNo = row["SlipNo"].ToString();
                                    kapanMappingMaster.Weight = Convert.ToDecimal(row["AdjustCarat"].ToString()) * -1;

                                    kapanMappingMaster.TransferId = TransferId;
                                    kapanMappingMaster.TransferType = "TransferedFrom";
                                    kapanMappingMaster.TransferEntryId = row["TransferEntryId"].ToString();
                                    kapanMappingMaster.TransferCaratRate = Convert.ToDouble(grvTransferItemDetails.GetRowCellValue(i, colRate).ToString());

                                    kapanMappingMaster.CreatedDate = DateTime.Now;
                                    kapanMappingMaster.CreatedBy = Common.LoginUserID;
                                    kapanMappingMaster.UpdatedDate = DateTime.Now;
                                    kapanMappingMaster.UpdatedBy = Common.LoginUserID;

                                    kapanMappingMasterRepository = new KapanMappingMasterRepository();
                                    var Result1 = await kapanMappingMasterRepository.AddKapanMappingAsync(kapanMappingMaster);
                                    kapanMappingMasterRepository = null;
                                }
                                else if (row["KapanType"].ToString().Equals("OpeningStock"))
                                {
                                    openingStockMaster = new OpeningStockMaster();
                                    openingStockMaster.Id = Guid.NewGuid().ToString();
                                    openingStockMaster.SrNo = 0;
                                    openingStockMaster.StockId = row["StockId"].ToString();
                                    openingStockMaster.EntryDate = Convert.ToDateTime(dtDate.Text).ToString("yyyyMMdd");
                                    openingStockMaster.EntryTime = Convert.ToDateTime(dtTime.Text).ToString("hh:mm:ss ttt");
                                    openingStockMaster.Category = TransferCategoryMaster.Kapan;
                                    openingStockMaster.CompanyId = lueCompany.EditValue.ToString();
                                    openingStockMaster.BranchId = grvTransferItemDetails.GetRowCellValue(i, colBranch).ToString();
                                    openingStockMaster.FinancialYearId = Common.LoginFinancialYear.ToString();

                                    openingStockMaster.KapanId = row["KapanId"].ToString();
                                    openingStockMaster.SizeId = row["SizeId"].ToString();

                                    openingStockMaster.ShapeId = row["ShapeId"].ToString();
                                    openingStockMaster.PurityId = row["PurityId"].ToString();

                                    openingStockMaster.TotalCts = Convert.ToDecimal(row["AdjustCarat"].ToString()) * -1;
                                    openingStockMaster.Rate = Convert.ToDecimal(grvTransferItemDetails.GetRowCellValue(i, colRate).ToString());
                                    openingStockMaster.Amount = Convert.ToDecimal(row["AdjustCarat"].ToString()) * Convert.ToDecimal(grvTransferItemDetails.GetRowCellValue(i, colRate));

                                    openingStockMaster.TransferId = TransferId;
                                    openingStockMaster.TransferType = "TransferedFrom";
                                    openingStockMaster.TransferEntryId = row["TransferEntryId"].ToString();
                                    openingStockMaster.TransferCaratRate = Convert.ToDouble(grvTransferItemDetails.GetRowCellValue(i, colRate).ToString());

                                    openingStockMaster.Remarks = txtRemark.Text;
                                    openingStockMaster.CreatedDate = DateTime.Now;
                                    openingStockMaster.CreatedBy = Common.LoginUserID;
                                    openingStockMaster.UpdatedDate = DateTime.Now;
                                    openingStockMaster.UpdatedBy = Common.LoginUserID;

                                    OpeningStockMasterRepositody openingStockMasterRepositody = new OpeningStockMasterRepositody();
                                    var Result1 = await openingStockMasterRepositody.AddOpeningStockAsync(openingStockMaster);
                                    openingStockMasterRepositody = null;
                                }
                                else if (row["KapanType"].ToString().Equals("Boil"))
                                {
                                    BoilProcessMaster boilProcessMaster = new BoilProcessMaster();
                                    boilProcessMaster.Id = Guid.NewGuid().ToString();
                                    boilProcessMaster.BoilNo = 0;
                                    boilProcessMaster.JangadNo = 0;
                                    boilProcessMaster.CompanyId = lueCompany.EditValue.ToString();
                                    boilProcessMaster.BranchId = grvTransferItemDetails.GetRowCellValue(i, colBranch).ToString();
                                    boilProcessMaster.EntryDate = Convert.ToDateTime(dtDate.Text).ToString("yyyyMMdd");
                                    boilProcessMaster.EntryTime = Convert.ToDateTime(dtTime.Text).ToString("hh:mm:ss ttt");
                                    boilProcessMaster.FinancialYearId = row["FinancialYearId"].ToString();
                                    boilProcessMaster.BoilType = Convert.ToInt32(ProcessType.Transfer);
                                    boilProcessMaster.KapanId = row["KapanId"].ToString();
                                    boilProcessMaster.ShapeId = row["ShapeId"].ToString();
                                    boilProcessMaster.SizeId = row["SizeId"].ToString();
                                    boilProcessMaster.PurityId = row["PurityId"].ToString();
                                    boilProcessMaster.Weight = Convert.ToDecimal(row["AdjustCarat"]) * -1;
                                    boilProcessMaster.LossWeight = 0;
                                    boilProcessMaster.RejectionWeight = 0;
                                    boilProcessMaster.HandOverById = lueTransferBy.EditValue.ToString();
                                    boilProcessMaster.HandOverToId = lueTransferBy.EditValue.ToString();
                                    boilProcessMaster.SlipNo = row["SlipNo"].ToString();
                                    boilProcessMaster.BoilCategoy = 0;
                                    boilProcessMaster.Remarks = txtRemark.Text;
                                    boilProcessMaster.IsDelete = false;
                                    boilProcessMaster.CreatedDate = DateTime.Now;
                                    boilProcessMaster.CreatedBy = Common.LoginUserID;
                                    boilProcessMaster.UpdatedDate = DateTime.Now;
                                    boilProcessMaster.UpdatedBy = Common.LoginUserID;
                                    boilProcessMaster.TransferId = TransferId;
                                    boilProcessMaster.TransferType = "TransferedFrom";
                                    boilProcessMaster.TransferEntryId = row["TransferEntryId"].ToString();
                                    boilProcessMaster.TransferCaratRate = Convert.ToDouble(grvTransferItemDetails.GetRowCellValue(i, colRate).ToString());

                                    BoilMasterRepository boilMasterRepository = new BoilMasterRepository();
                                    var Result1 = await boilMasterRepository.AddBoilAsync(boilProcessMaster);
                                }
                            }
                        }
                    }
                    else if (grvTransferItemDetails.GetRowCellValue(i, colCategoryType).ToString() == TransferCategoryMaster.Number.ToString())
                    {
                        var ListNumberProcessReturn = await _salesMasterRepository.GetSalesItemDetails(CategoryMaster.Number, lueCompany.EditValue.ToString(), grvTransferItemDetails.GetRowCellValue(i, colBranch).ToString(), Common.LoginFinancialYear);
                        var listNumberProcess = ListNumberProcessReturn.Where(x => x.CharniSizeId == grvTransferItemDetails.GetRowCellValue(i, colCategory).ToString()).ToList();

                        DataTable dt = Common.ToDataTable(listNumberProcess);
                        dtView = new DataView(dt);
                        dtView.RowFilter = "KapanId='" + grvTransferItemDetails.GetRowCellValue(i, colKapanId).ToString() + "' and  PurityId='" + grvTransferItemDetails.GetRowCellValue(i, colPurityId).ToString() + "'" +
                            "and ShapeId='" + grvTransferItemDetails.GetRowCellValue(i, colShapeId).ToString() + "' and SizeId='" + grvTransferItemDetails.GetRowCellValue(i, colSizeId).ToString() + "'"+
                            "and CharniSizeId='" + grvTransferItemDetails.GetRowCellValue(i, colCharniSizeId).ToString() + "'";
                        
                        if (dtView.Count > 0)
                        {
                            dtView.Sort = "CharniSizeId ASC";

                            decimal Value = Convert.ToDecimal(grvTransferItemDetails.GetRowCellValue(i, colCaratT).ToString());

                            if (!dt.Columns.Contains("AdjustCarat"))
                            {
                                DataColumn column = new DataColumn();
                                column.ColumnName = "AdjustCarat";
                                column.DataType = System.Type.GetType("System.Decimal");
                                column.DefaultValue = 0;
                                column.ReadOnly = false;

                                dt.Columns.Add(column);
                            }

                            if (!dt.Columns.Contains("TransferEntryId"))
                            {
                                DataColumn column = new DataColumn();
                                column.ColumnName = "TransferEntryId";
                                column.DataType = System.Type.GetType("System.String");
                                column.DefaultValue = "";
                                column.ReadOnly = false;

                                dt.Columns.Add(column);
                            }

                            foreach (DataRowView row in dtView)
                            {
                                row["AdjustCarat"] = 0;
                                row["TransferEntryId"] = "";
                            }

                            decimal a = Convert.ToDecimal(dtView.ToTable().Compute("SUM(AvailableWeight)", string.Empty));
                            if (Value > a)
                            {
                                MessageBox.Show("Max Amount allowed for available Weight is '" + a.ToString("0.000") + "'.");
                                return;
                            }
                            decimal TotalValue = 0;
                            decimal RemainValue = Value;
                            decimal AvailableValue = 0;
                            foreach (DataRowView row in dtView)
                            {
                                if (TotalValue != Value)
                                {
                                    AvailableValue = Convert.ToDecimal(row["AvailableWeight"]);
                                    decimal TempValue = AvailableValue - RemainValue;
                                    if (TempValue <= 0)
                                    {
                                        row["AdjustCarat"] = AvailableValue;
                                        TotalValue += AvailableValue;
                                        RemainValue = TempValue * -1;
                                    }
                                    else
                                    {
                                        row["AdjustCarat"] = RemainValue;
                                        TotalValue += RemainValue;
                                        RemainValue = 0;
                                    }
                                    row["TransferEntryId"] = Guid.NewGuid().ToString();
                                }
                            }
                        }

                        dtView.RowFilter = "AdjustCarat > 0";
                        if (dtView.Count > 0)
                        {
                            foreach (DataRowView row in dtView)
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
                                numberProcessMaster.KapanId = row["KapanId"].ToString();
                                numberProcessMaster.ShapeId = row["ShapeId"].ToString();
                                numberProcessMaster.SizeId = row["SizeId"].ToString();
                                numberProcessMaster.PurityId = row["PurityId"].ToString();
                                numberProcessMaster.CharniSizeId = row["CharniSizeId"].ToString();
                                numberProcessMaster.Weight = 0;
                                //numberProcessMaster.GalaNumberId = grvTransferItemDetails.GetRowCellValue(i, colTypeId).ToString();
                                numberProcessMaster.NumberId = grvTransferItemDetails.GetRowCellValue(i, colTypeId).ToString();
                                numberProcessMaster.NumberWeight = Convert.ToDecimal(row["AdjustCarat"]) * -1;
                                numberProcessMaster.LossWeight = 0;
                                numberProcessMaster.RejectionWeight = 0;
                                numberProcessMaster.HandOverById = lueTransferBy.EditValue.ToString();
                                numberProcessMaster.HandOverToId = lueTransferBy.EditValue.ToString();
                                numberProcessMaster.SlipNo = grvTransferItemDetails.GetRowCellValue(i, colSlipNo).ToString();
                                numberProcessMaster.NumberCategoy = 0;
                                numberProcessMaster.Remarks = txtRemark.Text;

                                numberProcessMaster.TransferId = TransferId;
                                numberProcessMaster.TransferType = "TransferedFrom";
                                numberProcessMaster.TransferEntryId = row["TransferEntryId"].ToString();
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
                        }
                    }

                    //Transfer To
                    if (grvTransferItemDetails.GetRowCellValue(i, colCategoryT).ToString() == TransferCategoryMaster.Kapan.ToString())
                    {
                        if (dtView.Count > 0)
                        {
                            foreach (DataRowView row in dtView)
                            {
                                if (!dtView.Table.Columns.Contains("KapanType") || 
                                    (dtView.Table.Columns.Contains("KapanType") && row["KapanType"].ToString().Equals("KapanMapped")))
                                {
                                    kapanMappingMaster = new KapanMappingMaster();
                                    kapanMappingMaster.Id = Guid.NewGuid().ToString();
                                    kapanMappingMaster.CompanyId = lueCompany.EditValue.ToString();
                                    kapanMappingMaster.BranchId = grvTransferItemDetails.GetRowCellValue(i, colBranch).ToString();
                                    kapanMappingMaster.FinancialYearId = Common.LoginFinancialYear.ToString();
                                    kapanMappingMaster.PurchaseMasterId = row.Row.Table.Columns.Contains("PurchaseMasterId")? row["PurchaseMasterId"].ToString():"";
                                    kapanMappingMaster.PurchaseDetailsId = row.Row.Table.Columns.Contains("PurchaseDetailsId")? row["PurchaseDetailsId"].ToString():"";
                                    kapanMappingMaster.PurityId = grvTransferItemDetails.GetRowCellValue(i, colPurityId).ToString();
                                    kapanMappingMaster.KapanId = grvTransferItemDetails.GetRowCellValue(i, colTypeIdT).ToString();
                                    kapanMappingMaster.SlipNo = grvTransferItemDetails.GetRowCellValue(i, colSlipNo).ToString();
                                    kapanMappingMaster.Weight = Convert.ToDecimal(row["AdjustCarat"].ToString());

                                    kapanMappingMaster.TransferId = TransferId;
                                    kapanMappingMaster.TransferType = "TransferedTo";
                                    kapanMappingMaster.TransferEntryId = row["TransferEntryId"].ToString();
                                    kapanMappingMaster.TransferCaratRate = Convert.ToDouble(grvTransferItemDetails.GetRowCellValue(i, colRateT).ToString());

                                    kapanMappingMaster.CreatedDate = DateTime.Now;
                                    kapanMappingMaster.CreatedBy = Common.LoginUserID;
                                    kapanMappingMaster.UpdatedDate = DateTime.Now;
                                    kapanMappingMaster.UpdatedBy = Common.LoginUserID;

                                    kapanMappingMasterRepository = new KapanMappingMasterRepository();
                                    var Result1 = await kapanMappingMasterRepository.AddKapanMappingAsync(kapanMappingMaster);
                                    kapanMappingMasterRepository = null;
                                }
                                else if (row["KapanType"].ToString().Equals("OpeningStock"))
                                {
                                    openingStockMaster = new OpeningStockMaster();
                                    openingStockMaster.Id = Guid.NewGuid().ToString();
                                    openingStockMaster.SrNo = 0;
                                    openingStockMaster.StockId = row["StockId"].ToString();
                                    openingStockMaster.EntryDate = Convert.ToDateTime(dtDate.Text).ToString("yyyyMMdd");
                                    openingStockMaster.EntryTime = Convert.ToDateTime(dtTime.Text).ToString("hh:mm:ss ttt");
                                    openingStockMaster.Category = TransferCategoryMaster.Kapan;
                                    openingStockMaster.CompanyId = lueCompany.EditValue.ToString();
                                    openingStockMaster.BranchId = grvTransferItemDetails.GetRowCellValue(i, colBranch).ToString();
                                    openingStockMaster.FinancialYearId = Common.LoginFinancialYear.ToString();

                                    openingStockMaster.KapanId = grvTransferItemDetails.GetRowCellValue(i, colTypeIdT).ToString();
                                    openingStockMaster.SizeId = grvTransferItemDetails.GetRowCellValue(i, colSizeId).ToString();

                                    openingStockMaster.ShapeId = grvTransferItemDetails.GetRowCellValue(i, colShapeId).ToString();
                                    openingStockMaster.PurityId = grvTransferItemDetails.GetRowCellValue(i, colPurityId).ToString();

                                    openingStockMaster.TotalCts = Convert.ToDecimal(row["AdjustCarat"].ToString());
                                    openingStockMaster.Rate = Convert.ToDecimal(grvTransferItemDetails.GetRowCellValue(i, colRateT).ToString());
                                    openingStockMaster.Amount = Convert.ToDecimal(row["AdjustCarat"].ToString()) * Convert.ToDecimal(grvTransferItemDetails.GetRowCellValue(i, colRateT).ToString());

                                    openingStockMaster.TransferId = TransferId;
                                    openingStockMaster.TransferType = "TransferedTo";
                                    openingStockMaster.TransferEntryId = row["TransferEntryId"].ToString();
                                    openingStockMaster.TransferCaratRate = Convert.ToDouble(grvTransferItemDetails.GetRowCellValue(i, colRateT).ToString());

                                    openingStockMaster.Remarks = txtRemark.Text;
                                    openingStockMaster.CreatedDate = DateTime.Now;
                                    openingStockMaster.CreatedBy = Common.LoginUserID;
                                    openingStockMaster.UpdatedDate = DateTime.Now;
                                    openingStockMaster.UpdatedBy = Common.LoginUserID;

                                    OpeningStockMasterRepositody openingStockMasterRepositody = new OpeningStockMasterRepositody();
                                    var Result1 = await openingStockMasterRepositody.AddOpeningStockAsync(openingStockMaster);
                                    openingStockMasterRepositody = null;
                                }
                                else if (row["KapanType"].ToString().Equals("Boil"))
                                {
                                    BoilProcessMaster boilProcessMaster = new BoilProcessMaster();
                                    boilProcessMaster.Id = Guid.NewGuid().ToString();
                                    boilProcessMaster.BoilNo = 0;
                                    boilProcessMaster.JangadNo = 0;
                                    boilProcessMaster.CompanyId = lueCompany.EditValue.ToString();
                                    boilProcessMaster.BranchId = grvTransferItemDetails.GetRowCellValue(i, colBranchT).ToString();
                                    boilProcessMaster.EntryDate = Convert.ToDateTime(dtDate.Text).ToString("yyyyMMdd");
                                    boilProcessMaster.EntryTime = Convert.ToDateTime(dtTime.Text).ToString("hh:mm:ss ttt");
                                    boilProcessMaster.FinancialYearId = row["FinancialYearId"].ToString();
                                    boilProcessMaster.BoilType = Convert.ToInt32(ProcessType.Transfer);
                                    boilProcessMaster.KapanId = grvTransferItemDetails.GetRowCellValue(i, colTypeIdT).ToString();
                                    boilProcessMaster.ShapeId = grvTransferItemDetails.GetRowCellValue(i, colShapeT).ToString();
                                    boilProcessMaster.SizeId = grvTransferItemDetails.GetRowCellValue(i, colSizeT).ToString();
                                    boilProcessMaster.PurityId = grvTransferItemDetails.GetRowCellValue(i, colPurityT).ToString();
                                    boilProcessMaster.Weight = Convert.ToDecimal(row["AdjustCarat"]);
                                    boilProcessMaster.LossWeight = 0;
                                    boilProcessMaster.RejectionWeight = 0;
                                    boilProcessMaster.HandOverById = lueTransferBy.EditValue.ToString();
                                    boilProcessMaster.HandOverToId = lueTransferBy.EditValue.ToString();
                                    boilProcessMaster.SlipNo = row["SlipNo"].ToString();
                                    boilProcessMaster.BoilCategoy = 0;
                                    boilProcessMaster.Remarks = txtRemark.Text;
                                    boilProcessMaster.IsDelete = false;
                                    boilProcessMaster.CreatedDate = DateTime.Now;
                                    boilProcessMaster.CreatedBy = Common.LoginUserID;
                                    boilProcessMaster.UpdatedDate = DateTime.Now;
                                    boilProcessMaster.UpdatedBy = Common.LoginUserID;
                                    boilProcessMaster.TransferId = TransferId;
                                    boilProcessMaster.TransferType = "TransferedTo";
                                    boilProcessMaster.TransferEntryId = row["TransferEntryId"].ToString();
                                    boilProcessMaster.TransferCaratRate = Convert.ToDouble(grvTransferItemDetails.GetRowCellValue(i, colRateT).ToString());

                                    BoilMasterRepository boilMasterRepository = new BoilMasterRepository();
                                    var Result1 = await boilMasterRepository.AddBoilAsync(boilProcessMaster);
                                }
                            }
                        }
                    }
                    else if (grvTransferItemDetails.GetRowCellValue(i, colCategoryT).ToString() == TransferCategoryMaster.Number.ToString())
                    {
                        if (dtView.Count > 0)
                        {
                            foreach (DataRowView row in dtView)
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
                                numberProcessMaster.CharniSizeId = grvTransferItemDetails.GetRowCellValue(i, colSizeT).ToString();//grvTransferItemDetails.GetRowCellValue(i, colCharniSizeId).ToString();
                                numberProcessMaster.Weight = 0;
                                //numberProcessMaster.GalaNumberId = grvTransferItemDetails.GetRowCellValue(i, colTypeId).ToString();
                                numberProcessMaster.NumberId = grvTransferItemDetails.GetRowCellValue(i, colTypeIdT).ToString();
                                numberProcessMaster.NumberWeight = Convert.ToDecimal(row["AdjustCarat"].ToString());
                                numberProcessMaster.LossWeight = 0;
                                numberProcessMaster.RejectionWeight = 0;
                                numberProcessMaster.HandOverById = lueTransferBy.EditValue.ToString();
                                numberProcessMaster.HandOverToId = lueTransferBy.EditValue.ToString();
                                numberProcessMaster.SlipNo = grvTransferItemDetails.GetRowCellValue(i, colSlipNo).ToString();
                                numberProcessMaster.NumberCategoy = 0;
                                numberProcessMaster.Remarks = txtRemark.Text;

                                numberProcessMaster.TransferId = TransferId;
                                numberProcessMaster.TransferType = "TransferedTo";
                                numberProcessMaster.TransferEntryId = row["TransferEntryId"].ToString();
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
                return false;
                MessageBox.Show("Please select Particulars Details", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                grvTransferItemDetails.Focus();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            dtTime.EditValue = DateTime.Now;
        }
    }
}