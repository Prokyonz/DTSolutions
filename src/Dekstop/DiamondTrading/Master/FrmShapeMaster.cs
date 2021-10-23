using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EFCore.SQL.Repository;
using Repository.Entities;

namespace DiamondTrading.Master
{
    public partial class FrmShapeMaster : DevExpress.XtraEditors.XtraForm
    {
        private readonly ShapeMasterRepository _shapeMasterRepository;
        private List<ShapeMaster> _shapeMaster;
        private ShapeMaster _EditedShapeMasterSet;
        private string _selectedShapeId;
        public FrmShapeMaster()
        {
            InitializeComponent();
            _shapeMasterRepository = new ShapeMasterRepository();
        }

        public FrmShapeMaster(List<ShapeMaster> shapeMasters)
        {
            InitializeComponent();
            _shapeMasterRepository = new ShapeMasterRepository();
            this._shapeMaster = shapeMasters;
        }

        public FrmShapeMaster(List<ShapeMaster> shapeMasters, string SelectedShapeId)
        {
            InitializeComponent();
            _shapeMasterRepository = new ShapeMasterRepository();
            this._shapeMaster = shapeMasters;
            _selectedShapeId = SelectedShapeId;
        }

        public string CreatedLedgerID
        {
            get;
            private set;
        }

        public bool IsSilentEntry
        {
            get;
            set;
        }

        private async void FrmShapeMaster_Load(object sender, EventArgs e)
        {
            if (_shapeMaster == null)
                _shapeMaster = await _shapeMasterRepository.GetAllShapeAsync();

            if (IsSilentEntry)
                btnReset.Enabled = false;

            if (_selectedShapeId != string.Empty)
            {
                _EditedShapeMasterSet = _shapeMaster.Where(s => s.Id == _selectedShapeId).FirstOrDefault();
                if (_EditedShapeMasterSet != null)
                {
                    btnSave.Text = AppMessages.GetString(AppMessageID.Update);
                    txtShapeName.Text = _EditedShapeMasterSet.Name;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            _selectedShapeId = string.Empty;
            txtShapeName.Text = "";
            btnSave.Text = AppMessages.GetString(AppMessageID.Save);
            txtShapeName.Focus();
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

                    ShapeMaster shapeMaster = new ShapeMaster
                    {
                        Id = tempId,
                        Name = txtShapeName.Text,
                        IsDelete = false,
                        CreatedBy = Common.LoginUserID,
                        CreatedDate = DateTime.Now,
                        UpdatedBy = Common.LoginUserID,
                        UpdatedDate = DateTime.Now,
                    };

                    var Result = await _shapeMasterRepository.AddShapeAsync(shapeMaster);

                    if (Result != null)
                    {
                        CreatedLedgerID = Result.Id;
                        if (!IsSilentEntry)
                        {
                            Reset();
                            MessageBox.Show(AppMessages.GetString(AppMessageID.SaveSuccessfully), "[" + this.Text + "}", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    _EditedShapeMasterSet.Name = txtShapeName.Text;
                    _EditedShapeMasterSet.UpdatedBy = Common.LoginUserID;
                    _EditedShapeMasterSet.UpdatedDate = DateTime.Now;

                    var Result = await _shapeMasterRepository.UpdateShapeAsync(_EditedShapeMasterSet);

                    if (Result != null)
                    {
                        CreatedLedgerID = Result.Id;
                        Reset();
                        MessageBox.Show(AppMessages.GetString(AppMessageID.SaveSuccessfully), "[" + this.Text + "}", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                //if (MessageBox.Show(AppMessages.GetString(AppMessageID.AddMoreShapeConfirmation), "[" + this.Text + "}", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
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
            if (txtShapeName.Text.Trim().Length == 0)
            {
                MessageBox.Show(AppMessages.GetString(AppMessageID.EmptyShapeName), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtShapeName.Focus();
                return false;
            }

            ShapeMaster ShapeNameExist = _shapeMaster.Where(s => s.Name == txtShapeName.Text).FirstOrDefault();
            if ((_EditedShapeMasterSet == null && ShapeNameExist != null) || (ShapeNameExist != null && _EditedShapeMasterSet != null && _EditedShapeMasterSet.Name != ShapeNameExist.Name))
            {
                MessageBox.Show(AppMessages.GetString(AppMessageID.ShapeNameExist), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtShapeName.Focus();
                return false;
            }

            return true;
        }

        private void FrmShapeMaster_KeyDown(object sender, KeyEventArgs e)
        {
            Common.MoveToNextControl(sender, e, this);
        }
    }
}