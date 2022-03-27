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
        public FrmOpeningStock()
        {
            InitializeComponent();
        }

        private void FrmOpeningStock_Load(object sender, EventArgs e)
        {
            dtDate.EditValue = DateTime.Now;
            dtTime.EditValue = DateTime.Now;

            LoadOpeningStockItemDetails();
        }

        private void LoadOpeningStockItemDetails()
        {
            grdTransferItemDetails.DataSource = GetDTColumnsforGridDetails();

            //Company
            LoadCompany();

            //Branch
            GetBrancheDetail();

            //Employee
            GetEmployeeList();

            //Category
            GetCategoryDetail();

            //Size
            GetSizeDetail();

            //Kapan
            GetKapanDetail();

            //NumberSize
            GetNumberSizeDetail();

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
            }
            else
            {
                repoBranch.DataSource = null;
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

        private async void GetCategoryDetail()
        {
            var Category = OpeningStockCategoryMaster.GetAllCategory();

            if (Category != null)
            {
                repoCategory.DataSource = Category;
                repoCategory.DisplayMember = "Name";
                repoCategory.ValueMember = "Id";
            }
        }

        private async void GetSizeDetail()
        {
            SizeMasterRepository sizeMasterRepository = new SizeMasterRepository();
            var sizeMaster = await sizeMasterRepository.GetAllSizeAsync();

            repoSize.DataSource = sizeMaster;
            repoSize.DisplayMember = "Name";
            repoSize.ValueMember = "Id";
        }

        private async void GetKapanDetail()
        {
            KapanMasterRepository kapanMasterRepository = new KapanMasterRepository();
            var kapanMaster = await kapanMasterRepository.GetAllKapanAsync();

            repoKapan.DataSource = kapanMaster;
            repoKapan.DisplayMember = "Name";
            repoKapan.ValueMember = "Id";
        }

        private async void GetNumberSizeDetail()
        {
            NumberMasterRepository numberMasterRepository = new NumberMasterRepository();
            var numberSizeMaster = await numberMasterRepository.GetAllNumberAsync();

            repoNumber.DataSource = numberSizeMaster;
            repoNumber.DisplayMember = "Name";
            repoNumber.ValueMember = "Id";
        }

        private void lueCompany_EditValueChanged(object sender, EventArgs e)
        {
            GetBrancheDetail();
        }

        private static DataTable GetDTColumnsforGridDetails()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Category");
            dt.Columns.Add("Branch");
            dt.Columns.Add("Kapan");
            dt.Columns.Add("Size");
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
    }
}