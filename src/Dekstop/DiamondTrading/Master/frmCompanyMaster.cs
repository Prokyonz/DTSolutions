using DevExpress.XtraEditors;
using EFCore.SQL.Repository;
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
    public partial class frmCompanyMaster : DevExpress.XtraEditors.XtraForm
    {
        private readonly CompanyMasterRepository _companyMasterRepository;
        public frmCompanyMaster()
        {
            InitializeComponent();
            _companyMasterRepository = new CompanyMasterRepository();
        }

        private async void frmCompanyMaster_Load(object sender, EventArgs e)
        { 
            var CompanyList = await _companyMasterRepository.GetAllCompanyAsync();
            if(CompanyList!=null)
            {
                lueCompanyType.Properties.DataSource = CompanyList;
                lueCompanyType.Properties.DisplayMember = "Name";
                lueCompanyType.Properties.ValueMember = "Id";
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
            btnSave.Text = "&Save";
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
                Guid tempId = Guid.NewGuid();
                var Result = await _companyMasterRepository.AddCompanyAsync(new Repository.Entities.CompanyMaster
                {
                    Id = tempId,
                    Type = null,//Convert.ToInt32(lueCompanyType.EditValue),
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
                    CreatedBy = tempId,
                    CreatedDate = DateTime.Now,
                    UpdatedBy = tempId,
                    UpdatedDate = DateTime.Now,
                });

                if (Result != null)
                {
                    Reset();
                    MessageBox.Show(AppMessages.GetString(AppMessageID.SaveSuccessfully));
                }
            }
            catch(Exception Ex)
            {

            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}