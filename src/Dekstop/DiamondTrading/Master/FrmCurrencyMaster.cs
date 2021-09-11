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
    public partial class FrmCurrencyMaster : DevExpress.XtraEditors.XtraForm
    {
        private readonly SizeMasterRepository _sizeMasterRepository;
        private readonly List<SizeMaster> _sizeMaster;
        private SizeMaster _EditedSizeMasterSet;
        private Guid _selectedSizeId;
        public FrmCurrencyMaster(List<SizeMaster> SizeMasters)
        {
            InitializeComponent();
            _sizeMasterRepository = new SizeMasterRepository();
            this._sizeMaster = SizeMasters;
        }

        public FrmCurrencyMaster(List<SizeMaster> SizeMasters, Guid SelectedSizeId)
        {
            InitializeComponent();
            _sizeMasterRepository = new SizeMasterRepository();
            this._sizeMaster = SizeMasters;
            _selectedSizeId = SelectedSizeId;
        }

        private void FrmSizeMaster_Load(object sender, EventArgs e)
        {
            if (_selectedSizeId != Guid.Empty)
            {
                _EditedSizeMasterSet = _sizeMaster.Where(s => s.Id == _selectedSizeId).FirstOrDefault();
                if (_EditedSizeMasterSet != null)
                {
                    btnSave.Text = AppMessages.GetString(AppMessageID.Update);
                    txtCurrencyName.Text = _EditedSizeMasterSet.Name;
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
            _selectedSizeId = Guid.Empty;
            txtCurrencyName.Text = "";
            btnSave.Text = AppMessages.GetString(AppMessageID.Save);
            txtCurrencyName.Focus();
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

                    SizeMaster SizeMaster = new SizeMaster
                    {
                        Id = tempId,
                        Name = txtCurrencyName.Text,
                        IsDelete = false,
                        CreatedBy = Common.LoginUserID,
                        CreatedDate = DateTime.Now,
                        UpdatedBy = Common.LoginUserID,
                        UpdatedDate = DateTime.Now,
                    };

                    var Result = await _sizeMasterRepository.AddSizeAsync(SizeMaster);

                    if (Result != null)
                    {
                        Reset();
                        MessageBox.Show(AppMessages.GetString(AppMessageID.SaveSuccessfully), "[" + this.Text + "}", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    _EditedSizeMasterSet.Name = txtCurrencyName.Text;
                    _EditedSizeMasterSet.UpdatedBy = Common.LoginUserID;
                    _EditedSizeMasterSet.UpdatedDate = DateTime.Now;

                    var Result = await _sizeMasterRepository.UpdateSizeAsync(_EditedSizeMasterSet);

                    if (Result != null)
                    {
                        Reset();
                        MessageBox.Show(AppMessages.GetString(AppMessageID.SaveSuccessfully), "[" + this.Text + "}", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                if (MessageBox.Show(AppMessages.GetString(AppMessageID.AddMoreSizeConfirmation), "[" + this.Text + "}", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
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
            if (txtCurrencyName.Text.Trim().Length == 0)
            {
                MessageBox.Show(AppMessages.GetString(AppMessageID.EmptySizeName), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCurrencyName.Focus();
                return false;
            }

            SizeMaster SizeNameExist = _sizeMaster.Where(s => s.Name == txtCurrencyName.Text).FirstOrDefault();
            if ((_EditedSizeMasterSet == null && SizeNameExist != null) || (SizeNameExist != null && _EditedSizeMasterSet != null && _EditedSizeMasterSet.Name != SizeNameExist.Name))
            {
                MessageBox.Show(AppMessages.GetString(AppMessageID.SizeNameExist), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCurrencyName.Focus();
                return false;
            }

            return true;
        }

        private void FrmSizeMaster_KeyDown(object sender, KeyEventArgs e)
        {
            Common.MoveToNextControl(sender, e, this);
        }
    }
}