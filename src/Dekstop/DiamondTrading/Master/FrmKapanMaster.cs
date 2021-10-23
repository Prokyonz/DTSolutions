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
    public partial class FrmKapanMaster : DevExpress.XtraEditors.XtraForm
    {
        private readonly KapanMasterRepository _kapanMasterRepository;
        private List<KapanMaster> _kapanMaster;
        private KapanMaster _EditedKapanMasterSet;
        private string _selectedKapanId;

        public FrmKapanMaster()
        {
            InitializeComponent();
            _kapanMasterRepository = new KapanMasterRepository();
        }

        public FrmKapanMaster(List<KapanMaster> KapanMasters)
        {
            InitializeComponent();
            _kapanMasterRepository = new KapanMasterRepository();
            this._kapanMaster = KapanMasters;
        }

        public FrmKapanMaster(List<KapanMaster> KapanMasters, string SelectedKapanId)
        {
            InitializeComponent();
            _kapanMasterRepository = new KapanMasterRepository();
            this._kapanMaster = KapanMasters;
            _selectedKapanId = SelectedKapanId;
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

        private async void FrmKapanMaster_Load(object sender, EventArgs e)
        {
            if (_kapanMaster == null)
                _kapanMaster = await _kapanMasterRepository.GetAllKapanAsync();

            if (IsSilentEntry)
                btnReset.Enabled = false;

            if (string.IsNullOrEmpty(_selectedKapanId) == false)
            {
                _EditedKapanMasterSet = _kapanMaster.Where(s => s.Id == _selectedKapanId).FirstOrDefault();
                if (_EditedKapanMasterSet != null)
                {
                    btnSave.Text = AppMessages.GetString(AppMessageID.Update);
                    tglIsActive.IsOn = _EditedKapanMasterSet.IsStatus;
                    txtKapanName.Text = _EditedKapanMasterSet.Name;
                    txtDetails.Text = _EditedKapanMasterSet.Details;
                    if (_EditedKapanMasterSet.CaratLimit > 0)
                    {
                        chkCaratLimit.Checked = true;
                        txtCaratLimit.Text = _EditedKapanMasterSet.CaratLimit.ToString();
                    }
                    else
                    {
                        chkCaratLimit.Checked = false;
                        txtCaratLimit.Text = "";
                    }
                }
            }
            txtKapanName.Focus();
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
            _selectedKapanId = Guid.Empty.ToString();
            txtKapanName.Text = "";
            txtDetails.Text = "";
            chkCaratLimit.Checked = false;
            txtCaratLimit.Text = "";
            tglIsActive.Capture = true;
            btnSave.Text = AppMessages.GetString(AppMessageID.Save);
            txtKapanName.Focus();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (!CheckValidation())
                    return;

                decimal caratLimit = 0;
                if (txtCaratLimit.Text.Trim().Length > 0 && Convert.ToDecimal(txtCaratLimit.Text) > 0)
                    caratLimit = Convert.ToDecimal(txtCaratLimit.Text);

                if (btnSave.Text == AppMessages.GetString(AppMessageID.Save))
                {
                    string tempId = Guid.NewGuid().ToString();

                    KapanMaster KapanMaster = new KapanMaster
                    {
                        Id = tempId,
                        IsStatus = tglIsActive.IsOn,
                        Name = txtKapanName.Text,
                        Details = txtDetails.Text,
                        CaratLimit = caratLimit,
                        IsDelete = false,
                        CreatedBy = Common.LoginUserID,
                        CreatedDate = DateTime.Now,
                        UpdatedBy = Common.LoginUserID,
                        UpdatedDate = DateTime.Now,
                    };

                    var Result = await _kapanMasterRepository.AddKapanAsync(KapanMaster);

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
                    _EditedKapanMasterSet.IsStatus = tglIsActive.IsOn;
                    _EditedKapanMasterSet.Name = txtKapanName.Text;
                    _EditedKapanMasterSet.Details = txtDetails.Text;
                    _EditedKapanMasterSet.CaratLimit = caratLimit;
                    _EditedKapanMasterSet.UpdatedBy = Common.LoginUserID;
                    _EditedKapanMasterSet.UpdatedDate = DateTime.Now;

                    var Result = await _kapanMasterRepository.UpdateKapanAsync(_EditedKapanMasterSet);

                    if (Result != null)
                    {
                        CreatedLedgerID = Result.Id;
                        Reset();
                        MessageBox.Show(AppMessages.GetString(AppMessageID.SaveSuccessfully), "[" + this.Text + "}", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                //if (MessageBox.Show(AppMessages.GetString(AppMessageID.AddMoreKapanConfirmation), "[" + this.Text + "}", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
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
            if (txtKapanName.Text.Trim().Length == 0)
            {
                MessageBox.Show(AppMessages.GetString(AppMessageID.EmptyKapanName), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtKapanName.Focus();
                return false;
            }

            KapanMaster KapanNameExist = _kapanMaster.Where(s => s.Name == txtKapanName.Text).FirstOrDefault();
            if ((_EditedKapanMasterSet == null && KapanNameExist != null) || (KapanNameExist != null && _EditedKapanMasterSet != null && _EditedKapanMasterSet.Name != KapanNameExist.Name))
            {
                MessageBox.Show(AppMessages.GetString(AppMessageID.KapanNameExist), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtKapanName.Focus();
                return false;
            }

            return true;
        }

        private void FrmKapanMaster_KeyDown(object sender, KeyEventArgs e)
        {
            Common.MoveToNextControl(sender, e, this);
        }

        private void chkCaratLimit_CheckedChanged(object sender, EventArgs e)
        {
            grpCaratLimit.Enabled = chkCaratLimit.Enabled;
            if (!chkCaratLimit.Checked)
                txtCaratLimit.Text = "";
        }
    }
}