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
        private readonly CurrencyMasterRepository _currencyMasterRepository;
        private readonly List<CurrencyMaster> _currencyMaster;
        private CurrencyMaster _EditedCurrencyMasterSet;
        private string _selectedCurrencyId;
        public FrmCurrencyMaster(List<CurrencyMaster> CurrencyMasters)
        {
            InitializeComponent();
            _currencyMasterRepository = new CurrencyMasterRepository();
            this._currencyMaster = CurrencyMasters;
        }

        public FrmCurrencyMaster(List<CurrencyMaster> CurrencyMasters, string SelectedCurrencyId)
        {
            InitializeComponent();
            _currencyMasterRepository = new CurrencyMasterRepository();
            this._currencyMaster = CurrencyMasters;
            _selectedCurrencyId = SelectedCurrencyId;
        }

        private void FrmCurrencyMaster_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedCurrencyId) == false)
            {
                _EditedCurrencyMasterSet = _currencyMaster.Where(s => s.Id == _selectedCurrencyId).FirstOrDefault();
                if (_EditedCurrencyMasterSet != null)
                {
                    btnSave.Text = AppMessages.GetString(AppMessageID.Update);
                    txtCurrencyName.Text = _EditedCurrencyMasterSet.Name;
                    txtShortName.Text = _EditedCurrencyMasterSet.ShortName;
                    txtRate.Text = _EditedCurrencyMasterSet.Value.ToString();
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
            _selectedCurrencyId = Guid.Empty.ToString();
            txtCurrencyName.Text = "";
            txtShortName.Text = "";
            txtRate.Text = "";
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
                    string tempId = Guid.NewGuid().ToString();

                    CurrencyMaster CurrencyMaster = new CurrencyMaster
                    {
                        Id = tempId,
                        Name = txtCurrencyName.Text,
                        ShortName = txtShortName.Text,
                        Value = Convert.ToDecimal(txtRate.Text),
                        IsDelete = false,
                        CreatedBy = Common.LoginUserID,
                        CreatedDate = DateTime.Now,
                        UpdatedBy = Common.LoginUserID,
                        UpdatedDate = DateTime.Now,
                    };

                    var Result = await _currencyMasterRepository.AddCurrencyAsync(CurrencyMaster);

                    if (Result != null)
                    {
                        Reset();
                        MessageBox.Show(AppMessages.GetString(AppMessageID.SaveSuccessfully), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    _EditedCurrencyMasterSet.Name = txtCurrencyName.Text;
                    _EditedCurrencyMasterSet.ShortName = txtShortName.Text;
                    _EditedCurrencyMasterSet.Value = Convert.ToDecimal(txtRate.Text);
                    _EditedCurrencyMasterSet.UpdatedBy = Common.LoginUserID;
                    _EditedCurrencyMasterSet.UpdatedDate = DateTime.Now;

                    var Result = await _currencyMasterRepository.UpdateCurrencyAsync(_EditedCurrencyMasterSet);

                    if (Result != null)
                    {
                        Reset();
                        MessageBox.Show(AppMessages.GetString(AppMessageID.SaveSuccessfully), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                if (MessageBox.Show(AppMessages.GetString(AppMessageID.AddMoreCurrencyConfirmation), "[" + this.Text + "]", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
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
            if (txtCurrencyName.Text.Trim().Length == 0)
            {
                MessageBox.Show(AppMessages.GetString(AppMessageID.EmptyCurrencyName), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCurrencyName.Focus();
                return false;
            }
            else if (txtShortName.Text.Trim().Length == 0)
            {
                MessageBox.Show(AppMessages.GetString(AppMessageID.EmptyCurrencyShortName), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtShortName.Focus();
                return false;
            }
            else if (txtRate.Text.Trim().Length == 0)
            {
                MessageBox.Show(AppMessages.GetString(AppMessageID.EmptyCurrencyRate), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRate.Focus();
                return false;
            }

            CurrencyMaster CurrencyNameExist = _currencyMaster.Where(s => s.Name == txtCurrencyName.Text).FirstOrDefault();
            if ((_EditedCurrencyMasterSet == null && CurrencyNameExist != null) || (CurrencyNameExist != null && _EditedCurrencyMasterSet != null && _EditedCurrencyMasterSet.Name != CurrencyNameExist.Name))
            {
                MessageBox.Show(AppMessages.GetString(AppMessageID.CurrencyNameExist), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCurrencyName.Focus();
                return false;
            }

            return true;
        }

        private void FrmCurrencyMaster_KeyDown(object sender, KeyEventArgs e)
        {
            Common.MoveToNextControl(sender, e, this);
        }
    }
}