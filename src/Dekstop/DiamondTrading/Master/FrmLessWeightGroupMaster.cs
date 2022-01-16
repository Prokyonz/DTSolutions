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
        private string _selectedLessGroup;

        public FrmLessWeightGroupMaster(List<LessWeightMaster> lessWeightMasters)
        {
            InitializeComponent();
            _lessWeightMasterRepository = new LessWeightMasterRepository();
            this._lessWeightMaster = lessWeightMasters;
            _lessWeightDetails = new List<LessWeightDetails>();
        }

        public FrmLessWeightGroupMaster(List<LessWeightMaster> lessWeightMasters, string SelectedLessGroup)
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
                    string tempId = Guid.NewGuid().ToString();

                    LessWeightDetails lessWeightDetails;
                    for (int i = 0; i < grvLessGroupWeightDetails.RowCount; i++)
                    {
                        lessWeightDetails = new LessWeightDetails();
                        lessWeightDetails.Id = Guid.NewGuid().ToString();
                        lessWeightDetails.LessWeight = decimal.Parse(grvLessGroupWeightDetails.GetRowCellValue(i, colLessWeight).ToString());
                        lessWeightDetails.LessWeightId = tempId;
                        lessWeightDetails.MaxWeight = decimal.Parse(grvLessGroupWeightDetails.GetRowCellValue(i, colMaxWeight).ToString());
                        lessWeightDetails.MinWeight = decimal.Parse(grvLessGroupWeightDetails.GetRowCellValue(i, colMinWeight).ToString());
                        _lessWeightDetails.Insert(i, lessWeightDetails);
                    }
                   
                    LessWeightMaster lessWeightMaster = new LessWeightMaster
                    {
                        Id = tempId,
                        Name = txtLessWeightGroupName.Text,
                        IsDelete = false,
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
                        MessageBox.Show(AppMessages.GetString(AppMessageID.SaveSuccessfully), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    var tempLessWeightDetails = (List<LessWeightDetails>)grdLessGroupWeightDetails.DataSource;
                    // remove the reff. of lessweightmaster from all details record before updating them.
                    tempLessWeightDetails.ForEach(x => x.LessWeightMaster = null);

                    _EditedLessWeightMasterSet.Name = txtLessWeightGroupName.Text;
                    _EditedLessWeightMasterSet.LessWeightDetails = tempLessWeightDetails;
                    _EditedLessWeightMasterSet.UpdatedBy = Common.LoginUserID;
                    _EditedLessWeightMasterSet.UpdatedDate = DateTime.Now;

                    var Result = await _lessWeightMasterRepository.UpdateLessWeightMaster(_EditedLessWeightMasterSet);

                    if (Result != null)
                    {
                        Reset();
                        MessageBox.Show(AppMessages.GetString(AppMessageID.SaveSuccessfully), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                if (MessageBox.Show(AppMessages.GetString(AppMessageID.AddMoreLessWeightGroupConfirmation), "[" + this.Text + "]", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                {
                    this.DialogResult = DialogResult.OK;
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
            grdLessGroupWeightDetails.DataSource = dtDefaultGridColumns();
            btnSave.Text = AppMessages.GetString(AppMessageID.Save);
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
            grdLessGroupWeightDetails.DataSource = dtDefaultGridColumns();

            if (string.IsNullOrEmpty(_selectedLessGroup) == false)
            {
                _EditedLessWeightMasterSet = _lessWeightMaster.Where(l => l.Id == _selectedLessGroup).FirstOrDefault();
                if (_EditedLessWeightMasterSet != null)
                {
                    btnSave.Text = AppMessages.GetString(AppMessageID.Update);
                    txtLessWeightGroupName.Text = _EditedLessWeightMasterSet.Name;

                    //DataTable dtTemp = dtDefaultGridColumns();
                    //for(int i=0;i<)

                    grdLessGroupWeightDetails.DataSource = _EditedLessWeightMasterSet.LessWeightDetails.OrderBy(x=>x.MinWeight).ToList();
                }
            }
        }

        private DataTable dtDefaultGridColumns()
        {
            DataTable dtTemp = new DataTable();
            dtTemp.Columns.Add("MinWeight",typeof(decimal));
            dtTemp.Columns.Add("MaxWeight", typeof(decimal));
            dtTemp.Columns.Add("LessWeight", typeof(decimal));
            return dtTemp;
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