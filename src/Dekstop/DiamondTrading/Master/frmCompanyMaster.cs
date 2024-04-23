using DevExpress.XtraEditors;
using EFCore.SQL.Repository;
using Microsoft.Win32;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace DiamondTrading.Master
{
    public partial class FrmCompanyMaster : DevExpress.XtraEditors.XtraForm
    {
        private readonly CompanyMasterRepository _companyMasterRepository;
        private readonly UserMasterRepository _userMasterRepository;
        private readonly List<CompanyMaster> _companyMasters;
        private CompanyMaster _EditedCompnayMasterSet;
        private string _selectedCompany;
        DataTable dtCompanyPermissionDetails = new DataTable();

        public FrmCompanyMaster(List<CompanyMaster> companyMasters)
        {
            InitializeComponent();
            _companyMasterRepository = new CompanyMasterRepository();
            _userMasterRepository = new UserMasterRepository();
            this._companyMasters = companyMasters;
        }

        public FrmCompanyMaster(List<CompanyMaster> companyMasters,string SelectedCompany)
        {
            InitializeComponent();
            _companyMasterRepository = new CompanyMasterRepository();
            this._companyMasters = companyMasters;
            _selectedCompany = SelectedCompany;
        }

        private async void frmCompanyMaster_Load(object sender, EventArgs e)
        {
            GetCompanyPermissionDefaultDetails();

            await GetParentCompanyList();

            if (string.IsNullOrEmpty(_selectedCompany) == false)
            {
                _EditedCompnayMasterSet = _companyMasters.Where(c => c.Id == _selectedCompany).FirstOrDefault();
                if (_EditedCompnayMasterSet != null)
                {
                    btnSave.Text = AppMessages.GetString(AppMessageID.Update);
                    lueCompanyType.EditValue = _EditedCompnayMasterSet.Type == null ? Common.DefaultGuid : _EditedCompnayMasterSet.Type;
                    txtCompanyName.Text = _EditedCompnayMasterSet.Name;
                    txtAddress.Text = _EditedCompnayMasterSet.Address;
                    txtAddress2.Text = _EditedCompnayMasterSet.Address2;
                    txtMobileNo.Text = _EditedCompnayMasterSet.MobileNo;
                    txtOfficeNo.Text = _EditedCompnayMasterSet.OfficeNo;
                    txtNotes.Text = _EditedCompnayMasterSet.Details;
                    txtTermsCondition.Text = _EditedCompnayMasterSet.TermsCondition;
                    txtGSTNo.Text = _EditedCompnayMasterSet.GSTNo;
                    txtPancardNo.Text = _EditedCompnayMasterSet.PanCardNo;
                    txtRegistrationNo.Text = _EditedCompnayMasterSet.RegistrationNo;

                    if (_EditedCompnayMasterSet.CompanyOptions.Count > 0)
                    {
                        for (int i = 0; i < grvCompanyAccessPermission.RowCount; i++)
                        {
                            string PermissionGroupName = grvCompanyAccessPermission.GetRowCellValue(i, colPermissionGroup).ToString();
                            string PermissionName = grvCompanyAccessPermission.GetRowCellValue(i, colPermissionName).ToString();

                            var result = _EditedCompnayMasterSet.CompanyOptions.Where(x => x.PermissionGroupName == PermissionGroupName && x.PermissionName == PermissionName).FirstOrDefault();
                            if(result != null)
                            {
                                grvCompanyAccessPermission.SetRowCellValue(i, colPurchaseIsCheck, result.IsPurchase);
                                grvCompanyAccessPermission.SetRowCellValue(i, colSaleIsCheck, result.IsSales);
                                grvCompanyAccessPermission.SetRowCellValue(i, colOtherIsCheck, result.IsOther);
                            }
                        }
                    }
                }
            }
        }

        private void GetCompanyPermissionDefaultDetails()
        {
            dtCompanyPermissionDetails = new DataTable();
            dtCompanyPermissionDetails.Columns.Add("PermissionGroup", typeof(string));
            dtCompanyPermissionDetails.Columns.Add("Permission", typeof(string));
            dtCompanyPermissionDetails.Columns.Add("DisplayName", typeof(string));
            dtCompanyPermissionDetails.Columns.Add("Purchase", typeof(bool)); 
            dtCompanyPermissionDetails.Columns.Add("Sale", typeof(bool));
            dtCompanyPermissionDetails.Columns.Add("Other", typeof(bool));

            dtCompanyPermissionDetails.Rows.Add("PurchaseSale", "Shape", "Shape", false, false, false);
            dtCompanyPermissionDetails.Rows.Add("PurchaseSale", "Purity", "Purity", false, false, false);
            dtCompanyPermissionDetails.Rows.Add("PurchaseSale", "Tip", "Tip", false, false, false);
            dtCompanyPermissionDetails.Rows.Add("PurchaseSale", "CVD", "CVD", false, false, false);
            dtCompanyPermissionDetails.Rows.Add("PurchaseSale", "(-) Cts", "(-) Cts", false, false, false);
            dtCompanyPermissionDetails.Rows.Add("PurchaseSale", "CVD A", "CVD A", false, false, false);
            dtCompanyPermissionDetails.Rows.Add("PurchaseSale", "Number", "Number", false, false, false);
            //dtCompanyPermissionDetails.Rows.Add("Sale", "Category", "Category", false, false, false);
            dtCompanyPermissionDetails.Rows.Add("Sale", "Kapan", "Kapan", false, false, false);
            //dtCompanyPermissionDetails.Rows.Add("Sale", "Charni Size", "Charni Size", false, false, false);
            //dtCompanyPermissionDetails.Rows.Add("Sale", "Gala Size", "Gala Size", false, false, false);
            dtCompanyPermissionDetails.Rows.Add("Other", "AllowProcess", "Allow Process", false, false, false);
            dtCompanyPermissionDetails.Rows.Add("Other", "KapanLagad", "Kapan Lagad", false, false, false);
            dtCompanyPermissionDetails.Rows.Add("Other", "GSTBillPrint", "GST Bill Print", false, false, false);

            grdCompanyAccessPermission.DataSource = dtCompanyPermissionDetails;
        }

        private async Task GetParentCompanyList()
        {
            try
            {
                var CompanyList = await _companyMasterRepository.GetParentCompanyAsync();
                CompanyMaster companyMaster = new CompanyMaster
                {
                    Id = Common.DefaultGuid,
                    Name = AppMessages.GetString(AppMessageID.NewCompany)
                };
                CompanyList.Insert(0, companyMaster);

                if (CompanyList != null)
                {
                    lueCompanyType.Properties.DataSource = CompanyList;
                    lueCompanyType.Properties.DisplayMember = "Name";
                    lueCompanyType.Properties.ValueMember = "Id";
                    lueCompanyType.EditValue = Common.DefaultGuid;
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
            _selectedCompany = Guid.Empty.ToString();
            lueCompanyType.EditValue = 0;
            txtCompanyName.Text = "";
            txtAddress.Text = "";
            txtAddress2.Text = "";
            txtMobileNo.Text = "";
            txtOfficeNo.Text = "";
            txtRegistrationNo.Text = "";
            txtGSTNo.Text = "";
            txtPancardNo.Text = "";
            txtNotes.Text = "";
            txtTermsCondition.Text = "";
            btnSave.Text = AppMessages.GetString(AppMessageID.Save);
            await GetParentCompanyList();
            lueCompanyType.Focus();
        }

        private void frmCompanyMaster_KeyDown(object sender, KeyEventArgs e)
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

                    List<CompanyOptions> companyOptionsList = new List<CompanyOptions>();
                    CompanyOptions companyOptions = new CompanyOptions();
                    for (int i = 0; i < grvCompanyAccessPermission.RowCount; i++)
                    {
                        companyOptions = new CompanyOptions();
                        companyOptions.Id = Guid.NewGuid().ToString();
                        companyOptions.CompanyMasterId = tempId;
                        companyOptions.PermissionGroupName = grvCompanyAccessPermission.GetRowCellValue(i, colPermissionGroup).ToString();
                        companyOptions.PermissionName = grvCompanyAccessPermission.GetRowCellValue(i, colPermissionName).ToString();
                        companyOptions.IsPurchase = Convert.ToBoolean(grvCompanyAccessPermission.GetRowCellValue(i, colPurchaseIsCheck));
                        companyOptions.IsSales = Convert.ToBoolean(grvCompanyAccessPermission.GetRowCellValue(i, colSaleIsCheck));
                        companyOptions.IsOther= Convert.ToBoolean(grvCompanyAccessPermission.GetRowCellValue(i, colOtherIsCheck));
                        companyOptions.PermissionStatus = true;
                        companyOptions.CreatedBy = Common.LoginUserID;
                        companyOptions.CreatedDate = DateTime.Now;
                        companyOptions.UpdatedBy = Common.LoginUserID;
                        companyOptions.UpdatedDate = DateTime.Now;
                        companyOptionsList.Add(companyOptions);
                    }

                    CompanyMaster companyMaster = new CompanyMaster
                    {
                        Id = tempId,
                        Type = lueCompanyType.EditValue.ToString(),
                        Name = txtCompanyName.Text,
                        Address = txtAddress.Text,
                        Address2 = txtAddress2.Text,
                        MobileNo = txtMobileNo.Text,
                        OfficeNo = txtOfficeNo.Text,
                        Details = txtNotes.Text,
                        TermsCondition = txtTermsCondition.Text,
                        GSTNo = txtGSTNo.Text,
                        PanCardNo = txtPancardNo.Text,
                        RegistrationNo = txtRegistrationNo.Text,
                        IsDelete = false,
                        CreatedBy = Common.LoginUserID,
                        CreatedDate = DateTime.Now,
                        UpdatedBy = Common.LoginUserID,
                        UpdatedDate = DateTime.Now,
                        CompanyOptions = companyOptionsList,
                    };

                    if (companyMaster.Type == Common.DefaultGuid)
                        companyMaster.Type = null;

                    var Result = await _companyMasterRepository.AddCompanyAsync(companyMaster);

                    if (Result != null)
                    {
                        //Update crrent user company assignment
                        var user = await _userMasterRepository.GetUserById(Common.LoginUserID.ToString());
                        
                        user.UserCompanyMappings.Add(new UserCompanyMapping
                        {
                            Id = Guid.NewGuid().ToString(),
                            UserId = user.Id,
                            CompanyId = Result.Id,
                            CreatedDate = DateTime.Now,
                            UpdatedDate = DateTime.Now,
                            CreatedBy = Common.LoginUserID,
                            UpdatedBy = Common.LoginUserID
                        });

                        await _userMasterRepository.UpdateUserAsync(user);

                        // Assign company to admin
                        if(user.Name.ToString() != "admin")
                        {
                            var details = await _userMasterRepository.GetUserByName("admin");

                            details.UserCompanyMappings.Add(new UserCompanyMapping
                            {
                                Id = Guid.NewGuid().ToString(),
                                UserId = details.Id,
                                CompanyId = Result.Id,
                                CreatedDate = DateTime.Now,
                                UpdatedDate = DateTime.Now,
                                CreatedBy = Common.LoginUserID,
                                UpdatedBy = Common.LoginUserID
                            });

                            await _userMasterRepository.UpdateUserAsync(details);
                        }

                        Reset();
                        MessageBox.Show(AppMessages.GetString(AppMessageID.SaveSuccessfully), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                else
                {
                    List<CompanyOptions> companyOptionsList = new List<CompanyOptions>();
                    CompanyOptions companyOptions = new CompanyOptions();
                    for (int i = 0; i < grvCompanyAccessPermission.RowCount; i++)
                    {
                        companyOptions = new CompanyOptions();
                        companyOptions.Id = Guid.NewGuid().ToString();
                        companyOptions.CompanyMasterId = _EditedCompnayMasterSet.Id;
                        companyOptions.PermissionGroupName = grvCompanyAccessPermission.GetRowCellValue(i, colPermissionGroup).ToString();
                        companyOptions.PermissionName = grvCompanyAccessPermission.GetRowCellValue(i, colPermissionName).ToString();
                        companyOptions.IsPurchase = Convert.ToBoolean(grvCompanyAccessPermission.GetRowCellValue(i, colPurchaseIsCheck));
                        companyOptions.IsSales = Convert.ToBoolean(grvCompanyAccessPermission.GetRowCellValue(i, colSaleIsCheck));
                        companyOptions.IsOther = Convert.ToBoolean(grvCompanyAccessPermission.GetRowCellValue(i, colOtherIsCheck));
                        companyOptions.PermissionStatus = true;
                        companyOptions.CreatedBy = Common.LoginUserID;
                        companyOptions.CreatedDate = DateTime.Now;
                        companyOptions.UpdatedBy = Common.LoginUserID;
                        companyOptions.UpdatedDate = DateTime.Now;
                        companyOptionsList.Add(companyOptions);
                    }

                    _EditedCompnayMasterSet.Type = lueCompanyType.EditValue.ToString();
                    _EditedCompnayMasterSet.Name = txtCompanyName.Text;
                    _EditedCompnayMasterSet.Address = txtAddress.Text;
                    _EditedCompnayMasterSet.Address2 = txtAddress2.Text;
                    _EditedCompnayMasterSet.MobileNo = txtMobileNo.Text;
                    _EditedCompnayMasterSet.OfficeNo = txtOfficeNo.Text;
                    _EditedCompnayMasterSet.Details = txtNotes.Text;
                    _EditedCompnayMasterSet.TermsCondition = txtTermsCondition.Text;
                    _EditedCompnayMasterSet.GSTNo = txtGSTNo.Text;
                    _EditedCompnayMasterSet.PanCardNo = txtPancardNo.Text;
                    _EditedCompnayMasterSet.RegistrationNo = txtRegistrationNo.Text;
                    _EditedCompnayMasterSet.UpdatedBy = Common.LoginUserID;
                    _EditedCompnayMasterSet.UpdatedDate = DateTime.Now;
                    _EditedCompnayMasterSet.CompanyOptions = companyOptionsList;

                    if (_EditedCompnayMasterSet.Type == Common.DefaultGuid)
                        _EditedCompnayMasterSet.Type = null;

                    var Result = await _companyMasterRepository.UpdateCompanyAsync(_EditedCompnayMasterSet);

                    if (Result != null)
                    {
                        Reset();
                        MessageBox.Show(AppMessages.GetString(AppMessageID.SaveSuccessfully), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                if (MessageBox.Show(AppMessages.GetString(AppMessageID.AddMoreCompaniesConfirmation), "["+this.Text+"]", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                {
                    string MainSec = @"InfoLogs\\" + Common.AppName +"\\ReportLayouts\\PurchaseReport\\ReportLayouts";
                    Registry.CurrentUser.DeleteSubKeyTree(MainSec, false);

                    string MainSec1 = @"InfoLogs\\" + Common.AppName + "\\ReportLayouts\\SalesReport\\ReportLayouts";
                    Registry.CurrentUser.DeleteSubKeyTree(MainSec1, false);

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
            if (txtCompanyName.Text.Trim().Length == 0)
            {
                MessageBox.Show(AppMessages.GetString(AppMessageID.EmptyCompanyName),"["+this.Text+"]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCompanyName.Focus();
                return false;
            }

            CompanyMaster CompanyNameExist = _companyMasters.Where(c => c.Name == txtCompanyName.Text).FirstOrDefault();
            if((_EditedCompnayMasterSet == null && CompanyNameExist != null) || (CompanyNameExist != null && _EditedCompnayMasterSet != null && _EditedCompnayMasterSet.Name != CompanyNameExist.Name))
            {
                MessageBox.Show(AppMessages.GetString(AppMessageID.CompanyNameExist), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCompanyName.Focus();
                return false;
            }

            return true;
        }

        private void grvCompanyAccessPermission_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column == colPurchaseIsCheck)
            {
                if (grvCompanyAccessPermission.GetRowCellValue(e.RowHandle, colPermissionGroup).ToString() == "Sale"
                    || grvCompanyAccessPermission.GetRowCellValue(e.RowHandle, colPermissionGroup).ToString() == "Other")
                {
                    e.Appearance.BackColor = Color.LightGray;
                }
            }
            else if (e.Column == colSaleIsCheck)
            {
                if (grvCompanyAccessPermission.GetRowCellValue(e.RowHandle, colPermissionGroup).ToString() == "Other")
                {
                    e.Appearance.BackColor = Color.LightGray;
                }
            }
            else if (e.Column == colOtherIsCheck)
            {
                if (grvCompanyAccessPermission.GetRowCellValue(e.RowHandle, colPermissionGroup).ToString() != "Other")
                {
                    e.Appearance.BackColor = Color.LightGray;
                }
            }
        }

        private void grvCompanyAccessPermission_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            //if (e.Column == colPurchaseIsCheck)
            //{
            //    if (grvCompanyAccessPermission.GetRowCellValue(e.RowHandle, colPermissionGroup).ToString() == "Sale")
            //    {
            //        e.RepositoryItem.ReadOnly = true;
            //        e.RepositoryItem.Enabled = false;
            //    }
            //    else
            //    {
            //        e.RepositoryItem.ReadOnly = false;
            //        e.RepositoryItem.Enabled = true;
            //    }
            //}
        }

        private void repositoryItemCheckEdit1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //if (grvCompanyAccessPermission.FocusedColumn == colPurchaseIsCheck)
            //{
            //    if (grvCompanyAccessPermission.GetRowCellValue(grvCompanyAccessPermission.FocusedRowHandle, colPermissionGroup).ToString() == "Sale")
            //    {
            //        e.Cancel = true;
            //    }
            //}
        }

        private void grvCompanyAccessPermission_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (grvCompanyAccessPermission.FocusedColumn == colPurchaseIsCheck)
            {
                if (grvCompanyAccessPermission.GetRowCellValue(grvCompanyAccessPermission.FocusedRowHandle, colPermissionGroup).ToString() == "Sale"
                    || grvCompanyAccessPermission.GetRowCellValue(grvCompanyAccessPermission.FocusedRowHandle, colPermissionGroup).ToString() == "Other")
                {
                    e.Cancel = true;
                }
            }
            if (grvCompanyAccessPermission.FocusedColumn == colSaleIsCheck)
            {
                if (grvCompanyAccessPermission.GetRowCellValue(grvCompanyAccessPermission.FocusedRowHandle, colPermissionGroup).ToString() == "Other")
                {
                    e.Cancel = true;
                }
            }
            else if (grvCompanyAccessPermission.FocusedColumn == colOtherIsCheck)
            {
                if (grvCompanyAccessPermission.GetRowCellValue(grvCompanyAccessPermission.FocusedRowHandle, colPermissionGroup).ToString() != "Other")
                {
                    e.Cancel = true;
                }
            }
        }
    }
}