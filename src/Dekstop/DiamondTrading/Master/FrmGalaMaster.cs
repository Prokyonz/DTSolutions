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
    public partial class FrmGalaMaster : DevExpress.XtraEditors.XtraForm
    {
        private readonly GalaMasterRepository _galaMasterRepository;
        private readonly List<GalaMaster> _galaMaster;
        private GalaMaster _EditedGalaMasterSet;
        private string _selectedGalaId;
        public FrmGalaMaster(List<GalaMaster> GalaMasters)
        {
            InitializeComponent();
            _galaMasterRepository = new GalaMasterRepository();
            this._galaMaster = GalaMasters;
        }

        public FrmGalaMaster(List<GalaMaster> GalaMasters, string SelectedGalaId)
        {
            InitializeComponent();
            _galaMasterRepository = new GalaMasterRepository();
            this._galaMaster = GalaMasters;
            _selectedGalaId = SelectedGalaId;
        }

        private void FrmGalaMaster_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty( _selectedGalaId) == false)
            {
                _EditedGalaMasterSet = _galaMaster.Where(s => s.Id == _selectedGalaId).FirstOrDefault();
                if (_EditedGalaMasterSet != null)
                {
                    btnSave.Text = AppMessages.GetString(AppMessageID.Update);
                    txtGalaName.Text = _EditedGalaMasterSet.Name;
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
            _selectedGalaId = Guid.Empty.ToString();
            txtGalaName.Text = "";
            btnSave.Text = AppMessages.GetString(AppMessageID.Save);
            txtGalaName.Focus();
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

                    GalaMaster GalaMaster = new GalaMaster
                    {
                        Id = tempId,
                        Name = txtGalaName.Text,
                        IsDelete = false,
                        CreatedBy = Common.LoginUserID,
                        CreatedDate = DateTime.Now,
                        UpdatedBy = Common.LoginUserID,
                        UpdatedDate = DateTime.Now,
                    };

                    var Result = await _galaMasterRepository.AddGalaAsync(GalaMaster);

                    if (Result != null)
                    {
                        Reset();
                        MessageBox.Show(AppMessages.GetString(AppMessageID.SaveSuccessfully), "[" + this.Text + "}", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    _EditedGalaMasterSet.Name = txtGalaName.Text;
                    _EditedGalaMasterSet.UpdatedBy = Common.LoginUserID;
                    _EditedGalaMasterSet.UpdatedDate = DateTime.Now;

                    var Result = await _galaMasterRepository.UpdateGalaAsync(_EditedGalaMasterSet);

                    if (Result != null)
                    {
                        Reset();
                        MessageBox.Show(AppMessages.GetString(AppMessageID.SaveSuccessfully), "[" + this.Text + "}", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                if (MessageBox.Show(AppMessages.GetString(AppMessageID.AddMoreGalaConfirmation), "[" + this.Text + "}", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
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
            if (txtGalaName.Text.Trim().Length == 0)
            {
                MessageBox.Show(AppMessages.GetString(AppMessageID.EmptyGalaName), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtGalaName.Focus();
                return false;
            }

            GalaMaster GalaNameExist = _galaMaster.Where(s => s.Name == txtGalaName.Text).FirstOrDefault();
            if ((_EditedGalaMasterSet == null && GalaNameExist != null) || (GalaNameExist != null && _EditedGalaMasterSet != null && _EditedGalaMasterSet.Name != GalaNameExist.Name))
            {
                MessageBox.Show(AppMessages.GetString(AppMessageID.GalaNameExist), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtGalaName.Focus();
                return false;
            }

            return true;
        }

        private void FrmGalaMaster_KeyDown(object sender, KeyEventArgs e)
        {
            Common.MoveToNextControl(sender, e, this);
        }
    }
}