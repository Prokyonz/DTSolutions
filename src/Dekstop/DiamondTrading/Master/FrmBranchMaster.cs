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
    public partial class FrmBranchMaster : DevExpress.XtraEditors.XtraForm
    {
        private readonly BranchMasterRepository _branchMasterRepository;
        private readonly List<BranchMaster> _branchMasters;
        private BranchMaster _EditedBranchMasterSet;
        private string _selectedBranch;

        public FrmBranchMaster(List<BranchMaster> BranchMasters)
        {
            InitializeComponent();
            _branchMasterRepository = new BranchMasterRepository();
            this._branchMasters = BranchMasters;
        }

        public FrmBranchMaster(List<BranchMaster> BranchMasters,string SelectedBranch)
        {
            InitializeComponent();
            _branchMasterRepository = new BranchMasterRepository();
            this._branchMasters = BranchMasters;
            _selectedBranch = SelectedBranch;
        }

        private async void frmBranchMaster_Load(object sender, EventArgs e)
        {
            await GetListForDepedendeFiels();
            
            if (string.IsNullOrEmpty(_selectedBranch) == false)
            {
                _EditedBranchMasterSet = _branchMasters.Where(c => c.Id == _selectedBranch).FirstOrDefault();
                if (_EditedBranchMasterSet != null)
                {
                    btnSave.Text = AppMessages.GetString(AppMessageID.Update);
                    lueParentCompany.EditValue = _EditedBranchMasterSet.CompanyId;
                    lueLessWeightGroup.EditValue = _EditedBranchMasterSet.LessWeightId;
                    txtBranchName.Text = _EditedBranchMasterSet.Name;
                    txtAddress.Text = _EditedBranchMasterSet.Address;
                    txtAddress2.Text = _EditedBranchMasterSet.Address2;
                    txtMobileNo.Text = _EditedBranchMasterSet.MobileNo;
                    txtOfficeNo.Text = _EditedBranchMasterSet.OfficeNo;
                    txtNotes.Text = _EditedBranchMasterSet.Details;
                    txtTermsCondition.Text = _EditedBranchMasterSet.TermsCondition;
                    txtGSTNo.Text = _EditedBranchMasterSet.GSTNo;
                    txtPancardNo.Text = _EditedBranchMasterSet.PanCardNo;
                    txtRegistrationNo.Text = _EditedBranchMasterSet.RegistrationNo;
                    txtCVDWeight.Text = _EditedBranchMasterSet.CVDWeight.ToString();
                    txtTipWeight.Text = _EditedBranchMasterSet.TipWeight.ToString();
                }
            }
        }

        private async Task GetListForDepedendeFiels()
        {
            try
            {
                CompanyMasterRepository companyMasterRepository = new CompanyMasterRepository();
                var CompanyList = await companyMasterRepository.GetUserCompanyMappingAsync(Common.LoginUserID);

                if (CompanyList != null)
                {
                    lueParentCompany.Properties.DataSource = CompanyList;
                    lueParentCompany.Properties.DisplayMember = "Name";
                    lueParentCompany.Properties.ValueMember = "Id";
                }

                LessWeightMasterRepository lessWeightMasterRepository = new LessWeightMasterRepository();
                var LessWeightGroupList = await lessWeightMasterRepository.GetLessWeightMasters();

                if (LessWeightGroupList != null)
                {
                    lueLessWeightGroup.Properties.DataSource = LessWeightGroupList;
                    lueLessWeightGroup.Properties.DisplayMember = "Name";
                    lueLessWeightGroup.Properties.ValueMember = "Id";
                }
            }
            catch (Exception Ex)
            {

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

        private async void Reset()
        {
            _selectedBranch = Guid.Empty.ToString();
            lueParentCompany.EditValue = 0;
            lueLessWeightGroup.EditValue = 0;
            txtBranchName.Text = "";
            txtAddress.Text = "";
            txtAddress2.Text = "";
            txtMobileNo.Text = "";
            txtOfficeNo.Text = "";
            txtRegistrationNo.Text = "";
            txtGSTNo.Text = "";
            txtPancardNo.Text = "";
            txtNotes.Text = "";
            txtTermsCondition.Text = "";
            txtCVDWeight.Text = "";
            txtTipWeight.Text = "";
            btnSave.Text = AppMessages.GetString(AppMessageID.Save);
            await GetListForDepedendeFiels();
            lueParentCompany.Focus();
        }

        private void frmBranchMaster_KeyDown(object sender, KeyEventArgs e)
        {
            Common.MoveToNextControl(sender, e, this);
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

                    BranchMaster BranchMaster = new BranchMaster
                    {
                        Id = tempId,
                        CompanyId = lueParentCompany.EditValue.ToString(),
                        LessWeightId = lueLessWeightGroup.EditValue.ToString(),
                        Name = txtBranchName.Text,
                        Address = txtAddress.Text,
                        Address2 = txtAddress2.Text,
                        MobileNo = txtMobileNo.Text,
                        OfficeNo = txtOfficeNo.Text,
                        Details = txtNotes.Text,
                        TermsCondition = txtTermsCondition.Text,
                        GSTNo = txtGSTNo.Text,
                        PanCardNo = txtPancardNo.Text,
                        RegistrationNo = txtRegistrationNo.Text,
                        CVDWeight = Convert.ToDecimal(txtCVDWeight.Text),
                        TipWeight = Convert.ToDecimal(txtTipWeight.Text),
                        IsDelete = false,
                        CreatedBy = Common.LoginUserID,
                        CreatedDate = DateTime.Now,
                        UpdatedBy = Common.LoginUserID,
                        UpdatedDate = DateTime.Now,
                    };

                    var Result = await _branchMasterRepository.AddBranchAsync(BranchMaster);

                    if (Result != null)
                    {
                        Reset();
                        MessageBox.Show(AppMessages.GetString(AppMessageID.SaveSuccessfully), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    _EditedBranchMasterSet.CompanyId = lueParentCompany.EditValue.ToString();
                    _EditedBranchMasterSet.LessWeightId = lueLessWeightGroup.EditValue.ToString();
                    _EditedBranchMasterSet.Name = txtBranchName.Text;
                    _EditedBranchMasterSet.Address = txtAddress.Text;
                    _EditedBranchMasterSet.Address2 = txtAddress2.Text;
                    _EditedBranchMasterSet.MobileNo = txtMobileNo.Text;
                    _EditedBranchMasterSet.OfficeNo = txtOfficeNo.Text;
                    _EditedBranchMasterSet.Details = txtNotes.Text;
                    _EditedBranchMasterSet.TermsCondition = txtTermsCondition.Text;
                    _EditedBranchMasterSet.GSTNo = txtGSTNo.Text;
                    _EditedBranchMasterSet.PanCardNo = txtPancardNo.Text;
                    _EditedBranchMasterSet.RegistrationNo = txtRegistrationNo.Text;
                    _EditedBranchMasterSet.CVDWeight = Convert.ToDecimal(txtCVDWeight.Text);
                    _EditedBranchMasterSet.TipWeight = Convert.ToDecimal(txtTipWeight.Text);
                    _EditedBranchMasterSet.UpdatedBy = Common.LoginUserID;
                    _EditedBranchMasterSet.UpdatedDate = DateTime.Now;

                    var Result = await _branchMasterRepository.UpdateBranchAsync(_EditedBranchMasterSet);

                    if (Result != null)
                    {
                        Reset();
                        MessageBox.Show(AppMessages.GetString(AppMessageID.SaveSuccessfully), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                if (MessageBox.Show(AppMessages.GetString(AppMessageID.AddMoreBranchConfirmation), "["+this.Text+"]", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show("Error : "+Ex.Message.ToString(), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private bool CheckValidation()
        {
            if(lueParentCompany.EditValue == null)
            {
                MessageBox.Show(AppMessages.GetString(AppMessageID.EmptyParentCompanySelection), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lueParentCompany.Focus();
                return false;
            }
            else if (txtBranchName.Text.Trim().Length == 0)
            {
                MessageBox.Show(AppMessages.GetString(AppMessageID.EmptyBranchName),"["+this.Text+"]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBranchName.Focus();
                return false;
            }
            else if (lueLessWeightGroup.EditValue == null)
            {
                MessageBox.Show(AppMessages.GetString(AppMessageID.EmptyLessWeightGroupSelection), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lueLessWeightGroup.Focus();
                return false;
            }

            BranchMaster BranchNameExist = _branchMasters.Where(c => c.Name == txtBranchName.Text && c.CompanyId == lueParentCompany.EditValue.ToString()).FirstOrDefault();
            if((_EditedBranchMasterSet == null && BranchNameExist != null) || (BranchNameExist != null && _EditedBranchMasterSet != null && _EditedBranchMasterSet.Name != BranchNameExist.Name))
            {
                MessageBox.Show(AppMessages.GetString(AppMessageID.BranchNameExist), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBranchName.Focus();
                return false;
            }

            return true;
        }
    }
}