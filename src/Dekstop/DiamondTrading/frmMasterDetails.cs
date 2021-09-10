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
        private LessWeightMasterRepository _lessWeightMasterRepository;
        private ShapeMasterRepository _shapeMasterRepository;
        private PurityMasterRepository _purityMasterRepository;
        private List<CompanyMaster> _companyMaster;
        private List<LessWeightMaster> _lessWeightMaster;
        private List<ShapeMaster> _shapeMaster;
        private List<PurityMaster> _purityMaster;
        public FrmMasterDetails()
        {
            InitializeComponent();
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
                //frmLogin frmLogin = new frmLogin();
                //frmLogin.ShowDialog();
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
                Master.FrmPurityMaster frmpurityMaster = new Master.FrmPurityMaster(_purityMaster);
                if (frmpurityMaster.ShowDialog() == DialogResult.OK)
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
                }
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabBranchMaster)
            {
                //frmLogin frmLogin = new frmLogin();
                //frmLogin.ShowDialog();
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabLessWeightGroupMaster)
            {
                _lessWeightMasterRepository = new LessWeightMasterRepository();
                _lessWeightMaster = await _lessWeightMasterRepository.GetLessWeightMasters();
                grdLessGroupWeightMaster.DataSource = _lessWeightMaster;
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabShapeMaster)
            {
                _shapeMasterRepository = new ShapeMasterRepository();
                _shapeMaster = await _shapeMasterRepository.GetAllShapeAsync();
                grdShapeMaster.DataSource = _shapeMaster;
            }
            else if (xtabMasterDetails.SelectedTabPage == xtabPurityMaster)
            {
                _purityMasterRepository = new PurityMasterRepository();
                _purityMaster = await _purityMasterRepository.GetAllPurityAsync();
                grdPurityMaster.DataSource = _purityMaster;
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
                //frmLogin frmLogin = new frmLogin();
                //frmLogin.ShowDialog();
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
                //frmLogin frmLogin = new frmLogin();
                //frmLogin.ShowDialog();
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
                if (MessageBox.Show(string.Format(AppMessages.GetString(AppMessageID.DeletePurityConfirmation), grvShapeMaster.GetFocusedRowCellValue(colPurityName).ToString()), "[" + this.Text + "}", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    var Result = await _purityMasterRepository.DeletePurityAsync(SelectedGuid);

                    MessageBox.Show(AppMessages.GetString(AppMessageID.DeleteSuccessfully));
                    await LoadGridData(true);
                }
            }
        }

        private void grvLessGroupWeightMaster_MasterRowEmpty(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventArgs e)
        {
            //GridView view = sender as GridView;
            //LessWeightMaster lessWeightMaster = view.GetRow(e.RowHandle) as LessWeightMaster;
            //if(lessWeightMaster!=null)
            //{
            //    e.IsEmpty = _lessWeightMaster[e.RowHandle].LessWeightDetails.Any(x => x.LessWeightId == lessWeightMaster.Id);
            //}
        }

        private void grvLessGroupWeightMaster_MasterRowGetChildList(object sender, MasterRowGetChildListEventArgs e)
        {
            //GridView view = sender as GridView;
            //LessWeightMaster lessWeightMaster = view.GetRow(e.RowHandle) as LessWeightMaster;
            //if (lessWeightMaster != null)
            //{
            //    e.ChildList=
            //}
        }
    }
}