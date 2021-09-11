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
    public partial class FrmNumberMaster : DevExpress.XtraEditors.XtraForm
    {
        private readonly NumberMasterRepository _numberMasterRepository;
        private readonly List<NumberMaster> _numberMaster;
        private NumberMaster _EditedNumberMasterSet;
        private Guid _selectedNumberId;
        public FrmNumberMaster(List<NumberMaster> NumberMasters)
        {
            InitializeComponent();
            _numberMasterRepository = new NumberMasterRepository();
            this._numberMaster = NumberMasters;
        }

        public FrmNumberMaster(List<NumberMaster> NumberMasters, Guid SelectedNumberId)
        {
            InitializeComponent();
            _numberMasterRepository = new NumberMasterRepository();
            this._numberMaster = NumberMasters;
            _selectedNumberId = SelectedNumberId;
        }

        private void FrmNumberMaster_Load(object sender, EventArgs e)
        {
            if (_selectedNumberId != Guid.Empty)
            {
                _EditedNumberMasterSet = _numberMaster.Where(s => s.Id == _selectedNumberId).FirstOrDefault();
                if (_EditedNumberMasterSet != null)
                {
                    btnSave.Text = AppMessages.GetString(AppMessageID.Update);
                    txtNumberName.Text = _EditedNumberMasterSet.Name;
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
            _selectedNumberId = Guid.Empty;
            txtNumberName.Text = "";
            btnSave.Text = AppMessages.GetString(AppMessageID.Save);
            txtNumberName.Focus();
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

                    NumberMaster NumberMaster = new NumberMaster
                    {
                        Id = tempId,
                        Name = txtNumberName.Text,
                        IsDelete = false,
                        CreatedBy = Common.LoginUserID,
                        CreatedDate = DateTime.Now,
                        UpdatedBy = Common.LoginUserID,
                        UpdatedDate = DateTime.Now,
                    };

                    var Result = await _numberMasterRepository.AddNumberAsync(NumberMaster);

                    if (Result != null)
                    {
                        Reset();
                        MessageBox.Show(AppMessages.GetString(AppMessageID.SaveSuccessfully), "[" + this.Text + "}", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    _EditedNumberMasterSet.Name = txtNumberName.Text;
                    _EditedNumberMasterSet.UpdatedBy = Common.LoginUserID;
                    _EditedNumberMasterSet.UpdatedDate = DateTime.Now;

                    var Result = await _numberMasterRepository.UpdateNumberAsync(_EditedNumberMasterSet);

                    if (Result != null)
                    {
                        Reset();
                        MessageBox.Show(AppMessages.GetString(AppMessageID.SaveSuccessfully), "[" + this.Text + "}", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                if (MessageBox.Show(AppMessages.GetString(AppMessageID.AddMoreNumberConfirmation), "[" + this.Text + "}", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
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
            if (txtNumberName.Text.Trim().Length == 0)
            {
                MessageBox.Show(AppMessages.GetString(AppMessageID.EmptyNumberName), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNumberName.Focus();
                return false;
            }

            NumberMaster NumberNameExist = _numberMaster.Where(s => s.Name == txtNumberName.Text).FirstOrDefault();
            if ((_EditedNumberMasterSet == null && NumberNameExist != null) || (NumberNameExist != null && _EditedNumberMasterSet != null && _EditedNumberMasterSet.Name != NumberNameExist.Name))
            {
                MessageBox.Show(AppMessages.GetString(AppMessageID.NumberNameExist), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNumberName.Focus();
                return false;
            }

            return true;
        }

        private void FrmNumberMaster_KeyDown(object sender, KeyEventArgs e)
        {
            Common.MoveToNextControl(sender, e, this);
        }
    }
}