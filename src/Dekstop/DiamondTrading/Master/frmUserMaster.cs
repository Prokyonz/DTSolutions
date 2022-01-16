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
    public partial class frmUserMaster : DevExpress.XtraEditors.XtraForm
    {
        private readonly UserMasterRepository _UserMasterRepository;
        private readonly List<UserMaster> _UserMasters;
        private UserMaster _EditedUserMasterSet;
        private string _selectedUser;

        public frmUserMaster(List<UserMaster> UserMasters)
        {
            InitializeComponent();
            _UserMasterRepository = new UserMasterRepository();
            this._UserMasters = UserMasters;
        }

        public frmUserMaster(List<UserMaster> UserMasters,string SelectedUser)
        {
            InitializeComponent();
            _UserMasterRepository = new UserMasterRepository();
            this._UserMasters = UserMasters;
            _selectedUser = SelectedUser;
        }

        private async void frmUserMaster_Load(object sender, EventArgs e)
        {
            await GetListForDepedendeFields();
            
            if (string.IsNullOrEmpty(_selectedUser) == false)
            {
                _EditedUserMasterSet = _UserMasters.Where(c => c.Id == _selectedUser).FirstOrDefault();
                if (_EditedUserMasterSet != null)
                {
                    btnSave.Text = AppMessages.GetString(AppMessageID.Update);
                    tglIsActive.IsOn = _EditedUserMasterSet.IsActive;
                    txtUserCode.Text = _EditedUserMasterSet.UserCode;
                    lueUserType.EditValue = _EditedUserMasterSet.UserType;
                    txtUserName.Text = _EditedUserMasterSet.Name;
                    lueDepartment.EditValue = _EditedUserMasterSet.DepartmentName;
                    lueDesignation.EditValue = _EditedUserMasterSet.Designation;
                    lueBrokerage.EditValue = _EditedUserMasterSet.BrokerageId;
                    txtAddress.Text = _EditedUserMasterSet.Address;
                    txtAddress2.Text = _EditedUserMasterSet.Address2;
                    txtMobileNo.Text = _EditedUserMasterSet.MobileNo;
                    txtHomeNo.Text = _EditedUserMasterSet.HomeNo;
                    txtRefrenceBy.Text = _EditedUserMasterSet.ReferenceBy;
                    txtAadharcardNo.Text = _EditedUserMasterSet.AadharCardNo;
                    dtDateOfBirth.EditValue = _EditedUserMasterSet.DateOfBirth;
                    dtStartDate.EditValue = _EditedUserMasterSet.DateOfJoin;
                    dtEndDate.EditValue = _EditedUserMasterSet.DateOfEnd;
                }
            }
        }

        private async Task GetListForDepedendeFields()
        {
            try
            {
                dtDateOfBirth.EditValue = DateTime.Now;
                dtStartDate.EditValue = DateTime.Now;
                dtEndDate.EditValue = DateTime.Now;

                txtUserCode.Text = "0";
                FillLookUpEdits();

                BrokerageMasterRepository brokerageMasterRepository = new BrokerageMasterRepository();
                var Brokerage = await brokerageMasterRepository.GetAllBrokerageAsync();
                if (Brokerage != null)
                {
                    lueBrokerage.Properties.DataSource = Brokerage;
                    lueBrokerage.Properties.DisplayMember = "Name";
                    lueBrokerage.Properties.ValueMember = "Id";
                }
            }
            catch (Exception Ex)
            {

            }
        }

        private void FillLookUpEdits()
        {
            var UserTypes = UserTypeMaster.GetAllUserType();

            if (UserTypes != null)
            {
                lueUserType.Properties.DataSource = UserTypes;
                lueUserType.Properties.DisplayMember = "Name";
                lueUserType.Properties.ValueMember = "Id";
            }

            var Department = DepartmentMaster.GetAllDepartment();

            if (Department != null)
            {
                lueDepartment.Properties.DataSource = Department;
                lueDepartment.Properties.DisplayMember = "Name";
                lueDepartment.Properties.ValueMember = "Id";
            }

            var Designation = DesignationMaster.GetAllDesignation();

            if (Designation != null)
            {
                lueDesignation.Properties.DataSource = Designation;
                lueDesignation.Properties.DisplayMember = "Name";
                lueDesignation.Properties.ValueMember = "Id";
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
            _selectedUser = Guid.Empty.ToString();
            tglIsActive.IsOn = true;
            lueUserType.EditValue = 0;
            txtUserName.Text = "";
            txtAddress.Text = "";
            txtAddress2.Text = "";
            txtMobileNo.Text = "";
            txtHomeNo.Text = "";
            txtRefrenceBy.Text = "";
            lueUserType.EditValue = 0;
            lueDepartment.EditValue = 0;
            lueDesignation.EditValue = 0;
            lueBrokerage.EditValue = 0;
            btnSave.Text = AppMessages.GetString(AppMessageID.Save);
            await GetListForDepedendeFields();
            lueUserType.Focus();
        }

        private void frmUserMaster_KeyDown(object sender, KeyEventArgs e)
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

                    UserMaster UserMaster = new UserMaster
                    {
                        Id = tempId,
                        IsActive = tglIsActive.IsOn,
                        UserCode = txtUserCode.Text,
                        UserType = Convert.ToInt32(lueUserType.EditValue),
                        Name = txtUserName.Text,
                        DepartmentName = lueDepartment.EditValue.ToString(),
                        Designation = lueDesignation.EditValue.ToString(),
                        BrokerageId = lueBrokerage.EditValue.ToString(),
                        Address = txtAddress.Text,
                        Address2 = txtAddress2.Text,
                        MobileNo = txtMobileNo.Text,
                        HomeNo = txtHomeNo.Text,
                        ReferenceBy = txtRefrenceBy.Text,
                        AadharCardNo = txtAadharcardNo.Text,
                        DateOfBirth = Convert.ToDateTime(dtDateOfBirth.EditValue),
                        DateOfJoin = Convert.ToDateTime(dtStartDate.EditValue),
                        DateOfEnd = Convert.ToDateTime(dtEndDate.EditValue),
                        IsDelete = false,
                        CreatedBy = Common.LoginUserID,
                        CreatedDate = DateTime.Now,
                        UpdatedBy = Common.LoginUserID,
                        UpdatedDate = DateTime.Now,
                    };

                    var Result = await _UserMasterRepository.AddUserAsync(UserMaster);

                    if (Result != null)
                    {
                        Reset();
                        MessageBox.Show(AppMessages.GetString(AppMessageID.SaveSuccessfully), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    _EditedUserMasterSet.IsActive = tglIsActive.IsOn;
                    _EditedUserMasterSet.UserCode = txtUserCode.Text;
                    _EditedUserMasterSet.UserType = Convert.ToInt32(lueUserType.EditValue);
                    _EditedUserMasterSet.Name = txtUserName.Text;
                    _EditedUserMasterSet.DepartmentName = lueDepartment.EditValue.ToString();
                    _EditedUserMasterSet.Designation = lueDesignation.EditValue.ToString();
                    _EditedUserMasterSet.BrokerageId = lueBrokerage.EditValue.ToString();
                    _EditedUserMasterSet.Address = txtAddress.Text;
                    _EditedUserMasterSet.Address2 = txtAddress2.Text;
                    _EditedUserMasterSet.MobileNo = txtMobileNo.Text;
                    _EditedUserMasterSet.HomeNo = txtHomeNo.Text;
                    _EditedUserMasterSet.ReferenceBy = txtRefrenceBy.Text;
                    _EditedUserMasterSet.AadharCardNo = txtAadharcardNo.Text;
                    _EditedUserMasterSet.DateOfBirth = Convert.ToDateTime(dtDateOfBirth.EditValue);
                    _EditedUserMasterSet.DateOfJoin = Convert.ToDateTime(dtStartDate.EditValue);
                    _EditedUserMasterSet.DateOfEnd = Convert.ToDateTime(dtEndDate.EditValue);
                    _EditedUserMasterSet.UpdatedBy = Common.LoginUserID;
                    _EditedUserMasterSet.UpdatedDate = DateTime.Now;


                    var Result = await _UserMasterRepository.UpdateUserAsync(_EditedUserMasterSet);

                    if (Result != null)
                    {
                        Reset();
                        MessageBox.Show(AppMessages.GetString(AppMessageID.SaveSuccessfully), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                if (MessageBox.Show(AppMessages.GetString(AppMessageID.AddMoreCompaniesConfirmation), "["+this.Text+"]", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
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
            if (txtUserName.Text.Trim().Length == 0)
            {
                MessageBox.Show(AppMessages.GetString(AppMessageID.EmptyUserName),"["+this.Text+"]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserName.Focus();
                return false;
            }

            UserMaster UserNameExist = _UserMasters.Where(c => c.Name == txtUserName.Text).FirstOrDefault();
            if((_EditedUserMasterSet == null && UserNameExist != null) || (UserNameExist != null && _EditedUserMasterSet != null && _EditedUserMasterSet.Name != UserNameExist.Name))
            {
                MessageBox.Show(AppMessages.GetString(AppMessageID.UserNameExist), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserName.Focus();
                return false;
            }

            return true;
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tglIsActive_Toggled(object sender, EventArgs e)
        {
            dtEndDate.Enabled = !tglIsActive.IsOn;
            if (dtEndDate.Enabled && Convert.ToDateTime(dtEndDate.EditValue) == DateTime.Today)
                dtEndDate.EditValue = DateTime.Now;
        }
    }
}