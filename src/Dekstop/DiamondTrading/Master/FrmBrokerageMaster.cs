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
    public partial class FrmBrokerageMaster : DevExpress.XtraEditors.XtraForm
    {
        private readonly BrokerageMasterRepository _brokerageMasterRepository;
        private List<BrokerageMaster> _brokerageMaster;
        private BrokerageMaster _EditedBrokerageMasterSet;
        private string _selectedBrokerageId;

        public bool IsSilentEntry
        {
            get;
            set;
        }

        public string CreatedBrokerageID
        {
            get;
            private set;
        }

        public FrmBrokerageMaster()
        {
            InitializeComponent();
            _brokerageMasterRepository = new BrokerageMasterRepository();
        }

        public FrmBrokerageMaster(List<BrokerageMaster> BrokerageMasters)
        {
            InitializeComponent();
            _brokerageMasterRepository = new BrokerageMasterRepository();
            this._brokerageMaster = BrokerageMasters;
        }

        public FrmBrokerageMaster(List<BrokerageMaster> BrokerageMasters, string SelectedBrokerageId)
        {
            InitializeComponent();
            _brokerageMasterRepository = new BrokerageMasterRepository();
            this._brokerageMaster = BrokerageMasters;
            _selectedBrokerageId = SelectedBrokerageId;
        }

        private async void FrmBrokerageMaster_Load(object sender, EventArgs e)
        {
            if (_brokerageMaster == null)
                _brokerageMaster = await _brokerageMasterRepository.GetAllBrokerageAsync();

            if (string.IsNullOrEmpty(_selectedBrokerageId) == false)
            {
                _EditedBrokerageMasterSet = _brokerageMaster.Where(s => s.Id == _selectedBrokerageId).FirstOrDefault();
                if (_EditedBrokerageMasterSet != null)
                {
                    btnSave.Text = AppMessages.GetString(AppMessageID.Update);
                    txtBrokerageName.Text = _EditedBrokerageMasterSet.Name;
                    txtPercentage.Text = _EditedBrokerageMasterSet.Percentage.ToString();
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
            _selectedBrokerageId = Guid.Empty.ToString();
            txtBrokerageName.Text = "";
            txtPercentage.Text = "";
            btnSave.Text = AppMessages.GetString(AppMessageID.Save);
            txtBrokerageName.Focus();
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

                    BrokerageMaster BrokerageMaster = new BrokerageMaster
                    {
                        Id = tempId,
                        Name = txtBrokerageName.Text,
                        Percentage = float.Parse(txtPercentage.Text),
                        IsDelete = false,
                        CreatedBy = Common.LoginUserID,
                        CreatedDate = DateTime.Now,
                        UpdatedBy = Common.LoginUserID,
                        UpdatedDate = DateTime.Now,
                    };

                    var Result = await _brokerageMasterRepository.AddBrokerageAsync(BrokerageMaster);

                    if (Result != null)
                    {
                        CreatedBrokerageID = Result.Id;
                        if (!IsSilentEntry)
                        {
                            Reset();
                            MessageBox.Show(AppMessages.GetString(AppMessageID.SaveSuccessfully), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    _EditedBrokerageMasterSet.Name = txtBrokerageName.Text;
                    _EditedBrokerageMasterSet.Percentage = float.Parse(txtPercentage.Text);
                    _EditedBrokerageMasterSet.UpdatedBy = Common.LoginUserID;
                    _EditedBrokerageMasterSet.UpdatedDate = DateTime.Now;

                    var Result = await _brokerageMasterRepository.UpdateBrokerageAsync(_EditedBrokerageMasterSet);

                    if (Result != null)
                    {
                        CreatedBrokerageID = Result.Id;
                        Reset();
                        MessageBox.Show(AppMessages.GetString(AppMessageID.SaveSuccessfully), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                ////if (MessageBox.Show(AppMessages.GetString(AppMessageID.AddMoreBrokerageConfirmation), "[" + this.Text + "]", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
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
            if (txtBrokerageName.Text.Trim().Length == 0)
            {
                MessageBox.Show(AppMessages.GetString(AppMessageID.EmptyBrokerageName), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBrokerageName.Focus();
                return false;
            }

            BrokerageMaster BrokerageNameExist = _brokerageMaster.Where(s => s.Name == txtBrokerageName.Text).FirstOrDefault();
            if ((_EditedBrokerageMasterSet == null && BrokerageNameExist != null) || (BrokerageNameExist != null && _EditedBrokerageMasterSet != null && _EditedBrokerageMasterSet.Name != BrokerageNameExist.Name))
            {
                MessageBox.Show(AppMessages.GetString(AppMessageID.BrokerageNameExist), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBrokerageName.Focus();
                return false;
            }

            return true;
        }

        private void FrmBrokerageMaster_KeyDown(object sender, KeyEventArgs e)
        {
            Common.MoveToNextControl(sender, e, this);
        }
    }
}