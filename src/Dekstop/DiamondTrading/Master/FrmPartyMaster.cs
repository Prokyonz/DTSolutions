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
    public partial class FrmPartyMaster : DevExpress.XtraEditors.XtraForm
    {
        private readonly PartyMasterRepository _partyMasterRepository;
        private readonly List<PartyMaster> _partyMasters;
        private PartyMaster _EditedPartyMasterSet;
        private Guid _selectedParty;

        public FrmPartyMaster(List<PartyMaster> PartyMasters)
        {
            InitializeComponent();
            _partyMasterRepository = new PartyMasterRepository();
            this._partyMasters = PartyMasters;
        }

        public FrmPartyMaster(List<PartyMaster> PartyMasters,Guid SelectedParty)
        {
            InitializeComponent();
            _partyMasterRepository = new PartyMasterRepository();
            this._partyMasters = PartyMasters;
            _selectedParty = SelectedParty;
        }

        private async void frmPartyMaster_Load(object sender, EventArgs e)
        {
            await GetListForDepedendeFields();
            
            if (_selectedParty != Guid.Empty)
            {
                _EditedPartyMasterSet = _partyMasters.Where(c => c.Id == _selectedParty).FirstOrDefault();
                if (_EditedPartyMasterSet != null)
                {
                    btnSave.Text = AppMessages.GetString(AppMessageID.Update);
                    tglIsActive.IsOn = _EditedPartyMasterSet.Status;
                    lueCompany.EditValue = _EditedPartyMasterSet.CompanyId;
                    luePartyType.EditValue = _EditedPartyMasterSet.Type;
                    txtPartyName.Text = _EditedPartyMasterSet.Name;
                    txtAddress.Text = _EditedPartyMasterSet.Address;
                    txtAddress2.Text = _EditedPartyMasterSet.Address2;
                    txtMobileNo.Text = _EditedPartyMasterSet.MobileNo;
                    txtOfficeNo.Text = _EditedPartyMasterSet.OfficeNo;
                    txtGSTNo.Text = _EditedPartyMasterSet.GSTNo;
                    txtPancardNo.Text = _EditedPartyMasterSet.PancardNo;
                    txtAadharcardNo.Text = _EditedPartyMasterSet.AadharCardNo;
                }
            }

            txtPartyName.Focus();
        }

        private async Task GetListForDepedendeFields()
        {
            try
            {
                CompanyMasterRepository companyMasterRepository = new CompanyMasterRepository();
                var CompanyList = await companyMasterRepository.GetAllCompanyAsync();

                if (CompanyList != null)
                {
                    lueCompany.Properties.DataSource = CompanyList;
                    lueCompany.Properties.DisplayMember = "Name";
                    lueCompany.Properties.ValueMember = "Id";
                }

                var PartyTypes = PartyTypeMaster.GetAllPartyType();

                if (PartyTypes != null)
                {
                    luePartyType.Properties.DataSource = PartyTypes;
                    luePartyType.Properties.DisplayMember = "Name";
                    luePartyType.Properties.ValueMember = "Id";
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
            _selectedParty = Guid.Empty;
            tglIsActive.IsOn = true;
            lueCompany.EditValue = 0;
            luePartyType.EditValue = 0;
            txtPartyName.Text = "";
            txtAddress.Text = "";
            txtAddress2.Text = "";
            txtMobileNo.Text = "";
            txtOfficeNo.Text = "";
            txtAadharcardNo.Text = "";
            txtGSTNo.Text = "";
            txtPancardNo.Text = "";
            btnSave.Text = AppMessages.GetString(AppMessageID.Save);
            await GetListForDepedendeFields();
            lueCompany.Focus();
        }

        private void frmPartyMaster_KeyDown(object sender, KeyEventArgs e)
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
                    Guid tempId = Guid.NewGuid();

                    PartyMaster PartyMaster = new PartyMaster
                    {
                        Id = tempId,
                        Status=tglIsActive.IsOn,
                        CompanyId = Guid.Parse(lueCompany.EditValue.ToString()),
                        Type = Convert.ToInt32(luePartyType.EditValue),
                        Name = txtPartyName.Text,
                        Address = txtAddress.Text,
                        Address2 = txtAddress2.Text,
                        MobileNo = txtMobileNo.Text,
                        OfficeNo = txtOfficeNo.Text,
                        GSTNo = txtGSTNo.Text,
                        PancardNo = txtPancardNo.Text,
                        AadharCardNo = txtAadharcardNo.Text,
                        IsDelete = false,
                        CreatedBy = Common.LoginUserID,
                        CreatedDate = DateTime.Now,
                        UpdatedBy = Common.LoginUserID,
                        UpdatedDate = DateTime.Now,
                    };

                    var Result = await _partyMasterRepository.AddPartyAsync(PartyMaster);

                    if (Result != null)
                    {
                        Reset();
                        MessageBox.Show(AppMessages.GetString(AppMessageID.SaveSuccessfully), "[" + this.Text + "}", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    _EditedPartyMasterSet.Status = tglIsActive.IsOn;
                    _EditedPartyMasterSet.CompanyId = Guid.Parse(lueCompany.EditValue.ToString());
                    _EditedPartyMasterSet.Type = Convert.ToInt32(luePartyType.EditValue);
                    _EditedPartyMasterSet.Name = txtPartyName.Text;
                    _EditedPartyMasterSet.Address = txtAddress.Text;
                    _EditedPartyMasterSet.Address2 = txtAddress2.Text;
                    _EditedPartyMasterSet.MobileNo = txtMobileNo.Text;
                    _EditedPartyMasterSet.OfficeNo = txtOfficeNo.Text;
                    _EditedPartyMasterSet.GSTNo = txtGSTNo.Text;
                    _EditedPartyMasterSet.PancardNo = txtPancardNo.Text;
                    _EditedPartyMasterSet.AadharCardNo = txtAadharcardNo.Text;
                    _EditedPartyMasterSet.UpdatedBy = Common.LoginUserID;
                    _EditedPartyMasterSet.UpdatedDate = DateTime.Now;

                    var Result = await _partyMasterRepository.UpdatePartyAsync(_EditedPartyMasterSet);

                    if (Result != null)
                    {
                        Reset();
                        MessageBox.Show(AppMessages.GetString(AppMessageID.SaveSuccessfully), "[" + this.Text + "}", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                if (MessageBox.Show(AppMessages.GetString(AppMessageID.AddMorePartyConfirmation), "["+this.Text+"}", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show("Error : "+Ex.Message.ToString(), "[" + this.Text + "}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private bool CheckValidation()
        {
            if(lueCompany.EditValue == null)
            {
                MessageBox.Show(AppMessages.GetString(AppMessageID.EmptyPartyCompanySelection), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lueCompany.Focus();
                return false;
            }
            else if (luePartyType.EditValue == null)
            {
                MessageBox.Show(AppMessages.GetString(AppMessageID.EmptyPartyTypeSelection), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                luePartyType.Focus();
                return false;
            }
            else if (txtPartyName.Text.Trim().Length == 0)
            {
                MessageBox.Show(AppMessages.GetString(AppMessageID.EmptyPartyName),"["+this.Text+"]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPartyName.Focus();
                return false;
            }

            PartyMaster PartyNameExist = _partyMasters.Where(c => c.Name == txtPartyName.Text).FirstOrDefault();
            if((_EditedPartyMasterSet == null && PartyNameExist != null) || (PartyNameExist != null && _EditedPartyMasterSet != null && _EditedPartyMasterSet.Name != PartyNameExist.Name))
            {
                MessageBox.Show(AppMessages.GetString(AppMessageID.PartyNameExist), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPartyName.Focus();
                return false;
            }

            return true;
        }
    }
}