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
    public partial class FrmMasterDetails : DevExpress.XtraEditors.XtraForm
    {
        private CompanyMasterRepository _companyMasterRepository;
        private BranchMasterRepository _branchMasterRepository;
        private LessWeightMasterRepository _lessWeightMasterRepository;
        private ShapeMasterRepository _shapeMasterRepository;
        private PurityMasterRepository _purityMasterRepository;
        private SizeMasterRepository _sizeMasterRepository;
        private GalaMasterRepository _galaMasterRepository;
        private NumberMasterRepository _numberMasterRepository;

        private List<CompanyMaster> _companyMaster;
        private List<BranchMaster> _branchMaster;
        private List<LessWeightMaster> _lessWeightMaster;
        private List<ShapeMaster> _shapeMaster;
        private List<PurityMaster> _purityMaster;
        private List<SizeMaster> _sizeMaster;
        private List<GalaMaster> _galaMaster;
        private List<NumberMaster> _numberMaster;

        public FrmMasterDetails(string SelectedTabPage)
        {
            InitializeComponent();
            HideAllTabs();
            switch(SelectedTabPage)
            {
                case "CompanyMaster":
                    xtabCompanyMaster.PageVisible = true;
                    xtabMasterDetails.SelectedTabPage = xtabCompanyMaster;
                    break;
                case "BranchMaster":
                    xtabBranchMaster.PageVisible = true;
                    xtabMasterDetails.SelectedTabPage = xtabBranchMaster;
                    break;
                case "LessWeightGroupMaster":
                    xtabLessWeightGroupMaster.PageVisible = true;
                    xtabMasterDetails.SelectedTabPage = xtabLessWeightGroupMaster;
                    break;
                case "ShapeMaster":
                    xtabShapeMaster.PageVisible = true;
                    xtabMasterDetails.SelectedTabPage = xtabShapeMaster;
                    break;
                case "PurityMaster":
                    xtabPurityMaster.PageVisible = true;
                    xtabMasterDetails.SelectedTabPage = xtabPurityMaster;
                    break;
                case "SizeMaster":
                    xtabSizeMaster.PageVisible = true;
                    xtabMasterDetails.SelectedTabPage = xtabSizeMaster;
                    break;
                case "GalaMaster":
                    xtabGalaMaster.PageVisible = true;
                    xtabMasterDetails.SelectedTabPage = xtabGalaMaster;
                    break;
                case "NumberMaster":
                    xtabNumberMaster.PageVisible = true;
                    xtabMasterDetails.SelectedTabPage = xtabNumberMaster;
                    break;
                default:
                    xtabCompanyMaster.PageVisible = true;
                    break;
            }
        }

        private void HideAllTabs()
        {
            xtabCompanyMaster.PageVisible = false;
            xtabBranchMaster.PageVisible = false;
            xtabLessWeightGroupMaster.PageVisible = false;
            xtabShapeMaster.PageVisible = false;
            xtabPurityMaster.PageVisible = false;
            xtabSizeMaster.PageVisible = false;
            xtabGalaMaster.PageVisible = false;
            xtabNumberMaster.PageVisible = false;
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private async void accordianAddBtn_Click(object sender, EventArgs e)
        {
            if (xtabMasterDetails.SelectedTabPage == xtabCompanyMaster)
            {
                Master.FrmCompanyMaster frmcompanymaster = new Master.FrmCompanyMaster(_companyMaster);
                if (frmcompanymaster.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabBranchMaster)
            {
                Master.FrmBranchMaster frmBranchMaster = new Master.FrmBranchMaster(_branchMaster);
                if (frmBranchMaster.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabLessWeightGroupMaster)
            {
                Master.FrmLessWeightGroupMaster frmLessWeightGroupMaster = new Master.FrmLessWeightGroupMaster(_lessWeightMaster);
                if (frmLessWeightGroupMaster.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabShapeMaster)
            {
                Master.FrmShapeMaster frmShapeMaster = new Master.FrmShapeMaster(_shapeMaster);
                if (frmShapeMaster.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabPurityMaster)
            {
                Master.FrmPurityMaster frmPurityMaster = new Master.FrmPurityMaster(_purityMaster);
                if (frmPurityMaster.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabSizeMaster)
            {
                Master.FrmSizeMaster frmSizeMaster = new Master.FrmSizeMaster(_sizeMaster);
                if (frmSizeMaster.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabGalaMaster)
            {
                Master.FrmGalaMaster frmGalaMaster = new Master.FrmGalaMaster(_galaMaster);
                if (frmGalaMaster.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabNumberMaster)
            {
                Master.FrmNumberMaster frmNumberMaster = new Master.FrmNumberMaster(_numberMaster);
                if (frmNumberMaster.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
            }
        }

        private async void FrmMasterDetails_Load(object sender, EventArgs e)
        {
            await LoadGridData(true);
        }

        private async Task LoadGridData(bool IsForceLoad=false)
        {
            if (xtabMasterDetails.SelectedTabPage == xtabCompanyMaster)
            {
                if (IsForceLoad || _companyMaster == null)
                {
                    _companyMasterRepository = new CompanyMasterRepository();
                    _companyMaster = await _companyMasterRepository.GetAllCompanyAsync();
                    tlCompanyMaster.DataSource = _companyMaster;
                    tlCompanyMaster.ExpandAll();

                    //gridControl1.DataSource = _companyMaster.Where(w=>w.Type == null).ToList();
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabBranchMaster)
            {
                if (IsForceLoad || _branchMaster == null)
                {
                    _branchMasterRepository = new BranchMasterRepository();
                    _branchMaster = await _branchMasterRepository.GetAllBranchAsync();
                    grdBranchMaster.DataSource = _branchMaster;
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabLessWeightGroupMaster)
            {
                if (IsForceLoad || _lessWeightMaster == null)
                {
                    _lessWeightMasterRepository = new LessWeightMasterRepository();
                    _lessWeightMaster = await _lessWeightMasterRepository.GetLessWeightMasters();
                    grdLessGroupWeightMaster.DataSource = _lessWeightMaster;
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabShapeMaster)
            {
                if (IsForceLoad || _shapeMaster == null)
                {
                    _shapeMasterRepository = new ShapeMasterRepository();
                    _shapeMaster = await _shapeMasterRepository.GetAllShapeAsync();
                    grdShapeMaster.DataSource = _shapeMaster;
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabPurityMaster)
            {
                if (IsForceLoad || _purityMaster == null)
                {
                    _purityMasterRepository = new PurityMasterRepository();
                    _purityMaster = await _purityMasterRepository.GetAllPurityAsync();
                    grdPurityMaster.DataSource = _purityMaster;
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabSizeMaster)
            {
                if (IsForceLoad || _sizeMaster == null)
                {
                    _sizeMasterRepository = new SizeMasterRepository();
                    _sizeMaster = await _sizeMasterRepository.GetAllSizeAsync();
                    grdSizeMaster.DataSource = _sizeMaster;
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabGalaMaster)
            {
                if (IsForceLoad || _galaMaster == null)
                {
                    _galaMasterRepository = new GalaMasterRepository();
                    _galaMaster = await _galaMasterRepository.GetAllGalaAsync();
                    grdGalaMaster.DataSource = _galaMaster;
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabNumberMaster)
            {
                if (IsForceLoad || _numberMaster == null)
                {
                    _numberMasterRepository = new NumberMasterRepository();
                    _numberMaster = await _numberMasterRepository.GetAllNumberAsync();
                    grdNumberMaster.DataSource = _numberMaster;
                }
            }
        }

        private async void accordionEditBtn_Click(object sender, EventArgs e)
        {
            if (xtabMasterDetails.SelectedTabPage == xtabCompanyMaster)
            {
                Guid SelectedGuid = Guid.Parse(tlCompanyMaster.GetFocusedRowCellValue(Id).ToString());
                Master.FrmCompanyMaster frmcompanymaster = new Master.FrmCompanyMaster(_companyMaster, SelectedGuid);
                if (frmcompanymaster.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabBranchMaster)
            {
                Guid SelectedGuid = Guid.Parse(grvBranchMaster.GetFocusedRowCellValue(colBranchId).ToString());
                Master.FrmBranchMaster frmBranchMaster = new Master.FrmBranchMaster(_branchMaster, SelectedGuid);
                if (frmBranchMaster.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabLessWeightGroupMaster)
            {
                Guid SelectedGuid = Guid.Parse(grvLessGroupWeightMaster.GetFocusedRowCellValue(colLessWeightGroupID).ToString());
                Master.FrmLessWeightGroupMaster frmLessWeightGroupMaster= new Master.FrmLessWeightGroupMaster(_lessWeightMaster, SelectedGuid);
                if (frmLessWeightGroupMaster.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabShapeMaster)
            {
                Guid SelectedGuid = Guid.Parse(grvShapeMaster.GetFocusedRowCellValue(colShapeId).ToString());
                Master.FrmShapeMaster frmShapeMaster = new Master.FrmShapeMaster(_shapeMaster, SelectedGuid);
                if (frmShapeMaster.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabPurityMaster)
            {
                Guid SelectedGuid = Guid.Parse(grvPurityMaster.GetFocusedRowCellValue(colPurityId).ToString());
                Master.FrmPurityMaster frmPurityMaster = new Master.FrmPurityMaster(_purityMaster, SelectedGuid);
                if (frmPurityMaster.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabSizeMaster)
            {
                Guid SelectedGuid = Guid.Parse(grvSizeMaster.GetFocusedRowCellValue(colSizeId).ToString());
                Master.FrmSizeMaster frmSizeMaster = new Master.FrmSizeMaster(_sizeMaster, SelectedGuid);
                if (frmSizeMaster.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabGalaMaster)
            {
                Guid SelectedGuid = Guid.Parse(grvGalaMaster.GetFocusedRowCellValue(colGalaId).ToString());
                Master.FrmGalaMaster frmGalaMaster = new Master.FrmGalaMaster(_galaMaster, SelectedGuid);
                if (frmGalaMaster.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabNumberMaster)
            {
                Guid SelectedGuid = Guid.Parse(grvNumberMaster.GetFocusedRowCellValue(colNumberId).ToString());
                Master.FrmNumberMaster frmNumberMaster = new Master.FrmNumberMaster(_numberMaster, SelectedGuid);
                if (frmNumberMaster.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridData(true);
                }
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
            if (xtabMasterDetails.SelectedTabPage == xtabCompanyMaster)
            {
                Guid SelectedGuid = Guid.Parse(tlCompanyMaster.GetFocusedRowCellValue(Id).ToString());
                if (MessageBox.Show(string.Format(AppMessages.GetString(AppMessageID.DeleteCompanyCofirmation), tlCompanyMaster.GetFocusedRowCellValue(Name).ToString()), "[" + this.Text + "}", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    var Result = await _companyMasterRepository.DeleteCompanyAsync(SelectedGuid);

                    MessageBox.Show(AppMessages.GetString(AppMessageID.DeleteSuccessfully));
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabBranchMaster)
            {
                Guid SelectedGuid = Guid.Parse(grvBranchMaster.GetFocusedRowCellValue(colBranchId).ToString());
                if (MessageBox.Show(string.Format(AppMessages.GetString(AppMessageID.DeleteBranchCofirmation), grvBranchMaster.GetFocusedRowCellValue(colBranchName).ToString()), "[" + this.Text + "}", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    var Result = await _branchMasterRepository.DeleteBranchAsync(SelectedGuid);

                    MessageBox.Show(AppMessages.GetString(AppMessageID.DeleteSuccessfully));
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabLessWeightGroupMaster)
            {
                //Guid SelectedGuid = Guid.Parse(tlCompanyMaster.GetFocusedRowCellValue(Id).ToString());
                //if (MessageBox.Show(string.Format(AppMessages.GetString(AppMessageID.DeleteCompanyCofirmation), tlCompanyMaster.GetFocusedRowCellValue(Name).ToString()), "[" + this.Text + "}", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                //{
                //    var Result = await _companyMasterRepository.DeleteCompanyAsync(SelectedGuid);

                //    MessageBox.Show(AppMessages.GetString(AppMessageID.DeleteSuccessfully));
                //    await LoadGridData(true);
                //}
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabShapeMaster)
            {
                Guid SelectedGuid = Guid.Parse(grvShapeMaster.GetFocusedRowCellValue(colShapeId).ToString());
                if (MessageBox.Show(string.Format(AppMessages.GetString(AppMessageID.DeleteShapeConfirmation), grvShapeMaster.GetFocusedRowCellValue(colShapeName).ToString()), "[" + this.Text + "}", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    var Result = await _shapeMasterRepository.DeleteShapeAsync(SelectedGuid);

                    MessageBox.Show(AppMessages.GetString(AppMessageID.DeleteSuccessfully));
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabPurityMaster)
            {
                Guid SelectedGuid = Guid.Parse(grvPurityMaster.GetFocusedRowCellValue(colPurityId).ToString());
                if (MessageBox.Show(string.Format(AppMessages.GetString(AppMessageID.DeletePurityConfirmation), grvPurityMaster.GetFocusedRowCellValue(colPurityName).ToString()), "[" + this.Text + "}", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    var Result = await _purityMasterRepository.DeletePurityAsync(SelectedGuid);

                    MessageBox.Show(AppMessages.GetString(AppMessageID.DeleteSuccessfully));
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabSizeMaster)
            {
                Guid SelectedGuid = Guid.Parse(grvSizeMaster.GetFocusedRowCellValue(colSizeId).ToString());
                if (MessageBox.Show(string.Format(AppMessages.GetString(AppMessageID.DeleteSizeConfirmation), grvSizeMaster.GetFocusedRowCellValue(colSizeName).ToString()), "[" + this.Text + "}", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    var Result = await _sizeMasterRepository.DeleteSizeAsync(SelectedGuid);

                    MessageBox.Show(AppMessages.GetString(AppMessageID.DeleteSuccessfully));
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabGalaMaster)
            {
                Guid SelectedGuid = Guid.Parse(grvGalaMaster.GetFocusedRowCellValue(colGalaId).ToString());
                if (MessageBox.Show(string.Format(AppMessages.GetString(AppMessageID.DeleteGalaConfirmation), grvGalaMaster.GetFocusedRowCellValue(colGalaName).ToString()), "[" + this.Text + "}", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    var Result = await _galaMasterRepository.DeleteGalaAsync(SelectedGuid);

                    MessageBox.Show(AppMessages.GetString(AppMessageID.DeleteSuccessfully));
                    await LoadGridData(true);
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabNumberMaster)
            {
                Guid SelectedGuid = Guid.Parse(grvNumberMaster.GetFocusedRowCellValue(colNumberId).ToString());
                if (MessageBox.Show(string.Format(AppMessages.GetString(AppMessageID.DeleteNumberConfirmation), grvNumberMaster.GetFocusedRowCellValue(colNumberName).ToString()), "[" + this.Text + "}", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    var Result = await _numberMasterRepository.DeleteNumberAsync(SelectedGuid);

                    MessageBox.Show(AppMessages.GetString(AppMessageID.DeleteSuccessfully));
                    await LoadGridData(true);
                }
            }
        }

        private void grvLessGroupWeightMaster_MasterRowEmpty(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventArgs e)
        {
            GridView grdiView = sender as GridView;
            LessWeightMaster lessWeightMaster = grdiView.GetRow(e.RowHandle) as LessWeightMaster;
            if (lessWeightMaster != null)
            {
                e.IsEmpty = _lessWeightMaster.Where(w => w.Id == lessWeightMaster.Id).Count() > 0 ? false : true;
            }
        }

        private void grvLessGroupWeightMaster_MasterRowGetChildList(object sender, MasterRowGetChildListEventArgs e)
        {
            GridView grdiView = sender as GridView;
            LessWeightMaster lessWeightMaster = grdiView.GetRow(e.RowHandle) as LessWeightMaster;
            if (lessWeightMaster != null)
            {
                e.ChildList = _lessWeightMaster.Where(w => w.Id == lessWeightMaster.Id).FirstOrDefault().LessWeightDetails;
            }
        }

        private void grvLessGroupWeightMaster_MasterRowGetRelationCount(object sender, MasterRowGetRelationCountEventArgs e)
        {
            e.RelationCount = 1;
        }

        private void grvLessGroupWeightMaster_MasterRowGetRelationName(object sender, MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = "grdLessGroupWeightMaster";// grvLessWeightGroupDetailMaster.Name;
        }

        private void gridView1_MasterRowEmpty(object sender, MasterRowEmptyEventArgs e)
        {
            GridView gridView = sender as GridView;
            CompanyMaster companyMaster = gridView.GetRow(e.RowHandle) as CompanyMaster;
            if(companyMaster !=null)
            {
                e.IsEmpty = _companyMaster.Where(w => w.Type == companyMaster.Id).Count() > 0 ? false : true;
            }
        }

        private void gridView1_MasterRowGetChildList(object sender, MasterRowGetChildListEventArgs e)
        {
            GridView gridView = sender as GridView;
            CompanyMaster companyMaster = gridView.GetRow(e.RowHandle) as CompanyMaster;
            if (companyMaster != null)
            {
                e.ChildList = _companyMaster.Where(w => w.Type == companyMaster.Id).ToList();
            }
        }

        private void gridView1_MasterRowGetRelationCount(object sender, MasterRowGetRelationCountEventArgs e)
        {
            e.RelationCount = 1;
        }

        private void gridView1_MasterRowGetRelationName(object sender, MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = "Detail";
        }
    }
}