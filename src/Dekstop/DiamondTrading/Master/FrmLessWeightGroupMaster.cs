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

namespace DiamondTrading.Master
{
    public partial class FrmLessWeightGroupMaster : DevExpress.XtraEditors.XtraForm
    {
        private readonly LessWeightMasterRepository _lessWeightMasterRepository;
        private readonly List<LessWeightMaster> _lessWeightMaster;
        private LessWeightMaster _EditedLessWeightMasterSet;
        private List<LessWeightDetails> _lessWeightDetails;
        private Guid _selectedLessGroup;

        public FrmLessWeightGroupMaster(List<LessWeightMaster> lessWeightMasters)
        {
            InitializeComponent();
            _lessWeightMasterRepository = new LessWeightMasterRepository();
            this._lessWeightMaster = lessWeightMasters;
            _lessWeightDetails = new List<LessWeightDetails>();
        }

        public FrmLessWeightGroupMaster(List<LessWeightMaster> lessWeightMasters, Guid SelectedLessGroup)
        {
            InitializeComponent();
            _lessWeightMasterRepository = new LessWeightMasterRepository();
            this._lessWeightMaster = lessWeightMasters;
            _selectedLessGroup = SelectedLessGroup;
            _lessWeightDetails = new List<LessWeightDetails>();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (!CheckValidation())
                    return;

                if (btnSave.Text == AppMessages.GetString(AppMessageID.Save))
                {
                    Guid tempId = Guid.NewGuid();

                    LessWeightDetails lessWeightDetails = new LessWeightDetails();
                    Guid tempDetailId = Guid.NewGuid();
                    for (int i = 0; i < grvLessGroupWeightDetails.RowCount; i++)
                    {
                        lessWeightDetails.Id = tempDetailId;
                        lessWeightDetails.LessWeight = float.Parse(grvLessGroupWeightDetails.GetRowCellValue(i, colLessWeight).ToString());
                        lessWeightDetails.LessWeightId = tempId;
                        lessWeightDetails.MaxWeight = float.Parse(grvLessGroupWeightDetails.GetRowCellValue(i, colMaxWeight).ToString());
                        lessWeightDetails.MinWeight = float.Parse(grvLessGroupWeightDetails.GetRowCellValue(i, colMinWeight).ToString());
                        _lessWeightDetails.Insert(i, lessWeightDetails);
                    }
                   
                    LessWeightMaster lessWeightMaster = new LessWeightMaster
                    {
                        Id = tempId,
                        Name = txtLessWeightGroupName.Text,
                        IsDelete = false,
                        BranchId = Guid.Parse("0A8689F1-5920-4F38-99D0-4B479B2ED043"),
                        CreatedBy = Common.LoginUserID,
                        CreatedDate = DateTime.Now,
                        UpdatedBy = Common.LoginUserID,
                        UpdatedDate = DateTime.Now,
                        LessWeightDetails = _lessWeightDetails
                    };

                    var Result = await _lessWeightMasterRepository.AddLessWeightMaster(lessWeightMaster);

                    if (Result != null)
                    {
                        Reset();
                        MessageBox.Show(AppMessages.GetString(AppMessageID.SaveSuccessfully), "[" + this.Text + "}", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    _EditedLessWeightMasterSet.Name = txtLessWeightGroupName.Text;
                    _EditedLessWeightMasterSet.LessWeightDetails = (List<LessWeightDetails>)grdLessGroupWeightDetails.DataSource;
                    _EditedLessWeightMasterSet.UpdatedBy = Common.LoginUserID;
                    _EditedLessWeightMasterSet.UpdatedDate = DateTime.Now;

                    var Result = await _lessWeightMasterRepository.UpdateLessWeightMaster(_EditedLessWeightMasterSet);

                    if (Result != null)
                    {
                        Reset();
                        MessageBox.Show(AppMessages.GetString(AppMessageID.SaveSuccessfully), "[" + this.Text + "}", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                if (MessageBox.Show(AppMessages.GetString(AppMessageID.AddMoreLessWeightGroupConfirmation), "[" + this.Text + "}", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error : " + Ex.Message.ToString(), "[" + this.Text + "}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private bool CheckValidation()
        {
            if (txtLessWeightGroupName.Text.Trim().Length == 0)
            {
                MessageBox.Show(AppMessages.GetString(AppMessageID.EmptyLessWeightGroupName), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLessWeightGroupName.Focus();
                return false;
            }
            else if (grvLessGroupWeightDetails.RowCount == 0)
            {
                MessageBox.Show(AppMessages.GetString(AppMessageID.EmptyLessWeightGroupItems), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                grvLessGroupWeightDetails.Focus();
                return false;
            }

            LessWeightMaster lessGroupNameExist = _lessWeightMaster.Where(l => l.Name == txtLessWeightGroupName.Text).FirstOrDefault();
            if ((_EditedLessWeightMasterSet == null && lessGroupNameExist != null) || (lessGroupNameExist != null && _EditedLessWeightMasterSet != null && _EditedLessWeightMasterSet.Name != lessGroupNameExist.Name))
            {
                MessageBox.Show(AppMessages.GetString(AppMessageID.LessWeightGroupNameExist), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLessWeightGroupName.Focus();
                return false;
            }

            return true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            txtLessWeightGroupName.Text = "";
            grdLessGroupWeightDetails.DataSource = null;
            LoadDefaultGridColumns();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FrmLessWeightGroupMaster_KeyDown(object sender, KeyEventArgs e)
        {
            Common.MoveToNextControl(sender, e, this);
        }

        private void FrmLessWeightGroupMaster_Load(object sender, EventArgs e)
        {
            LoadDefaultGridColumns();

            if (_selectedLessGroup != Guid.Empty)
            {
                _EditedLessWeightMasterSet = _lessWeightMaster.Where(l => l.Id == _selectedLessGroup).FirstOrDefault();
                if (_EditedLessWeightMasterSet != null)
                {
                    btnSave.Text = AppMessages.GetString(AppMessageID.Update);
                    txtLessWeightGroupName.Text = _EditedLessWeightMasterSet.Name;
                    grdLessGroupWeightDetails.DataSource = _EditedLessWeightMasterSet.LessWeightDetails;
                }
            }
        }

        private void LoadDefaultGridColumns()
        {
            DataTable dtTemp = new DataTable();
            dtTemp.Columns.Add("MinWeight");
            dtTemp.Columns.Add("MaxWeight");
            dtTemp.Columns.Add("LessWeight");
            grdLessGroupWeightDetails.DataSource = dtTemp;
        }

        private void grvLessGroupWeightDetails_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (grvLessGroupWeightDetails.FocusedColumn == colMinWeight)
            {
                if (grvLessGroupWeightDetails.GetRowCellValue(e.RowHandle, colMinWeight) == DBNull.Value)
                {
                    e.ErrorText = AppMessages.GetString(AppMessageID.EmptyMinWeight);
                    grvLessGroupWeightDetails.FocusedRowHandle = e.RowHandle;
                    grvLessGroupWeightDetails.FocusedColumn = colMinWeight;
                    e.Valid = false;
                }
            }
            else if (grvLessGroupWeightDetails.FocusedColumn == colMaxWeight)
            {
                if (grvLessGroupWeightDetails.GetRowCellValue(e.RowHandle, colMaxWeight) == DBNull.Value)
                {
                    e.ErrorText = AppMessages.GetString(AppMessageID.EmptyMaxWeight);
                    grvLessGroupWeightDetails.FocusedRowHandle = e.RowHandle;
                    grvLessGroupWeightDetails.FocusedColumn = colMaxWeight;
                    e.Valid = false;
                }
            }
            else if (grvLessGroupWeightDetails.FocusedColumn == colLessWeight)
            {
                if (grvLessGroupWeightDetails.GetRowCellValue(e.RowHandle, colLessWeight) == DBNull.Value)
                {
                    e.ErrorText = AppMessages.GetString(AppMessageID.EmptyLessWeight);
                    grvLessGroupWeightDetails.FocusedRowHandle = e.RowHandle;
                    grvLessGroupWeightDetails.FocusedColumn = colLessWeight;
                    e.Valid = false;
                }
            }
        }
    }
}