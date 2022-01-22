using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using EFCore.SQL.Repository;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            txtUserName.ReadOnly = false;

            await GetListForDepedendeFields();

            await GetPermissions();

            if (string.IsNullOrEmpty(_selectedUser) == false)
            {
                _EditedUserMasterSet = _UserMasters.Where(c => c.Id == _selectedUser).FirstOrDefault();
                if (_EditedUserMasterSet != null)
                {
                    txtUserName.ReadOnly = true;

                    btnSave.Text = AppMessages.GetString(AppMessageID.Update);
                    txtName.Text = _EditedUserMasterSet.Name;
                    txtUserName.Text = _EditedUserMasterSet.UserName;
                    //lueDepartment.EditValue = _EditedUserMasterSet.DepartmentName;
                    //lueDesignation.EditValue = _EditedUserMasterSet.Designation;
                    //lueBrokerage.EditValue = _EditedUserMasterSet.BrokerageId;
                    txtAddress.Text = _EditedUserMasterSet.Address;
                    txtAddress2.Text = _EditedUserMasterSet.Address2;
                    txtMobileNo.Text = _EditedUserMasterSet.MobileNo;
                    txtHomeNo.Text = _EditedUserMasterSet.HomeNo;

                    var permissionList = await _UserMasterRepository.GetUserPermissions(_EditedUserMasterSet.Id);


                    if (permissionList != null)
                    {
                        for (int i = 0; i < permissionList.Count; i++)
                        {
                            grvPermissionDetails.SelectRow(grvPermissionDetails.LocateByValue("Id", permissionList[i].PermissionMasterId));
                        }
                    }
                    //txtRefrenceBy.Text = _EditedUserMasterSet.ReferenceBy;
                    //txtAadharcardNo.Text = _EditedUserMasterSet.AadharCardNo;
                    //dtDateOfBirth.EditValue = _EditedUserMasterSet.DateOfBirth;
                    //dtStartDate.EditValue = _EditedUserMasterSet.DateOfJoin;
                    //dtEndDate.EditValue = _EditedUserMasterSet.DateOfEnd;
                }
            }            
        }

        private async Task GetListForDepedendeFields()
        {
            try
            {
                //dtDateOfBirth.EditValue = DateTime.Now;
                //dtStartDate.EditValue = DateTime.Now;
                //dtEndDate.EditValue = DateTime.Now;

                FillLookUpEdits();

                //BrokerageMasterRepository brokerageMasterRepository = new BrokerageMasterRepository();
                //var Brokerage = await brokerageMasterRepository.GetAllBrokerageAsync();
                //if (Brokerage != null)
                //{
                //    lueBrokerage.Properties.DataSource = Brokerage;
                //    lueBrokerage.Properties.DisplayMember = "Name";
                //    lueBrokerage.Properties.ValueMember = "Id";
                //}
            }
            catch (Exception Ex)
            {

            }
        }
            //var Department = DepartmentMaster.GetAllDepartment();

            //if (Department != null)
            //{
            //    lueDepartment.Properties.DataSource = Department;
            //    lueDepartment.Properties.DisplayMember = "Name";
            //    lueDepartment.Properties.ValueMember = "Id";
            //}

            //var Designation = DesignationMaster.GetAllDesignation();

            //if (Designation != null)
            //{
            //    lueDesignation.Properties.DataSource = Designation;
            //    lueDesignation.Properties.DisplayMember = "Name";
            //    lueDesignation.Properties.ValueMember = "Id";
            //}
        private void FillLookUpEdits()
        {

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
            txtName.Text = "";
            txtUserName.Text = "";
            txtAddress.Text = "";
            txtAddress2.Text = "";
            txtMobileNo.Text = "";
            txtHomeNo.Text = "";
            //txtRefrenceBy.Text = "";
            //lueDepartment.EditValue = 0;
            //lueDesignation.EditValue = 0;
            //lueBrokerage.EditValue = 0;
            btnSave.Text = AppMessages.GetString(AppMessageID.Save);
            await GetListForDepedendeFields();
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
                        IsActive = true,
                        UserCode = "",
                        UserType = 1,
                        Name = txtName.Text,
                        UserName = txtUserName.Text,
                        Password = txtPassword.Text,
                        DepartmentName = "",// lueDepartment.EditValue.ToString(),
                        Designation = "",//lueDesignation.EditValue.ToString(),
                        BrokerageId = "",//lueBrokerage.EditValue.ToString(),
                        Address = txtAddress.Text,
                        Address2 = txtAddress2.Text,
                        MobileNo = txtMobileNo.Text,
                        HomeNo = txtHomeNo.Text,
                        ReferenceBy = "", //txtRefrenceBy.Text,
                        AadharCardNo = "",//txtAadharcardNo.Text,
                        DateOfBirth = DateTime.Now,
                        DateOfJoin = DateTime.Now,
                        DateOfEnd = DateTime.Now,
                        IsDelete = false,
                        CreatedBy = Common.LoginUserID,
                        CreatedDate = DateTime.Now,
                        UpdatedBy = Common.LoginUserID,
                        UpdatedDate = DateTime.Now,
                        UserPermissionChilds = GetSelectedPermissions(tempId)
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

                    if (txtPassword.Text.Length > 0)
                    {
                        if(txtPassword.Text == txtConfrmPassword.Text)
                        {
                            _EditedUserMasterSet.Password = txtPassword.Text;
                        } else
                        {
                            MessageBox.Show(AppMessages.GetString(AppMessageID.PasswordNotMatched), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtPassword.Focus();
                        }
                        
                    }
                    _EditedUserMasterSet.Name = txtName.Text;
                    //_EditedUserMasterSet.DepartmentName = lueDepartment.EditValue.ToString();
                    //_EditedUserMasterSet.Designation = lueDesignation.EditValue.ToString();
                    //_EditedUserMasterSet.BrokerageId = lueBrokerage.EditValue.ToString();
                    //_EditedUserMasterSet.Address = txtAddress.Text;
                    _EditedUserMasterSet.Address2 = txtAddress2.Text;
                    _EditedUserMasterSet.MobileNo = txtMobileNo.Text;
                    _EditedUserMasterSet.HomeNo = txtHomeNo.Text;
                    _EditedUserMasterSet.Address = txtAddress.Text;
                    //_EditedUserMasterSet.ReferenceBy = txtRefrenceBy.Text;
                    //_EditedUserMasterSet.AadharCardNo = txtAadharcardNo.Text;
                    //_EditedUserMasterSet.DateOfBirth = Convert.ToDateTime(dtDateOfBirth.EditValue);
                    //_EditedUserMasterSet.DateOfJoin = Convert.ToDateTime(dtStartDate.EditValue);
                    //_EditedUserMasterSet.DateOfEnd = Convert.ToDateTime(dtEndDate.EditValue);
                    //_EditedUserMasterSet.UpdatedBy = Common.LoginUserID;
                    _EditedUserMasterSet.UpdatedDate = DateTime.Now;
                    _EditedUserMasterSet.UserPermissionChilds = GetSelectedPermissions(_EditedUserMasterSet.Id);


                    var Result = await _UserMasterRepository.UpdateUserAsync(_EditedUserMasterSet);

                    if (Result != null)
                    {
                        Reset();
                        MessageBox.Show(AppMessages.GetString(AppMessageID.SaveSuccessfully), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                if (MessageBox.Show(AppMessages.GetString(AppMessageID.AddMoreCompaniesConfirmation), "[" + this.Text + "]", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error : "+Ex.Message.ToString(), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private List<UserPermissionChild> GetSelectedPermissions(string UserId)
        {
            List<UserPermissionChild> userPermissionDetails = new List<UserPermissionChild>();
            if (grvPermissionDetails.GetSelectedRows().Count() > 0)
            {                
                Int32[] selectedRowHandles = grvPermissionDetails.GetSelectedRows();
                UserPermissionChild userPermission = null;
                for (int i = 0; i < selectedRowHandles.Length; i++)
                {
                    userPermission = new UserPermissionChild();
                    userPermission.Id = Guid.NewGuid().ToString();
                    userPermission.UserId = UserId;
                    userPermission.PermissionMasterId = grvPermissionDetails.GetRowCellValue(selectedRowHandles[i], "Id").ToString();
                    userPermission.Status = true;
                    userPermissionDetails.Add(userPermission);
                }
            }
            return userPermissionDetails;
        }

        private bool CheckValidation()
        {
            if(txtPassword.Text != txtConfrmPassword.Text)
            {
                MessageBox.Show(AppMessages.GetString(AppMessageID.PasswordNotMatched), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return false;
            }
            if (txtName.Text.Trim().Length == 0)
            {
                MessageBox.Show(AppMessages.GetString(AppMessageID.EmptyUserName),"["+this.Text+"]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return false;
            }

            UserMaster UserNameExist = _UserMasters.Where(c => c.Name == txtName.Text).FirstOrDefault();
            if((_EditedUserMasterSet == null && UserNameExist != null) || (UserNameExist != null && _EditedUserMasterSet != null && _EditedUserMasterSet.Name != UserNameExist.Name))
            {
                MessageBox.Show(AppMessages.GetString(AppMessageID.UserNameExist), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return false;
            }

            return true;
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9]");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            } else
            {
                e.Handled = false;
            }
        }

        private async Task GetPermissions()
        {
            grdPermissionDetails.DataSource = await _UserMasterRepository.GetAllPermissions();
        }
    }
}