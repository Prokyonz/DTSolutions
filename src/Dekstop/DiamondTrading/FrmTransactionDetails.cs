using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
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

namespace DiamondTrading
{
    public partial class FrmTransactionDetails : DevExpress.XtraEditors.XtraForm
    {
        private PurchaseMasterRepository _purchaseMasterRepository;
        private SalesMasterRepository _salesMasterRepository;

        private List<PurchaseMaster> _purchaseMaster;
        private List<SalesMaster> _salesMaster;

        public FrmTransactionDetails()
        {
            InitializeComponent();
            //LoadGridData();
        }

        public void ActiveTab()
        {
            HideAllTabs();
            switch (SelectedTabPage)
            {
                case "Purchase":
                    xtabPurchase.PageVisible = true;
                    xtabMasterDetails.SelectedTabPage = xtabPurchase;
                    this.Text = "PURCHASE DETAILS";
                    break;
                case "Sales":
                    xtabSales.PageVisible = true;
                    xtabMasterDetails.SelectedTabPage = xtabSales;
                    this.Text = "SALES DETAILS";
                    break;
                default:
                    xtabPurchase.PageVisible = true;
                    xtabMasterDetails.SelectedTabPage = xtabPurchase;
                    this.Text = "PURCHASE DETAILS";
                    break;
            }
        }

