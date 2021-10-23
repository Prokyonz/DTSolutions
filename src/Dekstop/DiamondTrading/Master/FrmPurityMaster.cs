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
    public partial class FrmPurityMaster : DevExpress.XtraEditors.XtraForm
    {
        private readonly PurityMasterRepository _purityMasterRepository;
        private List<PurityMaster> _purityMaster;
        private PurityMaster _EditedPurityMasterSet;
        private string _selectedPurityId;

        public FrmPurityMaster()
        {
            InitializeComponent();
            _purityMasterRepository = new PurityMasterRepository();
        }

        public FrmPurityMaster(List<PurityMaster> PurityMasters)
        {
            InitializeComponent();
            _purityMasterRepository = new PurityMasterRepository();
            this._purityMaster = PurityMasters;
        }

        public FrmPurityMaster(List<PurityMaster> PurityMasters, string SelectedPurityId)
        {
            InitializeComponent();
            _purityMasterRepository = new PurityMasterRepository();
            this._purityMaster = PurityMasters;
            _selectedPurityId = SelectedPurityId;
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

        private async void FrmPurityMaster_Load(object sender, EventArgs e)
        {
            if (_purityMaster == null)
                _purityMaster = await _purityMasterRepository.GetAllPurityAsync();

            if (IsSilentEntry)
                btnReset.Enabled = false;

            if (string.IsNullOrEmpty(_selectedPurityId) == false)
            {
                _EditedPurityMasterSet = _purityMaster.Where(s => s.Id == _selectedPurityId).FirstOrDefault();
                if (_EditedPurityMasterSet != null)
                {
                    btnSave.Text = AppMessages.GetString(AppMessageID.Update);
                    txtPurityName.Text = _EditedPurityMasterSet.Name;
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
            _selectedPurityId = Guid.Empty.ToString();
            txtPurityName.Text = "";
            btnSave.Text = AppMessages.GetString(AppMessageID.Save);
            txtPurityName.Focus();
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

                    PurityMaster PurityMaster = new PurityMaster
                    {
                        Id = tempId,
                        Name = txtPurityName.Text,
                        IsDelete = false,
                        CreatedBy = Common.LoginUserID,
                        CreatedDate = DateTime.Now,
                        UpdatedBy = Common.LoginUserID,
                        UpdatedDate = DateTime.Now,
                    };

                    var Result = await _purityMasterRepository.AddPurityAsync(PurityMaster);

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
                    _EditedPurityMasterSet.Name = txtPurityName.Text;
                    _EditedPurityMasterSet.UpdatedBy = Common.LoginUserID;
                    _EditedPurityMasterSet.UpdatedDate = DateTime.Now;

                    var Result = await _purityMasterRepository.UpdatePurityAsync(_EditedPurityMasterSet);

                    if (Result != null)
                    {
                        CreatedLedgerID = Result.Id;
                        Reset();
                        MessageBox.Show(AppMessages.GetString(AppMessageID.SaveSuccessfully), "[" + this.Text + "}", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                //if (MessageBox.Show(AppMessages.GetString(AppMessageID.AddMorePurityConfirmation), "[" + this.Text + "}", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
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
            if (txtPurityName.Text.Trim().Length == 0)
            {
                MessageBox.Show(AppMessages.GetString(AppMessageID.EmptyPurityName), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPurityName.Focus();
                return false;
            }

            PurityMaster PurityNameExist = _purityMaster.Where(s => s.Name == txtPurityName.Text).FirstOrDefault();
            if ((_EditedPurityMasterSet == null && PurityNameExist != null) || (PurityNameExist != null && _EditedPurityMasterSet != null && _EditedPurityMasterSet.Name != PurityNameExist.Name))
            {
                MessageBox.Show(AppMessages.GetString(AppMessageID.PurityNameExist), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPurityName.Focus();
                return false;
            }

            return true;
        }

        private void FrmPurityMaster_KeyDown(object sender, KeyEventArgs e)
        {
            Common.MoveToNextControl(sender, e, this);
        }
    }
}