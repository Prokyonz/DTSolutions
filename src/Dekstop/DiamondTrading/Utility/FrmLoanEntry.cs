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
using System.Collections.Generic;
using EFCore.SQL.Repository;

namespace DiamondTrading.Utility
{
    public partial class FrmLoanEntry : DevExpress.XtraEditors.XtraForm
    {
        PartyMasterRepository _partyMasterRepository;


        public FrmLoanEntry()
        {
            InitializeComponent();
            _partyMasterRepository = new PartyMasterRepository();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmLoanEntry_Load(object sender, EventArgs e)
        {
            _ = LoadParty();

            lueReceiveFrom.Properties.DataSource = Common.GetLoanType();
            lueReceiveFrom.Properties.DisplayMember = "Name";
            lueReceiveFrom.Properties.ValueMember = "Id";

            lueDuration.Properties.DataSource = Common.GetLoanDuration();
            lueDuration.Properties.DisplayMember = "Name";
            lueDuration.Properties.ValueMember = "Id";

        }

        private async Task LoadParty()
        {
            var result = await _partyMasterRepository.GetAllPartyAsync(Common.LoginCompany, 10);
            lueParty.Properties.DataSource = result;
            lueParty.Properties.DisplayMember = "Name";
            lueParty.Properties.ValueMember = "Id";
        }
    }
}