        public string SelectedTabPage { get; set; }
        private void HideAllTabs()
        {
            xtabPurchase.PageVisible = false;
            xtabSales.PageVisible = false;
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private async void accordianAddBtn_Click(object sender, EventArgs e)
        {
            if (xtabMasterDetails.SelectedTabPage == xtabPurchase)
            {
                Transaction.FrmPurchaseEntry frmPurchaseEntry = new Transaction.FrmPurchaseEntry();
                if (frmPurchaseEntry.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabSales)
            {
                Transaction.FrmSalesEntry frmSalesEntry= new Transaction.FrmSalesEntry();
                if (frmSalesEntry.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
            }
        }

        private async void FrmMasterDetails_Load(object sender, EventArgs e)
        {
            ActiveTab();
            await LoadGridData(true);
        }

        private async Task LoadGridData(bool IsForceLoad=false)
        {
            if (xtabMasterDetails.SelectedTabPage == xtabPurchase)
            {
                if (IsForceLoad || _purchaseMasterRepository == null)
                {
                    _purchaseMasterRepository = new PurchaseMasterRepository();
                    _purchaseMaster = await _purchaseMasterRepository.GetAllPurchaseAsync(Common.LoginCompany,Common.LoginFinancialYear);
                    grdTransactionMaster.DataSource = _purchaseMaster.OrderBy(o=>o.SlipNo);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabSales)
            {
                //if (IsForceLoad || _branchMaster == null)
                //{
                //    _branchMasterRepository = new BranchMasterRepository();
                //    _branchMaster = await _branchMasterRepository.GetAllBranchAsync();
                //    grdBranchMaster.DataSource = _branchMaster;
                //}
            }
        }

        private async void accordionEditBtn_Click(object sender, EventArgs e)
        {
            if (xtabMasterDetails.SelectedTabPage == xtabPurchase)
            {
                ////Guid SelectedGuid = Guid.Parse(tlCompanyMaster.GetFocusedRowCellValue(Id).ToString());

                //string SelectedGuid;

                //if (grdCompanyMaster.FocusedView.DetailLevel > 0)
                //{
                //    GridView tempChild = ((GridView)grdCompanyMaster.FocusedView);
                //    SelectedGuid = tempChild.GetFocusedRowCellValue("Id").ToString();
                //} 
                //else                 
                //    SelectedGuid = grvCompanyMaster.GetFocusedRowCellValue("Id").ToString();                


                //Master.FrmCompanyMaster frmcompanymaster = new Master.FrmCompanyMaster(_companyMaster, SelectedGuid);

                //if (frmcompanymaster.ShowDialog() == DialogResult.OK)
                //{
                //    await LoadGridData(true);
                //}
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabSales)
            {
                //string SelectedGuid = grvBranchMaster.GetFocusedRowCellValue(colBranchId).ToString();
                //Master.FrmBranchMaster frmBranchMaster = new Master.FrmBranchMaster(_branchMaster, SelectedGuid);
                //if (frmBranchMaster.ShowDialog() == DialogResult.OK)
                //{
                //    await LoadGridData(true);
                //}
            }
        }

        private async void xtabMasterDetails_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            await LoadGridData();
        } 

        private async void accordionRefreshBtn_Click(object sender, EventArgs e)
        {
            await LoadGridData(true);
        }

        private async void accordionDeleteBtn_Click(object sender, EventArgs e)
        {
            if (xtabMasterDetails.SelectedTabPage == xtabPurchase)
            {
                ////Guid SelectedGuid = Guid.Parse(tlCompanyMaster.GetFocusedRowCellValue(Id).ToString());

                //string SelectedGuid;
                //string tempCompanyName = "";

                //if (grdCompanyMaster.FocusedView.DetailLevel > 0)
                //{
                //    GridView tempChild = ((GridView)grdCompanyMaster.FocusedView);
                //    SelectedGuid = tempChild.GetFocusedRowCellValue("Id").ToString();
                //    tempCompanyName = tempChild.GetFocusedRowCellValue("Name").ToString();
                //}
                //else
                //{
                //    SelectedGuid = grvCompanyMaster.GetFocusedRowCellValue("Id").ToString();
                //    tempCompanyName = grvCompanyMaster.GetFocusedRowCellValue("Name").ToString();
                //}
                //if (MessageBox.Show(string.Format(AppMessages.GetString(AppMessageID.DeleteCompanyCofirmation), tempCompanyName), "[" + this.Text + "}", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                //{
                //    var Result = await _companyMasterRepository.DeleteCompanyAsync(SelectedGuid);

                //    MessageBox.Show(AppMessages.GetString(AppMessageID.DeleteSuccessfully));
                //    await LoadGridData(true);
                //}
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabSales)
            {
                //string SelectedGuid = grvBranchMaster.GetFocusedRowCellValue(colBranchId).ToString();
                //if (MessageBox.Show(string.Format(AppMessages.GetString(AppMessageID.DeleteBranchCofirmation), grvBranchMaster.GetFocusedRowCellValue(colBranchName).ToString()), "[" + this.Text + "}", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                //{
                //    var Result = await _branchMasterRepository.DeleteBranchAsync(SelectedGuid);

                //    MessageBox.Show(AppMessages.GetString(AppMessageID.DeleteSuccessfully));
                //    await LoadGridData(true);
                //}
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void accordionCancelButton_Click(object sender, EventArgs e)
        {
            btnCancel_Click(sender,e);
        }

        private void gridViewCompanyMaster_MasterRowEmpty(object sender, MasterRowEmptyEventArgs e)
        {
            //GridView gridView = sender as GridView;
            //CompanyMaster companyMaster = gridView.GetRow(e.RowHandle) as CompanyMaster;
            //if (companyMaster != null)
            //{
            //    e.IsEmpty = _companyMaster.Where(w => w.Type == companyMaster.Id).Count() > 0 ? false : true;
            //}
        }

        private void gridViewCompanyMaster_MasterRowGetChildList(object sender, MasterRowGetChildListEventArgs e)
        {
            //GridView gridView = sender as GridView;
            //CompanyMaster companyMaster = gridView.GetRow(e.RowHandle) as CompanyMaster;
            //if (companyMaster != null)
            //{
            //    e.ChildList = _companyMaster.Where(w => w.Type == companyMaster.Id).ToList();
            //}
        }

        private void gridViewCompanyMaster_MasterRowGetRelationCount(object sender, MasterRowGetRelationCountEventArgs e)
        {
            e.RelationCount = 1;
        }

        private void gridViewCompanyMaster_MasterRowGetRelationName(object sender, MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = "Child";
        }
    }
}