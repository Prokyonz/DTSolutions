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

namespace DiamondTrading.Transaction
{
    public partial class FrmSlipTransfer : DevExpress.XtraEditors.XtraForm
    {
        public FrmSlipTransfer()
        {
            InitializeComponent();
        }

        public FrmSlipTransfer(string CompanyId,int SlipType, int SlipNo, decimal TotalAmount, List<SlipTransferEntry> slipTransferEntry)
        {
            InitializeComponent();

            _ = LoadCompany();
            GetSlipTypes();
            grdParticularsDetails.DataSource = GetDTColumnsforParticularDetails();

            lueCompany.EditValue = CompanyId;
            lueSlipType.EditValue = SlipType;
            txtSlipNo.Text = SlipNo.ToString();
            txtTotalAmount.Text = TotalAmount.ToString("0.00");
            grdParticularsDetails.DataSource = slipTransferEntry;
        }

        private void FrmSlipTransfer_Load(object sender, EventArgs e)
        {
            dtDate.EditValue = DateTime.Now;
            dtTime.EditValue = DateTime.Now;

            _ = LoadCompany();
            GetSlipTypes();
            grdParticularsDetails.DataSource = GetDTColumnsforParticularDetails();
        }

        private async Task LoadCompany()
        {
            CompanyMasterRepository companyMasterRepository = new CompanyMasterRepository();
            var companies = await companyMasterRepository.GetAllCompanyAsync();
            lueCompany.Properties.DataSource = companies;
            lueCompany.Properties.DisplayMember = "Name";
            lueCompany.Properties.ValueMember = "Id";

            lueCompany.EditValue = Common.LoginCompany;
        }

        private void GetSlipTypes()
        {
            var slipTypes = SlipType.GetSlipTypes();

            if (slipTypes != null)
            {
                lueSlipType.Properties.DataSource = slipTypes;
                lueSlipType.Properties.DisplayMember = "Name";
                lueSlipType.Properties.ValueMember = "Id";
            }
        }

        private static DataTable GetDTColumnsforParticularDetails()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Party");
            dt.Columns.Add("Amount");
            return dt;
        }
    }
}