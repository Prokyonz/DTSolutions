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

namespace DiamondTrading.Transaction
{
    public partial class FrmPaymentEntry : DevExpress.XtraEditors.XtraForm
    {
        private readonly CompanyMasterRepository _companyMasterRepository;
        private readonly PartyMasterRepository _partyMasterRepository;

        public FrmPaymentEntry(string PaymentType)
        {
            InitializeComponent();

            _companyMasterRepository = new CompanyMasterRepository();
            _partyMasterRepository = new PartyMasterRepository();

            if (PaymentType == "Payment")
            {
                SetThemeColors(Color.FromArgb(250, 243, 197));
                this.Text = "PAYMENT";
            }
            else
            {
                SetThemeColors(Color.FromArgb(215, 246, 214));
                this.Text = "RECEIPT";
            }
            LoadCompany();
            LoadLedgers();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblFormTitle_Click(object sender, EventArgs e)
        {

        }

        private void FrmPaymentEntry_Load(object sender, EventArgs e)
        {
            dtDate.EditValue = DateTime.Now;
            dtTime.EditValue = DateTime.Now;

            lueCompany.EditValue = "Abhishek Bendre";
        }

        private void SetThemeColors(Color color)
        {
            if (!color.ToArgb().ToString().Equals(Color.FromArgb(0).Name))
            {
                grpGroup1.AppearanceCaption.BorderColor = color;
                grpGroup2.AppearanceCaption.BorderColor = color;

                //txtLedgerBalance.BackColor = color;
            }
        }

        private async void LoadCompany()
        {
            var result = await _companyMasterRepository.GetAllCompanyAsync();
            lueCompany.Properties.DataSource = result;
            lueCompany.Properties.DisplayMember = "Name";
            lueCompany.Properties.ValueMember = "Id";
        }

        private async void LoadLedgers()
        {
            var result = await _partyMasterRepository.GetAllPartyAsync();
            lueLeadger.Properties.DataSource = result;
            lueLeadger.Properties.DisplayMember = "Name";
            lueLeadger.Properties.ValueMember = "Id";
        }

        private async void lueLeadger_EditValueChanged(object sender, EventArgs e)
        {
            var result = await _partyMasterRepository.GetPartyBalance(lueLeadger.EditValue.ToString());
            txtLedgerBalance.Text = result.ToString();
        }
    }
}