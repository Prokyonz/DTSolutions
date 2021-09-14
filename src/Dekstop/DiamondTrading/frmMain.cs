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

namespace DiamondTrading
{
    public partial class FrmMain : DevExpress.XtraEditors.XtraForm
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void accordionControlElement15_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenMasterDetailsForm("CompanyMaster");
        }

        private void OpenMasterDetailsForm(string PageRequested)
        {
            panelControl1.SendToBack();
            FrmMasterDetails page = Application.OpenForms["frmMasterDetails"] as FrmMasterDetails;
            if (page != null)
            {
                page.Close();
                //barManager1.ForceInitialize();
                //page.SelectedTabPage = PageRequested;
                //page.ActiveTab();
                //page.BringToFront();
            }

            FrmMasterDetails frmMasterDetails = new FrmMasterDetails();
            frmMasterDetails.SelectedTabPage = PageRequested;
            frmMasterDetails.MdiParent = this;
            frmMasterDetails.Show();
            frmMasterDetails.BringToFront();

            accordionControlElementMaster.Expanded = true;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            barLblUserName.Caption = Common.LoginUserName;
            FrmCompanyYearSelection frmCompanyYearSelection = new FrmCompanyYearSelection();
            if(frmCompanyYearSelection.ShowDialog()==DialogResult.OK)
            {

            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void barBtnShape_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenMasterDetailsForm("ShapeMaster");
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenMasterDetailsForm("BranchMaster");
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenMasterDetailsForm("PurityMaster");
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenMasterDetailsForm("SizeMaster");
        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenMasterDetailsForm("LessWeightGroupMaster");
        }

        private void accrdianElementCompanyMaster_Click(object sender, EventArgs e)
        {
            OpenMasterDetailsForm("CompanyMaster");
        }

        private void accrdianElementBranchMaster_Click(object sender, EventArgs e)
        {
             OpenMasterDetailsForm("BranchMaster");
        }

        private void accrdianElementShapeMaster_Click(object sender, EventArgs e)
        {
            OpenMasterDetailsForm("ShapeMaster");
        }

        private void accrdianElementSizeMaster_Click(object sender, EventArgs e)
        {
            OpenMasterDetailsForm("SizeMaster");
        }

        private void accrdianElementPurityMaster_Click(object sender, EventArgs e)
        {
            OpenMasterDetailsForm("PurityMaster");
        }

        private void accrdianElementLessWeightGroupMaster_Click(object sender, EventArgs e)
        {
            OpenMasterDetailsForm("LessWeightGroupMaster");
        }

        private void accordionControlElementMaster_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenMasterDetailsForm("GalaMaster");
        }

        private void accrdianElementGalaMaster_Click(object sender, EventArgs e)
        {
            OpenMasterDetailsForm("GalaMaster");
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenMasterDetailsForm("NumberMaster");
        }

        private void accrdianElementNumberMaster_Click(object sender, EventArgs e)
        {
            OpenMasterDetailsForm("NumberMaster");
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenMasterDetailsForm("FinancialYearMaster");
        }

        private void accrdianElementFinancialYearMaster_Click(object sender, EventArgs e)
        {
            OpenMasterDetailsForm("FinancialYearMaster");
        }

        private void accordionControl1_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenMasterDetailsForm("BrokerageMaster");
        }

        private void accrdianElementBrokerageMaster_Click(object sender, EventArgs e)
        {
            OpenMasterDetailsForm("BrokerageMaster");
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenMasterDetailsForm("CurrencyMaster");
        }

        private void accrdianElementCurrencyMaster_Click(object sender, EventArgs e)
        {
            OpenMasterDetailsForm("CurrencyMaster");
        }
    }
}