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

namespace DiamondTrading.Process
{
    public partial class FrmTransferEntry : DevExpress.XtraEditors.XtraForm
    {
        public FrmTransferEntry()
        {
            InitializeComponent();
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
            dt.Columns.Add("Shape");
            dt.Columns.Add("Size");
            dt.Columns.Add("Purity");
            dt.Columns.Add("Kapan");
            dt.Columns.Add("Carat");
            dt.Columns.Add("CharniSize");
            dt.Columns.Add("GalaSize");
            dt.Columns.Add("NumberSize");
            return dt;
        }

        private void LoadTransferItemDetails()
        {
            grdTransferItemDetails.DataSource = GetDTColumnsforPurchaseDetails();

            //Category
            GetCategoryDetail();

            //Shape
            GetShapeDetail();

            //Size
            GetSizeDetail();

            //Purity
            GetPurityDetail();

            //Kapan
            GetKapanDetail();

            //Charni
            GetCharniList();

            //Gala
            GetGalaList();

            //Number
            GetNumberList();
        }

        private async void GetCategoryDetail()
        {
            var Category = CategoryMaster.GetAllCategory();

            if (Category != null)
            {
                repoCategory.DataSource = Category;
                repoCategory.DisplayMember = "Name";
                repoCategory.ValueMember = "Id";
            }
        }

        private async void GetShapeDetail()
        {
            ShapeMasterRepository shapeMasterRepository = new ShapeMasterRepository();
            var shapeMaster = await shapeMasterRepository.GetAllShapeAsync();
            repoShape.DataSource = shapeMaster.s;
            repoShape.DisplayMember = "Name";
            repoShape.ValueMember = "Id";

            repoShapeT.DataSource = shapeMaster;
            repoShapeT.DisplayMember = "Name";
            repoShapeT.ValueMember = "Id";
        }

        private async void GetSizeDetail()
        {
            SizeMasterRepository sizeMasterRepository = new SizeMasterRepository();
            var sizeMaster = await sizeMasterRepository.GetAllSizeAsync();
            repoSize.DataSource = sizeMaster;
            repoSize.DisplayMember = "Name";
            repoSize.ValueMember = "Id";

            repoSizeT.DataSource = sizeMaster;
            repoSizeT.DisplayMember = "Name";
            repoSizeT.ValueMember = "Id";
        }

        private async void GetPurityDetail()
        {
            PurityMasterRepository purityMasterRepository = new PurityMasterRepository();
            var purityMaster = await purityMasterRepository.GetAllPurityAsync();
            repoPurity.DataSource = purityMaster;
            repoPurity.DisplayMember = "Name";
            repoPurity.ValueMember = "Id";

            repoPurityT.DataSource = purityMaster;
            repoPurityT.DisplayMember = "Name";
            repoPurityT.ValueMember = "Id";
        }

        private async void GetKapanDetail()
        {
            KapanMasterRepository kapanMasterRepository = new KapanMasterRepository();
            var kapanMaster = await kapanMasterRepository.GetAllKapanAsync();
            repoKapan.DataSource = kapanMaster;
            repoKapan.DisplayMember = "Name";
            repoKapan.ValueMember = "Id";

            repoKapanT.DataSource = kapanMaster;
            repoKapanT.DisplayMember = "Name";
            repoKapanT.ValueMember = "Id";
        }

        private async void GetCharniList()
        {
            SizeMasterRepository sizeMasterRepository = new SizeMasterRepository();
            var CharniMaster = await sizeMasterRepository.GetAllSizeAsync();
            repoCharniSize.DataSource = CharniMaster;
            repoCharniSize.DisplayMember = "Name";
            repoCharniSize.ValueMember = "Id";

            repoCharniT.DataSource = CharniMaster;
            repoCharniT.DisplayMember = "Name";
            repoCharniT.ValueMember = "Id";
        }

        private async void GetGalaList()
        {
            GalaMasterRepository galaMasterRepository = new GalaMasterRepository();
            var GalaMaster = await galaMasterRepository.GetAllGalaAsync();
            repoGalaSize.DataSource = GalaMaster;
            repoGalaSize.DisplayMember = "Name";
            repoGalaSize.ValueMember = "Id";

            repoGalaT.DataSource = GalaMaster;
            repoGalaT.DisplayMember = "Name";
            repoGalaT.ValueMember = "Id";
        }

        private async Task GetNumberList()
        {
            NumberMasterRepository numberMasterRepository = new NumberMasterRepository();
            var NumberMaster = await numberMasterRepository.GetAllNumberAsync();
            repoNumberSize.DataSource = NumberMaster;
            repoNumberSize.DisplayMember = "Name";
            repoNumberSize.ValueMember = "Id";

            repoNumberT.DataSource = NumberMaster;
            repoNumberT.DisplayMember = "Name";
            repoNumberT.ValueMember = "Id";
        }
    }
}