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
        private List<PartyMaster> _partyMasters;
        private PartyMaster _EditedPartyMasterSet;
        private string _selectedParty;

        public FrmPartyMaster()
        {
            InitializeComponent();
            _partyMasterRepository = new PartyMasterRepository();
        }

        public FrmPartyMaster(List<PartyMaster> PartyMasters)
        {
            InitializeComponent();
            _partyMasterRepository = new PartyMasterRepository();
            this._partyMasters = PartyMasters;
        }

        public FrmPartyMaster(List<PartyMaster> PartyMasters, string SelectedParty)
        {
            InitializeComponent();
            _partyMasterRepository = new PartyMasterRepository();
            this._partyMasters = PartyMasters;
            _selectedParty = SelectedParty;
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

        public int LedgerType
        {
            get;
            set;
        }

        private async void frmPartyMaster_Load(object sender, EventArgs e)
        {
            if(_partyMasters == null)
                _partyMasters = await _partyMasterRepository.GetAllPartyAsync();

            await GetListForDepedendeFields();

            if (LedgerType == PartyTypeMaster.Buyer)
            {
                luePartyType.EditValue = PartyTypeMaster.Employee;
                lueSubType.EditValue = PartyTypeMaster.Buyer;

                lueCompany.Enabled = false;
                luePartyType.Enabled = false;
                lueSubType.Enabled = false;
                btnReset.Enabled = false;
            }
            else if (LedgerType == PartyTypeMaster.Broker)
            {
                luePartyType.EditValue = PartyTypeMaster.Employee;
                lueSubType.EditValue = PartyTypeMaster.Broker;

                lueCompany.Enabled = false;
                luePartyType.Enabled = false;
                lueSubType.Enabled = false;
                btnReset.Enabled = false;
            }
            else if (LedgerType == PartyTypeMaster.Party)
            {
                luePartyType.EditValue = PartyTypeMaster.Party;

                lueCompany.Enabled = false;
                luePartyType.Enabled = false;
                btnReset.Enabled = false;
            }

            if (_selectedParty != string.Empty)
            {
                _EditedPartyMasterSet = _partyMasters.Where(c => c.Id == _selectedParty).FirstOrDefault();
                if (_EditedPartyMasterSet != null)
                {
                    btnSave.Text = AppMessages.GetString(AppMessageID.Update);
                    tglIsActive.IsOn = _EditedPartyMasterSet.Status;
                    lueCompany.EditValue = _EditedPartyMasterSet.CompanyId;
                    luePartyType.EditValue = _EditedPartyMasterSet.Type;
                    lueSubType.EditValue = _EditedPartyMasterSet.SubType;
                    if(_EditedPartyMasterSet.BrokerageId != null)
                        lueBrokerage.EditValue = _EditedPartyMasterSet.BrokerageId;
                    txtOpeningBalance.Text = _EditedPartyMasterSet.OpeningBalance.ToString();
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

                    lueCompany.EditValue = Common.LoginCompany;
                }

                var PartyTypes = PartyTypeMaster.GetAllMainLedgerType();

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
            _selectedParty = string.Empty;
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
                    string tempId = Guid.NewGuid().ToString();

                    PartyMaster PartyMaster = new PartyMaster
                    {
                        Id = tempId,
                        Status=tglIsActive.IsOn,
                        CompanyId = lueCompany.EditValue.ToString(),
                        Type = Convert.ToInt32(luePartyType.EditValue),
                        OpeningBalance = Convert.ToDecimal(txtOpeningBalance.Text),
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

                    if (Convert.ToInt32(luePartyType.EditValue) == PartyTypeMaster.Employee)
                        PartyMaster.SubType = Convert.ToInt32(lueSubType.EditValue);
                    else
                        PartyMaster.SubType = PartyTypeMaster.None;

                    if (Convert.ToInt32(luePartyType.EditValue) == PartyTypeMaster.Employee && (Convert.ToInt32(lueSubType.EditValue) == PartyTypeMaster.Broker || Convert.ToInt32(lueSubType.EditValue) == PartyTypeMaster.Buyer || Convert.ToInt32(lueSubType.EditValue) == PartyTypeMaster.Seller))
                        PartyMaster.BrokerageId = lueBrokerage.EditValue.ToString();

                    var Result = await _partyMasterRepository.AddPartyAsync(PartyMaster);

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
                    _EditedPartyMasterSet.Status = tglIsActive.IsOn;
                    _EditedPartyMasterSet.CompanyId = lueCompany.EditValue.ToString();
                    _EditedPartyMasterSet.Type = Convert.ToInt32(luePartyType.EditValue);
                    if (Convert.ToInt32(luePartyType.EditValue) == PartyTypeMaster.Employee)
                        _EditedPartyMasterSet.SubType = Convert.ToInt32(lueSubType.EditValue);
                    else
                        _EditedPartyMasterSet.SubType = PartyTypeMaster.None;
                    if (Convert.ToInt32(luePartyType.EditValue) == PartyTypeMaster.Employee && (Convert.ToInt32(lueSubType.EditValue) == PartyTypeMaster.Broker ||
                        Convert.ToInt32(lueSubType.EditValue) == PartyTypeMaster.Buyer || Convert.ToInt32(lueSubType.EditValue) == PartyTypeMaster.Seller))
                        _EditedPartyMasterSet.BrokerageId = lueBrokerage.EditValue.ToString();
                    _EditedPartyMasterSet.OpeningBalance = Convert.ToDecimal(txtOpeningBalance.Text);
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
                        CreatedLedgerID = Result.Id;
                        Reset();
                        MessageBox.Show(AppMessages.GetString(AppMessageID.SaveSuccessfully), "[" + this.Text + "}", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                //if (MessageBox.Show(AppMessages.GetString(AppMessageID.AddMorePartyConfirmation), "["+this.Text+"}", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
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
                MessageBox.Show(AppMessages.GetString(AppMessageID.EmptyLedgerTypeSelection), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                luePartyType.Focus();
                return false;
            }
            else if (Convert.ToInt32(luePartyType.EditValue) == PartyTypeMaster.Employee && lueSubType.EditValue == null)
            {
                MessageBox.Show(AppMessages.GetString(AppMessageID.EmptySubTypeSelection), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                luePartyType.Focus();
                return false;
            }
            else if (Convert.ToInt32(luePartyType.EditValue) == PartyTypeMaster.Employee && Convert.ToInt32(lueSubType.EditValue) == PartyTypeMaster.Broker && lueBrokerage.EditValue == null)
            {
                MessageBox.Show(AppMessages.GetString(AppMessageID.EmptyBrokerageSelection), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void luePartyType_EditValueChanged(object sender, EventArgs e)
        {
            if (luePartyType.EditValue != null)
            {
                if (Convert.ToInt32(luePartyType.EditValue) == PartyTypeMaster.Party)
                {
                    pnl1.Visible = false;
                    pnl2.Visible = false;
                }
                else if (Convert.ToInt32(luePartyType.EditValue) == PartyTypeMaster.Employee)
                {
                    pnl1.Visible = true;
                    pnl2.Visible = false;

                    var SubTypes = PartyTypeMaster.GetAllSubLedgerType();

                    if (SubTypes != null)
                    {
                        lueSubType.Properties.DataSource = SubTypes;
                        lueSubType.Properties.DisplayMember = "Name";
                        lueSubType.Properties.ValueMember = "Id";
                    }

                    if (Convert.ToInt32(lueSubType.EditValue) == PartyTypeMaster.Broker)
                    {
                        lueSubType_EditValueChanged(sender,e);
                    }
                }
                else
                {
                    pnl1.Visible = false;
                    pnl2.Visible = false;
                }
            }
        }

        private async void lueSubType_EditValueChanged(object sender, EventArgs e)
        {
            if (lueSubType.EditValue != null)
            {
                if (Convert.ToInt32(lueSubType.EditValue) == PartyTypeMaster.Other)
                {
                    pnl2.Visible = false;
                }
                else if (Convert.ToInt32(lueSubType.EditValue) == PartyTypeMaster.Broker || Convert.ToInt32(lueSubType.EditValue) == PartyTypeMaster.Buyer
                    || Convert.ToInt32(lueSubType.EditValue) == PartyTypeMaster.Seller)
                {
                    pnl2.Visible = true;

                    BrokerageMasterRepository brokerageMasterRepository = new BrokerageMasterRepository();
                    var Brokerage = await brokerageMasterRepository.GetAllBrokerageAsync();
                    if (Brokerage != null)
                    {
                        lueBrokerage.Properties.DataSource = Brokerage;
                        lueBrokerage.Properties.DisplayMember = "Name";
                        lueBrokerage.Properties.ValueMember = "Id";
                    }
                }
            }
        }
    }
}