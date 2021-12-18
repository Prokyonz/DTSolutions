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
        SalesMasterRepository _salesMasterRepository;
        SalesItemObj _salesItemObj;
        List<CaratCategoryType> _caratCategoryTypes;

        public FrmTransferEntry()
        {
            InitializeComponent();
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
            return dt;
        }

        private void LoadTransferItemDetails()
        {
            grdTransferItemDetails.DataSource = GetDTColumnsforPurchaseDetails();

            //Company
            LoadCompany();

            //Branch
            GetBrancheDetail();

            //Category
            GetCategoryDetail();
            
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

        private async void GetCategoryDetail()
        {
            var Category = CategoryMaster.GetAllCategory();

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
                    if (grvTransferItemDetails.GetRowCellValue(e.RowHandle, colCategory).ToString() == CategoryMaster.Charni.ToString())
                    {
                        grvTransferItemDetails.SetRowCellValue(e.RowHandle, colCaratCategory, CaratCategoryMaster.CharniCarat);

                        if (!string.IsNullOrEmpty(grvTransferItemDetails.GetRowCellValue(e.RowHandle, colBranch).ToString()))
                        {
                            GalaProcessMasterRepository galaProcessMasterRepository = new GalaProcessMasterRepository();
                            var ListGalaProcessSend = await galaProcessMasterRepository.GetGalaSendToDetails(lueCompany.EditValue.ToString(), grvTransferItemDetails.GetRowCellValue(e.RowHandle, colBranch).ToString(), Common.LoginFinancialYear.ToString());

                            repoShape.DataSource = ListGalaProcessSend;
                            repoShape.DisplayMember = "Shape";
                            repoShape.ValueMember = "ShapeId";

                            repoShape.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                            repoShape.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;

                            repoShape.Columns["BoilNo"].Visible = false;
                            repoShape.Columns["CharniSize"].Visible = true;
                            repoShape.Columns["GalaNumber"].Visible = false;
                            repoShape.Columns["Number"].Visible = false;
                        }
                    }
                    else if (grvTransferItemDetails.GetRowCellValue(e.RowHandle, colCategory).ToString() == CategoryMaster.Number.ToString())
                    {
                        grvTransferItemDetails.SetRowCellValue(e.RowHandle, colCaratCategory, CaratCategoryMaster.NumberCarat);

                        if (!string.IsNullOrEmpty(grvTransferItemDetails.GetRowCellValue(e.RowHandle, colBranch).ToString()))
                        {
                            NumberProcessMasterRepository numberProcessMasterRepository = new NumberProcessMasterRepository();
                            var ListNumberProcessReturn = await numberProcessMasterRepository.GetNumberReturnDetails(lueCompany.EditValue.ToString(), grvTransferItemDetails.GetRowCellValue(e.RowHandle, colBranch).ToString(), Common.LoginFinancialYear.ToString());

                            repoShape.DataSource = ListNumberProcessReturn;
                            repoShape.DisplayMember = "Shape";
                            repoShape.ValueMember = "ShapeId";

                            repoShape.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                            repoShape.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;

                            repoShape.Columns["BoilNo"].Visible = false;
                            repoShape.Columns["CharniSize"].Visible = false;
                            repoShape.Columns["GalaNumber"].Visible = false;
                            repoShape.Columns["Number"].Visible = true;
                        }
                    }
                    else if (grvTransferItemDetails.GetRowCellValue(e.RowHandle, colCategory).ToString() == CategoryMaster.Gala.ToString())
                    {
                        grvTransferItemDetails.SetRowCellValue(e.RowHandle, colCaratCategory, CaratCategoryMaster.GalaCarat);

                        if (!string.IsNullOrEmpty(grvTransferItemDetails.GetRowCellValue(e.RowHandle, colBranch).ToString()))
                        {
                            NumberProcessMasterRepository numberProcessMasterRepository = new NumberProcessMasterRepository();
                            var ListNumberProcessSend = await numberProcessMasterRepository.GetNumberSendToDetails(lueCompany.EditValue.ToString(), grvTransferItemDetails.GetRowCellValue(e.RowHandle, colBranch).ToString(), Common.LoginFinancialYear.ToString());

                            repoShape.DataSource = ListNumberProcessSend;
                            repoShape.DisplayMember = "Shape";
                            repoShape.ValueMember = "ShapeId";

                            repoShape.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                            repoShape.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;

                            repoShape.Columns["BoilNo"].Visible = false;
                            repoShape.Columns["CharniSize"].Visible = false;
                            repoShape.Columns["GalaNumber"].Visible = true;
                            repoShape.Columns["Number"].Visible = false;
                        }
                    }
                    else if (grvTransferItemDetails.GetRowCellValue(e.RowHandle, colCategory).ToString() == CategoryMaster.Boil.ToString())
                    {
                        grvTransferItemDetails.SetRowCellValue(e.RowHandle, colCaratCategory, CaratCategoryMaster.None);

                        if (!string.IsNullOrEmpty(grvTransferItemDetails.GetRowCellValue(e.RowHandle, colBranch).ToString()))
                        {
                            CharniProcessMasterRepository charniProcessMasterRepository = new CharniProcessMasterRepository();
                            var ListCharniProcessSend = await charniProcessMasterRepository.GetCharniSendToDetails(lueCompany.EditValue.ToString(), grvTransferItemDetails.GetRowCellValue(e.RowHandle, colBranch).ToString(), Common.LoginFinancialYear.ToString());

                            repoShape.DataSource = ListCharniProcessSend;
                            repoShape.DisplayMember = "Shape";
                            repoShape.ValueMember = "ShapeId";

                            repoShape.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                            repoShape.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;

                            repoShape.Columns["BoilNo"].Visible = true;
                            repoShape.Columns["CharniSize"].Visible = false;
                            repoShape.Columns["GalaNumber"].Visible = false;
                            repoShape.Columns["Number"].Visible = false;
                        }
                    }
                }
                else if (e.Column == colTypeT)
                {
                    try
                    {
                        //grvTransferItemDetails.SetRowCellValue(e.RowHandle, colTypeT, CaratCategoryMaster.GalaCarat);
                        grvTransferItemDetails.SetRowCellValue(e.RowHandle, colTypeT, ((Repository.Entities.Model.CaratCategoryType)repoTypeT.GetDataSourceRowByKeyValue(e.Value)).Name);
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

                }
                else if (e.Column == colCarat)
                {
                    //decimal TipWeight = Convert.ToDecimal(lueBranch.GetColumnValue("TipWeight"));
                    //decimal CVDWeight = Convert.ToDecimal(lueBranch.GetColumnValue("CVDWeight"));
                    //GetLessWeightDetailBasedOnCity(lueBranch.GetColumnValue("LessWeightId").ToString(), Convert.ToDecimal(grvPurchaseDetails.GetRowCellValue(e.RowHandle, colCarat)), e.RowHandle, TipWeight, CVDWeight);
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
                    if (Convert.ToInt32(grvTransferItemDetails.GetRowCellValue(e.RowHandle, colCaratCategoryT)) == CaratCategoryMaster.None)
                    {

                    }
                    else if (Convert.ToInt32(grvTransferItemDetails.GetRowCellValue(e.RowHandle, colCaratCategoryT)) == CaratCategoryMaster.CharniCarat)
                    {
                        if (_caratCategoryTypes == null)
                            _caratCategoryTypes = await _salesMasterRepository.GetCaratCategoryDetails();

                        repoTypeT.DataSource = _caratCategoryTypes.Where(x => x.Type.Equals(CaratCategoryMaster.CharniCarat));
                        repoTypeT.DisplayMember = "Name";
                        repoTypeT.ValueMember = "Id";

                        e.RepositoryItem = repoTypeT;
                    }
                    else if (Convert.ToInt32(grvTransferItemDetails.GetRowCellValue(e.RowHandle, colCaratCategoryT)) == CaratCategoryMaster.GalaCarat)
                    {
                        if (_caratCategoryTypes == null)
                            _caratCategoryTypes = await _salesMasterRepository.GetCaratCategoryDetails();

                        repoTypeT.DataSource = _caratCategoryTypes.Where(x => x.Type.Equals(CaratCategoryMaster.GalaCarat));
                        repoTypeT.DisplayMember = "Name";
                        repoTypeT.ValueMember = "Id";

                        e.RepositoryItem = repoTypeT;
                    }
                    else if (Convert.ToInt32(grvTransferItemDetails.GetRowCellValue(e.RowHandle, colCaratCategoryT)) == CaratCategoryMaster.NumberCarat)
                    {
                        if (_caratCategoryTypes == null)
                            _caratCategoryTypes = await _salesMasterRepository.GetCaratCategoryDetails();

                        repoTypeT.DataSource = _caratCategoryTypes.Where(x => x.Type.Equals(CaratCategoryMaster.NumberCarat));
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
    }
}