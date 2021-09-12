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
    public partial class FrmFinancialYearMaster : DevExpress.XtraEditors.XtraForm
    {
        private readonly FinancialYearMasterRepository _financialYearMasterRepository;
        private readonly List<FinancialYearMaster> _financialYearMaster;
        private FinancialYearMaster _EditedFinancialYearMasterSet;
        private Guid _selectedFinancialYearId;
        public FrmFinancialYearMaster(List<FinancialYearMaster> FinancialYearMasters)
        {
            InitializeComponent();
            _financialYearMasterRepository = new FinancialYearMasterRepository();
            this._financialYearMaster = FinancialYearMasters;
        }

        public FrmFinancialYearMaster(List<FinancialYearMaster> FinancialYearMasters, Guid SelectedFinancialYearId)
        {
            InitializeComponent();
            _financialYearMasterRepository = new FinancialYearMasterRepository();
            this._financialYearMaster = FinancialYearMasters;
            _selectedFinancialYearId = SelectedFinancialYearId;
        }

        private void FrmFinancialYearMaster_Load(object sender, EventArgs e)
        {
            dtStartDate.EditValue = DateTime.Now;
            dtEndDate.EditValue = DateTime.Now;

            if (_selectedFinancialYearId != Guid.Empty)
            {
                _EditedFinancialYearMasterSet = _financialYearMaster.Where(s => s.Id == _selectedFinancialYearId).FirstOrDefault();
                if (_EditedFinancialYearMasterSet != null)
                {
                    btnSave.Text = AppMessages.GetString(AppMessageID.Update);
                    txtFinancialYearName.Text = _EditedFinancialYearMasterSet.Name;
                    dtStartDate.EditValue = _EditedFinancialYearMasterSet.StartDate;
                    dtEndDate.EditValue = _EditedFinancialYearMasterSet.EndDate;
                }
            }

            GetTotalDays();
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
            _selectedFinancialYearId = Guid.Empty;
            txtFinancialYearName.Text = "";
            btnSave.Text = AppMessages.GetString(AppMessageID.Save);
            txtFinancialYearName.Focus();
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

                    FinancialYearMaster FinancialYearMaster = new FinancialYearMaster
                    {
                        Id = tempId,
                        Name = txtFinancialYearName.Text,
                        StartDate = Convert.ToDateTime(dtStartDate.EditValue),
                        EndDate = Convert.ToDateTime(dtEndDate.EditValue),
                        IsDelete = false,
                        CreatedBy = Common.LoginUserID,
                        CreatedDate = DateTime.Now,
                        UpdatedBy = Common.LoginUserID,
                        UpdatedDate = DateTime.Now,
                    };

                    var Result = await _financialYearMasterRepository.AddFinancialYearAsync(FinancialYearMaster);

                    if (Result != null)
                    {
                        Reset();
                        MessageBox.Show(AppMessages.GetString(AppMessageID.SaveSuccessfully), "[" + this.Text + "}", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    _EditedFinancialYearMasterSet.Name = txtFinancialYearName.Text;
                    _EditedFinancialYearMasterSet.StartDate = Convert.ToDateTime(dtStartDate.EditValue);
                    _EditedFinancialYearMasterSet.EndDate = Convert.ToDateTime(dtEndDate.EditValue);
                    _EditedFinancialYearMasterSet.UpdatedBy = Common.LoginUserID;
                    _EditedFinancialYearMasterSet.UpdatedDate = DateTime.Now;

                    var Result = await _financialYearMasterRepository.UpdateFinancialYearAsync(_EditedFinancialYearMasterSet);

                    if (Result != null)
                    {
                        Reset();
                        MessageBox.Show(AppMessages.GetString(AppMessageID.SaveSuccessfully), "[" + this.Text + "}", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                if (MessageBox.Show(AppMessages.GetString(AppMessageID.AddMoreFinancialYearConfirmation), "[" + this.Text + "}", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
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
            if (txtFinancialYearName.Text.Trim().Length == 0)
            {
                MessageBox.Show(AppMessages.GetString(AppMessageID.EmptyFinancialYearName), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFinancialYearName.Focus();
                return false;
            }

            FinancialYearMaster FinancialYearNameExist = _financialYearMaster.Where(s => s.Name == txtFinancialYearName.Text).FirstOrDefault();
            if ((_EditedFinancialYearMasterSet == null && FinancialYearNameExist != null) || (FinancialYearNameExist != null && _EditedFinancialYearMasterSet != null && _EditedFinancialYearMasterSet.Name != FinancialYearNameExist.Name))
            {
                MessageBox.Show(AppMessages.GetString(AppMessageID.FinancialYearNameExist), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFinancialYearName.Focus();
                return false;
            }

            return true;
        }

        private void FrmFinancialYearMaster_KeyDown(object sender, KeyEventArgs e)
        {
            Common.MoveToNextControl(sender, e, this);
        }

        private void GetTotalDays()
        {
            TimeSpan ts = Convert.ToDateTime(dtEndDate.EditValue).Subtract(Convert.ToDateTime(dtStartDate.EditValue));
            lblTotalDays.Text =  ts.Days.ToString();
        }

        private void dtEndDate_EditValueChanged(object sender, EventArgs e)
        {
            GetTotalDays();
        }

        private void dtStartDate_EditValueChanged(object sender, EventArgs e)
        {
            GetTotalDays();
        }
    }
}