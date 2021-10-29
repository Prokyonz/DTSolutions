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

namespace DiamondTrading.Process
{
    public partial class FrmAssortProcessReceive : DevExpress.XtraEditors.XtraForm
    {
        AccountToAssortMasterRepository _accountToAssortMasterRepository;
        PartyMasterRepository _partyMasterRepository;

        public FrmAssortProcessReceive()
        {
            InitializeComponent();
            _accountToAssortMasterRepository = new AccountToAssortMasterRepository();
            _partyMasterRepository = new PartyMasterRepository();
        }

        private void SetThemeColors(Color color)
        {
            if (!color.ToArgb().ToString().Equals(Color.FromArgb(0).Name))
            {
                grpGroup1.AppearanceCaption.BorderColor = color;
                grpGroup2.AppearanceCaption.BorderColor = color;
            }
        }

        private async void FrmAssortProcessSend_Load(object sender, EventArgs e)
        {
            dtDate.EditValue = DateTime.Now;
            dtTime.EditValue = DateTime.Now;

            SetThemeColors(Color.FromArgb(215, 246, 214));

            await GetMaxSrNo();
            GetDepartmentList();
            await GetEmployeeList();
            await GetKapanDetail();
        }

        private void GetDepartmentList()
        {
            var Department = DepartmentMaster1.GetAllDepartment();

            if (Department != null)
            {
                lueDepartment.Properties.DataSource = Department;
                lueDepartment.Properties.DisplayMember = "Name";
                lueDepartment.Properties.ValueMember = "Id";
            }
        }

        private async Task GetMaxSrNo()
        {
            var SrNo = await _accountToAssortMasterRepository.GetMaxSrNoAsync(Common.LoginCompany.ToString(), Common.LoginBranch.ToString(), Common.LoginFinancialYear);
            txtSerialNo.Text = SrNo.ToString();
        }

        private async Task GetEmployeeList()
        {
            var EmployeeDetailList = await _partyMasterRepository.GetEmployeeAsync(PartyTypeMaster.Other);
            lueReceiveFrom.Properties.DataSource = EmployeeDetailList;
            lueReceiveFrom.Properties.DisplayMember = "Name";
            lueReceiveFrom.Properties.ValueMember = "Id";

            lueSendto.Properties.DataSource = EmployeeDetailList;
            lueSendto.Properties.DisplayMember = "Name";
            lueSendto.Properties.ValueMember = "Id";
        }

        private async Task GetKapanDetail()
        {
            KapanMasterRepository kapanMasterRepository = new KapanMasterRepository();
            var kapanMaster = await kapanMasterRepository.GetAllKapanAsync();
            lueKapan.Properties.DataSource = kapanMaster;
            lueKapan.Properties.DisplayMember = "Name";
            lueKapan.Properties.ValueMember = "Id";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}